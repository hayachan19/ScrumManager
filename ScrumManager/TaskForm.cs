using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScrumManager
{
    public partial class TaskForm : Form
    {
        int? editID;
        bool editMode;
        int? projectID;
        public TaskForm(int? projectId)
        {
            InitializeComponent();
            projectID = projectId;
            textBox3.Text = projectId.ToString();
            //listBox1
        }

        public TaskForm(int? projectId, int id)
        {
            InitializeComponent();
            editMode = true;
            editID = id;
            projectID = projectId;
            //Delete_Button.Visible = false;
            DataClassesDataContext dbContext = new DataClassesDataContext(ConnectionData.connectionString);
            Task editSprint = dbContext.Tasks.Where(p => p.ProjectId == projectId).Single(q => q.Id == id);
            textBox1.Text = editSprint.Name;     
            textBox3.Text = projectId.ToString();
            //listBox1.SelectedItem = 

        }


        private void button1_Click(object sender, EventArgs e)
        {
            DataClassesDataContext dbContext = new DataClassesDataContext(ConnectionData.connectionString);
            if (editMode == false)
            {
                Task newSprint = new Task();
                newSprint.Name = textBox1.Text;
                newSprint.ProjectId = (int)projectID;
                dbContext.Tasks.InsertOnSubmit(newSprint);
            }
            else
            {
                Task editSprint = dbContext.Tasks.Where(p => p.ProjectId == projectID).Single(q => q.Id == editID);
                editSprint.Name = textBox1.Text;
            }
            try
            {
                dbContext.SubmitChanges();
                Close();
            }
            catch (System.Data.SqlClient.SqlException exception)
            {
                DialogResult sqlError = MessageBox.Show(exception.Message, "Błąd SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (editMode == true && editID != null)
            {
                DataClassesDataContext dbContext = new DataClassesDataContext(ConnectionData.connectionString);
                Sprint editSprint = dbContext.Sprints.Where(p => p.ProjectId == projectID).Single(q => q.Id == editID);
                dbContext.Sprints.DeleteOnSubmit(editSprint);
                dbContext.SubmitChanges();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}

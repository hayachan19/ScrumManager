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
    public partial class ProjectForm : Form
    {
        int? editID;
        bool editMode;
        public ProjectForm()
        {
            InitializeComponent();
        }

        public ProjectForm(int id)
        {
            InitializeComponent();
            editMode = true;
            editID = id;
            DataClassesDataContext dbContext = new DataClassesDataContext();
            Project editProject = dbContext.Projects.Single(p => p.Id == id);
            textBox1.Text = editProject.Name;
            dateTimePicker1.Value = editProject.StartDate;
            dateTimePicker2.Value = editProject.EndDate;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataClassesDataContext dbContext = new DataClassesDataContext();
            Project newProject = new Project();
            newProject.Name = textBox1.Text;
            newProject.StartDate = dateTimePicker1.Value;
            newProject.EndDate = dateTimePicker2.Value;
            dbContext.Projects.InsertOnSubmit(newProject);
            dbContext.SubmitChanges();
            Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (editMode == true && editID != null)
            {
                DataClassesDataContext dbContext = new DataClassesDataContext();
                Project editProject = dbContext.Projects.Single(p => p.Id == editID);
                dbContext.Projects.DeleteOnSubmit(editProject);
                dbContext.SubmitChanges();
            }
        }
    }
}
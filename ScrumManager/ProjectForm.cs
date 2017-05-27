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
            Delete_Button.Visible = false;
            DataClassesDataContext dbContext = new DataClassesDataContext(ConnectionData.connectionString);
            Project editProject = dbContext.Projects.Single(p => p.Id == id);
            ProjectName_TextBox.Text = editProject.Name;
            ProjectStart_DatePicker.Value = editProject.StartDate;
            ProjectEnd_DatePicker.Value = editProject.EndDate;

        }

        private void OK_Button_Click(object sender, EventArgs e)
        {
            DataClassesDataContext dbContext = new DataClassesDataContext(ConnectionData.connectionString);
            if (editMode == false)
            {
                Project newProject = new Project();
                newProject.Name = ProjectName_TextBox.Text;
                newProject.StartDate = ProjectStart_DatePicker.Value;
                newProject.EndDate = ProjectEnd_DatePicker.Value;
                dbContext.Projects.InsertOnSubmit(newProject);
            }
            else
            {
                Project editProject = dbContext.Projects.Single(p => p.Id == editID);
                editProject.Name = ProjectName_TextBox.Text;
                editProject.StartDate = ProjectStart_DatePicker.Value;
                editProject.EndDate = ProjectEnd_DatePicker.Value;
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

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Delete_Button_Click(object sender, EventArgs e)
        {
            if (editMode == true && editID != null)
            {
                DataClassesDataContext dbContext = new DataClassesDataContext(ConnectionData.connectionString);
                Project editProject = dbContext.Projects.Single(p => p.Id == editID);
                dbContext.Projects.DeleteOnSubmit(editProject);
                dbContext.SubmitChanges();
            }
        }
    }
}
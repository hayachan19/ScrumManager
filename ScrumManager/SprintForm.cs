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
    public partial class SprintForm : Form
    {
        int? editID;
        bool editMode;
        int? projectID;
        public SprintForm(int? projectId)
        {
            InitializeComponent();
            projectID = projectId;
            ProjectName_TextBox.Text = projectId.ToString();
        }
        
        public SprintForm(int? projectId, int id)
        {
            InitializeComponent();
            editMode = true;
            editID = id;
            projectID = projectId;
            //Delete_Button.Visible = false;
            DataClassesDataContext dbContext = new DataClassesDataContext(ConnectionData.connectionString);
            Sprint editSprint = dbContext.Sprints.Where(p => p.ProjectId == projectId).Single(q => q.Id == id);
            SprintName_TextBox.Text = editSprint.Name;
            Description_TextBox.Text = editSprint.Description;
            SprintStart_DatePicker.Value = editSprint.StartDate;
            SprintEnd_DatePicker.Value = editSprint.EndDate;
            ProjectName_TextBox.Text = projectId.ToString();

        }

        private void OK_Button_Click(object sender, EventArgs e)
        {
            DataClassesDataContext dbContext = new DataClassesDataContext(ConnectionData.connectionString);
            if (editMode == false)
            {
                Sprint newSprint = new Sprint();
                newSprint.Name = SprintName_TextBox.Text;
                newSprint.Description = Description_TextBox.Text;
                newSprint.StartDate = SprintStart_DatePicker.Value;
                newSprint.EndDate = SprintEnd_DatePicker.Value;
                newSprint.ProjectId = (int)projectID;
                dbContext.Sprints.InsertOnSubmit(newSprint);
            }
            else
            {
                Sprint editSprint = dbContext.Sprints.Where(p => p.ProjectId == projectID).Single(q => q.Id == editID);
                editSprint.Name = SprintName_TextBox.Text;
                editSprint.Description = Description_TextBox.Text;
                editSprint.StartDate = SprintStart_DatePicker.Value;
                editSprint.EndDate = SprintEnd_DatePicker.Value;
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
                Sprint editSprint = dbContext.Sprints.Where(p => p.ProjectId == projectID).Single(q => q.Id == editID);
                dbContext.Sprints.DeleteOnSubmit(editSprint);
                dbContext.SubmitChanges();
            }
        }
    }
}

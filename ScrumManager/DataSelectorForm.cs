using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScrumManager
{
    public partial class DataSelectorForm : Form
    {
        string selectorMode;
        int projectId;
        int sprintId;
        int? taskId;

        public int returnProjectId
        {
            get { return projectId; }
        }

        public int returnSprintId
        {
            get { return sprintId; }
        }

        public DataSelectorForm(string mode, int id, int id2, int? id3)
        {
            InitializeComponent();
            selectorMode = mode;
            projectId = id;
            sprintId = id2;
            taskId = id3;
            DataClassesDataContext dbContext = new DataClassesDataContext(ConnectionData.connectionString);
            BindingSource binder = new BindingSource();
            switch (mode)
            {
                case "tasks":
                    {
                        binder.DataSource = dbContext.Tasks.Where(p => p.ProjectId == projectId);
                        break;
                    }
                case "phases":
                    {
                        binder.DataSource = dbContext.Phases;
                        break;
                    }
            }
            dataGridView1.DataSource = binder;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            int currentId = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            DataClassesDataContext dbContext = new DataClassesDataContext(ConnectionData.connectionString);
            switch (selectorMode)
            {
                case "tasks":
                    {
                        Task selectedTask = dbContext.Tasks.Single(p => p.Id == currentId && p.ProjectId == projectId);
                        SprintTask newTask = new SprintTask();
                        newTask.TaskId = selectedTask.Id;
                        newTask.SprintId = sprintId;
                        newTask.PhaseId = 1;
                        newTask.UserId = ConnectionData.currentUser;
                        dbContext.SprintTasks.InsertOnSubmit(newTask);
                        break;
                    }
                case "phases":
                    {
                        SprintTask selectedTask = dbContext.SprintTasks.Single(p => p.TaskId == taskId && p.SprintId == sprintId);
                        selectedTask.Phase = dbContext.Phases.Single(p => p.Id == currentId);
                        break;
                    }
            }
            try { dbContext.SubmitChanges(); Close(); }
            catch (SqlException exception) { DialogResult sqlError = MessageBox.Show(exception.Message, "Błąd SQL", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}

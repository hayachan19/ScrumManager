using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ScrumManager
{
    public partial class TableView : UserControl
    {
        public TableView()
        {
            InitializeComponent();

        }

        public int getSelectedItem
        {
            get
            {
                return Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            }
        }
        string tableMode;
        int? projectId;
        int? sprintId;
        bool editMode;
        public TableView(string mode, int? id, int? id2)
        {
            InitializeComponent();
            loadTable(mode, id, id2);

        }

        private void loadTable(string mode, int? id, int? id2)
        {
            tableMode = mode;
            projectId = id;
            sprintId = id2;
            DataClassesDataContext dbContext = new DataClassesDataContext(ConnectionData.connectionString);
            BindingSource binder = new BindingSource();
            switch (mode)
            {
                case "projects": { binder.DataSource = dbContext.Projects; break; }
                case "sprints": { binder.DataSource = dbContext.Sprints.Where(p => p.ProjectId == id); break; }
                case "tasks":
                    {
                        if (id2 != null)
                        {
                            binder.DataSource = dbContext.Tasks.Where(p => p.SprintTasks.Any(q => q.Sprint.ProjectId == id && q.SprintId == id2));
                        }
                        else { binder.DataSource = dbContext.Tasks.Where(p => p.ProjectId == id); }

                        break;
                    }
                case "users": { binder.DataSource = dbContext.Users; break; }
                case "roles": { binder.DataSource = dbContext.Roles; break; }
                case "phases": { binder.DataSource = dbContext.Phases; break; }
                case "phaseflow": { binder.DataSource = dbContext.PhaseFlows; break; }
            }
            dataGridView1.DataSource = binder;
            if (ConnectionData.role == "SM_ROLE_WORKER")
            {
                if (tableMode == "tasks" && sprintId != null)
                {
                    toolStripButton2.Visible = false;
                    toolStripButton6.Visible = false;
                }
                else {
                    toolStripButton2.Visible = false;
                    toolStripButton3.Visible = false;
                    toolStripButton6.Visible = false;
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //dodaj
            if (tableMode == "tasks" && sprintId != null)
            {
                DataSelectorForm taskSelector = new DataSelectorForm(tableMode, (int)projectId, (int)sprintId, null);
                taskSelector.ShowDialog();
                loadTable(tableMode, projectId, sprintId);
            }

            else
            {
                editMode = false;
                splitContainer1.Panel2Collapsed = false;
                dataGridView3.Columns.Clear();
                dataGridView3.Rows.Clear();
                foreach (DataGridViewColumn c in dataGridView1.Columns)
                {
                    dataGridView3.Columns.Add((DataGridViewColumn)c.Clone());
                }
                dataGridView3.Columns["Id"].ReadOnly = true;
                dataGridView3.Rows.Add();
            }
            //jezeli dodajemy uzytka to wykonać sql, dać adminowi prawa do tworzenia uzytkow
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            TabControl a = (TabControl)Parent.Parent;
            a.TabPages.Remove(a.SelectedTab);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //edytuj  
            int currentId = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            if (dataGridView1.SelectedRows.Count != 0)
            {
                if (tableMode == "tasks" && sprintId != null)
                {
                    DataSelectorForm taskSelector = new DataSelectorForm("phases", (int)projectId, (int)sprintId, currentId);
                    taskSelector.ShowDialog();
                    loadTable(tableMode, projectId, sprintId);
                }
                else
                {

                    editMode = true;
                    splitContainer1.Panel2Collapsed = false;
                    dataGridView3.Columns.Clear();
                    dataGridView3.Rows.Clear();

                    foreach (DataGridViewColumn c in dataGridView1.Columns)
                    {
                        dataGridView3.Columns.Add((DataGridViewColumn)c.Clone());
                    }
                    dataGridView3.Columns["Id"].ReadOnly = true;
                    DataGridViewRow aaa = (DataGridViewRow)dataGridView1.SelectedRows[0].Clone();
                    int intColIndex = 0;
                    foreach (DataGridViewCell cell in dataGridView1.SelectedRows[0].Cells)
                    {
                        aaa.Cells[intColIndex].Value = cell.Value;
                        intColIndex++;
                    }

                    dataGridView3.Rows.Add(aaa);
                }
            }
        }
        //   string[] adwsfasdf = new string[] { "projects", "sprints", "tasks", "users", "roles", "phases" };

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            //accept
            DialogResult accept = MessageBox.Show("Czy zaakceptować zmiany?", "Edycja", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (accept == DialogResult.OK)
            {
                DataClassesDataContext dbContext = new DataClassesDataContext(ConnectionData.connectionString);
                DataGridViewRow inputData = dataGridView3.Rows[0];
                switch (tableMode)
                {
                    case "projects":
                        {
                            Project editData;
                            if (editMode == true) { editData = dbContext.Projects.Single(p => p.Id == (int)inputData.Cells["Id"].Value); }
                            else { editData = new Project(); }
                            editData.Name = inputData.Cells["Name"].Value.ToString();
                            editData.StartDate = Convert.ToDateTime(inputData.Cells["StartDate"].Value);
                            editData.EndDate = Convert.ToDateTime(inputData.Cells["EndDate"].Value);
                            if (editMode != true) { dbContext.Projects.InsertOnSubmit(editData); }
                            break;
                        }
                    case "sprints":
                        {
                            Sprint editData;
                            if (editMode == true) { editData = dbContext.Sprints.Single(p => p.Id == (int)inputData.Cells["Id"].Value && p.ProjectId == (int)inputData.Cells["ProjectId"].Value); }
                            else { editData = new Sprint(); }
                            editData.Name = inputData.Cells["Name"].Value.ToString();
                            editData.Description = inputData.Cells["Description"].Value.ToString();
                            editData.StartDate = Convert.ToDateTime(inputData.Cells["StartDate"].Value);
                            editData.EndDate = Convert.ToDateTime(inputData.Cells["EndDate"].Value);
                            editData.ProjectId = Convert.ToInt32(projectId);
                            if (editMode != true) { dbContext.Sprints.InsertOnSubmit(editData); }
                            break;
                        }
                    case "tasks":
                        {
                            var a = projectId;
                            var b = sprintId;

                            if (sprintId != null)
                            {//zadania sprintu projektu
                            }
                            else
                            { //zadania projektu
                                //da sie edytowac
                            }
                            break;
                        }
                    case "users":
                        {
                            User editData;
                            if (editMode == true) { editData = dbContext.Users.Single(p => p.Id == (int)inputData.Cells["Id"].Value); }
                            else { editData = new User(); }
                            editData.UserName = inputData.Cells["UserName"].Value.ToString();
                            editData.Password = inputData.Cells["Password"].Value.ToString();
                            editData.RealName = inputData.Cells["RealName"].Value.ToString();
                            editData.ContactEmail = inputData.Cells["ContactEmail"].Value.ToString();
                            editData.RoleId = Convert.ToInt32(inputData.Cells["RoleId"].Value);
                            if (editMode != true) { dbContext.Users.InsertOnSubmit(editData); }
                            break;
                        }
                    case "phases":
                        {
                            Phase editData;
                            if (editMode == true) { editData = dbContext.Phases.Single(p => p.Id == (int)inputData.Cells["Id"].Value); }
                            else { editData = new Phase(); }
                            editData.Name = inputData.Cells["Name"].Value.ToString();
                            if (editMode != true) { dbContext.Phases.InsertOnSubmit(editData); }
                            break;
                        }
                    case "phaseflow":
                        {
                            PhaseFlow editData;
                            if (editMode == true) { editData = dbContext.PhaseFlows.Single(p => p.Id == (int)inputData.Cells["Id"].Value); }
                            else { editData = new PhaseFlow(); }
                            editData.PhaseId = Convert.ToInt32(inputData.Cells["PhaseId"].Value);
                            editData.PreviousPhase = Convert.ToInt32(inputData.Cells["PreviousPhase"].Value);
                            editData.NextPhase = Convert.ToInt32(inputData.Cells["NextPhase"].Value);
                            if (editMode != true) { dbContext.PhaseFlows.InsertOnSubmit(editData); }
                            break;
                        }
                }
                try { dbContext.SubmitChanges(); }
                catch (SqlException exception) { DialogResult sqlError = MessageBox.Show(exception.Message, "Błąd SQL", MessageBoxButtons.OK, MessageBoxIcon.Error); }


            }
            dataGridView1.Rows.Clear();
            loadTable(tableMode, null, null);


        }
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            //zamknij
            dataGridView3.Columns.Clear();
            dataGridView3.Rows.Clear();
            splitContainer1.Panel2Collapsed = true;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            //usuwaczka
            if (dataGridView1.SelectedRows.Count != 0)
            {
                DialogResult accept = MessageBox.Show("Czy na pewno usunąć rekord?", "Usuń", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if (accept == DialogResult.OK)
                {
                    DataClassesDataContext dbContext = new DataClassesDataContext(ConnectionData.connectionString);
                    int currentId = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                    switch (tableMode)
                    {
                        case "projects":
                            {
                                Project nukeData = dbContext.Projects.Single(p => p.Id == currentId);
                                dbContext.Projects.DeleteOnSubmit(nukeData);
                                break;
                            }
                        case "sprints": { break; }
                        case "tasks": { break; }
                        case "users":
                            {
                                User nukeData = dbContext.Users.Single(p => p.Id == currentId);
                                dbContext.Users.DeleteOnSubmit(nukeData);
                                break;
                            }
                        case "phases":
                            {
                                Phase nukeData = dbContext.Phases.Single(p => p.Id == currentId);
                                dbContext.Phases.DeleteOnSubmit(nukeData);
                                break;
                            }
                        case "phaseflow":
                            {
                                PhaseFlow nukeData = dbContext.PhaseFlows.Single(p => p.Id == currentId);
                                dbContext.PhaseFlows.DeleteOnSubmit(nukeData);
                                break;
                            }
                    }
                    try { dbContext.SubmitChanges(); }
                    catch (SqlException exception) { DialogResult sqlError = MessageBox.Show(exception.Message, "Błąd SQL", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

    }
}


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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            if (ConnectionData.role == "SM_ROLE_SUPERVISOR" || ConnectionData.role == "SM_ROLE_WORKER")
            {
                użytkownicyToolStripMenuItem.Visible = false;
                roleToolStripMenuItem.Visible = false;
            }          
        }


        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pokażToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //projekty
            TableView newTable = new TableView("projects", null, null);
            newTable.Dock = DockStyle.Fill;
            TabPage newView = new TabPage("projects");
            newView.Controls.Add(newTable);
            tabControl1.TabPages.Add(newView);
            tabControl1.SelectedTab = newView;
        }

        private void pokażToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            //sprint
            int a;
            SelectorForm selector = new SelectorForm();
            selector.sprintSelector = false;
            selector.ShowDialog();
            a = selector.returnProjectId;
            if (selector.properExit == true)
            {
                TableView newTable = new TableView("sprints", a, null);
                newTable.Dock = DockStyle.Fill;
                TabPage newView = new TabPage("sprints");
                newView.Controls.Add(newTable);
                tabControl1.TabPages.Add(newView);
                tabControl1.SelectedTab = newView;
            }
        }

        private void pokażToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            //zadania
            int a;
            int? b;
            SelectorForm selector = new SelectorForm();
            selector.sprintSelector = true;
            selector.ShowDialog();
            a = selector.returnProjectId;
            b = selector.returnSprintId;
            if (selector.properExit == true)
            {
                TableView newTable = new TableView("tasks", a, b);
                newTable.Dock = DockStyle.Fill;
                TabPage newView = new TabPage("tasks");
                newView.Controls.Add(newTable);
                tabControl1.TabPages.Add(newView);
                tabControl1.SelectedTab = newView;
            }
        }

        private void pokażToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //użytki
            TableView newTable = new TableView("users", null, null);
            newTable.Dock = DockStyle.Fill;
            TabPage newView = new TabPage("users");
            newView.Controls.Add(newTable);
            tabControl1.TabPages.Add(newView);
            tabControl1.SelectedTab = newView;
        }

        private void pokażToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //role
            TableView newTable = new TableView("roles", null, null);
            newTable.Dock = DockStyle.Fill;
            TabPage newView = new TabPage("roles");
            newView.Controls.Add(newTable);
            tabControl1.TabPages.Add(newView);
            tabControl1.SelectedTab = newView;
        }

        private void pokażToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            //fazy
            TableView newTable = new TableView("phases", null, null);
            newTable.Dock = DockStyle.Fill;
            TabPage newView = new TabPage("phases");
            newView.Controls.Add(newTable);
            tabControl1.TabPages.Add(newView);
            tabControl1.SelectedTab = newView;
        }

        private void pokażPrzejściaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //phaseflow
            TableView newTable = new TableView("phaseflow", null, null);
            newTable.Dock = DockStyle.Fill;
            TabPage newView = new TabPage("phaseflow");
            newView.Controls.Add(newTable);
            tabControl1.TabPages.Add(newView);
            tabControl1.SelectedTab = newView;
        }
    }
}

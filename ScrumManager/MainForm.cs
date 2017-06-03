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
            //sprinty i zadania wymagają parametru lub dwóch
            string[] adwsfasdf = new string[] { "projects", "sprints", "tasks", "users", "roles", "phases" };
            foreach (string a in adwsfasdf)
            {
                TableView newTable = new TableView(a, 1, null);
                newTable.Dock = DockStyle.Fill;
                TabPage newView = new TabPage(a);
                newView.Controls.Add(newTable);
                tabControl1.TabPages.Add(newView);
                tabControl1.SelectedTab = newView;
            }
        }


        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pokażToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pokażToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            //sprint
            //open form/ get value from form
            int a;
            int? b;
            using (SelectorForm selector = new SelectorForm())
            {
                selector.ShowDialog();
                a = selector.returnProjectId;
                b = selector.returnSprintId;
            }


            TableView newTable = new TableView("sprints", a, b);
            newTable.Dock = DockStyle.Fill;
            TabPage newView = new TabPage("sprints");
            newView.Controls.Add(newTable);
            tabControl1.TabPages.Add(newView);
            tabControl1.SelectedTab = newView;
        }

        private void pokażToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            //zadania
        }
    }
}

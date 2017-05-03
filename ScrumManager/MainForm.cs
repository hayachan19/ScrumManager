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
        TableUserControl dataTable;
        public MainForm()
        {
            InitializeComponent();
        }

        private void opcjeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var currentTab = tabControl1.SelectedTab;
            tabControl1.TabPages.Remove(currentTab);
        }

        private void użytkownicyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage test = new TabPage("Użytkownicy");
            test.Tag = 'u';
            dataTable = new TableUserControl();
            dataTable.TableDataMode = 'u';
            test.Controls.Add(dataTable);
            tabControl1.TabPages.Add(test);
            tabControl1.SelectedTab = test;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var curtab = tabControl1.SelectedTab;
            char tabtag = Convert.ToChar(curtab.Tag);
            switch (tabtag)
            {
                case 'u': UserForm newUserForm = new UserForm(); newUserForm.ShowDialog(); break;
                case 'r': RoleForm newRoleForm = new RoleForm(); newRoleForm.ShowDialog(); break;
                default: break;
            }
            //curtab.Controls.Remove;
            dataTable.TableDataMode = tabtag;
            dataTable.RefreshTable();

        }

        private void roleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage test = new TabPage("Role");
            test.Tag = 'r';
            dataTable = new TableUserControl();
            dataTable.TableDataMode = 'r';
            test.Controls.Add(dataTable);
            tabControl1.TabPages.Add(test);
            tabControl1.SelectedTab = test;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            dataTable.RefreshTable();
        }
    }
}

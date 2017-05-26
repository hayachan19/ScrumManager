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
        // DataClassesDataContext dbContext;
        public MainForm()
        {
            InitializeComponent();

        }
        //oddzielna klasa jako wrapper, chyba

        // private TabControl.TabPageCollection tabControlPages;
        public TabControl.TabPageCollection TabControlPages
        {
            get { return tabControl.TabPages; }
            //set { tabControl.TabPages.Add(value); }
        }
        //private TabPage tabControlPages2;
        public TabPage TabControlPages2
        {
            set { tabControl.TabPages.Add(value); }
        }

        public TabPage TabWrapperPage_Set
        {
            set { tabControl.SelectedTab = value; }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
            TabPage startTab = new TabPage();
            //TODO: spr wartość w ustawieniach
            {
                WelcomeUserControl welcomePage = new WelcomeUserControl();
                welcomePage.Dock = DockStyle.Fill;
                startTab.Text = "Start";
                startTab.Controls.Add(welcomePage);
            }

            tabControl.TabPages.Add(startTab);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var currentTab = tabControl.SelectedTab;
            //null protecter tutaj
            tabControl.TabPages.Remove(currentTab);
        }



        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //spr null tag
            //albo chowaj przy nie obslugiwanych
            //rozszerza się na role tak czy tak
            var curtab = tabControl.SelectedTab;
            char tabtag = Convert.ToChar(curtab.Tag);
            switch (tabtag)
            {
                case 'u': UserForm newUserForm = new UserForm(); newUserForm.ShowDialog(); break;
                case 'r': RoleForm newRoleForm = new RoleForm(); newRoleForm.ShowDialog(); break;
                case 'p': ProjectForm newProjectForm = new ProjectForm(); newProjectForm.ShowDialog(); break;
                case 's': SprintForm newSprintForm = new SprintForm(); newSprintForm.ShowDialog(); break;
                default: break;
            }
            //curtab.Controls.Remove;
            dataTable.TableDataMode = tabtag; //czy potrzeba?
            dataTable.RefreshTable();

        }


        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var curtab = tabControl.SelectedTab;
            if (curtab.Tag != null)
            {
                dataTable.RefreshTable();
            }
        }

        //zrób jedną funkcję parametryzowaną
        private void użytkownicyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage test = new TabPage("Użytkownicy");
            test.Tag = 'u';
            dataTable = new TableUserControl();
            dataTable.TableDataMode = 'u';
            dataTable.Dock = DockStyle.Fill;
            test.Controls.Add(dataTable);
            tabControl.TabPages.Add(test);
            tabControl.SelectedTab = test;
        }

        private void roleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage test = new TabPage("Role");
            test.Tag = 'r';
            dataTable = new TableUserControl();
            dataTable.TableDataMode = 'r';
            test.Controls.Add(dataTable);
            tabControl.TabPages.Add(test);
            tabControl.SelectedTab = test;
        }

        private void projektyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage test = new TabPage("Projekty");
            test.Tag = 'p';
            dataTable = new TableUserControl();
            dataTable.TableDataMode = 'p';
            test.Controls.Add(dataTable);
            tabControl.TabPages.Add(test);
            tabControl.SelectedTab = test;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker1.ReportProgress(1);
            try { DataClassesDataContext dbContext = new DataClassesDataContext(); }
            catch { }
            backgroundWorker1.ReportProgress(2);
            

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch (e.ProgressPercentage)
            {
                case 1: { toolStripStatusLabel1.Text = "Wczytywanie"; break; }
                case 2: { toolStripStatusLabel1.Text = "Zakończono"; break; }
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            var curtab = tabControl.SelectedTab;
            char tabtag = Convert.ToChar(curtab.Tag);
            switch (tabtag)
            {
                case 'u': UserForm newUserForm = new UserForm(); newUserForm.ShowDialog(); break;
                case 'r': RoleForm newRoleForm = new RoleForm(); newRoleForm.ShowDialog(); break;
                case 'p': ProjectForm newProjectForm = new ProjectForm(dataTable.someMiscTempVarThatShoudntBeHereInTheFirstPlaceToBeginWith); newProjectForm.ShowDialog(); break;
                case 's': SprintForm newSprintForm = new SprintForm(); newSprintForm.ShowDialog(); break;
                default: break;
            }
            //curtab.Controls.Remove;
            dataTable.TableDataMode = tabtag; //czy potrzeba?
            dataTable.RefreshTable();

        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
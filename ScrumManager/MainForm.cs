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


        /*
         * uzytkownik
         * moze wejsc w projekty gdzie jest zapisany - projectmembers
         * moze przejac zadania bez uzytka
         * moze zmienic stan tylko w swoich zadaniach
         * dostep do projekty, sprinty, zadania, jedynie edycja stanu w okienku edycji zadania w sprincie
         * 
         * kierownik
         * moze zakladac projekty i dodawac userow do nich blablabla wszystko oprócz edycji rol, userow i faz
         * 
         * admin
         * 
        */
        /*
         *jprdl
         * mogę zrobić coś co działa, ale dla użytkownika to będzie trochę dziwne
         * interfejs jak w sqlu, wpisujemy coś w okienko np. daj mi sprinty projektu 3
         * sql działa i otwiera tabelkę
         * wpisujemy edytuj/dodaj to i tamto
         * wystakuje zakładka z polami wyciągniętymi prosto z bazy, oczywiście opisana i z polami obcymi jeżeli zajdzie potrzeba
         * gdzieś na dole okienko z poleceniami wykonywanymi, log
         *ostatnie poprawki do bazy i będzie można przepisać to do sql servera
         * prototypowyform.cs ma to o co mi chodzi
         *
         */
        TableUserControl dataTable;

        public MainForm()
        {
            InitializeComponent();
        }

        public TabControl.TabPageCollection TabControlPages
        {
            get { return tabControl.TabPages; }
        }

        public TabPage TabControlPagesCurrent
        {
            get { return tabControl.SelectedTab; }
        }

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
            TabPage startTab = new TabPage();
            {
                WelcomeUserControl welcomePage = new WelcomeUserControl();
                welcomePage.Dock = DockStyle.Fill;
                startTab.Text = "Start";
                startTab.Controls.Add(welcomePage);
            }

            tabControl.TabPages.Add(startTab);
        }

        private void Close_Tab_Click(object sender, EventArgs e)
        {
            var currentTab = tabControl.SelectedTab;
            if (currentTab != null)
            {
                tabControl.TabPages.Remove(currentTab);
            }
        }



        private void Add_Button_Click(object sender, EventArgs e)
        {
            //czysci porjekty przy zamknieciu okienka
            //spr null tag
            //albo chowaj przy nie obslugiwanych
            //rozszerza się na role tak czy tak
            var curtab = tabControl.SelectedTab;
            //char tabtag = Convert.ToChar(curtab.Tag);
            TabTagData tabtabtag = curtab.Tag as TabTagData;      
            //null check
            char tabtag = tabtabtag.Mode;
            int? optID = tabtabtag.optionalID;
            switch (tabtag)
            {
                case 'u': UserForm newUserForm = new UserForm(); newUserForm.ShowDialog(); break;
                case 'r': RoleForm newRoleForm = new RoleForm(); newRoleForm.ShowDialog(); break;
                case 'p': ProjectForm newProjectForm = new ProjectForm(); newProjectForm.ShowDialog(); break;
                case 's': SprintForm newSprintForm = new SprintForm(optID); newSprintForm.ShowDialog(); break;
                case 'f': PhaseForm newPhaseForm = new PhaseForm(); newPhaseForm.ShowDialog(); break;
                case 't': TaskForm newTaskForm = new TaskForm(optID); newTaskForm.ShowDialog(); break;
            }
            //curtab.Controls.Remove;
            //coś tutaj spr
           //dataTable.TableDataMode = tabtag; //czy potrzeba?
          
          //pozostalosc ostatniego
          //nie działa
            //dataTable.RefreshTable();

        }


        private void Refresh_Tab_Click(object sender, EventArgs e)
        {
            /*
             * nie działa
            var curtab = tabControl.SelectedTab;
            TabTagData data = curtab.Tag as TabTagData;
            char test = data.Mode;
            if (test != null)
            {
                dataTable.RefreshTable();
            }
            */
        }


        private void użytkownicyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage test = new TabPage("Użytkownicy");
            TabTagData data = new TabTagData();
            data.Mode = 'u';
            test.Tag = data;
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
            TabTagData data = new TabTagData();
            data.Mode = 'r';
            test.Tag = data;
            dataTable = new TableUserControl();
            dataTable.TableDataMode = 'r';
            test.Controls.Add(dataTable);
            tabControl.TabPages.Add(test);
            tabControl.SelectedTab = test;
        }

        private void projektyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage test = new TabPage("Projekty");         
            TabTagData data = new TabTagData();
            data.Mode = 'p';
            test.Tag = data;
            dataTable = new TableUserControl();
            dataTable.TableDataMode = 'p';
            test.Controls.Add(dataTable);
            tabControl.TabPages.Add(test);
            tabControl.SelectedTab = test;
        }

        private void fazyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage test = new TabPage("Fazy");
            TabTagData data = new TabTagData();
            data.Mode = 'f';
            test.Tag = data;
            dataTable = new TableUserControl();
            dataTable.TableDataMode = 'f';
            test.Controls.Add(dataTable);
            tabControl.TabPages.Add(test);
            tabControl.SelectedTab = test;
        }

        private void Edit_Button_Click(object sender, EventArgs e)
        {
            //gdy rekordu brak nie rób nic
            var curtab = tabControl.SelectedTab;
            
            TabTagData tabtabtag = curtab.Tag as TabTagData;
            char tabtag = tabtabtag.Mode;
            int? optID = tabtabtag.optionalID;
            switch (tabtag)
            {
                case 'u': UserForm newUserForm = new UserForm(); newUserForm.ShowDialog(); break;
                case 'r': RoleForm newRoleForm = new RoleForm(); newRoleForm.ShowDialog(); break;
                case 'p': ProjectForm newProjectForm = new ProjectForm(dataTable.someMiscTempVarThatShoudntBeHereInTheFirstPlaceToBeginWith); newProjectForm.ShowDialog(); break;
                case 's': SprintForm newSprintForm = new SprintForm(optID); newSprintForm.ShowDialog(); break;
                case 'f': PhaseForm newPhaseForm = new PhaseForm(); newPhaseForm.ShowDialog(); break;
                case 't': TaskForm newTaskForm = new TaskForm(optID); newTaskForm.ShowDialog(); break;
            }
            dataTable.TableDataMode = tabtag; 
            //nie działa
            //dataTable.RefreshTable();

        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

       
    }
}
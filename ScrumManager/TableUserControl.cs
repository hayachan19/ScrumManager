using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScrumManager
{
    public partial class TableUserControl : UserControl
    {


        public char TableDataMode;//{ get; set; }
        public int someMiscTempVarThatShoudntBeHereInTheFirstPlaceToBeginWith;
        public TableUserControl()
        {
            InitializeComponent();
        }

        private void TableUserControl_Load(object sender, EventArgs e)
        {
            switch (TableDataMode)
            {
                case 'u': LoadUserTable(); break;
                case 'r': LoadRoleTable(); break;
                //case 'f': LoadPhaseTable(); break; //warto?
                case 'p': LoadProjectTable(); break;
                case 's': LoadSprintTable(someMiscTempVarThatShoudntBeHereInTheFirstPlaceToBeginWith); break;
                case 't': LoadTaskTable(someMiscTempVarThatShoudntBeHereInTheFirstPlaceToBeginWith); break;
                default: break;
                    //na boku guziczki do wlasciwosci

            }
        }

        public void RefreshTable()
        {
            //brzydko ale działa
            dataTableView.Rows.Clear();
            TableUserControl_Load(null, null);
        }

        private void LoadUserTable()
        {
            DataClassesDataContext dbContext = new DataClassesDataContext();
            var data = dbContext.Users;
            dataTableView.ColumnCount = 5;
            dataTableView.Columns[0].Name = "ID";
            dataTableView.Columns[1].Name = "Username";
            dataTableView.Columns[2].Name = "Real Name";
            dataTableView.Columns[3].Name = "E-Mail";
            dataTableView.Columns[4].Name = "Role";
            foreach (var row in data)
            {
                string roleName = "temp"; //temp
                string[] record = { row.Id.ToString(), row.UserName, row.RealName, row.ContactEmail, roleName };
                dataTableView.Rows.Add(record);
            }
        }
        private void LoadRoleTable()
        {
            DataClassesDataContext dbContext = new DataClassesDataContext();
            var test = dbContext.Roles;
            dataTableView.ColumnCount = 3;
            dataTableView.Columns[0].Name = "ID";
            dataTableView.Columns[1].Name = "Nazwa";
            dataTableView.Columns[2].Name = "Nazwa SQL";
            foreach (var row in test)
            {
                string[] record = { row.Id.ToString(), row.Name, row.SQLName };
                dataTableView.Rows.Add(record);
            }
        }

        private void LoadProjectTable()
        {
            DataClassesDataContext dbContext = new DataClassesDataContext();
            var test = dbContext.Projects;
            dataTableView.ColumnCount = 4;
            dataTableView.Columns[0].Name = "ID";
            dataTableView.Columns[1].Name = "Nazwa";
            dataTableView.Columns[2].Name = "start";
            dataTableView.Columns[3].Name = "koniec";
            foreach (var row in test)
            {
                string[] record = { row.Id.ToString(), row.Name, row.StartDate.ToLongDateString(), row.EndDate.ToShortDateString() };
                dataTableView.Rows.Add(record);
            }
        }

        private void LoadSprintTable(int projectId)
        {
            DataClassesDataContext dbContext = new DataClassesDataContext();
            var test = dbContext.Sprints.Where(p => p.ProjectId == projectId);
            dataTableView.ColumnCount = 6;
            dataTableView.Columns[0].Name = "ID";
            dataTableView.Columns[1].Name = "Nazwa";
            dataTableView.Columns[2].Name = "start";
            dataTableView.Columns[3].Name = "koniec";
            dataTableView.Columns[4].Name = "koniec";
            dataTableView.Columns[5].Name = "koniec";
            foreach (var row in test)
            {
                string[] record = { row.Id.ToString(), row.Name, row.Description, row.StartDate.ToLongDateString(), row.EndDate.ToShortDateString(), row.ProjectId.ToString() };
                dataTableView.Rows.Add(record);
            }
        }

        private void LoadTaskTable(int projectId)
        {
            DataClassesDataContext dbContext = new DataClassesDataContext();
            var test = dbContext.Tasks.Where(p => p.ProjectId == projectId);
            dataTableView.ColumnCount = 3;
            dataTableView.Columns[0].Name = "ID";
            dataTableView.Columns[1].Name = "Nazwa";
            dataTableView.Columns[2].Name = "start";
            foreach (var row in test)
            {
                string[] record = { row.Id.ToString(), row.Name, row.ProjectId.ToString() };
                dataTableView.Rows.Add(record);
            }
        }


        private void dataTableView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int testid = Convert.ToInt16(dataTableView[0, e.RowIndex].Value);

            if (TableDataMode == 'p')
            {
                TabPage test = new TabPage("Sprinty" + testid);
                test.Tag = 's';
                TableUserControl dataTable = new TableUserControl();
                dataTable.TableDataMode = 's';
                dataTable.someMiscTempVarThatShoudntBeHereInTheFirstPlaceToBeginWith = testid;
                test.Controls.Add(dataTable);

                TabPage test2 = new TabPage("Zadania" + testid);
                test2.Tag = 't';
                TableUserControl dataTable2 = new TableUserControl();
                dataTable2.TableDataMode = 't';
                dataTable2.someMiscTempVarThatShoudntBeHereInTheFirstPlaceToBeginWith = testid;
                test2.Controls.Add(dataTable2);

                MainForm mainFormtest = (MainForm)this.Parent.Parent.Parent.Parent.Parent; //heh
                mainFormtest.TabControlPages2 = test;
                mainFormtest.TabControlPages2 = test2;
            }





        }

        private void dataTableView_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                someMiscTempVarThatShoudntBeHereInTheFirstPlaceToBeginWith = Convert.ToInt16(dataTableView.SelectedCells[0].Value);
            }

            catch (ArgumentOutOfRangeException)
            {
                //sam nie wiem jak to ugryźć

            }

        }
    }
}
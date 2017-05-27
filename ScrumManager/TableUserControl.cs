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

        /*
         * dwuklik projekty = otwiera sprinty,zadania, uzytkow projektu n
         * sprinty = zadania projektu n sprintu n
         * zadania = brak
         * uzyt
         */
        public char TableDataMode;//{ get; set; }
        public int someMiscTempVarThatShoudntBeHereInTheFirstPlaceToBeginWith;
        public int? anotherMiscTempVarThatShoudntBeHereInTheFirstPlaceToBeginWith;

        public TableUserControl()
        {
            InitializeComponent();
        }

        private void TableUserControl_Load(object sender, EventArgs e)
        {

            var bbb = this.Parent.Parent;
            var aaa = (TabTagData)Parent.Tag;
            var ccc = aaa.optionalID;

            switch (TableDataMode)
            {
                case 'u': LoadUserTable(ccc); break;
                case 'r': LoadRoleTable(); break;
                case 'f': LoadPhaseTable(); break;
                case 'p': LoadProjectTable(); break;
                case 's': LoadSprintTable(Convert.ToInt16(ccc)); break;
                case 't': LoadTaskTable(Convert.ToInt16(ccc)); break;
            }
        }

        public void RefreshTable()
        {
            //albo nie odświeża po edycji lub na zawołanie, albo usuwa wszystko z innych zakładek
            //lepiej mieć to pierwsze
            //brzydko ale działa
            dataTableView.Rows.Clear();
            TableUserControl_Load(null, null);
        }

        private void LoadUserTable(int? projectID)
        {
            DataClassesDataContext dbContext = new DataClassesDataContext(ConnectionData.connectionString);
            IQueryable<ScrumManager.User> data;
            if (projectID != null) { data = dbContext.Users.Where(p => p.ProjectMembers.Any(u => u.ProjectId == projectID)); }
            else { data = dbContext.Users; }
            dataTableView.ColumnCount = 5;
            dataTableView.Columns[0].Name = "ID";
            dataTableView.Columns[1].Name = "Username";
            dataTableView.Columns[2].Name = "Real Name";
            dataTableView.Columns[3].Name = "E-Mail";
            dataTableView.Columns[4].Name = "Role";
            foreach (var row in data)
            {
                string[] record = { row.Id.ToString(), row.UserName, row.RealName, row.ContactEmail, row.Role.Name };
                dataTableView.Rows.Add(record);
            }
        }
        private void LoadRoleTable()
        {
            DataClassesDataContext dbContext = new DataClassesDataContext(ConnectionData.connectionString);
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
            DataClassesDataContext dbContext = new DataClassesDataContext(ConnectionData.connectionString);
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
            DataClassesDataContext dbContext = new DataClassesDataContext(ConnectionData.connectionString);
            var test = dbContext.Sprints.Where(p => p.ProjectId == projectId);
            dataTableView.ColumnCount = 6;
            dataTableView.Columns[0].Name = "ID";
            dataTableView.Columns[1].Name = "Nazwa";
            dataTableView.Columns[2].Name = "start";
            dataTableView.Columns[3].Name = "koniec";
            dataTableView.Columns[4].Name = "sprint";
            dataTableView.Columns[5].Name = "koniec";
            foreach (var row in test)
            {
                string[] record = { row.Id.ToString(), row.Name, row.Description, row.StartDate.ToLongDateString(), row.EndDate.ToShortDateString(), row.ProjectId.ToString() };
                dataTableView.Rows.Add(record);
            }
        }

        private void LoadTaskTable(int projectId)
        {
            DataClassesDataContext dbContext = new DataClassesDataContext(ConnectionData.connectionString);
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

        private void LoadPhaseTable()
        {
            DataClassesDataContext dbContext = new DataClassesDataContext(ConnectionData.connectionString);
            var test = dbContext.Phases;
            dataTableView.ColumnCount = 2;
            dataTableView.Columns[0].Name = "ID";
            dataTableView.Columns[1].Name = "Nazwa";
            foreach (var row in test)
            {
                string[] record = { row.Id.ToString(), row.Name };
                dataTableView.Rows.Add(record);
            }
        }


        private void dataTableView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int testid = Convert.ToInt16(dataTableView[0, e.RowIndex].Value);

            switch (TableDataMode)
            {
                case 'p':
                    {
                        anotherMiscTempVarThatShoudntBeHereInTheFirstPlaceToBeginWith = testid;
                        TabPage test = new TabPage("Sprinty projektu " + testid);
                        TabTagData data = new TabTagData();
                        data.Mode = 's';
                        data.optionalID = testid;
                        test.Tag = data;
                        //test.Tag = 's';
                        TableUserControl dataTable = new TableUserControl();
                        dataTable.TableDataMode = 's';
                        dataTable.someMiscTempVarThatShoudntBeHereInTheFirstPlaceToBeginWith = testid;
                        test.Controls.Add(dataTable);

                        TabPage test2 = new TabPage("Zadania projektu " + testid);
                        TabTagData data2 = new TabTagData();
                        data2.Mode = 't';
                        data2.optionalID = testid;
                        test2.Tag = data2;
                        //test2.Tag = 't';
                        TableUserControl dataTable2 = new TableUserControl();
                        dataTable2.TableDataMode = 't';
                        dataTable2.someMiscTempVarThatShoudntBeHereInTheFirstPlaceToBeginWith = testid;
                        test2.Controls.Add(dataTable2);

                        TabPage test3 = new TabPage("Użytkownicy projektu " + testid);
                        TabTagData data3 = new TabTagData();
                        data3.Mode = 'u';
                        data3.optionalID = testid;
                        test3.Tag = data3;
                        //test3.Tag = 'u';
                        TableUserControl dataTable3 = new TableUserControl();
                        dataTable3.TableDataMode = 'u';
                        dataTable3.someMiscTempVarThatShoudntBeHereInTheFirstPlaceToBeginWith = testid;
                        test3.Controls.Add(dataTable3);

                        MainForm mainFormtest = (MainForm)this.Parent.Parent.Parent.Parent.Parent; //heh
                        mainFormtest.TabControlPages2 = test;
                        mainFormtest.TabControlPages2 = test2;
                        mainFormtest.TabControlPages2 = test3;
                        break;
                    }
                case 's':
                    {
                        var aaa = (TabPage)this.Parent.Tag;
                        //var wambo = aaa.optionalID;
                        int? projectID = 5;// (TabPage)this.Parent;
                        TabPage test = new TabPage("Zadania sprintu " + testid + " projektu" + projectID);
                        test.Tag = 't';
                        TableUserControl dataTable = new TableUserControl();
                        dataTable.TableDataMode = 't';
                        dataTable.someMiscTempVarThatShoudntBeHereInTheFirstPlaceToBeginWith = testid;
                        test.Controls.Add(dataTable);
                        break;
                    }
                case 't':
                    {
                        break;
                    }
                case 'u':
                    { break; }
                case 'f': { break; }
                case 'r': { break; }

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
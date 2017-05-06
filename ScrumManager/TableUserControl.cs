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
                //case 't': LoadTaskTable(); break;
                default: break;
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
            //dataGridView1.DataSource = test;
            //var cols = dataTableView.Columns;
            dataTableView.ColumnCount = 5;
            dataTableView.Columns[0].Name = "ID";
            dataTableView.Columns[1].Name = "Username";
            dataTableView.Columns[2].Name = "Real Name";
            dataTableView.Columns[3].Name = "E-Mail";
            dataTableView.Columns[4].Name = "Role";
            foreach (var row in data)
            {
                string roleName = "ass"; //temp
                string[] record = { row.Id.ToString(), row.UserName, row.RealName, row.ContactEmail, roleName };
                dataTableView.Rows.Add(record);
            }
            //dataGridView1.Columns.Add();
            //dataGridView1.Columns.Remove("RoleId");
        }
        private void LoadRoleTable()
        {
            DataClassesDataContext dbContext = new DataClassesDataContext();
            var test = dbContext.Roles;
            //dataGridView1.DataSource = test;
            var cols = dataTableView.Columns;
            DataGridViewColumn aa = new DataGridViewColumn();
            //aa.
            dataTableView.ColumnCount = 3;
            dataTableView.Columns[0].Name = "ID";
            dataTableView.Columns[1].Name = "Nazwa";
            dataTableView.Columns[2].Name = "Nazwa SQL";
            foreach (var row in test)
            {
                string[] record = { row.Id.ToString(), row.Name, row.SQLName };
                dataTableView.Rows.Add(record);
            }
            //dataGridView1.Columns.Add();
            //dataGridView1.Columns.Remove("RoleId");
        }

        private void LoadProjectTable()
        {
            DataClassesDataContext dbContext = new DataClassesDataContext();
            var test = dbContext.Projects;
            //dataGridView1.DataSource = test;
            var cols = dataTableView.Columns;
            DataGridViewColumn aa = new DataGridViewColumn();
            //aa.
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
            //dataGridView1.Columns.Add();
            //dataGridView1.Columns.Remove("RoleId");
        }

        private void LoadSprintTable(int projectId)
        {
            DataClassesDataContext dbContext = new DataClassesDataContext();
            var test = dbContext.Sprints.Where(p => p.ProjectId == projectId);
            //dataGridView1.DataSource = test;
            var cols = dataTableView.Columns;
            //DataGridViewColumn aa = new DataGridViewColumn();
            //aa.
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
            //dataGridView1.Columns.Add();
            //dataGridView1.Columns.Remove("RoleId");
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
                MainForm mainFormtest = (MainForm)this.Parent.Parent.Parent.Parent.Parent; //heh
                // mainFormtest.TabWrapper_Set = test;
                //mainFormtest.TabWrapperPage_Set = test;
                mainFormtest.TabControlPages2 = test;
                //tabControl.TabPages.Add(test);
                //tabControl.SelectedTab = test;
            }





        }


        
            
            
        }
}

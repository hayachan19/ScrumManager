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
        public char TableDataMode { get; set; }
        public TableUserControl()
        {
            InitializeComponent();
        }

        private void TableUserControl_Load(object sender, EventArgs e)
        {

            var t = TableDataMode;
            //case
            switch (t)
            {
                case 'u': LoadUserTable(); break;
                case 'r': LoadRoleTable(); break;
                default: break;
            }
        }

        public void RefreshTable()
        {
            //brzydko ale działa
            dataGridView1.Rows.Clear();
            TableUserControl_Load(null,null);
        }

        private void LoadUserTable()
        {
            DataClasses1DataContext dbContext = new DataClasses1DataContext();
            var test = dbContext.Users;
            //dataGridView1.DataSource = test;
            var cols = dataGridView1.Columns;
            DataGridViewColumn aa = new DataGridViewColumn();
            //aa.
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[1].Name = "Username";
            dataGridView1.Columns[2].Name = "Real Name";
            dataGridView1.Columns[3].Name = "E-Mail";
            dataGridView1.Columns[4].Name = "Role";
            foreach (var row in test)
            {
                string roleName = "ass";
                string[] record = { row.Id.ToString(), row.UserName,row.RealName,row.ContactEmail,roleName};
                dataGridView1.Rows.Add(record);
            }
            //dataGridView1.Columns.Add();
            //dataGridView1.Columns.Remove("RoleId");
        }
        private void LoadRoleTable()
        {
            DataClasses1DataContext dbContext = new DataClasses1DataContext();
            var test = dbContext.Roles;
            //dataGridView1.DataSource = test;
            var cols = dataGridView1.Columns;
            DataGridViewColumn aa = new DataGridViewColumn();
            //aa.
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[1].Name = "Nazwa";
            dataGridView1.Columns[2].Name = "Nazwa SQL";
            foreach (var row in test)
            {
                string[] record = { row.Id.ToString(), row.Name, row.SQLName};
                dataGridView1.Rows.Add(record);
            }
            //dataGridView1.Columns.Add();
            //dataGridView1.Columns.Remove("RoleId");
        }
    }
}

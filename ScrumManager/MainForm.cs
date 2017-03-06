using ScrumManager.ScrumManagerDataSetTableAdapters;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ScrumManager
{
    public partial class MainForm : Form
    {
        DataClasses1DataContext test;
        string connection;
        SqlConnectionStringBuilder builder;
        public MainForm()
        {
            InitializeComponent();
            connection = ConfigurationManager.ConnectionStrings["ScrumManager.Properties.Settings.ScrumManagerConnectionString"].ConnectionString;
            builder = new SqlConnectionStringBuilder(connection);
            builder.Password = "admin123"; //testowo
            test = new DataClasses1DataContext(connection);
            test.Connection.ConnectionString = builder.ConnectionString;
            dataGridView2.Dock = DockStyle.Fill;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name != "ProjectsTab") {
                var temp = tabControl1.SelectedIndex - 1;
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                tabControl1.SelectedIndex = temp;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            dataGridView2.DataSource = test.Projects;


        }

        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var currentproject = dataGridView2.Rows[e.RowIndex];
            int projectnum = Convert.ToInt32(currentproject.Cells[0].Value);         
            
            DataGridView projectdetail = new DataGridView();

            projectdetail.DataSource = test.Sprints.Where(p => p.ProjectId == projectnum);
            TabPage tb = new TabPage("Projekt " + projectnum.ToString()); 
            tabControl1.TabPages.Add(tb);
            tb.Controls.Add(projectdetail);
            projectdetail.Dock = DockStyle.Fill;
            tabControl1.SelectedTab = tb;     
        }
    }
}
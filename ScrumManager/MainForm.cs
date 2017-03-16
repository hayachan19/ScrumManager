//using ScrumManager.ScrumManagerDataSetTableAdapters;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;


//przerób to albo od nowa zrób bo taki syf
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
            //wynieś to do osobnej klasy
            connection = ConfigurationManager.ConnectionStrings["ScrumManager.Properties.Settings.ScrumManagerConnectionString"].ConnectionString;
            builder = new SqlConnectionStringBuilder(connection);
            builder.Password = "admin123"; //testowo
            test = new DataClasses1DataContext(connection);
            test.Connection.ConnectionString = builder.ConnectionString;
            //chyba będzie potrzeba zrobić projekty programowo bo nierówno jest i trochę wnerwia
            //a tak w ogóle to by było nawet ciekawe zrobić całość 
            dataGridView2.Dock = DockStyle.Fill;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name != "ProjectsTab" || tabControl1.SelectedTab.Name != "UsersTab") {
                var temp = tabControl1.SelectedIndex - 1;
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                tabControl1.SelectedIndex = temp;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'scrumManagerDataSet1.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.scrumManagerDataSet1.Users);
            dataGridView2.DataSource = test.Projects;
            


        }

        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var currentproject = dataGridView2.Rows[e.RowIndex];
            int projectnum = Convert.ToInt32(currentproject.Cells[0].Value);         
            
            DataGridView projectdetail = new DataGridView();
            //ProjectID -> ProjectId
            projectdetail.DataSource = test.Sprints.Where(p => p.ProjectID == projectnum);
            TabPage tb = new TabPage("Projekt " + projectnum.ToString()); 
            tabControl1.TabPages.Add(tb);
            tb.Controls.Add(projectdetail);
            projectdetail.Dock = DockStyle.Fill;
            tabControl1.SelectedTab = tb;
            projectdetail.CellMouseDoubleClick += Projectdetail_CellMouseDoubleClick;
        }

        private void Projectdetail_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            /*
             * var currentsprint = tabControl1.TabPages
            int projectnum = Convert.ToInt32(currentproject.Cells[0].Value);

            DataGridView projectdetail = new DataGridView();
            //ProjectID -> ProjectId
            projectdetail.DataSource = test.Sprints.Where(p => p.ProjectID == projectnum);
            TabPage tb = new TabPage("Projekt " + projectnum.ToString());
            tabControl1.TabPages.Add(tb);
            tb.Controls.Add(projectdetail);
            projectdetail.Dock = DockStyle.Fill;
            tabControl1.SelectedTab = tb;
            projectdetail.CellMouseDoubleClick += Projectdetail_CellMouseDoubleClick;*/
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            NewProjectForm createProject = new NewProjectForm();
            createProject.Show();
        }
    }
}
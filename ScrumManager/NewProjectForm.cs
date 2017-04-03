using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScrumManager
{
    public partial class NewProjectForm : Form
    {
        public NewProjectForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //potem się przeniesie
            string connection = ConfigurationManager.ConnectionStrings["ScrumManager.Properties.Settings.ScrumManagerConnectionString"].ConnectionString;
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connection);
            builder.Password = "admin123"; //testowo
            DataClasses1DataContext test = new DataClasses1DataContext(connection);
            test.Connection.ConnectionString = builder.ConnectionString;

            Project newProject = new Project();
            newProject.Name = textBox1.Text;
            newProject.StartDate = dateTimePicker1.Value;
            newProject.EndDate = dateTimePicker2.Value;
            test.Projects.InsertOnSubmit(newProject);

            //doesnt allow nulls identity needed
            test.SubmitChanges();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

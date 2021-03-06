﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScrumManager
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            //wyciagnij rolę do uprawnien
            InitializeComponent();

            textBox3.Text = Properties.Settings.Default.LastServerName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.UserID = textBox1.Text;
            builder.Password = textBox2.Text;
            builder.DataSource = textBox3.Text;
            builder.InitialCatalog = "ScrumManager";
            ConnectionData.connectionString = builder.ConnectionString;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionData.connectionString))
                {
                    conn.Open();
                }

                if (Properties.Settings.Default.LastServerName != textBox3.Text)
                {
                    Properties.Settings.Default.LastServerName = textBox3.Text;
                    Properties.Settings.Default.Save();
                }
                MainForm main = new MainForm();
                main.Show();
                this.Hide();
            }
            catch (SqlException)
            {
                DialogResult sqlError = MessageBox.Show("Niepoprawne dane logowania", "Błąd logowania", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = @"(LocalDB)\MSSQLLocalDB";
            builder.AttachDBFilename = @"|DataDirectory|\ScrumManager.mdf";
            builder.IntegratedSecurity = true;
            ConnectionData.connectionString = builder.ConnectionString;

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionData.connectionString))
                {
                    conn.Open();
                }

                if (Properties.Settings.Default.LastServerName != textBox3.Text)
                { Properties.Settings.Default.LastServerName = textBox3.Text;
                    Properties.Settings.Default.Save(); }
                MainForm main = new MainForm();
                main.Show();
                this.Hide();
            }
            catch (SqlException)
            {
                DialogResult sqlError = MessageBox.Show("Niepoprawne dane logowania", "Błąd logowania", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
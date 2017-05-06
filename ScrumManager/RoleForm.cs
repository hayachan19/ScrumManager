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
    public partial class RoleForm : Form
    {
        public RoleForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataClassesDataContext dbContext = new DataClassesDataContext();
            //dbContext.Users;
            Role newRole = new Role();
            newRole.Name = textBox2.Text;
            newRole.SQLName = textBox3.Text;
            //dbContext.Roles.InsertOnSubmit(newRole);
            dbContext.Roles.InsertOnSubmit(newRole);
            dbContext.SubmitChanges();
            
            this.Close();
        }
    }
}

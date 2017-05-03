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
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            DataClasses1DataContext dbContext = new DataClasses1DataContext();
            var roles = dbContext.Roles;
            foreach (var role in roles) {
                comboBox1.Items.Add(role);
                    }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext dbContext = new DataClasses1DataContext();
            //dbContext.Users;
            User newUser = new User();
            newUser.UserName = textBox1.Text;
            newUser.Password = textBox4.Text;
            newUser.RealName = textBox2.Text;
            newUser.ContactEmail = textBox3.Text;
            newUser.RoleId = Convert.ToInt16(comboBox1.SelectedValue);
            //1 4 2 3 combo1
            dbContext.Users.InsertOnSubmit(newUser);
            dbContext.SubmitChanges();
        }
    }
}

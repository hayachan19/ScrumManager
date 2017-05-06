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
            using(DataClassesDataContext dbContext = new DataClassesDataContext())
            { var roles = dbContext.Roles;
                foreach (var role in roles) {

                    ComboBoxItem combinedRole = new ComboBoxItem();
                    combinedRole.Value = role.Id;
                    combinedRole.Text = role.Name;
                    comboBox1.Items.Add(combinedRole);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataClassesDataContext dbContext = new DataClassesDataContext();
            //dbContext.Users;
            User newUser = new User();
            newUser.UserName = textBox1.Text;
            newUser.Password = textBox4.Text;
            newUser.RealName = textBox2.Text;
            newUser.ContactEmail = textBox3.Text;
            newUser.RoleId = Convert.ToInt16((comboBox1.SelectedItem as ComboBoxItem).Value);
            //1 4 2 3 combo1
            dbContext.Users.InsertOnSubmit(newUser);
            dbContext.SubmitChanges();
        }
    }
}

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
    public partial class WelcomeUserControl : UserControl
    {
        public WelcomeUserControl()
        {
            InitializeComponent();

            DataClassesDataContext dbContext = new DataClassesDataContext();
            var aaa = dbContext.ProjectMembers;
            var bbb = aaa.Where(p => p.UserId == 1);
            foreach (var item in bbb)
            {
                listBox2.Items.Add(item.Project.Name);
            }
        }

        private void listBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //var list = (ListBox)sender;

            // This is your selected item
            // object item = list.SelectedItem;
            var stuff = listBox2.SelectedItem;
        }
    }
}
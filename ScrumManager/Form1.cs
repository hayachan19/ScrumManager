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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            var test = tabControl1.SelectedTab;
            if (e.Button == MouseButtons.Right)
               
            { 
                //tabControl1.TabPages.Remove(tabControl1.); 
            }
        }
    }
}

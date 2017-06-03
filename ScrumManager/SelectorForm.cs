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
    public partial class SelectorForm : Form
    {
        public SelectorForm()
        {
            InitializeComponent();
        }

        int projectId;
        int? sprintId;

        public int returnProjectId
        {
            get { return projectId; }
        }

        public int? returnSprintId
        {
            get { return sprintId; }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) panel1.Visible = true;
            else panel1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            projectId = (int)numericUpDown1.Value;
            if (checkBox1.Checked) { sprintId = (int)numericUpDown2.Value; }
            else { sprintId = null; }
            Close();
        }
    }
}

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
    public partial class DetailPanel : UserControl
    {
        public DetailPanel()
        {
            InitializeComponent();
        }

        public Control addToFlow
        {
            set { flowLayoutPanel1.Controls.Add(value); }
        }
    }
}

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
    public partial class TableView : UserControl
    {
        public TableView()
        {
            InitializeComponent();
            
        }

        public int getSelectedItem
        {
            get
            {
                return Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            }
        }

        public TableView(string mode, int? id, int? id2)
        {
            InitializeComponent();

            DataClassesDataContext dbContext = new DataClassesDataContext(ConnectionData.connectionString);
            BindingSource binder = new BindingSource();
            switch (mode)
            {
                case "projects": { binder.DataSource = dbContext.Projects; break;}
                case "sprints": { binder.DataSource = dbContext.Sprints.Where(p => p.ProjectId == id); break; }
                case "tasks": {
                        if (id2 != null)
                        {
                            binder.DataSource = dbContext.Tasks.Where(p => p.SprintTasks.Any(q => q.Sprint.ProjectId == id && q.SprintId == id2));
                        }
                        else { binder.DataSource = dbContext.Tasks.Where(p => p.ProjectId == id); }
                        //binder.DataSource = dbContext.Tasks;
                        break;
                    }
                case "users": { binder.DataSource = dbContext.Users; break; }
                case "roles": { binder.DataSource = dbContext.Roles; break; }
                case "phases": { binder.DataSource = dbContext.Phases; break; }
            }
          
            dataGridView1.DataSource = binder;
        }

    }
}

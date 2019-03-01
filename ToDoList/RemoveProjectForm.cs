using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class RemoveProjectForm : Form
    {
        private Controller C { get; set; }

        public RemoveProjectForm(Controller C)
        {
            InitializeComponent();
            this.C = C;
            deleteProjectButton.Text = "Delete Project " + C.AppModel.Projects[C.AppModel.SelectedProject].Name;
        }

        private void deleteProjectButton_Click(object sender, EventArgs e)
        {
            C.RemoveProject(C.AppModel.Projects[C.AppModel.SelectedProject]);
            this.Close();
        }
    }
}

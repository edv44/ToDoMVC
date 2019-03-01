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
    public partial class AddProjectForm : Form
    {
        private Controller C { get; set; }

        public AddProjectForm(Controller C)
        {
            InitializeComponent();
            this.C = C;
        }

        private void AddProjectConfirm_Click(object sender, EventArgs e)
        {
            C.AddProject(textBox1.Text);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

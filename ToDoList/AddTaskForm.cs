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
    public partial class AddTaskForm : Form
    {
        private Controller C { get; set; }

        public AddTaskForm(Controller C)
        {
            InitializeComponent();
            this.C = C;
            foreach (AppProject p in C.AppModel.Projects) comboBox1.Items.Add(p.Name);
            comboBox1.SelectedItem = C.AppModel.SelectedProject.Name;
        }

        private void addTaskButton_Click(object sender, EventArgs e)
        {
            C.AddTask(textBox1.Text);
            this.Close();
        }

        private void addTaskCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

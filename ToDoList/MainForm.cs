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
    public partial class MainForm : Form
    {
        private Controller C { get; set; }

        public MainForm(Controller C)
        {
            InitializeComponent();
            this.C = C;
            foreach (AppProject p in C.AppModel.Projects) comboBox1.Items.Add(p.Name);
            comboBox1.SelectedItem = C.AppModel.SelectedProject.Name;
            //foreach (AppTask t in C.AppModel.SelectedProject.Tasks) listView1.Items.Add(t.Name);
        }

        private void addProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddProjectForm form = new AddProjectForm(C);
            form.ShowDialog();
        }

        private void addTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTaskForm form = new AddTaskForm(C);
            form.ShowDialog();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

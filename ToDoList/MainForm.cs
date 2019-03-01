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

        public MainForm()
        {
            InitializeComponent(); ;
            this.C = new Controller(new Model());
            C.AppModel.ModelChanged += this.UpdateContent;
            UpdateContent();
        }

        private void addProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddProjectForm form = new AddProjectForm(C);
            form.ShowDialog();
        }

        private void removeProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (C.AppModel.Projects.Count > 0)
            {
                RemoveProjectForm form = new RemoveProjectForm(C);
                form.ShowDialog();
            }
            else MessageBox.Show("There are no projects.");

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            C.SelectProject(comboBox1.SelectedItem.ToString());

        }

        private void addTaskButton_Click(object sender, EventArgs e)
        {
            AddTaskForm form = new AddTaskForm(C);
            form.ShowDialog();
        }

        private void closeTaskButton_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null) C.CloseTask(listBox1.SelectedIndex);
        }

        private void UpdateContent()
        {
            //clear main form
            comboBox1.Items.Clear();
            listBox1.Items.Clear();
            comboBox1.SelectedItem = null;
            addTaskButton.Enabled= false;
            closeTaskButton.Enabled= false;

            if (C.AppModel.Projects.Count > 0)
            {
                //fill project combo box
                foreach (AppProject p in C.AppModel.Projects) comboBox1.Items.Add(p.Name);
                comboBox1.SelectedItem = C.AppModel.Projects[C.AppModel.SelectedProject].Name;

                //fill task list box
                foreach (AppTask t in C.AppModel.Projects[C.AppModel.SelectedProject].Tasks)
                {
                    if (t.Done) listBox1.Items.Add("[Done] " + t.Name);
                    else listBox1.Items.Add(t.Name);
                }

                addTaskButton.Enabled = true;
                closeTaskButton.Enabled = true;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiThread
{
    public partial class MainForm : Form
    {
        Model AppModel { get; set; }

        public MainForm(Model model)
        {
            InitializeComponent();
            AppModel = model;
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            foreach (Producer p in AppModel.Producers.Keys) p.Start();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            foreach (Producer p in AppModel.Producers.Keys) p.Stop();
        }
    }
}

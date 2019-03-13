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
        SolidBrush sb;
        Graphics g;

        public MainForm(Model model)
        {
            InitializeComponent();
            AppModel = model;

            sb = new SolidBrush(Color.Black);
            g = CreateGraphics();

            model.DrawEvent += Draw;
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            AppModel.Start();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            AppModel.Stop();
        }

        public void Draw(int x, int y)
        {
            g.FillRectangle(sb, x, y, 3, 3);
        }
    }
}
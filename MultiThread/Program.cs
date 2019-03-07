using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiThread
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Model MainModel = new Model();
            Producer P1 = new Producer(MainModel, 1);
            System.Threading.Thread.Sleep(50); //generates same coordinates without sleep
            Producer P2 = new Producer(MainModel, 2);
            System.Threading.Thread.Sleep(50); //generates same coordinates without sleep
            Producer P3 = new Producer(MainModel, 3);
            System.Threading.Thread.Sleep(50); //generates same coordinates without sleep
            Producer P4 = new Producer(MainModel, 4);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(MainModel));
        }
    }
}
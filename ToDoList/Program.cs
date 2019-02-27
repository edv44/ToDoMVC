using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoList
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Model M = new Model();
            Controller C = new Controller(M);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(C));
        }
    }
}

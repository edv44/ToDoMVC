using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class AppTask
    {
        public string Name { get; set; }
        public bool Done { get; set; }

        public AppTask(string name)
        {
            this.Name = name;
            this.Done = false;
        }
    }
}

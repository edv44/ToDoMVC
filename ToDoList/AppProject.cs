using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class AppProject
    {
        public string Name { get; set; }
        public List<AppTask> Tasks { get; set; }

        public AppProject(string name)
        {
            this.Name = name;
            this.Tasks = new List<AppTask>();
        }

        public void AddTask(string text)
        {
            Tasks.Add(new AppTask(text));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    interface IController
    {
        void AddProject(string name);
        void RemoveProject(AppProject project);
        void AddTask(string name);
        void CompleteTask(AppProject project, string name);
    }
}

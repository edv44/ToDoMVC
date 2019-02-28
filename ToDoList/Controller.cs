using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class Controller : IController
    {
        public Model AppModel { get; set; }

        public Controller(Model model)
        {
            this.AppModel = model;
        }

        public void AddProject(string name) //AddProjectForm click OK; name = textbox content
        {
            this.AppModel.Projects.Add(new AppProject(name));
        }

        public void RemoveProject(AppProject project)
        {
            this.AppModel.Projects.Remove(project);
        }

        public void AddTask(string text)
        {
            int index = AppModel.Projects.IndexOf(AppModel.SelectedProject);
            this.AppModel.Projects[index].AddTask(text);
        }

        public void CompleteTask(AppProject project, string name)
        {
            //set Task.Done = true
        }
    }
}

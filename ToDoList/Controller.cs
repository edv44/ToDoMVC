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
            //init model
            this.AppModel = model;
            AppProject FirstProject = new AppProject("First Project");
            FirstProject.Tasks.Add(new AppTask("First Task"));
            AppModel.Projects = new List<AppProject>();
            AppModel.Projects.Add(FirstProject);
            AppModel.SelectedProject = 0;
        }

        public void AddProject(string name)
        {
            this.AppModel.Projects.Add(new AppProject(name));
            this.AppModel.OnChangeModel();
        }

        public void RemoveProject(AppProject project)
        {
            this.AppModel.Projects.Remove(project);
            if (AppModel.Projects.Count > 0) this.AppModel.SelectedProject = 0;
            this.AppModel.OnChangeModel();
        }

        public void AddTask(string text)
        {
            this.AppModel.Projects[AppModel.SelectedProject].AddTask(text);
            this.AppModel.OnChangeModel();
        }

        public void SelectProject(string selectedText)
        {
            //this.AppModel.Projects.Where(p => p.Name == selectedText);
            for (int i = 0; i < this.AppModel.Projects.Count; i++)
            {
                if (AppModel.Projects[i].Name == selectedText && i != this.AppModel.SelectedProject)
                {
                    AppModel.SelectedProject = i;
                    this.AppModel.OnChangeModel();
                }
            }
        }

        public void CloseTask(int index)
        {
            this.AppModel.Projects[AppModel.SelectedProject].Tasks[index].Done = true;
            this.AppModel.OnChangeModel();
        }
    }
}
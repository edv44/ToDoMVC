using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class Model
    {
        public delegate void ChangeModel();
        public event ChangeModel ModelChanged;
        public AppProject SelectedProject { get; set; }
        public List<AppProject> Projects { get; set; }

        public Model()
        {
            AppProject FirstProject = new AppProject("First Project");
            this.Projects = new List<AppProject>();
            this.Projects.Add(FirstProject);
            this.SelectedProject = this.Projects[0];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class Model
    {
        public delegate void ChangeModelHandler();
        public event ChangeModelHandler ChangeModel;
        public int SelectedProject { get; set; }
        public List<AppProject> Projects { get; set; }

        public void OnChangeModel()
        {
            this.ChangeModel();
        }
    }
}

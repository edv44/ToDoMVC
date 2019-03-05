using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThread
{
    class Model
    {
        public Dictionary<Producer, Point> Producers { get; set; }

        public delegate void ModelChangeHandler(int id, bool limitX, bool limitY);
        public event ModelChangeHandler ModelChangeEvent;

        public void OnCollision(int id, bool limitX, bool limitY)
        {
            this.ModelChangeEvent(id, limitX, limitY);
        }

        public void Move(int id, double dx, double dy)
        {
            //Producers[Producers.Keys.Where(p => p.ID == id)].X += dx;
            //Producers[Producers.Keys.Where(p => p.ID == id)].Y += dy;

            foreach (Producer p in Producers.Keys)
            {
                if (p.ID == id)
                {
                    //Producers[p].X += dx;
                    //Producers[p].Y += dy;
                }
            }
        }
    }
}

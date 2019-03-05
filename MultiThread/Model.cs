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
        public int Size = 500; //square 500x500 px

        public delegate void ModelChangeHandler(int id, bool collideX, bool collideY);
        public event ModelChangeHandler ModelChangeEvent;

        public void OnCollision(int id, bool collideX, bool collideY)
        {
            ModelChangeEvent(id, collideX, collideY);
        }

        public void Move(int id, int dx, int dy)
        {
            foreach (Producer p in Producers.Keys)
            {
                if (p.ID == id)
                {
                    bool IsCollideX = Producers[p].X + dx >= Size ? true : false;
                    bool IsCollideY = Producers[p].Y + dy >= Size ? true : false;

                    if (IsCollideX || IsCollideY) OnCollision(id, IsCollideX, IsCollideY);
                    else Producers[p] = new Point(Producers[p].X + dx, Producers[p].Y + dy);

                    Console.WriteLine("Producer" + p.ID + " [" + Producers[p].X + " : " + Producers[p].Y + "]");
                }
            }
        }
    }
}

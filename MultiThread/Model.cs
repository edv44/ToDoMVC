﻿using System;
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

        public Model()
        {
            Producers = new Dictionary<Producer, Point>();
        }

        public delegate void ModelChangeHandler(int id, bool collideX, bool collideY);
        public event ModelChangeHandler ModelChangeEvent;

        public void OnCollision(int id, bool collideX, bool collideY)
        {
            ModelChangeEvent(id, collideX, collideY);
        }

        public void Move(int id, int dx, int dy)
        {
            /*foreach (Producer p in Producers.Keys)
            {
                if (p.ID == id)
                {
                    bool IsCollideX = Producers[p].X + dx >= Size || Producers[p].X + dx <= 0 ? true : false;
                    bool IsCollideY = Producers[p].Y + dy >= Size || Producers[p].Y + dy <= 0 ? true : false;

                    if (IsCollideX || IsCollideY) OnCollision(id, IsCollideX, IsCollideY);
                    else Producers[p] = new Point(Producers[p].X + dx, Producers[p].Y + dy);

                    Console.WriteLine("Producer" + p.ID + " [" + Producers[p].X + " : " + Producers[p].Y + "]");
                }
            }*/

            for (int i = 0; i < Producers.Count; i++)
            {
                if (Producers.ElementAt(i).Key.ID == id)
                {
                    bool IsCollideX = Producers.ElementAt(i).Value.X + dx >= Size || Producers.ElementAt(i).Value.X + dx <= 0 ? true : false;
                    bool IsCollideY = Producers.ElementAt(i).Value.Y + dy >= Size || Producers.ElementAt(i).Value.Y + dy <= 0 ? true : false;

                    if (IsCollideX || IsCollideY) OnCollision(id, IsCollideX, IsCollideY);
                    else Producers[Producers.ElementAt(i).Key] = new Point(Producers.ElementAt(i).Value.X + dx, Producers.ElementAt(i).Value.Y + dy);

                    Console.WriteLine("Producer" + Producers.ElementAt(i).Key.ID + " [" + Producers.ElementAt(i).Value.X + " : " + Producers.ElementAt(i).Value.Y + "]");
                }
            }
        }
    }
}

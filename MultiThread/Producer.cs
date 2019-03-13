using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThread
{
    public class Producer
    {
        public readonly int ID;
        private Model AppModel;
        private Thread Thread;
        private bool stopped;
        private volatile int dx;
        private volatile int dy;
        private readonly Random r = new Random();

        public Producer(Model model, int id)
        {
            AppModel = model;
            ID = id;
            dx = r.Next(4) + 1;
            dy = r.Next(4) + 1;
            stopped = true;
            AppModel.ModelChangeEvent += ChangeDirection;

            int Xpoint = r.Next(AppModel.Size);
            int Ypoint = r.Next(AppModel.Size);
            AppModel.AddProducer(this, new System.Drawing.Point(Xpoint, Ypoint));
            Console.WriteLine("Producer " + ID + " init at [" + Xpoint + " : " + Ypoint + "]");
        }

        public void Start()
        {
            if (stopped)
            {
                stopped = false;
                Thread = new Thread(SendToModel);
                Thread.Start();
            }
        }

        public void Stop()
        {
            if (!stopped)
            {
                stopped = true;
                Thread.Join();
            }
        }

        public void SendToModel()
        {
            /*int Xpoint = r.Next(AppModel.Size);
            int Ypoint = r.Next(AppModel.Size);
            AppModel.AddProducer(this, new System.Drawing.Point(Xpoint, Ypoint));
            Console.WriteLine("Producer " + ID + " init at [" + Xpoint + " : " + Ypoint + "]");
            dx = r.Next(4) + 1;
            dy = r.Next(4) + 1;*/

            while (!stopped)
            {
                AppModel.AddToMoveList(ID, dx, dy);
                //AppModel.MoveQueue.Enqueue(new int[] { ID, dx, dy });
                //AppModel.MoveQueue.Add(new int[] { ID, dx, dy });
                //AppModel.Move(this.ID, dx, dy);
                Thread.Sleep(50);
            }
        }

        public void ChangeDirection(int id, bool collideX, bool collideY)
        {
            if (ID == id)
            {
                dx = collideX ? -dx : dx;
                dy = collideY ? -dy : dy;
            }
        }
    }
}
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
        public int ID;
        private Model AppModel;
        private Thread Thread;
        private Random r = new Random();
        private volatile bool stopped;
        private volatile int dx;
        private volatile int dy;

        public Producer(Model model, int id)
        {
            AppModel = model;
            ID = id;
            int Xpoint = r.Next(AppModel.Size);
            int Ypoint = r.Next(AppModel.Size);
            Console.WriteLine("Producer " + ID + " init at [" + Xpoint + " : " + Ypoint + "]");
            AppModel.Producers.Add(this, new System.Drawing.Point(Xpoint, Ypoint));
            //Thread = new Thread(SendToModel);
            AppModel.ModelChangeEvent += ChangeDirection;
            dx = r.Next(4) + 1;
            dy = r.Next(4) + 1;
        }

        public void SendToModel()
        {
            while (!stopped)
            {
                this.AppModel.Move(this.ID, dx, dy);
                Thread.Sleep(10); //throws exception on Thread.Interrupt()
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

        public void Start()
        {
            Thread = new Thread(SendToModel);
            Thread.Start();
            stopped = false;

            /*
            switch (Thread.ThreadState.ToString())
            {
                case "Unstarted":
                    AppModel.ModelChangeEvent += ChangeDirection;
                    Thread.Start();
                    break;
                case "Suspended":
                    Thread.Resume();
                    break;
            }*/
        }

        public void Stop()
        {
            if (!stopped)
            {
                stopped = true;
                Thread.Join();
            }

            /*
            switch (Thread.ThreadState.ToString())
            {
                case "Running":
                    Thread.Join();
                    break;
                case "WaitSleepJoin":
                    Thread.Suspend();
                    break;
            }*/

            //Thread.Interrupt();
            //AppModel.ModelChangeEvent -= ChangeDirection;
        }
    }
}
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
        public int ID { get; set; }
        Model AppModel { get; set; }
        Thread Thread { get; set; }
        Random r = new Random();
        int dx { get; set; }
        int dy { get; set; }

        public Producer(Model model, int id)
        {
            AppModel = model;
            ID = id;
            AppModel.Producers.Add(this, new System.Drawing.Point(r.Next(AppModel.Size), r.Next(AppModel.Size)));
            Thread = new Thread(SendToModel);
            dx = r.Next(5);
            dy = r.Next(5);
        }

        public void SendToModel()
        {
            while (true)
            {
                this.AppModel.Move(this.ID, dx, dy);
                Thread.Sleep(500); //throws exception on Thread.Interrupt()
            }
        }

        public void ChangeDirection(int id, bool limX, bool limY)
        {
            if (id == ID)
            {
                dx = limX ? -dx : dx;
                dy = limY ? -dy : dy;
            }
        }

        public void Start()
        {
            if (Thread.ThreadState.ToString() == "Unstarted")
            {
                AppModel.ModelChangeEvent += ChangeDirection;
                Thread.Start();
            }
        }

        public void Stop()
        {
            try
            {
                //Thread.Abort();
                Thread.Interrupt();
                AppModel.ModelChangeEvent -= ChangeDirection;
            }
            catch (ThreadInterruptedException e) { Console.WriteLine(e); }
        }
    }
}
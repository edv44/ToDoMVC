using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThread
{
    class Producer
    {
        public int ID { get; set; }
        Model AppModel { get; set; }
        Thread Thread { get; set; }
        Random r = new Random();
        double dx { get; set; }
        double dy { get; set; }

        public Producer(Model model, int id)
        {
            this.AppModel = model;
            this.ID = id;
            this.AppModel.Producers.Add(this, new System.Drawing.Point(r.Next(250), r.Next(250)));
            this.Thread = new Thread(SendToModel);
            dx = r.NextDouble();
            dy = r.NextDouble();
        }

        public void SendToModel()
        {
            while (true)
            {
                this.AppModel.Move(this.ID, dx, dy);
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
            AppModel.ModelChangeEvent += ChangeDirection;
            Thread.Start();
        }

        public void Stop()
        {
            AppModel.ModelChangeEvent -= ChangeDirection;
            Thread.Interrupt();
        }
    }
}

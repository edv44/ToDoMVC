using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThread
{
    public class Model
    {
        private Dictionary<Producer, Point> Producers { get; set; }
        //public Queue<int[]> MoveQueue;
        private List<int[]> MoveList;
        private readonly Thread Thread;
        private readonly int FrameRate = 50;
        public readonly int Size = 500; //square 500x500 px

        public Model()
        {
            Producers = new Dictionary<Producer, Point>();
            MoveList = new List<int[]>();
            Thread = new Thread(MainLoop);
            //MoveQueue = new Queue<int[]>();
        }

        public delegate void ModelChangeHandler(int id, bool collideX, bool collideY);
        public event ModelChangeHandler ModelChangeEvent;
        public delegate void DrawHandler(int x, int y);
        public event DrawHandler DrawEvent;

        private void OnCollision(int id, bool collideX, bool collideY)
        {
            ModelChangeEvent(id, collideX, collideY);
        }

        private void OnDrawEvent(int x, int y)
        {
            DrawEvent(x, y);
        }

        public void Run()
        {
            Thread.Start();
        }

        public void Start()
        {
            for (int i = 0; i < Producers.Count; i++)
            {
                Producers.ElementAt(i).Key.Start();
            }
        }

        public void Stop()
        {
            for (int i = 0; i < Producers.Count; i++)
            {
                Producers.ElementAt(i).Key.Stop();
            }
        }

        public void AddProducer(Producer NewProducer, Point Position)
        {
            Producers.Add(NewProducer, Position);
        }

        public void AddToMoveList(int id, int dx, int dy)
        {
            lock (MoveList)
            {
                for (int i = 0; i < MoveList.Count; i++)
                {
                    if (MoveList[i][0] == id) MoveList.RemoveAt(i);
                }
                MoveList.Add(new int[] { id, dx, dy });
            }
        }

        private int GetPositionByID(int id)
        {
            int position = 0;
            for (int i = 0; i < Producers.Count; i++)
            {
                if (Producers.ElementAt(i).Key.ID == id) position = Producers.ElementAt(i).Key.ID;
            }
            return position - 1;
        }

        private void MainLoop()
        {
            while (true)
            {
                List<int[]> args;
                if (MoveList.Count > 0)
                {
                    //Queue<int[]> args = new Queue<int[]>(MoveQueue);
                    lock (MoveList)
                    {
                        args = new List<int[]>(MoveList);
                        MoveList.Clear();
                    }

                    for (int i = 0; i < args.Count; i++)
                    {
                        int id = args[i][0];
                        int dx = args[i][1];
                        int dy = args[i][2];

                        int PosX = Producers[Producers.ElementAt(GetPositionByID(id)).Key].X;
                        int PosY = Producers[Producers.ElementAt(GetPositionByID(id)).Key].Y;

                        bool IsCollideX = PosX + dx >= Size || PosX + dx <= 0 ? true : false;
                        bool IsCollideY = PosY + dy >= Size || PosY + dy <= 0 ? true : false;

                        if (IsCollideX || IsCollideY) OnCollision(id, IsCollideX, IsCollideY);
                        else Producers[Producers.ElementAt(GetPositionByID(id)).Key] = new Point(PosX + dx, PosY + dy);
                        Console.WriteLine("Producer" + Producers.ElementAt(GetPositionByID(id)).Key.ID + " [" + PosX + " : " + PosY + "]");
                        DrawEvent(PosX, PosY);
                    }

                    Thread.Sleep(FrameRate);
                    /*foreach (int[] i in args)
                    {
                        if (!HandledIDs.Contains(i[0]) && HandledIDs.Count != Producers.Count)
                        {
                            HandledIDs.Add(i[0]);
                            Console.WriteLine("id " + i[0] + " [" + i[1] + " : " + i[2] + "]");
                            //move
                        }
                    }

                    int[] args = MoveQueue.Dequeue();
                    Console.WriteLine(args[0] + " [" + args[1] + " : " + args[2] + "]");
                    Move(args[0], args[1], args[2]);
                    Thread.Sleep(50);*/
                }
            }
        }

        /*public void Move(int id, int dx, int dy)
        {
            lock (Producers)
            {
                for (int i = 0; i < Producers.Count; i++)
                {
                    if (Producers.ElementAt(i).Key.ID == id)
                    {
                        bool IsCollideX = Producers.ElementAt(i).Value.X + dx >= Size || Producers.ElementAt(i).Value.X + dx <= 0 ? true : false;
                        bool IsCollideY = Producers.ElementAt(i).Value.Y + dy >= Size || Producers.ElementAt(i).Value.Y + dy <= 0 ? true : false;

                        if (IsCollideX || IsCollideY) OnCollision(id, IsCollideX, IsCollideY);
                        else Producers[Producers.ElementAt(i).Key] = new Point(Producers.ElementAt(i).Value.X + dx, Producers.ElementAt(i).Value.Y + dy);
                        Console.WriteLine("Producer" + Producers.ElementAt(i).Key.ID + " [" + Producers.ElementAt(i).Value.X + " : " + Producers.ElementAt(i).Value.Y + "]");
                        DrawEvent(Producers.ElementAt(i).Value.X, Producers.ElementAt(i).Value.Y);
                    }
                }
            }
        */
    }
}

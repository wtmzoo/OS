using System;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;


namespace OS
{
    public class Praktika_5
    {
        public delegate void MyDelegate();



        public static void Start()
        {
            Console.WriteLine("\nTask Scheduler is running");




            worker();

            Thread.Sleep(50000);
        }


        static void worker()
        {
            float stop_time = 6;

            //  Init of threads queue ---
            Queue<Thread> queue = new Queue<Thread>();

            Thread mod_1 = new Thread(module_1);
            queue.Enqueue(mod_1);

            Thread mod_2 = new Thread(module_2);
            queue.Enqueue(mod_2);

            Thread mod_3 = new Thread(module_3);
            queue.Enqueue(mod_3);
            //  --------------------------



            while (true)
            {
                Thread.Sleep(1000);
                Thread first_thread = queue.Dequeue();
                first_thread.Start();


                if (first_thread.Join(1000))
                {
                    Console.WriteLine("The thread left the queue");
                    //first_thread.Abort();
                    first_thread.Interrupt();
                }
                else
                {
                    queue.Enqueue(first_thread);
                    Console.WriteLine("The thread took the last place in the queue");
                    //first_thread.Abort();
                    first_thread.Interrupt();
                }

                if (queue.Count == 0)
                {
                    Console.WriteLine("All threads have been completed");
                    break;
                }
                Console.WriteLine(queue.Count);

            }

            //DateTime Start = DateTime.Now;
            //(float)DateTime.Now.Subtract(Start).TotalSeconds

        }


        static void module_1()
        {
            Console.WriteLine("Module 1 Started");

            //Thread.Sleep(2000);

            Console.WriteLine("Module 1 Done");
        }

        static void module_2()
        {
            Console.WriteLine("Module 2 Started");

            Thread.Sleep(2000);

            Console.WriteLine("Module 2 Done");
        }

        static void module_3()
        {
            Console.WriteLine("Module 3 Started");

            Thread.Sleep(2000);

            Console.WriteLine("Module 3 Done");

        }


    }
}

using System;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;


namespace OS
{ 
    public class Praktika_5
    {
        int count = 3;

        bool[] glob_flag = { false, false, false };
        bool[] glob_isAlive = { true, true, true };
        bool wait_key_flag = true;

        int threads_counter = 0; // Счетчик номера потока


        bool flag = true;



        public void Start()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nTask Scheduler is running\n");
            Console.ResetColor();

            Queue<Thread> queue = new Queue<Thread>();

            //  Init of threads queue ----
            Console.WriteLine("--------------------");
            Console.WriteLine("Adding Thread 1...");
            Thread mod_1 = new Thread(module_1);
            mod_1.Name = $"Thread 1";
            queue.Enqueue(mod_1);
            Thread.Sleep(1000);

            Console.WriteLine("Adding Thread 2...");
            Thread mod_2 = new Thread(module_2);
            mod_2.Name = $"Thread 2";
            queue.Enqueue(mod_2);
            Thread.Sleep(1000);

            Console.WriteLine("Adding Thread 3...");
            Thread mod_3 = new Thread(module_3);
            mod_3.Name = $"Thread 3";
            queue.Enqueue(mod_3);
            Console.WriteLine("--------------------");
            Thread.Sleep(1000);
            //  --------------------------


            while (true)
            {
                glob_flag[threads_counter] = false;

                if (count == 0) break;


                if (glob_isAlive[threads_counter] == true)
                {
                    Thread first_thread = queue.Dequeue();
                    DateTime Start = DateTime.Now;

                    try
                    {
                        first_thread.Start();
                    }
                    catch
                    {
                        glob_flag[threads_counter] = false;
                    }


                    wait_key_flag = true;
                    Thread wait_k = new Thread(wait_key);
                    wait_k.Start();

                    flag = true;
                    while (true)
                    {
                        if (flag == false)
                        {
                            queue.Enqueue(first_thread);
                            break;
                        }

                        if (first_thread.IsAlive == false)
                        {
                            flag = false;
                            glob_flag[threads_counter] = false;
                            wait_key_flag = false;
                            break;
                        }

                        if ((float)DateTime.Now.Subtract(Start).TotalSeconds >= 6 && (glob_isAlive[threads_counter] != false))
                        {
                            flag = false;
                            glob_flag[threads_counter] = true;
                            queue.Enqueue(first_thread);
                            Console.ForegroundColor = ConsoleColor.Red;
                            wait_key_flag = false;
                            Console.WriteLine("The current thread has been running longer than it should. It was stopped");
                            Console.ResetColor();
                            break;
                        }
                    }
                    
                }

                
                //(float)DateTime.Now.Subtract(Start).TotalSeconds

                

                if (threads_counter == 2)
                {
                    threads_counter = 0;
                }
                else
                {
                    threads_counter++;
                }

            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nAll threads has completed its work\n");
            Console.ResetColor();
            Thread.Sleep(5000);
        }




        public void wait_key()
        {
            while (true)
            {
                Thread.Sleep(100);
                if (wait_key_flag != true) break;
                if (Console.ReadKey(true).Key == ConsoleKey.Q && wait_key_flag)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The current thread has been stopped\n");
                    Console.ResetColor();
                    flag = false;
                    glob_flag[threads_counter] = true;
                    break;
                }
            }
        }




        public void module_1()
        {

            Console.WriteLine($"\n{Thread.CurrentThread.Name} is running");

            for (int item = 0; item < 5; item++)
            {
                while (glob_flag[0] == true)
                {
                    Thread.Sleep(100);
                }

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Thread 1 is working");
                Console.ResetColor();
                Thread.Sleep(1000);

            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Thread.CurrentThread.Name} has completed work");
            Console.ResetColor();
            glob_isAlive[0] = false;


            count--;
            Thread.Sleep(1000);
            
        }

        public void module_2()
        {

            Console.WriteLine($"\n{Thread.CurrentThread.Name} is running");

            for (int item = 0; item < 14; item++)
            {
                while (glob_flag[1] == true)
                {
                    Thread.Sleep(100);
                }

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Thread 2 is working");
                Console.ResetColor();
                Thread.Sleep(1000);

            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Thread.CurrentThread.Name} has completed work");
            Console.ResetColor();
            glob_isAlive[1] = false;


            count--;
            Thread.Sleep(1000);

        }

        public void module_3()
        {

            Console.WriteLine($"\n{Thread.CurrentThread.Name} is running");

            for (int item = 0; item < 9; item++)
            {
                while (glob_flag[2] == true)
                {
                    Thread.Sleep(100);
                }

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Thread 3 is working");
                Console.ResetColor();
                Thread.Sleep(1000);

            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Thread.CurrentThread.Name} has completed work");
            Console.ResetColor();
            glob_isAlive[2] = false;

            count--;
            Thread.Sleep(1000);

        }


    }
}

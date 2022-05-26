using System;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;



// Вариант 3

namespace OS
{
    public class Praktika_6
    {


        Queue<int> queue = new Queue<int>();

        int mem_fullness = 0;
        int mem_size = 65536;

        int task_mem_min = 0;
        int task_mem_max = 65535;

        bool wait_flag = false;

        public void Start()
        {
            Console.Clear();
            Console.WriteLine("1. Start\n2. Add new Task\n3. View memory status");

            while (true)
            {
                if (Console.ReadLine() == "1")
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("At this point you can only select option number 1");
                    Console.WriteLine("1. Start\n2. Add new Task\n3. View memory status");
                }
            }

            Thread wait_k1 = new Thread(wait_add_key);
            wait_k1.Start();

            Thread wait_k2 = new Thread(wait_info_key);
            wait_k2.Start();

        }



        void add_task()
        {
            Random rnd = new Random();
            int task_mem_current = rnd.Next(task_mem_min, task_mem_max);

            if (mem_size - mem_fullness >= task_mem_current)
            {
                if (queue.Count == 0)
                {
                    Thread thread = new Thread(() => load_task_to_mem(task_mem_current));
                    thread.Start();
                }
                else
                {
                    queue.Enqueue(task_mem_current);
                    Thread thread = new Thread(() => load_task_to_mem(queue.Dequeue()));
                    //Thread new_thread = new Thread(load_task_to_mem);
                    thread.Start();
                }
            }
            else
            {
                // Добавить таск в очередь
                queue.Enqueue(task_mem_current);
                Console.WriteLine("It is not possible to allocate the right amount of memory. Task is placed in a queue. Size: {0}", task_mem_current);
            }
            
        }


        void load_task_to_mem(int task_mem_current)
        {
            Console.WriteLine("Task is running");
            Console.WriteLine("The memory is filled to {0} bytes", task_mem_current);
            mem_fullness += task_mem_current;
            //Thread.Sleep( (int)glob_task_mem_current / 5 );
            Thread.Sleep(5000);
            mem_fullness -= task_mem_current;
            Console.WriteLine("The memory has been freed up by {0} bytes", task_mem_current);
        }


        void wait_add_key()
        {
            while (true)
            {
                Thread.Sleep(100);
                if (Console.ReadKey(true).Key == ConsoleKey.D2)
                {
                    wait_flag = true;
                    add_task();
                }
            }
        }

        void wait_info_key()
        {
            while (true)
            {
                Thread.Sleep(100);
                if (Console.ReadKey(true).Key == ConsoleKey.D3)
                {
                    
                    string q_str = "";

                    int[] arr = queue.ToArray();

                    // Displaying the elements in array
                    foreach (int ob in arr)
                    {
                        q_str = q_str + ob.ToString() + ";  ";
                    }


                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("STATUS: memory_fullness: {0}; tasks in queue: {1}", mem_fullness, queue.Count);
                    Console.WriteLine("QUEUE STATUS: {0}", q_str);
                    Console.ResetColor();
                }
            }
        }
    }
}

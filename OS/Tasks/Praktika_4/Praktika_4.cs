using System;
using System.IO;
using System.Text;
using System.Diagnostics;

namespace OS
{
    class Praktika_4
    {
        public static void Start()
        {
            Stopwatch stopwatch = new Stopwatch();

            int a = 0, b = 3, c = 3;
            stopwatch.Start();
            for (int i = 0; i < 100000000; i++)
            {
                a += b * 2 + c - i;
            }
            stopwatch.Stop();

            Console.WriteLine(a);
            Console.WriteLine(stopwatch.ElapsedMilliseconds + " ms");
        }

    }
}




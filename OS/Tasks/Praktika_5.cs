using System;


namespace OS
{
    public class Praktika_5
    {
        public static void Start()
        {
            Console.WriteLine("Prk_5");
        }

        static void module_1()
        {
            Console.WriteLine("Module 1 Started");

            char[] letters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            string hash = "1115dd800feaacefdf481f1f9070374a2a81e27880f187396db67958b207cbad".ToString(); // zyzzx
            Praktika_2.Overhelming(letters, hash);
        }

        static void module_2()
        {
            Console.WriteLine("Module 2 Started");

            Praktika_4.Start();
        }

        static void module_3()
        {
            int item = 0;
            for (item = 0; item < 1000000000; item++)
            {
                Console.WriteLine(item);
            }

        }


    }
}

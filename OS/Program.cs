using System;


namespace OS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }


        static void Show_Menu()
        {
            Console.WriteLine("1. Praktika 1\n2. Praktika 2");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch(choice)
            {
                case 1:
                    Praktika_1.Start();
                    break;
                case 2:
                    Praktika_2.Start();
                    break;
            }

        }

    }
}

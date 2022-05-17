using System;


namespace OS
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
            Console.WriteLine("The program has finished execution");
        }


        static void Menu()
        {    
            for (;;)
            {
                Console.WriteLine("1. Run Praktika 1\n2. Run Praktika 2\n3. Run Praktika 3\n4. Run Praktika 4\n5. Run Praktika 5\n6. Run Praktika 6\n7. Clear Console");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\nPraktika_1 Running...\n");
                        Praktika_1.Start();
                        break;
                    case 2:
                        Console.WriteLine("\nPraktika_2 Running...\n");
                        Praktika_2.Start();
                        break;
                    case 3:
                        Console.WriteLine("\nPraktika_3 Running...\n");
                        Praktika_2.Start();
                        break;
                    case 4:
                        Console.WriteLine("\nPraktika_4 Running...\n");
                        Praktika_2.Start();
                        break;
                    case 5:
                        Console.WriteLine("\nPraktika_5 Running...\n");
                        Console.WriteLine("In progress\n");
                        break;
                    case 6:
                        Console.WriteLine("\nPraktika_6 Running...\n");
                        Console.WriteLine("In progress\n");
                        break;
                    case 7:
                        Console.Clear();
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Selection error. Select another option");
                        break;
                }
            }
        }

    }
}
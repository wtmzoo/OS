using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace OS
{
    class Praktika_2
    {
        public static void Start()
        {
            char[] letters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();


            string hash1 = "1115dd800feaacefdf481f1f9070374a2a81e27880f187396db67958b207cbad".ToString(); // zyzzx
            string hash2 = "3a7bd3e2360a3d29eea436fcfb7e44c735d117c42d1c1835420b6b9942dd4f1b".ToString(); // apple
            string hash3 = "74e1bb62f8dabb8125a58852b63bdf6eaef667cb56ac7f7cdba6d7305c50a22f".ToString(); // mmmmm
            string hello = "2cf24dba5fb0a30e26e83b2ac5b9e29e1b161e5c1fa7425e73043362938b9824".ToString(); // hello
            string am = "4edb39d5e30b7baa3c9ee4226de9481e5de97b110e1c474ab3452d060c1f85c3".ToString(); // ammmm
            string pas = "ed968e840d10d2d313a870bc131a4e2c311d7ad09bdf32b3418147221f51a6e2".ToString(); // aaaaa

            Menu(letters, hash3);
        }



        static void Menu(char[] letters, string hash)
        {
            Console.WriteLine("1. One Thread");
            Console.WriteLine("2. Multithreading");
            int num = Convert.ToInt32(Console.ReadLine());

            switch (Convert.ToInt32(num))
            {
                case 1:
                    Overhelming(letters, hash);
                    break;
                case 2:
                    Console.WriteLine("Threads: ");
                    int num_threads = Convert.ToInt32(Console.ReadLine());
                    Separation(letters, num_threads, hash);
                    break;
                default:
                    Console.WriteLine("Break");
                    break;

            }

        }

        static void Separation(char[] letters, int num_threads, string hash)
        {

            Task[] threads = new Task[num_threads];
            for (int i = 0; i < num_threads; i++)
            {
                char[] letters_threads_array = new char[26 - i];
                for (int j = 0; j < 26 - i; j++)
                {
                    letters_threads_array[j] = letters[j + i];
                }
                threads[i] = new Task(() => Overhelming(letters_threads_array, hash));
                threads[i].Start();
            }

            if (Task.WaitAny(threads) != -1)
            {
                for (int i = 0; i < num_threads; i++)
                {
                    threads[i] = null;

                }
            }
        }


        static void Overhelming(char[] letters, string hash)
        {
            int StartTime = Environment.TickCount;

            for (int g = 0; g < letters.Length; g++)
            {
                for (int i = 0; i < letters.Length; i++)
                {
                    for (int j = 0; j < letters.Length; j++)
                    {
                        for (int k = 0; k < letters.Length; k++)
                        {
                            for (int m = 0; m < letters.Length; m++)
                            {
                                string password = letters[g].ToString() + letters[i].ToString() + letters[j].ToString() + letters[k].ToString() + letters[m].ToString();
                                //Console.WriteLine("Overkill password: {0}", password);
                                using (SHA256 MyHash = SHA256.Create())
                                {
                                    if (GetHash(MyHash, password) == hash)
                                    {
                                        int ResultTime = Environment.TickCount - StartTime;
                                        Console.WriteLine("HASH OVERKILL DONE");
                                        Console.WriteLine("Default Hash: {0}\nHash: {1}\n\n", hash, GetHash(MyHash, password));
                                        Console.WriteLine("Password: {0}", password);
                                        Console.WriteLine("Time: {0}s {1}ms", ResultTime / 1000, ResultTime % 1000);
                                        return;
                                    }
                                }

                            }
                        }
                    }
                }

            }
            Console.WriteLine("PASSWORD NOT FOUND!");
            return;
        }


        private static string GetHash(HashAlgorithm hashAlgorithm, string input)
        {
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            var sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}

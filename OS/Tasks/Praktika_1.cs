using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using System.IO.Compression;



namespace OS
{ 
    class Praktika_1
    {
        static int choice_delete()
        {
            Console.WriteLine("Delete file?: Y or N");
            string choice = Console.ReadLine();
            if (choice == "Y")
            {
                return 1;
            }
            return 0;
        }

        public static void Start()
        {
            //string main_dir = "C://";
            string main_dir = @"D:\Documents\";

            // JSON
            string FirstName = "";
            string LastName = "";

            Console.WriteLine("Path to work: ");
            string path = Console.ReadLine();
            //FileWorker.show_directory(path);

            for (; ; )
            {
                ShowMenu.create_menu();
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\nFileName: ");
                        string fileName = Console.ReadLine();
                        FileWorker.create_file(path, fileName);
                        break;
                    case 2:
                        Console.WriteLine("\nFileName: ");
                        string fileName2 = Console.ReadLine();
                        Console.WriteLine("\nText: ");
                        string text = Console.ReadLine();
                        FileWorker.write_to_file(path + fileName2 + ".txt", text);
                        break;
                    case 3:
                        Console.WriteLine("\nFileName: ");
                        string fileName3 = Console.ReadLine();
                        FileWorker.read_file(path + fileName3 + ".txt");
                        break;
                    case 4:
                        if (choice_delete() == 1)
                        {
                            Console.WriteLine("\nFileName: ");
                            string filename = Console.ReadLine();
                            string file_path = path + filename + ".txt";
                            FileWorker.delete_file(file_path);
                        }
                        break;

                    case 5:
                        Console.WriteLine("\nJSON FileName: ");
                        string fileNameJSON5 = Console.ReadLine();
                        FileWorkerJson.create_file(path, fileNameJSON5);
                        break;
                    case 6:
                        Console.WriteLine("\nFileName: ");
                        string fileNameJSON6 = Console.ReadLine();
                        FileWorkerJson.write_to_file(path + fileNameJSON6 + ".json");
                        break;
                    case 7:
                        Console.WriteLine("\nFileName: ");
                        string fileNameJSON7 = Console.ReadLine();
                        FileWorker.read_file(path + fileNameJSON7 + ".json");
                        break;
                    case 8:
                        if (choice_delete() == 1)
                        {
                            Console.WriteLine("\nFileName: ");
                            string filenameJSON8 = Console.ReadLine();
                            string file_pathJSON = path + filenameJSON8 + ".json";
                            FileWorker.delete_file(file_pathJSON);
                        }
                        break;


                    case 9:
                        Console.WriteLine("\nXML FileName: ");
                        string fileNameXML9 = Console.ReadLine();
                        FileWorkerXML.create_file(path, fileNameXML9);
                        break;
                    case 10:
                        Console.WriteLine("\nXML_TEXT: ");
                        string textXML = Console.ReadLine();
                        Console.WriteLine("\nFileName: ");
                        string fileNameXML10 = Console.ReadLine();
                        FileWorkerXML.write_to_file(path + fileNameXML10 + ".xml", textXML);
                        break;
                    case 11:
                        Console.WriteLine("\nFileName: ");
                        string fileNameXML11 = Console.ReadLine();
                        FileWorkerXML.read_file(path + fileNameXML11 + ".xml");
                        break;
                    case 12:
                        if (choice_delete() == 1)
                        {
                            Console.WriteLine("\nFileName: ");
                            string filenameXML12 = Console.ReadLine();
                            string file_pathXML = path + filenameXML12 + ".xml";
                            FileWorkerXML.delete_file(file_pathXML);
                        }
                        break;

                    case 13:
                        ZipWorker.create_zip();
                        break;
                    case 14:
                        ZipWorker.add_file();
                        break;
                    case 15:
                        ZipWorker.extract_zip();
                        break;
                    case 16:
                        if (choice_delete() == 1)
                        {
                            Console.WriteLine("\nZIP_FileName: ");
                            string filenameZIP12 = Console.ReadLine();
                            string file_pathXML = path + filenameZIP12 + ".zip";
                            FileWorkerXML.delete_file(file_pathXML);
                        }
                        break;

                    case 0:
                        Environment.Exit(0);
                        break;
                }
            }
        }



    }



    class ShowMenu
    {
        public static void create_menu()
        {
            Console.WriteLine("------------------------");
            Console.WriteLine("1. TXT: Create File");
            Console.WriteLine("2. TXT: Write String");
            Console.WriteLine("3. TXT: Read File");
            Console.WriteLine("4. TXT: Delete File");
            Console.WriteLine("------------------------");
            Console.WriteLine("5. JSON: Create File");
            Console.WriteLine("6. JSON: Write String");
            Console.WriteLine("7. JSON: Read File");
            Console.WriteLine("8. JSON: Delete File");
            Console.WriteLine("------------------------");
            Console.WriteLine("9.  XML: Create File");
            Console.WriteLine("10. XML: Write String");
            Console.WriteLine("11. XML: Read File");
            Console.WriteLine("12. XML: Delete File");
            Console.WriteLine("------------------------");
            Console.WriteLine("13. ZIP: Create Archive");
            Console.WriteLine("14. ZIP: Add File");
            Console.WriteLine("15. ZIP: Extract");
            Console.WriteLine("16. ZIP: Delete Archive");
            Console.WriteLine("------------------------");
            Console.WriteLine("Choice: ");
        }
    }

    class ZipWorker
    {
        public static void create_zip()
        {
            ZipFile.CreateFromDirectory(@"D:\Documents\test archive", @"D:\Documents\release.zip");
        }

        public static void add_file()
        {
            using (FileStream zipToOpen = new FileStream(@"D:\Documents\release.zip", FileMode.Open))
            {
                using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
                {
                    ZipArchiveEntry readmeEntry = archive.CreateEntry("Readme.txt");
                    using (StreamWriter writer = new StreamWriter(readmeEntry.Open()))
                    {
                        writer.WriteLine("Information about this package.");
                        writer.WriteLine("========================");
                    }
                }
            }
        }

        public static void extract_zip()
        {
            ZipFile.ExtractToDirectory(@"D:\Documents\release.zip", @"D:\Documents\result");
        }

    }


    class FileWorker
    {
        // Create File in path 
        public static void create_file(string path, string fileName)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(path + fileName + ".txt");
                FileStream fs = fileInfo.Create();
                //fs.Write(Encoding.UTF8.GetBytes(text));
                fs.Close();
                Console.WriteLine("------------------------");
                Console.WriteLine("File Successfuly Created!");
                Console.WriteLine("------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static void delete_file(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            if (fileInfo.Exists)
            {
                fileInfo.Delete();
                Console.WriteLine("------------------------");
                Console.WriteLine("File Successfuly Deleted!");
                Console.WriteLine("------------------------");
                return;
            }
            Console.WriteLine("------------------------");
            Console.WriteLine("ERROR");
            Console.WriteLine("------------------------");
        }

        public static void read_file(string path)
        {

            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            StreamReader str = new StreamReader(fs);
            string data = str.ReadToEnd();
            string[] dataArray = data.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine("\nFile Content:");

            for (int i = 0; i < dataArray.Length; i++)
            {
                Console.WriteLine(dataArray[i]);

            }
            str.Close();
        }

        public static void write_to_file(string path, string text)
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    fs.Write(Encoding.UTF8.GetBytes(text));
                    Console.WriteLine("Text Successfuly Added");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
        }

        public static void create_directory(string path, string subpath)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);

            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            dirInfo.CreateSubdirectory(subpath);
        }



        public static void show_directory(string dir)
        {
            string[] dirs = Directory.GetDirectories(dir);

            foreach (string s in dirs)
            {
                Console.WriteLine(s);
            }
        }

        public static void show_files(string dir)
        {
            string[] files = Directory.GetFiles(dir);

            foreach (string s in files)
            {
                Console.WriteLine(s);
            }
        }


    }



    // JSON -----------------------------------------------------------

    class JsonEmployee
    {
        public string FirstName;
        public string LastName;
    }


    class FileWorkerJson
    {
        // Create File in path 
        public static void create_file(string path, string fileName)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(path + fileName + ".json");
                FileStream fs = fileInfo.Create();
                //fs.Write(Encoding.UTF8.GetBytes(text));
                fs.Close();
                Console.WriteLine("------------------------");
                Console.WriteLine("File Successfuly Created!");
                Console.WriteLine("------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static void delete_file(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            if (fileInfo.Exists)
            {
                fileInfo.Delete();
                Console.WriteLine("------------------------");
                Console.WriteLine("File Successfuly Deleted!");
                Console.WriteLine("------------------------");
                return;
            }
            Console.WriteLine("------------------------");
            Console.WriteLine("ERROR");
            Console.WriteLine("------------------------");
        }

        public static void write_to_file(string path)
        {



            JsonEmployee emp = new JsonEmployee();
            emp.FirstName = "John";
            emp.LastName = "Wick";

            string json = JsonConvert.SerializeObject(emp);


            try
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    fs.Write(Encoding.UTF8.GetBytes(json));
                    Console.WriteLine("Text Successfuly Added");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
        }



        public static void read_file(string path)
        {

            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            StreamReader str = new StreamReader(fs);
            string data = str.ReadToEnd();
            string[] dataArray = data.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine("\nFile Content:");

            for (int i = 0; i < dataArray.Length; i++)
            {
                Console.WriteLine(dataArray[i]);

            }
            str.Close();
        }
    }





    // XML ---------------------


    class FileWorkerXML
    {
        // Create File in path 
        public static void create_file(string path, string fileName)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(path + fileName + ".xml");
                FileStream fs = fileInfo.Create();
                //fs.Write(Encoding.UTF8.GetBytes(text));
                fs.Close();
                Console.WriteLine("------------------------");
                Console.WriteLine("File Successfuly Created!");
                Console.WriteLine("------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static void delete_file(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            if (fileInfo.Exists)
            {
                fileInfo.Delete();
                Console.WriteLine("------------------------");
                Console.WriteLine("File Successfuly Deleted!");
                Console.WriteLine("------------------------");
                return;
            }
            Console.WriteLine("------------------------");
            Console.WriteLine("ERROR");
            Console.WriteLine("------------------------");
        }

        public static void read_file(string path)
        {

            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            StreamReader str = new StreamReader(fs);
            string data = str.ReadToEnd();
            string[] dataArray = data.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine("\nFile Content:");

            for (int i = 0; i < dataArray.Length; i++)
            {
                Console.WriteLine(dataArray[i]);

            }
            str.Close();
        }

        public static void write_to_file(string path, string text)
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    fs.Write(Encoding.UTF8.GetBytes(text));
                    Console.WriteLine("Text Successfuly Added");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
        }

        public static void create_directory(string path, string subpath)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);

            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            dirInfo.CreateSubdirectory(subpath);
        }



        public static void show_directory(string dir)
        {
            string[] dirs = Directory.GetDirectories(dir);

            foreach (string s in dirs)
            {
                Console.WriteLine(s);
            }
        }

        public static void show_files(string dir)
        {
            string[] files = Directory.GetFiles(dir);

            foreach (string s in files)
            {
                Console.WriteLine(s);
            }
        }


    }


}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BackUpHT.Devices;

namespace BackUpHT
{
    public class ConsoleView
    {
        public ConsoleView()
        {

            CreateRandomFiles(20);
            
            StartMenu();
        }

        public List<File> files = new List<File>();
        public Random rnd = new Random();

        private HDD hdd = new HDD("HDD", "Toshiba", 20, 200000, 1);
        private DVD dvd = new DVD("USB", "x33", 50, "R", 15000);
        private Flash flash = new Flash("USB", "x33", 50, 8000);

        public void StartMenu()
        {
            Console.Clear();
           // hdd.files[i];
            Console.WriteLine("1. Список устройств");
            Console.WriteLine("2. Список файлов");
            Console.WriteLine("3. Копировать данные");

            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    ListDevicesMenu();
                    break;
                case 2:
                    FileListMenu();
                    break;
                case 3:
                    BackUpInDevice();
                    break;
            }
        }

        public void BackUpInDevice()
        {
            double s = 1.0;
            for (int i = 0; i < files.Count; i++)
            {
                s += files[i].FileSize;
            }

            Console.Clear();
            Console.WriteLine("Необходимое пространство для копирования всех файлов: " + s + " Mb" +
                "\nВыбирите устройство для копирования:\n");
            Console.WriteLine("1." + hdd.Name);
            Console.WriteLine("2." + dvd.Name);
            Console.WriteLine("3." + flash.Name);
            Console.WriteLine("\n0 - Назад");


            switch (int.Parse(Console.ReadLine()))
            {
                case 0:
                    StartMenu();
                    break;
                case 1:
                    {
                        Console.Clear();

                        if (s < hdd.FreeMemory())
                        {
                            for (int i = 0; i < files.Count; i++)
                            {
                                hdd.CopyData(files[i]);
                               
                                Console.WriteLine("имя файла: {0}\tСтатус: Успешно скопировано\n", files[i].FileName);
                            }
                        }
                        else Console.WriteLine("Недостаточно памяти");

                        Console.WriteLine("Нажмите любую клавишу что-бы продолжить!");
                        Console.ReadLine();

                        BackUpInDevice();
                    }
                    break;
                case 2:
                    {
                        Console.Clear();

                        if (s < dvd.FreeMemory())
                        {
                            for (int i = 0; i < files.Count; i++)
                            {
                                dvd.CopyData(files[i]);
                                Console.WriteLine("имя файла: {0}\tСтатус: Успешно скопировано\n", files[i].FileName);
                            }
                        }
                        else Console.WriteLine("Недостаточно памяти");

                        Console.WriteLine("Нажмите любую клавишу что-бы продолжить!");
                        Console.ReadLine();
                        BackUpInDevice();
                    }
                    break;
                case 3:
                    {
                        Console.Clear();
                        if (s < flash.FreeMemory())
                        {
                            for (int i = 0; i < files.Count; i++)
                            {
                                flash.CopyData(files[i]);
                                Console.WriteLine("имя файла: {0}\tСтатус: Успешно скопировано\n", files[i].FileName);
                            }
                        }
                        else Console.WriteLine("Недостаточно памяти");

                        Console.WriteLine("Нажмите любую клавишу что-бы продолжить!");
                        Console.ReadLine();
                        BackUpInDevice();
                    }
                    break;
            }
        }

        public void ListDevicesMenu()
        {
            Console.Clear();
            Console.WriteLine(
                "1. {0}\n------------------------\n1. {1}\n------------------------\n1. {2}\n------------------------\n",
                flash.GetDeviceiceInfo(), hdd.GetDeviceiceInfo(), dvd.GetDeviceiceInfo()
                );

            Console.WriteLine("\n0 - Назад");
            if (int.Parse(Console.ReadLine()) == 0) StartMenu();
        }

        public void CreateRandomFiles(int count)
        {
            for (int i = 0; i < count; i++)
            {
                files.Add(CreateFile("rar", "file_" + i, rnd.Next(2, 1000)));
            }
        }
        public void FileListMenu()
        {
            Console.Clear();
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine(files[i].Info);
            }

            Console.WriteLine("\n0 - Назад");
            if (int.Parse(Console.ReadLine()) == 0) StartMenu();
        }

        public double GetSharedMemory()
        {
            return flash.Memory + hdd.Memory + dvd.Memory;
        }
        public File CreateFile(string Type, string Name, int Size)
        {
            return new File(Type, Name, Size);
        }
    }
}

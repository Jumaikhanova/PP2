using System;
using System.IO;

namespace Task1
{
    class FarManager
    {
        public int cursor;
        public string path;
        public int sz;
        DirectoryInfo directory = null;
        FileSystemInfo current_fs = null;

        public FarManager(string path)
        {
            this.path = path; //обращаемся к рабочему каталогу 
            cursor = 0; //ставим курсор на начало
            directory = new DirectoryInfo(path); // привязываемся к рабочему каталогу
            sz = directory.GetFileSystemInfos().Length;//все файлы и директории, которые находятся в рабочем каталоге
        }

        public void Color(FileSystemInfo fs, int index) //передаем файл либо директорию и ее индекс
        {
            if (cursor == index)//если индекс совпадает с курсором, то курсор стоит на данной строке
            {
                Console.BackgroundColor = ConsoleColor.Red;
                current_fs = fs;//запоминаем в current_fs текущее положение
            }
            else if (fs.GetType() == typeof(DirectoryInfo))//если директория 
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else //если файл
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }
        public void Up()
        {
            cursor--;
            if (cursor < 0)
                cursor = sz - 1;
        }
        public void Down()
        {
            cursor++;
            if (cursor == sz)
                cursor = 0;
        }
        public void CalcSz()
        {
            directory = new DirectoryInfo(path); //привязываемся к новому рабочему каталогу
            FileSystemInfo[] fs = directory.GetFileSystemInfos(); //получаем все файлы и директории
            sz = fs.Length;
        }
        public void Start()
        {
            ConsoleKeyInfo consolekey = Console.ReadKey(); 
            while (consolekey.Key != ConsoleKey.Escape)
            {
                CalcSz();
                Show();
                consolekey = Console.ReadKey();//ждем нажатия кнопки
                if (consolekey.Key == ConsoleKey.UpArrow)
                {
                    Up();
                }
                if (consolekey.Key == ConsoleKey.DownArrow)
                {
                    Down();
                }
                if (consolekey.Key == ConsoleKey.RightArrow)
                {
                    if (current_fs.GetType() == typeof(DirectoryInfo))//если папка
                    {
                        cursor = 0;
                        path = current_fs.FullName; //возвращает полный путь вместе с данной папкой
                    }
                }
                if (consolekey.Key == ConsoleKey.LeftArrow)
                {
                    cursor = 0; 
                    path = directory.Parent.FullName; //возвращает назад
                    
                }
                if (consolekey.Key == ConsoleKey.Backspace)
                {
                    if (current_fs.GetType() == typeof(DirectoryInfo))//если папка
                    {
                        cursor = 0;
                        current_fs.Delete();//удаляем
                    }
                    if (current_fs.GetType() == typeof(FileInfo))//если файл
                    {
                        cursor = 0;
                        current_fs.Delete(); //удаляем
                    }
                }
                if (consolekey.Key == ConsoleKey.Enter)//открытие текстового файла
                {
                    if (current_fs.GetType() == typeof(FileInfo)) //если файл
                    {
                        Console.Clear();//очищаем консоль
                        StreamReader sr = new StreamReader(current_fs.FullName);//считываем файл
                        Console.WriteLine(sr.ReadToEnd());//запись на консоль 
                        sr.Close();
                        Console.ReadLine(); //вывод
                    }

                }
                if (consolekey.Key == ConsoleKey.R)//переименовывание файла или папки
                {
                    if (current_fs.GetType() == typeof(FileInfo))//если файл
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Clear();
                        string newname = Console.ReadLine();//вводим новое название
                        string old_n = current_fs.FullName;//полный путь до данного файла
                        string new_n = path + "/" + newname;//текущая положение+файл с новым названием
                        System.IO.File.Move(old_n, new_n);//используем Move, для переименования файла
                    }
                    if (current_fs.GetType() == typeof(DirectoryInfo)) //если папка
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Clear();
                        string newname = Console.ReadLine(); 
                        string old_n = current_fs.FullName;//полный путь до данной папки
                        string new_n = path + "/" + newname;//текущее положение+папка с новым названием
                        System.IO.Directory.Move(old_n, new_n);
                    }
                }
            }
        }

        public void Show()
        {
            Console.BackgroundColor = ConsoleColor.Black;//закрашиваем фон черным цветом
            Console.Clear();//очищаем консоль
            directory = new DirectoryInfo(path); // привязываемся к рабочему каталогу
            FileSystemInfo[] fs = directory.GetFileSystemInfos();//получаем все файлы и директории
            for (int i = 0; i < fs.Length; i++)
            {
                Color(fs[i], i);
                Console.WriteLine(i+1 + ". " + fs[i].Name);//выводим на консоль все файлы и директории
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string path = "/Users/user/Documents/PP2";//каталог, с которым работаем
            FarManager farManager = new FarManager(path); //экземпляр FarManager-a
            farManager.Show();
            farManager.Start();

        }
    }
}

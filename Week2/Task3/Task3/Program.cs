using System;
using System.IO;

namespace Task3
{
    class Program
    {

        public static void PrintSpaces(int level)
        {
            for (int i = 0; i < level; i++)
                Console.Write("     ");
        }

        public static void F(DirectoryInfo dir, int level)
        {
            foreach (FileInfo f in dir.GetFiles()) //getting the list of files
            {
                PrintSpaces(level);
                Console.WriteLine(f.Name);
            }
            foreach (DirectoryInfo d in dir.GetDirectories()) //getting the list ofdirectories 
            {
                PrintSpaces(level);
                Console.WriteLine(d.Name);
                F(d, level + 1);
            }
        }

        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo("/Users/user/Documents/PP2"); // Specifying the directories i want to manipulate.
            F(dir, 0);
        }
    }
}

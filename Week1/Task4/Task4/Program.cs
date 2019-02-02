using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); 
            char[,] a = new char[n, n]; //creating 2d array
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    a[i, j] = char.Parse("*"); //filling with *
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write(a[i, j] + " "); 
                Console.WriteLine();
            }
        }
    }
}

using System;

namespace Task2
{
    class Program
    {
        static void Double(int k) //a method that repeats each element of a given array
        {
            Console.Write(k + " " + k + " ");
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); //conversion to integer
            int[] a = new int[n]; //creating the array
            string[] arr = Console.ReadLine().Split(); //splitting the input string
            foreach (string k in arr) //moving through the array arr
            {
                Double(int.Parse(k)); //method call
            }
            
        }
        
    }
}

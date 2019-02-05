using System;
using System.IO;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt"); //Read a string from the file
            StreamWriter sw = new StreamWriter("output.txt"); //Write the output to the file
            string s = sr.ReadToEnd(); //reads all text from file
            string[] arr = s.Split(); //splitting the string
            int n = arr.Length; 
            int[] a = new int[n]; //creating an array
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = int.Parse(arr[i]); //conversion to integer
                if (isPrime(a[i]) == true)
                    sw.Write(a[i] + " ");
            }
            sw.Close();//Close the StreamReader object 
            Console.Write("operation is completed"); 
        }
        static bool isPrime(int k)
        {
            int p = 0;
            for (int i = 1; i <= k; i++) 
                if (k % i == 0)
                    p++;
            if (p == 2)
                return true;
            return false;
        }
    }
}

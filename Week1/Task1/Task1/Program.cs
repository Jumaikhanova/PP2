using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); //conversion to integer
            int[] a = new int[n]; //creating  the array
            string[] arr = Console.ReadLine().Split(); //splitting the input string
            for (int i = 0; i < a.Length; i++) 
            {
                a[i] = int.Parse(arr[i]); //conversion to integer
                if (isPrime(a[i]) == true) //condition
                    Console.Write(a[i] + " "); //output
            }
        }
        static bool isPrime(int k) //a method that checks the number
        {
            int p = 0; //counter
            for (int i = 1; i <= k; i++) //divisors
                if (k % i == 0)
                    p++;
            if (p == 2)
                return true; //the number is prime
            return false;
        }
    }
}

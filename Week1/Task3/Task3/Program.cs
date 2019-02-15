using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); //conversion to integer
            int[] a = new int[n]; //creating the array
            int[] b = new int[n * 2]; //creating the array
            string[] arr = Console.ReadLine().Split(); //splitting the input string
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = int.Parse(arr[i]); //conversion to integer
                for (int j=i*2; j<=2*i+1; j++) 
                {
                    b[j] = a[i];//assigning elements to a new array
                }
            }
            for (int i = 0; i < b.Length; i++)
            {
                Console.Write(b[i]+ " ");
            }

        }  
    }
}

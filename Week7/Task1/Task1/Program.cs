using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread[] t = new Thread[3];//create an array of 3 threads
            for (int i = 0; i < 3; i++) 
            {
                t[i] = new Thread(OutputName);//create a new thread and assign to it the function OutputName
                t[i].Name = (i+1).ToString();//assigning a name to thread
                t[i].Start();
            }
            Console.ReadKey();
        }
        static void OutputName()
        {
            for (int i = 0; i < 3; i++) 
            {
                Console.WriteLine("Thread_" + Thread.CurrentThread.Name);//output current thread's name
            }
        }
    }
}

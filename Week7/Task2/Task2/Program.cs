using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Task2
{
    class MyThread //creat a new class MyThread
    {
        public MyThread() { }

        public Thread threadField;
        public MyThread(string name)
        {
            threadField = new Thread(Output);//create a new thread and assign to it the function Output
            threadField.Name = name;//assigning a name to the thread

            void Output()
            {
                for (int i = 1; i <= 4; i++)
                {
                    if (i == 4)
                    {
                        Console.WriteLine(Thread.CurrentThread.Name + " выводит " + i);
                        Console.WriteLine(Thread.CurrentThread.Name + " завершился ");
                    }
                    else
                        Console.WriteLine(Thread.CurrentThread.Name + " выводит " + i);

                }
            }
        }
        public void startThread()
        {
            threadField.Start();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyThread t1 = new MyThread("Thread 1");//create an incstance if the class MyThread
            MyThread t2 = new MyThread("Thread 2");
            MyThread t3 = new MyThread("Thread 3");

            t1.startThread();//call the function startThread to start a thread
            t2.startThread();
            t3.startThread();
            Console.ReadKey();

        }
    }
}

using System;

namespace Task2
{
    class Student //creating the class
    {
        public string name;
        public string id;
        public int year_of_study;

        public Student (string name, string id)//creating a constructor with two parameters
        {
            this.name = name; // reference to the instance of the class
            this.id = id;
        }
        public void print() //creating a function
        {
            Console.WriteLine("Name:"+ name); //output
            Console.WriteLine("id:" + id);
        }
        public void Increment() //creating a function
        {
            year_of_study++; //increment the year of study
            Console.WriteLine("Increased year of study:" + year_of_study);//output
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student st1 = new Student("sss", "1234567");//creating the instance of the class Student
            st1.print(); //accessing name and id
            st1.Increment(); //accessing the increased year of study
        }
    }
}

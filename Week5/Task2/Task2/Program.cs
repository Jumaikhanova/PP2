using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;


namespace Task2
{
    public class Mark //create a new class Mark
    {
        public string Name;
        public string ID;
        public string Subject;
        public int Points;
        public string Letter;

        public Mark() { }//empty constructor

        public Mark(string Name, string ID, string Subject, int Points) //constructor with 4 parameters
        {
            this.Name = Name;
            this.ID = ID;
            this.Subject = Subject;
            this.Points = Points;
        }

        public void getLetter() //method to get letter 
        {
            if (Points >= 95) Letter = "A";
            else if (Points >= 90 && Points < 95) Letter = "A-";
            else if (Points >= 85 && Points < 90) Letter = "B+";
            else if (Points >= 80 && Points < 85) Letter = "B";
            else if (Points >= 75 && Points < 80) Letter = "B-";
            else if (Points >= 70 && Points < 75) Letter = "C+";
            else if (Points >= 65 && Points < 70) Letter = "C";
            else if (Points >= 60 && Points < 65) Letter = "C-";
            else if (Points >= 55 && Points < 60) Letter = "D+";
            else if (Points >= 50 && Points < 55) Letter = "D-";
            else if (Points < 50) Letter = "F";
        }

        public override string ToString() //ToString method
        {
            return Name + " (" + ID + "):" + Subject + " - " + Letter;
        }
    }
    class Program
    {
        public static void F1()
        {
            List<Mark> marks = new List<Mark>(); //create a list to collect all of the instaneces
            Mark mark1 = new Mark("Sasha", "18BD000000", "Physics1", 80);
            Mark mark2 = new Mark("Sabina", "18BD111111", "PP1", 91);
            Mark mark3 = new Mark("Sara", "18BD116303", "Calculus2", 95);
            mark1.getLetter();//call the getLetter method 
            mark2.getLetter();
            mark3.getLetter();

            marks.Add(mark1); // adding to the list
            marks.Add(mark2);
            marks.Add(mark3);

            FileStream fs = new FileStream("Mark.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);//provide a stream for a file
            XmlSerializer xs = new XmlSerializer(typeof(List<Mark>));// create an instance of the XmlSerializer class and specify the type of object to serialize
            xs.Serialize(fs, marks);//serializing an instance of the class Mark
            fs.Close();//close the stream

        }

        public static void F2()
        {
            FileStream fs = new FileStream("Mark.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(typeof(List<Mark>));
            List<Mark> marks = xs.Deserialize(fs) as List<Mark>; //deserializing
            Console.WriteLine(marks[0]);
            Console.WriteLine(marks[1]);
            Console.WriteLine(marks[2]);
            fs.Close();

        }
        static void Main(string[] args)
        {
            F1();
            F2();
            Console.ReadKey();
        }
    }
}

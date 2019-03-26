using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Task1
{
    public class ComNum // creating new class ComNum
    {
        public List<ComplexNumber> numbers; //list of complex numbers
        public ComNum() //create a constructor
        {
            numbers = new List<ComplexNumber>();
        }
        
    }
    public class ComplexNumber //creating new class ComplexNumber
    {
        public double a; //real part
        public double b; //imaginary part

        public ComplexNumber() { } //empty constructor
        public ComplexNumber(double a, double b) // create a constructor with 2 parameters
        {
            this.a = a; //reference to the instance of the class
            this.b = b;
        }
        public override string ToString()
        {
            return a + "+" + b + "i"; //returning in the form a + bi
        }
    }
    class Program
    {
        public static void F1()
        {
            ComNum ComplexNumbers = new ComNum(); //creating the instance of the class ComNum
            ComplexNumber number1 = new ComplexNumber(7, 2); //creating the instance of the class ComplexNumber
            ComplexNumber number2 = new ComplexNumber(4, 3);
            ComplexNumbers.numbers.Add(number1); //adding into the list
            ComplexNumbers.numbers.Add(number2);

            FileStream fs = new FileStream("ComNum.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);//provide a stream for a file
            XmlSerializer xs = new XmlSerializer(typeof(ComNum));// create an instance of the XmlSerializer class and specify the type of object to serialize
            xs.Serialize(fs, ComplexNumbers); //serializing an instance of the class ComNum
            fs.Close();// close the stream
        }
        public static void F2()
        {
            FileStream fs = new FileStream("ComNum.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(typeof(ComNum));
            ComNum ComplexNumbers = xs.Deserialize(fs) as ComNum; //deserializing

            Console.WriteLine(ComplexNumbers.numbers[0]);//output on the console
            Console.WriteLine(ComplexNumbers.numbers[1]);
        }
        static void Main(string[] args)
        {
            F1();//calling function to serialize
            F2();//deserialize
            Console.ReadKey();
        }
    }
}

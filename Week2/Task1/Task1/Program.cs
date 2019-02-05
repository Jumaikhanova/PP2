using System;
using System.IO;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt"); //Read a string from the file
            String s = sr.ReadToEnd(); //reads all text from file
            int l = 0;
            int r = s.Length-1;
            while (l < r)
            {
                if (s[l] != s[r]) //comparing two characters
                {
                    Console.WriteLine("NO");
                    sr.Close(); //Closes the StreamReader object 
                                //and releases any system resources associated with the reader.
                    return;
                }
                l++;
                r--;
            }
            Console.WriteLine("YES");
            sr.Close();
        }
    }
}

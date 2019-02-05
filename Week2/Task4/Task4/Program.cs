using System;
using System.IO;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "NewFile.txt"; // Create a file name for the file i want to create.
            string sourcePath = @"/Users/user/Desktop/path";
            string targetPath = @"/Users/user/Desktop/path1";
            string sourceFile = System.IO.Path.Combine(sourcePath, fileName); // Using Combine to add the file name to the path.
            string destFile = System.IO.Path.Combine(targetPath, fileName); 


            System.IO.File.Create(sourceFile).Close(); //By adding Close in the File creation part, the lock is released after the file is created. 
            Console.WriteLine("File is created");


            System.IO.File.Copy(sourceFile, destFile, true); //Copying a file to destination path
            Console.WriteLine("File is copied");

            System.IO.File.Delete(sourceFile); //Deleting a source file
            Console.WriteLine("File is deleted");

        }

    }
}

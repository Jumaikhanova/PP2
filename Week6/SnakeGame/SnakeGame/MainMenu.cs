using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace SnakeGame
{
    public class MainMenu
    {
        public int cursor;
        public string[] options = new string[] { "NEW GAME", "CONTINUE", "EXIT" };
        public MainMenu() { }
        public void Color(int index)
        {
            if (index == cursor)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }
        public void Up()
        {
            cursor--;
            if (cursor < 0)
                cursor = 2;
        }

        public void Down()
        {
            cursor++;
            if (cursor == 3)
                cursor = 0;
        }
        public void Options()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.SetCursorPosition(20, 6);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("S N A K E  G A M E");
            Console.SetCursorPosition(15, 13);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Created by Jumaikhanova Sabina");
            for (int i = 0; i < 3; i++)
            {
                Color(i);
                Console.SetCursorPosition(25 + i, 8 + i);
                Console.WriteLine(options[i]);
            }
        }
        public void Begin()
        {
            ConsoleKeyInfo consoleKey = Console.ReadKey();
            while (true)
            {
                Options();
                consoleKey = Console.ReadKey();
                if (consoleKey.Key == ConsoleKey.UpArrow)
                    Up();
                if (consoleKey.Key == ConsoleKey.DownArrow)
                    Down();
                if (consoleKey.Key == ConsoleKey.Enter)
                {
                    if (cursor == 0)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(21, 6);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("S N A K E  G A M E");
                        Console.SetCursorPosition(20, 9);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Enter your Nickname:");
                        Console.SetCursorPosition(15, 13);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Created by Jumaikhanova Sabina");
                        Console.SetCursorPosition(27, 11);
                        Console.ForegroundColor = ConsoleColor.White;
                        string Nickname = Console.ReadLine();
                        Game game = new Game(Nickname);
                        Console.Clear();
                        game.Start();

                    }
                    if (cursor == 1)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(21, 6);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("S N A K E  G A M E");
                        Console.SetCursorPosition(20, 9);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Enter your Nickname:");
                        Console.SetCursorPosition(15, 13);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Created by Jumaikhanova Sabina");
                        Console.SetCursorPosition(27, 11);
                        Console.ForegroundColor = ConsoleColor.White;
                        string Nickname = Console.ReadLine();
                        string fileName = Nickname + ".xml";
                        if (File.Exists(fileName))
                        {
                            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                            XmlSerializer xs = new XmlSerializer(typeof(List<GameObject>));
                            List<GameObject> g_objects2 = xs.Deserialize(fs) as List<GameObject>;
                            fs.Close();
                            Console.Clear();
                            Game continueGame = new Game(g_objects2, Nickname);
                            continueGame.Start();
                        }
                    }
                    if (cursor == 2)
                        Environment.Exit(0);
                }


            }
        }
    }

}

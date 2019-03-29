using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Threading;

namespace SnakeGame
{
    
    public class Game
    {
        int time = 400;
        public List<GameObject> g_objects;
        public bool isAlive;
        public Snake snake;
        public Food food;
        public Wall wall;
        public string Nickname;
        public Game() { }
        public Game(string Nickname)
        {
            g_objects = new List<GameObject>();
            snake = new Snake(20, 10, 'o', ConsoleColor.Green);
            food = new Food(0, 0, '*', ConsoleColor.Yellow);
            wall = new Wall('X', ConsoleColor.White);
            wall.LoadLevel();
            while (food.IsCollisionWithObject(snake) || food.IsCollisionWithObject(wall))
                food.Generate();
            g_objects.Add(snake);
            g_objects.Add(food);
            g_objects.Add(wall);
            this.Nickname = Nickname;
            isAlive = true;

        }
        public Game(List<GameObject> g_objects, string Nickname)
        {
            this.g_objects = g_objects;
            this.snake = (Snake)g_objects[0];
            this.food = (Food)g_objects[1];
            this.wall = (Wall)g_objects[2];
            this.Nickname = Nickname;
            isAlive = true;

        }
        public void Start()
        {
            DrawGameView();
            DrawScore();
            DrawLevel();
            snake.Draw();
            food.Draw();
            wall.Draw();
            Thread thread = new Thread(MoveSnake);
            thread.Start();
            while (isAlive)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (snake.SnakeMovement(keyInfo))
                    snake.ChangeDirection(keyInfo);
                
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    thread.Abort();
                    string fileName = Nickname + ".xml";
                    if (File.Exists(fileName))
                        File.Delete(fileName);
                    FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    XmlSerializer xs = new XmlSerializer(typeof(List<GameObject>));
                    xs.Serialize(fs, g_objects);
                    fs.Close();
                    MainMenu mainMenu = new MainMenu();
                    mainMenu.Options();
                    mainMenu.Begin();
                }
               
            }
            
            
        }
        public void MoveSnake()
        {
            while (isAlive)
            {
                snake.Move();
       
                if (snake.IsCollisionWithObject(food))
                {
                    snake.body.Add(new Point(1, 22));
                    DrawScore();
                    
                    if (snake.body.Count < 9 && snake.body.Count % 4 == 0)
                    {
                        time = time - 70;
                        wall.Clear();
                        wall.NextLevel();
                        wall.Draw();
                        DrawLevel();
                        snake.InitialPosition();
                        while (food.IsCollisionWithObject(snake) || food.IsCollisionWithObject(wall))
                            food.Generate();
                        food.Draw();


                    }
                    else
                    {
                        while (food.IsCollisionWithObject(snake) || food.IsCollisionWithObject(wall))
                            food.Generate();
                        food.Draw();
                    }

                }
                if (snake.IsCollisionWithSnake(snake))
                    isAlive = false;
                if (snake.IsCollisionWithObject(wall))
                    isAlive = false;
               
                if (isAlive == false)
                {
                    if (File.Exists(Nickname + ".xml"))
                        File.Delete(Nickname + ".xml");
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(23, 10);
                    Console.WriteLine("GAME OVER");
                    Console.SetCursorPosition(22, 12);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("YOUR SCORE:" + ((snake.body.Count * 10) - 10));
                    Console.ReadKey();
                    break;

                }
                snake.Clear();
                snake.Draw();
                Thread.Sleep(time);
            }
        }
       
        public void DrawGameView()
        {
            Console.SetCursorPosition(7, 16);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("SNAKE GAME >> Author >> Jumaikhanova Sabina");
            Console.SetCursorPosition(2, 22);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("YOUR SCORE:");
            Console.SetCursorPosition(44, 22);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("YOUR LEVEL:");
        }
        public void DrawScore()
        {
            Console.SetCursorPosition(13, 22);
            Console.ForegroundColor = ConsoleColor.Red;
            if (snake.body.Count == 1)
                Console.WriteLine("0");
            else Console.WriteLine(snake.body.Count * 10 - 10);
        }
        public void DrawLevel()
        {
            Console.SetCursorPosition(55, 22);
            Console.ForegroundColor = ConsoleColor.Red;
            if (wall.gameLevel == Wall.GameLevel.FIRST)
                Console.WriteLine("1");
            else if (wall.gameLevel == Wall.GameLevel.SECOND)
                Console.WriteLine("2");
            else if (wall.gameLevel == Wall.GameLevel.THIRD)
                Console.WriteLine("3");
        }
        
    }
}

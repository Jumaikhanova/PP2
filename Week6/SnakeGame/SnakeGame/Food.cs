using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Food:GameObject
    {
        public Food(int x, int y, char sign, ConsoleColor color) : base(x, y, sign, color)
        {

        }
        public Food() { }
        public void Generate()
        {
            Random random = new Random();
            int x = random.Next(3, 52);
            int y = random.Next(3, 13);
            body[0].x = x;
            body[0].y = y;
        }
        public void Draw()
        {
            Console.ForegroundColor = color;
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(sign);
            }
        }
    }
}

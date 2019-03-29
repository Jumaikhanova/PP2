using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SnakeGame
{
    public class Snake:GameObject
    {
        public Snake(int x, int y, char sign, ConsoleColor color):base(x, y, sign, color)
        {
        }
        enum Direction
        {
            NONE,
            RIGHT,
            LEFT,
            UP,
            DOWN
        }
        public Snake() { }
        Direction direction = Direction.NONE;
        public bool SnakeMovement(ConsoleKeyInfo keyInfo)
        {
            if (keyInfo.Key == ConsoleKey.UpArrow && direction == Direction.DOWN)
                return false;
            if (keyInfo.Key == ConsoleKey.DownArrow && direction == Direction.UP)
                return false;
            if (keyInfo.Key == ConsoleKey.RightArrow && direction == Direction.LEFT)
                return false;
            if (keyInfo.Key == ConsoleKey.LeftArrow && direction == Direction.RIGHT)
                return false;
            return true;
        }

        public void Clear()
        {
            for(int i = 0; i < body.Count; i++)
            {
                Console.SetCursorPosition(body[i].x, body[i].y);
                Console.Write(' ');
            }
        }

        public void Move()
        {
            if (direction == Direction.NONE)
                return;
            Clear();
            for (int i = body.Count - 1; i > 0; i--)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }
           
            if (direction == Direction.DOWN)
                body[0].y++;
            if (direction == Direction.UP)
                body[0].y--;
            if (direction == Direction.LEFT)
                body[0].x--;
            if (direction == Direction.RIGHT)
                body[0].x++;

        }
        public void ChangeDirection(ConsoleKeyInfo keyInfo)
        {
            if (keyInfo.Key == ConsoleKey.UpArrow)
                direction = Direction.UP;
            if (keyInfo.Key == ConsoleKey.DownArrow)
                direction = Direction.DOWN;
            if (keyInfo.Key == ConsoleKey.LeftArrow)
                direction = Direction.LEFT;
            if (keyInfo.Key == ConsoleKey.RightArrow)
                direction = Direction.RIGHT;
        }
       
       
        public void InitialPosition()
        {
            for (int i=0; i<body.Count(); i++)
            {
                direction = Direction.RIGHT;
                body[i].x = body.Count - i + 1;
                body[i].y = 2;
            }
        }
        public void Draw()
        {

            Console.ForegroundColor = color;
            for (int i = 0; i < body.Count; i++)
            {
                Console.SetCursorPosition(body[i].x, body[i].y);
                Console.Write(sign);
            }
        }

    }
}

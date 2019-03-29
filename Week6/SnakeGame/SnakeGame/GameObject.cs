﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SnakeGame
{
    [XmlInclude(typeof(Snake))]
    [XmlInclude(typeof(Food))]
    [XmlInclude(typeof(Wall))]
    public class GameObject
    {
        public List<Point> body;
        public char sign;
        public ConsoleColor color;
        public GameObject() { }
        public GameObject(int x, int y, char sign, ConsoleColor color)
        {
            body = new List<Point>
            {
                new Point(x,y)
            };
            this.sign = sign;
            this.color = color;
        }
        
        public bool IsCollisionWithObject(GameObject obj)
        {
            
            foreach (Point p in obj.body)
            {
                if (body[0].x == p.x && body[0].y == p.y)
                    return true;
            }
            return false;
        }
        public bool IsCollisionWithSnake(GameObject obj)
        {
            for (int i = 1; i < body.Count; i++)
            {
                if (body[0].x == body[i].x && body[0].y == body[i].y)
                    return true;
            }
            return false;

        }
        public void Clear()
        {
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(' ');
                
            }
        }
    }
}

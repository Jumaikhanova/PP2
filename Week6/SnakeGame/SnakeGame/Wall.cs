﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SnakeGame
{
    public class Wall : GameObject
    {
        public Wall() { }
        public Wall(char sign, ConsoleColor color) : base(0, 0, sign, color)
        {
            body = new List<Point>();
        }
        public enum GameLevel
        {
            FIRST,
            SECOND,
            THIRD
        }

        public GameLevel gameLevel = GameLevel.FIRST;
        
        public void LoadLevel()
        {
            body = new List<Point>();
            string fileName = "level1.txt";
            if (gameLevel == GameLevel.SECOND)
                fileName = "level2.txt";
            if (gameLevel == GameLevel.THIRD)
                fileName = "level3.txt";

            StreamReader sr = new StreamReader(fileName);
            string[] rows = sr.ReadToEnd().Split('\n');
            for (int i = 0; i < rows.Length; i++)
                for (int j = 0; j < rows[i].Length; j++)
                    if (rows[i][j] == 'X')
                        body.Add(new Point(j, i));
        }

        public void NextLevel()
        {
            if (gameLevel == GameLevel.FIRST)
                gameLevel = GameLevel.SECOND;
            else if (gameLevel == GameLevel.SECOND)
                gameLevel = GameLevel.THIRD;
            LoadLevel();
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

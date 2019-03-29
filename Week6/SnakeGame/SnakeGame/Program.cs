using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(56, 25);
            Console.SetBufferSize(56, 25);
            Console.CursorVisible = false;
            MainMenu mainMenu = new MainMenu();
            mainMenu.Options();
            mainMenu.Begin();
        }
    }
}

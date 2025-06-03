using System;
using System.Diagnostics.CodeAnalysis;
using System.Security;
using System.Threading;

class Program
{
    static void Main()
    {
        int x;
        int y;

        while (true)
        {
            if(Console.KeyAvailable)
            {
                key = Console.Ready(true).Key;
            }

            switch (key)
            {
                case ConsoleKey.UpArrow: y--; break;
                case ConsoleKey.DownArrow: y++; break;
                case ConsoleKey.LeftArrow: x--; break;
                case ConsoleKey.RightArrow: x++; break;
            }
            
            Console.Clear();
            Console.SetCursorPosition(x, y);
            Console.Write("O"); // cabeça da cobra la ele 
            Thread.Sleep(200); //velocidade de movimento 200ms
        }
    }
}

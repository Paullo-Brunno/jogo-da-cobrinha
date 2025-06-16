using System;
using System.Diagnostics.CodeAnalysis;
using System.Security;
using System.Threading;


class Point
{
    public int X;
    public int Y;

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
}
class Program
{
    static void Main()
    {
        //corpo da cobrinha 
        List<Point> snake = new List<Point>
        {
            new Point(10, 10), //cabeça da cobrinha
            new Point(9, 10), // corpo da cobrinha
            new Point(8, 10)
        };
        //direçao da cobrinha direita e esquerda
        int dx = 1;
        int dy = 0;

        Random random = new Random();   //adiciona comida e score 
        Point food = new Point(random.Next( 0 , Console.WindowWidth), random.Next( 1 , Console.WindowHeight));
        int score = 0;

        while (true)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                //movimentaçao da cobrinha
                switch (key)
                {
                    case ConsoleKey.W:
                        dx = 0; dy = -1;
                        break;
                    case ConsoleKey.S:
                        dx = 0; dy = 1;
                        break;
                    case ConsoleKey.A:
                        dx = -1; dy = 0;
                        break;
                    case ConsoleKey.D:
                        dx = 1; dy = 0;
                        break;
                }
            }
            //remove o ultimo corpo da cobrinha e adiciona um novo na frente 
            Point head = snake[0];
            Point newHead = new Point(head.X + dx, head.Y + dy);

            if (newHead.X == food.X && newHead.Y == food.Y)
            {
                snake.Insert(0, newHead); // aumenta a cobrinha ao comer a comida
                score++;

                food = new Point(random.Next(0, Console.WindowWidth), random.Next(1, Console.WindowHeight)); //gera nova comida 
            }
            else
            {
                snake.Insert(0, newHead);  //move a cobrinha
                snake.RemoveAt(snake.Count - 1);
            
            }
            Console.Clear();

            Console.SetCursorPosition(0, 0);
            Console.Write($"Score: {score}");
            
            // desenha a cobrinha 
            foreach (Point part in snake)
            {
                if (part.X >= 0 && part.X < Console.WindowWidth &&
                    part.Y >= 0 && part.Y < Console.WindowHeight)
                {
                    Console.SetCursorPosition(part.X, part.Y);
                    Console.Write("O"); //cabeça da cobrinha la ele
                }

                Console.SetCursorPosition(food.X, food.Y);
                Console.Write("@");  //simbolo da comida

            }

            Thread.Sleep(200); // velocidade de movimento 
        }
    }
}


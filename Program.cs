using System;
using System.Diagnostics.CodeAnalysis;
using System.Security;
using System.Threading;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Rodando...");
            Thread.Sleep(100); //pausa o game por 100ms
        }
    }
}


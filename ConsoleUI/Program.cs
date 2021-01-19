using FactoryMethod;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Select();
        }

        private static void Select()
        {
            while (true)
            {
                Console.WriteLine("Select From Below");
                Console.WriteLine("[1][Factory Method] Create Random Weapons");
                Console.Write("Selection: ");
                ConsoleKeyInfo selection = Console.ReadKey();

                switch (selection.Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        _ = new FactoryMethodConsoleUI();
                        break;

                    default:
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
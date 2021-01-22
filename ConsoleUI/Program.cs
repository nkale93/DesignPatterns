using System;

namespace ConsoleUI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            while (true)
            {
                Select();
            }
        }

        private static void Select()
        {
            bool selected = false;

            Console.WriteLine("[*][Select From Below]______ ____________________");
            Console.WriteLine("[1][Factory Method]_________ Craft Random Weapons");
            Console.WriteLine("[2][Abstract Factory Method] Arena_______________");

            ConsoleKeyInfo selection;
            do
            {
                Console.Write("Selection: ");
                selection = Console.ReadKey(false);

                if (selection.Key != ConsoleKey.Enter)
                {
                    Console.WriteLine();
                }

                switch (selection.Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        _ = new FactoryMethodConsoleUI();
                        selected = true;
                        break;

                    case ConsoleKey.D2:
                        Console.Clear();
                        _ = new AbstractMethodConsoleUI();
                        selected = true;
                        break;
                }
            } while (!selected);
        }
    }
}
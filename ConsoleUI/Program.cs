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
                        FactoryMethod();
                        selected = true;
                        break;

                    case ConsoleKey.D2:
                        Console.Clear();
                        AbstractFactoryMethod();
                        selected = true;
                        break;
                }
            } while (!selected);
        }

        private static void AbstractFactoryMethod()
        {
            AbstractMethodConsoleUI abstractMethodConsoleUI = new AbstractMethodConsoleUI();
            abstractMethodConsoleUI.CreateCharacter();
            abstractMethodConsoleUI.SimulateBattle();
        }

        private static void FactoryMethod()
        {
            FactoryMethodConsoleUI factoryMethodConsoleUI = new FactoryMethodConsoleUI();
            factoryMethodConsoleUI.FactoryMethod();
        }
    }
}
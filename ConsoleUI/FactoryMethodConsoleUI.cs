using FactoryMethod;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    internal class FactoryMethodConsoleUI
    {
        public FactoryMethodConsoleUI()
        {
            FactoryMethod();
        }

        private void FactoryMethod()
        {
            FactoryManager factoryManager = new FactoryManager();
            List<IEquipment> equipments = new List<IEquipment>();
            float money = 0;
            bool create = true;

            while (create)
            {
                Console.WriteLine("[1] Create Weapon\n" +
                                  "[2] Create Armour\n" +
                                  "[3] Show Bag\n" +
                                  "[4] Show Money\n" +
                                  "[5] Sell All\n\n" +
                                  "[0] Main Menu [9] Exit\n");
                Console.Write("Selection: ");
                ConsoleKeyInfo selection = Console.ReadKey();

                switch (selection.Key)
                {
                    case ConsoleKey.D1:
                        GetEquipment(equipments, factoryManager);
                        break;

                    case ConsoleKey.D2:
                        GetArmour(equipments, factoryManager);
                        break;

                    case ConsoleKey.D3:
                        ShowBag(equipments);
                        break;

                    case ConsoleKey.D4:
                        ShowMoney(money);
                        break;

                    case ConsoleKey.D5:
                        SellAll(equipments, ref money);
                        break;

                    case ConsoleKey.D9:
                        ExitConsoleApp();
                        break;

                    case ConsoleKey.D0:
                        Console.Clear();
                        equipments = null;
                        create = false;
                        break;

                    default:
                        Console.Clear();
                        break;
                }
            }

            Console.Clear();
        }

        private void GetEquipment(List<IEquipment> equipments, FactoryManager factoryManager)
        {
            Console.Clear();

            IEquipment weapon = factoryManager.GetEquipment(EquipmentType.Weapon);

            Console.WriteLine($"{weapon.GetInfo()}\n\n");

            equipments.Add(weapon);
        }

        private void GetArmour(List<IEquipment> equipments, FactoryManager factoryManager)
        {
            Console.Clear();

            IEquipment armour = factoryManager.GetEquipment(EquipmentType.Armour);

            Console.WriteLine($"{armour.GetInfo()}\n\n");

            equipments.Add(armour);
        }

        private void ShowBag(List<IEquipment> equipments)
        {
            Console.Clear();

            if (equipments.Count == 0)
            {
                Console.WriteLine("Bag is empty\n\n");
                return;
            }

            foreach (var item in equipments)
            {
                Console.WriteLine($"{item.GetInfo()}\n\n");
            }
        }

        private static void ShowMoney(float money)
        {
            Console.Clear();
            Console.WriteLine($"Total money: { money }$\n\n");
        }

        private void SellAll(List<IEquipment> equipments, ref float money)
        {
            Console.Clear();

            if (equipments.Count == 0)
            {
                Console.WriteLine("Bag is empty\n\n");
                return;
            }

            foreach (var item in equipments)
            {
                money += item.GetValue();
            }

            money = MathF.Round(money, 2);

            equipments.Clear();

            Console.WriteLine($"Sold amount: { money }$\n\n");
        }

        private void ExitConsoleApp()
        {
            Environment.Exit(0);
        }
    }
}
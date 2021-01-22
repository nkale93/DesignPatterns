using AbstractFactoryMethod;
using FactoryMethod;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleUI
{
    public class AbstractMethodConsoleUI
    {
        private const string format = "{0,50} {1,0} {2,-50}";

        private int userHealthPoint = 100;
        private string userName;
        private IEquipment userEquipment;

        private int enemyHealyPoint;
        private string enemyName;
        private IEquipment enemyEquipment;

        public AbstractMethodConsoleUI()
        {
            CreateCharacter();
            SimulateBattle();
        }

        private void CreateCharacter()
        {
            ConsoleKey response;
            int rolls = 3;

            do
            {
                Console.Write("Please Enter Your Name: ");
                userName = Console.ReadLine();

                do
                {
                    Console.Write($"Do you want to change this name? [{ userName }] [y/n] ");
                    response = Console.ReadKey(false).Key;
                    if (response != ConsoleKey.Enter)
                        Console.WriteLine("\n");
                } while (response != ConsoleKey.Y && response != ConsoleKey.N);

                if (response != ConsoleKey.N)
                {
                    Console.Clear();
                }
            } while (response != ConsoleKey.N);

            Console.Clear();
            FactoryMethodManager manager = new FactoryMethodManager();
            this.userEquipment = manager.GetEquipment(EquipmentType.Weapon);
            Console.WriteLine(userEquipment.GetInfo());
            do
            {
                do
                {
                    Console.Write($"Do you want to re-roll this item? [remaining rolls:{ rolls }] [y/n] ");
                    response = Console.ReadKey(false).Key;
                    if (response != ConsoleKey.Enter)
                        Console.WriteLine("\n");
                } while (response != ConsoleKey.Y && response != ConsoleKey.N);

                if (rolls != 0 && response != ConsoleKey.N)
                {
                    Console.Clear();
                    this.userEquipment = manager.GetEquipment(EquipmentType.Weapon);
                    Console.WriteLine(userEquipment.GetInfo());
                }

                rolls--;
            } while (rolls != 0 && response != ConsoleKey.N);

            Console.Clear();
            do
            {
                Console.Write($"Name: {userName}\n\n{userEquipment.GetInfo()}\n\nDo you want to create again? [y/n] ");
                response = Console.ReadKey(false).Key;
                if (response != ConsoleKey.Enter)
                    Console.WriteLine("\n");
            } while (response != ConsoleKey.Y && response != ConsoleKey.N);

            if (response == ConsoleKey.Y)
            {
                Console.Clear();
                CreateCharacter();
            }

            Console.Clear();
        }

        private void SimulateBattle()
        {
            CreateEnemy();
            AttackMode attackMode = new AttackMode();
            DefenseMode defenseMode = new DefenseMode();
            Random random = new Random();
            bool alive = true;
            bool enemyAttacking = false;
            bool wrongButton = false;
            bool triedDef = false;
            int userDamage = 0;
            bool userDefended = false;
            bool enemyDefended = false;

            while (alive)
            {
                if (enemyAttacking)
                {
                    Console.WriteLine("Apparently the enemy will attack... Try to defense it\n");
                }

                ShowInfo(userName, userHealthPoint, userEquipment, enemyName, enemyHealyPoint, enemyEquipment);
                Console.WriteLine("[1] Front Attack\n" +
                                  "[2] Vertical Attack\n" +
                                  "[3] Horizontal Attack\n" +
                                  "[4] Defense Front\n" +
                                  "[5] Defense Vertically\n" +
                                  "[6] Defense Horizontally\n");

                ConsoleKeyInfo selection = Console.ReadKey();
                Console.Clear();
                switch (selection.Key)
                {
                    case ConsoleKey.D1:
                        userDamage = (attackMode.GetData(AttackType.NormalAttack).DataItem as IAttack).Damage((int)userEquipment.GetRating());
                        break;

                    case ConsoleKey.D2:
                        userDamage = (attackMode.GetData(AttackType.VerticalSlashAttack).DataItem as IAttack).Damage((int)userEquipment.GetRating());
                        break;

                    case ConsoleKey.D3:
                        userDamage = (attackMode.GetData(AttackType.HorizontalSlashAttack).DataItem as IAttack).Damage((int)userEquipment.GetRating());
                        break;

                    case ConsoleKey.D4:
                        userDefended = (defenseMode.GetData(DefenseType.NormalDefense).DataItem as IDefense).
                            GetDefense((DefenseType)random.Next((int)Enum.GetValues(typeof(DefenseType)).Cast<DefenseType>().Max()) + 1);
                        triedDef = true;
                        break;

                    case ConsoleKey.D5:
                        userDefended = (defenseMode.GetData(DefenseType.VerticalDefense).DataItem as IDefense).
                            GetDefense((DefenseType)random.Next((int)Enum.GetValues(typeof(DefenseType)).Cast<DefenseType>().Max()) + 1);
                        triedDef = true;
                        break;

                    case ConsoleKey.D6:
                        userDefended = (defenseMode.GetData(DefenseType.HorizontalDefense).DataItem as IDefense).
                            GetDefense((DefenseType)random.Next((int)Enum.GetValues(typeof(DefenseType)).Cast<DefenseType>().Max()) + 1);
                        triedDef = true;
                        break;

                    default:
                        Console.WriteLine("You did nothing...");
                        wrongButton = true;
                        break;
                }

                if (enemyAttacking)
                {
                    if (!userDefended)
                    {
                        int enemyDamage = (attackMode.GetData((AttackType)random.
                            Next((int)Enum.GetValues(typeof(AttackType)).
                            Cast<AttackType>().Max()) + 1).DataItem as IAttack).
                            Damage((int)enemyEquipment.GetRating());
                        userHealthPoint -= enemyDamage;

                        if (triedDef)
                        {
                            Console.WriteLine($"You failed to block { enemyName }'s attack");
                        }
                        Console.WriteLine($"{ enemyName } landed { enemyDamage } damage to you.");
                    }
                    else
                    {
                        Console.WriteLine($"You successfully defended { enemyName }'s attack");
                    }

                    if (userDamage > 0)
                    {
                        enemyHealyPoint -= userDamage;
                        Console.WriteLine($"You landed { enemyName } to { userDamage } damage");
                    }
                }
                else
                {
                    if (userDamage > 0)
                    {
                        // enemy tries to defense
                        if (random.Next(100) < 25)
                        {
                            enemyDefended = (defenseMode.GetData((DefenseType)random.
                                Next((int)Enum.GetValues(typeof(DefenseType)).Cast<DefenseType>().Max()) + 1).
                                DataItem as IDefense).
                                GetDefense((DefenseType)random.
                                Next((int)Enum.GetValues(typeof(DefenseType)).Cast<DefenseType>().Max()) + 1);
                        }

                        if (!enemyDefended)
                        {
                            enemyHealyPoint -= userDamage;
                            Console.WriteLine($"You landed { enemyName } to { userDamage } damage");
                        }
                        else
                        {
                            Console.WriteLine($"{ enemyName } managed to block your attack");
                        }
                    }
                    else
                    {
                        if (!wrongButton)
                        {
                            Console.WriteLine("You made an defense move but it was meaningless...");
                        }
                    }
                }

                Console.WriteLine();

                if (userHealthPoint <= 0)
                {
                    Console.Clear();
                    Console.WriteLine($"{ userName } Died");
                    Console.WriteLine("...GAME OVER...");
                    alive = false;
                    Console.ReadLine();
                    Console.Clear();
                }
                if (enemyHealyPoint <= 0)
                {
                    Console.Clear();
                    Console.WriteLine($"{ userName } killed { enemyName }");
                    Console.WriteLine($"...CONGRUCULATIONS...");
                    alive = false;
                    Console.ReadLine();
                    Console.Clear();
                }

                userDamage = 0;
                userDefended = false;
                triedDef = false;
                wrongButton = false;
                enemyAttacking = !enemyAttacking;
            }
        }

        private void CreateEnemy()
        {
            Random random = new Random();

            enemyHealyPoint = random.Next(50, 300);

            string[] enemyNames = { "Goblin", "Dragon", "Slime", "Demon", "Beggar" };

            enemyName = enemyNames[random.Next(enemyNames.Length)];

            FactoryMethodManager factoryMethodManager = new FactoryMethodManager();
            enemyEquipment = factoryMethodManager.GetEquipment(EquipmentType.Weapon);
        }

        private void ShowInfo(string userName, int userHp, IEquipment userEquipment, string enemyName, int enemyHp, IEquipment enemyEquipment)
        {
            Console.WriteLine(string.Format(format, userName, "||||||Name||||||", enemyName));
            Console.WriteLine(string.Format(format, userHp, "||Health Point||", enemyHp));
            Console.WriteLine(string.Format(format, userEquipment.GetName(), "|||||Weapon|||||", enemyEquipment.GetName()));
            Console.WriteLine(string.Format(format, userEquipment.GetRating(), "||Attack Rating|", enemyEquipment.GetRating()));
        }
    }
}
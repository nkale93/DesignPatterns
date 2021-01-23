using AbstractFactoryMethod;
using ConsoleUILibrary;
using FactoryMethod;
using System;
using System.Linq;

namespace ConsoleUI
{
    public class AbstractMethodConsoleUI
    {
        private readonly EasyCW cw = new EasyCW();
        private readonly FactoryMethodManager manager = new FactoryMethodManager();
        private Player player;
        private Enemy enemy;

        private const string format = "{0,50} {1,0} {2,-50}";

        public void CreateCharacter()
        {
            IEquipment userEquipment;
            ConsoleKey response;
            int rolls = 3;

            string userName = cw.GetUserName();

            userEquipment = manager.GetEquipment(EquipmentType.Weapon);
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
                    userEquipment = manager.GetEquipment(EquipmentType.Weapon);
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
                return;
            }

            Weapon weapon = new Weapon(userEquipment.GetName(), userEquipment.GetRating(), userEquipment.GetWeight(), userEquipment.GetValue());
            player = new Player(userName, 100, weapon);

            Console.Clear();
        }

        public void SimulateBattle()
        {
            CreateEnemy();
            AttackMode attackMode = new AttackMode();
            DefenseMode defenseMode = new DefenseMode();
            Random random = new Random();
            bool enemyAttacking = false;
            bool wrongButton = false;
            bool triedDef = false;
            int userDamage = 0;
            bool userDefended = false;
            bool enemyDefended = false;

            while (player.IsAlive && enemy.IsAlive)
            {
                if (enemyAttacking)
                {
                    Console.WriteLine("Apparently the enemy will attack... Try to defense it\n");
                }

                ShowInfo(player.Name, player.CurrentHealth, player.Weapon, enemy.Name, enemy.CurrentHealth, enemy.Weapon);
                string[] menu =
                {
                    "[1] Front Attack",
                    "[2] Vertical Attack",
                    "[3] Horizontal Attack",
                    "[4] Defense Front",
                    "[5] Defense Vertically",
                    "[6] Defense Horizontally"
                };
                cw.CWStringArray(menu);

                ConsoleKeyInfo selection = Console.ReadKey();
                Console.Clear();
                switch (selection.Key)
                {
                    case ConsoleKey.D1:
                        userDamage = (attackMode.GetData(AttackType.NormalAttack).DataItem as IAttack).Damage((int)player.Weapon.AttackRating);
                        break;

                    case ConsoleKey.D2:
                        userDamage = (attackMode.GetData(AttackType.VerticalSlashAttack).DataItem as IAttack).Damage((int)player.Weapon.AttackRating);
                        break;

                    case ConsoleKey.D3:
                        userDamage = (attackMode.GetData(AttackType.HorizontalSlashAttack).DataItem as IAttack).Damage((int)player.Weapon.AttackRating);
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
                            Damage((int)enemy.Weapon.AttackRating);
                        player.DamagePlayer(enemyDamage);

                        if (triedDef)
                        {
                            Console.WriteLine($"You failed to block { enemy.Name }'s attack");
                        }
                        Console.WriteLine($"{ enemy.Name } landed { enemyDamage } damage to you.");
                    }
                    else
                    {
                        Console.WriteLine($"You successfully defended { enemy.Name }'s attack");
                    }

                    if (userDamage > 0)
                    {
                        enemy.DamageEnemy(userDamage);
                        Console.WriteLine($"You landed { enemy.Name } to { userDamage } damage");
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
                            enemy.DamageEnemy(userDamage);
                            Console.WriteLine($"You landed { enemy.Name } to { userDamage } damage");
                        }
                        else
                        {
                            Console.WriteLine($"{ enemy.Name } managed to block your attack");
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

                if (!player.IsAlive)
                {
                    Console.Clear();
                    Console.WriteLine($"{ player.Name } Died");
                    Console.WriteLine("...GAME OVER...");
                    Console.ReadLine();
                    Console.Clear();
                }
                if (!enemy.IsAlive)
                {
                    Console.Clear();
                    Console.WriteLine($"{ player.Name } killed { enemy.Name }");
                    Console.WriteLine($"...CONGRUCULATIONS...");
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

            int enemyHealyPoint;
            string enemyName;
            IEquipment enemyEquipment;

            enemyHealyPoint = random.Next(50, 300);

            string[] enemyNames = { "Goblin", "Dragon", "Slime", "Demon", "Beggar" };

            enemyName = enemyNames[random.Next(enemyNames.Length)];

            enemyEquipment = manager.GetEquipment(EquipmentType.Weapon);

            Weapon weapon = new Weapon(enemyEquipment.GetName(), enemyEquipment.GetRating(), enemyEquipment.GetWeight(), enemyEquipment.GetValue());
            enemy = new Enemy(enemyName, enemyHealyPoint, weapon);
        }

        private void ShowInfo(string userName, float userHp, Weapon userEquipment, string enemyName, float enemyHp, Weapon enemyEquipment)
        {
            Console.WriteLine(string.Format(format, userName, "||||||Name||||||", enemyName));
            Console.WriteLine(string.Format(format, userHp, "||Health Point||", enemyHp));
            Console.WriteLine(string.Format(format, userEquipment.Name, "|||||Weapon|||||", enemyEquipment.Name));
            Console.WriteLine(string.Format(format, userEquipment.AttackRating, "||Attack Rating|", enemyEquipment.AttackRating));
        }
    }
}
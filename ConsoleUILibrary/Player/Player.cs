using System;

namespace ConsoleUILibrary
{
    public class Player
    {
        public string Name { get; private set; }
        public float MaxHealth { get; private set; }
        public float CurrentHealth { get; private set; }
        public bool IsAlive { get; private set; }
        public Weapon Weapon { get; private set; }

        public Player(string name = "nameless", float maxHP = 100, Weapon weapon = null)
        {
            Name = name;
            MaxHealth = maxHP;
            CurrentHealth = MaxHealth;
            IsAlive = true;
            Weapon = weapon ?? new Weapon() ?? throw new Exception();
        }

        public void DamagePlayer(float damage)
        {
            CurrentHealth -= damage;

            if (CurrentHealth <= 0)
            {
                IsAlive = false;
            }
        }
    }
}
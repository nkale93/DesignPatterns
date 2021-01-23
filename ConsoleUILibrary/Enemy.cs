using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUILibrary
{
    public class Enemy
    {
        public string Name { get; private set; }
        public float MaxHealth { get; private set; }
        public float CurrentHealth { get; private set; }
        public bool IsAlive { get; private set; }
        public Weapon Weapon { get; private set; }

        public Enemy(string name = "nameless", float maxHP = 100, Weapon weapon = null)
        {
            Name = name;
            MaxHealth = maxHP;
            CurrentHealth = MaxHealth;
            IsAlive = true;
            Weapon = weapon ?? new Weapon() ?? throw new Exception();
        }

        public void DamageEnemy(float damage)
        {
            CurrentHealth -= damage;

            if (CurrentHealth <= 0)
            {
                IsAlive = false;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUILibrary
{
    public class Weapon
    {
        public string Name { get; private set; }
        public float AttackRating { get; private set; }
        public float Weight { get; private set; }
        public float Value { get; private set; }

        public Weapon(string name = "nameless", float attackRating = 1, float weight = 5, float value = 1)
        {
            Name = name;
            AttackRating = attackRating;
            Weight = weight;
            Value = value;
        }
    }
}
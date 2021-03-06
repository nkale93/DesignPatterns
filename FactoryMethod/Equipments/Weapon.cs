﻿namespace FactoryMethod
{
    internal class Weapon : IEquipment
    {
        private readonly EquipmentType equipmentType;
        private readonly int id;
        private readonly string itemName;
        private readonly float attackRating;
        private readonly float weight;
        private readonly float value;

        public Weapon(ICraftedEquipment equipment)
        {
            this.equipmentType = equipment.EquipmentType;
            this.id = equipment.Id;
            this.itemName = equipment.ItemName;
            this.attackRating = equipment.Rating;
            this.weight = equipment.Weight;
            this.value = equipment.Value;
        }

        public string GetInfo()
        {
            return $"{ itemName } \nAttack rating: { attackRating }\nWeight: { weight } kg\nValue: { value }$";
        }

        public string GetName()
        {
            return itemName;
        }

        public float GetRating()
        {
            return attackRating;
        }

        public float GetValue()
        {
            return value;
        }

        public float GetWeight()
        {
            return weight;
        }
    }
}
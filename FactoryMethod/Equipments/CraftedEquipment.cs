using System;

namespace FactoryMethod
{
    public class CraftedEquipment : ICraftedEquipment
    {
        public EquipmentType EquipmentType { get; private set; }
        public int Id { get; private set; }
        public string ItemName { get; private set; }
        public float Rating { get; private set; }
        public float Weight { get; private set; }
        public float Value { get; private set; }

        public CraftedEquipment(EquipmentType equipmentType)
        {
            EquipmentType = equipmentType;
            Id = GetId();
            ItemName = RandomEquipmentName();
            Rating = RandomRatingValue();
            Weight = RandomEquipmentWeight();
            Value = CalculateValue();
        }

        private int GetId()
        {
            return 0;
        }

        private string RandomEquipmentName()
        {
            string[] names = null;

            if (EquipmentType == EquipmentType.Weapon)
            {
                names = new string[] {
                    "Echo",
                    "End Bringer",
                    "Storm Breaker",
                    "Fire Soul Spell Blade",
                    "Forsaken Mage Blade",
                    "Remorseful Mithril Doom Blade",
                    "Fierce Glass Katana",
                    "Skull Crusher, Quick Blade of Suffering",
                    "Justifier, Claymore of the Lion",
                    "Purifier, Quick Blade of the Gladiator"
                };
            }
            else if (EquipmentType == EquipmentType.Armour)
            {
                names = new string[]
                {
                    "Tunic of Haunted Voices",
                    "Armor of Eternal Fires",
                    "Silver Great Plate of Burning Misery",
                    "Steel Tunic of Silent Misery",
                    "Malicious Chain Tunic",
                    "Storm Guard Golden Battle Plate",
                    "Promised Vest of Torment",
                    "Gladiator Armor of Protection",
                    "Fall of the Whale",
                    "Bond of Courage"
                };
            }

            Random random = new Random();

            int randomNameValue = random.Next(0, names.Length);

            return names[randomNameValue];
        }

        private float RandomRatingValue()
        {
            float max = 50.0f;

            Random random = new Random();

            float rating = MathF.Round((float)(random.NextDouble() * max), 2);

            return rating;
        }

        private float RandomEquipmentWeight()
        {
            float max = 100.0f;

            Random random = new Random();

            float rating = MathF.Round((float)(random.NextDouble() * max), 2);

            return rating;
        }

        private float CalculateValue()
        {
            float value = MathF.Round(((Rating / 50.0f) + (Weight / 100.0f)) / 2 * 100.0f, 2);

            return value;
        }
    }
}
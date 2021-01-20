namespace FactoryMethod
{
    public class Weapon : IEquipment
    {
        private readonly EquipmentType equipmentType;
        private readonly int id;
        private readonly string itemName;
        private readonly float defenseRating;
        private readonly float weight;
        private readonly float value;

        public Weapon(ICraftedEquipment equipment)
        {
            this.equipmentType = equipment.EquipmentType;
            this.id = equipment.Id;
            this.itemName = equipment.ItemName;
            this.defenseRating = equipment.Rating;
            this.weight = equipment.Weight;
            this.value = equipment.Value;
        }

        public string GetInfo()
        {
            return $"{ itemName } \nAttack rating: { defenseRating }\nWeight: { weight } kg\nValue: { value }$";
        }

        public float GetValue()
        {
            return value;
        }
    }
}
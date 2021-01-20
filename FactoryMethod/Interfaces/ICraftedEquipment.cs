namespace FactoryMethod
{
    public interface ICraftedEquipment
    {
        EquipmentType EquipmentType { get; }
        int Id { get; }
        string ItemName { get; }
        float Rating { get; }
        float Weight { get; }
        float Value { get; }
    }
}
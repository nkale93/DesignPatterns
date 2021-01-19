using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod
{
    public class FactoryManager
    {
        public IEquipment GetEquipment(EquipmentType equipmentType)
        {
            if (equipmentType == EquipmentType.Weapon)
            {
                return new Weapon(GetItem(equipmentType));
            }
            else if (equipmentType == EquipmentType.Armour)
            {
                return new Armour(GetItem(equipmentType));
            }
            else
            {
                return null;
            }
        }

        private IItem GetItem(EquipmentType equipmentType)
        {
            return new Item(equipmentType);
        }
    }
}
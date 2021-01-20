using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod
{
    public class FactoryMethodManager
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

        private ICraftedEquipment GetItem(EquipmentType equipmentType)
        {
            return new CraftedEquipment(equipmentType);
        }
    }
}
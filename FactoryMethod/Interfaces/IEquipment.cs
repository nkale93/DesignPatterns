using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod
{
    public interface IEquipment
    {
        string GetInfo();

        string GetName();

        float GetValue();

        float GetWeight();

        float GetRating();
    }
}
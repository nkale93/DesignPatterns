using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactoryMethod
{
    public class DefenseMode : AbstractMethod<DefenseType>
    {
        public override AbstractMethodDataItem GetData(DefenseType type)
        {
            AbstractMethodDataItem item = null;

            switch (type)
            {
                case DefenseType.NormalDefense:
                    item = new AbstractMethodDataItem(new Defense(type));
                    break;

                case DefenseType.VerticalDefense:
                    item = new AbstractMethodDataItem(new Defense(type));
                    break;

                case DefenseType.HorizontalDefense:
                    item = new AbstractMethodDataItem(new Defense(type));
                    break;
            }

            return item;
        }
    }
}
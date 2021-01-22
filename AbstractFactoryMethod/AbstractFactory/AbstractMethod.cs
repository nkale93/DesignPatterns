using System;

namespace AbstractFactoryMethod
{
    public abstract class AbstractMethod<EnumType> : IAbstractMethod<EnumType> where EnumType : Enum
    {
        public abstract AbstractMethodDataItem GetData(EnumType type);
    }
}
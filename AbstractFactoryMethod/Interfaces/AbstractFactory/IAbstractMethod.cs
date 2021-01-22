using System;

namespace AbstractFactoryMethod
{
    public interface IAbstractMethod<EnumType> where EnumType : Enum
    {
        AbstractMethodDataItem GetData(EnumType type);
    }
}
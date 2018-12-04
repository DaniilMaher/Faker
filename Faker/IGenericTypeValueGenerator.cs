using System;

namespace ValuesGenerator
{
    interface IGenericTypeValueGenerator : IBaseTypeValueGenerator
    {
        object Generate(Type parameter);
    }
}

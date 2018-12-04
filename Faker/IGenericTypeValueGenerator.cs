using System;

namespace Faker
{
    interface IGenericTypeValueGenerator : IBaseTypeValueGenerator
    {
        object Generate(Type parameter);
    }
}

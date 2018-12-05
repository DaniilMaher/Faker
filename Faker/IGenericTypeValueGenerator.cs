using System;

namespace Faker
{
    public interface IGenericTypeValueGenerator
    {
        object Generate(Type parameter);
    }
}

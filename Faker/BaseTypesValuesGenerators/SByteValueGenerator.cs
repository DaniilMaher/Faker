using System;

namespace Faker.BaseTypesValuesGenerators
{
    public class SByteValueGenerator : IBaseTypeValueGenerator
    {
        private Random random;

        public SByteValueGenerator()
        {
            random = new Random();
        }

        public object Generate()
        {
            return (sbyte)random.Next();
        }
    }
}

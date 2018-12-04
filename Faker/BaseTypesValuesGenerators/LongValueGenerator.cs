using System;

namespace Faker.BaseTypesValuesGenerators
{
    public class LongValueGenerator : IBaseTypeValueGenerator
    {
        private Random random;

        public LongValueGenerator()
        {
            random = new Random();
        }

        public object Generate()
        {
            return (long)random.NextDouble();
        }
    }
}

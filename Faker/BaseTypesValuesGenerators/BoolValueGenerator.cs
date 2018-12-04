using System;

namespace Faker.BaseTypesValuesGenerators
{
    public class BoolValueGenerator : IBaseTypeValueGenerator
    {
        private Random random;

        public BoolValueGenerator()
        {
            random = new Random();
        }

        public object Generate()
        {
            return random.Next() % 2 == 0;
        }
    }
}

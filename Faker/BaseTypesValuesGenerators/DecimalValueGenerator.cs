using System;

namespace Faker.BaseTypesValuesGenerators
{
    public class DecimalValueGenerator : IBaseTypeValueGenerator
    {
        private Random random;

        public DecimalValueGenerator()
        {
            random = new Random();
        }

        public object Generate()
        {
            return (decimal)random.Next();
        }
    }
}

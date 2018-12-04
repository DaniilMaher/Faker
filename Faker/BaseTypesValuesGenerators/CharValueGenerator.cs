using System;

namespace Faker.BaseTypesValuesGenerators
{
    public class CharValueGenerator : IBaseTypeValueGenerator
    {
        private Random random;

        public CharValueGenerator()
        {
            random = new Random();
        }

        public object Generate()
        {
            return (char)random.Next();
        }
    }
}

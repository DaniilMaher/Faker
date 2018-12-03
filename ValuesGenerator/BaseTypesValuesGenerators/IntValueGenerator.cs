using System;

namespace ValuesGenerator.BaseTypesValuesGenerators
{
    public class IntValueGenerator : IBaseTypeValueGenerator
    {
        private Random random;

        public IntValueGenerator()
        {
            random = new Random();
        }

        public object Generate()
        {
            return random.Next();
        }
    }
}

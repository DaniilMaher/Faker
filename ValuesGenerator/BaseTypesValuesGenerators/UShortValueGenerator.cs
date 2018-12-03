using System;

namespace ValuesGenerator.BaseTypesValuesGenerators
{
    public class UShortValueGenerator : IBaseTypeValueGenerator
    {
        private Random random;

        public UShortValueGenerator()
        {
            random = new Random();
        }

        public object Generate()
        {
            return (ushort)random.Next();
        }
    }
}

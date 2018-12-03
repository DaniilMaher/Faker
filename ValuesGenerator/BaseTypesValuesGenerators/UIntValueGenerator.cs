using System;

namespace ValuesGenerator.BaseTypesValuesGenerators
{
    public class UIntValueGenerator : IBaseTypeValueGenerator
    {
        private Random random;

        public UIntValueGenerator()
        {
            random = new Random();
        }

        public object Generate()
        {
            return (uint)random.Next();
        }
    }
}

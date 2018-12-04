using System;

namespace ValuesGenerator.BaseTypesValuesGenerators
{
    public class ByteValueGenerator : IBaseTypeValueGenerator
    {
        private Random random;

        public ByteValueGenerator()
        {
            random = new Random();
        }

        public object Generate()
        {
            return (byte)random.Next();
        }
    }
}

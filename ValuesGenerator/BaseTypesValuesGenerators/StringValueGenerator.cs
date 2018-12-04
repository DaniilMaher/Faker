using System;

namespace ValuesGenerator.BaseTypesValuesGenerators
{
    public class StringValueGenerator : IBaseTypeValueGenerator
    {
        private Random random;

        public StringValueGenerator()
        {
            random = new Random();
        }

        public object Generate()
        {
            byte[] strBytes = new byte[random.Next(0, byte.MaxValue)];
            random.NextBytes(strBytes);
            return Convert.ToBase64String(strBytes); 
        }
    }
}

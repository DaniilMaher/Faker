using System;

namespace ValuesGenerator.BaseTypesValuesGenerators
{
    public class DoubleValueGenerator : IBaseTypeValueGenerator
    {
        private Random random;

        public DoubleValueGenerator()
        {
            random = new Random();
        }
      
        public object Generate()
        {
            return random.NextDouble();
        }
    }
}

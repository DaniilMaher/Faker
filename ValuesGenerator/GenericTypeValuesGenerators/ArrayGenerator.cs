using System;

namespace ValuesGenerator.GenericTypeValuesGenerators
{
    public class ArrayGenerator : IGenericTypeValueGenerator
    {
        private Random random;
        priva

        public ArrayGenerator()
        {
            random = new Random();
        }

        public object Generate(Type type)
        {
            Array generated = Array.CreateInstance(type, (byte)random.Next());
            for (int i = 0; i < generated.Length; i++)
            {
                generated.SetValue();
            }
            return generated;
        }

        public object Generate()
        {
            throw new NotImplementedException();
        }
    }
}

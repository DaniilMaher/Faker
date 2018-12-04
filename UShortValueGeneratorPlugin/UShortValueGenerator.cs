using System;
using Faker;

namespace UShortValueGeneratorPlugin
{
    public class UShortValueGenerator : IBaseTypeValueGeneratorPlugin
    {
        private Random random;

        public UShortValueGenerator()
        {
            random = new Random();
        }

        public Type GeneratedValueType
        {
            get
            {
                return typeof(ushort);
            }
        }

        public object Generate()
        {
            return (ushort)random.Next();
        }
    }
}

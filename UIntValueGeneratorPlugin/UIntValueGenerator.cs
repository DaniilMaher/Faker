using System;
using Faker;

namespace UIntValueGeneratorPlugin
{
    public class UIntValueGenerator : IBaseTypeValueGeneratorPlugin
    {
        private Random random;

        public UIntValueGenerator()
        {
            random = new Random();
        }

        public Type GeneratedValueType
        {
            get
            {
                return typeof(uint);
            }
        }

        public object Generate()
        {
            return (uint)random.Next();
        }
    }
       
}

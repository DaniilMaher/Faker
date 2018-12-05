using System;
using System.Collections.Generic;

namespace Faker.GenericTypeValuesGenerators
{
    public class ArrayGenerator : IGenericTypeValueGenerator
    {
        private Random random;
        private Dictionary<Type, IBaseTypeValueGenerator> baseTypesGenerators;

        public ArrayGenerator(Dictionary<Type, IBaseTypeValueGenerator> generators)
        {
            random = new Random();
            baseTypesGenerators = generators;
        }

        public object Generate(Type type)
        {
            Array generated = Array.CreateInstance(type, (byte)random.Next());
            if (baseTypesGenerators.TryGetValue(type, out IBaseTypeValueGenerator generator))
            {
                for (int i = 0; i < generated.Length; i++)
                {
                    generated.SetValue(generator.Generate(), i);
                }
            }
            return generated;
        }
    }
}

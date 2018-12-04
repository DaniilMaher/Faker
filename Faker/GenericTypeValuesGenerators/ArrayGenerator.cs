using System;
using System.Collections.Generic;

namespace Faker.GenericTypeValuesGenerators
{
    public class ArrayGenerator : IGenericTypeValueGenerator
    {
        private Random random;
        private Dictionary<Type, IBaseTypeValueGenerator> baseTypesGenerators;

        public ArrayGenerator()
        {
            random = new Random();
            baseTypesGenerators = GeneratorsDictionaryCreator.CreateBaseTypesGeneratorsDictionary();
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

        public object Generate()
        {
            throw new NotImplementedException();
        }
    }
}

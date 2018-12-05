using System;
using System.Collections;
using System.Collections.Generic;

namespace Faker.GenericTypeValuesGenerators
{
    public class ListGenerator : IGenericTypeValueGenerator
    {
        private Random random;
        private Dictionary<Type, IBaseTypeValueGenerator> baseTypesGenerators;
        
        public object Generate(Type baseType)
        {
            IList generated = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(baseType));
            if (baseTypesGenerators.TryGetValue(baseType, out IBaseTypeValueGenerator generator))
            {
                byte listSize = (byte)random.Next();

                for (int i = 0; i < listSize; i++)
                {
                    generated.Add(generator.Generate());
                }
            }
            return generated;
        }

        public ListGenerator(Dictionary<Type, IBaseTypeValueGenerator> generators)
        {
            this.baseTypesGenerators = generators;
            random = new Random();
        }
    }
}

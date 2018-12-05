using System;
using System.Collections.Generic;
using Faker.BaseTypesValuesGenerators;
using Faker.GenericTypeValuesGenerators;

namespace Faker
{
    public class GeneratorsDictionaryCreator
    {
        public static Dictionary<Type, IBaseTypeValueGenerator> CreateBaseTypesGeneratorsDictionary()
        {
            Dictionary<Type, IBaseTypeValueGenerator> dictionary = new Dictionary<Type, IBaseTypeValueGenerator>();
            dictionary.Add(typeof(bool), new BoolValueGenerator());
            dictionary.Add(typeof(byte), new ByteValueGenerator());
            dictionary.Add(typeof(char), new CharValueGenerator());
            dictionary.Add(typeof(decimal), new DecimalValueGenerator());
            dictionary.Add(typeof(double), new DoubleValueGenerator());
            dictionary.Add(typeof(float), new FloatValueGenerator());
            dictionary.Add(typeof(int), new IntValueGenerator());
            dictionary.Add(typeof(long), new LongValueGenerator());
            dictionary.Add(typeof(sbyte), new SByteValueGenerator());
            dictionary.Add(typeof(short), new ShortValueGenerator());
            dictionary.Add(typeof(DateTime), new DateTimeValueGenerator());
            return dictionary;
        }

        public static Dictionary<Type, IGenericTypeValueGenerator> CreateGenericTypesGeneratorsDictionary(Dictionary<Type, IBaseTypeValueGenerator> generators)
        {
            Dictionary<Type, IGenericTypeValueGenerator> dictionary = new Dictionary<Type, IGenericTypeValueGenerator>();
            dictionary.Add(typeof(List<>), new ListGenerator(generators));
            return dictionary;
        }
    }
}

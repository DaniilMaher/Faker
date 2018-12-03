using System;
using System.Collections.Generic;
using ValuesGenerator;

namespace Faker
{
    public class Faker : IFaker
    {
        private Dictionary<Type, IBaseTypeValueGenerator> baseTypesGenerators;
        private Stack<Type> generatedTypes;

        public T Create<T>()
        {
            return (T)Create(typeof(T));
        }

        private object Create(Type type)
        {
            object created = null;
            if (type.IsValueType)
            {
                if (baseTypesGenerators.TryGetValue(type, out IBaseTypeValueGenerator generator))
                {
                    created = generator.Generate();
                } 
                else
                {
                    created = Activator.CreateInstance(type);
                }
            }
            else if (type.IsClass && !type.IsGenericType && !type.IsArray && !type.IsPointer && !type.IsAbstract && !generatedTypes.Contains(type))
            {
                created = CreateCustomObject(type);
                FillFieldsAndProperties(created);
            }
            return created;
        }

        private void FillFieldsAndProperties(object o)
        {

        }

        private object CreateCustomObject(Type type)
        {
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using Faker.GenericTypeValuesGenerators;
namespace Faker
{
    public class Faker : IFaker
    {
        private Dictionary<Type, IBaseTypeValueGenerator> baseTypesGenerators;
        private Dictionary<Type, IGenericTypeValueGenerator> genericTypesGenerators;
        private IGenericTypeValueGenerator arrayGenerator;

        private Stack<Type> generatedTypes;
        private string pluginsPath = "Plugins";

        public Faker()
        {
            generatedTypes = new Stack<Type>();
            baseTypesGenerators = GeneratorsDictionaryCreator.CreateBaseTypesGeneratorsDictionary();
            genericTypesGenerators = GeneratorsDictionaryCreator.CreateGenericTypesGeneratorsDictionary(baseTypesGenerators);
            arrayGenerator = new ArrayGenerator(baseTypesGenerators);
            PlugPlugins();
        }

        public T Create<T>()
        {
            return (T)Create(typeof(T));
        }

        internal object Create(Type type)
        {
            object created = null;
            if (baseTypesGenerators.TryGetValue(type, out IBaseTypeValueGenerator generator))
            {
                created = generator.Generate();
            }
            else if (type.IsGenericType && genericTypesGenerators.TryGetValue(type.GetGenericTypeDefinition(), out IGenericTypeValueGenerator genericTypeGenerator))
            {
                created = genericTypeGenerator.Generate(type.GenericTypeArguments[0]);
            }
            else if (type.IsArray)
            {
                created = arrayGenerator.Generate(type.GetElementType());
            }
            else if (type.IsValueType)
            {
                created = Activator.CreateInstance(type);
            }
            else if (type.IsClass && !type.IsGenericType && !type.IsAbstract && !generatedTypes.Contains(type))
            {
                generatedTypes.Push(type);
                created = CreateCustomObject(type);
                if (created != null)
                {
                    SetFieldsValues(created);
                    SetPropertiesValues(created);
                }
                generatedTypes.Pop();
            }
            return created;
        }

        private void SetFieldsValues(object o)
        {
            Type type = o.GetType();
            foreach (FieldInfo fieldInfo in type.GetFields(BindingFlags.Instance | BindingFlags.Public))
            {
                object fieldValue = Create(fieldInfo.FieldType);
                fieldInfo.SetValue(o, fieldValue);
            }

        }

        private void SetPropertiesValues(object o)
        {
            Type type = o.GetType();
            foreach (PropertyInfo propertyInfo in type.GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                if (propertyInfo.CanWrite)
                {
                    object propertyValue = Create(propertyInfo.PropertyType);
                    propertyInfo.SetValue(o, propertyValue);
                }
            }
        }

        private object CreateCustomObject(Type type)
        {
            object created = null;
            ConstructorInfo[] constructors = type.GetConstructors();
            Array.Sort<ConstructorInfo>(constructors, (o1, o2) => o2.GetParameters().Length - o1.GetParameters().Length);
            foreach (ConstructorInfo constructor in constructors)
            {
                created = CreateObjectByConstructor(constructor);
                if (created != null)
                {
                    return created;
                }
            }
            return created;
        }

        private object CreateObjectByConstructor(ConstructorInfo constructor)
        {
            List<object> parametersValues = new List<object>();
            foreach (ParameterInfo parameter in constructor.GetParameters())
            {
                object value = Create(parameter.ParameterType);
                parametersValues.Add(value);
            }
            try
            {
                return constructor.Invoke(parametersValues.ToArray());
            }
            catch (TargetInvocationException)
            {
                return null;
            }
        }

        private void PlugPlugins()
        {
            List<Assembly> assemblies = new List<Assembly>();
            try
            {
                foreach (string file in Directory.GetFiles(pluginsPath, "*.dll"))
                {
                    try
                    {
                        assemblies.Add(Assembly.LoadFile(new FileInfo(file).FullName));
                    }
                    catch (BadImageFormatException)
                    { }
                    catch (FileLoadException)
                    { }
                }
            }
            catch (DirectoryNotFoundException)
            { }

            foreach (Assembly assembly in assemblies)
            {
                foreach (Type type in assembly.GetTypes())
                {
                    if (typeof(IBaseTypeValueGeneratorPlugin).IsAssignableFrom(type) && type.IsClass && !type.IsAbstract)
                    {
                        IBaseTypeValueGeneratorPlugin generator = (IBaseTypeValueGeneratorPlugin)Activator.CreateInstance(type);
                        baseTypesGenerators.Add(generator.GeneratedValueType, generator);
                    }
                }
            }

        }
    }
}

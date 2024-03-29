﻿using System;

namespace Faker.BaseTypesValuesGenerators
{
    public class FloatValueGenerator : IBaseTypeValueGenerator
    {
        private Random random;

        public FloatValueGenerator()
        {
            random = new Random();
        }

        public object Generate()
        {
            return (float)random.NextDouble();
        }
    }
}

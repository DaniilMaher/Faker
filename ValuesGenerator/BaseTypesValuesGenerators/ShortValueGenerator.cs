﻿using System;

namespace ValuesGenerator.BaseTypesValuesGenerators
{
    public class ShortValueGenerator : IBaseTypeValueGenerator
    {
        private Random random;

        public ShortValueGenerator()
        {
            random = new Random();
        }

        public object Generate()
        {
            return (short)random.Next();
        }
    }
}

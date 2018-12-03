using System;

namespace Faker
{
    class Faker : IFaker
    {
        public T Create<T>()
        {
            throw new NotImplementedException();
        }
    }
}

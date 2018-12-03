using System;

namespace Faker
{
    public class Faker : IFaker
    {
        public T Create<T>()
        {
            throw new NotImplementedException();
        }
    }
}

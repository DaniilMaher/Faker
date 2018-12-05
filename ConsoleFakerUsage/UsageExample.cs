using System;

namespace ConsoleFakerUsage
{
    class UsageExample
    {
        static void Main(string[] args)
        {
            Faker.Faker faker = new Faker.Faker();
            Foo foo = faker.Create<Foo>();
            foo.Print();
            int[] arr = { 1, 46, 3};
        }
    }
}

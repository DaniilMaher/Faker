using Faker;

namespace ConsoleFakerUsage
{
    class UsageExample
    {
        static void Main(string[] args)
        {
            Faker.Faker faker = new Faker.Faker();
            Foo foo = faker.Create<Foo>();
            foo.Print();          
        }
    }
}

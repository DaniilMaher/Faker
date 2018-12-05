
using System.Collections.Generic;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TracerUnitTest
{
    [TestClass]
    public class FakerUnitTest
    {
        private Faker.Faker faker;

        [TestInitialize]
        public void Setup()
        {
            faker = new Faker.Faker();
        }

        [TestMethod]
        public void RecursionTest()
        {
            Foo foo = faker.Create<Foo>();
            Assert.IsNull(foo.bar.foo);
        }

        [TestMethod]
        public void FieldsFillingTest()
        {
            Test test = faker.Create<Test>();
            Assert.IsTrue((test.Prop1 != 0) && (test.Prop2 != 0));
        }

        [TestMethod]
        public void PluginsTest()
        {
            PluginsTest test = faker.Create<PluginsTest>();
            Assert.IsTrue((test.field1 != 0) && (test.field2 != 0));
        }



    }
}

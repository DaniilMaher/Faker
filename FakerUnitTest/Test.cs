
namespace TracerUnitTest
{
    public class Test
    {
        public int Prop1
        {
            private set;
            get;
        } = 0;
        public int Prop2
        {
            set;
            get;
        } = 0;

        public Test(int prop1)
        {
            Prop1 = prop1;
        }
    }
}

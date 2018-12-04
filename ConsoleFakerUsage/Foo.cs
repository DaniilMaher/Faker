using System;

namespace ConsoleFakerUsage
{
    class Foo
    {
        private ushort field1;
        public short field2;
        public int field3;
        private char ch;

        public Foo(ushort value, char c)
        {
            field1 = value;
            ch = c;
        }

        public void Print()
        {
            Console.WriteLine(field1 + " " + field2 + " " + field3 + " " + ch);
        }
    }
}

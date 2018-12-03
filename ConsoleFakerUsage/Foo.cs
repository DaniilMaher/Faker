using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFakerUsage
{
    class Foo
    {
        private byte field1;
        public short field2;
        private int field3;
        private char ch;

        public Foo(byte value, char c)
        {
            field1 = value;
            ch = c;
        }

        public void Print()
        {
            Console.WriteLine(field1 + " " + field2 + " " + field3 + " ");
        }
    }
}

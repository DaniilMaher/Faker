using System;
using System.Collections.Generic;

namespace ConsoleFakerUsage
{
    public class Foo
    {
        private ushort field1;
        public ushort field2;
        public uint field3;
        private char ch;
        public List<int> arr;

        public Foo(ushort value, char c)
        {
            field1 = value;
            ch = c;
        }

        public void Print()
        {
            Console.WriteLine(field1 + " " + field2 + " " + field3 + " " + ch);
            foreach (ushort num in arr)
            {
                Console.Write(num + " ");
            }
        }
    }
}

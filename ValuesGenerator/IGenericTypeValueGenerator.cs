using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValuesGenerator
{
    interface IGenericTypeValueGenerator : IBaseTypeValueGenerator
    {
        object Generate(Type parameter);
    }
}

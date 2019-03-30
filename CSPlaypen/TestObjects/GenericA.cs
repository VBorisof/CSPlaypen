using System;
using System.Collections.Generic;
using System.Text;

namespace CSPlaypen.TestObjects
{
    class GenericA <T>
    {
        public static string ToStr()
        {
            return $"{typeof(GenericA<T>).Name}<{typeof(T).Name}>";
        }
    }
}

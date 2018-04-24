using Compiler.Core.Chars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Core.Expression
{
    public static class Expressions
    {
        public static IExpression Sequence(string str, bool ignoreCase = false)
        {
            return new Sequence(str, ignoreCase);
        }

        public static IExpression Sequence(params IExpression[] elements)
        {
            return new Sequence(elements);
        }
    }
}

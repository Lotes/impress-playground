using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Core.Expression
{
    public static class Grammars
    {
        public static IGrammarBuilder New()
        {
            return null;
        }

        public static IExpression Then(this IExpression lhs, params IExpression[] rhss)
        {
            return new Sequence(new[] { lhs }.Concat(rhss));
        }
    }
}

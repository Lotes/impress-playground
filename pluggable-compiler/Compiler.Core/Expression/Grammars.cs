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
            return new GrammarBuilder();
        }

        public static IGrammarExpression Then(this IGrammarExpression lhs, params IGrammarExpression[] rhss)
        {
            return new Sequence(new[] { lhs }.Concat(rhss));
        }
    }
}

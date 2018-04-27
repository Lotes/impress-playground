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
        public static readonly IExpression Epsilon = new CharacterClass(new CharSet());

        public static readonly IExpression EOF = new EOF();

        public static IExpression Sequence(string str, bool ignoreCase = false)
        {
            return new Sequence(str, ignoreCase);
        }

        public static IExpression Sequence(params IExpression[] elements)
        {
            return new Sequence(elements);
        }

        public static IExpression Choice(params IExpression[] choices)
        {
            return new Choice(choices);
        }

        public static IExpression Call(IRule rule)
        {
            return new Call(rule);
        }

        public static IExpression Repeat(IExpression expression, int min, int? max = null)
        {
            return new Repetition(expression, min, max);
        }
    }
}

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
        public static readonly IGrammarExpression<string> Epsilon = new CharacterClass(new CharSet());

        public static readonly IGrammarExpression<string> EOF = new EOF<string>();

        public static IGrammarExpression Sequence(params IGrammarExpression[] elements)
        {
            return new Sequence(elements);
        }

        public static IGrammarExpression Choice(params IGrammarExpression[] choices)
        {
            return new Choice(choices);
        }

        public static IGrammarExpression Call(IRule rule)
        {
            return new Call(rule);
        }

        public static IGrammarExpression Repeat(IGrammarExpression expression, int min, int? max = null)
        {
            return new Repetition(expression, min, max);
        }
    }
}

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
        public static readonly IGrammarExpression Epsilon = new CharacterClass(new CharSet());

        public static readonly IGrammarExpression EOF = new EOF();

        /*public static T ReferencedAs<T>(IGrammarExpression<T> expr, )
        {

        }*/

        public static IGrammarExpression Sequence(params IGrammarExpression[] elements)
        {
            return new Sequence(elements);
        }

        public static IGrammarExpression Char(char c)
        {
            return new Sequence(new[] { new CharacterClass(new CharSet(c)) });
        }

        public static IGrammarExpression Choice(params IGrammarExpression[] choices)
        {
            return new Choice(choices);
        }

        public static IGrammarExpression CharacterClass(params char[] chars)
        {
            return new CharacterClass(new CharSet(chars));
        }

        public static IGrammarExpression CharacterClass(params CharRange[] ranges)
        {
            return new CharacterClass(new CharSet(ranges));
        }

        public static IGrammarExpression Call(IRule rule)
        {
            return new Call(rule);
        }

        public static IGrammarExpression Repeat(IGrammarExpression expression, int min, int? max = null)
        {
            return new Repetition(expression, min, max);
        }

        public static IGrammarExpression ZeroOrMore(IGrammarExpression expression)
        {
            return new Repetition(expression, 0, null);
        }

        public static IGrammarExpression OneOrMore(IGrammarExpression expression)
        {
            return new Repetition(expression, 1, null);
        }

        public static IGrammarExpression Optional(IGrammarExpression expression)
        {
            return new Repetition(expression, 0, 1);
        }

        public static IGrammarExpression Named(string name, IGrammarExpression expression)
        {
            return new Named(name, expression);
        }
    }
}

using Compiler.Core.Chars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Core.Expression
{
    using static Expressions;

    public static partial class Expressions
    {
        public static readonly IGrammarExpression<string> Epsilon = new CharacterClass(new CharSet());

        public static IGrammarExpression<string> String(string str, bool ignoreCase = true)
        {
            if (string.IsNullOrEmpty(str))
                return Epsilon;
            var first = str[0];
            IGrammarExpression<string> result = new CharacterClass(new CharSet(first, ignoreCase));
            for (var index = 1; index < str.Length; index++)
                result = Sequence(result, new CharacterClass(new CharSet(str[index]))).Returns(string.Concat);
            return result;
        }

        public static IGrammarExpression<string> Concat(this IGrammarExpression<IReadOnlyList<string>> @this)
        {
            return @this.Returns(string.Concat);
        }

        public static IGrammarExpression<TResult> Null<TResult>() { return (IGrammarExpression<TResult>)null; }

        public static readonly IGrammarExpression<string> EOF = new EOF();
        public static IGrammarExpression<string> Char(char c)
        {
            return new CharacterClass(new CharSet(c));
        }

        public static IGrammarExpression<string> Chars(params char[] cs)
        {
            return new CharacterClass(new CharSet(cs));
        }

        public static IGrammarExpression<string> Range(char from, char to)
        {
            return new CharacterClass(new CharSet(new CharRange(from, to)));
        }

        public static IGrammarBuilder New()
        {
            return new GrammarBuilder();
        }

        public static IGrammarExpression<TResult> Choice<TResult>(params IGrammarExpression<TResult>[] choices)
        {
            return new Choice<TResult>(choices);
        }

        public static IGrammarExpression<TResult> Call<TResult>(IRule<TResult> rule)
        {
            return new Call<TResult>(rule);
        }

        public static IGrammarExpression<TResult> Returns<TSource, TResult>(this IGrammarExpression<TSource> expr, Func<TSource, TResult> convert)
        {
            return new Return<TSource, TResult>(expr, convert);
        }

        public static IGrammarExpression<IReadOnlyList<TResult>> Repeat<TResult>(IGrammarExpression<TResult> expression, int min, int? max = null)
        {
            return new Repetition<TResult>(expression, min, max);
        }

        public static IGrammarExpression<IReadOnlyList<TResult>> ZeroOrMore<TResult>(IGrammarExpression<TResult> expression)
        {
            return Repeat(expression, 0, null);
        }

        public static IGrammarExpression<IReadOnlyList<TResult>> OneOrMore<TResult>(IGrammarExpression<TResult> expression)
        {
            return Repeat(expression, 1, null);
        }

        public static IGrammarExpression<IReadOnlyList<TResult>> Optional<TResult>(IGrammarExpression<TResult> expression)
        {
            return Repeat(expression, 0, 1);
        }

        public static IGrammarExpression<TResult> As<TResult>(string name, IGrammarExpression<TResult> expression)
        {
            return new Named<TResult>(name, expression);
        }
    }
}

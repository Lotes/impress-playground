using Compiler.Core.Chars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Core.Expression
{
    public static partial class Expressions
    {
        public static readonly IGrammarExpression<string> Epsilon = new CharacterClass(new CharSet());

        public static readonly IGrammarExpression<string> EOF = new EOF();

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
    }
}

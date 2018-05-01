using System;
using System.Collections.Generic;

namespace Compiler.Core.Expression
{
    public class Repetition<TResult> : IGrammarExpression<IReadOnlyList<TResult>>
    {
        public Repetition(IGrammarExpression<TResult> expression, int minimum, int? maximum)
        {
            if (maximum != null && minimum > maximum.Value)
                throw new ArgumentException(nameof(maximum));
            Expression = expression;
            Minimum = minimum;
            Maximum = maximum;
        }

        public IGrammarExpression<TResult> Expression { get; }
        public int Minimum { get; }
        public int? Maximum { get; }

        public MayBe<IParseResult<IReadOnlyList<TResult>>> ParseAt(IParserVisitor visitor, int position)
        {
            return visitor.Visit_Repetition(position, this);
        }
    }
}

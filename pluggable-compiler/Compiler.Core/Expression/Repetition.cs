using System;
using System.Collections.Generic;

namespace Compiler.Core.Expression
{
    public class Repetition<TResult> : IGrammarExpression<TResult[]>
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

        public TResult[] Accept<S>(IVisitor<S> visitor, S state)
        {
            return visitor.Visit_Repetition(state, this);
        }       
    }
}

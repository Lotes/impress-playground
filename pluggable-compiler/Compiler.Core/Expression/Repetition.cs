using System;
using System.Collections.Generic;

namespace Compiler.Core.Expression
{
    public class Repetition: IGrammarExpression
    {
        public Repetition(IGrammarExpression expression, int minimum, int? maximum)
        {
            if (maximum != null && minimum > maximum.Value)
                throw new ArgumentException(nameof(maximum));
            Expression = expression;
            Minimum = minimum;
            Maximum = maximum;
        }

        public IGrammarExpression Expression { get; }
        public int Minimum { get; }
        public int? Maximum { get; }

        public T Accept<T, S>(IVisitor<T, S> visitor, S state)
        {
            return visitor.Visit_Repetition(state, this);
        }       
    }
}

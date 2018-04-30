using Compiler.Core.Chars;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Compiler.Core.Expression
{
    public class Sequence: IGrammarExpression
    {
        public Sequence(IEnumerable<IGrammarExpression> elements)
        {
            Elements = elements;
        }

        public IEnumerable<IGrammarExpression> Elements { get; }

        public T Accept<T, S>(IVisitor<T, S> visitor, S state)
        {
            return visitor.Visit_Sequence(state, this);
        }
    }
}

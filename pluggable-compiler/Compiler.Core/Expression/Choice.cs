using System.Collections.Generic;

namespace Compiler.Core.Expression
{
    public class Choice: IGrammarExpression
    {
        public Choice(IEnumerable<IGrammarExpression> choices)
        {
            Choices = choices;
        }

        public IEnumerable<IGrammarExpression> Choices { get; }

        public T Accept<T, S>(IVisitor<T, S> visitor, S state)
        {
            return visitor.Visit_Choice(state, this);
        }
    }
}

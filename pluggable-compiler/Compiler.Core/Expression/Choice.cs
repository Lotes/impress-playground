using System.Collections.Generic;

namespace Compiler.Core.Expression
{
    public class Choice<TResult, TOperand> : IGrammarExpression<TResult>
    {
        public Choice(IEnumerable<IGrammarExpression<TOperand>> choices)
        {
            Choices = choices;
        }

        public IEnumerable<IGrammarExpression<TOperand>> Choices { get; }

        public TResult Accept<S>(IVisitor<S> visitor, S state)
        {
            return visitor.Visit_Choice(state, this);
        }
    }
}

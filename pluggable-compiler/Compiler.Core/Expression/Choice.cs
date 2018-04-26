using System.Collections.Generic;

namespace Compiler.Core.Expression
{
    public class Choice: IExpression
    {
        public Choice(IEnumerable<IExpression> choices)
        {
            Choices = choices;
        }

        public IEnumerable<IExpression> Choices { get; }

        public T Accept<T, S>(IVisitor<T, S> visitor, S state)
        {
            return visitor.Visit_Choice(state, this);
        }
    }
}

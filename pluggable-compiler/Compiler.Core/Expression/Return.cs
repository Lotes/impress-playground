using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Core.Expression
{
    public class Return<TType> : IGrammarExpression
    {
        public Return(IGrammarExpression expression, Func<IParseResult, TType> @return)
        {
            Expression = expression;
            Convert = @return;
        }

        public IGrammarExpression Expression { get; }
        public Func<IParseResult, TType> Convert { get; }

        public TResult Accept<TResult, TState>(IVisitor<TResult, TState> visitor, TState state)
        {
            return visitor.Visit_Return(state, this);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Core.Expression
{
    public class Named<TResult, TOperand> : IGrammarExpression<TResult>
    {
        public string Name { get; }
        public IGrammarExpression<TOperand> Expression { get; }

        public TResult Accept<S>(IVisitor<S> visitor, S state)
        {
            return visitor.Visit_Named(state, this);
        }
    }
}

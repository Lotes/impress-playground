using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Core.Expression
{
    public class Call<TResult>: IGrammarExpression<TResult>
    {
        public Call(IRule<TResult> rule)
        {
            Rule = rule;
        }

        public IRule<TResult> Rule { get; }
        public TResult Accept<S>(IVisitor<S> visitor, S state)
        {
            return visitor.Visit_Call(state, this);
        }
    }
}

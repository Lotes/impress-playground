using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Core.Expression
{
    public class EOF<TResult> : IGrammarExpression<TResult>
    {
        public TResult Accept<S>(IVisitor<S> visitor, S state)
        {
            return visitor.Visit_EOF(state, this);
        }
    }
}

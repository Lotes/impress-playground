using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Core.Expression
{
    public class Call: IGrammarExpression
    {
        public Call(IRule rule)
        {
            Rule = rule;
        }

        public IRule Rule { get; }
        public T Accept<T, S>(IVisitor<T, S> visitor, S state)
        {
            return visitor.Visit_Call(state, this);
        }
    }
}

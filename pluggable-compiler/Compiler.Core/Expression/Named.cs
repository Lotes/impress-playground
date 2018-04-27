using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Core.Expression
{
    public class Named : IGrammarExpression
    {
        public string Name { get; }
        public IGrammarExpression Expression { get; }

        public T Accept<T, S>(IVisitor<T, S> visitor, S state)
        {
            return visitor.Visit_Named(state, this);
        }
    }
}

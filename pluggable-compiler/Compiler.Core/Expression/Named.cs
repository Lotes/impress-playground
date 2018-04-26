using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Core.Expression
{
    public class Named : IExpression
    {
        public string Name { get; }
        public IExpression Expression { get; }

        public T Accept<T, S>(IVisitor<T, S> visitor, S state)
        {
            return visitor.Visit_Named(state, this);
        }
    }
}

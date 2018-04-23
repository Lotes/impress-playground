using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Core.Expression
{
    public class Named : IExpression
    {
        public string Identifier { get; }
        public IExpression Expression { get; }

        public T Accept<T>(IVisitor<T> visitor)
        {
            return visitor.Visit_Named(this);
        }

        public bool Parse(IParserContext context, int position, out IParseResult result)
        {
            var ok = Expression.Parse(context, position, out result);
            result = ok ? new ParseResult(this, context, result.Start.Index, result.End.Index) : null;
            return ok;
        }
    }
}

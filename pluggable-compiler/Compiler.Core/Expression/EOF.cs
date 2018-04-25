using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Core.Expression
{
    public class EOF : IExpression
    {
        public T Accept<T>(IVisitor<T> visitor)
        {
            return visitor.Visit_EOF(this);
        }

        public bool Parse(IParserContext context, int position, out IParseResult result)
        {
            result = new ParseResult(this, context, position, position-1, new IParseResult[0]);
            return position >= context.Input.Length;
        }
    }
}

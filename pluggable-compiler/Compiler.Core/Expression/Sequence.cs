using System;
using System.Collections.Generic;

namespace Compiler.Core.Expression
{
    public class Sequence: IExpression
    {
        public Sequence(IEnumerable<IExpression> elements)
        {
            Elements = elements;
        }

        public IEnumerable<IExpression> Elements { get; }

        public T Accept<T>(IVisitor<T> visitor)
        {
            return visitor.Visit_Sequence(this);
        }

        public bool Parse(IParserContext context, int position, out IParseResult result)
        {
            var pos = position;
            foreach(var element in Elements)
            {
                IParseResult elemResult;
                if (!element.Parse(context, position, out elemResult))
                {
                    result = null;
                    return false;
                }
                pos += elemResult.GetLength();
            }
            result = new ParseResult(this, context, position, Math.Max(position, pos - 1));
            return true;
        }
    }
}

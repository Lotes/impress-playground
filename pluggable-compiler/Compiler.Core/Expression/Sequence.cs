using Compiler.Core.Chars;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Compiler.Core.Expression
{
    public class Sequence: IExpression
    {
        public Sequence(IEnumerable<IExpression> elements)
        {
            Elements = elements;
        }

        public Sequence(string str, bool ignoreCase = false)
        {
            Elements = str.Select(c => 
            {
                ICharSet cs;
                if (ignoreCase)
                {
                    var low = c.ToString().ToLower()[0];
                    var up = c.ToString().ToUpper()[0];
                    if(low == up)
                        cs = new CharSet(low);
                    else
                        cs = new CharSet(low, up);
                }
                else
                    cs = new CharSet(c);
                return new CharacterClass(cs);
            }).ToArray();
        }

        public IEnumerable<IExpression> Elements { get; }

        public T Accept<T>(IVisitor<T> visitor)
        {
            return visitor.Visit_Sequence(this);
        }

        public bool Parse(IParserContext context, int position, out IParseResult result)
        {
            var pos = position;
            var list = new LinkedList<IParseResult>();
            foreach(var element in Elements)
            {
                IParseResult elemResult;
                if (!element.Parse(context, pos, out elemResult))
                {
                    result = null;
                    return false;
                }
                list.AddLast(elemResult);
                pos += elemResult.GetLength();
            }
            result = new ParseResult(this, context, position, Math.Max(position, pos - 1), list);
            return true;
        }
    }
}

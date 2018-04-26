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

        public T Accept<T, S>(IVisitor<T, S> visitor, S state)
        {
            return visitor.Visit_Sequence(state, this);
        }
    }
}

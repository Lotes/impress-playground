using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Core.Expression
{
    public class Call: IExpression
    {
        public string Identifier { get; }
        public T Accept<T>(IVisitor<T> visitor)
        {
            return visitor.Visit_Call(this);
        }

        public bool Parse(IParserContext context, int position, out IParseResult result)
        {
            if (!context.Grammar.Rules.ContainsKey(Identifier))
                throw new InvalidOperationException("Invalid grammar!");
            var rule = context.Grammar.Rules[Identifier].Expression;
            var ok = rule.Parse(context, position, out result);
            result = ok ? new ParseResult(this, context, result.Start.Index, result.End.Index) : null;
            return ok;
        }
    }
}

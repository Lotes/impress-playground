using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Core.Expression
{
    public class Call: IExpression
    {
        public Call(IRule rule)
        {
            Rule = rule;
        }

        public IRule Rule { get; }
        public T Accept<T>(IVisitor<T> visitor)
        {
            return visitor.Visit_Call(this);
        }

        public bool Parse(IParserContext context, int position, out IParseResult result)
        {
            if (!context.Grammar.Rules.Contains(Rule))
                throw new InvalidOperationException("Invalid call!");
            var ok = Rule.Expression.Parse(context, position, out result);
            result = ok ? new ParseResult(this, context, result.Start.Index, result.End.Index, new[] { result }) : null;
            return ok;
        }
    }
}

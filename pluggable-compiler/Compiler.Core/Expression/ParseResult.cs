using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Core.Expression
{
    public class ParseResult : IParseResult
    {
        public ParseResult(IExpression expression, IParserContext context, int startIndex, int endIndex)
        {
            Expression = expression;
            Context = context;
            Start = new Cursor(startIndex);
            End = new Cursor(endIndex);
        }

        public IExpression Expression { get; }

        public IParserContext Context { get; }

        public ICursor Start { get; }

        public ICursor End { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Core.Expression
{
    public class ParseResult : IParseResult
    {
        public ParseResult(IGrammarExpression expression, IParserContext context, int startIndex, int endIndex, IEnumerable<IParseResult> children)
        {
            Expression = expression;
            Context = context;
            Start = new Cursor(startIndex);
            End = new Cursor(endIndex);
            Children = new List<IParseResult>(children);
        }

        public IGrammarExpression Expression { get; }

        public IParserContext Context { get; }

        public ICursor Start { get; }

        public ICursor End { get; }

        public List<IParseResult> Children { get; }

        IReadOnlyList<IParseResult> IParseResult.Children => Children;
    }
}

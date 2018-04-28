using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Core.Expression
{
    public class ParseResult<TResult> : IParseResult<TResult>
    {
        public ParseResult(IGrammarExpression<TResult> expression, IParserContext context, ICursor start, ICursor end, IEnumerable<IParseResult> children)
        {
            Expression = expression;
            Context = context;
            Start = start;
            End = end;
            Children = new List<IParseResult>(children);
        }

        public IGrammarExpression<TResult> Expression { get; }

        public IParserContext Context { get; }

        public ICursor Start { get; }

        public ICursor End { get; }

        public List<IParseResult> Children { get; }

        IReadOnlyList<IParseResult> IParseResult.Children => Children;
    }
}

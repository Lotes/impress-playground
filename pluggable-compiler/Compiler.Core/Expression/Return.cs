using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Core.Expression
{
    public class Return<TSource, TResult> : IGrammarExpression<TResult>
    {
        public Return(IGrammarExpression<TSource> expression, Func<TSource, TResult> convert)
        {
            Expression = expression;
            Convert = convert;
        }

        public IGrammarExpression<TSource> Expression { get; }
        public Func<TSource, TResult> Convert { get; }

        public MayBe<IParseResult<TResult>> ParseAt(IParserVisitor visitor, int position)
        {
            return visitor.Visit_Return(position, this);
        }
    }
}

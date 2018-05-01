using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Core.Expression
{
    public class Call<TResult>: IGrammarExpression<TResult>
    {
        public Call(IRule<TResult> rule)
        {
            Rule = rule;
        }

        public IRule<TResult> Rule { get; }
        public MayBe<IParseResult<TResult>> ParseAt(IParserVisitor visitor, int position)
        {
            return visitor.Visit_Call(position, this);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Core.Expression
{
    public class Named<TResult> : IGrammarExpression<TResult>
    {
        public Named(string name, IGrammarExpression<TResult> expression)
        {
            Name = name;
            Expression = expression;
        }

        public string Name { get; }
        public IGrammarExpression<TResult> Expression { get; }

        public MayBe<IParseResult<TResult>> ParseAt(IParserVisitor visitor, int position)
        {
            return visitor.Visit_Named(position, this);
        }
    }
}

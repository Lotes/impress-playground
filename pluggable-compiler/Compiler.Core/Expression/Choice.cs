using System.Collections.Generic;

namespace Compiler.Core.Expression
{
    public class Choice<TResult> : IGrammarExpression<TResult>
    {
        public Choice(IEnumerable<IGrammarExpression<TResult>> choices)
        {
            Choices = choices;
        }

        public IEnumerable<IGrammarExpression<TResult>> Choices { get; }

        public MayBe<IParseResult<TResult>> ParseAt(IParserVisitor visitor, int position)
        {
            return visitor.Visit_Choice(position, this);
        }
    }
}

namespace Compiler.Core.Expression
{
    public class And<TResult> : IGrammarExpression<TResult>
    {
        public And(IGrammarExpression<TResult> operand)
        {
            Operand = operand;
        }

        public IGrammarExpression<TResult> Operand { get; }
        public MayBe<IParseResult<TResult>> ParseAt(IParserVisitor visitor, int position)
        {
            return visitor.Visit_And(position, this);
        }
    }
}

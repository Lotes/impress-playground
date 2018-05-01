namespace Compiler.Core.Expression
{
    public class Not<TResult> : IGrammarExpression<TResult>
    {
        public Not(IGrammarExpression<TResult> operand)
        {
            Operand = operand;
        }

        public IGrammarExpression<TResult> Operand { get; }

        public MayBe<IParseResult<TResult>> ParseAt(IParserVisitor visitor, int position)
        {
            return visitor.Visit_Not(position, this);
        }
    }
}

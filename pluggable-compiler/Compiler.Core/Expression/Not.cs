namespace Compiler.Core.Expression
{
    public class Not<TResult, TOperand> : IGrammarExpression<TResult>
    {
        public Not(IGrammarExpression<TOperand> operand)
        {
            Operand = operand;
        }

        public IGrammarExpression<TOperand> Operand { get; }

        public TResult Accept<S>(IVisitor<S> visitor, S state)
        {
            return visitor.Visit_Not(state, this);
        }
    }
}

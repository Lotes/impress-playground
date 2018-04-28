namespace Compiler.Core.Expression
{
    public class And<TResult, TOperand> : IGrammarExpression<TResult>
    {
        public And(IGrammarExpression<TOperand> operand)
        {
            Operand = operand;
        }

        public IGrammarExpression<TOperand> Operand { get; }
        public TResult Accept<S>(IVisitor<S> visitor, S state)
        {
            return visitor.Visit_And(state, this);
        }
    }
}

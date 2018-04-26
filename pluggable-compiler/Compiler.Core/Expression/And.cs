namespace Compiler.Core.Expression
{
    public class And : IExpression
    {
        public And(IExpression operand)
        {
            Operand = operand;
        }

        public IExpression Operand { get; }
        public T Accept<T, S>(IVisitor<T, S> visitor, S state)
        {
            return visitor.Visit_And(state, this);
        }
    }
}

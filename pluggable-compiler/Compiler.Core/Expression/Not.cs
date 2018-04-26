namespace Compiler.Core.Expression
{
    public class Not : IExpression
    {
        public Not(IExpression operand)
        {
            Operand = operand;
        }

        public IExpression Operand { get; }

        public T Accept<T, S>(IVisitor<T, S> visitor, S state)
        {
            return visitor.Visit_Not(state, this);
        }
    }
}

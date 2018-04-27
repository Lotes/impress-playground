namespace Compiler.Core.Expression
{
    public class Not : IGrammarExpression
    {
        public Not(IGrammarExpression operand)
        {
            Operand = operand;
        }

        public IGrammarExpression Operand { get; }

        public T Accept<T, S>(IVisitor<T, S> visitor, S state)
        {
            return visitor.Visit_Not(state, this);
        }
    }
}

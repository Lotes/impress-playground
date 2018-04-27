namespace Compiler.Core.Expression
{
    public class And : IGrammarExpression
    {
        public And(IGrammarExpression operand)
        {
            Operand = operand;
        }

        public IGrammarExpression Operand { get; }
        public T Accept<T, S>(IVisitor<T, S> visitor, S state)
        {
            return visitor.Visit_And(state, this);
        }
    }
}

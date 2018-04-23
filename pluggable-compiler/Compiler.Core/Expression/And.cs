namespace Compiler.Core.Expression
{
    public class And : IExpression
    {
        public And(IExpression operand)
        {
            Operand = operand;
        }

        public IExpression Operand { get; }
        public T Accept<T>(IVisitor<T> visitor)
        {
            return visitor.Visit_And(this);
        }

        public bool Parse(IParserContext context, int position, out IParseResult result)
        {
            if (Operand.Parse(context, position, out result))
                return true;
            return false;
        }
    }
}

namespace Compiler.Core.Expression
{
    public class Not : IExpression
    {
        public Not(IExpression operand)
        {
            Operand = operand;
        }

        public IExpression Operand { get; }

        public T Accept<T>(IVisitor<T> visitor)
        {
            return visitor.Visit_Not(this);
        }

        public bool Parse(IParserContext context, int position, out IParseResult result)
        {
            if (Operand.Parse(context, position, out result))
                return false;
            return true;
        }
    }
}

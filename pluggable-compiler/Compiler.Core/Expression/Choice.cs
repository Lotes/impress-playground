using System.Collections.Generic;

namespace Compiler.Core.Expression
{
    public class Choice: IExpression
    {
        public Choice(IEnumerable<IExpression> choices)
        {
            Choices = choices;
        }

        public IEnumerable<IExpression> Choices { get; }

        public T Accept<T>(IVisitor<T> visitor)
        {
            return visitor.Visit_Choice(this);
        }

        public bool Parse(IParserContext context, int position, out IParseResult result)
        {
            foreach(var choice in Choices)
            {
                if (choice.Parse(context, position, out result))
                    return true;
            }
            result = null;
            return false;
        }
    }
}

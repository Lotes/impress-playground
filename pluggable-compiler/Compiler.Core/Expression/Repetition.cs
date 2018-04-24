using System;
using System.Collections.Generic;

namespace Compiler.Core.Expression
{
    public class Repetition: IExpression
    {
        public Repetition(IExpression expression, int minimum, int? maximum)
        {
            if (maximum != null && minimum > maximum.Value)
                throw new ArgumentException(nameof(maximum));
            Expression = expression;
            Minimum = minimum;
            Maximum = maximum;
        }

        public IExpression Expression { get; }
        public int Minimum { get; }
        public int? Maximum { get; }

        public T Accept<T>(IVisitor<T> visitor)
        {
            return visitor.Visit_Repetition(this);
        }

        public bool Parse(IParserContext context, int position, out IParseResult result)
        {
            var children = new LinkedList<IParseResult>();
            var end = position;
            int start = position;
            IParseResult itResult;
            for(var index=1; index<=Minimum; index++)
            {
                if(!Expression.Parse(context, end, out itResult))
                {
                    result = null;
                    return false;
                }
                children.AddLast(itResult);
                end += itResult.GetLength();
            }
            if(Maximum != null)
            {
                int index;
                for (index = Minimum; index <= Maximum.Value; index++)
                {
                    if (Expression.Parse(context, end, out itResult))
                    {
                        end += itResult.GetLength();
                        children.AddLast(itResult);
                    }
                    else
                        break;
                }
                if (index <= Maximum.Value)
                {
                    result = new ParseResult(this, context, start, end, children);
                    return true;
                }
                else
                {
                    result = null;
                    return false;
                }
            }
            else
            {
                while (Expression.Parse(context, end, out itResult))
                {
                    end += itResult.GetLength();
                    children.AddLast(itResult);
                }
                result = new ParseResult(this, context, start, end, children);
                return true;
            }
        }
    }
}

using Compiler.Core.Chars;

namespace Compiler.Core.Expression
{
    public class CharacterClass: IExpression
    {
        public CharacterClass(ICharSet charSet)
        {
            CharSet = charSet;
        }

        public ICharSet CharSet { get; }
        public T Accept<T>(IVisitor<T> visitor)
        {
            return visitor.Visit_CharacterClass(this);
        }

        public bool Parse(IParserContext context, int position, out IParseResult result)
        {
            if(CharSet.Length == 0)
            {
                result = new ParseResult(this, context, position, position-1, new IParseResult[0]);
                return true;
            }
            try
            {
                var character = context.Input[position];
                if (CharSet.Includes(character))
                {
                    result = new ParseResult(this, context, position, position, new IParseResult[0]);
                    return true;
                }
                result = null;
                return false;
            }
            catch
            {
                result = null;
                return false;
            }
            
        }
    }
}

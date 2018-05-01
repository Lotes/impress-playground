using Compiler.Core.Chars;

namespace Compiler.Core.Expression
{
    public class CharacterClass : IGrammarExpression<string>
    {
        public CharacterClass(ICharSet charSet)
        {
            CharSet = charSet;
        }

        public ICharSet CharSet { get; }

        public MayBe<IParseResult<string>> ParseAt(IParserVisitor visitor, int position)
        {
            return visitor.Visit_CharacterClass(position, this);
        }
    }
}

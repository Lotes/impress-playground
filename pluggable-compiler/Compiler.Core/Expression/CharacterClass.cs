using Compiler.Core.Chars;

namespace Compiler.Core.Expression
{
    public class CharacterClass: IGrammarExpression
    {
        public CharacterClass(ICharSet charSet)
        {
            CharSet = charSet;
        }

        public ICharSet CharSet { get; }
        public T Accept<T, S>(IVisitor<T, S> visitor, S state)
        {
            return visitor.Visit_CharacterClass(state, this);
        }
    }
}

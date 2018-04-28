using Compiler.Core.Chars;

namespace Compiler.Core.Expression
{
    public class CharacterClass<TResult> : IGrammarExpression<TResult>
    {
        public CharacterClass(ICharSet charSet)
        {
            CharSet = charSet;
        }

        public ICharSet CharSet { get; }
        public TResult Accept<S>(IVisitor<S> visitor, S state)
        {
            return visitor.Visit_CharacterClass(state, this);
        }
    }
}

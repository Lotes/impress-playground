using Compiler.Core.Expression;

namespace Compiler.Core.Engine.Builder
{
    public class BinaryOperator : ILexicalDefinition
    {
        public BinaryOperator(IPartialGrammar partialGrammar, int priority)
        {
            Priority = priority;
            PartialGrammar = partialGrammar;
        }

        public int Priority { get; }
        public IPartialGrammar PartialGrammar { get; }
    }
}
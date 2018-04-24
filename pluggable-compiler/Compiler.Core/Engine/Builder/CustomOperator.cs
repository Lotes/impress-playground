using Compiler.Core.Expression;

namespace Compiler.Core.Engine.Builder
{
    public class CustomOperator : ILexicalDefinition
    {
        public CustomOperator(IPartialGrammar partialGrammar, int priority)
        {
            PartialGrammar = partialGrammar;
            Priority = priority;
        }

        public IPartialGrammar PartialGrammar { get; }
        public int Priority { get; }
    }
}
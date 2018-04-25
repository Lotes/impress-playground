using Compiler.Core.Expression;

namespace Compiler.Core.Engine.Builder
{
    public class CustomOperator : ILexicalDefinition
    {
        public CustomOperator(IGrammar partialGrammar, int priority)
        {
            PartialGrammar = partialGrammar;
            Priority = priority;
        }

        public IGrammar PartialGrammar { get; }
        public int Priority { get; }
    }
}
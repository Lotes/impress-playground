using Compiler.Core.Expression;

namespace Compiler.Core.Engine
{
    public class WhiteSpace: ILexicalDefinition
    {
        public WhiteSpace(IGrammar partialGrammar, int priority)
        {
            Priority = priority;
            PartialGrammar = partialGrammar;
        }

        public int Priority { get; }
        public IGrammar PartialGrammar { get; }
    }
}
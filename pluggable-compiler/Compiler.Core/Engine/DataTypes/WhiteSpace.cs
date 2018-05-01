using Compiler.Core.Expression;

namespace Compiler.Core.Engine
{
    public class WhiteSpace: ILexicalDefinition<string>
    {
        public WhiteSpace(IGrammar<string> partialGrammar, int priority)
        {
            Priority = priority;
            PartialGrammar = partialGrammar;
        }

        public int Priority { get; }
        public IGrammar<string> PartialGrammar { get; }
    }
}
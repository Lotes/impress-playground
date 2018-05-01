using Compiler.Core.Expression;

namespace Compiler.Core.Engine
{
    public class UnaryOperator : ILexicalDefinition<string>
    {
        public UnaryOperator(IGrammar<string> partialGrammar, int priority, Associativity associativity)
        {
            PartialGrammar = partialGrammar;
            Priority = priority;
            Associativity = associativity;
        }

        public IGrammar<string> PartialGrammar { get; }
        public int Priority { get; }
        public Associativity Associativity { get; }
    }
}
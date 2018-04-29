using Compiler.Core.Expression;

namespace Compiler.Core.Engine
{
    public class UnaryOperator : ILexicalDefinition
    {
        public UnaryOperator(IGrammar partialGrammar, int priority, Associativity associativity)
        {
            PartialGrammar = partialGrammar;
            Priority = priority;
            Associativity = associativity;
        }

        public IGrammar PartialGrammar { get; }
        public int Priority { get; }
        public Associativity Associativity { get; }
    }
}
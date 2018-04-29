using Compiler.Core.Expression;

namespace Compiler.Core.Engine
{
    public class BinaryOperator : ILexicalDefinition
    {
        public BinaryOperator(IGrammar partialGrammar, int priority, Associativity associativity)
        {
            Priority = priority;
            PartialGrammar = partialGrammar;
            Associativity = associativity;
        }

        public int Priority { get; }
        public IGrammar PartialGrammar { get; }
        public Associativity Associativity { get; }
    }
}
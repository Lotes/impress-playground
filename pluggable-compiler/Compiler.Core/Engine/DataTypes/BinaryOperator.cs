using Compiler.Core.Expression;

namespace Compiler.Core.Engine
{
    public class BinaryOperator : ILexicalDefinition<string>
    {
        public BinaryOperator(IGrammar<string> partialGrammar, int priority, Associativity associativity)
        {
            Priority = priority;
            PartialGrammar = partialGrammar;
            Associativity = associativity;
        }

        public int Priority { get; }
        public IGrammar<string> PartialGrammar { get; }
        public Associativity Associativity { get; }
    }
}
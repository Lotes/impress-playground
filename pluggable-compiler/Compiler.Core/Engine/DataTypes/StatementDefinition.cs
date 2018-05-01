using Compiler.Core.Expression;
using System;

namespace Compiler.Core.Engine
{
    public class StatementDefinition : ILexicalDefinition<IStatement>
    {
        public StatementDefinition(IGrammar<IStatement> partialGrammar, int priority)
        {
            PartialGrammar = partialGrammar;
            Priority = priority;
        }

        public IGrammar<IStatement> PartialGrammar { get; }
        public int Priority { get; }
    }
}
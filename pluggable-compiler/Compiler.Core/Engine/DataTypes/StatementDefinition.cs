using Compiler.Core.Expression;
using System;

namespace Compiler.Core.Engine
{
    public class StatementDefinition : ILexicalDefinition
    {
        public StatementDefinition(IGrammar partialGrammar, Func<IParseResult, IStatement> toStatement, int priority)
        {
            PartialGrammar = partialGrammar;
            ToStatement = toStatement;
            Priority = priority;
        }

        public IGrammar PartialGrammar { get; }
        public Func<IParseResult, IStatement> ToStatement { get; }
        public int Priority { get; }
    }
}
using Compiler.Core.Expression;
using System;

namespace Compiler.Core.Engine
{
    public class LiteralDefinition: ILexicalDefinition<IExpression>
    {
        public LiteralDefinition(IGrammar<IExpression> grammar, int priority)
        {
            PartialGrammar = grammar;
            Priority = priority;
        }

        public IGrammar<IExpression> PartialGrammar { get; }
        public int Priority { get; }
    }
}
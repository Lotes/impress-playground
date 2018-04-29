using Compiler.Core.Expression;
using System;

namespace Compiler.Core.Engine
{
    public class ExpressionDefinition: ILexicalDefinition
    {
        public ExpressionDefinition(IGrammar grammar, Func<IParseResult, IExpression> toExpression, int priority)
        {
            PartialGrammar = grammar;
            ToExpression = toExpression;
            Priority = priority;
        }

        public IGrammar PartialGrammar { get; }
        public Func<IParseResult, IExpression> ToExpression { get; }
        public int Priority { get; }
    }
}
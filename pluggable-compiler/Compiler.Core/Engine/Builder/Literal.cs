using System;

namespace Compiler.Core.Engine.Builder
{
    public class Literal: ILexicalDefinition
    {
        private Func<string, IExpression> convert;

        public Literal(IPartialGrammar partialGrammar, Func<string, IExpression> convert, int priority)
        {
            this.convert = convert;
            PartialGrammar = partialGrammar;
            Priority = priority;
        }

        public IPartialGrammar PartialGrammar { get; }
        public int Priority { get; }
    }
}

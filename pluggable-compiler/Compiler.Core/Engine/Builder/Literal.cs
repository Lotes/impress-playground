using Compiler.Core.Expression;
using System;

namespace Compiler.Core.Engine.Builder
{
    public class Literal: ILexicalDefinition
    {
        private Func<IParseResult, IExpression> convert;

        public Literal(IPartialGrammar partialGrammar, Func<IParseResult, IExpression> convert, int priority)
        {
            this.convert = convert;
            PartialGrammar = partialGrammar;
            Priority = priority;
        }

        public IPartialGrammar PartialGrammar { get; }
        public int Priority { get; }
        public IExpression FromString(IParseResult input)
        {
            return convert(input);
        }
    }
}

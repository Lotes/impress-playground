using Compiler.Core.Expression;
using System;

namespace Compiler.Core.Engine
{
    public class Literal: ILexicalDefinition
    {
        private Func<IParseResult, IExpression> convert;

        public Literal(IGrammar partialGrammar, Func<IParseResult, IExpression> convert, int priority)
        {
            this.convert = convert;
            PartialGrammar = partialGrammar;
            Priority = priority;
        }

        public IGrammar PartialGrammar { get; }
        public int Priority { get; }
        public IExpression FromString(IParseResult input)
        {
            return convert(input);
        }
    }
}

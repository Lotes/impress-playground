using System.Collections.Generic;

namespace Compiler.Core.Expression
{
    public interface IParseResult
    {
        IExpression Expression { get; }
        IParserContext Context { get; }
        ICursor Start { get; }
        ICursor End { get; }
        IReadOnlyList<IParseResult> Children { get; }
    }
}
using System.Collections.Generic;

namespace Compiler.Core.Expression
{
    public interface IParseResult
    {
        IParserContext Context { get; }
        ICursor Start { get; }
        ICursor End { get; }
        IReadOnlyList<IParseResult> Children { get; }
    }

    public interface IParseResult<TResult>: IParseResult
    {
        IGrammarExpression<TResult> Expression { get; }
        TResult Result { get; }
    }
}
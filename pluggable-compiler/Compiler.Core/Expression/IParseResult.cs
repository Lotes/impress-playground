﻿using System.Collections.Generic;

namespace Compiler.Core.Expression
{
    public interface IParseResult
    {
        IGrammarExpression Expression { get; }
        IParserContext Context { get; }
        ICursor Start { get; }
        ICursor End { get; }
        IReadOnlyList<IParseResult> Children { get; }
    }

    public interface IParseResult<T>: IParseResult
    {
        T Value { get; }
    }
}
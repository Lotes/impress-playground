using System.Collections.Generic;

namespace Compiler.Core.Expression
{
    public interface IGrammar
    {
        IRule Start { get; }
        IReadOnlyDictionary<string, IRule> Rules { get; }
    }
}
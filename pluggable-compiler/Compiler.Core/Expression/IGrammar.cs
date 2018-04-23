using System.Collections.Generic;

namespace Compiler.Core.Expression
{
    public interface IGrammar
    {
        IRule StartingRule { get; }
        IEnumerable<IRule> Rules { get; }
    }
}
using System.Collections.Generic;

namespace Compiler.Core.Expression
{
    public interface IGrammar<TStart>: IGrammar
    {
        new IRule<TStart> StartingRule { get; }
    }

    public interface IGrammar
    {
        IRule StartingRule { get; }
        IEnumerable<IRule> Rules { get; }
    }
}
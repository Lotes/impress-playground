using Compiler.Core.Expression;
using System.Collections.Generic;

namespace Compiler.Core.Engine.Builder
{
    public interface IPartialGrammar
    {
        IEnumerable<IRule> Rules { get; }
        IRule StartingRule { get; }
    }
}

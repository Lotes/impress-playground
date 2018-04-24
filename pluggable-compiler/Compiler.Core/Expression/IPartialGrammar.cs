using Compiler.Core.Expression;
using System.Collections.Generic;

namespace Compiler.Core.Expression
{
    public interface IPartialGrammar
    {
        IGrammar Parent { get; }
        IEnumerable<IRule> Rules { get; }
        IRule StartingRule { get; }
    }
}

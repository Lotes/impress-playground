using Compiler.Core.Expression;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Core.Engine
{
    public interface ILexicalDefinition<TResult>
    {
        IGrammar<TResult> PartialGrammar { get; }
        int Priority { get; }
    }
}

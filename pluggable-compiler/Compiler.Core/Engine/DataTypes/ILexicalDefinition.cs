using Compiler.Core.Expression;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Core.Engine
{
    public interface ILexicalDefinition
    {
        IGrammar PartialGrammar { get; }
        int Priority { get; }
    }
}

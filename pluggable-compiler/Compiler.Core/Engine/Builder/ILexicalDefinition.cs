using Compiler.Core.Expression;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Core.Engine.Builder
{
    public interface ILexicalDefinition
    {
        IPartialGrammar PartialGrammar { get; }
        int Priority { get; }
    }
}

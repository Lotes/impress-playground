using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Core.Expression
{
    public interface IGrammarExpression
    {
        TResult Accept<TResult, TState>(IVisitor<TResult, TState> visitor, TState state);
    }
}

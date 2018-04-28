using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Core.Expression
{
    public interface IGrammarExpression<TResult>
    {
        TResult Accept<TState>(IVisitor<TState> visitor, TState state);
    }
}

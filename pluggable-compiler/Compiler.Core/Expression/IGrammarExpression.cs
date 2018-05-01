using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Core.Expression
{
    public interface IGrammarExpression<TResult>
    {
        MayBe<IParseResult<TResult>> ParseAt(IParserVisitor visitor, int position);
    }
}

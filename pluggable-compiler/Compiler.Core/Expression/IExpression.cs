using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Core.Expression
{
    public interface IExpression
    {
        bool Parse(IParserContext context, int position, out IParseResult result);
        T Accept<T>(IVisitor<T> visitor);
    }
}

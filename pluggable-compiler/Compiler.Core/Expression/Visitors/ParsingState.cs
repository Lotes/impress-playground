using System.Text;
using System.Threading.Tasks;

namespace Compiler.Core.Expression.Visitors
{
    public class ParsingState
    {
        public readonly bool Ok;
        public readonly IParseResult Result;

        public ParsingState(bool ok, IParseResult result)
        {
            Ok = ok;
            Result = result;
        }
    }
}

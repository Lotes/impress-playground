using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Core.Expression
{
    public interface IExpressionParser
    {
        IParseResult Parse(IGrammar expression, string input);
    }
}

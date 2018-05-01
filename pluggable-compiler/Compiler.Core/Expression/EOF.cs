using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Core.Expression
{
    public class EOF : IGrammarExpression<string>
    {
        public MayBe<IParseResult<string>> ParseAt(IParserVisitor visitor, int position)
        {
            return visitor.Visit_EOF(position, this);
        }
    }
}

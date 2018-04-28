using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Core.Expression
{
    public class ExpressionParser : IExpressionParser
    {
        public IParseResult Parse(IGrammar grammar, string input)
        {
            var visitor = new ParsingVisitor(new ParserContext(input, grammar));
            var state = grammar.StartingRule.Expression.Accept(visitor, 0);
            if (!state.Ok)
                throw new InvalidOperationException("Parse error!");
            return state.Result;
        }
    }
}

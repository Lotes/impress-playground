using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Core.Expression
{
    public delegate MayBe<IParseResult<TResult>> HookingDelegate<TResult>(IParserContext context, int position);
    public class Hook<TResult> : IGrammarExpression<TResult>
    {
        public Hook(HookingDelegate<TResult> callback)
        {
            Callback = callback;
        }
        public HookingDelegate<TResult> Callback { get; }
        public MayBe<IParseResult<TResult>> ParseAt(IParserVisitor visitor, int position)
        {
            return visitor.Visit_Hook<TResult>(position, this);
        }
    }
}

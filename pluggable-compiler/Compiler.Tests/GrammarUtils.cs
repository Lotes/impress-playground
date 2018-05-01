using Compiler.Core;
using Compiler.Core.Expression;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Tests
{
    public static class GrammarUtils
    {
        public static void Accepts<TResult>(this IGrammar<TResult> @this, string str)
        {
            var ok = @this.Parse(str, out IParseResult<TResult> result);
            Assert.IsTrue(ok);
        }

        public static void Rejects<TResult>(this IGrammar<TResult> @this, string str)
        {
            var ok = @this.Parse(str, out IParseResult<TResult> result);
            Assert.IsFalse(ok);
        }

        private static bool Parse<TResult>(this IGrammar<TResult> @this, string str, out IParseResult<TResult> result)
        {
            result = null;
            var context = new ParserContext(str, @this);
            var visitor = new ParserVisitor(context);
            try
            {
                var answer = @this.StartingRule.Expression.ParseAt(visitor, 0);
                if (answer == MayBe<IParseResult<TResult>>.Nothing)
                    return false;
                result = answer.Value;
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }
    }
}

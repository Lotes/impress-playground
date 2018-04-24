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
        public static void Accepts(this IGrammar @this, string str)
        {
            var context = new ParserContext(str, @this);
            IParseResult result;
            var ok = @this.StartingRule.Expression.Parse(context, 0, out result);
            Assert.IsTrue(ok);
        }

        public static void Rejects(this IGrammar @this, string str)
        {
            var context = new ParserContext(str, @this);
            IParseResult result;
            var ok = @this.StartingRule.Expression.Parse(context, 0, out result);
            Assert.IsFalse(ok);
        }
    }
}

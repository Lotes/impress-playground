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
            var ok = @this.Parse(str, out IParseResult result);
            Assert.IsTrue(ok);
        }

        public static void Rejects(this IGrammar @this, string str)
        {
            var ok = @this.Parse(str, out IParseResult result);
            Assert.IsFalse(ok);
        }

        private static bool Parse(this IGrammar @this, string str, out IParseResult result)
        {
            var parser = new ExpressionParser();
            try
            {
                result = parser.Parse(@this, str);
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

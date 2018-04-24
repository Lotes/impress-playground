using System;
using Compiler.Core.Expression;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Compiler.Tests
{
    [TestClass]
    public class ExpressionTests
    {
        [TestMethod]
        public void TestSequence()
        {
            IRule rule;
            var grammar = Grammars.New()
                .NewRule(Expressions.Sequence("hello"), out rule)
                .Build();
            grammar.Accepts("hello");
            grammar.Rejects("hallo");
            grammar.Rejects("");
        }
    }
}

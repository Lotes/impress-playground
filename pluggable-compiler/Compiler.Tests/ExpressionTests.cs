using System;
using Compiler.Core.Expression;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Compiler.Tests
{
    [TestClass]
    public class ExpressionTests
    {
        [TestMethod]
        public void SequenceString()
        {
            var grammar = Grammars.New()
                .NewRule(Expressions.Sequence("hello"), "start", out IRule rule)
                .Build(rule);
            grammar.Accepts("hello");
            grammar.Rejects("hallo");
            grammar.Rejects("");
        }

        [TestMethod]
        public void Choice()
        {
            var grammar = Grammars.New()
                .NewRule(Expressions.Choice(
                    Expressions.Sequence("hello"), 
                    Expressions.Sequence("bonjour")
                ), "start", out IRule rule)
                .Build(rule);
            grammar.Accepts("hello");
            grammar.Accepts("bonjour");
            grammar.Rejects("hallo");
            grammar.Rejects("");
        }

        [TestMethod]
        public void Call()
        {
            var grammar = Grammars.New()
                .NewRule(Expressions.Epsilon, "start", out IRule rule)
                .RedefineRule(rule, Expressions.Choice(
                    Expressions.Sequence(Expressions.Sequence("aa"), Expressions.Call(rule)),
                    Expressions.Sequence("aa")
                ))
                .Build(rule);
            grammar.Accepts("aa");
            grammar.Accepts("aaaa");
            grammar.Accepts("aaaaaa");
            grammar.Rejects("a");
            grammar.Rejects("aaa");
            grammar.Rejects("");
        }
    }
}

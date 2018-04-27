using System;
using Compiler.Core.Expression;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Compiler.Tests
{
    [TestClass]
    public class GrammarExpressionTests
    {
        [TestMethod]
        public void Sequence()
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

        [TestMethod]
        public void Repetition()
        {
            var grammar = Grammars.New()
                .NewRule(Expressions.Repeat(Expressions.Sequence("aa"), 1, 2), "start", out IRule rule)
                .Build(rule);
            grammar.Rejects("aaa");
            grammar.Accepts("aa");
            grammar.Accepts("aaaa");
            grammar.Rejects("aaaaaa");
            grammar.Rejects("a");
            grammar.Rejects("");
        }

        [TestMethod]
        public void EOF()
        {
            var grammar = Grammars.New()
                .NewRule(Expressions.EOF, "start", out IRule rule)
                .Build(rule);
            grammar.Rejects("a");
            grammar.Accepts("");
        }
    }
}

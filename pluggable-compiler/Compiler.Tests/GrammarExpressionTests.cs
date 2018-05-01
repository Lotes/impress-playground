using System;
using System.Linq;
using Compiler.Core.Expression;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Compiler.Tests
{
    using static Expressions;

    [TestClass]
    public class GrammarExpressionTests
    {
        [TestMethod]
        public void StringTest()
        {
            var grammar = New()
                .NewRule("start", String("hello"), out IRule<string> rule)
                .Build(rule);
            grammar.Accepts("hello");
            grammar.Rejects("hallo");
            grammar.Rejects("");
        }

        [TestMethod]
        public void ChoiceTest()
        {
            var grammar = New()
                .NewRule("start", Choice(
                    String("hello"), 
                    String("bonjour")
                ), out IRule<string> rule)
                .Build(rule);
            grammar.Accepts("hello");
            grammar.Accepts("bonjour");
            grammar.Rejects("hallo");
            grammar.Rejects("");
        }

        [TestMethod]
        public void CallTest()
        {
            var grammar = New()
                .NewRule("start", Epsilon, out IRule<string> rule)
                .RedefineRule(rule, Choice(
                    String("aa").Then(Call(rule)).Returns(string.Concat),
                    String("aa")
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
            var grammar = New()
                .NewRule("start", Repeat(String("aa"), 1, 2).Returns(list => string.Concat(list.ToArray())), out IRule<string> rule)
                .Build(rule);
            grammar.Rejects("aaa");
            grammar.Accepts("aa");
            grammar.Accepts("aaaa");
            grammar.Rejects("aaaaaa");
            grammar.Rejects("a");
            grammar.Rejects("");
        }

        [TestMethod]
        public void EOFTest()
        {
            var grammar = New()
                .NewRule("start", EOF, out IRule<string> rule)
                .Build(rule);
            grammar.Rejects("a");
            grammar.Accepts("");
        }
    }
}

using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Compiler.Core.Engine;
using Compiler.Core.Expression;
using Compiler.Core.Chars;

namespace Compiler.Tests
{
    using static Expressions;

    [TestClass]
    public class EngineTests
    {
        [TestMethod]
        public void AddingLanguage()
        {
            IParserBuilder builder = new ParserBuilder();
            var opBinaryPlus = builder
                .AddBinaryOperator(g => 
                    g.NewRule("+",
                        Char('+'), out IRule<string> plusOperator
                    ).Build(plusOperator), Associativity.Left, 
                    20
                );
            builder
                .AddExpressionDefinition(g =>
                    g
                        .NewRule("Digit", Range('0', '9'), out IRule<string> digit)
                        .NewRule("Number", 
                            OneOrMore(Call(digit)).Concat()
                            .Then(
                                Optional(Char('.').Then(OneOrMore(Call(digit)).Concat()).Concat()).Concat()
                            )
                            .Concat()
                            .Returns(str => (IExpression)new LiteralExpression(typeof(double), double.Parse(str))), 
                            out IRule<IExpression> number
                        )
                        .Build(number),
                    20
                );
            builder
                .AddExpressionDefinition(g =>
                    g.NewRule("Parentheses", 
                        Sequence(
                            Char('('), 
                            Call(g.WhiteSpaceZeroOrMore), 
                            Call(g.Expression), 
                            Call(g.WhiteSpaceZeroOrMore), 
                            Char(')')
                        ).Returns(tuple => tuple.Item3), out IRule<IExpression> parenthesesRule)
                     .Build(parenthesesRule),
                    10000
                );
            builder
                .AddWhiteSpaceDefinition(g => 
                    g
                        .NewRule("\\s", Chars('\n', '\r', '\t', ' '), out IRule<string> wsRule)
                        .Build(wsRule)
                );
            builder.AddBinaryOperation<double, double, double>(opBinaryPlus, (a, b) => a + b);
            var parser = builder.Build();
            Assert.AreEqual(33, parser.ParseExpression("10 + 23").Evaluate(null));
        }
    }
}

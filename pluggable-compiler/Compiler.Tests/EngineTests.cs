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
                        Sequence("+"), out IRule plusOperator
                    ).Build(plusOperator), Associativity.Left, 20
                );
            builder
                .AddExpressionDefinition(g =>
                    g.NewRule("Digit", CharacterClass(new CharRange('0', '9')), out IRule digit)
                     .NewRule("Number", OneOrMore(Call(digit)).Then(Optional(Char('.').Then(OneOrMore(Call(digit))))), out IRule number)
                     .Build(number),
                    result => new LiteralExpression(typeof(double), double.Parse(result.GetContent()))
                );
            builder.AddBinaryOperation<double, double, double>(opBinaryPlus, (a, b) => a + b);
            var parser = builder.Build();
            Assert.AreEqual(33, parser.ParseExpression("10+23").Evaluate(null));
        }
    }
}

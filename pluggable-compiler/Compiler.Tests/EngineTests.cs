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
            IParserBuilder builder = new ParserBuilder(null);
            var opBinaryPlus = builder
                .AddBinaryOperator(g => 
                    g.NewRule(
                        Sequence("+"), "+", out IRule plusOperator
                    ).Build(plusOperator), Associativity.Left, 20
                );
            builder
                .AddExpression(g =>
                    g.NewRule(CharacterClass(new CharRange('0', '9')), "Digit", out IRule digit)
                     .NewRule(OneOrMore(Call(digit)).Then(Optional(Char('.').Then(OneOrMore(Call(digit))))), "number", out IRule number)
                     .Build(number),
                    result => new LiteralExpression(typeof(double), double.Parse(result.GetContent()))
                );
            builder.AddBinaryOperation<double, double, double>(opBinaryPlus, (a, b) => a + b);
            var parser = builder.Build();
            Assert.AreEqual(3, parser.ParseExpression("1+2").Evaluate(null));
        }
    }
}

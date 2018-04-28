using Compiler.Core.Expression;
using System;

namespace Compiler.Core.Engine
{
    public class ParserBuilder : IParserBuilder
    {
        private ToolKit kit = new ToolKit();
        private IGrammarBuilder grammarBuilder;

        public ParserBuilder(IGrammarBuilder grammarBuilder)
        {
            this.grammarBuilder = grammarBuilder;
        }

        public void AddBinaryOperation<TLeft, TRight>(BinaryOperator op, Func<IExpression, IExpression, IExpression> definition, int priority = 0)
        {
            
        }

        public void AddBinaryOperator(Func<IGrammarBuilder, IGrammar> generateGrammar, int priority = 0)
        {
            var op = new BinaryOperator(generateGrammar(grammarBuilder), priority);
            kit.BinaryOperators.Add(op);
        }

        public void AddCoercion<TSource, TTarget>(CoercionType type, Func<TSource, TTarget> convert)
        {
            
        }

        public void AddCustomExpression(Func<IGrammarBuilder, IGrammar> generateGrammar, Func<IParseResult, IExpression> definition)
        {
            
        }

        public void AddLiteralDefinition(Func<IGrammarBuilder, IGrammar> generateGrammar, Func<IParseResult, IExpression> toTarget, int priority = 0)
        {
            var grammar = generateGrammar(grammarBuilder);
            var literal = new Literal(grammar, toTarget, priority);
            kit.Literals.Add(literal);
        }

        public void AddStatementDefintion(Func<IGrammarBuilder, IGrammar> generateGrammar, Func<IParseResult, IStatement> toStatement, int priority = 0)
        {
            
        }

        public void AddUnaryOperation<TOperand>(IUnaryOperator op, Func<IExpression, IExpression> definition, int priority = 0)
        {
            
        }

        public void AddUnaryOperator(Func<IGrammarBuilder, IGrammar> generateGrammar, int priority = 0)
        {
            
        }

        public void AddWhiteSpace(Func<IGrammarBuilder, IGrammar> generateGrammar, int priority = 0)
        {
            kit.WhiteSpaces.Add(new WhiteSpace(generateGrammar(grammarBuilder), priority));
        }

        public IParser Build()
        {
            return new Parser(kit);
        }
    }
}

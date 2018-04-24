using Compiler.Core.Expression;
using System;

namespace Compiler.Core.Engine.Builder
{
    public class ParserBuilder : IParserBuilder
    {
        private ToolKit kit = new ToolKit();
        private IPartialGrammarBuilder grammarBuilder;

        public ParserBuilder(IPartialGrammarBuilder grammarBuilder)
        {
            this.grammarBuilder = grammarBuilder;
        }

        public void AddBinaryOperation<TLeft, TRight>(BinaryOperator op, Func<IExpression, IExpression, IExpression> definition, int priority = 0)
        {
            
        }

        public void AddBinaryOperator(Func<IPartialGrammarBuilder, IPartialGrammar> generateGrammar, int priority = 0)
        {
            var op = new BinaryOperator(generateGrammar(grammarBuilder), priority);
            kit.BinaryOperators.Add(op);
        }

        public void AddCoercion<TSource, TTarget>(CoercionType type, Func<TSource, TTarget> convert)
        {
            
        }

        public void AddCustomExpression(Func<IPartialGrammarBuilder, IPartialGrammar> generateGrammar, Func<IParseResult, IExpression> definition)
        {
            
        }

        public void AddLiteralDefinition(Func<IPartialGrammarBuilder, IPartialGrammar> generateGrammar, Func<IParseResult, IExpression> toTarget, int priority = 0)
        {
            var grammar = generateGrammar(grammarBuilder);
            var literal = new Literal(grammar, toTarget, priority);
            kit.Literals.Add(literal);
        }

        public void AddStatementDefintion(Func<IPartialGrammarBuilder, IPartialGrammar> generateGrammar, Func<IParseResult, IStatement> toStatement, int priority = 0)
        {
            
        }

        public void AddUnaryOperation<TOperand>(IUnaryOperator op, Func<IExpression, IExpression> definition, int priority = 0)
        {
            
        }

        public void AddUnaryOperator(Func<IPartialGrammarBuilder, IPartialGrammar> generateGrammar, int priority = 0)
        {
            
        }

        public void AddWhiteSpace(Func<IPartialGrammarBuilder, IPartialGrammar> generateGrammar, int priority = 0)
        {
            kit.WhiteSpaces.Add(new WhiteSpace(generateGrammar(grammarBuilder), priority));
        }

        public IParser Build()
        {
            return new Parser(kit);
        }
    }
}

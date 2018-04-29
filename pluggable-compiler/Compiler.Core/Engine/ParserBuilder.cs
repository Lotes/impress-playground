using Compiler.Core.Expression;
using System;
using System.Collections.Generic;

namespace Compiler.Core.Engine
{
    public partial class ParserBuilder : IParserBuilder
    {
        //placeholder rules
        private Rule expression = new Rule(Expressions.Epsilon, "Expression");
        private Rule statement = new Rule(Expressions.Epsilon, "Statement");
        private Rule whiteSpaceZero = new Rule(Expressions.Epsilon, "_");
        private Rule whiteSpaceOne = new Rule(Expressions.Epsilon, "__");

        //parser part collections
        private ICollection<BinaryOperator> binaryOperators = new HashSet<BinaryOperator>();
        private ICollection<UnaryOperator> unaryOperators = new HashSet<UnaryOperator>();
        private ICollection<IBinaryOperation> binaryOperation = new HashSet<IBinaryOperation>();
        private ICollection<IUnaryOperation> unaryOperation = new HashSet<IUnaryOperation>();
        private ICollection<WhiteSpace> whiteSpaces = new HashSet<WhiteSpace>();
        private ICollection<ExpressionDefinition> expressionDefinitions = new HashSet<ExpressionDefinition>();
        private ICollection<StatementDefinition> statementDefinitions = new HashSet<StatementDefinition>();

        public ParserBuilder()
        {
            
        }
        
        public BinaryOperator AddBinaryOperator(Func<PartialGrammarBuilder, IGrammar> generateGrammar, Associativity associativity, int priority = 0)
        {
            var partialBuilder = NewPartialGrammarBuilder();
            var op = new BinaryOperator(generateGrammar(partialBuilder), priority, associativity);
            binaryOperators.Add(op);
            return op;
        }

        public UnaryOperator AddUnaryOperator(Func<PartialGrammarBuilder, IGrammar> generateGrammar, Associativity associativity, int priority = 0)
        {
            var partialBuilder = NewPartialGrammarBuilder();
            var op = new UnaryOperator(generateGrammar(partialBuilder), priority, associativity);
            unaryOperators.Add(op);
            return op;
        }

        public void AddWhiteSpace(Func<PartialGrammarBuilder, IGrammar> generate, int priority = 0)
        {
            var partialBuilder = NewPartialGrammarBuilder();
            whiteSpaces.Add(new WhiteSpace(generate(partialBuilder), priority));
        }

        private PartialGrammarBuilder NewPartialGrammarBuilder()
        {
            return new PartialGrammarBuilder(expression, statement, whiteSpaceZero, whiteSpaceOne);
        }

        public void AddExpressionDefinition(Func<PartialGrammarBuilder, IGrammar> generate, Func<IParseResult, IExpression> definition, int priority)
        {
            var builder = NewPartialGrammarBuilder();
            var grammar = generate(builder);
            var result = new ExpressionDefinition(grammar, definition, priority);
            expressionDefinitions.Add(result);
        }

        public void AddStatementDefinition(Func<PartialGrammarBuilder, IGrammar> generate, Func<IParseResult, IStatement> toStatement, int priority = 0)
        {
            var builder = NewPartialGrammarBuilder();
            var grammar = generate(builder);
            var result = new StatementDefinition(grammar, toStatement, priority);
            statementDefinitions.Add(result);
        }

        public void AddBinaryOperation<TLeft, TRight, TResult>(BinaryOperator op, Func<TLeft, TRight, TResult> definition)
        {
                        
        }

        public void AddUnaryOperation<TOperand, TResult>(UnaryOperator op, Func<TOperand, TResult> definition)
        {
            
        }

        public void AddCoercion<TSource, TTarget>(CoercionType type, Func<TSource, TTarget> convert)
        {
            
        }

        public IParser Build()
        {
            return new Parser(null);
        }
    }
}

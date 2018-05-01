using Compiler.Core.Expression;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Compiler.Core.Engine
{
    using static Expressions;

    public partial class ParserBuilder : IParserBuilder
    {
        //placeholder rules
        private Rule<IExpression> expression = new Rule<IExpression>("Expression", Null<IExpression>());
        private Rule<IStatement> statement = new Rule<IStatement>("Statement", Null<IStatement>());
        private Rule<string> whiteSpaceZero = new Rule<string>("_", Null<string>());
        private Rule<string> whiteSpaceOne = new Rule<string>("__", Null<string>());

        //parser part collections
        private ICollection<BinaryOperator> binaryOperators = new HashSet<BinaryOperator>();
        private ICollection<UnaryOperator> unaryOperators = new HashSet<UnaryOperator>();
        private ICollection<WhiteSpace> whiteSpaces = new HashSet<WhiteSpace>();
        private ICollection<ExpressionDefinition> expressionDefinitions = new HashSet<ExpressionDefinition>();
        private ICollection<IBinaryOperation> binaryOperations = new HashSet<IBinaryOperation>();
        private ICollection<IUnaryOperation> unaryOperations = new HashSet<IUnaryOperation>();
        private ICollection<ICoercionOperation> coercionOperations = new HashSet<ICoercionOperation>();
        private ICollection<StatementDefinition> statementDefinitions = new HashSet<StatementDefinition>();

        public ParserBuilder()
        {
            
        }
        
        public BinaryOperator AddBinaryOperator(Func<PartialGrammarBuilder, IGrammar<string>> generateGrammar, Associativity associativity, int priority = 0)
        {
            var partialBuilder = NewPartialGrammarBuilder();
            var op = new BinaryOperator(generateGrammar(partialBuilder), priority, associativity);
            binaryOperators.Add(op);
            return op;
        }

        public UnaryOperator AddUnaryOperator(Func<PartialGrammarBuilder, IGrammar<string>> generateGrammar, Associativity associativity, int priority = 0)
        {
            var partialBuilder = NewPartialGrammarBuilder();
            var op = new UnaryOperator(generateGrammar(partialBuilder), priority, associativity);
            unaryOperators.Add(op);
            return op;
        }

        public void AddWhiteSpaceDefinition(Func<PartialGrammarBuilder, IGrammar<string>> generate, int priority = 0)
        {
            var partialBuilder = NewPartialGrammarBuilder();
            whiteSpaces.Add(new WhiteSpace(generate(partialBuilder), priority));
        }

        private PartialGrammarBuilder NewPartialGrammarBuilder()
        {
            return new PartialGrammarBuilder(expression, statement, whiteSpaceZero, whiteSpaceOne);
        }

        public void AddExpressionDefinition(Func<PartialGrammarBuilder, IGrammar<IExpression>> generate, int priority)
        {
            var builder = NewPartialGrammarBuilder();
            var grammar = generate(builder);
            var result = new ExpressionDefinition(grammar, priority);
            expressionDefinitions.Add(result);
        }

        public void AddStatementDefinition(Func<PartialGrammarBuilder, IGrammar<IStatement>> generate, int priority = 0)
        {
            var builder = NewPartialGrammarBuilder();
            var grammar = generate(builder);
            var result = new StatementDefinition(grammar, priority);
            statementDefinitions.Add(result);
        }

        public void AddBinaryOperation<TLeft, TRight, TResult>(BinaryOperator op, Func<TLeft, TRight, TResult> definition)
        {
            var binaryOperation = new BinaryOperation(op, typeof(TLeft), typeof(TRight), typeof(TResult), (lhs, rhs) => definition((TLeft)lhs, (TRight)rhs));
            binaryOperations.Add(binaryOperation);
        }

        public void AddUnaryOperation<TOperand, TResult>(UnaryOperator op, Func<TOperand, TResult> definition)
        {
            var unaryOperation = new UnaryOperation(op, typeof(TOperand), typeof(TResult), (operand) => definition((TOperand)operand));
            unaryOperations.Add(unaryOperation);
        }

        public void AddCoercion<TSource, TTarget>(CoercionType type, Func<TSource, TTarget> convert)
        {
            var operation = new CoercionOperation(typeof(TSource), typeof(TTarget), type, from => convert((TSource)from));
            coercionOperations.Add(operation);
        }

        public IParser Build()
        {
            var rules = new List<IRule>();

            //prepare whitespace rules
            var wsStarts = new List<IGrammarExpression<string>>(); 
            foreach(var ws in this.whiteSpaces.OrderBy(w => w.Priority))
            {
                rules.AddRange(ws.PartialGrammar.Rules);
                wsStarts.Add(Call<string>(ws.PartialGrammar.StartingRule));
            }
            whiteSpaceZero.Expression = ZeroOrMore(Choice(wsStarts.ToArray())).Returns(string.Concat);
            whiteSpaceOne.Expression = OneOrMore(Choice(wsStarts.ToArray())).Returns(string.Concat);
            rules.Add(whiteSpaceZero);
            rules.Add(whiteSpaceOne);
            
            

            return new Parser();
        }
    }
}

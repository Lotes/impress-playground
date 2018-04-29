using Compiler.Core.Expression;
using System;

namespace Compiler.Core.Engine
{
    public interface IParserBuilder
    {
        void AddStatementDefinition(Func<PartialGrammarBuilder, IGrammar> generate, Func<IParseResult, IStatement> toStatement, int priority = 0);
        UnaryOperator AddUnaryOperator(Func<PartialGrammarBuilder, IGrammar> generate, Associativity associtivity, int priority = 0);
        BinaryOperator AddBinaryOperator(Func<PartialGrammarBuilder, IGrammar> generate, Associativity associtivity, int priority = 0);
        void AddExpressionDefinition(Func<PartialGrammarBuilder, IGrammar> generate, Func<IParseResult, IExpression> definition, int priority = 0);
        void AddWhiteSpace(Func<PartialGrammarBuilder, IGrammar> generate, int priority = 0);

        void AddCoercion<TSource, TTarget>(CoercionType type, Func<TSource, TTarget> convert);
        void AddUnaryOperation<TOperand, TResult>(UnaryOperator op, Func<TOperand, TResult> definition);
        void AddBinaryOperation<TLeft, TRight, TResult>(BinaryOperator op, Func<TLeft, TRight, TResult> definition);
        
        IParser Build();
    }
}

using Compiler.Core.Expression;
using System;

namespace Compiler.Core.Engine
{
    public interface IParserBuilder
    {
        void AddStatementDefintion(Func<IGrammarBuilder, IGrammar> generateGrammar, Func<IParseResult, IStatement> toStatement, int priority = 0);
        UnaryOperator AddUnaryOperator(Func<IGrammarBuilder, IGrammar> generateGrammar, Associativity associtivity, int priority = 0);
        BinaryOperator AddBinaryOperator(Func<IGrammarBuilder, IGrammar> generateGrammar, Associativity associtivity, int priority = 0);
        void AddExpression(Func<IGrammarBuilder, IGrammar> generateGrammar, Func<IParseResult, IExpression> definition);
        void AddWhiteSpace(Func<IGrammarBuilder, IGrammar> generateGrammar, int priority = 0);

        void AddCoercion<TSource, TTarget>(CoercionType type, Func<TSource, TTarget> convert);
        void AddUnaryOperation<TOperand>(UnaryOperator op, Func<IExpression, IExpression> definition);
        void AddBinaryOperation<TLeft, TRight, TResult>(BinaryOperator op, Func<TLeft, TRight, TResult> definition);
        
        IParser Build();
    }
}

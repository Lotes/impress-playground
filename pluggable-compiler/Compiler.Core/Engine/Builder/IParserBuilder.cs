using Compiler.Core.Expression;
using System;

namespace Compiler.Core.Engine.Builder
{
    public interface IParserBuilder
    {
        void AddLiteralDefinition(Func<IPartialGrammarBuilder, IPartialGrammar> generateGrammar, Func<IParseResult, IExpression> toTarget, int priority = 0);
        void AddStatementDefintion(Func<IPartialGrammarBuilder, IPartialGrammar> generateGrammar, Func<IParseResult, IStatement> toStatement, int priority = 0);
        void AddUnaryOperator(Func<IPartialGrammarBuilder, IPartialGrammar> generateGrammar, int priority = 0);
        void AddBinaryOperator(Func<IPartialGrammarBuilder, IPartialGrammar> generateGrammar, int priority = 0);
        void AddCustomExpression(Func<IPartialGrammarBuilder, IPartialGrammar> generateGrammar, Func<IParseResult, IExpression> definition);
        void AddWhiteSpace(Func<IPartialGrammarBuilder, IPartialGrammar> generateGrammar, int priority = 0);

        void AddCoercion<TSource, TTarget>(CoercionType type, Func<TSource, TTarget> convert);
        void AddUnaryOperation<TOperand>(IUnaryOperator op, Func<IExpression, IExpression> definition, int priority = 0);
        void AddBinaryOperation<TLeft, TRight>(BinaryOperator op, Func<IExpression, IExpression, IExpression> definition, int priority = 0);
        
        IParser Build();
    }
}

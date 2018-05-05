using Compiler.Core.Expression;
using System;
using System.Collections.Generic;

namespace Compiler.Core.Engine
{
    public delegate IGrammar<T> PartialGrammarConstructor<T>(PartialGrammarBuilder builder);
    public delegate IExpression FoldExpressionsDelegate(IExpression beforeOperand, IEnumerable<IExpression> expressions, IExpression afterOperand);

    public interface IParserBuilder
    {
        void AddStatementDefinition(PartialGrammarConstructor<IStatement> generate, int priority = 0);
        void AddLiteralDefinition(PartialGrammarConstructor<IExpression> generate, int priority = 0);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="before">operand or operator? if operator, the first argument of the fold function is null!</param>
        /// <param name="open">opening parenthesis</param>
        /// <param name="next">separator, between resulting expressions, if null, no separator s expected!</param>
        /// <param name="close">closing parenthesis</param>
        /// <param name="after">operand or operator? if operator, the last argument of the fold function is null!</param>
        /// <param name="fold">arguments are front, inner and back operands, result is an expression</param>
        /// <param name="priority">parsing priority in the parentheses group</param>
        void AddParenthesesDefinition(
            ParserExpectation before, 
            PartialGrammarConstructor<string> open, 
            PartialGrammarConstructor<string> next, 
            PartialGrammarConstructor<string> close, 
            ParserExpectation after,
            FoldExpressionsDelegate fold, int priority = 0);
        void AddWhiteSpaceDefinition(PartialGrammarConstructor<string> generate, int priority = 0);

        UnaryOperator AddUnaryOperator(PartialGrammarConstructor<string> generate, Associativity associtivity, int priority = 0);
        BinaryOperator AddBinaryOperator(PartialGrammarConstructor<string> generate, Associativity associtivity, int priority = 0);

        void AddCoercion<TSource, TTarget>(CoercionType type, Func<TSource, TTarget> convert);
        void AddUnaryOperation<TOperand, TResult>(UnaryOperator op, Func<TOperand, TResult> definition);
        void AddBinaryOperation<TLeft, TRight, TResult>(BinaryOperator op, Func<TLeft, TRight, TResult> definition);
        
        IParser Build();
    }
}

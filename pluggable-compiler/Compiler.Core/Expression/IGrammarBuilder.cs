using Compiler.Core.Expression;
using System;

namespace Compiler.Core.Expression
{
    public interface IGrammarBuilder
    {
        IGrammarBuilder NewRule<TResult>(string hintName, Expression.IGrammarExpression<TResult> peg, out IRule<TResult> rule);
        IGrammarBuilder RedefineRule<TResult>(IRule<TResult> rule, Expression.IGrammarExpression<TResult> peg);
        IGrammar<TResult> Build<TResult>(IRule<TResult> startAt);
    }
}
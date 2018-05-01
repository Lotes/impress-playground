using Compiler.Core.Expression;
using System;

namespace Compiler.Core.Expression
{
    public interface IGrammarBuilder
    {
        IGrammarBuilder NewRule<T>(Expression.IGrammarExpression<T> peg, string hintName, out IRule rule);
        IGrammarBuilder RedefineRule<T>(IRule<T> rule, Expression.IGrammarExpression<T> peg);
        IGrammar<T> Build<T>(IRule<T> startAt);
    }
}
using Compiler.Core.Expression;
using System;

namespace Compiler.Core.Expression
{
    public interface IGrammarBuilder
    {
        IGrammarBuilder NewRule(Expression.IGrammarExpression peg, string hintName, out IRule rule);
        IGrammarBuilder RedefineRule(IRule rule, Expression.IGrammarExpression peg);
        IGrammar Build(IRule startAt);
    }
}
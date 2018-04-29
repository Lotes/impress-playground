using Compiler.Core.Expression;
using System;

namespace Compiler.Core.Expression
{
    public interface IGrammarBuilder
    {
        IGrammarBuilder NewRule(string hintName, Expression.IGrammarExpression peg, out IRule rule);
        IGrammarBuilder RedefineRule(IRule rule, Expression.IGrammarExpression peg);
        IGrammar Build(IRule startAt);
    }
}
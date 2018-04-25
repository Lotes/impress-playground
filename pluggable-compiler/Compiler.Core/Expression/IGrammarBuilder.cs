using Compiler.Core.Expression;
using System;

namespace Compiler.Core.Expression
{
    public interface IGrammarBuilder
    {
        IGrammarBuilder NewRule(Expression.IExpression peg, string hintName, out IRule rule);
        IGrammarBuilder RedefineRule(IRule rule, Expression.IExpression peg);
        IGrammar Build(IRule startAt);
    }
}
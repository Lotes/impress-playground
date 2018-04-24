using Compiler.Core.Expression;
using System;

namespace Compiler.Core.Expression
{
    public interface IGrammarBuilder
    {
        IGrammarBuilder NewRule(Expression.IExpression peg, out IRule rule);
        IGrammarBuilder DeclareRule(Expression.IExpression peg, out IRule rule);
        IGrammarBuilder RedefineRule(IRule rule, Expression.IExpression peg);
        IGrammarBuilder NewPart(Func<IPartialGrammarBuilder, IPartialGrammar> create);
        IGrammar Build();
    }
}
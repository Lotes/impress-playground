using Compiler.Core.Expression;

namespace Compiler.Core.Engine.Builder
{
    public interface IPartialGrammarBuilder
    {
        IRule Rule_Identifier { get; }
        IRule Rule_Whitespace { get; }
        IRule Rule_Expression { get; }
        IRule Rule_Statement { get; }
        IRule Rule_StatementBlock { get; }

        IPartialGrammarBuilder NewRule(Expression.IExpression peg, out IRule rule);
        IPartialGrammarBuilder DeclareRule(Expression.IExpression peg, out IRule rule);
        IPartialGrammarBuilder RedefineRule(IRule rule, Expression.IExpression peg);
        IPartialGrammar Build();
    }
}
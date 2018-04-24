namespace Compiler.Core.Expression
{
    public interface IPartialGrammarBuilder
    {
        IPartialGrammarBuilder NewRule(Expression.IExpression peg, out IRule rule);
        IPartialGrammarBuilder DeclareRule(Expression.IExpression peg, out IRule rule);
        IPartialGrammarBuilder RedefineRule(IRule rule, Expression.IExpression peg);
        IPartialGrammar Build();
    }
}
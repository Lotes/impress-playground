namespace Compiler.Core.Expression
{
    public interface IRule<TResult>
    {
        string HintName { get; }
        IGrammarExpression<TResult> Expression { get; }
    }
}
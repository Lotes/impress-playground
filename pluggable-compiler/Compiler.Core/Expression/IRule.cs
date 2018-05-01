namespace Compiler.Core.Expression
{
    public interface IRule
    {
        string HintName { get; }
    }

    public interface IRule<TResult>: IRule
    {
        IGrammarExpression<TResult> Expression { get; }
    }
}
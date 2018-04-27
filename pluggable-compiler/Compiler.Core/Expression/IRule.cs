namespace Compiler.Core.Expression
{
    public interface IRule
    {
        string HintName { get; }
        IGrammarExpression Expression { get; }
    }
}
namespace Compiler.Core.Expression
{
    public interface IRule
    {
        string HintName { get; }
        IExpression Expression { get; }
    }
}
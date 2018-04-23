namespace Compiler.Core.Expression
{
    public interface IRule
    {
        string Name { get; }
        IExpression Expression { get; }
    }
}
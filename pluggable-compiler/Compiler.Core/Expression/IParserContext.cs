namespace Compiler.Core.Expression
{
    public interface IParserContext
    {
        string Input { get; }
        IGrammar Grammar { get; }
    }
}
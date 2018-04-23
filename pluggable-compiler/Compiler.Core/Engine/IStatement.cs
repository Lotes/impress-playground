namespace Compiler.Core.Engine
{
    public interface IStatement
    {
        void Validate(IValidationContext context);
        void Execute(IExecutionContext context);
    }
}

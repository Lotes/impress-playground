using System;

namespace Compiler.Core.Engine
{
    public interface IExpression
    {
        Type Validate(IValidationContext context);
        object Evaluate(IExecutionContext context);
    }
}

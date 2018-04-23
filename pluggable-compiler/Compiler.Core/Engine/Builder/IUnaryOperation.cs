using System;

namespace Compiler.Core.Engine.Builder
{
    public interface IUnaryOperation
    {
        IUnaryOperator Operator { get; }
        bool Accept(Type operand);
        Type Validate(IValidationContext context, Type operand);
        object Evaluate(IExecutionContext context, object operand);
    }
}
using System;

namespace Compiler.Core.Engine
{
    public interface IUnaryOperation
    {
        UnaryOperator Operator { get; }
        bool Accept(Type operand);
        Type Validate(IValidationContext context, Type operand);
        object Evaluate(IExecutionContext context, object operand);
    }
}
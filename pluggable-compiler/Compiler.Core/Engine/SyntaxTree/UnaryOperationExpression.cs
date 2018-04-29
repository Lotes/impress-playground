using Compiler.Core.Engine;
using System;

namespace Compiler.Core.Engine
{
    public class UnaryOperationExpression : IExpression
    {
        public UnaryOperationExpression(IUnaryOperation operation, IExpression operand)
        {
            Operation = operation;
            Operand = operand;
        }

        public IUnaryOperation Operation { get; }
        public IExpression Operand { get; }

        public object Evaluate(IExecutionContext context)
        {
            throw new NotImplementedException();
        }

        public Type Validate(IValidationContext context)
        {
            throw new NotImplementedException();
        }
    }
}

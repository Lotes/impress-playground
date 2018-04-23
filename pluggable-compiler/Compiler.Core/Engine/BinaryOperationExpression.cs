using Compiler.Core.Engine.Builder;
using System;

namespace Compiler.Core.Engine
{
    public class BinaryOperationExpression: IExpression
    {
        public BinaryOperationExpression(IBinaryOperation operation, IExpression leftExpression, IExpression rightExpression)
        {
            Operation = operation;
            LeftExpression = leftExpression;
            RightExpression = rightExpression;
        }

        public IBinaryOperation Operation { get; }
        public IExpression LeftExpression { get; }
        public IExpression RightExpression { get; }

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

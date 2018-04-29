using System;

namespace Compiler.Core.Engine
{
    public class UnaryOperation : IUnaryOperation
    {
        public UnaryOperation(UnaryOperator @operator, Type operandType, Type resultType, Func<object, object> apply)
        {
            Operator = @operator;
            OperandType = operandType;
            ResultType = resultType;
            Apply = apply;
        }

        public UnaryOperator Operator { get; }
        public Type OperandType { get; }
        public Type ResultType { get; }
        public Func<object, object> Apply { get; }
    }
}
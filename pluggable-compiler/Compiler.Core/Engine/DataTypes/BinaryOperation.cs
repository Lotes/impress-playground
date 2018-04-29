using System;

namespace Compiler.Core.Engine
{
    public class BinaryOperation: IBinaryOperation
    {
        public BinaryOperation(BinaryOperator @operator, Type leftOperand, Type rightOperand, Type result, Func<object, object, object> apply)
        {
            Operator = @operator;
            LeftOperand = leftOperand;
            RightOperand = rightOperand;
            Result = result;
            Apply = apply;
        }

        public BinaryOperator Operator { get; }
        public Type LeftOperand { get; }
        public Type RightOperand { get; }
        public Type Result { get; }
        public Func<object, object, object> Apply { get; }
    }
}

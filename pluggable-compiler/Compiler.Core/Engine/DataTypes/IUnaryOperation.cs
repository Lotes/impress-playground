using System;

namespace Compiler.Core.Engine
{
    public interface IUnaryOperation
    {
        UnaryOperator Operator { get; }
        Type OperandType { get; }
        Type ResultType { get; }
        Func<object, object> Apply { get; }
    }
}
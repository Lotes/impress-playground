using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Core.Engine.Builder
{
    public interface IBinaryOperation
    {
        BinaryOperator Operator { get; }
        bool Accept(Type lhs, Type rhs);
        Type Validate(IValidationContext context, Type lhs, Type rhs);
        object Evaluate(IExecutionContext context, object lhs, object rhs);
    }
}

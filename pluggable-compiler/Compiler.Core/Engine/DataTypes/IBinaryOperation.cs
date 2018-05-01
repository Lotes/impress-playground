using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Core.Engine
{
    public interface IBinaryOperation
    {
        BinaryOperator Operator { get; }
        Type LeftOperand { get; }
        Type RightOperand { get; }
        Type Result { get; }
        Func<object, object, object> Apply { get; }
    }
}

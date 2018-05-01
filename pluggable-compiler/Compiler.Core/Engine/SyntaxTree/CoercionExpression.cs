using Compiler.Core.Engine;
using System;

namespace Compiler.Core.Engine
{
    public class CoercionExpression: IExpression
    {
        public CoercionExpression(ICoercionOperation conversion, IExpression expression)
        {
            Conversion = conversion;
            Expression = expression;
        }

        public ICoercionOperation Conversion { get; }
        public IExpression Expression { get; }

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

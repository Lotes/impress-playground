using System;

namespace Compiler.Core.Engine
{
    public class LiteralExpression: IExpression
    {
        private object value;
        private Type type;

        public LiteralExpression(Type type, object value)
        {
            this.type = type;
            this.value = value;
        }

        public Type Validate(IValidationContext context) { return type; }
        public object Evaluate(IExecutionContext context) { return value; }
    }
}

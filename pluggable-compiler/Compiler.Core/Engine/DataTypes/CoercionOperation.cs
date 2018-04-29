using System;

namespace Compiler.Core.Engine
{
    public class CoercionOperation: ICoercionOperation
    {
        public CoercionOperation(Type sourceType, Type targetType, CoercionType coercionType, Func<object, object> convert)
        {
            SourceType = sourceType;
            TargetType = targetType;
            CoercionType = coercionType;
            Convert = convert;
        }

        public Type SourceType { get; }
        public Type TargetType { get; }
        public CoercionType CoercionType { get; }
        public Func<object, object> Convert { get; }
    }
}

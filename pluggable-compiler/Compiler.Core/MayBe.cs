using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Core
{
    public sealed class MayBe<T>
    {
        public readonly T Value;
        internal MayBe() { Value = default(T); }
        internal MayBe(T value)
        {
            Value = value;
        }
        public static readonly MayBe<T> Nothing = new MayBe<T>();
        public static MayBe<T> Some(T value) { return new MayBe<T>(value); }
    }

    public static class MayBeExtensions
    {
        public static MayBe<T> ToMayBe<T>(this T value)
        {
            return new MayBe<T>(value);
        }
    }
}

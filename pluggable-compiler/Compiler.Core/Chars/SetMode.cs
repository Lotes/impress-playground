using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Core.Chars
{
    public enum SetMode
    {
        Included,
        Excluded
    }

    public static class SetModeExtensions
    {
        public static SetMode Negate(this SetMode @this)
        {
            return @this == SetMode.Excluded ? SetMode.Included : SetMode.Excluded;
        }
    }
}

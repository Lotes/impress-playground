using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Core.Expression
{
    public class Cursor : ICursor
    {
        public Cursor(int index) { Index = index; }
        public int Index { get; }
    }
}

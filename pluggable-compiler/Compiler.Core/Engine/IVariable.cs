using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Core.Engine
{
    public interface IVariable
    {
        string Name { get; }
        Type VariableType { get; }
        object Value { get; }
    }
}

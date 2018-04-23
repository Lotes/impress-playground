using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Core.Engine.Builder
{
    public interface ICoercionOperation
    {
        Type SourceType { get; }
        Type TargetType { get; }
        CoercionType CoercionType { get; }
        object Convert(object source);
    }
}

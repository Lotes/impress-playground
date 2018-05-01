using System.Collections.Generic;
using System.Linq;

namespace Compiler.Core.Expression
{
    public static class ParseResultExtensions
    {
        public static string GetContent(this IParseResult result)
        {
            return result.Context.Input.Substring(result.Start.Index, result.GetLength());
        }

        public static int GetLength(this IParseResult result)
        {
            return result.End.Index - result.Start.Index + 1;
        }
    }
}

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

        public static string GetName(this IParseResult result)
        {
            return result.Expression is Named ? ((Named)result.Expression).Name : null;
        }

        public static IParseResult FindByName(this IParseResult @this, string name)
        {
            var queue = new Queue<IParseResult>();
            queue.Enqueue(@this);
            while(queue.Any())
            {
                var result = queue.Dequeue();
                if (result.GetName() == name)
                    return result;
                foreach (var child in result.Children)
                    queue.Enqueue(child);
            }
            return null;
        }
    }
}

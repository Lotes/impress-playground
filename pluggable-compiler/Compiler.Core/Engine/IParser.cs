using System.Collections.Generic;

namespace Compiler.Core.Engine
{
    public interface IParser
    {
        IEnumerable<IStatement> ParseStatements(string input);
        IExpression ParseExpression(string input);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Core.Expression
{
    public class ParserContext : IParserContext
    {
        public ParserContext(string input, IGrammar grammar)
        {
            Input = input;
            Grammar = grammar;
        }

        public string Input { get; }
        public IGrammar Grammar { get; }
    }
}

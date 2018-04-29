using System;
using System.Collections.Generic;
using System.Linq;
using Compiler.Core.Expression;

namespace Compiler.Core.Engine
{
    public class PartialGrammar : IGrammar
    {
        public PartialGrammar(IEnumerable<IRule> ownRules, IRule startAt)
        {
            if (!ownRules.Contains(startAt))
                throw new InvalidOperationException("This is not a rule of this set!");
            this.Rules = ownRules.ToArray();
            this.StartingRule = startAt;
        }
        public IRule StartingRule { get; }
        public IEnumerable<IRule> Rules { get; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Compiler.Core.Expression;

namespace Compiler.Core.Engine
{
    public class PartialGrammar<TResult>: IGrammar<TResult>
    {
        public PartialGrammar(IEnumerable<IRule> ownRules, IRule<TResult> startAt)
        {
            if (!ownRules.Contains(startAt))
                throw new InvalidOperationException("This is not a rule of this set!");
            this.Rules = ownRules.ToArray();
            this.StartingRule = startAt;
        }
        IRule IGrammar.StartingRule { get { return StartingRule; } }
        public IEnumerable<IRule> Rules { get; }
        public IRule<TResult> StartingRule { get; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace Compiler.Core.Expression
{
    public class Grammar : IGrammar
    {
        public Grammar(IEnumerable<IRule> rules, IRule startAt)
        {
            if (startAt == null || !rules.Contains(startAt))
                throw new ArgumentException(nameof(startAt));
            var realStart = new Rule(Expressions.Sequence(Expressions.Call(startAt), Expressions.EOF));
            StartingRule = realStart;
            Rules = rules.Concat(new[] { realStart }).ToArray();
        }

        public IRule StartingRule { get; }
        public IEnumerable<IRule> Rules { get; }
    }
}

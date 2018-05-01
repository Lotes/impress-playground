using System;
using System.Collections.Generic;
using System.Linq;

namespace Compiler.Core.Expression
{
    public class Grammar<TResult> : IGrammar<TResult>
    {
        public Grammar(IEnumerable<IRule> rules, IRule<TResult> startAt)
        {
            if (startAt == null || !rules.Contains(startAt))
                throw new ArgumentException(nameof(startAt));
            var realStart = new Rule<TResult>("start'", Expressions.Sequence(Expressions.Call(startAt), Expressions.EOF).Returns(tuple => tuple.Item1));
            StartingRule = realStart;
            Rules = rules.Concat(new[] { realStart }).ToArray();
        }

        public IRule<TResult> StartingRule { get; }
        public IEnumerable<IRule> Rules { get; }

        IRule IGrammar.StartingRule => StartingRule;
    }
}

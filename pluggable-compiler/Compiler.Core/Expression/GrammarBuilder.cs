using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public class Rule : IRule
    {
        public Rule(IExpression expression, string hintName = "<no name>")
        {
            HintName = hintName;
            Expression = expression;
        }

        public string HintName { get; }
        public IExpression Expression { get; set; }
        public override string ToString()
        {
            return HintName;
        }
    }

    public class GrammarBuilder : IGrammarBuilder
    {
        private HashSet<Rule> rules = new HashSet<Rule>();
        public IGrammar Build(IRule startAt)
        {
            return new Grammar(rules, startAt);
        }

        public IGrammarBuilder NewRule(IExpression peg, string hintName, out IRule rule)
        {
            Rule result;
            rule = result = new Rule(peg, hintName);
            rules.Add(result);
            return this;
        }

        public IGrammarBuilder RedefineRule(IRule rule, IExpression peg)
        {
            if (rules.Contains(rule))
                ((Rule)rule).Expression = peg;
            else
                throw new InvalidOperationException("Builder does not contain that rule!");
            return this;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Core.Expression
{
    public class GrammarBuilder : IGrammarBuilder
    {
        private HashSet<IRule> rules = new HashSet<IRule>();
        public IGrammar<TResult> Build<TResult>(IRule<TResult> startAt)
        {
            return new Grammar<TResult>(rules, startAt);
        }

        public IGrammarBuilder NewRule<TResult>(string hintName, IGrammarExpression<TResult> peg, out IRule<TResult> rule)
        {
            Rule<TResult> result;
            rule = result = new Rule<TResult>(hintName, peg);
            rules.Add(result);
            return this;
        }

        public IGrammarBuilder RedefineRule<TResult>(IRule<TResult> rule, IGrammarExpression<TResult> peg)
        {
            if (rules.Contains(rule))
                ((Rule<TResult>)rule).Expression = peg;
            else
                throw new InvalidOperationException("Builder does not contain that rule!");
            return this;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Core.Expression
{
    public class Rule<TResult> : IRule<TResult>
    {
        public Rule(string hintName, IGrammarExpression<TResult> expression)
        {
            HintName = hintName;
            Expression = expression;
        }

        public string HintName { get; }
        public IGrammarExpression<TResult> Expression { get; set; }
    }
}

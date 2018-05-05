using Compiler.Core.Expression;
using System;
using System.Collections.Generic;

namespace Compiler.Core.Engine
{
    
    public class PartialGrammarBuilder : IGrammarBuilder
    {
        private readonly HashSet<IRule> ownRules = new HashSet<IRule>();
         
        public readonly IRule<IExpression> Expression;
        public readonly IRule<IStatement> Statement;
        public readonly IRule<string> WhiteSpace;

        public PartialGrammarBuilder(IRule<IExpression> expression, IRule<IStatement> statement, IRule<string> whiteSpace)
        {
            this.Expression = expression;
            this.Statement = statement;
            this.WhiteSpace = whiteSpace;
        }

        public IGrammar<TResult> Build<TResult>(IRule<TResult> startAt)
        {
            return new PartialGrammar<TResult>(ownRules, startAt);
        }

        public IGrammarBuilder NewRule<TResult>(string hintName, IGrammarExpression<TResult> peg, out IRule<TResult> rule)
        {
            rule = new Rule<TResult>(hintName, peg);
            ownRules.Add(rule);
            return this;   
        }

        public IGrammarBuilder RedefineRule<TResult>(IRule<TResult> rule, IGrammarExpression<TResult> peg)
        {
            if (!ownRules.Contains(rule))
                throw new InvalidOperationException("This rule does not belong to the current rules set!");
            ((Rule<TResult>)rule).Expression = peg;
            return this;
        }
    }
    
}

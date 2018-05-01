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
        public readonly IRule<string> WhiteSpaceZeroOrMore;
        public readonly IRule<string> WhiteSpaceOneOrMore;

        public PartialGrammarBuilder(IRule<IExpression> expression, IRule<IStatement> statement, IRule<string> whiteSpaceZeroOrMore, IRule<string> whiteSpacesOneOrMore)
        {
            this.Expression = expression;
            this.Statement = statement;
            this.WhiteSpaceOneOrMore = whiteSpacesOneOrMore;
            this.WhiteSpaceZeroOrMore = whiteSpaceZeroOrMore;
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
            ((Rule)rule).Expression = peg;
            return this;
        }
    }
    
}

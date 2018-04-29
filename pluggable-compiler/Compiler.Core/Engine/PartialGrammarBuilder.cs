using Compiler.Core.Expression;
using System;
using System.Collections.Generic;

namespace Compiler.Core.Engine
{
    
    public class PartialGrammarBuilder : IGrammarBuilder
    {
        private readonly HashSet<IRule> ownRules = new HashSet<IRule>();
         
        public readonly IRule Expression;
        public readonly IRule Statement;
        public readonly IRule WhiteSpaceZeroOrMore;
        public readonly IRule WhiteSpaceOneOrMore;

        public PartialGrammarBuilder(IRule expression, IRule statement, IRule whiteSpaceZeroOrMore, IRule whiteSpacesOneOrMore)
        {
            this.Expression = expression;
            this.Statement = statement;
            this.WhiteSpaceOneOrMore = whiteSpacesOneOrMore;
            this.WhiteSpaceZeroOrMore = whiteSpaceZeroOrMore;
        }

        public IGrammar Build(IRule startAt)
        {
            return new PartialGrammar(ownRules, startAt);
        }

        public IGrammarBuilder NewRule(string hintName, IGrammarExpression peg, out IRule rule)
        {
            rule = new Rule(peg, hintName);
            ownRules.Add(rule);
            return this;   
        }

        public IGrammarBuilder RedefineRule(IRule rule, IGrammarExpression peg)
        {
            if (!ownRules.Contains(rule))
                throw new InvalidOperationException("This rule does not belong to the current rules set!");
            ((Rule)rule).Expression = peg;
            return this;
        }
    }
    
}

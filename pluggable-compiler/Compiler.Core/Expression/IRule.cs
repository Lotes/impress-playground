namespace Compiler.Core.Expression
{
    public interface IRule
    {
        string HintName { get; }
    }

    public interface IRule<TResult>: IRule
    {
        IGrammarExpression<TResult> Expression { get; }
    }

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
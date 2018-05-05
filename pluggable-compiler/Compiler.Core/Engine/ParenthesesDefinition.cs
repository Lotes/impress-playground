namespace Compiler.Core.Engine
{
    public class ParenthesesDefinition
    {
        public ParserExpectation Before { get; }
        public PartialGrammarConstructor<string> Open { get; }
        public PartialGrammarConstructor<string> Next { get; }
        public PartialGrammarConstructor<string> Close { get; }
        public ParserExpectation After { get; }
        public FoldExpressionsDelegate Fold { get; }
        public int Priority { get; }

        public ParenthesesDefinition(ParserExpectation before, PartialGrammarConstructor<string> open, PartialGrammarConstructor<string> next, PartialGrammarConstructor<string> close, ParserExpectation after, FoldExpressionsDelegate fold, int priority)
        {
            Before = before;
            Open = open;
            Next = next;
            Close = close;
            After = after;
            Fold = fold;
            Priority = priority;
        }
    }
}
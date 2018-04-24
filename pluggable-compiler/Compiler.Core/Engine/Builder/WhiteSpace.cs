namespace Compiler.Core.Engine.Builder
{
    public class WhiteSpace: ILexicalDefinition
    {
        public WhiteSpace(IPartialGrammar partialGrammar, int priority)
        {
            Priority = priority;
            PartialGrammar = partialGrammar;
        }

        public int Priority { get; }
        public IPartialGrammar PartialGrammar { get; }
    }
}
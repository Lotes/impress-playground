namespace Compiler.Core.Expression
{
    public interface IVisitor<TResult, TState>
    {
        TResult Visit_And(TState state, And and);
        TResult Visit_Call(TState state, Call call);
        TResult Visit_CharacterClass(TState state, CharacterClass characterClass);
        TResult Visit_Not(TState state, Not not);
        TResult Visit_Choice(TState state, Choice choice);
        TResult Visit_Sequence(TState state, Sequence sequence);
        TResult Visit_EOF(TState state, EOF eof);
        TResult Visit_Repetition(TState state, Repetition repetition);
        TResult Visit_Named(TState state, Named named);
    }
}
namespace Compiler.Core.Expression
{
    public interface IVisitor<T>
    {
        T Visit_And(And and);
        T Visit_Call(Call call);
        T Visit_CharacterClass(CharacterClass characterClass);
        T Visit_Not(Not not);
        T Visit_Choice(Choice choice);
        T Visit_Sequence(Sequence sequence);
        T Visit_Repetition(Repetition repetition);
        T Visit_Named(Named named);
    }
}
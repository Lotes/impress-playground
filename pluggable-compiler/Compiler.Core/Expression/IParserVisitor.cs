using System.Collections.Generic;

namespace Compiler.Core.Expression
{
    public interface IParserVisitor: ISequenceParserVisitor
    {
        MayBe<IParseResult<T>> Visit_Return<S, T>(int position, Return<S, T> @return);
        MayBe<IParseResult<string>> Visit_CharacterClass(int position, CharacterClass characterClass);
        MayBe<IParseResult<TResult>> Visit_Call<TResult>(int position, Call<TResult> call);
        MayBe<IParseResult<string>> Visit_EOF(int position, EOF eOF);
        MayBe<IParseResult<TResult>> Visit_Not<TResult>(int position, Not<TResult> not);
        MayBe<IParseResult<TResult>> Visit_And<TResult>(int position, And<TResult> and);
        MayBe<IParseResult<TResult>> Visit_Named<TResult>(int position, Named<TResult> named);
        MayBe<IParseResult<TResult>> Visit_Choice<TResult>(int position, Choice<TResult> choice);
        MayBe<IParseResult<IReadOnlyList<TResult>>> Visit_Repetition<TResult>(int position, Repetition<TResult> repetition);
    }
}
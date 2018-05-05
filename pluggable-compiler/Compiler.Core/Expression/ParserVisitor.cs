using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Core.Expression
{
    public partial class ParserVisitor : IParserVisitor
    {
        private IParserContext context;

        public ParserVisitor(IParserContext context)
        {
            this.context = context;
        }

        public MayBe<IParseResult<TResult>> Visit_And<TResult>(int position, And<TResult> and)
        {
            var result = and.Operand.ParseAt(this, position);
            if (result == MayBe<IParseResult<TResult>>.Nothing)
                return MayBe<IParseResult<TResult>>.Nothing;
            return MayBe<IParseResult<TResult>>.Some(new ParseResult<TResult>(result.Value.Result, and, context, new Cursor(position), new Cursor(position-1), new[] { result.Value }));
        }

        public MayBe<IParseResult<TResult>> Visit_Call<TResult>(int position, Call<TResult> call)
        {
            if (!context.Grammar.Rules.Contains(call.Rule))
                throw new InvalidOperationException("Invalid call!");
            var result = call.Rule.Expression.ParseAt(this, position);
            if (result == MayBe<IParseResult<TResult>>.Nothing)
                return MayBe<IParseResult<TResult>>.Nothing;
            return ((IParseResult<TResult>)new ParseResult<TResult>(result.Value.Result, call, context, result.Value.Start, result.Value.End, new IParseResult[] { result.Value }))
                .ToMayBe();
        }

        public MayBe<IParseResult<string>> Visit_CharacterClass(int position, CharacterClass characterClass)
        {
            if (characterClass.CharSet.Length == 0)
            {
                return MayBe<IParseResult<string>>.Some(new ParseResult<string>("", characterClass, context, new Cursor(position), new Cursor(position-1), new IParseResult[0]));
            }
            try
            {
                var character = context.Input[position];
                if (characterClass.CharSet.Includes(character))
                    return new MayBe<IParseResult<string>>(new ParseResult<string>(character.ToString(), characterClass, context, new Cursor(position), new Cursor(position), new IParseResult[0]));
            }
            catch
            {
            }
            return MayBe<IParseResult<string>>.Nothing;
        }

        public MayBe<IParseResult<TResult>> Visit_Choice<TResult>(int position, Choice<TResult> choice)
        {
            foreach (var element in choice.Choices)
            {
                var result = element.ParseAt(this, position);
                if (result != MayBe<IParseResult<TResult>>.Nothing)
                    return MayBe<IParseResult<TResult>>.Some(new ParseResult<TResult>(result.Value.Result, choice, context, result.Value.Start, result.Value.End,  new[] { result.Value }));
            }
            return MayBe<IParseResult<TResult>>.Nothing;
        }

        public MayBe<IParseResult<string>> Visit_EOF(int position, EOF eOF)
        {
            if (position >= context.Input.Length)
                return MayBe<IParseResult<string>>.Some(new ParseResult<string>("", eOF, context, new Cursor(position), new Cursor(position), new IParseResult[0]));
            return MayBe<IParseResult<string>>.Nothing;
        }

        public MayBe<IParseResult<TResult>> Visit_Hook<TResult>(int position, Hook<TResult> hook)
        {
            return hook.Callback(context, position);
        }

        public MayBe<IParseResult<TResult>> Visit_Named<TResult>(int position, Named<TResult> named)
        {
            var result = named.Expression.ParseAt(this, position);
            if (result != MayBe<IParseResult<TResult>>.Nothing)
                return MayBe<IParseResult<TResult>>.Some(new ParseResult<TResult>(result.Value.Result, named, context, result.Value.Start, result.Value.End, new[] { result.Value }));
            return MayBe<IParseResult<TResult>>.Nothing;

        }

        public MayBe<IParseResult<TResult>> Visit_Not<TResult>(int position, Not<TResult> not)
        {
            var result = not.Operand.ParseAt(this, position);
            if (result == MayBe<IParseResult<TResult>>.Nothing)
                return MayBe<IParseResult<TResult>>.Nothing;
            return MayBe<IParseResult<TResult>>.Some(new ParseResult<TResult>(result.Value.Result, not, context, result.Value.Start, result.Value.End, new[] { result.Value }));
        }

        public MayBe<IParseResult<IReadOnlyList<TResult>>> Visit_Repetition<TResult>(int position, Repetition<TResult> repetition)
        {
            var children = new LinkedList<IParseResult>();
            var end = position;
            int start = position;
            MayBe<IParseResult<TResult>> itResult = null;
            for (var index = 1; index <= repetition.Minimum; index++)
            {
                if ((itResult = repetition.Expression.ParseAt(this, end)) == MayBe<IParseResult<TResult>>.Nothing)
                    return MayBe<IParseResult<IReadOnlyList<TResult>>>.Nothing;
                children.AddLast(itResult.Value);
                end += itResult.Value.GetLength();
            }
            if (repetition.Maximum != null)
            {
                int index;
                for (index = repetition.Minimum; index <= repetition.Maximum.Value; index++)
                {
                    if ((itResult = repetition.Expression.ParseAt(this, end)) != MayBe<IParseResult<TResult>>.Nothing)
                    {
                        end += itResult.Value.GetLength();
                        children.AddLast(itResult.Value);
                    }
                    else
                        break;
                }
                if (index <= repetition.Maximum.Value)
                    return MayBe<IParseResult<IReadOnlyList<TResult>>>.Some(new ParseResult<IReadOnlyList<TResult>>(children.Cast<IParseResult<TResult>>().Select(c => c.Result).ToList(), repetition, context, new Cursor(start), new Cursor(end - 1), children));
                else
                    return MayBe<IParseResult<IReadOnlyList<TResult>>>.Nothing;
            }
            else
            {
                while ((itResult = repetition.Expression.ParseAt(this, end)) != MayBe<IParseResult<TResult>>.Nothing)
                {
                    end += itResult.Value.GetLength();
                    children.AddLast(itResult.Value);
                }
                return MayBe<IParseResult<IReadOnlyList<TResult>>>.Some(new ParseResult<IReadOnlyList<TResult>>(
                    children.Cast<IParseResult<TResult>>().Select(c => c.Result).ToList(), 
                    repetition, 
                    context, 
                    new Cursor(start), 
                    new Cursor(end - 1), 
                    children
                ));
            }
        }

        public MayBe<IParseResult<T>> Visit_Return<S, T>(int position, Return<S, T> @return)
        {
            var parseResult = @return.Expression.ParseAt(this, position);
            if (parseResult == MayBe<IParseResult<S>>.Nothing)
                return MayBe<IParseResult<T>>.Nothing;
            return MayBe<IParseResult<T>>.Some(
                new ParseResult<T>(
                    @return.Convert(parseResult.Value.Result),
                    @return,
                    context,
                    parseResult.Value.Start,
                    parseResult.Value.End,
                    new[] { parseResult.Value }
                )
            );
        }
    }
}

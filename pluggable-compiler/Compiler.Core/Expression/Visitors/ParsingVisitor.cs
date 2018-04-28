using System;
using System.Collections.Generic;
using System.Linq;

namespace Compiler.Core.Expression.Visitors
{
    public partial class ParsingVisitor : IVisitor<int>
    {
        private IParserContext context;
        public ParsingVisitor(IParserContext context)
        {
            this.context = context;
        }

        public TResult Visit_And<TResult, TOperand>(int state, And<TResult, TOperand> and)
        {
            var result = and.Operand.Accept(this, state);
            return new ParsingState(result.Ok, result.Ok ? new ParseResult(and, context, state, state - 1, new IParseResult[0]) : null);
        }

        public ParsingState Visit_Call(int state, Call call)
        {
            if (!context.Grammar.Rules.Contains(call.Rule))
                throw new InvalidOperationException("Invalid call!");
            var result = call.Rule.Expression.Accept(this, state);
            return new ParsingState(
                result.Ok,
                result.Ok
                    ? new ParseResult(call, context, result.Result.Start.Index, result.Result.End.Index, new[] { result.Result })
                    : null
            );
        }

        public ParsingState Visit_CharacterClass(int state, CharacterClass characterClass)
        {
            if (characterClass.CharSet.Length == 0)
            {
                return new ParsingState(true, new ParseResult(characterClass, context, state, state - 1, new IParseResult[0]));
            }
            try
            {
                var character = context.Input[state];
                if (characterClass.CharSet.Includes(character))
                {
                    return new ParsingState(true, new ParseResult(characterClass, context, state, state, new IParseResult[0]));
                }
                return new ParsingState(false, null);
            }
            catch
            {
                return new ParsingState(false, null);
            }
        }

        public ParsingState Visit_Choice(int state, Choice expression)
        {
            foreach (var choice in expression.Choices)
            {
                var result = choice.Accept(this, state);
                if (result.Ok)
                    return new ParsingState(true, new ParseResult(expression, context, result.Result.Start.Index, result.Result.End.Index, new[] { result.Result }));
            }
            return new ParsingState(false, null);
        }

        public ParsingState Visit_EOF(int state, EOF eof)
        {
            if (state >= context.Input.Length)
                return new ParsingState(true, new ParseResult(eof, context, state, state - 1, new IParseResult[0]));
            return new ParsingState(false, null);
        }

        public ParsingState Visit_Named(int state, Named named)
        {
            var result = named.Expression.Accept(this, state);
            if (result.Ok)
                return new ParsingState(true, new ParseResult(named, context, result.Result.Start.Index, result.Result.End.Index, new[] { result.Result }));
            return new ParsingState(false, null);
        }

        public ParsingState Visit_Not(int state, Not not)
        {
            var result = not.Operand.Accept(this, state);
            return new ParsingState(!result.Ok, !result.Ok ? new ParseResult(not, context, state, state - 1, new IParseResult[0]) : null);
        }

        public ParsingState Visit_Repetition(int state, Repetition rep)
        {
            var children = new LinkedList<IParseResult>();
            var end = state;
            int start = state;
            ParsingState itResult = null;
            for (var index = 1; index <= rep.Minimum; index++)
            {
                if (!(itResult = rep.Expression.Accept(this, end)).Ok)
                    return new ParsingState(false, null);
                children.AddLast(itResult.Result);
                end += itResult.Result.GetLength();
            }
            if (rep.Maximum != null)
            {
                int index;
                for (index = rep.Minimum; index <= rep.Maximum.Value; index++)
                {
                    if ((itResult = rep.Expression.Accept(this, end)).Ok)
                    {
                        end += itResult.Result.GetLength();
                        children.AddLast(itResult.Result);
                    }
                    else
                        break;
                }
                if (index <= rep.Maximum.Value)
                    return new ParsingState(true, new ParseResult(rep, context, start, end - 1, children));
                else
                    return new ParsingState(false, null);
            }
            else
            {
                while ((itResult = rep.Expression.Accept(this, end)).Ok)
                {
                    end += itResult.Result.GetLength();
                    children.AddLast(itResult.Result);
                }
                return new ParsingState(true, new ParseResult(rep, context, start, end - 1, children));
            }
        }

        public ParsingState Visit_Sequence(int state, Sequence sequence)
        {
            var pos = state;
            var list = new LinkedList<IParseResult>();
            foreach (var element in sequence.Elements)
            {
                var elemResult = element.Accept(this, pos);
                if (!elemResult.Ok)
                    return new ParsingState(false, null);
                list.AddLast(elemResult.Result);
                pos += elemResult.Result.GetLength();
            }
            return new ParsingState(true, new ParseResult(sequence, context, state, Math.Max(state, pos - 1), list));
        }
    }
}

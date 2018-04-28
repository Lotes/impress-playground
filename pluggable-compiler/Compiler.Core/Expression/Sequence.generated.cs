using Compiler.Core.Chars;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Compiler.Core.Expression
{
	public interface IVisitor<TState>
    {
        TResult Visit_And<TResult, TOperand>(TState state, And<TResult, TOperand> and);
        TResult Visit_Call<TResult>(TState state, Call<TResult> call);
        TResult[] Visit_Repetition<TResult>(TState state, Repetition<TResult> repetition);
        TResult Visit_Choice<TResult, TOperand>(TState state, Choice<TResult, TOperand> choice);
        TResult Visit_CharacterClass<TResult>(TState state, CharacterClass<TResult> characterClass);
        TResult Visit_Named<TResult, TOperand>(TState state, Named<TResult, TOperand> named);
        TResult Visit_EOF<TResult>(TState state, EOF<TResult> eof);
        TResult Visit_Not<TResult, TOperand>(TState state, Not<TResult, TOperand> not);
        TResult Visit_Sequence<TResult, TOperand1>(TState state, Sequence<TResult, TOperand1> sequence);
        TResult Visit_Sequence<TResult, TOperand1, TOperand2>(TState state, Sequence<TResult, TOperand1, TOperand2> sequence);
        TResult Visit_Sequence<TResult, TOperand1, TOperand2, TOperand3>(TState state, Sequence<TResult, TOperand1, TOperand2, TOperand3> sequence);
    }

    public class Sequence<TResult, TOperand1>: IGrammarExpression<TResult>
    {
        public Sequence(IGrammarExpression<TOperand1> operand1)
        {
			this.Operand1 = operand1;
        }

		public IGrammarExpression<TOperand1> Operand1 { get; }

        public TResult Accept<S>(IVisitor<S> visitor, S state)
        {
            return visitor.Visit_Sequence(state, this);
        }
    }
    public class Sequence<TResult, TOperand1, TOperand2>: IGrammarExpression<TResult>
    {
        public Sequence(IGrammarExpression<TOperand1> operand1, IGrammarExpression<TOperand2> operand2)
        {
			this.Operand1 = operand1;
			this.Operand2 = operand2;
        }

		public IGrammarExpression<TOperand1> Operand1 { get; }
		public IGrammarExpression<TOperand2> Operand2 { get; }

        public TResult Accept<S>(IVisitor<S> visitor, S state)
        {
            return visitor.Visit_Sequence(state, this);
        }
    }
    public class Sequence<TResult, TOperand1, TOperand2, TOperand3>: IGrammarExpression<TResult>
    {
        public Sequence(IGrammarExpression<TOperand1> operand1, IGrammarExpression<TOperand2> operand2, IGrammarExpression<TOperand3> operand3)
        {
			this.Operand1 = operand1;
			this.Operand2 = operand2;
			this.Operand3 = operand3;
        }

		public IGrammarExpression<TOperand1> Operand1 { get; }
		public IGrammarExpression<TOperand2> Operand2 { get; }
		public IGrammarExpression<TOperand3> Operand3 { get; }

        public TResult Accept<S>(IVisitor<S> visitor, S state)
        {
            return visitor.Visit_Sequence(state, this);
        }
    }
}

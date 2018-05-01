using Compiler.Core.Chars;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Compiler.Core.Expression
{
	public interface ISequenceParserVisitor
    {
        MayBe<IParseResult<Tuple<TOperand1>>> Visit_Sequence<TOperand1>(int position, Sequence<TOperand1> sequence);
        MayBe<IParseResult<Tuple<TOperand1, TOperand2>>> Visit_Sequence<TOperand1, TOperand2>(int position, Sequence<TOperand1, TOperand2> sequence);
        MayBe<IParseResult<Tuple<TOperand1, TOperand2, TOperand3>>> Visit_Sequence<TOperand1, TOperand2, TOperand3>(int position, Sequence<TOperand1, TOperand2, TOperand3> sequence);
        MayBe<IParseResult<Tuple<TOperand1, TOperand2, TOperand3, TOperand4>>> Visit_Sequence<TOperand1, TOperand2, TOperand3, TOperand4>(int position, Sequence<TOperand1, TOperand2, TOperand3, TOperand4> sequence);
        MayBe<IParseResult<Tuple<TOperand1, TOperand2, TOperand3, TOperand4, TOperand5>>> Visit_Sequence<TOperand1, TOperand2, TOperand3, TOperand4, TOperand5>(int position, Sequence<TOperand1, TOperand2, TOperand3, TOperand4, TOperand5> sequence);
        MayBe<IParseResult<Tuple<TOperand1, TOperand2, TOperand3, TOperand4, TOperand5, TOperand6>>> Visit_Sequence<TOperand1, TOperand2, TOperand3, TOperand4, TOperand5, TOperand6>(int position, Sequence<TOperand1, TOperand2, TOperand3, TOperand4, TOperand5, TOperand6> sequence);
        MayBe<IParseResult<Tuple<TOperand1, TOperand2, TOperand3, TOperand4, TOperand5, TOperand6, TOperand7>>> Visit_Sequence<TOperand1, TOperand2, TOperand3, TOperand4, TOperand5, TOperand6, TOperand7>(int position, Sequence<TOperand1, TOperand2, TOperand3, TOperand4, TOperand5, TOperand6, TOperand7> sequence);
        MayBe<IParseResult<Tuple<TOperand1, TOperand2, TOperand3, TOperand4, TOperand5, TOperand6, TOperand7, TOperand8>>> Visit_Sequence<TOperand1, TOperand2, TOperand3, TOperand4, TOperand5, TOperand6, TOperand7, TOperand8>(int position, Sequence<TOperand1, TOperand2, TOperand3, TOperand4, TOperand5, TOperand6, TOperand7, TOperand8> sequence);
    }

	public partial class ParserVisitor 
    {
        public MayBe<IParseResult<Tuple<TOperand1>>> Visit_Sequence<TOperand1>(int position, Sequence<TOperand1> sequence)
		{
            var Nothing = MayBe<IParseResult<Tuple<TOperand1>>>.Nothing;
            //Operand 1
            var result1 = sequence.Operand1.ParseAt(this, position);
            if (result1 == MayBe<IParseResult<TOperand1>>.Nothing)
                return Nothing;
            position += result1.Value.GetLength();

	
            return MayBe<IParseResult<Tuple<TOperand1>>>.Some(
                new ParseResult<Tuple<TOperand1>>(
                    new Tuple<TOperand1>(
                        result1.Value.Result
                    ),
                    sequence,
                    context,
                    result1.Value.Start,
                    result1.Value.End,
                    new IParseResult[]
                    {
                        result1.Value
                    }
                )
            );		
		}
        public MayBe<IParseResult<Tuple<TOperand1, TOperand2>>> Visit_Sequence<TOperand1, TOperand2>(int position, Sequence<TOperand1, TOperand2> sequence)
		{
            var Nothing = MayBe<IParseResult<Tuple<TOperand1, TOperand2>>>.Nothing;
            //Operand 1
            var result1 = sequence.Operand1.ParseAt(this, position);
            if (result1 == MayBe<IParseResult<TOperand1>>.Nothing)
                return Nothing;
            position += result1.Value.GetLength();

            //Operand 2
            var result2 = sequence.Operand2.ParseAt(this, position);
            if (result2 == MayBe<IParseResult<TOperand2>>.Nothing)
                return Nothing;
            position += result2.Value.GetLength();

	
            return MayBe<IParseResult<Tuple<TOperand1, TOperand2>>>.Some(
                new ParseResult<Tuple<TOperand1, TOperand2>>(
                    new Tuple<TOperand1, TOperand2>(
                        result1.Value.Result,
                        result2.Value.Result
                    ),
                    sequence,
                    context,
                    result1.Value.Start,
                    result2.Value.End,
                    new IParseResult[]
                    {
                        result1.Value,
                        result2.Value
                    }
                )
            );		
		}
        public MayBe<IParseResult<Tuple<TOperand1, TOperand2, TOperand3>>> Visit_Sequence<TOperand1, TOperand2, TOperand3>(int position, Sequence<TOperand1, TOperand2, TOperand3> sequence)
		{
            var Nothing = MayBe<IParseResult<Tuple<TOperand1, TOperand2, TOperand3>>>.Nothing;
            //Operand 1
            var result1 = sequence.Operand1.ParseAt(this, position);
            if (result1 == MayBe<IParseResult<TOperand1>>.Nothing)
                return Nothing;
            position += result1.Value.GetLength();

            //Operand 2
            var result2 = sequence.Operand2.ParseAt(this, position);
            if (result2 == MayBe<IParseResult<TOperand2>>.Nothing)
                return Nothing;
            position += result2.Value.GetLength();

            //Operand 3
            var result3 = sequence.Operand3.ParseAt(this, position);
            if (result3 == MayBe<IParseResult<TOperand3>>.Nothing)
                return Nothing;
            position += result3.Value.GetLength();

	
            return MayBe<IParseResult<Tuple<TOperand1, TOperand2, TOperand3>>>.Some(
                new ParseResult<Tuple<TOperand1, TOperand2, TOperand3>>(
                    new Tuple<TOperand1, TOperand2, TOperand3>(
                        result1.Value.Result,
                        result2.Value.Result,
                        result3.Value.Result
                    ),
                    sequence,
                    context,
                    result1.Value.Start,
                    result3.Value.End,
                    new IParseResult[]
                    {
                        result1.Value,
                        result2.Value,
                        result3.Value
                    }
                )
            );		
		}
        public MayBe<IParseResult<Tuple<TOperand1, TOperand2, TOperand3, TOperand4>>> Visit_Sequence<TOperand1, TOperand2, TOperand3, TOperand4>(int position, Sequence<TOperand1, TOperand2, TOperand3, TOperand4> sequence)
		{
            var Nothing = MayBe<IParseResult<Tuple<TOperand1, TOperand2, TOperand3, TOperand4>>>.Nothing;
            //Operand 1
            var result1 = sequence.Operand1.ParseAt(this, position);
            if (result1 == MayBe<IParseResult<TOperand1>>.Nothing)
                return Nothing;
            position += result1.Value.GetLength();

            //Operand 2
            var result2 = sequence.Operand2.ParseAt(this, position);
            if (result2 == MayBe<IParseResult<TOperand2>>.Nothing)
                return Nothing;
            position += result2.Value.GetLength();

            //Operand 3
            var result3 = sequence.Operand3.ParseAt(this, position);
            if (result3 == MayBe<IParseResult<TOperand3>>.Nothing)
                return Nothing;
            position += result3.Value.GetLength();

            //Operand 4
            var result4 = sequence.Operand4.ParseAt(this, position);
            if (result4 == MayBe<IParseResult<TOperand4>>.Nothing)
                return Nothing;
            position += result4.Value.GetLength();

	
            return MayBe<IParseResult<Tuple<TOperand1, TOperand2, TOperand3, TOperand4>>>.Some(
                new ParseResult<Tuple<TOperand1, TOperand2, TOperand3, TOperand4>>(
                    new Tuple<TOperand1, TOperand2, TOperand3, TOperand4>(
                        result1.Value.Result,
                        result2.Value.Result,
                        result3.Value.Result,
                        result4.Value.Result
                    ),
                    sequence,
                    context,
                    result1.Value.Start,
                    result4.Value.End,
                    new IParseResult[]
                    {
                        result1.Value,
                        result2.Value,
                        result3.Value,
                        result4.Value
                    }
                )
            );		
		}
        public MayBe<IParseResult<Tuple<TOperand1, TOperand2, TOperand3, TOperand4, TOperand5>>> Visit_Sequence<TOperand1, TOperand2, TOperand3, TOperand4, TOperand5>(int position, Sequence<TOperand1, TOperand2, TOperand3, TOperand4, TOperand5> sequence)
		{
            var Nothing = MayBe<IParseResult<Tuple<TOperand1, TOperand2, TOperand3, TOperand4, TOperand5>>>.Nothing;
            //Operand 1
            var result1 = sequence.Operand1.ParseAt(this, position);
            if (result1 == MayBe<IParseResult<TOperand1>>.Nothing)
                return Nothing;
            position += result1.Value.GetLength();

            //Operand 2
            var result2 = sequence.Operand2.ParseAt(this, position);
            if (result2 == MayBe<IParseResult<TOperand2>>.Nothing)
                return Nothing;
            position += result2.Value.GetLength();

            //Operand 3
            var result3 = sequence.Operand3.ParseAt(this, position);
            if (result3 == MayBe<IParseResult<TOperand3>>.Nothing)
                return Nothing;
            position += result3.Value.GetLength();

            //Operand 4
            var result4 = sequence.Operand4.ParseAt(this, position);
            if (result4 == MayBe<IParseResult<TOperand4>>.Nothing)
                return Nothing;
            position += result4.Value.GetLength();

            //Operand 5
            var result5 = sequence.Operand5.ParseAt(this, position);
            if (result5 == MayBe<IParseResult<TOperand5>>.Nothing)
                return Nothing;
            position += result5.Value.GetLength();

	
            return MayBe<IParseResult<Tuple<TOperand1, TOperand2, TOperand3, TOperand4, TOperand5>>>.Some(
                new ParseResult<Tuple<TOperand1, TOperand2, TOperand3, TOperand4, TOperand5>>(
                    new Tuple<TOperand1, TOperand2, TOperand3, TOperand4, TOperand5>(
                        result1.Value.Result,
                        result2.Value.Result,
                        result3.Value.Result,
                        result4.Value.Result,
                        result5.Value.Result
                    ),
                    sequence,
                    context,
                    result1.Value.Start,
                    result5.Value.End,
                    new IParseResult[]
                    {
                        result1.Value,
                        result2.Value,
                        result3.Value,
                        result4.Value,
                        result5.Value
                    }
                )
            );		
		}
        public MayBe<IParseResult<Tuple<TOperand1, TOperand2, TOperand3, TOperand4, TOperand5, TOperand6>>> Visit_Sequence<TOperand1, TOperand2, TOperand3, TOperand4, TOperand5, TOperand6>(int position, Sequence<TOperand1, TOperand2, TOperand3, TOperand4, TOperand5, TOperand6> sequence)
		{
            var Nothing = MayBe<IParseResult<Tuple<TOperand1, TOperand2, TOperand3, TOperand4, TOperand5, TOperand6>>>.Nothing;
            //Operand 1
            var result1 = sequence.Operand1.ParseAt(this, position);
            if (result1 == MayBe<IParseResult<TOperand1>>.Nothing)
                return Nothing;
            position += result1.Value.GetLength();

            //Operand 2
            var result2 = sequence.Operand2.ParseAt(this, position);
            if (result2 == MayBe<IParseResult<TOperand2>>.Nothing)
                return Nothing;
            position += result2.Value.GetLength();

            //Operand 3
            var result3 = sequence.Operand3.ParseAt(this, position);
            if (result3 == MayBe<IParseResult<TOperand3>>.Nothing)
                return Nothing;
            position += result3.Value.GetLength();

            //Operand 4
            var result4 = sequence.Operand4.ParseAt(this, position);
            if (result4 == MayBe<IParseResult<TOperand4>>.Nothing)
                return Nothing;
            position += result4.Value.GetLength();

            //Operand 5
            var result5 = sequence.Operand5.ParseAt(this, position);
            if (result5 == MayBe<IParseResult<TOperand5>>.Nothing)
                return Nothing;
            position += result5.Value.GetLength();

            //Operand 6
            var result6 = sequence.Operand6.ParseAt(this, position);
            if (result6 == MayBe<IParseResult<TOperand6>>.Nothing)
                return Nothing;
            position += result6.Value.GetLength();

	
            return MayBe<IParseResult<Tuple<TOperand1, TOperand2, TOperand3, TOperand4, TOperand5, TOperand6>>>.Some(
                new ParseResult<Tuple<TOperand1, TOperand2, TOperand3, TOperand4, TOperand5, TOperand6>>(
                    new Tuple<TOperand1, TOperand2, TOperand3, TOperand4, TOperand5, TOperand6>(
                        result1.Value.Result,
                        result2.Value.Result,
                        result3.Value.Result,
                        result4.Value.Result,
                        result5.Value.Result,
                        result6.Value.Result
                    ),
                    sequence,
                    context,
                    result1.Value.Start,
                    result6.Value.End,
                    new IParseResult[]
                    {
                        result1.Value,
                        result2.Value,
                        result3.Value,
                        result4.Value,
                        result5.Value,
                        result6.Value
                    }
                )
            );		
		}
        public MayBe<IParseResult<Tuple<TOperand1, TOperand2, TOperand3, TOperand4, TOperand5, TOperand6, TOperand7>>> Visit_Sequence<TOperand1, TOperand2, TOperand3, TOperand4, TOperand5, TOperand6, TOperand7>(int position, Sequence<TOperand1, TOperand2, TOperand3, TOperand4, TOperand5, TOperand6, TOperand7> sequence)
		{
            var Nothing = MayBe<IParseResult<Tuple<TOperand1, TOperand2, TOperand3, TOperand4, TOperand5, TOperand6, TOperand7>>>.Nothing;
            //Operand 1
            var result1 = sequence.Operand1.ParseAt(this, position);
            if (result1 == MayBe<IParseResult<TOperand1>>.Nothing)
                return Nothing;
            position += result1.Value.GetLength();

            //Operand 2
            var result2 = sequence.Operand2.ParseAt(this, position);
            if (result2 == MayBe<IParseResult<TOperand2>>.Nothing)
                return Nothing;
            position += result2.Value.GetLength();

            //Operand 3
            var result3 = sequence.Operand3.ParseAt(this, position);
            if (result3 == MayBe<IParseResult<TOperand3>>.Nothing)
                return Nothing;
            position += result3.Value.GetLength();

            //Operand 4
            var result4 = sequence.Operand4.ParseAt(this, position);
            if (result4 == MayBe<IParseResult<TOperand4>>.Nothing)
                return Nothing;
            position += result4.Value.GetLength();

            //Operand 5
            var result5 = sequence.Operand5.ParseAt(this, position);
            if (result5 == MayBe<IParseResult<TOperand5>>.Nothing)
                return Nothing;
            position += result5.Value.GetLength();

            //Operand 6
            var result6 = sequence.Operand6.ParseAt(this, position);
            if (result6 == MayBe<IParseResult<TOperand6>>.Nothing)
                return Nothing;
            position += result6.Value.GetLength();

            //Operand 7
            var result7 = sequence.Operand7.ParseAt(this, position);
            if (result7 == MayBe<IParseResult<TOperand7>>.Nothing)
                return Nothing;
            position += result7.Value.GetLength();

	
            return MayBe<IParseResult<Tuple<TOperand1, TOperand2, TOperand3, TOperand4, TOperand5, TOperand6, TOperand7>>>.Some(
                new ParseResult<Tuple<TOperand1, TOperand2, TOperand3, TOperand4, TOperand5, TOperand6, TOperand7>>(
                    new Tuple<TOperand1, TOperand2, TOperand3, TOperand4, TOperand5, TOperand6, TOperand7>(
                        result1.Value.Result,
                        result2.Value.Result,
                        result3.Value.Result,
                        result4.Value.Result,
                        result5.Value.Result,
                        result6.Value.Result,
                        result7.Value.Result
                    ),
                    sequence,
                    context,
                    result1.Value.Start,
                    result7.Value.End,
                    new IParseResult[]
                    {
                        result1.Value,
                        result2.Value,
                        result3.Value,
                        result4.Value,
                        result5.Value,
                        result6.Value,
                        result7.Value
                    }
                )
            );		
		}
        public MayBe<IParseResult<Tuple<TOperand1, TOperand2, TOperand3, TOperand4, TOperand5, TOperand6, TOperand7, TOperand8>>> Visit_Sequence<TOperand1, TOperand2, TOperand3, TOperand4, TOperand5, TOperand6, TOperand7, TOperand8>(int position, Sequence<TOperand1, TOperand2, TOperand3, TOperand4, TOperand5, TOperand6, TOperand7, TOperand8> sequence)
		{
            var Nothing = MayBe<IParseResult<Tuple<TOperand1, TOperand2, TOperand3, TOperand4, TOperand5, TOperand6, TOperand7, TOperand8>>>.Nothing;
            //Operand 1
            var result1 = sequence.Operand1.ParseAt(this, position);
            if (result1 == MayBe<IParseResult<TOperand1>>.Nothing)
                return Nothing;
            position += result1.Value.GetLength();

            //Operand 2
            var result2 = sequence.Operand2.ParseAt(this, position);
            if (result2 == MayBe<IParseResult<TOperand2>>.Nothing)
                return Nothing;
            position += result2.Value.GetLength();

            //Operand 3
            var result3 = sequence.Operand3.ParseAt(this, position);
            if (result3 == MayBe<IParseResult<TOperand3>>.Nothing)
                return Nothing;
            position += result3.Value.GetLength();

            //Operand 4
            var result4 = sequence.Operand4.ParseAt(this, position);
            if (result4 == MayBe<IParseResult<TOperand4>>.Nothing)
                return Nothing;
            position += result4.Value.GetLength();

            //Operand 5
            var result5 = sequence.Operand5.ParseAt(this, position);
            if (result5 == MayBe<IParseResult<TOperand5>>.Nothing)
                return Nothing;
            position += result5.Value.GetLength();

            //Operand 6
            var result6 = sequence.Operand6.ParseAt(this, position);
            if (result6 == MayBe<IParseResult<TOperand6>>.Nothing)
                return Nothing;
            position += result6.Value.GetLength();

            //Operand 7
            var result7 = sequence.Operand7.ParseAt(this, position);
            if (result7 == MayBe<IParseResult<TOperand7>>.Nothing)
                return Nothing;
            position += result7.Value.GetLength();

            //Operand 8
            var result8 = sequence.Operand8.ParseAt(this, position);
            if (result8 == MayBe<IParseResult<TOperand8>>.Nothing)
                return Nothing;
            position += result8.Value.GetLength();

	
            return MayBe<IParseResult<Tuple<TOperand1, TOperand2, TOperand3, TOperand4, TOperand5, TOperand6, TOperand7, TOperand8>>>.Some(
                new ParseResult<Tuple<TOperand1, TOperand2, TOperand3, TOperand4, TOperand5, TOperand6, TOperand7, TOperand8>>(
                    new Tuple<TOperand1, TOperand2, TOperand3, TOperand4, TOperand5, TOperand6, TOperand7, TOperand8>(
                        result1.Value.Result,
                        result2.Value.Result,
                        result3.Value.Result,
                        result4.Value.Result,
                        result5.Value.Result,
                        result6.Value.Result,
                        result7.Value.Result,
                        result8.Value.Result
                    ),
                    sequence,
                    context,
                    result1.Value.Start,
                    result8.Value.End,
                    new IParseResult[]
                    {
                        result1.Value,
                        result2.Value,
                        result3.Value,
                        result4.Value,
                        result5.Value,
                        result6.Value,
                        result7.Value,
                        result8.Value
                    }
                )
            );		
		}
    }

    public class Sequence<TOperand1>: IGrammarExpression<Tuple<TOperand1>>
    {
        public Sequence(IGrammarExpression<TOperand1> operand1)
        {
			this.Operand1 = operand1;
        }

		public IGrammarExpression<TOperand1> Operand1 { get; }

        public MayBe<IParseResult<Tuple<TOperand1>>> ParseAt(IParserVisitor visitor, int position)
        {
            return visitor.Visit_Sequence(position, this);
        }
    }
    public class Sequence<TOperand1, TOperand2>: IGrammarExpression<Tuple<TOperand1, TOperand2>>
    {
        public Sequence(IGrammarExpression<TOperand1> operand1, IGrammarExpression<TOperand2> operand2)
        {
			this.Operand1 = operand1;
			this.Operand2 = operand2;
        }

		public IGrammarExpression<TOperand1> Operand1 { get; }
		public IGrammarExpression<TOperand2> Operand2 { get; }

        public MayBe<IParseResult<Tuple<TOperand1, TOperand2>>> ParseAt(IParserVisitor visitor, int position)
        {
            return visitor.Visit_Sequence(position, this);
        }
    }
    public class Sequence<TOperand1, TOperand2, TOperand3>: IGrammarExpression<Tuple<TOperand1, TOperand2, TOperand3>>
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

        public MayBe<IParseResult<Tuple<TOperand1, TOperand2, TOperand3>>> ParseAt(IParserVisitor visitor, int position)
        {
            return visitor.Visit_Sequence(position, this);
        }
    }
    public class Sequence<TOperand1, TOperand2, TOperand3, TOperand4>: IGrammarExpression<Tuple<TOperand1, TOperand2, TOperand3, TOperand4>>
    {
        public Sequence(IGrammarExpression<TOperand1> operand1, IGrammarExpression<TOperand2> operand2, IGrammarExpression<TOperand3> operand3, IGrammarExpression<TOperand4> operand4)
        {
			this.Operand1 = operand1;
			this.Operand2 = operand2;
			this.Operand3 = operand3;
			this.Operand4 = operand4;
        }

		public IGrammarExpression<TOperand1> Operand1 { get; }
		public IGrammarExpression<TOperand2> Operand2 { get; }
		public IGrammarExpression<TOperand3> Operand3 { get; }
		public IGrammarExpression<TOperand4> Operand4 { get; }

        public MayBe<IParseResult<Tuple<TOperand1, TOperand2, TOperand3, TOperand4>>> ParseAt(IParserVisitor visitor, int position)
        {
            return visitor.Visit_Sequence(position, this);
        }
    }
    public class Sequence<TOperand1, TOperand2, TOperand3, TOperand4, TOperand5>: IGrammarExpression<Tuple<TOperand1, TOperand2, TOperand3, TOperand4, TOperand5>>
    {
        public Sequence(IGrammarExpression<TOperand1> operand1, IGrammarExpression<TOperand2> operand2, IGrammarExpression<TOperand3> operand3, IGrammarExpression<TOperand4> operand4, IGrammarExpression<TOperand5> operand5)
        {
			this.Operand1 = operand1;
			this.Operand2 = operand2;
			this.Operand3 = operand3;
			this.Operand4 = operand4;
			this.Operand5 = operand5;
        }

		public IGrammarExpression<TOperand1> Operand1 { get; }
		public IGrammarExpression<TOperand2> Operand2 { get; }
		public IGrammarExpression<TOperand3> Operand3 { get; }
		public IGrammarExpression<TOperand4> Operand4 { get; }
		public IGrammarExpression<TOperand5> Operand5 { get; }

        public MayBe<IParseResult<Tuple<TOperand1, TOperand2, TOperand3, TOperand4, TOperand5>>> ParseAt(IParserVisitor visitor, int position)
        {
            return visitor.Visit_Sequence(position, this);
        }
    }
    public class Sequence<TOperand1, TOperand2, TOperand3, TOperand4, TOperand5, TOperand6>: IGrammarExpression<Tuple<TOperand1, TOperand2, TOperand3, TOperand4, TOperand5, TOperand6>>
    {
        public Sequence(IGrammarExpression<TOperand1> operand1, IGrammarExpression<TOperand2> operand2, IGrammarExpression<TOperand3> operand3, IGrammarExpression<TOperand4> operand4, IGrammarExpression<TOperand5> operand5, IGrammarExpression<TOperand6> operand6)
        {
			this.Operand1 = operand1;
			this.Operand2 = operand2;
			this.Operand3 = operand3;
			this.Operand4 = operand4;
			this.Operand5 = operand5;
			this.Operand6 = operand6;
        }

		public IGrammarExpression<TOperand1> Operand1 { get; }
		public IGrammarExpression<TOperand2> Operand2 { get; }
		public IGrammarExpression<TOperand3> Operand3 { get; }
		public IGrammarExpression<TOperand4> Operand4 { get; }
		public IGrammarExpression<TOperand5> Operand5 { get; }
		public IGrammarExpression<TOperand6> Operand6 { get; }

        public MayBe<IParseResult<Tuple<TOperand1, TOperand2, TOperand3, TOperand4, TOperand5, TOperand6>>> ParseAt(IParserVisitor visitor, int position)
        {
            return visitor.Visit_Sequence(position, this);
        }
    }
    public class Sequence<TOperand1, TOperand2, TOperand3, TOperand4, TOperand5, TOperand6, TOperand7>: IGrammarExpression<Tuple<TOperand1, TOperand2, TOperand3, TOperand4, TOperand5, TOperand6, TOperand7>>
    {
        public Sequence(IGrammarExpression<TOperand1> operand1, IGrammarExpression<TOperand2> operand2, IGrammarExpression<TOperand3> operand3, IGrammarExpression<TOperand4> operand4, IGrammarExpression<TOperand5> operand5, IGrammarExpression<TOperand6> operand6, IGrammarExpression<TOperand7> operand7)
        {
			this.Operand1 = operand1;
			this.Operand2 = operand2;
			this.Operand3 = operand3;
			this.Operand4 = operand4;
			this.Operand5 = operand5;
			this.Operand6 = operand6;
			this.Operand7 = operand7;
        }

		public IGrammarExpression<TOperand1> Operand1 { get; }
		public IGrammarExpression<TOperand2> Operand2 { get; }
		public IGrammarExpression<TOperand3> Operand3 { get; }
		public IGrammarExpression<TOperand4> Operand4 { get; }
		public IGrammarExpression<TOperand5> Operand5 { get; }
		public IGrammarExpression<TOperand6> Operand6 { get; }
		public IGrammarExpression<TOperand7> Operand7 { get; }

        public MayBe<IParseResult<Tuple<TOperand1, TOperand2, TOperand3, TOperand4, TOperand5, TOperand6, TOperand7>>> ParseAt(IParserVisitor visitor, int position)
        {
            return visitor.Visit_Sequence(position, this);
        }
    }
    public class Sequence<TOperand1, TOperand2, TOperand3, TOperand4, TOperand5, TOperand6, TOperand7, TOperand8>: IGrammarExpression<Tuple<TOperand1, TOperand2, TOperand3, TOperand4, TOperand5, TOperand6, TOperand7, TOperand8>>
    {
        public Sequence(IGrammarExpression<TOperand1> operand1, IGrammarExpression<TOperand2> operand2, IGrammarExpression<TOperand3> operand3, IGrammarExpression<TOperand4> operand4, IGrammarExpression<TOperand5> operand5, IGrammarExpression<TOperand6> operand6, IGrammarExpression<TOperand7> operand7, IGrammarExpression<TOperand8> operand8)
        {
			this.Operand1 = operand1;
			this.Operand2 = operand2;
			this.Operand3 = operand3;
			this.Operand4 = operand4;
			this.Operand5 = operand5;
			this.Operand6 = operand6;
			this.Operand7 = operand7;
			this.Operand8 = operand8;
        }

		public IGrammarExpression<TOperand1> Operand1 { get; }
		public IGrammarExpression<TOperand2> Operand2 { get; }
		public IGrammarExpression<TOperand3> Operand3 { get; }
		public IGrammarExpression<TOperand4> Operand4 { get; }
		public IGrammarExpression<TOperand5> Operand5 { get; }
		public IGrammarExpression<TOperand6> Operand6 { get; }
		public IGrammarExpression<TOperand7> Operand7 { get; }
		public IGrammarExpression<TOperand8> Operand8 { get; }

        public MayBe<IParseResult<Tuple<TOperand1, TOperand2, TOperand3, TOperand4, TOperand5, TOperand6, TOperand7, TOperand8>>> ParseAt(IParserVisitor visitor, int position)
        {
            return visitor.Visit_Sequence(position, this);
        }
    }
}

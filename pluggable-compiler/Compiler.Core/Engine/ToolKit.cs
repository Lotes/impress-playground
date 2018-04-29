using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Core.Engine
{
    public class ToolKit
    {
        public ToolKit()
        {
            CoercionRules = new Dictionary<Type, LinkedList<ICoercionOperation>>();
            UnaryOperators = new SortedSet<UnaryOperator>();
            UnaryOperations = new Dictionary<UnaryOperator, LinkedList<IUnaryOperation>>();
            BinaryOperators = new SortedSet<BinaryOperator>();
            BinaryOperations = new Dictionary<BinaryOperator, LinkedList<IBinaryOperation>>();
            Literals = new SortedSet<Literal>();
            WhiteSpaces = new SortedSet<WhiteSpace>();
        }

        public Dictionary<Type, LinkedList<ICoercionOperation>> CoercionRules { get; }
        public SortedSet<UnaryOperator> UnaryOperators { get; }
        public Dictionary<UnaryOperator, LinkedList<IUnaryOperation>> UnaryOperations { get; }
        public SortedSet<BinaryOperator> BinaryOperators { get; }
        public Dictionary<BinaryOperator, LinkedList<IBinaryOperation>> BinaryOperations { get; }
        public SortedSet<Literal> Literals { get; }
        public SortedSet<WhiteSpace> WhiteSpaces { get; }
    }
}

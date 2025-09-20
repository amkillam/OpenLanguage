using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.SpreadsheetML.Formula.Ast
{
    public class FunctionCallNode : ExpressionNode
    {
        public ExpressionNode FunctionReference { get; set; }
        public List<ExpressionNode> Arguments { get; }

        public override int Precedence => Ast.Precedence.Primary;

        public FunctionCallNode(
            ExpressionNode functionIdentifier,
            List<ExpressionNode> arguments,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            FunctionReference = functionIdentifier;
            Arguments = arguments;
            Arguments.TrimExcess();
        }

        public override string ToRawString() =>
            FunctionReference.ToString()
            + "("
            + string.Join(",", Arguments.Select(a => a.ToString()))
            + ")";

        public override IEnumerable<O> Children<O>()
        {
            if (FunctionReference is O funcImp)
            {
                yield return funcImp;
            }
            foreach (ExpressionNode child in Arguments)
            {
                if (child is O childImp)
                {
                    yield return childImp;
                }
            }
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            ExpressionNode? current = null;
            if (replacement is ExpressionNode expr)
            {
                if (index == 0)
                {
                    current = FunctionReference;
                    FunctionReference = expr;
                }

                int argIdx = index - 1;
                if (argIdx < Arguments.Count)
                {
                    current = Arguments[argIdx];
                    Arguments[argIdx] = expr;
                }
            }
            return current;
        }
    }
}

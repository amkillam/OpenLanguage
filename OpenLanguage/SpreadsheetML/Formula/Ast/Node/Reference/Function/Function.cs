using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenLanguage.SpreadsheetML.Formula.Ast
{
    public class FunctionCallNode : ExpressionNode
    {
        public ExpressionNode FunctionIdentifier { get; set; }
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
            FunctionIdentifier = functionIdentifier;
            Arguments = arguments;
        }

        public override string ToRawString() =>
            FunctionIdentifier.ToString()
            + "("
            + string.Join(",", Arguments.Select(a => a.ToString()))
            + ")";

        public override IEnumerable<O> Children<O>()
        {
            if (FunctionIdentifier is O funcImp)
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
            if (replacement is ExpressionNode expr)
            {
                if (index == 0)
                {
                    ExpressionNode currentIdent = FunctionIdentifier;
                    FunctionIdentifier = expr;
                    return currentIdent;
                }

                int argIdx = index - 1;
                if (argIdx < Arguments.Count)
                {
                    ExpressionNode currentArgNode = Arguments[argIdx];
                    Arguments[argIdx] = expr;
                    return currentArgNode;
                }
            }
            return null;
        }
    }
}

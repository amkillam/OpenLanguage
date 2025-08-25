using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenLanguage.SpreadsheetML.Formula.Ast
{
    public class FunctionCallNode : ExpressionNode
    {
        public ExpressionNode FunctionIdentifier { get; set; }
        public List<Node> WsAfterIdentifier { get; set; }
        public List<Node> WsAfterOpenParen { get; set; }
        public List<ExpressionNode> Arguments { get; }
        public List<Node> WsBeforeCloseParen { get; set; }

        public override int Precedence => Ast.Precedence.Primary;

        public FunctionCallNode(
            ExpressionNode functionIdentifier,
            List<Node>? wsAfterIdentifier,
            List<Node>? wsAfterOpenParen,
            List<ExpressionNode> arguments,
            List<Node>? wsBeforeCloseParen,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            FunctionIdentifier = functionIdentifier;
            WsAfterIdentifier = wsAfterIdentifier ?? new List<Node>();
            WsAfterOpenParen = wsAfterOpenParen ?? new List<Node>();
            Arguments = arguments;
            WsBeforeCloseParen = wsBeforeCloseParen ?? new List<Node>();
        }

        public override string ToRawString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(FunctionIdentifier.ToString());
            builder.Append(string.Concat(WsAfterIdentifier.Select(w => w.ToString())));
            builder.Append('(');
            builder.Append(string.Concat(WsAfterOpenParen.Select(w => w.ToString())));

            builder.Append(string.Join(",", Arguments.Select(a => a.ToString())));

            builder.Append(string.Concat(WsBeforeCloseParen.Select(w => w.ToString())));
            builder.Append(')');
            return builder.ToString();
        }

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

using System.Collections.Generic;

namespace OpenLanguage.WordprocessingML.Ast
{
    public class ParenthesizedExpressionNode : ExpressionNode
    {
        public LeftParenNode LeftParen { get; set; }
        public ExpressionNode Inner { get; set; }
        public RightParenNode RightParen { get; set; }

        public ParenthesizedExpressionNode(
            LeftParenNode left,
            ExpressionNode inner,
            RightParenNode right,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            LeftParen = left;
            Inner = inner;
            RightParen = right;
        }

        public override string ToRawString() =>
            LeftParen.ToString() + Inner.ToString() + RightParen.ToString();

        public override IEnumerable<O> Children<O>()
        {
            if (LeftParen is O o1)
            {
                yield return o1;
            }
            if (Inner is O o2)
            {
                yield return o2;
            }
            if (RightParen is O o3)
            {
                yield return o3;
            }
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;
            if (index == 0 && replacement is LeftParenNode lpn)
            {
                current = LeftParen;
                LeftParen = lpn;
            }
            else if (index == 1 && replacement is ExpressionNode expr)
            {
                current = Inner;
                Inner = expr;
            }
            else if (index == 2 && replacement is RightParenNode rpn)
            {
                current = RightParen;
                RightParen = rpn;
            }
            return current;
        }
    }
}

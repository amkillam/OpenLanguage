using System.Collections.Generic;

namespace OpenLanguage.WordprocessingML.Ast
{
    public class AndFunctionCallNode : FunctionCallNode
    {
        public ExpressionNode Left { get; set; }
        public CommaNode Separator { get; set; }
        public ExpressionNode Right { get; set; }

        public AndFunctionCallNode(
            FunctionNode functionHead,
            LeftParenNode? leftParen,
            ExpressionNode left,
            CommaNode separator,
            ExpressionNode right,
            RightParenNode? rightParen,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(functionHead, leftParen, rightParen, leadingWhitespace, trailingWhitespace)
        {
            Left = left;
            Separator = separator;
            Right = right;
        }

        public override string ToRawString() =>
            FunctionHead.ToString()
            + (LeftParen?.ToString() ?? string.Empty)
            + Left.ToString()
            + Separator.ToString()
            + Right.ToString()
            + (RightParen?.ToString() ?? string.Empty);

        public override IEnumerable<O> Children<O>()
        {
            if (FunctionHead is O fh)
            {
                yield return fh;
            }
            if (LeftParen is O lp)
            {
                yield return lp;
            }
            if (Left is O l)
            {
                yield return l;
            }
            if (Separator is O s)
            {
                yield return s;
            }
            if (Right is O r)
            {
                yield return r;
            }
            if (RightParen is O rp)
            {
                yield return rp;
            }
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;
            switch (index)
            {
                case 0 when replacement is FunctionNode fh:
                {
                    current = FunctionHead;
                    FunctionHead = fh;
                    break;
                }
                case 1 when replacement is LeftParenNode lp:
                {
                    current = LeftParen;
                    LeftParen = lp;
                    break;
                }
                case 2 when replacement is ExpressionNode l:
                {
                    current = Left;
                    Left = l;
                    break;
                }
                case 3 when replacement is CommaNode s:
                {
                    current = Separator;
                    Separator = s;
                    break;
                }
                case 4 when replacement is ExpressionNode r:
                {
                    current = Right;
                    Right = r;
                    break;
                }
                case 5 when replacement is RightParenNode rp:
                {
                    current = RightParen;
                    RightParen = rp;
                    break;
                }
            }
            return current;
        }
    }
}

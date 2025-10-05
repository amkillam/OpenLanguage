using System.Collections.Generic;

namespace OpenLanguage.WordprocessingML.Ast
{
    public class BracedExpressionNode : ExpressionNode
    {
        public LeftBraceNode Left { get; set; }
        public ExpressionNode Inner { get; set; }
        public RightBraceNode Right { get; set; }

        public BracedExpressionNode(
            LeftBraceNode left,
            ExpressionNode inner,
            RightBraceNode right,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Left = left;
            Inner = inner;
            Right = right;
        }

        public override string ToRawString() =>
            Left.ToString() + Inner.ToString() + Right.ToString();

        public override IEnumerable<O> Children<O>()
        {
            if (Left is O oLeft)
            {
                yield return oLeft;
            }
            if (Inner is O oInner)
            {
                yield return oInner;
            }
            if (Right is O oRight)
            {
                yield return oRight;
            }
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;

            switch (index)
            {
                case 0:
                    if (replacement is LeftBraceNode lb)
                    {
                        current = Left;
                        Left = lb;
                    }
                    break;
                case 1:
                    if (replacement is ExpressionNode inner)
                    {
                        current = Inner;
                        Inner = inner;
                    }
                    break;
                case 2:
                    if (replacement is RightBraceNode rb)
                    {
                        current = Right;
                        Right = rb;
                    }
                    break;
            }

            return current;
        }
    }
}

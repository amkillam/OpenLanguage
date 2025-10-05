using System.Collections.Generic;

namespace OpenLanguage.WordprocessingML.Ast
{
    public class DelimitedNodes<T, D, U> : ExpressionNode
        where T : ExpressionNode
        where D : ExpressionNode
        where U : ExpressionNode
    {
        public T Left { get; set; }
        public D Sep { get; set; }
        public U Right { get; set; }

        public DelimitedNodes(
            T left,
            D sep,
            U right,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Left = left;
            Sep = sep;
            Right = right;
        }

        public override string ToRawString() => Left.ToString() + Sep.ToString() + Right.ToString();

        public override IEnumerable<O> Children<O>()
        {
            if (Left is O o1)
            {
                yield return o1;
            }
            if (Sep is O o2)
            {
                yield return o2;
            }
            if (Right is O o3)
            {
                yield return o3;
            }
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;
            if (index == 0 && replacement is T l)
            {
                current = Left;
                Left = l;
            }
            else if (index == 1 && replacement is D s)
            {
                current = Sep;
                Sep = s;
            }
            else if (index == 2 && replacement is U r)
            {
                current = Right;
                Right = r;
            }
            return current;
        }
    }

    public class ColonDelimitedNodes<T, U> : DelimitedNodes<T, ColonNode, U>
        where T : ExpressionNode
        where U : ExpressionNode
    {
        public ColonDelimitedNodes(
            T left,
            ColonNode sep,
            U right,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(left, sep, right, leadingWhitespace, trailingWhitespace) { }
    }

    public class CommaDelimitedNodes<T, U> : DelimitedNodes<T, CommaNode, U>
        where T : ExpressionNode
        where U : ExpressionNode
    {
        public CommaDelimitedNodes(
            T left,
            CommaNode sep,
            U right,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(left, sep, right, leadingWhitespace, trailingWhitespace) { }
    }

    public class BracketedExpressionNode : ExpressionNode
    {
        public LeftBracketNode LeftBracket { get; set; }
        public ExpressionNode Inner { get; set; }
        public RightBracketNode RightBracket { get; set; }

        public BracketedExpressionNode(
            LeftBracketNode left,
            ExpressionNode inner,
            RightBracketNode right,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            LeftBracket = left;
            Inner = inner;
            RightBracket = right;
        }

        public override string ToRawString() =>
            LeftBracket.ToString() + Inner.ToString() + RightBracket.ToString();

        public override IEnumerable<O> Children<O>()
        {
            if (LeftBracket is O oLeft)
            {
                yield return oLeft;
            }
            if (Inner is O oInner)
            {
                yield return oInner;
            }
            if (RightBracket is O oRight)
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
                    if (replacement is LeftBracketNode lb)
                    {
                        current = LeftBracket;
                        LeftBracket = lb;
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
                    if (replacement is RightBracketNode rb)
                    {
                        current = RightBracket;
                        RightBracket = rb;
                    }
                    break;
            }

            return current;
        }
    }
}

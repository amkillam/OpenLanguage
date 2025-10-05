using System.Collections.Generic;

namespace OpenLanguage.WordprocessingML.Ast
{
    public class TrueFunctionCallNode : FunctionCallNode
    {
        public TrueFunctionCallNode(
            FunctionNode functionHead,
            LeftParenNode? leftParen = null,
            RightParenNode? rightParen = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(functionHead, leftParen, rightParen, leadingWhitespace, trailingWhitespace) { }

        public override string ToRawString() =>
            FunctionHead.ToString()
            + (LeftParen?.ToString() ?? string.Empty)
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
                case 1:
                {
                    if (replacement is LeftParenNode lp)
                    {
                        current = LeftParen;
                        LeftParen = lp;
                    }
                    else if (replacement is null)
                    {
                        current = LeftParen;
                        LeftParen = null;
                    }
                    break;
                }
                case 2:
                {
                    if (replacement is RightParenNode rp)
                    {
                        current = RightParen;
                        RightParen = rp;
                    }
                    else if (replacement is null)
                    {
                        current = RightParen;
                        RightParen = null;
                    }
                    break;
                }
            }
            return current;
        }
    }
}

using System.Collections.Generic;

namespace OpenLanguage.WordprocessingML.Ast
{
    public class DefinedFunctionCallNode : FunctionCallNode
    {
        public ExpressionNode Argument { get; set; }

        public DefinedFunctionCallNode(
            FunctionNode functionHead,
            LeftParenNode leftParen,
            ExpressionNode arg,
            RightParenNode rightParen,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(functionHead, leftParen, rightParen, leadingWhitespace, trailingWhitespace)
        {
            Argument = arg;
        }

        public override string ToRawString() =>
            FunctionHead.ToString()
            + (LeftParen?.ToString() ?? string.Empty)
            + Argument.ToString()
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
            if (Argument is O arg)
            {
                yield return arg;
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
                case 2 when replacement is ExpressionNode arg:
                {
                    current = Argument;
                    Argument = arg;
                    break;
                }
                case 3 when replacement is RightParenNode rp:
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

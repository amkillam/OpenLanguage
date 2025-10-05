using System.Collections.Generic;

namespace OpenLanguage.WordprocessingML.Ast
{
    public class AverageFunctionCallNode : FunctionCallNode
    {
        public ExpressionListNode ArgumentList { get; set; }

        public AverageFunctionCallNode(
            FunctionNode functionHead,
            LeftParenNode leftParen,
            ExpressionListNode argumentList,
            RightParenNode rightParen,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(functionHead, leftParen, rightParen, leadingWhitespace, trailingWhitespace)
        {
            ArgumentList = argumentList;
        }

        public override string ToRawString()
        {
            System.Text.StringBuilder sb = new();
            sb.Append(FunctionHead.ToString());
            sb.Append(LeftParen?.ToString());
            sb.Append(ArgumentList.ToString());
            sb.Append(RightParen?.ToString());
            return sb.ToString();
        }

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
            if (ArgumentList is O al)
            {
                yield return al;
            }
            if (RightParen is O rp)
            {
                yield return rp;
            }
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? old = null;
            switch (index)
            {
                case 0:
                {
                    if (replacement is FunctionNode fn)
                    {
                        old = FunctionHead;
                        FunctionHead = fn;
                    }
                    break;
                }
                case 1:
                {
                    if (replacement is LeftParenNode lpn)
                    {
                        old = LeftParen;
                        LeftParen = lpn;
                    }
                    break;
                }
                case 2:
                {
                    if (replacement is ExpressionListNode eln)
                    {
                        old = ArgumentList;
                        ArgumentList = eln;
                    }
                    break;
                }
                case 3:
                {
                    if (replacement is RightParenNode rpn)
                    {
                        old = RightParen;
                        RightParen = rpn;
                    }
                    break;
                }
            }
            return old;
        }
    }
}

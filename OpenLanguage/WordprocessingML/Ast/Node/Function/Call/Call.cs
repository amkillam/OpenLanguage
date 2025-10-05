using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.WordprocessingML.Ast
{
    public abstract class FunctionCallNode : ExpressionNode
    {
        public FunctionNode FunctionHead { get; set; }
        public LeftParenNode? LeftParen { get; set; }
        public RightParenNode? RightParen { get; set; }

        public FunctionCallNode(
            FunctionNode functionHead,
            LeftParenNode? leftParen,
            RightParenNode? rightParen,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            FunctionHead = functionHead;
            LeftParen = leftParen;
            RightParen = rightParen;
        }
    }
}

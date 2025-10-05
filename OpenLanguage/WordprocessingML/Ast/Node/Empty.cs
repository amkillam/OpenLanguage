using System.Collections.Generic;

namespace OpenLanguage.WordprocessingML.Ast
{
    public class EmptyExpressionNode : ExpressionNode
    {
        public EmptyExpressionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace) { }

        public override string ToRawString() => string.Empty;

        public override IEnumerable<O> Children<O>()
        {
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement) => null;
    }
}

using System.Collections.Generic;

namespace OpenLanguage.WordprocessingML.Ast
{
    /// <summary>
    /// Represents a text element in a template.
    /// </summary>
    public class TextElementNode : ExpressionNode
    {
        public string Text { get; set; }

        public TextElementNode(
            string text,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Text = text;
        }

        public override string ToRawString() => Text;

        public override IEnumerable<O> Children<O>()
        {
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            return null;
        }
    }
}

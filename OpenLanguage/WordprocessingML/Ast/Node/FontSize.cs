using System.Collections.Generic;

namespace OpenLanguage.WordprocessingML.Ast
{
    public class FontSizeNode : ExpressionNode
    {
        public DocumentFormat.OpenXml.Wordprocessing.FontSize Value { get; set; }
        private readonly string _raw;

        public FontSizeNode(
            DocumentFormat.OpenXml.Wordprocessing.FontSize value,
            string raw,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Value = value;
            _raw = raw;
        }

        public override string ToRawString() => _raw;

        public override IEnumerable<O> Children<O>()
        {
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement) => null;
    }
}

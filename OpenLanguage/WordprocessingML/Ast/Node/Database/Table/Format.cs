using System.Collections.Generic;

namespace OpenLanguage.WordprocessingML.Ast
{
    public class DatabaseTableFormatNode : ExpressionNode
    {
        private DatabaseTableFormat Value { get; set; }
        private string? Raw { get; set; }

        public DatabaseTableFormatNode(
            DatabaseTableFormat value,
            string? raw = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Value = value;
            Raw = raw;
        }

        public override string ToRawString() => Raw ?? ((int)Value).ToString();

        public override IEnumerable<O> Children<O>()
        {
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement) => null;
    }
}

using System.Collections.Generic;

namespace OpenLanguage.WordprocessingML.Ast
{
    public abstract class RelativeCellRangeKeyword : CellReferenceNode
    {
        public StringLiteralNode Value { get; set; }

        protected RelativeCellRangeKeyword(
            StringLiteralNode value,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Value = value;
        }

        public override string ToRawString() => Value.ToString();

        public override IEnumerable<O> Children<O>()
        {
            if (Value is O o)
            {
                yield return o;
            }
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            if (index == 0 && replacement is StringLiteralNode sln)
            {
                Value = sln;
                return Value;
            }
            return null;
        }
    }

    public class RelativeCellRangeKeywordLeft : RelativeCellRangeKeyword
    {
        public RelativeCellRangeKeywordLeft(
            StringLiteralNode value,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(value, leadingWhitespace, trailingWhitespace) { }
    }

    public class RelativeCellRangeKeywordRight : RelativeCellRangeKeyword
    {
        public RelativeCellRangeKeywordRight(
            StringLiteralNode value,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(value, leadingWhitespace, trailingWhitespace) { }
    }

    public class RelativeCellRangeKeywordAbove : RelativeCellRangeKeyword
    {
        public RelativeCellRangeKeywordAbove(
            StringLiteralNode value,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(value, leadingWhitespace, trailingWhitespace) { }
    }

    public class RelativeCellRangeKeywordBelow : RelativeCellRangeKeyword
    {
        public RelativeCellRangeKeywordBelow(
            StringLiteralNode value,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(value, leadingWhitespace, trailingWhitespace) { }
    }
}

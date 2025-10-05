using System.Collections.Generic;
using OpenLanguage.Utils;

namespace OpenLanguage.WordprocessingML.Ast
{
    public abstract class A1ColumnNode : ColumnNode<ulong>
    {
        public string? Raw { get; set; }

        public A1ColumnNode(
            ulong val,
            string raw,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(val, leadingWhitespace, trailingWhitespace)
        {
            Raw = raw;
        }

        public A1ColumnNode(
            ulong val,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(val, leadingWhitespace, trailingWhitespace)
        {
            Raw = null;
        }

        public override string ToRawString() =>
            Raw?.ToString()
            ?? new AlphabeticHexevigesimalProvider().Format(
                "X",
                ColumnSpecifier,
                new AlphabeticHexevigesimalProvider()
            );
    }

    public class A1AbsoluteColumnNode : A1ColumnNode
    {
        public A1AbsoluteColumnNode(
            ulong val,
            string raw,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(val, raw, leadingWhitespace, trailingWhitespace) { }

        public A1AbsoluteColumnNode(
            ulong val,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(val, leadingWhitespace, trailingWhitespace) { }
    }
}

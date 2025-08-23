using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.SpreadsheetML.Formula.Ast
{
    public abstract class R1C1ColumnNode : ColumnNode<Int64>
    {
        public R1C1ColumnNode(
            Int64 val,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(val, leadingWhitespace, trailingWhitespace) { }

        public override string ToRawString() => "C" + base.ToString();
    }

    public class R1C1AbsoluteColumnNode : R1C1ColumnNode
    {
        public R1C1AbsoluteColumnNode(
            Int64 val,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(val, leadingWhitespace, trailingWhitespace) { }
    }

    public class R1C1RelativeColumnNode : R1C1ColumnNode
    {
        public R1C1RelativeColumnNode(
            Int64 val,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(val, leadingWhitespace, trailingWhitespace) { }

        public override string ToRawString() => "C" + "[" + base.ToString() + "]";
    }

    public abstract class R1C1RowNode : RowNode<Int64>
    {
        public R1C1RowNode(
            Int64 val,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(val, leadingWhitespace, trailingWhitespace) { }

        public override string ToRawString() => "R" + base.ToString();
    }

    public class R1C1AbsoluteRowNode : R1C1RowNode
    {
        public R1C1AbsoluteRowNode(
            Int64 val,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(val, leadingWhitespace, trailingWhitespace) { }
    }

    public class R1C1RelativeRowNode : R1C1RowNode
    {
        public R1C1RelativeRowNode(
            Int64 val,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(val, leadingWhitespace, trailingWhitespace) { }

        public override string ToRawString() => "R" + "[" + base.ToString() + "]";
    }

    public class R1C1CellNode : CellNode<R1C1RowNode, Int64, R1C1ColumnNode, Int64>
    {
        public R1C1CellNode(R1C1RowNode row, R1C1ColumnNode column)
            : base(row, column) { }

        public override string ToRawString() => Row.ToString() + Column.ToString();
    }
}

using System.Collections.Generic;

namespace OpenLanguage.SpreadsheetML.Formula.Ast
{
    public abstract class R1C1ColumnNode : ColumnNode<long>
    {
        public R1C1ColumnNode(
            long val,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(val, leadingWhitespace, trailingWhitespace) { }

        public override string ValueString() => "C" + base.ValueString();
    }

    public class R1C1AbsoluteColumnNode : R1C1ColumnNode
    {
        public R1C1AbsoluteColumnNode(
            long val,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(val, leadingWhitespace, trailingWhitespace) { }
    }

    public class R1C1RelativeColumnNode : R1C1ColumnNode
    {
        public R1C1RelativeColumnNode(
            long val,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(val, leadingWhitespace, trailingWhitespace) { }

        public override string ValueString() =>
            "C"
            + "["
            + base.ColumnSpecifier.ToString("D", System.Globalization.CultureInfo.InvariantCulture)
            + "]";
    }

    public class R1C1CurrentColumnNode : R1C1ColumnNode
    {
        public R1C1CurrentColumnNode(
            long val = 0,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(val, leadingWhitespace, trailingWhitespace) { }

        public override string ValueString() => "C";
    }

    public abstract class R1C1RowNode : RowNode<long>
    {
        public R1C1RowNode(
            long val,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(val, leadingWhitespace, trailingWhitespace) { }

        public override string ValueString() => "R" + base.ValueString();
    }

    public class R1C1AbsoluteRowNode : R1C1RowNode
    {
        public R1C1AbsoluteRowNode(
            long val,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(val, leadingWhitespace, trailingWhitespace) { }
    }

    public class R1C1RelativeRowNode : R1C1RowNode
    {
        public R1C1RelativeRowNode(
            long val,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(val, leadingWhitespace, trailingWhitespace) { }

        public override string ValueString() =>
            "R"
            + "["
            + base.RowSpecifier.ToString("D", System.Globalization.CultureInfo.InvariantCulture)
            + "]";
    }

    public class R1C1CurrentRowNode : R1C1RowNode
    {
        public R1C1CurrentRowNode(
            long val = 0,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(val, leadingWhitespace, trailingWhitespace) { }

        public override string ValueString() => "R";
    }

    public class R1C1CellNode : CellNode<R1C1RowNode, long, R1C1ColumnNode, long>
    {
        public R1C1CellNode(R1C1RowNode row, R1C1ColumnNode column)
            : base(row, column) { }

        public override string ValueString() => Row.ValueString() + Column.ValueString();
    }
}

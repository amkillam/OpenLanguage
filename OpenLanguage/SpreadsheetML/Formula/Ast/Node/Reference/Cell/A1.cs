using System;
using System.Collections.Generic;
using OpenLanguage.Utils;

namespace OpenLanguage.SpreadsheetML.Formula.Ast
{
    public abstract class A1ColumnNode : ColumnNode<UInt64>
    {
        public A1ColumnNode(
            UInt64 val,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(val, leadingWhitespace, trailingWhitespace) { }

        public override string ToRawString() =>
            new AlphabeticHexevigesimalProvider().Format(
                "AH",
                ColumnSpecifier,
                new AlphabeticHexevigesimalProvider()
            );
    }

    public class A1AbsoluteColumnNode : A1ColumnNode
    {
        public A1AbsoluteColumnNode(
            UInt64 val,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(val, leadingWhitespace, trailingWhitespace) { }

        public override string ToRawString() => "$" + base.ToRawString();
    }

    public class A1RelativeColumnNode : A1ColumnNode
    {
        public A1RelativeColumnNode(
            UInt64 val,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(val, leadingWhitespace, trailingWhitespace) { }
    }

    public abstract class A1RowNode : RowNode<UInt64>
    {
        public A1RowNode(
            UInt64 val,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(val, leadingWhitespace, trailingWhitespace) { }
    }

    public class A1ColumnOnlyNode : A1ColumnNode
    {
        public A1ColumnOnlyNode(UInt64 val)
            : base(val) { }
    }

    public class A1RowOnlyNode : A1RowNode
    {
        public A1RowOnlyNode(UInt64 val)
            : base(val) { }
    }

    public class A1AbsoluteRowNode : A1RowNode
    {
        public A1AbsoluteRowNode(
            UInt64 val,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(val, leadingWhitespace, trailingWhitespace) { }

        public override string ToRawString() => "$" + base.ToRawString();
    }

    public class A1RelativeRowNode : A1RowNode
    {
        public A1RelativeRowNode(
            UInt64 val,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(val, leadingWhitespace, trailingWhitespace) { }
    }

    public class A1CellNode : CellNode<A1RowNode, UInt64, A1ColumnNode, UInt64>
    {
        public A1CellNode(A1ColumnNode column, A1RowNode row)
            : base(row, column) { }

        public override string ToRawString() => base.Column.ToString() + base.Row.ToString();

        public override IEnumerable<O> Children<O>()
        {
            if (Column is O c)
                yield return c;
            if (Row is O r)
                yield return r;
        }

        public override Node? ReplaceChild(Int32 index, Node replacement)
        {
            Node? current = null;
            if (index == 0 && replacement is A1ColumnNode columnRep)
            {
                current = Column as Node;
                Column = columnRep;
            }
            else if (index == 1 && replacement is A1RowNode rowRep)
            {
                current = Row as Node;
                Row = rowRep;
            }
            return current;
        }
    }
}

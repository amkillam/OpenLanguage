using System;
using System.Collections.Generic;
using OpenLanguage.Utils;

namespace OpenLanguage.SpreadsheetML.Formula.Ast
{
    public abstract class A1ColumnNode : ColumnNode<ulong>
    {
        public A1ColumnNode(
            ulong val,
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
            ulong val,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(val, leadingWhitespace, trailingWhitespace) { }

        public override string ToRawString() => "$" + base.ToRawString();
    }

    public class A1RelativeColumnNode : A1ColumnNode
    {
        public A1RelativeColumnNode(
            ulong val,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(val, leadingWhitespace, trailingWhitespace) { }
    }

    public abstract class A1RowNode : RowNode<ulong>
    {
        public A1RowNode(
            ulong val,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(val, leadingWhitespace, trailingWhitespace) { }
    }

    public class A1ColumnOnlyNode : A1ColumnNode
    {
        public A1ColumnOnlyNode(ulong val)
            : base(val) { }
    }

    public class A1RowOnlyNode : A1RowNode
    {
        public A1RowOnlyNode(ulong val)
            : base(val) { }
    }

    public class A1AbsoluteRowNode : A1RowNode
    {
        public A1AbsoluteRowNode(
            ulong val,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(val, leadingWhitespace, trailingWhitespace) { }

        public override string ToRawString() => "$" + base.ToRawString();
    }

    public class A1RelativeRowNode : A1RowNode
    {
        public A1RelativeRowNode(
            ulong val,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(val, leadingWhitespace, trailingWhitespace) { }
    }

    public class A1CellNode : CellNode<A1RowNode, ulong, A1ColumnNode, ulong>
    {
        public A1CellNode(A1ColumnNode column, A1RowNode row)
            : base(row, column) { }

        public override string ToRawString() => base.Column.ToString() + base.Row.ToString();

        public override IEnumerable<O> Children<O>()
        {
            if (Column is O c)
            {
                yield return c;
            }
            if (Row is O r)
            {
                yield return r;
            }
        }

        public override Node? ReplaceChild(int index, Node replacement)
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

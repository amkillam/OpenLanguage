using System;
using System.Collections.Generic;

namespace OpenLanguage.WordprocessingML.Ast
{
    public abstract class ColumnNode<N> : ExpressionNode
        where N : System.Numerics.INumber<N>,
            System.Numerics.IBinaryInteger<N>,
            System.Numerics.INumberBase<N>,
            IParsable<N>,
            IFormattable,
            System.Numerics.IMinMaxValue<N>
    {
        public N ColumnSpecifier { get; set; }

        public ColumnNode(
            N val,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            ColumnSpecifier = val;
        }

        public override string ToRawString() =>
            ColumnSpecifier.ToString("D", System.Globalization.CultureInfo.InvariantCulture);

        public override Node? ReplaceChild(int index, Node replacement) => null;

        public override IEnumerable<O> Children<O>()
        {
            yield break;
        }
    }

    public abstract class RowNode<N> : ExpressionNode
        where N : System.Numerics.INumber<N>,
            System.Numerics.IBinaryInteger<N>,
            System.Numerics.INumberBase<N>,
            IParsable<N>,
            IFormattable,
            System.Numerics.IMinMaxValue<N>
    {
        public N RowSpecifier { get; set; }

        public RowNode(
            N val,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            RowSpecifier = val;
        }

        public override string ToRawString() =>
            RowSpecifier.ToString("D", System.Globalization.CultureInfo.InvariantCulture);

        public override Node? ReplaceChild(int index, Node replacement) => null;

        public override IEnumerable<O> Children<O>()
        {
            yield break;
        }
    }

    public abstract class CellNode<R, RN, C, CN> : CellReferenceNode
        where RN : System.Numerics.INumber<RN>,
            System.Numerics.IBinaryInteger<RN>,
            System.Numerics.INumberBase<RN>,
            IParsable<RN>,
            IFormattable,
            System.Numerics.IMinMaxValue<RN>
        where CN : System.Numerics.INumber<CN>,
            System.Numerics.IBinaryInteger<CN>,
            System.Numerics.INumberBase<CN>,
            IParsable<CN>,
            IFormattable,
            System.Numerics.IMinMaxValue<CN>
        where R : RowNode<RN>
        where C : ColumnNode<CN>
    {
        public R Row { get; set; }
        public C Column { get; set; }

        public CellNode(
            R row,
            C column,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Row = row;
            Column = column;
        }

        public override string ToRawString() => Row.ToString() + Column.ToString();

        public override IEnumerable<O> Children<O>()
        {
            if (Row is O r)
            {
                yield return r;
            }
            if (Column is O c)
            {
                yield return c;
            }
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;
            if (index == 0 && replacement is R rowRep)
            {
                current = Row as Node;
                Row = rowRep;
            }
            else if (index == 1 && replacement is C columnRep)
            {
                current = Column as Node;
                Column = columnRep;
            }
            return current;
        }
    }
}

using System;
using System.Collections.Generic;

namespace OpenLanguage.WordprocessingML.Ast
{
    public class CellRangeNode<LC, RC, LCRN, LCR, LCCN, LCC, RCRN, RCR, RCCN, RCC>
        : CellReferenceNode
        where LCRN : System.Numerics.INumber<LCRN>,
            System.Numerics.IBinaryInteger<LCRN>,
            System.Numerics.INumberBase<LCRN>,
            IParsable<LCRN>,
            IFormattable,
            System.Numerics.IMinMaxValue<LCRN>
        where LCCN : System.Numerics.INumber<LCCN>,
            System.Numerics.IBinaryInteger<LCCN>,
            System.Numerics.INumberBase<LCCN>,
            IParsable<LCCN>,
            IFormattable,
            System.Numerics.IMinMaxValue<LCCN>
        where RCRN : System.Numerics.INumber<RCRN>,
            System.Numerics.IBinaryInteger<RCRN>,
            System.Numerics.INumberBase<RCRN>,
            IParsable<RCRN>,
            IFormattable,
            System.Numerics.IMinMaxValue<RCRN>
        where RCCN : System.Numerics.INumber<RCCN>,
            System.Numerics.IBinaryInteger<RCCN>,
            System.Numerics.INumberBase<RCCN>,
            IParsable<RCCN>,
            IFormattable,
            System.Numerics.IMinMaxValue<RCCN>
        where LCR : RowNode<LCRN>
        where LCC : ColumnNode<LCCN>
        where RCR : RowNode<RCRN>
        where RCC : ColumnNode<RCCN>
        where LC : CellNode<LCR, LCRN, LCC, LCCN>
        where RC : CellNode<RCR, RCRN, RCC, RCCN>
    {
        public LC Left { get; set; }
        public ColonNode Sep { get; set; }
        public RC Right { get; set; }

        public CellRangeNode(
            LC left,
            ColonNode sep,
            RC right,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Left = left;
            Sep = sep;
            Right = right;
        }

        public override string ToRawString() => Left.ToString() + Sep.ToString() + Right.ToString();

        public override IEnumerable<O> Children<O>()
        {
            if (Left is O o1)
            {
                yield return o1;
            }
            if (Sep is O o2)
            {
                yield return o2;
            }
            if (Right is O o3)
            {
                yield return o3;
            }
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;
            if (index == 0 && replacement is LC l)
            {
                current = Left;
                Left = l;
            }
            else if (index == 1 && replacement is ColonNode s)
            {
                current = Sep;
                Sep = s;
            }
            else if (index == 2 && replacement is RC r)
            {
                current = Right;
                Right = r;
            }
            return current;
        }
    }
}

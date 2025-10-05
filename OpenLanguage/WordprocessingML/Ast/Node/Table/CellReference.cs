using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.WordprocessingML.Ast
{
    public class TableCellReferenceNode : CellReferenceNode
    {
        public LeftParenNode LeftParen { get; set; }
        public TableReferenceNode Table { get; set; }
        public CellReferenceNode Cell { get; set; }
        public RightParenNode RightParen { get; set; }

        public TableCellReferenceNode(
            LeftParenNode leftParen,
            TableReferenceNode table,
            CellReferenceNode cell,
            RightParenNode rightParen,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            LeftParen = leftParen;
            Table = table;
            Cell = cell;
            RightParen = rightParen;
        }

        public override string ToRawString() =>
            LeftParen.ToString() + Table.ToString() + Cell.ToString() + RightParen.ToString();

        public override IEnumerable<O> Children<O>()
        {
            if (LeftParen is O lp)
            {
                yield return lp;
            }
            if (Table is O t)
            {
                yield return t;
            }
            if (Cell is O c)
            {
                yield return c;
            }

            if (RightParen is O rp)
            {
                yield return rp;
            }

            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;
            switch (index)
            {
                case 0 when replacement is LeftParenNode lpRep:
                {
                    current = LeftParen as Node;
                    LeftParen = lpRep;

                    break;
                }
                case 1 when replacement is TableReferenceNode tRep:
                {
                    current = Table as Node;
                    Table = tRep;

                    break;
                }
                case 2 when replacement is CellReferenceNode cellRep:
                {
                    current = Cell as Node;
                    Cell = cellRep;
                    break;
                }
                case 3 when replacement is RightParenNode rpRep:
                {
                    current = RightParen as Node;
                    RightParen = rpRep;

                    break;
                }
                default:
                {
                    break;
                }
            }

            return current;
        }
    }
}

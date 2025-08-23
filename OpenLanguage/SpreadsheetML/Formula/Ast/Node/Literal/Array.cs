using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace OpenLanguage.SpreadsheetML.Formula.Ast
{
    public class ArrayNode : ExpressionNode
    {
        public List<List<ExpressionNode>> Rows { get; set; }
        public override int Precedence => Ast.Precedence.Primary;

        public ArrayNode(
            List<List<ExpressionNode>> rows,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Rows = rows;
        }

        public override string ToRawString()
        {
            IEnumerable<string> rowsStr = Rows.Select(row =>
                string.Join(",", row.Select(cell => cell.ToString()))
            );
            return "{" + string.Join(";", rowsStr) + "}";
        }

        public override IEnumerable<O> Children<O>()
        {
            foreach (ExpressionNode cell in Rows.SelectMany(row => row))
            {
                if (cell is O cellImp)
                    yield return cellImp;
            }
        }

        public override Node? ReplaceChild(Int32 index, Node replacement)
        {
            if (replacement is ExpressionNode expr)
            {
                int currentIndex = 0;
                for (int i = 0; i < Rows.Count; i++)
                {
                    for (int j = 0; j < Rows[i].Count; j++)
                    {
                        if (currentIndex == index)
                        {
                            ExpressionNode oldNode = Rows[i][j];
                            Rows[i][j] = expr;
                            return oldNode;
                        }
                        currentIndex++;
                    }
                }
            }
            return null;
        }
    }
}

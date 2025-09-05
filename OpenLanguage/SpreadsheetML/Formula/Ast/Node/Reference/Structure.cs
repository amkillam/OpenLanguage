using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.SpreadsheetML.Formula.Ast
{
    public abstract class StructureReferenceNode : ExpressionNode
    {
        protected StructureReferenceNode(
            List<Node>? leadingWs = null,
            List<Node>? trailingWs = null
        )
            : base(leadingWs, trailingWs) { }

        public override int Precedence => Ast.Precedence.Primary;

        public override IEnumerable<O> Children<O>()
        {
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement) => null;
    }

    public class StructureAllReferenceNode : StructureReferenceNode
    {
        private const string Keyword = "#All";

        public override string ToRawString() => Keyword;
    }

    public class StructureDataReferenceNode : StructureReferenceNode
    {
        private const string Keyword = "#Data";

        public override string ToRawString() => Keyword;
    }

    public class StructureHeadersReferenceNode : StructureReferenceNode
    {
        private const string Keyword = "#Headers";

        public override string ToRawString() => Keyword;
    }

    public class StructureTotalsReferenceNode : StructureReferenceNode
    {
        private const string Keyword = "#Totals";

        public override string ToRawString() => Keyword;
    }

    public class StructureThisRowReferenceNode : StructureReferenceNode
    {
        public string RawValue { get; }

        public StructureThisRowReferenceNode(string rawValue)
        {
            RawValue = rawValue;
        }

        public override string ToRawString() => RawValue;
    }

    public class StructureThisRowByPrefixReferenceNode : StructureAbsoluteColumn
    {
        public AtSymbolLiteralNode AtSymbol { get; set; }

        public StructureThisRowByPrefixReferenceNode(
            AtSymbolLiteralNode atSymbol,
            ExpressionNode name
        )
            : base(name)
        {
            AtSymbol = atSymbol;
        }

        public override string ToRawString() => AtSymbol.ToString() + base.ToRawString();

        public override IEnumerable<O> Children<O>()
        {
            if (AtSymbol is O ats)
            {
                yield return ats;
            }
            foreach (O child in base.Children<O>())
            {
                yield return child;
            }
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            if (index == 0 && replacement is AtSymbolLiteralNode atsn)
            {
                AtSymbolLiteralNode current = AtSymbol;
                AtSymbol = atsn;
                return current;
            }
            // If index is not 0, pass to base class for Name replacement
            return base.ReplaceChild(index - 1, replacement);
        }
    }

    public class StructureColumn : ExpressionNode
    {
        public LeftBracketNode OpenBracket { get; set; }
        public ExpressionNode Name { get; set; }
        public RightBracketNode CloseBracket { get; set; }

        public StructureColumn(
            LeftBracketNode openBracket,
            ExpressionNode name,
            RightBracketNode closeBracket,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            OpenBracket = openBracket;
            Name = name;
            CloseBracket = closeBracket;
        }

        public override int Precedence => Ast.Precedence.Primary;

        public override string ToRawString() =>
            OpenBracket.ToString() + Name.ToString() + CloseBracket.ToString();

        public override IEnumerable<O> Children<O>()
        {
            if (OpenBracket is O ob)
            {
                yield return ob;
            }
            if (Name is O n)
            {
                yield return n;
            }
            if (CloseBracket is O cb)
            {
                yield return cb;
            }
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;
            if (index == 0 && replacement is LeftBracketNode lbn)
            {
                current = OpenBracket;
                OpenBracket = lbn;
            }
            else if (index == 1 && replacement is ExpressionNode nn)
            {
                current = Name;
                Name = nn;
            }
            else if (index == 2 && replacement is RightBracketNode rbn)
            {
                current = CloseBracket;
                CloseBracket = rbn;
            }
            return current;
        }
    }

    public class StructureAbsoluteColumn : ExpressionNode
    {
        public ExpressionNode Name { get; set; }

        public StructureAbsoluteColumn(ExpressionNode name)
        {
            Name = name;
        }

        public override int Precedence => Ast.Precedence.Primary;

        public override string ToRawString() => Name.ToString();

        public override IEnumerable<O> Children<O>()
        {
            if (Name is O o)
            {
                yield return o;
            }
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            if (index == 0 && replacement is ExpressionNode nn)
            {
                Node current = Name;
                Name = nn;
                return current;
            }
            return null;
        }
    }

    public class StructureColumnRange : ExpressionNode
    {
        public StructureColumn Start { get; set; }
        public StructureColumn End { get; set; }

        public StructureColumnRange(StructureColumn start, StructureColumn end)
        {
            Start = start;
            End = end;
        }

        public override int Precedence => Ast.Precedence.Primary;

        public override string ToRawString() => $"{Start.ToString()}:{End.ToString()}";

        public override IEnumerable<O> Children<O>()
        {
            if (Start is O s)
            {
                yield return s;
            }
            if (End is O e)
            {
                yield return e;
            }
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            if (replacement is StructureColumn sc)
            {
                if (index == 0)
                {
                    Node current = Start;
                    Start = sc;
                    return current;
                }
                if (index == 1)
                {
                    Node current = End;
                    End = sc;
                    return current;
                }
            }
            return null;
        }
    }

    public class StructureThisRowColumnReferenceNode : ExpressionNode
    {
        public StructureThisRowReferenceNode ThisRow { get; set; }
        public StructureColumn Column { get; set; }

        public StructureThisRowColumnReferenceNode(
            StructureThisRowReferenceNode thisRow,
            StructureColumn column
        )
        {
            ThisRow = thisRow;
            Column = column;
        }

        public override int Precedence => Ast.Precedence.Primary;

        public override string ToRawString() => $"{ThisRow.ToRawString()}{Column.ToRawString()}";

        public override IEnumerable<O> Children<O>()
        {
            if (ThisRow is O t)
            {
                yield return t;
            }
            if (Column is O c)
            {
                yield return c;
            }
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            if (index == 0 && replacement is StructureThisRowReferenceNode t)
            {
                Node current = ThisRow;
                ThisRow = t;
                return current;
            }
            if (index == 1 && replacement is StructureColumn c)
            {
                Node current = Column;
                Column = c;
                return current;
            }
            return null;
        }
    }

    public class StructureHeadersDataReferenceNode : ExpressionNode
    {
        public StructureHeadersReferenceNode Headers { get; set; }
        public StructureDataReferenceNode Data { get; set; }

        public StructureHeadersDataReferenceNode(
            StructureHeadersReferenceNode headers,
            StructureDataReferenceNode data
        )
        {
            Headers = headers;
            Data = data;
        }

        public override int Precedence => Ast.Precedence.Primary;

        public override string ToRawString() => $"{Headers.ToString()},{Data.ToString()}";

        public override IEnumerable<O> Children<O>()
        {
            if (Headers is O h)
            {
                yield return h;
            }
            if (Data is O d)
            {
                yield return d;
            }
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            if (index == 0 && replacement is StructureHeadersReferenceNode h)
            {
                Node current = Headers;
                Headers = h;
                return current;
            }
            if (index == 1 && replacement is StructureDataReferenceNode d)
            {
                Node current = Data;
                Data = d;
                return current;
            }
            return null;
        }
    }

    public class StructureDataTotalsReferenceNode : ExpressionNode
    {
        public StructureDataReferenceNode Data { get; set; }
        public StructureTotalsReferenceNode Totals { get; set; }

        public StructureDataTotalsReferenceNode(
            StructureDataReferenceNode data,
            StructureTotalsReferenceNode totals
        )
        {
            Data = data;
            Totals = totals;
        }

        public override int Precedence => Ast.Precedence.Primary;

        public override string ToRawString() => $"{Data.ToString()},{Totals.ToString()}";

        public override IEnumerable<O> Children<O>()
        {
            if (Data is O d)
            {
                yield return d;
            }
            if (Totals is O t)
            {
                yield return t;
            }
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            if (index == 0 && replacement is StructureDataReferenceNode d)
            {
                Node current = Data;
                Data = d;
                return current;
            }
            if (index == 1 && replacement is StructureTotalsReferenceNode t)
            {
                Node current = Totals;
                Totals = t;
                return current;
            }
            return null;
        }
    }

    public class ColumnRangeIndexedKeyword : ExpressionNode
    {
        public ExpressionNode Keyword { get; set; }
        public StructureColumnRange ColumnRange { get; set; }

        public ColumnRangeIndexedKeyword(ExpressionNode keyword, StructureColumnRange columnRange)
        {
            Keyword = keyword;
            ColumnRange = columnRange;
        }

        public override int Precedence => Ast.Precedence.Primary;

        public override string ToRawString() => $"{Keyword.ToString()},{ColumnRange.ToString()}";

        public override IEnumerable<O> Children<O>()
        {
            if (Keyword is O k)
            {
                yield return k;
            }
            if (ColumnRange is O c)
            {
                yield return c;
            }
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            if (index == 0 && replacement is ExpressionNode k)
            {
                Node current = Keyword;
                Keyword = k;
                return current;
            }
            if (index == 1 && replacement is StructureColumnRange c)
            {
                Node current = ColumnRange;
                ColumnRange = c;
                return current;
            }
            return null;
        }
    }

    public class ColumnIndexedKeyword : ExpressionNode
    {
        public ExpressionNode Keyword { get; set; }
        public StructureColumn Column { get; set; }

        public ColumnIndexedKeyword(ExpressionNode keyword, StructureColumn column)
        {
            Keyword = keyword;
            Column = column;
        }

        public override int Precedence => Ast.Precedence.Primary;

        public override string ToRawString() => $"{Keyword.ToString()},{Column.ToString()}";

        public override IEnumerable<O> Children<O>()
        {
            if (Keyword is O k)
            {
                yield return k;
            }
            if (Column is O c)
            {
                yield return c;
            }
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            if (index == 0 && replacement is ExpressionNode k)
            {
                Node current = Keyword;
                Keyword = k;
                return current;
            }
            if (index == 1 && replacement is StructureColumn c)
            {
                Node current = Column;
                Column = c;
                return current;
            }
            return null;
        }
    }

    public class StructureReferenceIndicesUnion
        : CommaDelimitedNodes<ExpressionNode, ExpressionNode>
    {
        public StructureReferenceIndicesUnion(
            ExpressionNode left,
            CommaNode delimiter,
            ExpressionNode right,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(left, delimiter, right, leadingWhitespace, trailingWhitespace) { }
    }

    public class StructuredReferenceNode : ExpressionNode
    {
        public WorkbookIndexNode? Workbook { get; set; }
        public ExpressionNode? TableName { get; set; }
        public List<ExpressionNode> Indices { get; set; } = new List<ExpressionNode>();
        public List<CommaNode> DelimiterNodes { get; set; } = new List<CommaNode>();

        public StructuredReferenceNode(
            WorkbookIndexNode? workbook,
            ExpressionNode? tableName,
            ExpressionNode? intraTableReference
        )
        {
            Workbook = workbook;
            TableName = tableName;
            if (intraTableReference == null)
            {
                Indices = new List<ExpressionNode>();
            }
            else
            {
                Indices = new List<ExpressionNode>() { intraTableReference };
            }
        }

        public StructuredReferenceNode(
            WorkbookIndexNode? workbook,
            ExpressionNode? tableName,
            List<ExpressionNode>? intraTableReferences
        )
        {
            Workbook = workbook;
            TableName = tableName;
            Indices = intraTableReferences ?? new List<ExpressionNode>();
        }

        public override int Precedence => Ast.Precedence.Primary;

        public override string ToRawString()
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            if (Workbook != null)
            {
                builder.Append(Workbook.ToString());
            }
            if (TableName != null)
            {
                builder.Append(TableName.ToString());
            }

            for (System.Int32 i = 0; i < Indices.Count - 1; i++)
            {
                ExpressionNode intraTableRef = Indices[i];
                builder.Append(intraTableRef.ToString());
                CommaNode delimiter = DelimiterNodes[i];
                builder.Append(delimiter.ToString());
            }

            builder.Append(Indices.Last().ToString());

            return builder.ToString();
        }

        public override IEnumerable<O> Children<O>()
        {
            if (Workbook is O w)
            {
                yield return w;
            }
            if (TableName is O t)
            {
                yield return t;
            }

            foreach (ExpressionNode intraTableRef in Indices)
            {
                if (intraTableRef is O i)
                {
                    yield return i;
                }
            }

            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;
            int nameNodeIdx = 0;
            int referencesStartIdx = 0;
            if (Workbook != null)
            {
                if (index == 0 && replacement is WorkbookIndexNode w)
                {
                    current = Workbook;
                    Workbook = w;
                    return current;
                }

                nameNodeIdx++;
                referencesStartIdx++;
            }

            if (TableName != null)
            {
                if (index == nameNodeIdx && replacement is ExpressionNode t)
                {
                    current = TableName;
                    TableName = t;
                    return current;
                }
                referencesStartIdx++;
            }

            int referenceOffset = referencesStartIdx + index;

            if (referenceOffset < Indices.Count && replacement is ExpressionNode e)
            {
                current = Indices[referenceOffset];
                Indices[referenceOffset] = e;
            }

            return current;
        }
    }
}

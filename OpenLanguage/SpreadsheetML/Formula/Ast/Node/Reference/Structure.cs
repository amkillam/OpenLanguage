using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.SpreadsheetML.Formula.Ast
{
    public abstract class StructureKeywordNode : ExpressionNode
    {
        protected StructureKeywordNode(List<Node>? leadingWs = null, List<Node>? trailingWs = null)
            : base(leadingWs, trailingWs) { }

        public override int Precedence => Ast.Precedence.Primary;

        public override IEnumerable<O> Children<O>()
        {
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement) => null;
    }

    public class StructureAllNode : StructureKeywordNode
    {
        private const string Keyword = "#All";

        public override string ToRawString() => Keyword;
    }

    public class StructureDataNode : StructureKeywordNode
    {
        private const string Keyword = "#Data";

        public override string ToRawString() => Keyword;
    }

    public class StructureHeadersNode : StructureKeywordNode
    {
        private const string Keyword = "#Headers";

        public override string ToRawString() => Keyword;
    }

    public class StructureTotalsNode : StructureKeywordNode
    {
        private const string Keyword = "#Totals";

        public override string ToRawString() => Keyword;
    }

    public class StructureThisRowNode : StructureKeywordNode
    {
        public string RawValue { get; }

        public StructureThisRowNode(string rawValue)
        {
            RawValue = rawValue;
        }

        public override string ToRawString() => RawValue;
    }

    public class StructureThisRowByPrefixNode : StructureAbsoluteColumn
    {
        public StructureThisRowByPrefixNode(ExpressionNode name)
            : base(name) { }

        public override string ToRawString() => "@" + base.ToRawString();
    }

    public class StructureColumn : ExpressionNode
    {
        public ExpressionNode Name { get; set; }

        public StructureColumn(ExpressionNode name)
        {
            Name = name;
        }

        public override int Precedence => Ast.Precedence.Primary;

        public override string ToRawString() => $"[{Name.ToString()}]";

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

    public class StructureThisRowColumnNode : ExpressionNode
    {
        public StructureThisRowNode ThisRow { get; set; }
        public StructureColumn Column { get; set; }

        public StructureThisRowColumnNode(StructureThisRowNode thisRow, StructureColumn column)
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
            if (index == 0 && replacement is StructureThisRowNode t)
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

    public class StructureHeadersDataNode : ExpressionNode
    {
        public StructureHeadersNode Headers { get; set; }
        public StructureDataNode Data { get; set; }

        public StructureHeadersDataNode(StructureHeadersNode headers, StructureDataNode data)
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
            if (index == 0 && replacement is StructureHeadersNode h)
            {
                Node current = Headers;
                Headers = h;
                return current;
            }
            if (index == 1 && replacement is StructureDataNode d)
            {
                Node current = Data;
                Data = d;
                return current;
            }
            return null;
        }
    }

    public class StructureDataTotalsNode : ExpressionNode
    {
        public StructureDataNode Data { get; set; }
        public StructureTotalsNode Totals { get; set; }

        public StructureDataTotalsNode(StructureDataNode data, StructureTotalsNode totals)
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
            if (index == 0 && replacement is StructureDataNode d)
            {
                Node current = Data;
                Data = d;
                return current;
            }
            if (index == 1 && replacement is StructureTotalsNode t)
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

    public class IntraTableIndexedReference : ExpressionNode
    {
        public List<ExpressionNode> InnerReferences { get; set; } = new List<ExpressionNode>();

        public IntraTableIndexedReference(
            ExpressionNode? innerReference,
            List<Node>? leadingWs = null,
            List<Node>? trailingWs = null
        )
            : base(leadingWs, trailingWs)
        {
            InnerReferences = new List<ExpressionNode>();
            if (innerReference != null)
            {
                InnerReferences.Add(innerReference);
            }
        }

        public IntraTableIndexedReference(
            List<ExpressionNode>? innerReferences,
            List<Node>? leadingWs = null,
            List<Node>? trailingWs = null
        )
            : base(leadingWs, trailingWs)
        {
            InnerReferences = new List<ExpressionNode>();
            if (innerReferences != null)
            {
                InnerReferences.AddRange(innerReferences);
            }
        }

        public override int Precedence => Ast.Precedence.Primary;

        public override string ToRawString()
        {
            if (InnerReferences.Count <= 1)
            {
                return "[" + string.Concat(InnerReferences.Select(r => r.ToString())) + "]";
            }
            return "["
                + string.Join(",", InnerReferences.Select(rNested => rNested.ToString()))
                + "]";
        }

        public override IEnumerable<O> Children<O>()
        {
            foreach (ExpressionNode innerRef in InnerReferences)
            {
                if (innerRef is O i)
                {
                    yield return i;
                }
            }

            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;
            if (index < InnerReferences.Count && replacement is ExpressionNode ir)
            {
                current = InnerReferences[index];
                InnerReferences[index] = ir;
            }
            return current;
        }
    }

    public class StructuredReferenceNode : ExpressionNode
    {
        public WorkbookIndexNode? Workbook { get; set; }
        public ExpressionNode? TableName { get; set; }
        public List<ExpressionNode> IntraTableReferences { get; set; } = new List<ExpressionNode>();
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
                IntraTableReferences = new List<ExpressionNode>();
            }
            else
            {
                IntraTableReferences = new List<ExpressionNode>() { intraTableReference };
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
            IntraTableReferences = intraTableReferences ?? new List<ExpressionNode>();
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

            for (int i = 0; i < IntraTableReferences.Count - 1; i++)
            {
                ExpressionNode intraTableRef = IntraTableReferences[i];
                builder.Append(intraTableRef.ToString());
                CommaNode delimiter = DelimiterNodes[i];
                builder.Append(delimiter.ToString());
            }

            builder.Append(IntraTableReferences.Last().ToString());

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

            foreach (ExpressionNode intraTableRef in IntraTableReferences)
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

            if (referenceOffset < IntraTableReferences.Count && replacement is ExpressionNode e)
            {
                current = IntraTableReferences[referenceOffset];
                IntraTableReferences[referenceOffset] = e;
            }

            return current;
        }
    }
}

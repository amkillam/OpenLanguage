using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.SpreadsheetML.Formula.Ast
{
    public abstract class NameNode : ExpressionNode
    {
        public String Name { get; set; }
        public override Int32 Precedence => Ast.Precedence.Primary;

        protected NameNode(
            string name,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Name = name;
        }

        public override string ToRawString() => Name;

        public override IEnumerable<O> Children<O>()
        {
            yield break;
        }

        public override Node? ReplaceChild(Int32 index, Node replacement) => null;
    }

    public class NamedRangeNode : NameNode
    {
        public NamedRangeNode(
            string name,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(name, leadingWhitespace, trailingWhitespace) { }
    }

    /// <summary>
    /// Represents a reference prefixed with a bang, e.g., "!MyName" or "!A1".
    /// </summary>
    public class BangReferenceNode : ExpressionNode
    {
        public BangNode Bang { get; set; }
        public ExpressionNode Reference { get; set; }

        public BangReferenceNode(
            BangNode bang,
            ExpressionNode reference,
            List<Node>? leadingWs = null,
            List<Node>? trailingWs = null
        )
            : base(leadingWs, trailingWs)
        {
            Bang = bang;
            Reference = reference;
        }

        public override int Precedence => Ast.Precedence.Primary;

        public override string ToRawString() => Bang.ToString() + Reference.ToString();

        public override IEnumerable<O> Children<O>()
        {
            if (Reference is O o)
            {
                yield return o;
            }
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            if (index == 0 && replacement is BangNode rb)
            {
                Node current = Bang;
                Bang = rb;
                return current;
            }
            else if (index == 1 && replacement is ExpressionNode expr)
            {
                ExpressionNode current = Reference;
                Reference = expr;
                return current;
            }
            return null;
        }
    }

    /// <summary>
    /// Represents a reference to a single sheet, e.g., "Sheet1!A1".
    /// </summary>
    public class SheetReferenceNode : ExpressionNode
    {
        public ExpressionNode Sheet { get; set; }
        public BangReferenceNode BangReference { get; set; }

        public SheetReferenceNode(
            ExpressionNode sheet,
            BangReferenceNode bangRef,
            List<Node>? leadingWs = null,
            List<Node>? trailingWs = null
        )
            : base(leadingWs, trailingWs)
        {
            Sheet = sheet;
            BangReference = bangRef;
        }

        public override int Precedence => Ast.Precedence.Primary;

        public override string ToRawString()
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            builder.Append(Sheet.ToString());
            builder.Append(BangReference.ToString());
            return builder.ToString();
        }

        public override IEnumerable<O> Children<O>()
        {
            if (BangReference is O b)
            {
                yield return b;
            }

            if (Sheet is O s)
            {
                yield return s;
            }

            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;
            if (replacement is ExpressionNode expr)
            {
                if (index == 0 && expr is BangReferenceNode bangRefRep)
                {
                    current = BangReference;
                    BangReference = bangRefRep;
                }
                else if (index == 1)
                {
                    current = Sheet;
                    Sheet = expr;
                }
            }
            return current;
        }
    }

    /// <summary>
    /// Represents a single sheet name, which may be quoted or unquoted, and may have a workbook index.
    /// </summary>
    public class SheetNode : ExpressionNode
    {
        public ExpressionNode? Workbook { get; set; }
        public List<Node> WsAfterWorkbook { get; set; }
        public string SheetName { get; set; }
        public bool IsQuoted { get; set; }

        public SheetNode(
            ExpressionNode? workbook,
            List<Node> wsAfterWorkbook,
            string sheetName,
            bool isQuoted,
            List<Node>? leadingWs = null,
            List<Node>? trailingWs = null
        )
            : base(leadingWs, trailingWs)
        {
            Workbook = workbook;
            WsAfterWorkbook = wsAfterWorkbook;
            SheetName = sheetName;
            IsQuoted = isQuoted;
        }

        public override int Precedence => Ast.Precedence.Primary;

        public override string ToRawString()
        {
            string workbookStr = Workbook?.ToString() ?? "";
            string wsStr = string.Concat(WsAfterWorkbook.Select(w => w.ToString()));
            string nameStr = IsQuoted ? $"'{SheetName.Replace("'", "''")}'" : SheetName;
            return $"{workbookStr}{wsStr}{nameStr}";
        }

        public override IEnumerable<O> Children<O>()
        {
            if (Workbook is O o)
            {
                yield return o;
            }
        }

        public override Node? ReplaceChild(int index, Node replacement) => null;
    }

    /// <summary>
    /// Represents a range of sheets, e.g., "Sheet1:Sheet3".
    /// </summary>
    public class SheetRangeNode : ExpressionNode
    {
        public ExpressionNode? Workbook { get; set; }
        public List<Node> WsAfterWorkbook { get; set; }
        public string StartSheetName { get; set; }
        public List<Node> WsBeforeColon { get; set; }
        public List<Node> WsAfterColon { get; set; }
        public string EndSheetName { get; set; }

        public SheetRangeNode(
            ExpressionNode? workbook,
            List<Node> wsAfterWorkbook,
            string startSheet,
            List<Node> wsBeforeColon,
            List<Node> wsAfterColon,
            string endSheet,
            List<Node>? leadingWs = null,
            List<Node>? trailingWs = null
        )
            : base(leadingWs, trailingWs)
        {
            Workbook = workbook;
            WsAfterWorkbook = wsAfterWorkbook;
            StartSheetName = startSheet;
            WsBeforeColon = wsBeforeColon;
            WsAfterColon = wsAfterColon;
            EndSheetName = endSheet;
        }

        public override int Precedence => Ast.Precedence.Primary;

        public override string ToRawString()
        {
            return new System.Text.StringBuilder()
                .Append(Workbook?.ToString() ?? "")
                .Append(string.Concat(WsAfterWorkbook.Select(w => w.ToString())))
                .Append(StartSheetName)
                .Append(string.Concat(WsBeforeColon.Select(w => w.ToString())))
                .Append(":")
                .Append(string.Concat(WsAfterColon.Select(w => w.ToString())))
                .Append(EndSheetName)
                .ToString();
        }

        public override IEnumerable<O> Children<O>()
        {
            if (Workbook is O o)
            {
                yield return o;
            }
        }

        public override Node? ReplaceChild(int index, Node replacement) => null;
    }

    /// <summary>
    /// Represents a workbook index, e.g., "[1]".
    /// </summary>
    public class WorkbookIndexNode : ExpressionNode
    {
        public List<Node> WsAfterOpenBracket { get; set; }
        public Int64 Index { get; set; }
        public List<Node> WsBeforeCloseBracket { get; set; }

        public WorkbookIndexNode(
            Int64 index,
            List<Node>? leadingWs = null,
            List<Node>? trailingWs = null
        )
            : base(leadingWs, trailingWs)
        {
            WsAfterOpenBracket = new List<Node>();
            Index = index;
            WsBeforeCloseBracket = new List<Node>();
        }

        public override int Precedence => Ast.Precedence.Primary;

        public override string ToRawString() =>
            $"[{string.Concat(WsAfterOpenBracket.Select(w => w.ToString()))}{Index.ToString("D")}{string.Concat(WsBeforeCloseBracket.Select(w => w.ToString()))}]";

        public override IEnumerable<O> Children<O>()
        {
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement) => null;
    }
}

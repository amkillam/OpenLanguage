using System.Collections.Generic;

namespace OpenLanguage.SpreadsheetML.Formula.Ast
{
    public class NameNode : ExpressionNode
    {
        public string? RawName { get; set; } = null;
        public ExpressionNode? Name { get; set; } = null;
        public override int Precedence => Ast.Precedence.Primary;

        public NameNode(
            string name,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            RawName = name;
            Name = null;
        }

        public NameNode(
            ExpressionNode name,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Name = name;
            RawName = null;
        }

        public override string ToRawString() =>
            Name == null ? (RawName ?? string.Empty) : Name.ToString();

        public override IEnumerable<O> Children<O>()
        {
            if (Name is O o)
            {
                yield return o;
            }

            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;
            if (index == 0 && replacement is ExpressionNode expr)
            {
                current = Name;
                Name = expr;
                RawName = null;
                return current;
            }
            return null;
        }
    }

    public class NamedRangeNode : NameNode
    {
        public NamedRangeNode(
            ExpressionNode name,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(name, leadingWhitespace, trailingWhitespace) { }

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
        public ExpressionNode? WorkbookReference { get; set; }
        public ExpressionNode? SheetName { get; set; }

        public SheetNode(
            ExpressionNode? workbookIndex = null,
            ExpressionNode? sheetName = null,
            List<Node>? leadingWs = null,
            List<Node>? trailingWs = null
        )
            : base(leadingWs, trailingWs)
        {
            WorkbookReference = workbookIndex;
            SheetName = sheetName;
        }

        public override int Precedence => Ast.Precedence.Primary;

        public override string ToRawString() =>
            (WorkbookReference?.ToString() ?? string.Empty)
            + (SheetName?.ToString() ?? string.Empty);

        public override IEnumerable<O> Children<O>()
        {
            if (WorkbookReference is O o)
            {
                yield return o;
            }

            if (SheetName is O s)
            {
                yield return s;
            }
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;
            if (index == 0 && replacement is ExpressionNode expr)
            {
                current = WorkbookReference;
                WorkbookReference = expr;
            }
            else if (index == 1 && replacement is ExpressionNode expr2)
            {
                current = SheetName;
                SheetName = expr2;
            }
            return current;
        }
    }

    /// <summary>
    /// Represents a range of sheets, e.g., "Sheet1:Sheet3".
    /// </summary>
    public class SheetRangeNode : ExpressionNode
    {
        public ExpressionNode StartSheetName { get; set; }
        public ExpressionNode EndSheetName { get; set; }
        public ColonNode ColonNode { get; set; }

        public SheetRangeNode(
            ExpressionNode startSheet,
            ColonNode colon,
            ExpressionNode endSheet,
            List<Node>? leadingWs = null,
            List<Node>? trailingWs = null
        )
            : base(leadingWs, trailingWs)
        {
            StartSheetName = startSheet;
            EndSheetName = endSheet;
            ColonNode = colon;
        }

        public override int Precedence => Ast.Precedence.Primary;

        public override string ToRawString() =>
            StartSheetName + ColonNode.ToString() + EndSheetName;

        public override IEnumerable<O> Children<O>()
        {
            if (StartSheetName is O s)
            {
                yield return s;
            }
            if (ColonNode is O c)
            {
                yield return c;
            }
            if (EndSheetName is O e)
            {
                yield return e;
            }
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;
            if (index == 0 && replacement is ExpressionNode expr)
            {
                current = StartSheetName;
                StartSheetName = expr;
            }
            else if (index == 1 && replacement is ColonNode cn)
            {
                current = ColonNode;
                ColonNode = cn;
            }
            else if (index == 2 && replacement is ExpressionNode expr2)
            {
                current = EndSheetName;
                EndSheetName = expr2;
            }
            return current;
        }
    }

    /// <summary>
    /// Represents a workbook index, e.g., "[1]" or "[MyWorkbook.xlsx]".
    /// </summary>
    public class WorkbookReferenceNode : ExpressionNode
    {
        public ExpressionNode? Index { get; set; } = null;
        public LeftBracketNode OpenBracket { get; set; }
        public RightBracketNode CloseBracket { get; set; }

        public WorkbookReferenceNode(
            ExpressionNode? index,
            LeftBracketNode openBracket,
            RightBracketNode closeBracket,
            List<Node>? leadingWs = null,
            List<Node>? trailingWs = null
        )
            : base(leadingWs, trailingWs)
        {
            Index = index;
            OpenBracket = openBracket;
            CloseBracket = closeBracket;
        }

        public override int Precedence => Ast.Precedence.Primary;

        public override string ToRawString() =>
            OpenBracket.ToString() + (Index?.ToString() ?? string.Empty) + CloseBracket.ToString();

        public override IEnumerable<O> Children<O>()
        {
            if (OpenBracket is O ob)
            {
                yield return ob;
            }
            if (Index is O i)
            {
                yield return i;
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
            else if (index == 1 && replacement is ExpressionNode expr)
            {
                current = Index;
                Index = expr;
            }
            else if (index == 2 && replacement is RightBracketNode rbn)
            {
                current = CloseBracket;
                CloseBracket = rbn;
            }
            return current;
        }
    }

    public class QuotedSheetNode : ExpressionNode
    {
        public ExpressionNode Sheet { get; set; }
        public string OpenQuote { get; set; }
        public string CloseQuote { get; set; }

        public QuotedSheetNode(
            ExpressionNode sheet,
            string openQuote,
            string closeQuote,
            List<Node>? leadingWs = null,
            List<Node>? trailingWs = null
        )
            : base(leadingWs, trailingWs)
        {
            Sheet = sheet;
            OpenQuote = openQuote;
            CloseQuote = closeQuote;
        }

        public override int Precedence => Ast.Precedence.Primary;

        public override string ToRawString() => OpenQuote + Sheet.ToString() + CloseQuote;

        public override IEnumerable<O> Children<O>()
        {
            if (Sheet is O s)
            {
                yield return s;
            }
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            if (index == 0 && replacement is ExpressionNode expr)
            {
                ExpressionNode current = Sheet;
                Sheet = expr;
                return current;
            }
            return null;
        }
    }
}

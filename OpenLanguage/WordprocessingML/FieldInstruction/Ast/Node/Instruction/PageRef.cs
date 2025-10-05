using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;
using OpenLanguage.WordprocessingML.FieldInstruction.Generated;

namespace OpenLanguage.WordprocessingML.FieldInstruction
{
    public enum PageRefArgument
    {
        Hyperlink,
        RelativePosition,
        GeneralFormat,
        NumericFormat,
    }

    /// <summary>
    /// Represents a strongly-typed PAGEREF field instruction.
    /// Inserts the number of the page containing the bookmark specified by text
    /// in field-argument for a cross-reference.
    /// </summary>
    public class PageRefFieldInstruction : Ast.FieldInstruction
    {
        /// <summary>
        /// The bookmark name for the page reference.
        /// </summary>
        public ExpressionNode? BookmarkName { get; set; }

        /// <summary>
        /// Switch: \h
        /// Creates a hyperlink to the bookmarked paragraph.
        /// </summary>
        public BoolFlagNode? Hyperlink { get; set; }

        /// <summary>
        /// Switch: \p
        /// Causes the field to display its position relative to the source bookmark.
        /// If the PAGEREF field is on the same page as the bookmark, it omits "on page #" and returns "above" or "below" only.
        /// If the PAGEREF field is not on the same page as the bookmark, the string "on page #" is used.
        /// </summary>
        public BoolFlagNode? RelativePosition { get; set; }
        public FlaggedArgument<ExpressionNode>? GeneralFormat { get; set; }
        public FlaggedArgument<ExpressionNode>? NumericFormat { get; set; }

        public List<PageRefArgument> Order { get; set; } = new List<PageRefArgument>();

        public PageRefFieldInstruction(
            StringLiteralNode instruction,
            ExpressionNode? bookmarkName,
            BoolFlagNode? hyperlink,
            BoolFlagNode? relativePosition,
            FlaggedArgument<ExpressionNode>? generalFormat,
            FlaggedArgument<ExpressionNode>? numericFormat,
            List<PageRefArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            BookmarkName = bookmarkName;
            Hyperlink = hyperlink;
            RelativePosition = relativePosition;
            GeneralFormat = generalFormat;
            NumericFormat = numericFormat;
            Order = order;
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToRawString() =>
            Instruction.ToString()
            + (BookmarkName?.ToString() ?? string.Empty)
            + string.Concat(
                Order.Select(arg =>
                    arg switch
                    {
                        PageRefArgument.Hyperlink => Hyperlink?.ToString() ?? string.Empty,
                        PageRefArgument.RelativePosition => RelativePosition?.ToString()
                            ?? string.Empty,
                        PageRefArgument.GeneralFormat => GeneralFormat?.ToString() ?? string.Empty,
                        PageRefArgument.NumericFormat => NumericFormat?.ToString() ?? string.Empty,
                        _ => string.Empty,
                    }
                )
            );

        public override IEnumerable<O> Children<O>()
        {
            if (Instruction is O oInstr)
            {
                yield return oInstr;
            }
            if (BookmarkName is O oBookmark)
            {
                yield return oBookmark;
            }
            foreach (PageRefArgument arg in Order)
            {
                Node? child = arg switch
                {
                    PageRefArgument.Hyperlink => Hyperlink,
                    PageRefArgument.RelativePosition => RelativePosition,
                    PageRefArgument.GeneralFormat => GeneralFormat,
                    PageRefArgument.NumericFormat => NumericFormat,
                    _ => null,
                };
                if (child is O oChild)
                {
                    yield return oChild;
                }
            }
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;

            if (index == 0)
            {
                if (replacement is StringLiteralNode instr)
                {
                    current = Instruction;
                    Instruction = instr;
                }
                return current;
            }

            if (index == 1)
            {
                if (replacement is ExpressionNode name)
                {
                    current = BookmarkName;
                    BookmarkName = name;
                }
                return current;
            }

            int mapIndex = index - 2;
            if (mapIndex >= 0 && mapIndex < Order.Count)
            {
                PageRefArgument arg = Order[mapIndex];
                switch (arg)
                {
                    case PageRefArgument.Hyperlink:
                        if (replacement is BoolFlagNode link)
                        {
                            current = Hyperlink;
                            Hyperlink = link;
                        }
                        break;
                    case PageRefArgument.RelativePosition:
                        if (replacement is BoolFlagNode rel)
                        {
                            current = RelativePosition;
                            RelativePosition = rel;
                        }
                        break;
                    case PageRefArgument.GeneralFormat:
                        if (replacement is FlaggedArgument<ExpressionNode> gf)
                        {
                            current = GeneralFormat;
                            GeneralFormat = gf;
                        }
                        break;
                    case PageRefArgument.NumericFormat:
                        if (replacement is FlaggedArgument<ExpressionNode> nf)
                        {
                            current = NumericFormat;
                            NumericFormat = nf;
                        }
                        break;
                    default:
                        break;
                }
            }

            return current;
        }
    }
}

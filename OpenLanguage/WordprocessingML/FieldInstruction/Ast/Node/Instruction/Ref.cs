using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction
{
    public enum RefArgument
    {
        BookmarkName,
        SeparatorSequence,
        IncrementFootnote,
        CreateHyperlink,
        InsertParagraphNumber,
        RelativePosition,
        InsertParagraphNumberRelative,
        SuppressText,
        FullContextParagraphNumber,
        GeneralFormat,
    }

    /// <summary>
    /// Represents a strongly-typed REF field instruction.
    /// Inserts the text or graphics represented by the bookmark specified by text in field-argument.
    /// The bookmark shall be defined in the current document.
    /// </summary>
    public class RefFieldInstruction : Ast.FieldInstruction
    {
        /// <summary>
        /// The bookmark name to reference.
        /// </summary>
        public ExpressionNode? BookmarkName { get; set; }

        /// <summary>
        /// Switch: \d field-argument
        /// Specifies the character sequence that is used to separate sequence numbers and page numbers.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? SeparatorSequence { get; set; }

        /// <summary>
        /// Switch: \f
        /// Increments footnote, endnote, and annotation numbers that are marked by the bookmark, and inserts the corresponding footnote, endnote, and comment text.
        /// </summary>
        public BoolFlagNode? IncrementFootnote { get; set; }

        /// <summary>
        /// Switch: \h
        /// Creates a hyperlink to the bookmarked paragraph.
        /// </summary>
        public BoolFlagNode? CreateHyperlink { get; set; }

        /// <summary>
        /// Switch: \n
        /// For a referenced paragraph, causes the field result to have the entire paragraph number without trailing periods.
        /// </summary>
        public BoolFlagNode? InsertParagraphNumber { get; set; }

        /// <summary>
        /// Switch: \p
        /// Causes the field result to contain the position relative to the source bookmark using the word "above" or "below".
        /// </summary>
        public BoolFlagNode? RelativePosition { get; set; }

        /// <summary>
        /// Switch: \r
        /// Inserts the entire paragraph number of the bookmarked paragraph in relative context.
        /// </summary>
        public BoolFlagNode? InsertParagraphNumberRelative { get; set; }

        /// <summary>
        /// Switch: \t
        /// Causes the REF field to suppress non-delimiter or non-numerical text when used in conjunction with the \n, \r, or \w switch.
        /// </summary>
        public BoolFlagNode? SuppressText { get; set; }

        /// <summary>
        /// Switch: \w
        /// Inserts the paragraph number of the bookmarked paragraph in full context from anywhere in the document.
        /// </summary>
        public BoolFlagNode? FullContextParagraphNumber { get; set; }

        /// <summary>
        /// Switch: \*
        /// General formatting switch for the field value.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? GeneralFormat { get; set; }

        public List<RefArgument> Order { get; set; } = new List<RefArgument>();

        public RefFieldInstruction(
            StringLiteralNode instruction,
            ExpressionNode? bookmarkName,
            FlaggedArgument<ExpressionNode>? separatorSequence,
            BoolFlagNode? incrementFootnote,
            BoolFlagNode? createHyperlink,
            BoolFlagNode? insertParagraphNumber,
            BoolFlagNode? relativePosition,
            BoolFlagNode? insertParagraphNumberRelative,
            BoolFlagNode? suppressText,
            BoolFlagNode? fullContextParagraphNumber,
            FlaggedArgument<ExpressionNode>? generalFormat,
            List<RefArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            BookmarkName = bookmarkName;
            SeparatorSequence = separatorSequence;
            IncrementFootnote = incrementFootnote;
            CreateHyperlink = createHyperlink;
            InsertParagraphNumber = insertParagraphNumber;
            RelativePosition = relativePosition;
            InsertParagraphNumberRelative = insertParagraphNumberRelative;
            SuppressText = suppressText;
            FullContextParagraphNumber = fullContextParagraphNumber;
            GeneralFormat = generalFormat;
            Order = order;
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToRawString() =>
            Instruction.ToString()
            + string.Concat(
                Order.Select(a =>
                    a switch
                    {
                        RefArgument.BookmarkName => BookmarkName?.ToString() ?? string.Empty,
                        RefArgument.SeparatorSequence => SeparatorSequence?.ToString()
                            ?? string.Empty,
                        RefArgument.IncrementFootnote => IncrementFootnote?.ToString()
                            ?? string.Empty,
                        RefArgument.CreateHyperlink => CreateHyperlink?.ToString() ?? string.Empty,
                        RefArgument.InsertParagraphNumber => InsertParagraphNumber?.ToString()
                            ?? string.Empty,
                        RefArgument.RelativePosition => RelativePosition?.ToString()
                            ?? string.Empty,
                        RefArgument.InsertParagraphNumberRelative =>
                            InsertParagraphNumberRelative?.ToString() ?? string.Empty,
                        RefArgument.SuppressText => SuppressText?.ToString() ?? string.Empty,
                        RefArgument.FullContextParagraphNumber =>
                            FullContextParagraphNumber?.ToString() ?? string.Empty,
                        RefArgument.GeneralFormat => GeneralFormat?.ToString() ?? string.Empty,
                        _ => string.Empty,
                    }
                )
            );

        public override IEnumerable<O> Children<O>()
        {
            if (Instruction is O oInstruction)
            {
                yield return oInstruction;
            }

            foreach (RefArgument arg in Order)
            {
                Node? child = arg switch
                {
                    RefArgument.BookmarkName => BookmarkName,
                    RefArgument.SeparatorSequence => SeparatorSequence,
                    RefArgument.IncrementFootnote => IncrementFootnote,
                    RefArgument.CreateHyperlink => CreateHyperlink,
                    RefArgument.InsertParagraphNumber => InsertParagraphNumber,
                    RefArgument.RelativePosition => RelativePosition,
                    RefArgument.InsertParagraphNumberRelative => InsertParagraphNumberRelative,
                    RefArgument.SuppressText => SuppressText,
                    RefArgument.FullContextParagraphNumber => FullContextParagraphNumber,
                    RefArgument.GeneralFormat => GeneralFormat,
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
                if (replacement is StringLiteralNode instruction)
                {
                    current = Instruction;
                    Instruction = instruction;
                }
            }
            else
            {
                index--;
                if (index < Order.Count)
                {
                    RefArgument arg = Order[index];
                    switch (arg)
                    {
                        case RefArgument.BookmarkName:
                            if (replacement is ExpressionNode bookmarkName)
                            {
                                current = BookmarkName;
                                BookmarkName = bookmarkName;
                            }
                            break;
                        case RefArgument.SeparatorSequence:
                            if (replacement is FlaggedArgument<ExpressionNode> separatorSequence)
                            {
                                current = SeparatorSequence;
                                SeparatorSequence = separatorSequence;
                            }
                            break;
                        case RefArgument.IncrementFootnote:
                            if (replacement is BoolFlagNode incrementFootnote)
                            {
                                current = IncrementFootnote;
                                IncrementFootnote = incrementFootnote;
                            }
                            break;
                        case RefArgument.CreateHyperlink:
                            if (replacement is BoolFlagNode createHyperlink)
                            {
                                current = CreateHyperlink;
                                CreateHyperlink = createHyperlink;
                            }
                            break;
                        case RefArgument.InsertParagraphNumber:
                            if (replacement is BoolFlagNode insertParagraphNumber)
                            {
                                current = InsertParagraphNumber;
                                InsertParagraphNumber = insertParagraphNumber;
                            }
                            break;
                        case RefArgument.RelativePosition:
                            if (replacement is BoolFlagNode relativePosition)
                            {
                                current = RelativePosition;
                                RelativePosition = relativePosition;
                            }
                            break;
                        case RefArgument.InsertParagraphNumberRelative:
                            if (replacement is BoolFlagNode insertParagraphNumberRelative)
                            {
                                current = InsertParagraphNumberRelative;
                                InsertParagraphNumberRelative = insertParagraphNumberRelative;
                            }
                            break;
                        case RefArgument.SuppressText:
                            if (replacement is BoolFlagNode suppressText)
                            {
                                current = SuppressText;
                                SuppressText = suppressText;
                            }
                            break;
                        case RefArgument.FullContextParagraphNumber:
                            if (replacement is BoolFlagNode fullContextParagraphNumber)
                            {
                                current = FullContextParagraphNumber;
                                FullContextParagraphNumber = fullContextParagraphNumber;
                            }
                            break;
                        case RefArgument.GeneralFormat:
                            if (replacement is FlaggedArgument<ExpressionNode> generalFormat)
                            {
                                current = GeneralFormat;
                                GeneralFormat = generalFormat;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }

            return current;
        }
    }
}

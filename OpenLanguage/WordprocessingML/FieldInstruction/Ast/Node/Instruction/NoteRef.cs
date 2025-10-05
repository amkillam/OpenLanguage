using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction
{
    public enum NoteRefArgument
    {
        BookmarkName,
        FootnoteFormat,
        Hyperlink,
        RelativePosition,
    }

    /// <summary>
    /// Represents a strongly-typed NOTEREF field instruction.
    /// Inserts the mark of the footnote or endnote that is marked by the bookmark specified by text in field-argument.
    /// </summary>
    public class NoteRefFieldInstruction : Ast.FieldInstruction
    {
        /// <summary>
        /// The bookmark name for the note reference.
        /// </summary>
        public ExpressionNode? BookmarkName { get; set; }

        /// <summary>
        /// Switch: \f
        /// For a footnote, inserts the reference mark with the same character formatting as the Footnote Reference style.
        /// For an endnote, inserts the reference mark with the same character formatting as the Endnote Reference style.
        /// </summary>
        public BoolFlagNode? FootnoteFormat { get; set; }

        /// <summary>
        /// Switch: \h
        /// Inserts a hyperlink to the bookmarked endnote or footnote.
        /// </summary>
        public BoolFlagNode? Hyperlink { get; set; }

        /// <summary>
        /// Switch: \p
        /// Inserts the relative position of the footnote or endnote ("above" or "below").
        /// </summary>
        public BoolFlagNode? RelativePosition { get; set; }
        public List<NoteRefArgument> Order { get; set; } = new List<NoteRefArgument>();

        public NoteRefFieldInstruction(
            StringLiteralNode instruction,
            ExpressionNode? bookmarkName,
            BoolFlagNode? footnoteFormat,
            BoolFlagNode? hyperlink,
            BoolFlagNode? relativePosition,
            List<NoteRefArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            BookmarkName = bookmarkName;
            FootnoteFormat = footnoteFormat;
            Hyperlink = hyperlink;
            RelativePosition = relativePosition;
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
                        NoteRefArgument.BookmarkName => BookmarkName?.ToString() ?? string.Empty,
                        NoteRefArgument.FootnoteFormat => FootnoteFormat?.ToString()
                            ?? string.Empty,
                        NoteRefArgument.Hyperlink => Hyperlink?.ToString() ?? string.Empty,
                        NoteRefArgument.RelativePosition => RelativePosition?.ToString()
                            ?? string.Empty,
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

            foreach (NoteRefArgument arg in Order)
            {
                Node? child = arg switch
                {
                    NoteRefArgument.BookmarkName => BookmarkName,
                    NoteRefArgument.FootnoteFormat => FootnoteFormat,
                    NoteRefArgument.Hyperlink => Hyperlink,
                    NoteRefArgument.RelativePosition => RelativePosition,
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
                    NoteRefArgument arg = Order[index];
                    switch (arg)
                    {
                        case NoteRefArgument.BookmarkName:
                            if (replacement is ExpressionNode bookmarkName)
                            {
                                current = BookmarkName;
                                BookmarkName = bookmarkName;
                            }
                            break;
                        case NoteRefArgument.FootnoteFormat:
                            if (replacement is BoolFlagNode footnoteFormat)
                            {
                                current = FootnoteFormat;
                                FootnoteFormat = footnoteFormat;
                            }
                            break;
                        case NoteRefArgument.Hyperlink:
                            if (replacement is BoolFlagNode hyperlink)
                            {
                                current = Hyperlink;
                                Hyperlink = hyperlink;
                            }
                            break;
                        case NoteRefArgument.RelativePosition:
                            if (replacement is BoolFlagNode relativePosition)
                            {
                                current = RelativePosition;
                                RelativePosition = relativePosition;
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

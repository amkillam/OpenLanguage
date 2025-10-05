using System;
using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;
using OpenLanguage.WordprocessingML.FieldInstruction;
using OpenLanguage.WordprocessingML.FieldInstruction.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction
{
    public enum XeArgument
    {
        EntryText,
        EntryType,
        ApplyBoldFormatting,
        ApplyItalicFormatting,
        BookmarkName,
        CrossReferenceText,
        YomiText,
    }

    /// <summary>
    /// Represents a strongly-typed XE field instruction.
    /// Defines the text and page number for an index entry, which is used by an INDEX field.
    /// The text of the entry is specified in the field argument. To indicate a subentry, the main entry text
    /// and the subentry text shall be separated by a colon (:). Subentries beyond one level are permitted.
    /// </summary>
    public class XeFieldInstruction : Ast.FieldInstruction
    {
        /// <summary>
        /// The text for the index entry (field-argument). Required.
        /// To indicate a subentry, separate main entry and subentry text with a colon (:).
        /// </summary>
        public ExpressionNode EntryText { get; set; }

        /// <summary>
        /// Switch: \b
        /// Applies bold formatting to the entry's page number. However, if the index style for that entry
        /// is already bold, this switch removes that formatting for that entry.
        /// </summary>
        public BoolFlagNode? ApplyBoldFormatting { get; set; }

        /// <summary>
        /// Switch: \f field-argument
        /// Defines an index entry type. If an INDEX field has the same \f switch and field-argument,
        /// this entry is included in the resulting index; otherwise, it is excluded.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? EntryType { get; set; }

        /// <summary>
        /// Switch: \i
        /// Applies italic formatting to the entry's page number. However, if the index style for that entry
        /// is already italic, this switch removes that formatting for that entry.
        /// </summary>
        public BoolFlagNode? ApplyItalicFormatting { get; set; }

        /// <summary>
        /// Switch: \r field-argument
        /// Instead of the entry's page number, uses the range of pages marked by the bookmark
        /// specified by this field argument.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? BookmarkName { get; set; }

        /// <summary>
        /// Switch: \t field-argument
        /// Uses text from this field argument in place of a page number.
        /// Useful for "See …" or "See also …" entries.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? CrossReferenceText { get; set; }

        /// <summary>
        /// Switch: \y field-argument
        /// Specifies that the text from this field argument defines the yomi (first phonetic character for sorting indexes) for the index entry.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? YomiText { get; set; }

        public List<XeArgument> Order { get; set; }

        public XeFieldInstruction(
            StringLiteralNode instruction,
            ExpressionNode entryText,
            BoolFlagNode? applyBoldFormatting,
            FlaggedArgument<ExpressionNode>? entryType,
            BoolFlagNode? applyItalicFormatting,
            FlaggedArgument<ExpressionNode>? bookmarkName,
            FlaggedArgument<ExpressionNode>? crossReferenceText,
            FlaggedArgument<ExpressionNode>? yomiText,
            List<XeArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            EntryText = entryText ?? throw new ArgumentNullException(nameof(entryText));
            ApplyBoldFormatting = applyBoldFormatting;
            EntryType = entryType;
            ApplyItalicFormatting = applyItalicFormatting;
            BookmarkName = bookmarkName;
            CrossReferenceText = crossReferenceText;
            YomiText = yomiText;

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
                        XeArgument.EntryText => EntryText.ToString(),
                        XeArgument.ApplyBoldFormatting => ApplyBoldFormatting?.ToString()
                            ?? string.Empty,
                        XeArgument.EntryType => EntryType?.ToString() ?? string.Empty,
                        XeArgument.ApplyItalicFormatting => ApplyItalicFormatting?.ToString()
                            ?? string.Empty,
                        XeArgument.BookmarkName => BookmarkName?.ToString() ?? string.Empty,
                        XeArgument.CrossReferenceText => CrossReferenceText?.ToString()
                            ?? string.Empty,
                        XeArgument.YomiText => YomiText?.ToString() ?? string.Empty,
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

            foreach (XeArgument arg in Order)
            {
                Node? child = arg switch
                {
                    XeArgument.EntryText => EntryText,
                    XeArgument.ApplyBoldFormatting => ApplyBoldFormatting,
                    XeArgument.EntryType => EntryType,
                    XeArgument.ApplyItalicFormatting => ApplyItalicFormatting,
                    XeArgument.BookmarkName => BookmarkName,
                    XeArgument.CrossReferenceText => CrossReferenceText,
                    XeArgument.YomiText => YomiText,
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
                    XeArgument arg = Order[index];
                    switch (arg)
                    {
                        case XeArgument.EntryText:
                            if (replacement is ExpressionNode entryText)
                            {
                                current = EntryText;
                                EntryText = entryText;
                            }
                            break;
                        case XeArgument.ApplyBoldFormatting:
                            if (replacement is BoolFlagNode applyBoldFormatting)
                            {
                                current = ApplyBoldFormatting;
                                ApplyBoldFormatting = applyBoldFormatting;
                            }
                            break;
                        case XeArgument.EntryType:
                            if (replacement is FlaggedArgument<ExpressionNode> entryType)
                            {
                                current = EntryType;
                                EntryType = entryType;
                            }
                            break;
                        case XeArgument.ApplyItalicFormatting:
                            if (replacement is BoolFlagNode applyItalicFormatting)
                            {
                                current = ApplyItalicFormatting;
                                ApplyItalicFormatting = applyItalicFormatting;
                            }
                            break;
                        case XeArgument.BookmarkName:
                            if (replacement is FlaggedArgument<ExpressionNode> bookmarkName)
                            {
                                current = BookmarkName;
                                BookmarkName = bookmarkName;
                            }
                            break;
                        case XeArgument.CrossReferenceText:
                            if (replacement is FlaggedArgument<ExpressionNode> crossReferenceText)
                            {
                                current = CrossReferenceText;
                                CrossReferenceText = crossReferenceText;
                            }
                            break;
                        case XeArgument.YomiText:
                            if (replacement is FlaggedArgument<ExpressionNode> yomiText)
                            {
                                current = YomiText;
                                YomiText = yomiText;
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

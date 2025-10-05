using System;
using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;
using OpenLanguage.WordprocessingML.FieldInstruction.Generated;

namespace OpenLanguage.WordprocessingML.FieldInstruction
{
    public enum TaArgument
    {
        EntryText,
        ApplyBoldFormatting,
        CategoryNumber,
        ApplyItalicFormatting,
        LongCitation,
        BookmarkName,
        ShortCitation,
    }

    /// <summary>
    /// Represents a strongly-typed TA field instruction.
    /// Defines the text and page number for a table of authorities entry, which is used by a `TOA` field.
    /// </summary>
    public class TaFieldInstruction : Ast.FieldInstruction
    {
        /// <summary>
        /// The text for the table of authorities entry
        /// </summary>
        public ExpressionNode? EntryText { get; set; }

        /// <summary>
        /// Switch: \b
        /// Applies bold formatting to the page number for the entry. If the table of authorities style for the entry already has bold formatting, \b removes it.
        /// </summary>
        public BoolFlagNode? ApplyBoldFormatting { get; set; }

        /// <summary>
        /// Switch: \c field-argument
        /// Text in this switch's field-argument specifies the integral entry category, which is a number that corresponds to the order of categories. The number determines how citations are grouped in tables of authorities. If \c is omitted, category 1 is the default.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? CategoryNumber { get; set; }

        /// <summary>
        /// Switch: \i
        /// Applies italic formatting to the page number for the entry. If the table of authorities' style for the entry already has italic formatting, \i removes it.
        /// </summary>
        public BoolFlagNode? ApplyItalicFormatting { get; set; }

        /// <summary>
        /// Switch: \l field-argument
        /// Text in this switch's field-argument defines the long citation for the entry.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? LongCitation { get; set; }

        /// <summary>
        /// Switch: \r field-argument
        /// Inserts as the entry's page number the range of pages marked by the bookmark specified by text in this switch's field-argument.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? BookmarkName { get; set; }

        /// <summary>
        /// Switch: \s field-argument
        /// Text in this switch's field-argument defines the short citation for the entry.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? ShortCitation { get; set; }

        public List<TaArgument> Order { get; set; } = new List<TaArgument>();

        public TaFieldInstruction(
            StringLiteralNode instruction,
            ExpressionNode? entryText,
            BoolFlagNode? applyBoldFormatting,
            FlaggedArgument<ExpressionNode>? categoryNumber,
            BoolFlagNode? applyItalicFormatting,
            FlaggedArgument<ExpressionNode>? longCitation,
            FlaggedArgument<ExpressionNode>? bookmarkName,
            FlaggedArgument<ExpressionNode>? shortCitation,
            List<TaArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            EntryText = entryText;
            ApplyBoldFormatting = applyBoldFormatting;
            CategoryNumber = categoryNumber;
            ApplyItalicFormatting = applyItalicFormatting;
            LongCitation = longCitation;
            BookmarkName = bookmarkName;
            ShortCitation = shortCitation;

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
                        TaArgument.EntryText => EntryText?.ToString() ?? string.Empty,
                        TaArgument.ApplyBoldFormatting => ApplyBoldFormatting?.ToString()
                            ?? string.Empty,
                        TaArgument.CategoryNumber => CategoryNumber?.ToString() ?? string.Empty,
                        TaArgument.ApplyItalicFormatting => ApplyItalicFormatting?.ToString()
                            ?? string.Empty,
                        TaArgument.LongCitation => LongCitation?.ToString() ?? string.Empty,
                        TaArgument.BookmarkName => BookmarkName?.ToString() ?? string.Empty,
                        TaArgument.ShortCitation => ShortCitation?.ToString() ?? string.Empty,
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

            foreach (TaArgument arg in Order)
            {
                Node? child = arg switch
                {
                    TaArgument.EntryText => EntryText,
                    TaArgument.ApplyBoldFormatting => ApplyBoldFormatting,
                    TaArgument.CategoryNumber => CategoryNumber,
                    TaArgument.ApplyItalicFormatting => ApplyItalicFormatting,
                    TaArgument.LongCitation => LongCitation,
                    TaArgument.BookmarkName => BookmarkName,
                    TaArgument.ShortCitation => ShortCitation,
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
                    TaArgument arg = Order[index];
                    switch (arg)
                    {
                        case TaArgument.EntryText:
                            if (replacement is ExpressionNode entryText)
                            {
                                current = EntryText;
                                EntryText = entryText;
                            }
                            break;
                        case TaArgument.ApplyBoldFormatting:
                            if (replacement is BoolFlagNode applyBoldFormatting)
                            {
                                current = ApplyBoldFormatting;
                                ApplyBoldFormatting = applyBoldFormatting;
                            }
                            break;
                        case TaArgument.CategoryNumber:
                            if (replacement is FlaggedArgument<ExpressionNode> categoryNumber)
                            {
                                current = CategoryNumber;
                                CategoryNumber = categoryNumber;
                            }
                            break;
                        case TaArgument.ApplyItalicFormatting:
                            if (replacement is BoolFlagNode applyItalicFormatting)
                            {
                                current = ApplyItalicFormatting;
                                ApplyItalicFormatting = applyItalicFormatting;
                            }
                            break;
                        case TaArgument.LongCitation:
                            if (replacement is FlaggedArgument<ExpressionNode> longCitation)
                            {
                                current = LongCitation;
                                LongCitation = longCitation;
                            }
                            break;
                        case TaArgument.BookmarkName:
                            if (replacement is FlaggedArgument<ExpressionNode> bookmarkName)
                            {
                                current = BookmarkName;
                                BookmarkName = bookmarkName;
                            }
                            break;
                        case TaArgument.ShortCitation:
                            if (replacement is FlaggedArgument<ExpressionNode> shortCitation)
                            {
                                current = ShortCitation;
                                ShortCitation = shortCitation;
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

using System;
using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;
using OpenLanguage.WordprocessingML.FieldInstruction.Generated;

namespace OpenLanguage.WordprocessingML.FieldInstruction
{
    public enum ToaArgument
    {
        Category,
        BookmarkName,
        CategoryNumber,
        SequencePageSeparator,
        EntryPageSeparator,
        PageRangeSeparator,
        RemoveFormatting,
        IncludeCategoryHeading,
        MultiplePageSeparator,
        UsePassim,
        SequenceIdentifier,
    }

    /// <summary>
    /// Represents a strongly-typed TOA field instruction.
    /// Builds a table of authorities (that is, a list of the references in a legal document, such as references to cases, statutes, and rules, along with the numbers of the pages on which the references appear) using the entries specified by TA fields.
    /// </summary>
    public class ToaFieldInstruction : Ast.FieldInstruction
    {
        /// <summary>
        /// The category for the table of authorities
        /// </summary>
        public ExpressionNode? Category { get; set; }

        /// <summary>
        /// Switch: \b field-argument
        /// Bookmark name
        /// </summary>
        public FlaggedArgument<ExpressionNode>? BookmarkName { get; set; }

        /// <summary>
        /// Switch: \c field-argument
        /// Includes the entries whose integral category is that specified by text in this switch's field-argument.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? CategoryNumber { get; set; }

        /// <summary>
        /// Switch: \d field-argument
        /// Used in conjunction with \s to specify the character sequence that separates the sequence numbers and page numbers. If \d is omitted, a hyphen (-) is used.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? SequencePageSeparator { get; set; }

        /// <summary>
        /// Switch: \e field-argument
        /// Text in this switch's field-argument specifies the character sequence that separates a table of authorities entry and its page number. If \e is not specified, a tab stop with leader dots is used.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? EntryPageSeparator { get; set; }

        /// <summary>
        /// Switch: \g field-argument
        /// Text in this switch's field-argument specifies the character sequence that separates the pages in a page range. If \g is omitted, an en dash (–) is used.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? PageRangeSeparator { get; set; }

        /// <summary>
        /// Switch: \f
        /// Remove formatting from entries
        /// </summary>
        public BoolFlagNode? RemoveFormatting { get; set; }

        /// <summary>
        /// Switch: \h
        /// Includes the category heading for the entries in a table of authorities.
        /// </summary>
        public BoolFlagNode? IncludeCategoryHeading { get; set; }

        /// <summary>
        /// Switch: \l field-argument
        /// Text in this switch's field-argument specifies the character sequence that separates multiple page references. If \l is omitted, a comma (,) and space are used.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? MultiplePageSeparator { get; set; }

        /// <summary>
        /// Switch: \p
        /// Replaces five or more different page references to the same authority with "passim", which is used to indicate that a word or passage occurs frequently in the work cited.
        /// </summary>
        public BoolFlagNode? UsePassim { get; set; }

        /// <summary>
        /// Switch: \s field-argument
        /// Includes a case or section number before the page number. The entry shall be numbered with a SEQ field, and text in this switch's field-argument shall match the identifier in the SEQ field.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? SequenceIdentifier { get; set; }

        public List<ToaArgument> Order { get; set; } = new List<ToaArgument>();

        public ToaFieldInstruction(
            StringLiteralNode instruction,
            ExpressionNode? category,
            FlaggedArgument<ExpressionNode>? bookmarkName,
            FlaggedArgument<ExpressionNode>? categoryNumber,
            FlaggedArgument<ExpressionNode>? sequencePageSeparator,
            FlaggedArgument<ExpressionNode>? entryPageSeparator,
            FlaggedArgument<ExpressionNode>? pageRangeSeparator,
            BoolFlagNode? removeFormatting,
            BoolFlagNode? includeCategoryHeading,
            FlaggedArgument<ExpressionNode>? multiplePageSeparator,
            BoolFlagNode? usePassim,
            FlaggedArgument<ExpressionNode>? sequenceIdentifier,
            List<ToaArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            Category = category;
            BookmarkName = bookmarkName;
            CategoryNumber = categoryNumber;
            SequencePageSeparator = sequencePageSeparator;
            EntryPageSeparator = entryPageSeparator;
            PageRangeSeparator = pageRangeSeparator;
            RemoveFormatting = removeFormatting;
            IncludeCategoryHeading = includeCategoryHeading;
            MultiplePageSeparator = multiplePageSeparator;
            UsePassim = usePassim;
            SequenceIdentifier = sequenceIdentifier;
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
                        ToaArgument.Category => Category?.ToString() ?? string.Empty,
                        ToaArgument.BookmarkName => BookmarkName?.ToString() ?? string.Empty,
                        ToaArgument.CategoryNumber => CategoryNumber?.ToString() ?? string.Empty,
                        ToaArgument.SequencePageSeparator => SequencePageSeparator?.ToString()
                            ?? string.Empty,
                        ToaArgument.EntryPageSeparator => EntryPageSeparator?.ToString()
                            ?? string.Empty,
                        ToaArgument.PageRangeSeparator => PageRangeSeparator?.ToString()
                            ?? string.Empty,
                        ToaArgument.RemoveFormatting => RemoveFormatting?.ToString()
                            ?? string.Empty,
                        ToaArgument.IncludeCategoryHeading => IncludeCategoryHeading?.ToString()
                            ?? string.Empty,
                        ToaArgument.MultiplePageSeparator => MultiplePageSeparator?.ToString()
                            ?? string.Empty,
                        ToaArgument.UsePassim => UsePassim?.ToString() ?? string.Empty,
                        ToaArgument.SequenceIdentifier => SequenceIdentifier?.ToString()
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

            foreach (ToaArgument arg in Order)
            {
                Node? child = arg switch
                {
                    ToaArgument.Category => Category,
                    ToaArgument.BookmarkName => BookmarkName,
                    ToaArgument.CategoryNumber => CategoryNumber,
                    ToaArgument.SequencePageSeparator => SequencePageSeparator,
                    ToaArgument.EntryPageSeparator => EntryPageSeparator,
                    ToaArgument.PageRangeSeparator => PageRangeSeparator,
                    ToaArgument.RemoveFormatting => RemoveFormatting,
                    ToaArgument.IncludeCategoryHeading => IncludeCategoryHeading,
                    ToaArgument.MultiplePageSeparator => MultiplePageSeparator,
                    ToaArgument.UsePassim => UsePassim,
                    ToaArgument.SequenceIdentifier => SequenceIdentifier,
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
                    ToaArgument arg = Order[index];
                    switch (arg)
                    {
                        case ToaArgument.Category:
                            if (replacement is ExpressionNode category)
                            {
                                current = Category;
                                Category = category;
                            }
                            break;
                        case ToaArgument.BookmarkName:
                            if (replacement is FlaggedArgument<ExpressionNode> bookmarkName)
                            {
                                current = BookmarkName;
                                BookmarkName = bookmarkName;
                            }
                            break;
                        case ToaArgument.CategoryNumber:
                            if (replacement is FlaggedArgument<ExpressionNode> categoryNumber)
                            {
                                current = CategoryNumber;
                                CategoryNumber = categoryNumber;
                            }
                            break;
                        case ToaArgument.SequencePageSeparator:
                            if (
                                replacement is FlaggedArgument<ExpressionNode> sequencePageSeparator
                            )
                            {
                                current = SequencePageSeparator;
                                SequencePageSeparator = sequencePageSeparator;
                            }
                            break;
                        case ToaArgument.EntryPageSeparator:
                            if (replacement is FlaggedArgument<ExpressionNode> entryPageSeparator)
                            {
                                current = EntryPageSeparator;
                                EntryPageSeparator = entryPageSeparator;
                            }
                            break;
                        case ToaArgument.PageRangeSeparator:
                            if (replacement is FlaggedArgument<ExpressionNode> pageRangeSeparator)
                            {
                                current = PageRangeSeparator;
                                PageRangeSeparator = pageRangeSeparator;
                            }
                            break;
                        case ToaArgument.RemoveFormatting:
                            if (replacement is BoolFlagNode removeFormatting)
                            {
                                current = RemoveFormatting;
                                RemoveFormatting = removeFormatting;
                            }
                            break;
                        case ToaArgument.IncludeCategoryHeading:
                            if (replacement is BoolFlagNode includeCategoryHeading)
                            {
                                current = IncludeCategoryHeading;
                                IncludeCategoryHeading = includeCategoryHeading;
                            }
                            break;
                        case ToaArgument.MultiplePageSeparator:
                            if (
                                replacement is FlaggedArgument<ExpressionNode> multiplePageSeparator
                            )
                            {
                                current = MultiplePageSeparator;
                                MultiplePageSeparator = multiplePageSeparator;
                            }
                            break;
                        case ToaArgument.UsePassim:
                            if (replacement is BoolFlagNode usePassim)
                            {
                                current = UsePassim;
                                UsePassim = usePassim;
                            }
                            break;
                        case ToaArgument.SequenceIdentifier:
                            if (replacement is FlaggedArgument<ExpressionNode> sequenceIdentifier)
                            {
                                current = SequenceIdentifier;
                                SequenceIdentifier = sequenceIdentifier;
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

using System;
using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;
using OpenLanguage.WordprocessingML.FieldInstruction;
using OpenLanguage.WordprocessingML.FieldInstruction.Ast;
using OpenLanguage.WordprocessingML.FieldInstruction.Generated;

namespace OpenLanguage.WordprocessingML.FieldInstruction
{
    public enum SeqArgument
    {
        SequenceName,
        BookmarkName,
        RepeatPreviousNumber,
        Hide,
        InsertNext,
        ResetToNumber,
        ResetToHeadingLevel,
        GeneralFormat,
    }

    /// <summary>
    /// Represents a strongly-typed SEQ field instruction.
    /// Sequentially numbers chapters, tables, figures, and other user-defined lists of items in a document.
    /// If an item and its SEQ field are added, deleted, or moved, updating the remaining SEQ fields in the
    /// document reflects the new sequence. A SEQ field in a header, footer, annotation, or footnote shall NOT affect
    /// the sequence numbering that results from SEQ fields in the document text.
    ///
    /// Syntax: SEQ identifier [ field-argument ] [ switches ]
    ///
    /// The identifier is the name assigned to the series of items that are to be numbered (e.g., Equation, Figure, Table, Thing).
    /// The identifier shall start with a Latin letter and shall consist of no more than 40 Latin letters, Arabic digits, and underscores.
    ///
    /// The optional field-argument specifies a bookmark name that refers to an item elsewhere in the document
    /// rather than in the current location.
    ///
    /// Field Value: The next number in the sequence. If no numeric-formatting-switch is present, \* Arabic is used.
    ///
    /// Switches:
    /// - \c: Repeats the closest preceding sequence number (useful for inserting chapter numbers in headers or footers)
    /// - \h: Hides the field result unless a general-formatting-switch is also present (useful for cross-references)
    /// - \n: Inserts the next sequence number for the specified item (this is the default behavior)
    /// - \r field-argument: Resets the sequence number to the integer number specified by the field-argument
    /// - \s field-argument: Resets the sequence number to the built-in (integer) heading level specified by the field-argument
    /// </summary>
    public class SeqFieldInstruction : Ast.FieldInstruction
    {
        /// <summary>
        /// The identifier - name assigned to the series of items that are to be numbered.
        /// Must start with a Latin letter and consist of no more than 40 Latin letters, Arabic digits, and underscores.
        /// Examples: Equation, Figure, Table, Thing
        /// </summary>
        public ExpressionNode? SequenceName { get; set; }

        /// <summary>
        /// Optional field-argument specifying a bookmark name that refers to an item elsewhere in the document
        /// rather than in the current location.
        /// </summary>
        public ExpressionNode? BookmarkName { get; set; }

        /// <summary>
        /// Switch: \c
        /// Repeats the closest preceding sequence number.
        /// This is useful for inserting chapter numbers in headers or footers.
        /// </summary>
        public BoolFlagNode? RepeatPreviousNumber { get; set; }

        /// <summary>
        /// Switch: \h
        /// Hides the field result unless a general-formatting-switch is also present.
        /// This switch can be used to refer to a SEQ field in a cross-reference without printing the number.
        /// </summary>
        public BoolFlagNode? Hide { get; set; }

        /// <summary>
        /// Switch: \n
        /// Inserts the next sequence number for the specified item. This is the default behavior.
        /// </summary>
        public BoolFlagNode? InsertNext { get; set; }

        /// <summary>
        /// Switch: \r field-argument
        /// Resets the sequence number to the integer number specified by text in this switch's field-argument.
        /// </summary>
        public FlaggedArgument<NumericLiteralNode<int>>? ResetToNumber { get; set; }

        /// <summary>
        /// Switch: \s field-argument
        /// Resets the sequence number to the built-in (integer) heading level specified by text in this switch's field-argument.
        /// </summary>
        public FlaggedArgument<NumericLiteralNode<int>>? ResetToHeadingLevel { get; set; }

        public FlaggedArgument<ExpressionNode>? GeneralFormat { get; set; }

        public List<SeqArgument> Order { get; set; } = new List<SeqArgument>();

        public SeqFieldInstruction(
            StringLiteralNode instruction,
            ExpressionNode? sequenceName,
            ExpressionNode? bookmarkName,
            BoolFlagNode? repeatPreviousNumber,
            BoolFlagNode? hide,
            BoolFlagNode? insertNext,
            FlaggedArgument<NumericLiteralNode<int>>? resetToNumber,
            FlaggedArgument<NumericLiteralNode<int>>? resetToHeadingLevel,
            FlaggedArgument<ExpressionNode>? generalFormat,
            List<SeqArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            SequenceName = sequenceName;
            BookmarkName = bookmarkName;
            RepeatPreviousNumber = repeatPreviousNumber;
            Hide = hide;
            InsertNext = insertNext;
            ResetToNumber = resetToNumber;
            ResetToHeadingLevel = resetToHeadingLevel;
            GeneralFormat = generalFormat;
            Order = order;
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToRawString()
        {
            return Instruction.ToString()
                + string.Concat(
                    Order.Select(a =>
                        a switch
                        {
                            SeqArgument.SequenceName => SequenceName?.ToString() ?? string.Empty,
                            SeqArgument.BookmarkName => BookmarkName?.ToString() ?? string.Empty,
                            SeqArgument.RepeatPreviousNumber => RepeatPreviousNumber?.ToString()
                                ?? string.Empty,
                            SeqArgument.Hide => Hide?.ToString() ?? string.Empty,
                            SeqArgument.InsertNext => InsertNext?.ToString() ?? string.Empty,
                            SeqArgument.ResetToNumber => ResetToNumber?.ToString() ?? string.Empty,
                            SeqArgument.ResetToHeadingLevel => ResetToHeadingLevel?.ToString(),
                            SeqArgument.GeneralFormat => GeneralFormat?.ToString() ?? string.Empty,
                            _ => string.Empty,
                        }
                    )
                );
        }

        public override IEnumerable<O> Children<O>()
        {
            if (Instruction is O oInstruction)
            {
                yield return oInstruction;
            }

            foreach (SeqArgument arg in Order)
            {
                Node? child = arg switch
                {
                    SeqArgument.SequenceName => SequenceName,
                    SeqArgument.BookmarkName => BookmarkName,
                    SeqArgument.RepeatPreviousNumber => RepeatPreviousNumber,
                    SeqArgument.Hide => Hide,
                    SeqArgument.InsertNext => InsertNext,
                    SeqArgument.ResetToNumber => ResetToNumber,
                    SeqArgument.ResetToHeadingLevel => ResetToHeadingLevel,
                    SeqArgument.GeneralFormat => GeneralFormat,
                    _ => null,
                };

                if (child is O oChild)
                {
                    yield return oChild;
                }
            }
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
                    SeqArgument arg = Order[index];
                    switch (arg)
                    {
                        case SeqArgument.SequenceName:
                            if (replacement is ExpressionNode sequenceName)
                            {
                                current = SequenceName;
                                SequenceName = sequenceName;
                            }
                            break;
                        case SeqArgument.BookmarkName:
                            if (replacement is ExpressionNode bookmarkName)
                            {
                                current = BookmarkName;
                                BookmarkName = bookmarkName;
                            }
                            break;
                        case SeqArgument.RepeatPreviousNumber:
                            if (replacement is BoolFlagNode repeatPreviousNumber)
                            {
                                current = RepeatPreviousNumber;
                                RepeatPreviousNumber = repeatPreviousNumber;
                            }
                            break;
                        case SeqArgument.Hide:
                            if (replacement is BoolFlagNode hide)
                            {
                                current = Hide;
                                Hide = hide;
                            }
                            break;
                        case SeqArgument.InsertNext:
                            if (replacement is BoolFlagNode insertNext)
                            {
                                current = InsertNext;
                                InsertNext = insertNext;
                            }
                            break;
                        case SeqArgument.ResetToNumber:
                            if (
                                replacement
                                is FlaggedArgument<NumericLiteralNode<int>> resetToNumber
                            )
                            {
                                current = ResetToNumber;
                                ResetToNumber = resetToNumber;
                            }
                            break;
                        case SeqArgument.ResetToHeadingLevel:
                            if (
                                replacement
                                is FlaggedArgument<NumericLiteralNode<int>> resetToHeadingLevel
                            )
                            {
                                current = ResetToHeadingLevel;
                                ResetToHeadingLevel = resetToHeadingLevel;
                            }
                            break;
                        case SeqArgument.GeneralFormat:
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

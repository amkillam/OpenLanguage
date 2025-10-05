using System;
using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;
using OpenLanguage.WordprocessingML.FieldInstruction;
using OpenLanguage.WordprocessingML.FieldInstruction.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction
{
    public enum MergeFieldArgument
    {
        FieldName,
        TextBefore,
        TextAfter,
        IsMapped,
        VerticalFormatting,
        NumericFormat,
        GeneralFormat,
        DateTimeFormat,
    }

    /// <summary>
    /// Represents a strongly-typed MERGEFIELD field instruction.
    /// Retrieves the name of a data field designated by text in field-argument within the merge characters in a mail merge main document.
    /// When the main document is merged with the selected data source, information from the specified data field is inserted in place of the merge field.
    /// The name designated by text shall match exactly the field name in the header record.
    ///
    /// Syntax: MERGEFIELD field-argument [ switch ]
    ///
    /// Field Value: The name of a data field designated by text in field-argument.
    ///
    /// Switches:
    /// - \b field-argument: The text in this switch's field-argument specifies the text to be inserted before the MERGEFIELD field if the field is not blank
    /// - \f field-argument: The text in this switch's field-argument specifies the text to be inserted after the MERGEFIELD field if the field is not blank
    /// - \m: Specifies that the MERGEFIELD field is a mapped field
    /// - \v: Enables character conversion for vertical formatting
    /// </summary>
    public class MergeFieldFieldInstruction : Ast.FieldInstruction
    {
        /// <summary>
        /// The name of the merge field
        /// </summary>
        public ExpressionNode FieldName { get; set; }

        /// <summary>
        /// Switch: \b field-argument
        /// The text in this switch's field-argument specifies the text to be inserted before the MERGEFIELD field if the field is not blank.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? TextBefore { get; set; }

        /// <summary>
        /// Switch: \f field-argument
        /// The text in this switch's field-argument specifies the text to be inserted after the MERGEFIELD field if the field is not blank.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? TextAfter { get; set; }

        /// <summary>
        /// Switch: \m
        /// Specifies that the MERGEFIELD field is a mapped field.
        /// </summary>
        public BoolFlagNode? IsMapped { get; set; }

        /// <summary>
        /// Switch: \v
        /// Enables character conversion for vertical formatting.
        /// </summary>
        public BoolFlagNode? VerticalFormatting { get; set; }

        /// <summary>
        /// Switch: \# field-argument
        /// Numeric formatting switch for the field value.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? NumericFormat { get; set; }

        /// <summary>
        /// Switch: \* field-argument
        /// General formatting switch for the field value.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? GeneralFormat { get; set; }

        /// <summary>
        /// Switch: \@ field-argument
        /// Date/Time formatting switch for the field value.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? DateTimeFormat { get; set; }

        public List<MergeFieldArgument> Order { get; set; } = new List<MergeFieldArgument>();

        public MergeFieldFieldInstruction(
            StringLiteralNode instruction,
            ExpressionNode fieldName,
            FlaggedArgument<ExpressionNode>? textBefore,
            FlaggedArgument<ExpressionNode>? textAfter,
            BoolFlagNode? isMapped,
            BoolFlagNode? verticalFormatting,
            FlaggedArgument<ExpressionNode>? numericFormat,
            FlaggedArgument<ExpressionNode>? generalFormat,
            FlaggedArgument<ExpressionNode>? dateTimeFormat,
            List<MergeFieldArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            FieldName = fieldName ?? throw new ArgumentNullException(nameof(fieldName));
            TextBefore = textBefore;
            TextAfter = textAfter;
            IsMapped = isMapped;
            VerticalFormatting = verticalFormatting;
            NumericFormat = numericFormat;
            GeneralFormat = generalFormat;
            DateTimeFormat = dateTimeFormat;
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
                        MergeFieldArgument.FieldName => FieldName?.ToString() ?? string.Empty,
                        MergeFieldArgument.TextBefore => TextBefore?.ToString() ?? string.Empty,
                        MergeFieldArgument.TextAfter => TextAfter?.ToString() ?? string.Empty,
                        MergeFieldArgument.IsMapped => IsMapped?.ToString() ?? string.Empty,
                        MergeFieldArgument.VerticalFormatting => VerticalFormatting?.ToString()
                            ?? string.Empty,
                        MergeFieldArgument.NumericFormat => NumericFormat?.ToString()
                            ?? string.Empty,
                        MergeFieldArgument.GeneralFormat => GeneralFormat?.ToString()
                            ?? string.Empty,
                        MergeFieldArgument.DateTimeFormat => DateTimeFormat?.ToString()
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
            foreach (MergeFieldArgument arg in Order)
            {
                switch (arg)
                {
                    case MergeFieldArgument.FieldName:
                        if (FieldName is O oFieldName)
                        {
                            yield return oFieldName;
                        }
                        break;
                    case MergeFieldArgument.TextBefore:
                        if (TextBefore is O oTextBefore)
                        {
                            yield return oTextBefore;
                        }
                        break;
                    case MergeFieldArgument.TextAfter:
                        if (TextAfter is O oTextAfter)
                        {
                            yield return oTextAfter;
                        }
                        break;
                    case MergeFieldArgument.IsMapped:
                        if (IsMapped is O oIsMapped)
                        {
                            yield return oIsMapped;
                        }
                        break;
                    case MergeFieldArgument.VerticalFormatting:
                        if (VerticalFormatting is O oVerticalFormatting)
                        {
                            yield return oVerticalFormatting;
                        }
                        break;
                    case MergeFieldArgument.NumericFormat:
                        if (NumericFormat is O oNumeric)
                        {
                            yield return oNumeric;
                        }
                        break;
                    case MergeFieldArgument.GeneralFormat:
                        if (GeneralFormat is O oGeneral)
                        {
                            yield return oGeneral;
                        }
                        break;
                    case MergeFieldArgument.DateTimeFormat:
                        if (DateTimeFormat is O oDateTime)
                        {
                            yield return oDateTime;
                        }
                        break;
                }
            }
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;
            if (index == 0 && replacement is StringLiteralNode bon)
            {
                current = Instruction;
                Instruction = bon;
            }
            else
            {
                index--;
                if (index < Order.Count)
                {
                    MergeFieldArgument arg = Order[index];
                    switch (arg)
                    {
                        case MergeFieldArgument.FieldName:
                            if (replacement is ExpressionNode fieldName)
                            {
                                current = FieldName;
                                FieldName = fieldName;
                            }
                            break;
                        case MergeFieldArgument.TextBefore:
                            if (replacement is FlaggedArgument<ExpressionNode> textBefore)
                            {
                                current = TextBefore;
                                TextBefore = textBefore;
                            }
                            break;
                        case MergeFieldArgument.TextAfter:
                            if (replacement is FlaggedArgument<ExpressionNode> textAfter)
                            {
                                current = TextAfter;
                                TextAfter = textAfter;
                            }
                            break;
                        case MergeFieldArgument.IsMapped:
                            if (replacement is BoolFlagNode isMapped)
                            {
                                current = IsMapped;
                                IsMapped = isMapped;
                            }
                            break;
                        case MergeFieldArgument.VerticalFormatting:
                            if (replacement is BoolFlagNode verticalFormatting)
                            {
                                current = VerticalFormatting;
                                VerticalFormatting = verticalFormatting;
                            }
                            break;
                        case MergeFieldArgument.NumericFormat:
                            if (replacement is FlaggedArgument<ExpressionNode> numFmt)
                            {
                                current = NumericFormat;
                                NumericFormat = numFmt;
                            }
                            break;
                        case MergeFieldArgument.GeneralFormat:
                            if (replacement is FlaggedArgument<ExpressionNode> genFmt)
                            {
                                current = GeneralFormat;
                                GeneralFormat = genFmt;
                            }
                            break;
                        case MergeFieldArgument.DateTimeFormat:
                            if (replacement is FlaggedArgument<ExpressionNode> dtFmt)
                            {
                                current = DateTimeFormat;
                                DateTimeFormat = dtFmt;
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

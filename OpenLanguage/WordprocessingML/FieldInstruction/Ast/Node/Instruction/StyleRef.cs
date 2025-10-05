using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction
{
    public enum StyleRefArgument
    {
        StyleName,
        InsertNearestTextFollowing,
        InsertParagraphNumber,
        InsertRelativePosition,
        InsertParagraphNumberRelative,
        SuppressNonDelimiter,
        InsertParagraphNumberFull,
        GeneralFormat,
        UndocumentedS,
    }

    /// <summary>
    /// Represents a strongly-typed STYLEREF field instruction.
    /// Inserts the nearest piece of text prior to this field that is formatted by the style whose name is specified by text in field-argument.
    /// The style can be a paragraph style or a character style.
    /// </summary>
    public class StyleRefFieldInstruction : Ast.FieldInstruction
    {
        /// <summary>
        /// The name of the style to reference.
        /// </summary>
        public ExpressionNode? StyleName { get; set; }

        /// <summary>
        /// Switch: \l
        /// Inserts the nearest text following the field.
        /// </summary>
        public BoolFlagNode? InsertNearestTextFollowing { get; set; }

        /// <summary>
        /// Switch: \n
        /// Inserts the paragraph number of the referenced paragraph exactly as it appears in the document.
        /// </summary>
        public BoolFlagNode? InsertParagraphNumber { get; set; }

        /// <summary>
        /// Switch: \p
        /// Inserts the relative position of the referenced paragraph as being "above" or "below".
        /// </summary>
        public BoolFlagNode? InsertRelativePosition { get; set; }

        /// <summary>
        /// Switch: \r
        /// Inserts the paragraph number of the referenced paragraph exactly in relative context.
        /// </summary>
        public BoolFlagNode? InsertParagraphNumberRelative { get; set; }

        /// <summary>
        /// Switch: \t
        /// When used with the \n, \r, or \w switch, causes non-delimiter and non-numerical text to be suppressed.
        /// </summary>
        public BoolFlagNode? SuppressNonDelimiter { get; set; }

        /// <summary>
        /// Switch: \w
        /// Inserts the paragraph number of the referenced paragraph in full context, from anywhere in the document.
        /// </summary>
        public BoolFlagNode? InsertParagraphNumberFull { get; set; }

        /// <summary>
        /// General formatting switch.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? GeneralFormat { get; set; }

        /// <summary>
        /// Undocumented \s switch.
        /// </summary>
        public BoolFlagNode? UndocumentedS { get; set; }

        public List<StyleRefArgument> Order { get; set; } = new List<StyleRefArgument>();

        public StyleRefFieldInstruction(
            StringLiteralNode instruction,
            ExpressionNode? styleName,
            BoolFlagNode? insertNearestTextFollowing,
            BoolFlagNode? insertParagraphNumber,
            BoolFlagNode? insertRelativePosition,
            BoolFlagNode? insertParagraphNumberRelative,
            BoolFlagNode? suppressNonDelimiter,
            BoolFlagNode? insertParagraphNumberFull,
            FlaggedArgument<ExpressionNode>? generalFormat,
            BoolFlagNode? undocumentedS,
            List<StyleRefArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            StyleName = styleName;
            InsertNearestTextFollowing = insertNearestTextFollowing;
            InsertParagraphNumber = insertParagraphNumber;
            InsertRelativePosition = insertRelativePosition;
            InsertParagraphNumberRelative = insertParagraphNumberRelative;
            SuppressNonDelimiter = suppressNonDelimiter;
            InsertParagraphNumberFull = insertParagraphNumberFull;
            GeneralFormat = generalFormat;
            UndocumentedS = undocumentedS;
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
                        StyleRefArgument.StyleName => StyleName?.ToString() ?? string.Empty,
                        StyleRefArgument.InsertNearestTextFollowing =>
                            InsertNearestTextFollowing?.ToString() ?? string.Empty,
                        StyleRefArgument.InsertParagraphNumber => InsertParagraphNumber?.ToString()
                            ?? string.Empty,
                        StyleRefArgument.InsertRelativePosition =>
                            InsertRelativePosition?.ToString() ?? string.Empty,
                        StyleRefArgument.InsertParagraphNumberRelative =>
                            InsertParagraphNumberRelative?.ToString() ?? string.Empty,
                        StyleRefArgument.SuppressNonDelimiter => SuppressNonDelimiter?.ToString()
                            ?? string.Empty,
                        StyleRefArgument.InsertParagraphNumberFull =>
                            InsertParagraphNumberFull?.ToString() ?? string.Empty,
                        StyleRefArgument.GeneralFormat => GeneralFormat?.ToString() ?? string.Empty,
                        StyleRefArgument.UndocumentedS => UndocumentedS?.ToString() ?? string.Empty,
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

            foreach (StyleRefArgument arg in Order)
            {
                Node? node = arg switch
                {
                    StyleRefArgument.StyleName => StyleName,
                    StyleRefArgument.InsertNearestTextFollowing => InsertNearestTextFollowing,
                    StyleRefArgument.InsertParagraphNumber => InsertParagraphNumber,
                    StyleRefArgument.InsertRelativePosition => InsertRelativePosition,
                    StyleRefArgument.InsertParagraphNumberRelative => InsertParagraphNumberRelative,
                    StyleRefArgument.SuppressNonDelimiter => SuppressNonDelimiter,
                    StyleRefArgument.InsertParagraphNumberFull => InsertParagraphNumberFull,
                    StyleRefArgument.GeneralFormat => GeneralFormat,
                    StyleRefArgument.UndocumentedS => UndocumentedS,
                    _ => null,
                };
                if (node is O oNode)
                {
                    yield return oNode;
                }
            }

            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;
            if (index == 0 && replacement is StringLiteralNode instruction)
            {
                current = Instruction;
                Instruction = instruction;
            }
            else
            {
                index--;
                if (index >= 0 && index < Order.Count)
                {
                    StyleRefArgument arg = Order[index];
                    switch (arg)
                    {
                        case StyleRefArgument.StyleName:
                            if (replacement is ExpressionNode styleName)
                            {
                                current = StyleName;
                                StyleName = styleName;
                            }
                            break;
                        case StyleRefArgument.InsertNearestTextFollowing:
                            if (replacement is BoolFlagNode insertNearestTextFollowing)
                            {
                                current = InsertNearestTextFollowing;
                                InsertNearestTextFollowing = insertNearestTextFollowing;
                            }
                            break;
                        case StyleRefArgument.InsertParagraphNumber:
                            if (replacement is BoolFlagNode insertParagraphNumber)
                            {
                                current = InsertParagraphNumber;
                                InsertParagraphNumber = insertParagraphNumber;
                            }
                            break;

                        case StyleRefArgument.InsertRelativePosition:
                            if (replacement is BoolFlagNode insertRelativePosition)
                            {
                                current = InsertRelativePosition;
                                InsertRelativePosition = insertRelativePosition;
                            }
                            break;
                        case StyleRefArgument.InsertParagraphNumberRelative:
                            if (replacement is BoolFlagNode insertParagraphNumberRelative)
                            {
                                current = InsertParagraphNumberRelative;
                                InsertParagraphNumberRelative = insertParagraphNumberRelative;
                            }
                            break;
                        case StyleRefArgument.SuppressNonDelimiter:
                            if (replacement is BoolFlagNode suppressNonDelimiter)
                            {
                                current = SuppressNonDelimiter;
                                SuppressNonDelimiter = suppressNonDelimiter;
                            }
                            break;
                        case StyleRefArgument.InsertParagraphNumberFull:
                            if (replacement is BoolFlagNode insertParagraphNumberFull)
                            {
                                current = InsertParagraphNumberFull;
                                InsertParagraphNumberFull = insertParagraphNumberFull;
                            }
                            break;
                        case StyleRefArgument.GeneralFormat:
                            if (replacement is FlaggedArgument<ExpressionNode> generalFormat)
                            {
                                current = GeneralFormat;
                                GeneralFormat = generalFormat;
                            }
                            break;
                        case StyleRefArgument.UndocumentedS:
                            if (replacement is BoolFlagNode undocumentedS)
                            {
                                current = UndocumentedS;
                                UndocumentedS = undocumentedS;
                            }
                            break;
                    }
                }
            }
            return current;
        }
    }
}

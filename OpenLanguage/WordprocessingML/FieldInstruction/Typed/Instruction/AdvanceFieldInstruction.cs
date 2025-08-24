using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Typed
{
    /// <summary>
    /// Represents a strongly-typed ADVANCE field instruction.
    /// Moves the starting point of text that follows the field to the right or left, up or down, or to a specific horizontal or vertical position. The switches used by this field can cause text to overlap. Text will not display if it is moved to the previous or next page, or beyond the print margins of the current page.
    /// </summary>
    public class AdvanceFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// Switch: \d field-argument
        /// Move text down by the specified number of points.
        /// </summary>
        public PtsMeasurementValue? MoveDown { get; set; }

        /// <summary>
        /// Switch: \l field-argument
        /// Move text left by the specified number of points.
        /// </summary>
        public PtsMeasurementValue? MoveLeft { get; set; }

        /// <summary>
        /// Switch: \r field-argument
        /// Move text right by the specified number of points.
        /// </summary>
        public PtsMeasurementValue? MoveRight { get; set; }

        /// <summary>
        /// Switch: \u field-argument
        /// Move text up by the specified number of points.
        /// </summary>
        public PtsMeasurementValue? MoveUp { get; set; }

        /// <summary>
        /// Switch: \x field-argument
        /// Set horizontal position from left edge of column/frame/text box in points.
        /// </summary>
        public PtsMeasurementValue? HorizontalPosition { get; set; }

        /// <summary>
        /// Switch: \y field-argument
        /// Set vertical position relative to page in points (entire line is moved).
        /// Ignored if outside page margins or inside table/text box/footnote/endnote/annotation/header/footer.
        /// </summary>
        public PtsMeasurementValue? VerticalPosition { get; set; }

        /// <summary>
        /// Initializes a new instance of the AdvanceFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public AdvanceFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Gets the next argument after the specified switch index.
        /// </summary>
        private string GetNextArgumentAfter(int switchIndex)
        {
            if (switchIndex + 1 < Source.Arguments.Count)
            {
                FieldArgument nextArg = Source.Arguments[switchIndex + 1];
                if (nextArg.Type != FieldArgumentType.Switch)
                {
                    return nextArg.Value?.ToString() ?? "";
                }
            }
            return "";
        }

        /// <summary>
        /// Parses a points measurement argument from a string value.
        /// </summary>
        private PtsMeasurementValue? ParsePtsMeasurementArgument(string argumentText)
        {
            if (string.IsNullOrWhiteSpace(argumentText))
            {
                return null;
            }

            if (int.TryParse(argumentText.Trim(), out int value))
            {
                try
                {
                    return new PtsMeasurementValue(value);
                }
                catch (ArgumentOutOfRangeException)
                {
                    return null;
                }
            }

            return null;
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "ADVANCE")
            {
                throw new ArgumentException(
                    $"Expected ADVANCE field, but got {Source.Instruction}"
                );
            }

            // ADVANCE field has no field arguments, only switches
            if (
                Source.Arguments.Any(arg =>
                    arg.Type == FieldArgumentType.Identifier
                    || arg.Type == FieldArgumentType.StringLiteral
                )
            )
            {
                throw new ArgumentException(
                    "ADVANCE field does not accept field arguments, only switches"
                );
            }

            // Parse switches
            for (int i = 0; i < Source.Arguments.Count; i++)
            {
                FieldArgument arg = Source.Arguments[i];
                if (arg.Type == FieldArgumentType.Switch)
                {
                    string switchValue = arg.Value?.ToString() ?? string.Empty;
                    switch (switchValue.ToLowerInvariant())
                    {
                        case "\\d":
                            MoveDown = ParsePtsMeasurementArgument(GetNextArgumentAfter(i));
                            break;
                        case "\\l":
                            MoveLeft = ParsePtsMeasurementArgument(GetNextArgumentAfter(i));
                            break;
                        case "\\r":
                            MoveRight = ParsePtsMeasurementArgument(GetNextArgumentAfter(i));
                            break;
                        case "\\u":
                            MoveUp = ParsePtsMeasurementArgument(GetNextArgumentAfter(i));
                            break;
                        case "\\x":
                            HorizontalPosition = ParsePtsMeasurementArgument(
                                GetNextArgumentAfter(i)
                            );
                            break;
                        case "\\y":
                            VerticalPosition = ParsePtsMeasurementArgument(GetNextArgumentAfter(i));
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToString()
        {
            List<string> result = new List<string> { "ADVANCE" };

            if (MoveDown != null)
            {
                result.Add("\\d");
                result.Add(MoveDown.ToString());
            }

            if (MoveLeft != null)
            {
                result.Add("\\l");
                result.Add(MoveLeft.ToString());
            }

            if (MoveRight != null)
            {
                result.Add("\\r");
                result.Add(MoveRight.ToString());
            }

            if (MoveUp != null)
            {
                result.Add("\\u");
                result.Add(MoveUp.ToString());
            }

            if (HorizontalPosition != null)
            {
                result.Add("\\x");
                result.Add(HorizontalPosition.ToString());
            }

            if (VerticalPosition != null)
            {
                result.Add("\\y");
                result.Add(VerticalPosition.ToString());
            }

            return string.Join(" ", result);
        }
    }
}

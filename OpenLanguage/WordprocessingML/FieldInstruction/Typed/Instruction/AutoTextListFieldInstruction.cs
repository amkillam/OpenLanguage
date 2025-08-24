using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Typed
{
    /// <summary>
    /// Represents a strongly-typed AUTOTEXTLIST field instruction.
    /// Creates a shortcut menu based on AutoText entries in the active template.
    /// </summary>
    public class AutoTextListFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// The display text to show in the document (required field argument).
        /// </summary>
        public string DisplayText { get; set; } = string.Empty;

        /// <summary>
        /// Switch: \s field-argument
        /// Specifies the style name for filtering AutoText entries.
        /// Can be paragraph style or character style.
        /// </summary>
        public string? StyleName { get; set; }

        /// <summary>
        /// Switch: \t field-argument
        /// Text to show in the ScreenTip.
        /// </summary>
        public string? ScreenTipText { get; set; }

        /// <summary>
        /// Initializes a new instance of the AutoTextListFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public AutoTextListFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Gets the next argument after the specified switch index.
        /// </summary>
        private string GetNextArgumentAfter(Int32 switchIndex)
        {
            if (switchIndex + 1 < Source.Arguments.Count)
            {
                FieldArgument nextArg = Source.Arguments[switchIndex + 1];
                if (nextArg.Type != FieldArgumentType.Switch)
                {
                    return nextArg.Value?.ToString() ?? string.Empty;
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "AUTOTEXTLIST")
            {
                throw new ArgumentException(
                    $"Expected AUTOTEXTLIST field, but got {Source.Instruction}"
                );
            }

            // Parse primary field argument (display text - required)
            FieldArgument? firstNonSwitch = Source.Arguments.FirstOrDefault(arg =>
                arg.Type == FieldArgumentType.Identifier
                || arg.Type == FieldArgumentType.StringLiteral
            );
            if (firstNonSwitch == null)
            {
                throw new ArgumentException("AUTOTEXTLIST field requires a display text argument");
            }
            DisplayText = firstNonSwitch.Value?.ToString() ?? string.Empty;

            // Parse switches
            for (Int32 i = 0; i < Source.Arguments.Count; i++)
            {
                FieldArgument arg = Source.Arguments[i];
                if (arg.Type == FieldArgumentType.Switch)
                {
                    string switchValue = arg.Value?.ToString() ?? string.Empty;
                    switch (switchValue.ToLowerInvariant())
                    {
                        case "\\s":
                            StyleName = GetNextArgumentAfter(i);
                            break;
                        case "\\t":
                            ScreenTipText = GetNextArgumentAfter(i);
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
            List<string> result = new List<string> { "AUTOTEXTLIST" };

            if (!string.IsNullOrEmpty(DisplayText))
            {
                result.Add(DisplayText.Contains(" ") ? $"\"{DisplayText}\"" : DisplayText);
            }

            if (!string.IsNullOrWhiteSpace(StyleName))
            {
                result.Add("\\s");
                result.Add(StyleName.Contains(" ") ? $"\"{StyleName}\"" : StyleName);
            }

            if (!string.IsNullOrWhiteSpace(ScreenTipText))
            {
                result.Add("\\t");
                result.Add(ScreenTipText.Contains(" ") ? $"\"{ScreenTipText}\"" : ScreenTipText);
            }

            return string.Join(" ", result);
        }
    }
}

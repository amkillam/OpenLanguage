using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Typed
{
    /// <summary>
    /// Represents a strongly-typed MACROBUTTON field instruction.
    /// Allows the macro or command designated by text in field-argument-1 to be run. text in field-argument-2 designates the text or graphic to appear as the "button" that is selected to run the macro or command.
    /// </summary>
    public class MacroButtonFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// The name of the macro or command to run (field-argument-1).
        /// </summary>
        public string MacroName { get; set; } = string.Empty;

        /// <summary>
        /// The text or graphic to appear as the button (field-argument-2).
        /// This is also the field value that gets displayed.
        /// </summary>
        public string ButtonText { get; set; } = string.Empty;

        /// <summary>
        /// Initializes a new instance of the MacroButtonFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public MacroButtonFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "MACROBUTTON")
            {
                throw new ArgumentException(
                    $"Expected MACROBUTTON field, but got {Source.Instruction}"
                );
            }

            // MACROBUTTON requires exactly 2 field arguments
            List<FieldArgument> nonSwitchArgs = Source
                .Arguments.Where(arg => arg.Type != FieldArgumentType.Switch)
                .ToList();

            // Parse field-argument-1: macro name
            MacroName =
                nonSwitchArgs.Count > 0
                    ? nonSwitchArgs[0].Value?.ToString() ?? string.Empty
                    : string.Empty;

            // Parse field-argument-2: button text
            ButtonText =
                nonSwitchArgs.Count > 1
                    ? nonSwitchArgs[1].Value?.ToString() ?? string.Empty
                    : string.Empty;
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToString()
        {
            List<string> result = new List<string> { Source.Instruction };

            // Add field-argument-1: macro name
            if (!string.IsNullOrEmpty(MacroName))
            {
                result.Add(MacroName.Contains(" ") ? $"\"{MacroName}\"" : MacroName);
            }

            // Add field-argument-2: button text
            if (!string.IsNullOrEmpty(ButtonText))
            {
                result.Add(ButtonText.Contains(" ") ? $"\"{ButtonText}\"" : ButtonText);
            }

            return string.Join(" ", result);
        }
    }
}

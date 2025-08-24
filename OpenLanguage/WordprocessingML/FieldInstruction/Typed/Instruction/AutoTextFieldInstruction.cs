using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Typed
{
    /// <summary>
    /// Represents a strongly-typed AUTOTEXT field instruction.
    /// Inserts the AutoText entry whose name is specified by text in field-argument. Regarding XML generation, the field result is the value of the autotext. ##### Note This can be arbitrarily complex and involve VML
    /// </summary>
    public class AutoTextFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// The name of the AutoText entry to insert.
        /// </summary>
        public string AutoTextEntryName { get; set; } = string.Empty;

        /// <summary>
        /// Initializes a new instance of the AutoTextFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public AutoTextFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "AUTOTEXT")
            {
                throw new ArgumentException(
                    $"Expected AUTOTEXT field, but got {Source.Instruction}"
                );
            }

            // Parse primary field argument (AutoText entry name - required)
            FieldArgument? firstNonSwitch = Source.Arguments.FirstOrDefault(arg =>
                arg.Type == FieldArgumentType.Identifier
                || arg.Type == FieldArgumentType.StringLiteral
            );
            if (firstNonSwitch == null)
            {
                throw new ArgumentException(
                    "AUTOTEXT field requires an AutoText entry name argument"
                );
            }
            AutoTextEntryName = firstNonSwitch.Value?.ToString() ?? string.Empty;
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToString()
        {
            List<string> result = new List<string> { "AUTOTEXT" };

            if (!string.IsNullOrEmpty(AutoTextEntryName))
            {
                result.Add(
                    AutoTextEntryName.Contains(" ") ? $"\"{AutoTextEntryName}\"" : AutoTextEntryName
                );
            }

            return string.Join(" ", result);
        }
    }
}

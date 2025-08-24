using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Typed
{
    /// <summary>
    /// Represents a strongly-typed SET field instruction.
    /// Defines the bookmark name specified by field-argument-1 to represent the information specified by field-argument-2.
    /// </summary>
    public class SetFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// The bookmark name to set
        /// </summary>
        public string? BookmarkName { get; set; }

        /// <summary>
        /// Initializes a new instance of the SetFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public SetFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "SET")
            {
                throw new ArgumentException($"Expected SET field, but got {Source.Instruction}");
            }

            // Parse primary field argument (first non-switch argument)
            FieldArgument? firstNonSwitch = Source.Arguments.FirstOrDefault(arg =>
                arg.Type == FieldArgumentType.Identifier
                || arg.Type == FieldArgumentType.StringLiteral
            );
            if (firstNonSwitch != null)
            {
                BookmarkName = firstNonSwitch.Value?.ToString();
            }
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToString()
        {
            List<string> result = new List<string> { Source.Instruction };

            if (BookmarkName != null)
            {
                string argString = BookmarkName.ToString();
                result.Add(argString.Contains(" ") ? $"\"{BookmarkName}\"" : argString);
            }

            return string.Join(" ", result);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage
{
    /// <summary>
    /// Represents a strongly-typed AUTHOR field instruction.
    /// Retrieves and optionally sets the document author's name.
    /// </summary>
    public class AuthorFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// Optional field argument to set the author's name.
        /// If present, changes the document's Creator property to this value.
        /// </summary>
        public string? NewAuthorName { get; set; }

        /// <summary>
        /// Initializes a new instance of the AuthorFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public AuthorFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "AUTHOR")
            {
                throw new ArgumentException($"Expected AUTHOR field, but got {Source.Instruction}");
            }

            // Parse optional field argument (new author name)
            FieldArgument? firstNonSwitch = Source.Arguments.FirstOrDefault(arg =>
                arg.Type == FieldArgumentType.Identifier
                || arg.Type == FieldArgumentType.StringLiteral
            );
            if (firstNonSwitch != null)
            {
                NewAuthorName = firstNonSwitch.Value?.ToString();
            }

            // AUTHOR field only supports general formatting switches, no field-specific switches
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToString()
        {
            List<string> result = new List<string> { "AUTHOR" };

            if (!string.IsNullOrWhiteSpace(NewAuthorName))
            {
                result.Add(NewAuthorName.Contains(" ") ? $"\"{NewAuthorName}\"" : NewAuthorName);
            }

            return string.Join(" ", result);
        }
    }
}

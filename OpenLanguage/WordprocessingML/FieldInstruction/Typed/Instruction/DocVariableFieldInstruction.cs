using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Typed
{
    /// <summary>
    /// Represents a strongly-typed DOCVARIABLE field instruction.
    /// Inserts the string assigned to the document variable designated by text in field-argument. Each WordprocessingML document has a collection of variables. This field is used to access and display the contents of &lt;docVar&gt; elements in the Document Settings part.
    /// </summary>
    public class DocVariableFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// The name of the document variable
        /// </summary>
        public string? VariableName { get; set; }

        /// <summary>
        /// Initializes a new instance of the DocVariableFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public DocVariableFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "DOCVARIABLE")
            {
                throw new ArgumentException(
                    $"Expected DOCVARIABLE field, but got {Source.Instruction}"
                );
            }

            // Parse primary field argument (first non-switch argument)
            FieldArgument? firstNonSwitch = Source.Arguments.FirstOrDefault(arg =>
                arg.Type == FieldArgumentType.Identifier
                || arg.Type == FieldArgumentType.StringLiteral
            );
            if (firstNonSwitch != null)
            {
                VariableName = firstNonSwitch.Value?.ToString();
            }
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToString()
        {
            List<string> result = new List<string> { Source.Instruction };

            if (!string.IsNullOrWhiteSpace(VariableName))
            {
                result.Add(
                    VariableName.Contains(" ") && !VariableName.StartsWith("\"")
                        ? $"\"{VariableName}\""
                        : VariableName
                );
            }

            return string.Join(" ", result);
        }
    }
}

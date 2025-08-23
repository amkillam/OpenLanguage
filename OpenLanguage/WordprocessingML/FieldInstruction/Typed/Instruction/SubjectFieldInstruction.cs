using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage
{
    /// <summary>
    /// Represents a strongly-typed SUBJECT field instruction.
    /// Retrieves, and optionally sets, the document's subject, as recorded in the `<Subject>` element of the Core File Properties part or, if field-argument is present, the subject specified by text in field-argument. Specifying a field-argument shall change `<Subject>` to text.
    /// </summary>
    public class SubjectFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// Optional field argument that specifies the text to set as the document's subject.
        /// If present, this will change the document's Subject property to this value.
        /// </summary>
        public string SubjectText { get; set; } = string.Empty;

        /// <summary>
        /// Initializes a new instance of the SubjectFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public SubjectFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "SUBJECT")
            {
                throw new ArgumentException(
                    $"Expected SUBJECT field, but got {Source.Instruction}"
                );
            }

            // Parse field arguments - look for text argument that sets the subject
            for (int i = 0; i < Source.Arguments.Count; i++)
            {
                FieldArgument arg = Source.Arguments[i];
                if (arg.Type == FieldArgumentType.Text)
                {
                    SubjectText = arg.Value?.ToString() ?? string.Empty;
                    break; // Only take the first text argument
                }
            }
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToString()
        {
            List<string> result = new List<string> { Source.Instruction };

            if (!string.IsNullOrEmpty(SubjectText))
            {
                result.Add("SUBJECT");
            }

            return string.Join(" ", result);
        }
    }
}

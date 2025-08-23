using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage
{
    /// <summary>
    /// Represents a strongly-typed TITLE field instruction.
    /// Retrieves, and optionally sets, the document's title, as recorded in the `<Title>` element of the Core File Properties part or, if field-argument is present, the name specified by text in field-argument. Specifying a field-argument shall change `<Title>` to text.
    /// </summary>
    public class TitleFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// Initializes a new instance of the TitleFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public TitleFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "TITLE")
            {
                throw new ArgumentException($"Expected TITLE field, but got {Source.Instruction}");
            }
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToString()
        {
            List<string> result = new List<string> { Source.Instruction };

            return string.Join(" ", result);
        }
    }
}

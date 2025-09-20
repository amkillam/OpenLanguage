using System;
using System.Collections.Generic;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Typed
{
    /// <summary>
    /// Represents a strongly-typed SECTIONPAGES field instruction.
    /// Retrieves the number of the current page within the current section.
    /// </summary>
    public class SectionPagesFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// Initializes a new instance of the SectionPagesFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public SectionPagesFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "SECTIONPAGES")
            {
                throw new ArgumentException(
                    $"Expected SECTIONPAGES field, but got {Source.Instruction}"
                );
            }

            // SECTIONPAGES has no field-specific arguments, only general formatting switches
            // which are handled by the base field processing logic
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

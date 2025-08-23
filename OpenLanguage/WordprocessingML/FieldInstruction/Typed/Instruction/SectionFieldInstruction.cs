using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage
{
    /// <summary>
    /// Represents a strongly-typed SECTION field instruction.
    /// Retrieves the number of the current section.
    /// </summary>
    public class SectionFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// Initializes a new instance of the SectionFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public SectionFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "SECTION")
            {
                throw new ArgumentException(
                    $"Expected SECTION field, but got {Source.Instruction}"
                );
            }

            // SECTION has no field-specific arguments, only general formatting switches
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

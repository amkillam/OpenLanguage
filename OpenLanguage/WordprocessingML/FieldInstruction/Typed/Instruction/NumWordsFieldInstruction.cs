using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage
{
    /// <summary>
    /// Represents a strongly-typed NUMWORDS field instruction.
    /// Retrieves the number of words in the current document, as recorded in the `<Words>` element of the Application-Defined File Properties part.
    /// </summary>
    public class NumWordsFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// Initializes a new instance of the NumWordsFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public NumWordsFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "NUMWORDS")
            {
                throw new ArgumentException(
                    $"Expected NUMWORDS field, but got {Source.Instruction}"
                );
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

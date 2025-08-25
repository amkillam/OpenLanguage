using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Typed
{
    /// <summary>
    /// Represents a strongly-typed NUMCHARS field instruction.
    /// Retrieves the number of characters in the current document, as recorded in the &lt;Characters&gt; element of the Application-Defined File Properties part.
    /// </summary>
    public class NumCharsFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// Initializes a new instance of the NumCharsFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public NumCharsFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "NUMCHARS")
            {
                throw new ArgumentException(
                    $"Expected NUMCHARS field, but got {Source.Instruction}"
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

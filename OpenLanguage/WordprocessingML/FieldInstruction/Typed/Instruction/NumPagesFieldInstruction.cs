using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Typed
{
    /// <summary>
    /// Represents a strongly-typed NUMPAGES field instruction.
    /// Retrieves the number of pages in the current document, as recorded in the &lt;Pages&gt; element of the Application-Defined File Properties part.
    /// </summary>
    public class NumPagesFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// Initializes a new instance of the NumPagesFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public NumPagesFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "NUMPAGES")
            {
                throw new ArgumentException(
                    $"Expected NUMPAGES field, but got {Source.Instruction}"
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

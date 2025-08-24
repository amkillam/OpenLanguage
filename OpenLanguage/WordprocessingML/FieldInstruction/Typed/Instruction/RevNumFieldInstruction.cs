using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Typed
{
    /// <summary>
    /// Represents a strongly-typed REVNUM field instruction.
    /// Retrieves the document's revision number (which indicates the number of times the document has been saved), as recorded in the `&lt;Revision&gt;` element of the Core File Properties part.
    /// </summary>
    public class RevNumFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// Initializes a new instance of the RevNumFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public RevNumFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "REVNUM")
            {
                throw new ArgumentException($"Expected REVNUM field, but got {Source.Instruction}");
            }

            // REVNUM has no arguments or switches - it simply retrieves the document's revision number
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

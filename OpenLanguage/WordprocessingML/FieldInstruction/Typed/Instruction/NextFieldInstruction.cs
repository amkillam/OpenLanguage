using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Typed
{
    /// <summary>
    /// Represents a strongly-typed NEXT field instruction.
    /// Merges the next data record into the current resulting merged document, rather than starting a new merged document. ##### Note This field is used when setting up a mailing label and envelope main document during a mail merge.
    /// </summary>
    public class NextFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// Initializes a new instance of the NextFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public NextFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "NEXT")
            {
                throw new ArgumentException($"Expected NEXT field, but got {Source.Instruction}");
            }

            // NEXT has no arguments or switches - it simply merges the next data record into the current document
            // This is primarily used for mailing labels and envelopes during mail merge operations
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

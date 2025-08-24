using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Typed
{
    /// <summary>
    /// Represents a strongly-typed MERGESEQ field instruction.
    /// Counts the number of data records that were successfully merged with the main document. Merged records are numbered starting from 1 each time documents are merged. ##### Note The number might be different from the value inserted by the `MERGEREC` field.
    /// </summary>
    public class MergeSeqFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// Initializes a new instance of the MergeSeqFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public MergeSeqFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "MERGESEQ")
            {
                throw new ArgumentException(
                    $"Expected MERGESEQ field, but got {Source.Instruction}"
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

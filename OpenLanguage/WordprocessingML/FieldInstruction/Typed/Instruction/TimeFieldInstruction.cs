using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Typed
{
    /// <summary>
    /// Represents a strongly-typed TIME field instruction.
    /// Retrieves the current date and time. The Gregorian calendar is always used. By default, the date-and-time-formatting-switch used is implementation-defined.
    /// </summary>
    public class TimeFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// Initializes a new instance of the TimeFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public TimeFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "TIME")
            {
                throw new ArgumentException($"Expected TIME field, but got {Source.Instruction}");
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

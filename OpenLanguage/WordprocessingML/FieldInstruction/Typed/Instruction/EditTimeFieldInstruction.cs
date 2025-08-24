using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Typed
{
    /// <summary>
    /// Represents a strongly-typed EDITTIME field instruction.
    /// Retrieves the total editing time, in minutes, since the document was created, as recorded in the `<TotalTime>` element of the Application-Defined File Properties part. By default, the numeric-formatting-switch or general-formatting-switch used is implementation-defined.
    /// </summary>
    public class EditTimeFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// Initializes a new instance of the EditTimeFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public EditTimeFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "EDITTIME")
            {
                throw new ArgumentException(
                    $"Expected EDITTIME field, but got {Source.Instruction}"
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

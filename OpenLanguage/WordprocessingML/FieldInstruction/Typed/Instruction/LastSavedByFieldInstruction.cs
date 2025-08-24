using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Typed
{
    /// <summary>
    /// Represents a strongly-typed LASTSAVEDBY field instruction.
    /// Retrieves the name of the user who last modified and saved the current document, as recorded in the `<LastModifiedBy>` element of the Core File Properties part.
    /// </summary>
    public class LastSavedByFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// Initializes a new instance of the LastSavedByFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public LastSavedByFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "LASTSAVEDBY")
            {
                throw new ArgumentException(
                    $"Expected LASTSAVEDBY field, but got {Source.Instruction}"
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

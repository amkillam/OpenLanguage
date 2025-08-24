using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Typed
{
    /// <summary>
    /// Represents a strongly-typed USERINITIALS field instruction.
    /// Retrieves the current user's initials or, if field-argument is present, the initials specified by text in field-argument. Specifying a field-argument shall not change the initials of the current user.
    /// </summary>
    public class UserInitialsFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// Initializes a new instance of the UserInitialsFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public UserInitialsFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "USERINITIALS")
            {
                throw new ArgumentException(
                    $"Expected USERINITIALS field, but got {Source.Instruction}"
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

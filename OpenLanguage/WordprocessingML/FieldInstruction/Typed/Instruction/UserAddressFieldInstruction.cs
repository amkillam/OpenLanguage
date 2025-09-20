using System;
using System.Collections.Generic;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Typed
{
    /// <summary>
    /// Represents a strongly-typed USERADDRESS field instruction.
    /// Retrieves the current user's postal address or, if field-argument is present, the address specified by text in field-argument. Specifying a field-argument shall not change the address of the current user.
    /// </summary>
    public class UserAddressFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// Initializes a new instance of the UserAddressFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public UserAddressFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "USERADDRESS")
            {
                throw new ArgumentException(
                    $"Expected USERADDRESS field, but got {Source.Instruction}"
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

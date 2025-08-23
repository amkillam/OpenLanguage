using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage
{
    /// <summary>
    /// Represents a strongly-typed AUTONUMOUT field instruction.
    /// Provides automatic numbering for headings using built-in heading styles.
    /// Legacy field - LISTNUM is recommended instead.
    /// </summary>
    public class AutoNumOutFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// Initializes a new instance of the AutoNumOutFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public AutoNumOutFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "AUTONUMOUT")
            {
                throw new ArgumentException(
                    $"Expected AUTONUMOUT field, but got {Source.Instruction}"
                );
            }

            // AUTONUMOUT field has no arguments or switches
            if (Source.Arguments.Any(arg => arg.Type != FieldArgumentType.Switch))
            {
                throw new ArgumentException("AUTONUMOUT field does not accept field arguments");
            }

            if (Source.Arguments.Any(arg => arg.Type == FieldArgumentType.Switch))
            {
                throw new ArgumentException("AUTONUMOUT field does not accept switches");
            }
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToString()
        {
            List<string> result = new List<string> { "AUTONUMOUT" };

            return string.Join(" ", result);
        }
    }
}

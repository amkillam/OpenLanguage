using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Typed
{
    /// <summary>
    /// Represents a strongly-typed KEYWORDS field instruction.
    /// Retrieves, and optionally sets, the document's keywords, as recorded in the `<Keywords>` element of the Core File Properties part or, if field-argument is present, the subject specified by text in field-argument. Specifying a field-argument shall change `<Keywords>` to text. The `<Keywords>` element contains a string of text whose format and semantics is unspecified by this Office Open XML Standard.
    /// </summary>
    public class KeywordsFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// Initializes a new instance of the KeywordsFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public KeywordsFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "KEYWORDS")
            {
                throw new ArgumentException(
                    $"Expected KEYWORDS field, but got {Source.Instruction}"
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

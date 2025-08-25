using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Typed
{
    /// <summary>
    /// Represents a strongly-typed COMMENTS field instruction.
    /// Retrieves, and optionally sets, the comments relating to the current document, as recorded in the &lt;Description&gt; element of the Core File Properties part or, if field-argument is present, the comments specified by text in field-argument. Specifying a field-argument shall change &lt;Description&gt; to text.
    /// </summary>
    public class CommentsFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// Initializes a new instance of the CommentsFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public CommentsFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "COMMENTS")
            {
                throw new ArgumentException(
                    $"Expected COMMENTS field, but got {Source.Instruction}"
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

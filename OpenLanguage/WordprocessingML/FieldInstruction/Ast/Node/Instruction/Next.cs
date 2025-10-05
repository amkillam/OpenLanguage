using System.Collections.Generic;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    /// <summary>
    /// Represents a strongly-typed NEXT field instruction.
    /// Merges the next data record into the current resulting merged document,
    /// rather than starting a new merged document.
    /// ##### Note This field is used when setting up a mailing label and envelope main document during a mail merge.
    /// </summary>
    public class NextFieldInstruction : FieldInstruction
    {
        /// <summary>
        /// Initializes a new instance of the NextFieldInstruction class.
        /// </summary>
        public NextFieldInstruction(
            StringLiteralNode instruction,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace) { }
    }
}

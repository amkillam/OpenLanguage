using System.Collections.Generic;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    /// <summary>
    /// Represents a strongly-typed AUTONUMOUT field instruction.
    /// Provides automatic numbering for headings using built-in heading styles.
    /// Legacy field - LISTNUM is recommended instead.
    /// </summary>
    public class AutoNumOutFieldInstruction : FieldInstruction
    {
        /// <summary>
        /// Initializes a new instance of the AutoNumOutFieldInstruction class.
        /// </summary>
        public AutoNumOutFieldInstruction(
            StringLiteralNode instruction,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace) { }
    }
}

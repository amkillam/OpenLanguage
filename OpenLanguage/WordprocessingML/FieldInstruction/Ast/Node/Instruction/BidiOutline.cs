using System.Collections.Generic;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    /// <summary>
    /// Represents a strongly-typed BIDIOUTLINE field instruction.
    /// Sets the output as right-to-left outline numbering.
    /// </summary>
    public class BidiOutlineFieldInstruction : FieldInstruction
    {
        public BidiOutlineFieldInstruction(
            StringLiteralNode instruction,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace) { }
    }
}

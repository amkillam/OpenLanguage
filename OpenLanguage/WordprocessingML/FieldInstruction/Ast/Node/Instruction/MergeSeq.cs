using System.Collections.Generic;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    /// <summary>
    /// Represents a strongly-typed MERGESEQ field instruction.
    /// Counts the number of data records that were successfully merged with the main document. Merged records are numbered starting from 1 each time documents are merged. ##### Note The number might be different from the value inserted by the `MERGEREC` field.
    /// </summary>
    public class MergeSeqFieldInstruction : Ast.FieldInstruction
    {
        /// <summary>
        /// Initializes a new instance of the MergeSeqFieldInstruction class.
        /// </summary>
        public MergeSeqFieldInstruction(
            StringLiteralNode instruction,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace) { }
    }
}

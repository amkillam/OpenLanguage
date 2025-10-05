using System.Collections.Generic;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    /// <summary>
    /// Represents a strongly-typed MERGEREC field instruction.
    /// Results in `«MERGEREC»`. Use this in a mail merge to print the number of the corresponding merged data record in each resulting merged document. The number reflects the sequential order of the data records that were selected and possibly sorted for merging with the active main document. It does not indicate the actual order of the records as they occur in the physical data source. ##### Note A personnel database might contain thousands of records. However, to send a form letter to employees who've reached their five-year anniversary with your company, you'd select as your data source only the records of those five-year employees, a much smaller set of records. To print a physical record number, you must include a record number field in the data source and insert the corresponding merge field in the main document.
    /// </summary>
    public class MergeRecFieldInstruction : FieldInstruction
    {
        /// <summary>
        /// Initializes a new instance of the MergeRecFieldInstruction class.
        /// </summary>
        public MergeRecFieldInstruction(
            StringLiteralNode instruction,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace) { }
    }
}

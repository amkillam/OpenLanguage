using System.Collections.Generic;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    /// <summary>
    /// Represents a strongly-typed FORMDROPDOWN field instruction.
    /// Inserts a drop-down list style form field which, when the editing of
    /// form fields is enabled using the <documentProtection> element,
    /// can be used to select an entry in the list.
    ///
    /// An instance of this field shall be accompanied by a use of the <ffData> element
    /// which contains the form field's properties.
    /// </summary>
    public class FormDropDownFieldInstruction : FieldInstruction
    {
        /// <summary>
        /// Initializes a new instance of the FormDropDownFieldInstruction class.
        /// </summary>
        public FormDropDownFieldInstruction(
            StringLiteralNode instruction,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace) { }
    }
}

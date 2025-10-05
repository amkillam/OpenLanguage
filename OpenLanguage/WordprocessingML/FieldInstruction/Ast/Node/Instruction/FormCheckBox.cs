using System.Collections.Generic;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    /// <summary>
    /// Represents a strongly-typed FORMCHECKBOX field instruction.
    /// Inserts a check box style form field which, when the editing of form fields is enabled using the
    /// <documentProtection> element, can be checked and unchecked.
    ///
    /// An instance of this field shall be accompanied by a use of the <ffData> element which contains
    /// the form field's properties.
    /// </summary>
    public class FormCheckBoxFieldInstruction : FieldInstruction
    {
        /// <summary>
        /// Initializes a new instance of the FormCheckBoxFieldInstruction class.
        /// </summary>
        public FormCheckBoxFieldInstruction(
            StringLiteralNode instruction,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace) { }
    }
}

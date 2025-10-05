using System.Collections.Generic;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    /// <summary>
    /// Represents a strongly-typed FORMTEXT field instruction.
    /// Inserts a text box style form field which, when the editing of form fields is
    /// enabled using the <documentProtection> element, can be typed into.
    ///
    /// An instance of this field shall be accompanied by a use of the <ffData> element
    /// which contains the form field's properties.
    /// </summary>
    public class FormTextFieldInstruction : FieldInstruction
    {
        /// <summary>
        /// Initializes a new instance of the FormTextFieldInstruction class.
        /// </summary>
        public FormTextFieldInstruction(
            StringLiteralNode instruction,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace) { }
    }
}

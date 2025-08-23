using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage
{
    /// <summary>
    /// Represents a strongly-typed FORMDROPDOWN field instruction.
    /// Inserts a drop-down list style form field which, when the editing of form fields is enabled using the `<documentProtection>` element (§[2.15.1.28](https://c-rex.net/samples/ooxml/e1/Part4/OOXML_P4_DOCX_documentProtection_topic_ID0EJVTX.html#topic_ID0EJVTX)), can be used to select an entry in the list. An instance of this field shall be accompanied by a use of the `<ffData>` element (§[2.16.17](https://c-rex.net/samples/ooxml/e1/Part4/OOXML_P4_DOCX_ffData_topic_ID0EJFT1.html#topic_ID0EJFT1)) which contains the form field's properties.
    /// </summary>
    public class FormDropDownFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// Initializes a new instance of the FormDropDownFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public FormDropDownFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "FORMDROPDOWN")
            {
                throw new ArgumentException(
                    $"Expected FORMDROPDOWN field, but got {Source.Instruction}"
                );
            }

            // FORMDROPDOWN has no arguments or switches - validate this
            if (Source.Arguments.Count > 0)
            {
                throw new ArgumentException("FORMDROPDOWN field takes no arguments or switches");
            }
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToString()
        {
            // FORMDROPDOWN field has no arguments or switches
            return "FORMDROPDOWN";
        }
    }
}

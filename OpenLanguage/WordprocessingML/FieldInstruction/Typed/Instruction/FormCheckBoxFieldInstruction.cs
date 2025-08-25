using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Typed
{
    /// <summary>
    /// Represents a strongly-typed FORMCHECKBOX field instruction.
    /// Inserts a check box style form field which, when the editing of form fields is enabled using the &lt;documentProtection&gt; element, can be checked and unchecked. An instance of this field shall be accompanied by a use of the &lt;ffData&gt; element which contains the form field's properties.
    /// </summary>
    public class FormCheckBoxFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// Initializes a new instance of the FormCheckBoxFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public FormCheckBoxFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "FORMCHECKBOX")
            {
                throw new ArgumentException(
                    $"Expected FORMCHECKBOX field, but got {Source.Instruction}"
                );
            }

            // FORMCHECKBOX has no arguments or switches - validate this
            if (Source.Arguments.Count > 0)
            {
                throw new ArgumentException("FORMCHECKBOX field takes no arguments or switches");
            }
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToString()
        {
            // FORMCHECKBOX field has no arguments or switches
            return "FORMCHECKBOX";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Typed
{
    /// <summary>
    /// Represents a strongly-typed FORMDROPDOWN field instruction.
    /// Inserts a drop-down list style form field which, when the editing of form fields is enabled using the &lt;documentProtection&gt; element, can be used to select an entry in the list. An instance of this field shall be accompanied by a use of the &lt;ffData&gt; element which contains the form field's properties.
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

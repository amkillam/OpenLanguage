using System.Collections.Generic;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction
{
    /// <summary>
    /// Represents a strongly-typed MACROBUTTON field instruction.
    /// Allows the macro or command designated by text in field-argument-1 to be run.
    /// Text in field-argument-2 designates the text or graphic to appear as the "button"
    /// that is selected to run the macro or command.
    /// </summary>
    public class MacroButtonFieldInstruction : Ast.FieldInstruction
    {
        /// <summary>
        /// The name of the macro or command to run (field-argument-1).
        /// </summary>
        public ExpressionNode? MacroName { get; set; }

        /// <summary>
        /// The text or graphic to appear as the button (field-argument-2).
        /// This is also the field value that gets displayed.
        /// </summary>
        public ExpressionNode? ButtonText { get; set; }

        public MacroButtonFieldInstruction(
            StringLiteralNode instruction,
            ExpressionNode? macroName = null,
            ExpressionNode? buttonText = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            MacroName = macroName;
            ButtonText = buttonText;
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToRawString() =>
            Instruction.ToString()
            + (MacroName?.ToString() ?? string.Empty)
            + (ButtonText?.ToString() ?? string.Empty);

        public override IEnumerable<O> Children<O>()
        {
            if (Instruction is O oInstruction)
            {
                yield return oInstruction;
            }

            if (MacroName is O oMacroName)
            {
                yield return oMacroName;
            }

            if (ButtonText is O oButtonText)
            {
                yield return oButtonText;
            }
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;
            switch (index)
            {
                case 0:
                {
                    if (replacement is StringLiteralNode strRep)
                    {
                        current = Instruction;
                        Instruction = strRep;
                    }
                    break;
                }
                case 1:
                {
                    if (replacement is ExpressionNode exprMacroRep)
                    {
                        current = MacroName;
                        MacroName = exprMacroRep;
                    }
                    break;
                }
                case 2:
                {
                    if (replacement is ExpressionNode exprRep)
                    {
                        current = ButtonText;
                        ButtonText = exprRep;
                    }
                    break;
                }
            }
            return current;
        }
    }
}

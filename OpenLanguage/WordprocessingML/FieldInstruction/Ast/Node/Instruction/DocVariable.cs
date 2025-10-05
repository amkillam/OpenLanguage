using System.Collections.Generic;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    /// <summary>
    /// Represents a strongly-typed DOCVARIABLE field instruction.
    /// Inserts the string assigned to the document variable designated by text in field-argument. Each WordprocessingML document has a collection of variables. This field is used to access and display the contents of <docVar> elements in the Document Settings part.
    /// </summary>
    public class DocVariableFieldInstruction : FieldInstruction
    {
        /// <summary>
        /// The name of the document variable
        /// </summary>
        public ExpressionNode? VariableName { get; set; }

        public DocVariableFieldInstruction(
            StringLiteralNode instruction,
            ExpressionNode? variableName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            VariableName = variableName;
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToRawString()
        {
            return Instruction.ToString() + (VariableName?.ToString() ?? string.Empty);
        }

        public override IEnumerable<O> Children<O>()
        {
            if (Instruction is O oInstruction)
            {
                yield return oInstruction;
            }

            if (VariableName is O oVariableName)
            {
                yield return oVariableName;
            }
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;

            if (index == 0 && replacement is StringLiteralNode instruction)
            {
                current = Instruction;
                Instruction = instruction;
            }
            else if (index == 1 && replacement is ExpressionNode variableName)
            {
                current = VariableName;
                VariableName = variableName;
            }

            return current;
        }
    }
}

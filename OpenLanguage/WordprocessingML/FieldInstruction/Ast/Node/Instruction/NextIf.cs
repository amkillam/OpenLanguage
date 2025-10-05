using System.Collections.Generic;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    /// <summary>
    /// Represents a strongly-typed NEXTIF field instruction.
    /// Evaluates condition. If the condition is true, the next data record is merged into the current merge document. (Merge fields that follow the `NEXTIF` in the main document are replaced by values from the next data record rather than the current data record.) If the condition is false, the next data record is merged into a new merge document. Operator can be any one of the six relational and equality operators. Fields shall NOT be used in a footnote, an endnote, annotation, a header, a footer, or a data source. A `NEXTIF` field shall NOT be nested within any field.
    /// </summary>
    public class NextIfFieldInstruction : FieldInstruction
    {
        /// <summary>
        /// The condition to evaluate.
        /// </summary>
        public ExpressionNode? Condition { get; set; }

        public NextIfFieldInstruction(
            StringLiteralNode instruction,
            ExpressionNode? condition,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            Condition = condition;
        }

        /// <summary>
        ///
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToRawString() =>
            Instruction.ToString() + (Condition?.ToString() ?? string.Empty);

        public override IEnumerable<O> Children<O>()
        {
            if (Instruction is O o)
            {
                yield return o;
            }
            if (Condition is O o1)
            {
                yield return o1;
            }
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;
            if (index == 0 && replacement is StringLiteralNode sln)
            {
                current = Instruction;
                Instruction = sln;
            }
            else if (index == 1 && replacement is ExpressionNode bon)
            {
                current = Condition;
                Condition = bon;
            }
            return current;
        }
    }
}

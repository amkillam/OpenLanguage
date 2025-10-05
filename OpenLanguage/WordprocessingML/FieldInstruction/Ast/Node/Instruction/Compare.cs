using System.Collections.Generic;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    /// <summary>
    /// Represents a strongly-typed COMPARE field instruction.
    /// Compares two expressions using a relational or equality operator.
    /// Returns 1 if comparison is true, 0 if false.
    /// </summary>
    public class CompareFieldInstruction : FieldInstruction
    {
        /// <summary>
        /// The comparison expression.
        /// </summary>
        public ExpressionNode? CompareExpression { get; set; }

        public CompareFieldInstruction(
            StringLiteralNode instruction,
            ExpressionNode? compareExpr = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            CompareExpression = compareExpr;
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToRawString() =>
            Instruction.ToString() + (CompareExpression?.ToString() ?? string.Empty);

        public override IEnumerable<O> Children<O>()
        {
            if (Instruction is O o)
            {
                yield return o;
            }
            if (CompareExpression is O o1)
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
                current = CompareExpression;
                CompareExpression = bon;
            }
            return current;
        }
    }
}

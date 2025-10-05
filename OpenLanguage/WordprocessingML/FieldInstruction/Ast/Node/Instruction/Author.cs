using System.Collections.Generic;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    /// <summary>
    /// Represents a strongly-typed AUTHOR field instruction.
    /// Retrieves and optionally sets the document author's name.
    /// </summary>
    public class AuthorFieldInstruction : Ast.FieldInstruction
    {
        /// <summary>
        /// Optional field argument to set the author's name.
        /// If present, changes the document's Creator property to this value.
        /// </summary>
        public ExpressionNode? NewAuthorName { get; set; }

        /// <summary>
        /// Switch: \*
        /// General formatting switch for the field value.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? GeneralFormat { get; set; }

        public AuthorFieldInstruction(
            StringLiteralNode instruction,
            ExpressionNode? newAuthorName = null,
            FlaggedArgument<ExpressionNode>? generalFormat = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            NewAuthorName = newAuthorName;
            GeneralFormat = generalFormat;
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToRawString() =>
            Instruction.ToString()
            + (NewAuthorName?.ToString() ?? string.Empty)
            + (GeneralFormat?.ToString() ?? string.Empty);

        public override IEnumerable<O> Children<O>()
        {
            if (Instruction is O o)
            {
                yield return o;
            }
            if (NewAuthorName is O matchAuthorName)
            {
                yield return matchAuthorName;
            }

            if (GeneralFormat is O oGen)
            {
                yield return oGen;
            }

            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;

            if (index == 0 && replacement is StringLiteralNode strLiteral)
            {
                current = Instruction;
                Instruction = strLiteral;
            }
            else if (index == 1 && replacement is ExpressionNode expr)
            {
                current = NewAuthorName;
                NewAuthorName = expr;
            }
            else if (index == 2 && replacement is FlaggedArgument<ExpressionNode> gen)
            {
                current = GeneralFormat;
                GeneralFormat = gen;
            }
            return current;
        }
    }
}

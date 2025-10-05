using System.Collections.Generic;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    /// <summary>
    /// Represents a strongly-typed PAGE field instruction.
    /// Retrieves the number of the current page.
    /// </summary>
    public class PageFieldInstruction : FieldInstruction
    {
        public FlaggedArgument<ExpressionNode>? GeneralFormat { get; set; }

        public PageFieldInstruction(
            StringLiteralNode instruction,
            FlaggedArgument<ExpressionNode>? generalFormat = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            GeneralFormat = generalFormat;
        }

        public override string ToRawString() =>
            Instruction.ToString() + (GeneralFormat?.ToString() ?? string.Empty);

        public override IEnumerable<O> Children<O>()
        {
            if (Instruction is O oInstruction)
            {
                yield return oInstruction;
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
            if (index == 0 && replacement is StringLiteralNode instr)
            {
                current = Instruction;
                Instruction = instr;
            }
            else if (index == 1 && replacement is FlaggedArgument<ExpressionNode> gen)
            {
                current = GeneralFormat;
                GeneralFormat = gen;
            }
            return current;
        }
    }
}

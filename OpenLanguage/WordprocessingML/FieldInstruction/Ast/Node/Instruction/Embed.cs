using System.Collections.Generic;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    public class EmbedFieldInstruction : FieldInstruction
    {
        public ExpressionNode ProgId { get; set; }
        public FlaggedArgument<StringLiteralNode>? MergeFormattingSwitch { get; set; }

        public EmbedFieldInstruction(
            StringLiteralNode instruction,
            ExpressionNode progId,
            FlaggedArgument<StringLiteralNode>? mergeFormattingSwitch = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            ProgId = progId;
            MergeFormattingSwitch = mergeFormattingSwitch;
        }

        public override string ToRawString() =>
            Instruction.ToString()
            + ProgId.ToString()
            + (MergeFormattingSwitch?.ToString() ?? string.Empty);

        public override IEnumerable<O> Children<O>()
        {
            if (Instruction is O o1)
            {
                yield return o1;
            }
            if (ProgId is O o2)
            {
                yield return o2;
            }
            if (MergeFormattingSwitch is O o3)
            {
                yield return o3;
            }
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;
            if (index == 0 && replacement is StringLiteralNode bon)
            {
                current = Instruction;
                Instruction = bon;
            }
            else if (index == 1 && replacement is ExpressionNode pin)
            {
                current = ProgId;
                ProgId = pin;
            }
            else if (index == 2 && replacement is FlaggedArgument<StringLiteralNode> fasln)
            {
                current = MergeFormattingSwitch;
                MergeFormattingSwitch = fasln;
            }
            return current;
        }
    }
}

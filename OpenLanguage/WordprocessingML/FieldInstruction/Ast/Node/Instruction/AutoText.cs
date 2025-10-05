using System.Collections.Generic;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    public class AutoTextFieldInstruction : FieldInstruction
    {
        public ExpressionNode? EntryName { get; set; }

        public AutoTextFieldInstruction(
            StringLiteralNode instruction,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace) { }

        public AutoTextFieldInstruction(
            StringLiteralNode instruction,
            ExpressionNode? entryName,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            EntryName = entryName;
        }

        public override string ToRawString() =>
            Instruction.ToString() + (EntryName?.ToString() ?? string.Empty);

        public override IEnumerable<O> Children<O>()
        {
            if (Instruction is O oInstr)
            {
                yield return oInstr;
            }
            if (EntryName is O oEntry)
            {
                yield return oEntry;
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
            else if (index == 1 && replacement is ExpressionNode entry)
            {
                current = EntryName;
                EntryName = entry;
            }

            return current;
        }
    }
}

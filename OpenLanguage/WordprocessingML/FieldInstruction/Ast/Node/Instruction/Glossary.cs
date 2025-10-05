using System.Collections.Generic;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    /// <summary>
    /// Inserts the glossary entry whose name is specified by text in field-argument.
    /// </summary>
    public class GlossaryInstruction : FieldInstruction
    {
        /// <summary>
        /// The name of the glossary entry.
        /// </summary>
        public ExpressionNode? EntryName { get; set; }

        public GlossaryInstruction(
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
            if (Instruction is O o1)
            {
                yield return o1;
            }
            if (EntryName is O o2)
            {
                yield return o2;
            }
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;
            switch (index)
            {
                case 0:
                    if (replacement is StringLiteralNode instr)
                    {
                        current = Instruction;
                        Instruction = instr;
                    }
                    break;
                case 1:
                    if (replacement is ExpressionNode entryName)
                    {
                        current = EntryName;
                        EntryName = entryName;
                    }
                    break;
            }
            return current;
        }
    }
}

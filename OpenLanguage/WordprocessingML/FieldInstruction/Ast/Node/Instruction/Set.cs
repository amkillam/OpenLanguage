using System.Collections.Generic;
using OpenLanguage.WordprocessingML.Ast;
using OpenLanguage.WordprocessingML.FieldInstruction.Generated;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    /// <summary>
    /// Represents a strongly-typed SET field instruction.
    /// Defines the bookmark name specified by field-argument-1 to represent the information specified by field-argument-2.
    /// </summary>
    public class SetFieldInstruction : FieldInstruction
    {
        public ExpressionNode? BookmarkName { get; set; }
        public ExpressionNode? Value { get; set; }

        public SetFieldInstruction(
            StringLiteralNode instruction,
            ExpressionNode? bookmarkName,
            ExpressionNode? value,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            BookmarkName = bookmarkName;
            Value = value;
        }

        public override string ToRawString()
        {
            return Instruction.ToString()
                + (BookmarkName?.ToString() ?? string.Empty)
                + (Value?.ToString() ?? string.Empty);
        }

        public override IEnumerable<O> Children<O>()
        {
            if (Instruction is O oInstr)
            {
                yield return oInstr;
            }
            if (BookmarkName is O o1)
            {
                yield return o1;
            }
            if (Value is O o2)
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
                {
                    if (replacement is StringLiteralNode instr)
                    {
                        current = Instruction;
                        Instruction = instr;
                    }
                    break;
                }
                case 1:
                {
                    if (replacement is ExpressionNode bn)
                    {
                        current = BookmarkName;
                        BookmarkName = bn;
                    }
                    break;
                }
                case 2:
                {
                    if (replacement is ExpressionNode val)
                    {
                        current = Value;
                        Value = val;
                    }
                    break;
                }
            }

            return current;
        }
    }
}

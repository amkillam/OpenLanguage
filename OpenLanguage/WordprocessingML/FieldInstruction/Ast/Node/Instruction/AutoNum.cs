using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    public enum AutoNumArgument
    {
        Separator,
    }

    public class AutoNumFieldInstruction : Ast.FieldInstruction
    {
        public FlaggedArgument<ExpressionNode>? Separator { get; set; }
        public List<AutoNumArgument> Order { get; set; } = new List<AutoNumArgument>();

        public AutoNumFieldInstruction(
            StringLiteralNode instruction,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace) { }

        public AutoNumFieldInstruction(
            StringLiteralNode instruction,
            FlaggedArgument<ExpressionNode>? separator,
            List<AutoNumArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            Separator = separator;
            Order = order;
        }

        public override string ToRawString() =>
            Instruction.ToString()
            + string.Concat(
                Order.Select(a =>
                    a switch
                    {
                        AutoNumArgument.Separator => Separator?.ToString() ?? string.Empty,
                        _ => string.Empty,
                    }
                )
            );

        public override IEnumerable<O> Children<O>()
        {
            if (Instruction is O o)
            {
                yield return o;
            }

            foreach (AutoNumArgument arg in Order)
            {
                Node? child = arg switch
                {
                    AutoNumArgument.Separator => Separator,
                    _ => null,
                };
                if (child is O oChild)
                {
                    yield return oChild;
                }
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
                return current;
            }

            index--;
            if (index >= 0 && index < Order.Count)
            {
                AutoNumArgument arg = Order[index];
                switch (arg)
                {
                    case AutoNumArgument.Separator:
                        if (replacement is FlaggedArgument<ExpressionNode> sep)
                        {
                            current = Separator;
                            Separator = sep;
                        }
                        break;
                }
            }

            return current;
        }
    }
}

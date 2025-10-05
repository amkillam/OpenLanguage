using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    public enum AutoNumLglArgument
    {
        RemoveTrailingSeparator,
        Separator,
    }

    public class AutoNumLglFieldInstruction : FieldInstruction
    {
        public BoolFlagNode? RemoveTrailingSeparator { get; set; }
        public FlaggedArgument<ExpressionNode>? Separator { get; set; }
        public List<AutoNumLglArgument> Order { get; set; } = new List<AutoNumLglArgument>();

        public AutoNumLglFieldInstruction(
            StringLiteralNode instruction,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace) { }

        public AutoNumLglFieldInstruction(
            StringLiteralNode instruction,
            BoolFlagNode? removeTrailing,
            FlaggedArgument<ExpressionNode>? separator,
            List<AutoNumLglArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            RemoveTrailingSeparator = removeTrailing;
            Separator = separator;
            Order = order;
        }

        public override string ToRawString() =>
            Instruction.ToString()
            + string.Concat(
                Order.Select(a =>
                    a switch
                    {
                        AutoNumLglArgument.RemoveTrailingSeparator =>
                            RemoveTrailingSeparator?.ToString() ?? string.Empty,
                        AutoNumLglArgument.Separator => Separator?.ToString() ?? string.Empty,
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
            foreach (AutoNumLglArgument arg in Order)
            {
                Node? child = arg switch
                {
                    AutoNumLglArgument.RemoveTrailingSeparator => RemoveTrailingSeparator,
                    AutoNumLglArgument.Separator => Separator,
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
                AutoNumLglArgument arg = Order[index];
                switch (arg)
                {
                    case AutoNumLglArgument.RemoveTrailingSeparator:
                        if (replacement is BoolFlagNode rm)
                        {
                            current = RemoveTrailingSeparator;
                            RemoveTrailingSeparator = rm;
                        }
                        break;
                    case AutoNumLglArgument.Separator:
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

using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    public enum SectionArgument
    {
        GeneralFormat,
    }

    /// <summary>
    /// Represents a strongly-typed SECTION field instruction.
    /// Retrieves the number of the current section.
    /// </summary>
    public class SectionFieldInstruction : FieldInstruction
    {
        public FlaggedArgument<ExpressionNode>? GeneralFormat { get; set; }
        public List<SectionArgument> Order { get; set; }

        /// <summary>
        /// Initializes a new instance of the SectionFieldInstruction class.
        /// </summary>
        public SectionFieldInstruction(
            StringLiteralNode instruction,
            FlaggedArgument<ExpressionNode>? generalFormat,
            List<SectionArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            GeneralFormat = generalFormat;
            Order = order;
        }

        public override string ToRawString() =>
            Instruction.ToString()
            + string.Concat(
                Order.Select(a =>
                    a switch
                    {
                        SectionArgument.GeneralFormat => GeneralFormat?.ToString() ?? string.Empty,
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

            foreach (SectionArgument arg in Order)
            {
                switch (arg)
                {
                    case SectionArgument.GeneralFormat:
                        if (GeneralFormat is O o1)
                        {
                            yield return o1;
                        }
                        break;
                    default:
                        break;
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
            }
            else
            {
                index--;
                if (index > -1 && index < Order.Count)
                {
                    SectionArgument arg = Order[index];
                    switch (arg)
                    {
                        case SectionArgument.GeneralFormat:
                            if (replacement is FlaggedArgument<ExpressionNode> genFormat)
                            {
                                current = GeneralFormat;
                                GeneralFormat = genFormat;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            return current;
        }
    }
}

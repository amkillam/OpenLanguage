using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    public enum SectionPagesArgument
    {
        GeneralFormat,
        NumericFormat,
    }

    /// <summary>
    /// Represents a strongly-typed SECTIONPAGES field instruction.
    /// Retrieves the number of the current page within the current section.
    /// </summary>
    public class SectionPagesFieldInstruction : FieldInstruction
    {
        public FlaggedArgument<ExpressionNode>? GeneralFormat { get; set; }
        public FlaggedArgument<ExpressionNode>? NumericFormat { get; set; }
        public List<SectionPagesArgument> Order { get; set; }

        /// <summary>
        /// Initializes a new instance of the SectionPagesFieldInstruction class.
        /// </summary>
        public SectionPagesFieldInstruction(
            StringLiteralNode instruction,
            FlaggedArgument<ExpressionNode>? generalFormat,
            FlaggedArgument<ExpressionNode>? numericFormat,
            List<SectionPagesArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            GeneralFormat = generalFormat;
            NumericFormat = numericFormat;
            Order = order;
        }

        public override string ToRawString() =>
            Instruction.ToString()
            + string.Concat(
                Order.Select(a =>
                    a switch
                    {
                        SectionPagesArgument.GeneralFormat => GeneralFormat?.ToString()
                            ?? string.Empty,
                        SectionPagesArgument.NumericFormat => NumericFormat?.ToString()
                            ?? string.Empty,
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

            foreach (SectionPagesArgument arg in Order)
            {
                switch (arg)
                {
                    case SectionPagesArgument.GeneralFormat:
                        if (GeneralFormat is O o1)
                        {
                            yield return o1;
                        }
                        break;
                    case SectionPagesArgument.NumericFormat:
                        if (NumericFormat is O o2)
                        {
                            yield return o2;
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
            if (index == 0 && replacement is StringLiteralNode str)
            {
                current = Instruction;
                Instruction = str;
            }
            else
            {
                index--;
                if (index > -1 && index < Order.Count)
                {
                    SectionPagesArgument arg = Order[index];
                    switch (arg)
                    {
                        case SectionPagesArgument.GeneralFormat:
                            if (replacement is FlaggedArgument<ExpressionNode> genFormat)
                            {
                                current = GeneralFormat;
                                GeneralFormat = genFormat;
                            }
                            break;
                        case SectionPagesArgument.NumericFormat:
                            if (replacement is FlaggedArgument<ExpressionNode> numFormat)
                            {
                                current = NumericFormat;
                                NumericFormat = numFormat;
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

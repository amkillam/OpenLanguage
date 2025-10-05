using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    public enum EditTimeArgument
    {
        GeneralFormat,
        NumericFormat,
    }

    /// <summary>
    /// Represents a strongly-typed EDITTIME field instruction.
    /// Retrieves the total editing time, in minutes, since the document was created,
    /// as recorded in the `<TotalTime>` element of the Application-Defined File Properties part.
    /// By default, the numeric-formatting-switch or general-formatting-switch used is implementation-defined.
    /// </summary>
    public class EditTimeFieldInstruction : FieldInstruction
    {
        /// <summary>
        /// General formatting switch.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? GeneralFormat { get; set; }

        /// <summary>
        /// Numeric formatting switch.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? NumericFormat { get; set; }

        public List<EditTimeArgument> Order { get; set; } = new List<EditTimeArgument>();

        public EditTimeFieldInstruction(
            StringLiteralNode instruction,
            FlaggedArgument<ExpressionNode>? generalFormat,
            FlaggedArgument<ExpressionNode>? numericFormat,
            List<EditTimeArgument> order,
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
                Order.Select(arg =>
                    arg switch
                    {
                        EditTimeArgument.GeneralFormat => GeneralFormat?.ToString() ?? string.Empty,
                        EditTimeArgument.NumericFormat => NumericFormat?.ToString() ?? string.Empty,
                        _ => string.Empty,
                    }
                )
            );

        public override IEnumerable<O> Children<O>()
        {
            if (Instruction is O oInstruction)
            {
                yield return oInstruction;
            }

            foreach (EditTimeArgument arg in Order)
            {
                Node? child = arg switch
                {
                    EditTimeArgument.GeneralFormat => GeneralFormat,
                    EditTimeArgument.NumericFormat => NumericFormat,
                    _ => null,
                };
                if (child is O oChild)
                {
                    yield return oChild;
                }
            }
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
                EditTimeArgument arg = Order[index];
                switch (arg)
                {
                    case EditTimeArgument.GeneralFormat:
                        if (replacement is FlaggedArgument<ExpressionNode> gen)
                        {
                            current = GeneralFormat;
                            GeneralFormat = gen;
                        }
                        break;
                    case EditTimeArgument.NumericFormat:
                        if (replacement is FlaggedArgument<ExpressionNode> num)
                        {
                            current = NumericFormat;
                            NumericFormat = num;
                        }
                        break;
                }
            }

            return current;
        }
    }
}

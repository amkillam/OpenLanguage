using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;
using OpenLanguage.WordprocessingML.FieldInstruction.Generated;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    public enum NumPagesArgument
    {
        GeneralFormat,
        NumericFormat,
    }

    /// <summary>
    /// Represents a strongly-typed NUMPAGES field instruction.
    /// Retrieves the number of pages in the current document, as recorded in the
    /// <Pages> element of the Application-Defined File Properties part.
    /// </summary>
    public class NumPagesFieldInstruction : FieldInstruction
    {
        public FlaggedArgument<ExpressionNode>? GeneralFormat { get; set; }
        public FlaggedArgument<ExpressionNode>? NumericFormat { get; set; }
        public List<NumPagesArgument> Order { get; set; } = new List<NumPagesArgument>();

        /// <summary>
        /// Initializes a new instance of the NumPagesFieldInstruction class.
        /// </summary>
        public NumPagesFieldInstruction(
            StringLiteralNode instruction,
            FlaggedArgument<ExpressionNode>? generalFormat,
            FlaggedArgument<ExpressionNode>? numericFormat,
            List<NumPagesArgument> order,
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
                        NumPagesArgument.GeneralFormat => GeneralFormat?.ToString() ?? string.Empty,
                        NumPagesArgument.NumericFormat => NumericFormat?.ToString() ?? string.Empty,
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
            foreach (NumPagesArgument arg in Order)
            {
                Node? child = arg switch
                {
                    NumPagesArgument.GeneralFormat => GeneralFormat,
                    NumPagesArgument.NumericFormat => NumericFormat,
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
                NumPagesArgument arg = Order[index];
                switch (arg)
                {
                    case NumPagesArgument.GeneralFormat:
                        if (replacement is FlaggedArgument<ExpressionNode> gen)
                        {
                            current = GeneralFormat;
                            GeneralFormat = gen;
                        }
                        break;
                    case NumPagesArgument.NumericFormat:
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

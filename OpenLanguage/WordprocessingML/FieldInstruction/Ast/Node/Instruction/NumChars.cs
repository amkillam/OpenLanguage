using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    public enum NumCharsArgument
    {
        GeneralFormat,
        NumericFormat,
    }

    /// <summary>
    /// Represents a strongly-typed NUMCHARS field instruction.
    /// Retrieves the number of characters in the current document,
    /// as recorded in the <Characters> element of the Application-Defined File Properties part.
    /// </summary>
    public class NumCharsFieldInstruction : FieldInstruction
    {
        public FlaggedArgument<ExpressionNode>? GeneralFormat { get; set; }
        public FlaggedArgument<ExpressionNode>? NumericFormat { get; set; }
        public List<NumCharsArgument> Order { get; set; } = new List<NumCharsArgument>();

        /// <summary>
        /// Initializes a new instance of the NumCharsFieldInstruction class.
        /// </summary>
        public NumCharsFieldInstruction(
            StringLiteralNode instruction,
            FlaggedArgument<ExpressionNode>? generalFormat,
            FlaggedArgument<ExpressionNode>? numericFormat,
            List<NumCharsArgument> order,
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
                        NumCharsArgument.GeneralFormat => GeneralFormat?.ToString() ?? string.Empty,
                        NumCharsArgument.NumericFormat => NumericFormat?.ToString() ?? string.Empty,
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

            foreach (NumCharsArgument arg in Order)
            {
                Node? child = arg switch
                {
                    NumCharsArgument.GeneralFormat => GeneralFormat,
                    NumCharsArgument.NumericFormat => NumericFormat,
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
                NumCharsArgument arg = Order[index];
                switch (arg)
                {
                    case NumCharsArgument.GeneralFormat:
                        if (replacement is FlaggedArgument<ExpressionNode> gen)
                        {
                            current = GeneralFormat;
                            GeneralFormat = gen;
                        }
                        break;
                    case NumCharsArgument.NumericFormat:
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

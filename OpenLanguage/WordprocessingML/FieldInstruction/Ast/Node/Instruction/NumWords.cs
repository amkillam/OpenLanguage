using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    public enum NumWordsArgument
    {
        GeneralFormat,
        NumericFormat,
    }

    /// <summary>
    /// Represents a strongly-typed NUMWORDS field instruction.
    /// Retrieves the number of words in the current document, as recorded in
    /// the <Words> element of the Application-Defined File Properties part.
    /// </summary>
    public class NumWordsFieldInstruction : FieldInstruction
    {
        public FlaggedArgument<ExpressionNode>? GeneralFormat { get; set; }
        public FlaggedArgument<ExpressionNode>? NumericFormat { get; set; }
        public List<NumWordsArgument> Order { get; set; } = new List<NumWordsArgument>();

        /// <summary>
        /// Initializes a new instance of the NumWordsFieldInstruction class.
        /// </summary>
        public NumWordsFieldInstruction(
            StringLiteralNode instruction,
            FlaggedArgument<ExpressionNode>? generalFormat,
            FlaggedArgument<ExpressionNode>? numericFormat,
            List<NumWordsArgument> order,
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
                        NumWordsArgument.GeneralFormat => GeneralFormat?.ToString() ?? string.Empty,
                        NumWordsArgument.NumericFormat => NumericFormat?.ToString() ?? string.Empty,
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

            foreach (NumWordsArgument arg in Order)
            {
                Node? child = arg switch
                {
                    NumWordsArgument.GeneralFormat => GeneralFormat,
                    NumWordsArgument.NumericFormat => NumericFormat,
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
                NumWordsArgument arg = Order[index];
                switch (arg)
                {
                    case NumWordsArgument.GeneralFormat:
                        if (replacement is FlaggedArgument<ExpressionNode> gen)
                        {
                            current = GeneralFormat;
                            GeneralFormat = gen;
                        }
                        break;
                    case NumWordsArgument.NumericFormat:
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

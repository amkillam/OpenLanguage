using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    public enum RevNumArgument
    {
        GeneralFormat,
        NumericFormat,
    }

    /// <summary>
    /// Represents a strongly-typed REVNUM field instruction.
    /// Retrieves the document's revision number (which indicates the number of times the document has been saved), as recorded in the `<Revision>` element of the Core File Properties part.
    /// </summary>
    public class RevNumFieldInstruction : Ast.FieldInstruction
    {
        public FlaggedArgument<ExpressionNode>? GeneralFormat { get; set; }
        public FlaggedArgument<ExpressionNode>? NumericFormat { get; set; }
        public List<RevNumArgument> Order { get; set; } = new List<RevNumArgument>();

        /// <summary>
        /// Initializes a new instance of the RevNumFieldInstruction class.
        /// </summary>
        public RevNumFieldInstruction(
            StringLiteralNode instruction,
            FlaggedArgument<ExpressionNode>? generalFormat,
            FlaggedArgument<ExpressionNode>? numericFormat,
            List<RevNumArgument> order,
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
                        RevNumArgument.GeneralFormat => GeneralFormat?.ToString() ?? string.Empty,
                        RevNumArgument.NumericFormat => NumericFormat?.ToString() ?? string.Empty,
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
            foreach (RevNumArgument arg in Order)
            {
                Node? child = arg switch
                {
                    RevNumArgument.GeneralFormat => GeneralFormat,
                    RevNumArgument.NumericFormat => NumericFormat,
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
                RevNumArgument arg = Order[index];
                switch (arg)
                {
                    case RevNumArgument.GeneralFormat:
                        if (replacement is FlaggedArgument<ExpressionNode> gf)
                        {
                            current = GeneralFormat;
                            GeneralFormat = gf;
                        }
                        break;
                    case RevNumArgument.NumericFormat:
                        if (replacement is FlaggedArgument<ExpressionNode> nf)
                        {
                            current = NumericFormat;
                            NumericFormat = nf;
                        }
                        break;
                }
            }
            return current;
        }
    }
}

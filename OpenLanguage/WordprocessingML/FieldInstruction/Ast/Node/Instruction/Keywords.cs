using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    public enum KeywordsArgument
    {
        FieldArgument,
        GeneralFormat,
        NumericFormat,
        DateTimeFormat,
    }

    /// <summary>
    /// Represents a strongly-typed KEYWORDS field instruction.
    /// Retrieves, and optionally sets, the document's keywords.
    /// </summary>
    public class KeywordsFieldInstruction : FieldInstruction
    {
        public ExpressionNode? FieldArgument { get; set; }
        public FlaggedArgument<ExpressionNode>? GeneralFormat { get; set; }
        public FlaggedArgument<ExpressionNode>? NumericFormat { get; set; }
        public FlaggedArgument<ExpressionNode>? DateTimeFormat { get; set; }
        public List<KeywordsArgument> Order { get; set; } = new List<KeywordsArgument>();

        public KeywordsFieldInstruction(
            StringLiteralNode instruction,
            ExpressionNode? fieldArgument,
            FlaggedArgument<ExpressionNode>? generalFormat,
            FlaggedArgument<ExpressionNode>? numericFormat,
            FlaggedArgument<ExpressionNode>? dateTimeFormat,
            List<KeywordsArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            FieldArgument = fieldArgument;
            GeneralFormat = generalFormat;
            NumericFormat = numericFormat;
            DateTimeFormat = dateTimeFormat;
            Order = order;
        }

        public override string ToRawString() =>
            Instruction.ToString()
            + string.Concat(
                Order.Select(arg =>
                    arg switch
                    {
                        KeywordsArgument.FieldArgument => FieldArgument?.ToString() ?? string.Empty,
                        KeywordsArgument.GeneralFormat => GeneralFormat?.ToString() ?? string.Empty,
                        KeywordsArgument.NumericFormat => NumericFormat?.ToString() ?? string.Empty,
                        KeywordsArgument.DateTimeFormat => DateTimeFormat?.ToString()
                            ?? string.Empty,
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
            foreach (KeywordsArgument arg in Order)
            {
                Node? child = arg switch
                {
                    KeywordsArgument.FieldArgument => FieldArgument,
                    KeywordsArgument.GeneralFormat => GeneralFormat,
                    KeywordsArgument.NumericFormat => NumericFormat,
                    KeywordsArgument.DateTimeFormat => DateTimeFormat,
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
                KeywordsArgument arg = Order[index];
                switch (arg)
                {
                    case KeywordsArgument.FieldArgument when replacement is ExpressionNode fa:
                        current = FieldArgument;
                        FieldArgument = fa;
                        break;
                    case KeywordsArgument.GeneralFormat
                        when replacement is FlaggedArgument<ExpressionNode> gf:
                        current = GeneralFormat;
                        GeneralFormat = gf;
                        break;
                    case KeywordsArgument.NumericFormat
                        when replacement is FlaggedArgument<ExpressionNode> nf:
                        current = NumericFormat;
                        NumericFormat = nf;
                        break;
                    case KeywordsArgument.DateTimeFormat
                        when replacement is FlaggedArgument<ExpressionNode> dtf:
                        current = DateTimeFormat;
                        DateTimeFormat = dtf;
                        break;
                }
            }
            return current;
        }
    }
}

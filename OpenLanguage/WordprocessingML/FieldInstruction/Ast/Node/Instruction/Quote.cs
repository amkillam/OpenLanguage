using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction
{
    public enum QuoteArgument
    {
        QuoteText,
        GeneralFormat,
        NumericFormat,
        DateTimeFormat,
    }

    /// <summary>
    /// Represents a strongly-typed QUOTE field instruction.
    /// Retrieves the text specified by text in field-argument. This text can include any other fields except `AUTONUM`, `AUTONUMLGL`, `AUTONUMOUT`, and `SYMBOL`.
    /// </summary>
    public class QuoteFieldInstruction : Ast.FieldInstruction
    {
        /// <summary>
        /// The raw text content that may contain sub-field instructions.
        /// </summary>
        public ExpressionNode? QuoteText { get; set; }
        public FlaggedArgument<ExpressionNode>? GeneralFormat { get; set; }
        public FlaggedArgument<ExpressionNode>? NumericFormat { get; set; }
        public FlaggedArgument<ExpressionNode>? DateTimeFormat { get; set; }
        public List<QuoteArgument> Order { get; set; } = new List<QuoteArgument>();

        public QuoteFieldInstruction(
            StringLiteralNode instruction,
            ExpressionNode? quoteText,
            FlaggedArgument<ExpressionNode>? generalFormat,
            FlaggedArgument<ExpressionNode>? numericFormat,
            FlaggedArgument<ExpressionNode>? dateTimeFormat,
            List<QuoteArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            QuoteText = quoteText;
            GeneralFormat = generalFormat;
            NumericFormat = numericFormat;
            DateTimeFormat = dateTimeFormat;
            Order = order;
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToRawString() =>
            Instruction.ToString()
            + string.Concat(
                Order.Select(a =>
                    a switch
                    {
                        QuoteArgument.QuoteText => QuoteText?.ToString() ?? string.Empty,
                        QuoteArgument.GeneralFormat => GeneralFormat?.ToString() ?? string.Empty,
                        QuoteArgument.NumericFormat => NumericFormat?.ToString() ?? string.Empty,
                        QuoteArgument.DateTimeFormat => DateTimeFormat?.ToString() ?? string.Empty,
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

            foreach (QuoteArgument arg in Order)
            {
                Node? child = arg switch
                {
                    QuoteArgument.QuoteText => QuoteText,
                    QuoteArgument.GeneralFormat => GeneralFormat,
                    QuoteArgument.NumericFormat => NumericFormat,
                    QuoteArgument.DateTimeFormat => DateTimeFormat,
                    _ => null,
                };
                if (child is O o)
                {
                    yield return o;
                }
            }
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;
            if (index == 0 && replacement is StringLiteralNode bon)
            {
                current = Instruction;
                Instruction = bon;
            }
            else
            {
                index--;
                if (index < Order.Count)
                {
                    QuoteArgument arg = Order[index];
                    switch (arg)
                    {
                        case QuoteArgument.QuoteText:
                            if (replacement is ExpressionNode qt)
                            {
                                current = QuoteText;
                                QuoteText = qt;
                            }
                            break;
                        case QuoteArgument.GeneralFormat:
                            if (replacement is FlaggedArgument<ExpressionNode> gf)
                            {
                                current = GeneralFormat;
                                GeneralFormat = gf;
                            }
                            break;
                        case QuoteArgument.NumericFormat:
                            if (replacement is FlaggedArgument<ExpressionNode> nf)
                            {
                                current = NumericFormat;
                                NumericFormat = nf;
                            }
                            break;
                        case QuoteArgument.DateTimeFormat:
                            if (replacement is FlaggedArgument<ExpressionNode> dtf)
                            {
                                current = DateTimeFormat;
                                DateTimeFormat = dtf;
                            }
                            break;
                    }
                }
            }
            return current;
        }
    }
}

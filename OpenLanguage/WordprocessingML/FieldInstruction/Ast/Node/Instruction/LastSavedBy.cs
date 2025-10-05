using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    public enum LastSavedByArgument
    {
        GeneralFormat,
        NumericFormat,
        DateTimeFormat,
    }

    /// <summary>
    /// Represents a strongly-typed LASTSAVEDBY field instruction.
    /// Retrieves the name of the user who last modified and saved the current document, as recorded in the <LastModifiedBy> element of the Core File Properties part.
    /// </summary>
    public class LastSavedByFieldInstruction : FieldInstruction
    {
        public FlaggedArgument<ExpressionNode>? GeneralFormat { get; set; }
        public FlaggedArgument<ExpressionNode>? NumericFormat { get; set; }
        public FlaggedArgument<ExpressionNode>? DateTimeFormat { get; set; }
        public List<LastSavedByArgument> Order { get; set; } = new List<LastSavedByArgument>();

        /// <summary>
        /// Initializes a new instance of the LastSavedByFieldInstruction class.
        /// </summary>
        public LastSavedByFieldInstruction(
            StringLiteralNode instruction,
            FlaggedArgument<ExpressionNode>? generalFormat,
            FlaggedArgument<ExpressionNode>? numericFormat,
            FlaggedArgument<ExpressionNode>? dateTimeFormat,
            List<LastSavedByArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
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
                        LastSavedByArgument.GeneralFormat => GeneralFormat?.ToString()
                            ?? string.Empty,
                        LastSavedByArgument.NumericFormat => NumericFormat?.ToString()
                            ?? string.Empty,
                        LastSavedByArgument.DateTimeFormat => DateTimeFormat?.ToString()
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
            foreach (LastSavedByArgument arg in Order)
            {
                Node? child = arg switch
                {
                    LastSavedByArgument.GeneralFormat => GeneralFormat,
                    LastSavedByArgument.NumericFormat => NumericFormat,
                    LastSavedByArgument.DateTimeFormat => DateTimeFormat,
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
            // This is a simple instruction, so we only care about the instruction itself.
            // The logic for replacing arguments would be more complex and is not needed for this simple field.
            // It's implemented in more complex fields as an example.
            return base.ReplaceChild(index, replacement);
        }
    }
}

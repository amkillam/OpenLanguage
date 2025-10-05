using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    /// <summary>
    /// Retrieves the text specified by text in field-argument.
    /// </summary>
    public class ShapeFieldInstruction : FieldInstruction
    {
        public enum ShapeArgument
        {
            ShapeText,
            GeneralFormat,
            NumericFormat,
            DateTimeFormat,
        }

        /// <summary>
        /// The text to be retrieved.
        /// </summary>
        public ExpressionNode? ShapeText { get; set; }

        /// <summary>
        /// General formatting switch.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? GeneralFormat { get; set; }

        /// <summary>
        /// Numeric formatting switch.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? NumericFormat { get; set; }

        /// <summary>
        /// Date-time formatting switch.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? DateTimeFormat { get; set; }

        public List<ShapeArgument> Order { get; set; } = new List<ShapeArgument>();

        public ShapeFieldInstruction(
            StringLiteralNode instruction,
            ExpressionNode? shapeText,
            FlaggedArgument<ExpressionNode>? generalFormat,
            FlaggedArgument<ExpressionNode>? numericFormat,
            FlaggedArgument<ExpressionNode>? dateTimeFormat,
            List<ShapeArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            ShapeText = shapeText;
            GeneralFormat = generalFormat;
            NumericFormat = numericFormat;
            DateTimeFormat = dateTimeFormat;
            Order = order;
        }

        public override string ToRawString() =>
            Instruction.ToString()
            + string.Concat(
                Order.Select(
                    (ShapeArgument a) =>
                        a switch
                        {
                            ShapeArgument.ShapeText => ShapeText?.ToString() ?? string.Empty,
                            ShapeArgument.GeneralFormat => GeneralFormat?.ToString()
                                ?? string.Empty,
                            ShapeArgument.NumericFormat => NumericFormat?.ToString()
                                ?? string.Empty,
                            ShapeArgument.DateTimeFormat => DateTimeFormat?.ToString()
                                ?? string.Empty,
                            _ => string.Empty,
                        }
                )
            );

        public override IEnumerable<O> Children<O>()
        {
            if (Instruction is O o1)
            {
                yield return o1;
            }
            foreach (ShapeArgument arg in Order)
            {
                Node? node = arg switch
                {
                    ShapeArgument.ShapeText => ShapeText,
                    ShapeArgument.GeneralFormat => GeneralFormat,
                    ShapeArgument.NumericFormat => NumericFormat,
                    ShapeArgument.DateTimeFormat => DateTimeFormat,
                    _ => null,
                };

                if (node is O o)
                {
                    yield return o;
                }
            }
            yield break;
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
                    ShapeArgument arg = Order[index];
                    switch (arg)
                    {
                        case ShapeArgument.ShapeText:
                            if (replacement is ExpressionNode sln1)
                            {
                                current = ShapeText;
                                ShapeText = sln1;
                            }
                            break;
                        case ShapeArgument.GeneralFormat:
                            if (replacement is FlaggedArgument<ExpressionNode> fa1)
                            {
                                current = GeneralFormat;
                                GeneralFormat = fa1;
                            }
                            break;
                        case ShapeArgument.NumericFormat:
                            if (replacement is FlaggedArgument<ExpressionNode> fa2)
                            {
                                current = NumericFormat;
                                NumericFormat = fa2;
                            }
                            break;
                        case ShapeArgument.DateTimeFormat:
                            if (replacement is FlaggedArgument<ExpressionNode> fa3)
                            {
                                current = DateTimeFormat;
                                DateTimeFormat = fa3;
                            }
                            break;
                    }
                }
            }
            return current;
        }
    }
}

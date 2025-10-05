using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    public enum CommentsArgument
    {
        Value,
        GeneralFormat,
    }

    /// <summary>
    /// Represents a strongly-typed COMMENTS field instruction.
    /// Retrieves, and optionally sets, the comments relating to the current document, as recorded in the <Description> element of the Core File Properties part or,
    /// if field-argument is present, the comments specified by text in field-argument.
    ///
    /// Specifying a field-argument shall change <Description> to text.
    /// </summary>
    public class CommentsFieldInstruction : FieldInstruction
    {
        public ExpressionNode? Value { get; set; }
        public FlaggedArgument<ExpressionNode>? GeneralFormat { get; set; }
        public List<CommentsArgument> Order { get; set; }

        /// <summary>
        /// Initializes a new instance of the CommentsFieldInstruction class.
        /// </summary>
        public CommentsFieldInstruction(
            StringLiteralNode instruction,
            ExpressionNode? value,
            FlaggedArgument<ExpressionNode>? generalFormat,
            List<CommentsArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            Value = value;
            Order = order;
            GeneralFormat = generalFormat;
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToRawString() =>
            Instruction.ToString()
            + string.Concat(
                Order.Select(arg =>
                    arg switch
                    {
                        CommentsArgument.Value => Value?.ToString() ?? string.Empty,
                        CommentsArgument.GeneralFormat => GeneralFormat?.ToString() ?? string.Empty,
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
            foreach (CommentsArgument arg in Order)
            {
                switch (arg)
                {
                    case CommentsArgument.Value:
                        if (Value is O o2)
                        {
                            yield return o2;
                        }
                        break;
                    case CommentsArgument.GeneralFormat:
                        if (GeneralFormat is O o3)
                        {
                            yield return o3;
                        }
                        break;
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
                if (index > -1 && index < Order.Count)
                {
                    switch (Order[index])
                    {
                        case CommentsArgument.Value:
                            if (replacement is ExpressionNode en)
                            {
                                current = Value;
                                Value = en;
                            }
                            break;
                        case CommentsArgument.GeneralFormat:
                            if (replacement is FlaggedArgument<ExpressionNode> faen)
                            {
                                current = GeneralFormat;
                                GeneralFormat = faen;
                            }
                            break;
                    }
                }
            }
            return current;
        }
    }
}

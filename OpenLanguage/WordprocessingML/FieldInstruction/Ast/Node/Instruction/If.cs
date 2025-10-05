using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    public enum IfArgument
    {
        Condition,
        TrueExpression,
        FalseExpression,
    }

    /// <summary>
    /// Represents a strongly-typed IF field instruction.
    /// Evaluates the condition expression (field-argument). If true, returns field-argument-1; if false, returns field-argument-2 (both required).
    /// </summary>
    public class IfFieldInstruction : FieldInstruction
    {
        /// <summary>
        /// Condition to evaluate. If true, returns field-argument-1; if false, returns field-argument-2 (required).
        /// </summary>
        public ExpressionNode? Condition { get; set; }

        /// <summary>
        /// The expression to return if the comparison is true (field-argument-1, required).
        /// </summary>
        public ExpressionNode? TrueExpression { get; set; }

        /// <summary>
        /// The expression to return if the comparison is false (field-argument-2, required).
        /// </summary>
        public ExpressionNode? FalseExpression { get; set; }

        public List<IfArgument> Order { get; set; } = new List<IfArgument>();

        public IfFieldInstruction(
            StringLiteralNode instruction,
            ExpressionNode? condition,
            ExpressionNode? trueExpression,
            ExpressionNode? falseExpression,
            List<IfArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            Condition = condition;
            TrueExpression = trueExpression;
            FalseExpression = falseExpression;
            Order = order;
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToRawString()
        {
            return Instruction.ToString()
                + string.Concat(
                    Order.Select(arg =>
                        arg switch
                        {
                            IfArgument.Condition => Condition?.ToString() ?? string.Empty,
                            IfArgument.TrueExpression => TrueExpression?.ToString() ?? string.Empty,
                            IfArgument.FalseExpression => FalseExpression?.ToString()
                                ?? string.Empty,
                            _ => string.Empty,
                        }
                    )
                );
        }

        public override IEnumerable<O> Children<O>()
        {
            if (Instruction is O o)
            {
                yield return o;
            }

            foreach (IfArgument arg in Order)
            {
                Node? child = arg switch
                {
                    IfArgument.Condition => Condition,
                    IfArgument.TrueExpression => TrueExpression,
                    IfArgument.FalseExpression => FalseExpression,
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
                IfArgument arg = Order[index];
                if (replacement is ExpressionNode expr)
                {
                    switch (arg)
                    {
                        case IfArgument.Condition:
                            current = Condition;
                            Condition = expr;
                            break;
                        case IfArgument.TrueExpression:
                            current = TrueExpression;
                            TrueExpression = expr;
                            break;
                        case IfArgument.FalseExpression:
                            current = FalseExpression;
                            FalseExpression = expr;
                            break;
                    }
                }
            }

            return current;
        }
    }
}

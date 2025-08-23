using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage
{
    /// <summary>
    /// Represents a strongly-typed IF field instruction.
    /// Compares the values designated by Expression-1 and Expression-2 using the operator designated by Operator.
    /// </summary>
    public class IfFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// The first expression in the comparison (Expression-1, required).
        /// </summary>
        public Expression FirstExpression { get; set; } = null!;

        /// <summary>
        /// The comparison operator (required).
        /// </summary>
        public ComparisonOperator ComparisonOperator { get; set; } = ComparisonOperator.Equal;

        /// <summary>
        /// The second expression in the comparison (Expression-2, required).
        /// </summary>
        public Expression SecondExpression { get; set; } = null!;

        /// <summary>
        /// The expression to return if the comparison is true (field-argument-1, required).
        /// </summary>
        public Expression TrueExpression { get; set; } = null!;

        /// <summary>
        /// The expression to return if the comparison is false (field-argument-2, required).
        /// </summary>
        public Expression FalseExpression { get; set; } = null!;

        /// <summary>
        /// Initializes a new instance of the IfFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public IfFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "IF")
            {
                throw new ArgumentException($"Expected IF field, but got {Source.Instruction}");
            }

            // IF requires exactly 5 arguments: Expression-1, Operator, Expression-2, field-argument-1, field-argument-2
            List<FieldArgument> nonSwitchArgs = Source
                .Arguments.Where(arg => arg.Type != FieldArgumentType.Switch)
                .ToList();

            // Parse Expression-1
            string firstExpressionText =
                nonSwitchArgs.Count > 0
                    ? nonSwitchArgs[0].Value?.ToString() ?? string.Empty
                    : string.Empty;
            FirstExpression = ExpressionLexer.ParseExpression(firstExpressionText);

            // Parse Operator
            string operatorText =
                nonSwitchArgs.Count > 1
                    ? nonSwitchArgs[1].Value?.ToString() ?? string.Empty
                    : string.Empty;
            ComparisonOperator = ParseComparisonOperator(operatorText);

            // Parse Expression-2
            string secondExpressionText =
                nonSwitchArgs.Count > 2
                    ? nonSwitchArgs[2].Value?.ToString() ?? string.Empty
                    : string.Empty;
            SecondExpression = ExpressionLexer.ParseExpression(secondExpressionText);

            // Parse field-argument-1 (true expression)
            string trueExpressionText =
                nonSwitchArgs.Count > 3
                    ? nonSwitchArgs[3].Value?.ToString() ?? string.Empty
                    : string.Empty;
            TrueExpression = ExpressionLexer.ParseExpression(trueExpressionText);

            // Parse field-argument-2 (false expression)
            string falseExpressionText =
                nonSwitchArgs.Count > 4
                    ? nonSwitchArgs[4].Value?.ToString() ?? string.Empty
                    : string.Empty;
            FalseExpression = ExpressionLexer.ParseExpression(falseExpressionText);

            // IF field has no switches according to documentation
        }

        /// <summary>
        /// Parses a comparison operator from text.
        /// </summary>
        /// <param name="operatorText">The operator text to parse.</param>
        /// <returns>The parsed ComparisonOperator.</returns>
        private ComparisonOperator ParseComparisonOperator(string operatorText)
        {
            switch (operatorText?.Trim())
            {
                case "=":
                    return ComparisonOperator.Equal;
                case "<>":
                    return ComparisonOperator.NotEqual;
                case "<":
                    return ComparisonOperator.LessThan;
                case "<=":
                    return ComparisonOperator.LessThanOrEqual;
                case ">":
                    return ComparisonOperator.GreaterThan;
                case ">=":
                    return ComparisonOperator.GreaterThanOrEqual;
                default:
                    throw new ArgumentException($"Invalid comparison operator: {operatorText}");
            }
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToString()
        {
            List<string> result = new List<string> { "IF" };

            // Add Expression-1
            if (FirstExpression != null)
            {
                result.Add(FirstExpression.ToString());
            }

            // Add Operator
            string operatorString = ComparisonOperator switch
            {
                ComparisonOperator.Equal => "=",
                ComparisonOperator.NotEqual => "<>",
                ComparisonOperator.LessThan => "<",
                ComparisonOperator.LessThanOrEqual => "<=",
                ComparisonOperator.GreaterThan => ">",
                ComparisonOperator.GreaterThanOrEqual => ">=",
                _ => throw new InvalidOperationException(
                    $"Unknown comparison operator: {ComparisonOperator}"
                ),
            };
            result.Add(operatorString);

            // Add Expression-2
            if (SecondExpression != null)
            {
                result.Add(SecondExpression.ToString());
            }

            // Add field-argument-1 (true expression)
            if (TrueExpression != null)
            {
                result.Add(TrueExpression.ToString());
            }

            // Add field-argument-2 (false expression)
            if (FalseExpression != null)
            {
                result.Add(FalseExpression.ToString());
            }

            return string.Join(" ", result);
        }
    }
}

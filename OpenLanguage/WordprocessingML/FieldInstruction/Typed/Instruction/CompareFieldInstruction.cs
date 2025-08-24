using System;
using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Expression;
using OpenLanguage.WordprocessingML.Operators;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Typed
{
    /// <summary>
    /// Represents a strongly-typed COMPARE field instruction.
    /// Compares two expressions using a relational or equality operator.
    /// Returns 1 if comparison is true, 0 if false.
    /// </summary>
    public class CompareFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// The first expression to compare.
        /// </summary>
        public Expression.Expression? Expression1 { get; set; }

        /// <summary>
        /// The comparison operator to use.
        /// </summary>
        public ComparisonOperator? Operator { get; set; }

        /// <summary>
        /// The second expression to compare.
        /// </summary>
        public Expression.Expression? Expression2 { get; set; }

        /// <summary>
        /// Initializes a new instance of the CompareFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public CompareFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "COMPARE")
            {
                throw new ArgumentException(
                    $"Expected COMPARE field, but got {Source.Instruction}"
                );
            }

            // COMPARE requires exactly 3 arguments: Expression-1, Operator, Expression-2
            List<FieldArgument> nonSwitchArgs = Source
                .Arguments.Where(arg =>
                    arg.Type == FieldArgumentType.Identifier
                    || arg.Type == FieldArgumentType.StringLiteral
                    || arg.Type == FieldArgumentType.NestedField
                )
                .ToList();

            // COMPARE requires exactly 3 arguments: Expression-1, Operator, Expression-2
            // We will initialize them to null and let the parsing logic handle their presence.
            if (nonSwitchArgs.Count > 0)
            {
                string expression1Text = GetArgumentText(nonSwitchArgs[0]);
                Expression1 = ExpressionLexer.Parse(expression1Text);
            }

            if (nonSwitchArgs.Count > 1)
            {
                string operatorText = GetArgumentText(nonSwitchArgs[1]);
                Operator = ParseComparisonOperator(operatorText);
            }

            if (nonSwitchArgs.Count > 2)
            {
                string expression2Text = GetArgumentText(nonSwitchArgs[2]);
                Expression2 = ExpressionLexer.Parse(expression2Text);
            }
        }

        /// <summary>
        /// Gets the text representation of a field argument.
        /// </summary>
        private string GetArgumentText(FieldArgument argument)
        {
            if (
                argument.Type == FieldArgumentType.NestedField
                && argument.Value is FieldInstruction nestedField
            )
            {
                return nestedField.ToString();
            }
            return argument.Value?.ToString() ?? "";
        }

        /// <summary>
        /// Parses a comparison operator from text.
        /// </summary>
        private ComparisonOperator? ParseComparisonOperator(string? operatorText)
        {
            if (string.IsNullOrWhiteSpace(operatorText))
            {
                return null;
            }

            return operatorText.Trim() switch
            {
                "=" => ComparisonOperator.Equal,
                "<>" => ComparisonOperator.NotEqual,
                "<" => ComparisonOperator.LessThan,
                "<=" => ComparisonOperator.LessThanOrEqual,
                ">" => ComparisonOperator.GreaterThan,
                ">=" => ComparisonOperator.GreaterThanOrEqual,
                _ => null,
            };
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToString()
        {
            List<string> result = new List<string> { "COMPARE" };

            if (Expression1 != null)
            {
                string expr1Text = Expression1.ToString();
                result.Add(expr1Text.Contains(" ") ? $"\"{expr1Text}\"" : expr1Text);
            }

            if (Operator.HasValue)
            {
                string operatorText = Operator.Value switch
                {
                    ComparisonOperator.Equal => "=",
                    ComparisonOperator.NotEqual => "<>",
                    ComparisonOperator.LessThan => "<",
                    ComparisonOperator.LessThanOrEqual => "<=",
                    ComparisonOperator.GreaterThan => ">",
                    ComparisonOperator.GreaterThanOrEqual => ">=",
                    _ => "",
                };
                result.Add(operatorText);
            }

            if (Expression2 != null)
            {
                string expr2Text = Expression2.ToString();
                result.Add(expr2Text.Contains(" ") ? $"\"{expr2Text}\"" : expr2Text);
            }

            return string.Join(" ", result);
        }
    }
}

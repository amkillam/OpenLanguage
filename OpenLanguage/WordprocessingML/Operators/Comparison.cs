using System;

namespace OpenLanguage.WordprocessingML.Operators
{
    /// <summary>
    /// Enumeration of comparison operators.
    /// </summary>
    public enum ComparisonOperator : sbyte
    {
        Equal = 0b01,
        NotEqual = ~ComparisonOperator.Equal,
        LessThan = 0b10,
        LessThanOrEqual = ComparisonOperator.Equal | ComparisonOperator.LessThan,
        GreaterThan = ~ComparisonOperator.LessThanOrEqual,
        GreaterThanOrEqual = ~ComparisonOperator.LessThan,
    }

    public static class ComparisonOperatorExtensions
    {
        /// <summary>
        /// Parses a string representation of a comparison operator into the corresponding enum value.
        /// </summary>
        /// <param name="operatorString">The string representation of the operator.</param>
        /// <returns>The corresponding ComparisonOperator enum value.</returns>
        /// <exception cref="ArgumentException">Thrown if the operator string is not recognized.</exception>
        public static ComparisonOperator ParseOperator(string? operatorString)
        {
            return operatorString?.Trim() switch
            {
                "=" => ComparisonOperator.Equal,
                "<>" => ComparisonOperator.NotEqual,
                "<" => ComparisonOperator.LessThan,
                "<=" => ComparisonOperator.LessThanOrEqual,
                ">" => ComparisonOperator.GreaterThan,
                ">=" => ComparisonOperator.GreaterThanOrEqual,
                _ => throw new ArgumentException($"Invalid comparison operator: {operatorString}"),
            };
        }

        /// <summary>
        /// Converts a ComparisonOperator enum value to its string representation.
        /// </summary>
        /// <param name="op">The operator to convert.</param>
        /// <returns>The string representation of the operator.</returns>
        public static string OperatorToString(ComparisonOperator op)
        {
            return op switch
            {
                ComparisonOperator.Equal => "=",
                ComparisonOperator.NotEqual => "<>",
                ComparisonOperator.LessThan => "<",
                ComparisonOperator.LessThanOrEqual => "<=",
                ComparisonOperator.GreaterThan => ">",
                ComparisonOperator.GreaterThanOrEqual => ">=",
                _ => throw new ArgumentException($"Unknown comparison operator: {op}"),
            };
        }
    }
}

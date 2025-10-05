using System;

namespace OpenLanguage.WordprocessingML.Operators
{
    public static class OperatorConstants
    {
        public const sbyte OperatorMask = 0b111;
    }

    /// <summary>
    /// Enumeration of comparison operators.
    ///
    /// This can be seen in practice as what would be a bitpacked union in C.
    /// First bit represents "Equal": whether the two values is equal.
    /// Second bit represents "LessThan": whether the first value is less than the second
    /// Third bit represents "GreaterThan": whether the first value is greater than the second.
    /// Combining these bits allows representation of all standard comparison operators.
    /// For example:
    ///   - Equal (0b001): only equal
    ///   - LessThan (0b010): only less than
    ///   - LessThanOrEqual (0b011): less than or equal
    ///   - GreaterThan (0b100): only greater than
    ///   - GreaterThanOrEqual (0b101): greater than or equal
    ///   - NotEqual (0b110): less than or greater than (not equal)
    ///   - All (0b111): equal, less than, or greater than (always true)
    ///   - None (0b000): no relation (always false)
    /// </summary>
    public enum ComparisonOperator : sbyte
    {
        Equal = 0b001,
        LessThan = 0b010,
        LessThanOrEqual = ComparisonOperator.Equal | ComparisonOperator.LessThan, // 0b011
        GreaterThan = ~ComparisonOperator.LessThanOrEqual & OperatorConstants.OperatorMask, // 0b100
        GreaterThanOrEqual = ~ComparisonOperator.LessThan & OperatorConstants.OperatorMask, // 0b101
        NotEqual = ComparisonOperator.LessThan | ComparisonOperator.GreaterThan, // 0b110
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

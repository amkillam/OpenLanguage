using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage
{
    /// <summary>
    /// Represents comparison operators used in field instructions like SKIPIF, NEXTIF, IF, etc.
    /// </summary>
    public enum ComparisonOperator
    {
        /// <summary>
        /// Equal to (=)
        /// </summary>
        Equal,

        /// <summary>
        /// Not equal to (<>)
        /// </summary>
        NotEqual,

        /// <summary>
        /// Less than (<)
        /// </summary>
        LessThan,

        /// <summary>
        /// Less than or equal to (<=)
        /// </summary>
        LessThanOrEqual,

        /// <summary>
        /// Greater than (>)
        /// </summary>
        GreaterThan,

        /// <summary>
        /// Greater than or equal to (>=)
        /// </summary>
        GreaterThanOrEqual,
    }

    /// <summary>
    /// Represents a strongly-typed SKIPIF field instruction.
    /// Compares the values designated by Expression-1 and Expression-2 using the operator designated by Operator. If the comparison is true, `SKIPIF` cancels the current merge document, moves to the next in the data source, and starts a new merge document. If the comparison is false, the current merge document is continued. Operator can be any one of the six relational and equality operators specified for operator (§[2.16.3.3](https://c-rex.net/samples/ooxml/e1/Part4/OOXML_P4_DOCX_Operatorsfieldoperat_topic_ID0EUQXZ.html#topic_ID0EUQXZ)).
    /// </summary>
    public class SkipIfFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// The first expression to compare.
        /// </summary>
        public Expression? LeftExpression { get; set; }

        /// <summary>
        /// The comparison operator.
        /// </summary>
        public ComparisonOperator ComparisonOperator { get; set; } = ComparisonOperator.Equal;

        /// <summary>
        /// The second expression to compare.
        /// </summary>
        public Expression? RightExpression { get; set; }

        /// <summary>
        /// Initializes a new instance of the SkipIfFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public SkipIfFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "SKIPIF")
            {
                throw new ArgumentException($"Expected SKIPIF field, but got {Source.Instruction}");
            }

            // SKIPIF requires exactly 3 arguments: Expression-1, Operator, Expression-2
            // Parse the arguments in order
            if (Source.Arguments.Count > 0)
                LeftExpression = ExpressionLexer.ParseExpression(
                    Source.Arguments[0].Value?.ToString()
                );

            if (Source.Arguments.Count > 1)
            {
                try
                {
                    ComparisonOperator = ExpressionLexer.ParseOperator(
                        Source.Arguments[1].Value?.ToString()
                    );
                }
                catch (ArgumentException ex)
                {
                    throw new ArgumentException(
                        $"Invalid comparison operator in SKIPIF field: {Source.Arguments[1].Value?.ToString()}",
                        ex
                    );
                }
            }

            if (Source.Arguments.Count > 2)
                RightExpression = ExpressionLexer.ParseExpression(
                    Source.Arguments[2].Value?.ToString()
                );
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToString()
        {
            List<string> result = new List<string> { Source.Instruction };

            if (LeftExpression != null)
            {
                result.Add(LeftExpression.RawText);
            }

            result.Add(ExpressionLexer.OperatorToString(ComparisonOperator));

            if (RightExpression != null)
            {
                result.Add(RightExpression.RawText);
            }

            return string.Join(" ", result);
        }
    }
}

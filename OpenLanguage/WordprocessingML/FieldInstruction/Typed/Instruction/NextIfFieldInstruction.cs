using System;
using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Expression;
using OpenLanguage.WordprocessingML.Operators;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Typed
{
    /// <summary>
    /// Represents a strongly-typed NEXTIF field instruction.
    /// Compares the values designated by Expression-1 and Expression-2 using the operator designated by Operator. If the comparison is true, the next data record is merged into the current merge document. (Merge fields that follow the `NEXTIF` in the main document are replaced by values from the next data record rather than the current data record.) If the comparison is false, the next data record is merged into a new merge document. Operator can be any one of the six relational and equality operators. Fields shall NOT be used in a footnote, an endnote, annotation, a header, a footer, or a data source. A `NEXTIF` field shall NOT be nested within any field.
    /// </summary>
    public class NextIfFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// The first expression to compare.
        /// </summary>
        public Expression.Expression? LeftExpression { get; set; }

        /// <summary>
        /// The comparison operator.
        /// </summary>
        public ComparisonOperator Operator { get; set; } = ComparisonOperator.Equal;

        /// <summary>
        /// The second expression to compare.
        /// </summary>
        public Expression.Expression? RightExpression { get; set; }

        /// <summary>
        /// Initializes a new instance of the NextIfFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public NextIfFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "NEXTIF")
            {
                throw new ArgumentException(
                    $"Expected NEXTIF field, but got \"{Source.Instruction}\""
                );
            }

            // NEXTIF requires exactly 3 arguments: Expression-1, Operator, Expression-2
            // Parse the arguments in order
            if (Source.Arguments.Count > 0)
            {
                LeftExpression = ExpressionLexer.ParseExpression(
                    Source.Arguments[0].Value?.ToString()
                );

                if (Source.Arguments.Count > 1)
                {
                    try
                    {
                        Operator = ComparisonOperatorExtensions.ParseOperator(
                            Source.Arguments[1].Value?.ToString()
                        );
                    }
                    catch (ArgumentException ex)
                    {
                        throw new ArgumentException(
                            $"Invalid comparison operator in NEXTIF field: \"{Source.Arguments[1].Value?.ToString()}\"",
                            ex
                        );
                    }

                    if (Source.Arguments.Count > 2)
                    {
                        RightExpression = ExpressionLexer.ParseExpression(
                            Source.Arguments[2].Value?.ToString()
                        );
                    }
                }
            }
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

            result.Add(ComparisonOperatorExtensions.OperatorToString(Operator));

            if (RightExpression != null)
            {
                result.Add(RightExpression.RawText);
            }

            return string.Join(" ", result);
        }
    }
}

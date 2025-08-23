using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace OpenLanguage
{
    /// <summary>
    /// Represents the type of location target for a GOTOBUTTON field.
    /// </summary>
    public enum GoToButtonTargetType
    {
        /// <summary>
        /// A bookmark name.
        /// </summary>
        Bookmark,

        /// <summary>
        /// An annotation (A n).
        /// </summary>
        Annotation,

        /// <summary>
        /// A footnote (F n).
        /// </summary>
        Footnote,

        /// <summary>
        /// A line (L n).
        /// </summary>
        Line,

        /// <summary>
        /// A page (P n).
        /// </summary>
        Page,

        /// <summary>
        /// A section (S n).
        /// </summary>
        Section,
    }

    /// <summary>
    /// Represents a strongly-typed GOTOBUTTON field instruction.
    /// Inserts a jump command that moves the insertion point to a specified location when activated.
    /// </summary>
    public class GoToButtonFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// The location to jump to (field-argument-1, required).
        /// </summary>
        public Expression? TargetLocation { get; set; }

        /// <summary>
        /// The text or graphic "button" that appears in the document (field-argument-2, required).
        /// </summary>
        public Expression? ButtonDisplayContent { get; set; }

        /// <summary>
        /// Initializes a new instance of the GoToButtonFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public GoToButtonFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "GOTOBUTTON")
            {
                throw new ArgumentException(
                    $"Expected GOTOBUTTON field, but got {Source.Instruction}"
                );
            }

            // GOTOBUTTON requires exactly 2 field arguments
            List<FieldArgument> nonSwitchArgs = Source
                .Arguments.Where(arg => arg.Type != FieldArgumentType.Switch)
                .ToList();

            // Parse field-argument-1: target location
            if (nonSwitchArgs.Count > 0)
            {
                string targetLocationText = nonSwitchArgs[0].Value?.ToString() ?? string.Empty;
                TargetLocation = ExpressionLexer.ParseExpression(targetLocationText);
            }

            // Parse field-argument-2: button display content
            if (nonSwitchArgs.Count > 1)
            {
                string buttonReadContentText = nonSwitchArgs[1].Value?.ToString() ?? string.Empty;
                ButtonDisplayContent = ExpressionLexer.ParseExpression(buttonReadContentText);
            }

            // GOTOBUTTON field has no switches according to documentation
        }

        /// <summary>
        /// Parses the target location to determine its type and value.
        /// </summary>
        /// <param name="targetLocation">The target location text to parse.</param>
        /// <returns>A tuple containing the target type and numeric value (if applicable).</returns>
        public (GoToButtonTargetType Type, int? Number) ParseTargetLocation(string targetLocation)
        {
            if (string.IsNullOrEmpty(targetLocation))
            {
                return (GoToButtonTargetType.Bookmark, null);
            }

            // Check for special location patterns: A n, F n, L n, P n, S n
            Match match = Regex.Match(
                targetLocation.Trim(),
                @"^([AFLPS])\s+(\d+)$",
                RegexOptions.IgnoreCase
            );
            if (match.Success)
            {
                string typeChar = match.Groups[1].Value.ToUpperInvariant();
                int number = int.Parse(match.Groups[2].Value);

                GoToButtonTargetType targetType = typeChar switch
                {
                    "A" => GoToButtonTargetType.Annotation,
                    "F" => GoToButtonTargetType.Footnote,
                    "L" => GoToButtonTargetType.Line,
                    "P" => GoToButtonTargetType.Page,
                    "S" => GoToButtonTargetType.Section,
                    _ => throw new ArgumentException($"Invalid target type: {typeChar}"),
                };

                return (targetType, number);
            }

            // If no pattern match, assume it's a bookmark name
            return (GoToButtonTargetType.Bookmark, null);
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToString()
        {
            List<string> result = new List<string> { "GOTOBUTTON" };

            // Add field-argument-1: target location
            if (TargetLocation != null)
            {
                result.Add(TargetLocation.ToString());
            }

            // Add field-argument-2: button display content
            if (ButtonDisplayContent != null)
            {
                result.Add(ButtonDisplayContent.ToString());
            }

            return string.Join(" ", result);
        }
    }
}

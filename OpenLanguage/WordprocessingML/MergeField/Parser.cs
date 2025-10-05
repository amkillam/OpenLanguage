using System;

namespace OpenLanguage.WordprocessingML.MergeField
{
    /// <summary>
    /// Represents a parsed merge field placeholder used in mail merge operations.
    /// </summary>
    public class MergeFieldPlaceholder
    {
        /// <summary>
        /// The field name (without merge field delimiters).
        /// </summary>
        public string FieldName { get; set; } = string.Empty;

        /// <summary>
        /// The raw placeholder text including delimiters.
        /// </summary>
        public string RawText { get; set; } = string.Empty;

        /// <summary>
        /// Whether this placeholder has valid merge field syntax.
        /// </summary>
        public bool IsValid => !string.IsNullOrWhiteSpace(FieldName);

        /// <summary>
        /// Any formatting or switches applied to the merge field.
        /// </summary>
        public string? FormattingSwitch { get; set; }
    }

    public static class MergeFieldParser
    {
        public static OpenLanguage.WordprocessingML.Ast.MergeFieldNode Parse(
            string? placeholderText
        )
        {
            if (string.IsNullOrWhiteSpace(placeholderText))
            {
                throw new ArgumentException(
                    "Placeholder cannot be null or whitespace.",
                    nameof(placeholderText)
                );
            }

            OpenLanguage.WordprocessingML.MergeField.Generated.Scanner scanner =
                new OpenLanguage.WordprocessingML.MergeField.Generated.Scanner();
            scanner.SetSource(placeholderText, 0);

            OpenLanguage.WordprocessingML.MergeField.Generated.Parser parser =
                new OpenLanguage.WordprocessingML.MergeField.Generated.Parser(scanner);

            if (!parser.Parse())
            {
                throw new InvalidOperationException(
                    "Failed to parse merge field due to syntax errors."
                );
            }

            if (parser.root is not OpenLanguage.WordprocessingML.Ast.MergeFieldNode node)
            {
                throw new InvalidOperationException("Parser returned a null or invalid AST root.");
            }

            return node;
        }

        public static OpenLanguage.WordprocessingML.Ast.MergeFieldNode? TryParse(
            string? placeholderText
        )
        {
            try
            {
                return Parse(placeholderText);
            }
            catch
            {
                return null;
            }
        }
    }
}

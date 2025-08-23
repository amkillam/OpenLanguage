using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage
{
    /// <summary>
    /// Represents a strongly-typed CITATION field instruction.
    /// Displays bibliography source contents using the specified bibliographic style.
    /// </summary>
    public class CitationFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// The source tag identifying the bibliography source to display.
        /// </summary>
        public string SourceTag { get; set; } = string.Empty;

        /// <summary>
        /// Switch: \l field-argument
        /// Locale used with bibliographic style to format the citation.
        /// </summary>
        public LanguageIdentifier? LocaleId { get; set; }

        /// <summary>
        /// Switch: \f field-argument
        /// Prefix to prepend to the citation.
        /// </summary>
        public string? Prefix { get; set; }

        /// <summary>
        /// Switch: \s field-argument
        /// Suffix to append to the citation.
        /// </summary>
        public string? Suffix { get; set; }

        /// <summary>
        /// Switch: \p field-argument
        /// Page number associated with the citation (can include ranges like "123-125" or prefixes like "pp. 123").
        /// </summary>
        public string? PageNumber { get; set; }

        /// <summary>
        /// Switch: \v field-argument
        /// Volume number associated with the citation (can include letters like "2A" or prefixes like "vol. 2").
        /// </summary>
        public string? VolumeNumber { get; set; }

        /// <summary>
        /// Switch: \n
        /// Suppress author information from the citation.
        /// </summary>
        public bool SuppressAuthor { get; set; }

        /// <summary>
        /// Switch: \t
        /// Suppress title information from the citation.
        /// </summary>
        public bool SuppressTitle { get; set; }

        /// <summary>
        /// Switch: \y
        /// Suppress year information from the citation.
        /// </summary>
        public bool SuppressYear { get; set; }

        /// <summary>
        /// Switch: \m field-argument
        /// Additional source tag to include in this citation's field result.
        /// </summary>
        public string? AdditionalSourceTag { get; set; }

        /// <summary>
        /// Initializes a new instance of the CitationFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public CitationFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Gets the next argument after the specified switch index.
        /// </summary>
        private string GetNextArgumentAfter(int switchIndex)
        {
            if (switchIndex + 1 < Source.Arguments.Count)
            {
                FieldArgument nextArg = Source.Arguments[switchIndex + 1];
                if (nextArg.Type != FieldArgumentType.Switch)
                {
                    return nextArg.Value?.ToString() ?? "";
                }
            }
            return "";
        }

        /// <summary>
        /// Parses a language identifier from text.
        /// </summary>
        private LanguageIdentifier? ParseLanguageId(string languageText)
        {
            if (string.IsNullOrWhiteSpace(languageText))
                return null;

            // Try parsing as LCID number first
            if (int.TryParse(languageText.Trim(), out int lcid))
            {
                if (Enum.IsDefined(typeof(LanguageIdentifier), lcid))
                {
                    return (LanguageIdentifier)lcid;
                }
            }

            // Try parsing as enum name
            if (
                Enum.TryParse<LanguageIdentifier>(
                    languageText.Trim(),
                    true,
                    out LanguageIdentifier result
                )
            )
            {
                return result;
            }

            return null;
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "CITATION")
            {
                throw new ArgumentException(
                    $"Expected CITATION field, but got {Source.Instruction}"
                );
            }

            // Parse primary field argument (source tag - required)
            FieldArgument? firstNonSwitch = Source.Arguments.FirstOrDefault(arg =>
                arg.Type == FieldArgumentType.Identifier
                || arg.Type == FieldArgumentType.StringLiteral
            );

            SourceTag = firstNonSwitch?.Value?.ToString() ?? string.Empty;

            // Parse switches
            for (int i = 0; i < Source.Arguments.Count; i++)
            {
                FieldArgument arg = Source.Arguments[i];
                if (arg.Type == FieldArgumentType.Switch)
                {
                    string switchValue = arg.Value?.ToString() ?? string.Empty;
                    switch (switchValue.ToLowerInvariant())
                    {
                        case "\\l":
                            LocaleId = ParseLanguageId(GetNextArgumentAfter(i));
                            break;
                        case "\\f":
                            Prefix = GetNextArgumentAfter(i);
                            break;
                        case "\\s":
                            Suffix = GetNextArgumentAfter(i);
                            break;
                        case "\\p":
                            PageNumber = GetNextArgumentAfter(i);
                            break;
                        case "\\v":
                            VolumeNumber = GetNextArgumentAfter(i);
                            break;
                        case "\\n":
                            SuppressAuthor = true;
                            break;
                        case "\\t":
                            SuppressTitle = true;
                            break;
                        case "\\y":
                            SuppressYear = true;
                            break;
                        case "\\m":
                            AdditionalSourceTag = GetNextArgumentAfter(i);
                            break;
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
            List<string> result = new List<string> { "CITATION" };

            if (!string.IsNullOrEmpty(SourceTag))
            {
                result.Add(SourceTag.Contains(" ") ? $"\"{SourceTag}\"" : SourceTag);
            }

            if (LocaleId.HasValue)
            {
                result.Add("\\l");
                result.Add(((int)LocaleId.Value).ToString());
            }

            if (!string.IsNullOrWhiteSpace(Prefix))
            {
                result.Add("\\f");
                result.Add(Prefix.Contains(" ") ? $"\"{Prefix}\"" : Prefix);
            }

            if (!string.IsNullOrWhiteSpace(Suffix))
            {
                result.Add("\\s");
                result.Add(Suffix.Contains(" ") ? $"\"{Suffix}\"" : Suffix);
            }

            if (!string.IsNullOrWhiteSpace(PageNumber))
            {
                result.Add("\\p");
                result.Add(PageNumber.Contains(" ") ? $"\"{PageNumber}\"" : PageNumber);
            }

            if (!string.IsNullOrWhiteSpace(VolumeNumber))
            {
                result.Add("\\v");
                result.Add(VolumeNumber.Contains(" ") ? $"\"{VolumeNumber}\"" : VolumeNumber);
            }

            if (SuppressAuthor)
            {
                result.Add("\\n");
            }

            if (SuppressTitle)
            {
                result.Add("\\t");
            }

            if (SuppressYear)
            {
                result.Add("\\y");
            }

            if (!string.IsNullOrWhiteSpace(AdditionalSourceTag))
            {
                result.Add("\\m");
                result.Add(
                    AdditionalSourceTag.Contains(" ")
                        ? $"\"{AdditionalSourceTag}\""
                        : AdditionalSourceTag
                );
            }

            return string.Join(" ", result);
        }
    }
}

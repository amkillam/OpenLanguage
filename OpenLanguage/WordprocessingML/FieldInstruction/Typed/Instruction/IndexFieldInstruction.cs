using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Typed
{
    /// <summary>
    /// Represents a strongly-typed INDEX field instruction.
    /// Builds an index using the index entries specified by XE fields, and inserts that index at this place in the document.
    /// Each index entry and subentry is a separate paragraph unless the \r switch is used.
    /// </summary>
    public class IndexFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// Switch: \b field-argument
        /// Builds an index for the portion of the document marked by the bookmark indicated by this field argument.
        /// </summary>
        public string? BookmarkName { get; set; }

        /// <summary>
        /// Switch: \c field-argument
        /// Builds an index having the number of columns per page specified by this field argument.
        /// That number can be 1–4. Without this switch, the number of columns is 1.
        /// </summary>
        public int? NumberOfColumns { get; set; }

        /// <summary>
        /// Switch: \d field-argument
        /// Specifies a sequence of characters that is used to separate sequence numbers and page numbers when the \s switch is used.
        /// By default, a hyphen (-) is used.
        /// </summary>
        public string? SequencePageSeparator { get; set; }

        /// <summary>
        /// Switch: \e field-argument
        /// Specifies a sequence of characters that is used to separate an index entry and its first page number.
        /// By default, a comma (,) and space sequence is used. If text contains a horizontal tab character,
        /// the page number list is right justified in the column.
        /// </summary>
        public string? EntryPageSeparator { get; set; }

        /// <summary>
        /// Switch: \f field-argument
        /// Builds an index using only those entries having the entry type (XE) specified by this field argument.
        /// Without this switch, all entries are included.
        /// </summary>
        public string? EntryTypeFilter { get; set; }

        /// <summary>
        /// Switch: \g field-argument
        /// Specifies a sequence of characters that is used to separate the start and end of a page range.
        /// By default, an en dash is used.
        /// </summary>
        public string? PageRangeSeparator { get; set; }

        /// <summary>
        /// Switch: \h field-argument
        /// Builds an index such that this field argument occurs as a heading—formatted with the Index Heading style—at the start of each set of entries for any given letter.
        /// If the first letter in text is A or a, that letter is replaced with the corresponding letter for each letter set.
        /// To replace the default heading with a blank line, use a space as text.
        /// </summary>
        public string? IndexHeadingText { get; set; }

        /// <summary>
        /// Switch: \k field-argument
        /// Specifies a sequence of characters that is used to separate an index entry and its cross reference.
        /// Used for cross references produced by XE entries having a \t switch. By default, a period (.) and space sequence is used.
        /// </summary>
        public string? CrossReferenceSeparator { get; set; }

        /// <summary>
        /// Switch: \l field-argument
        /// Specifies a sequence of characters that is used to separate two page numbers in a page number list.
        /// By default, a comma (,) and space sequence is used.
        /// </summary>
        public string? PageNumberSeparator { get; set; }

        /// <summary>
        /// Switch: \p field-argument
        /// Builds an index using only those entries whose first letter falls within the range specified by this field argument.
        /// Format is "startLetter-endLetter". If startLetter is "!", entries whose first character is not a letter are included,
        /// along with letters starting from A. The letters in the range can be either upper- or lowercase.
        /// </summary>
        public string? LetterRange { get; set; }

        /// <summary>
        /// Switch: \r
        /// Runs subentries into the same line as the main entry. Colons (:) separate main entries from subentries;
        /// semicolons (;) separate subentries.
        /// </summary>
        public bool UseRunInFormat { get; set; }

        /// <summary>
        /// Switch: \s field-argument
        /// Includes with each page number the sequence number of the sequence name specified by this field argument.
        /// The sequence number is included along with the page number, separated by a hyphen (-) by default,
        /// or by the character specified in \d switch.
        /// </summary>
        public string? SequenceName { get; set; }

        /// <summary>
        /// Switch: \y
        /// Enables the use of yomi text for index entries. Yomi text is used for phonetic sorting in East Asian languages.
        /// </summary>
        public bool EnableYomiText { get; set; }

        /// <summary>
        /// Switch: \z field-argument
        /// Uses the language ID specified by this field argument to generate the index.
        /// This affects sorting and formatting of the index.
        /// </summary>
        public LanguageIdentifier? LanguageId { get; set; }

        /// <summary>
        /// Initializes a new instance of the IndexFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public IndexFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "INDEX")
            {
                throw new ArgumentException($"Expected INDEX field, but got {Source.Instruction}");
            }

            // INDEX field has no field arguments, only switches
            List<FieldArgument> nonSwitchArgs = Source
                .Arguments.Where(arg => arg.Type != FieldArgumentType.Switch)
                .ToList();

            if (nonSwitchArgs.Count > 0)
            {
                throw new ArgumentException("INDEX field takes no arguments, only switches");
            }

            // Parse switches
            for (int i = 0; i < Source.Arguments.Count; i++)
            {
                FieldArgument arg = Source.Arguments[i];
                if (arg.Type == FieldArgumentType.Switch)
                {
                    string switchValue = arg.Value?.ToString() ?? string.Empty;
                    ParseSwitch(switchValue, i);
                }
            }
        }

        /// <summary>
        /// Parses individual switches and their arguments.
        /// </summary>
        /// <param name="switchValue">The switch value to parse.</param>
        /// <param name="switchIndex">The index of the switch in the arguments list.</param>
        private void ParseSwitch(string switchValue, int switchIndex)
        {
            switch (switchValue.ToLowerInvariant())
            {
                case "\\b":
                    BookmarkName = GetArgumentAfterSwitch(switchIndex);
                    break;
                case "\\c":
                    string? columnArg = GetArgumentAfterSwitch(switchIndex);
                    if (
                        !string.IsNullOrEmpty(columnArg)
                        && int.TryParse(columnArg, out int columns)
                        && columns >= 1
                        && columns <= 4
                    )
                    {
                        NumberOfColumns = columns;
                    }
                    else if (!string.IsNullOrEmpty(columnArg))
                    {
                        throw new ArgumentException(
                            $"\\c switch requires a number between 1 and 4, got: {columnArg}"
                        );
                    }
                    break;
                case "\\d":
                    SequencePageSeparator = GetArgumentAfterSwitch(switchIndex);
                    break;
                case "\\e":
                    EntryPageSeparator = GetArgumentAfterSwitch(switchIndex);
                    break;
                case "\\f":
                    EntryTypeFilter = GetArgumentAfterSwitch(switchIndex);
                    break;
                case "\\g":
                    PageRangeSeparator = GetArgumentAfterSwitch(switchIndex);
                    break;
                case "\\h":
                    IndexHeadingText = GetArgumentAfterSwitch(switchIndex);
                    break;
                case "\\k":
                    CrossReferenceSeparator = GetArgumentAfterSwitch(switchIndex);
                    break;
                case "\\l":
                    PageNumberSeparator = GetArgumentAfterSwitch(switchIndex);
                    break;
                case "\\p":
                    string? range = GetArgumentAfterSwitch(switchIndex);
                    if (!string.IsNullOrEmpty(range) && ValidateLetterRange(range))
                    {
                        LetterRange = range;
                    }
                    else if (!string.IsNullOrEmpty(range))
                    {
                        throw new ArgumentException(
                            $"\\p switch requires a valid letter range (e.g., 'A-M' or '!-Z'), got: {range}"
                        );
                    }
                    break;
                case "\\r":
                    UseRunInFormat = true;
                    break;
                case "\\s":
                    SequenceName = GetArgumentAfterSwitch(switchIndex);
                    break;
                case "\\y":
                    EnableYomiText = true;
                    break;
                case "\\z":
                    string? langId = GetArgumentAfterSwitch(switchIndex);
                    if (!string.IsNullOrEmpty(langId))
                    {
                        LanguageId = ParseLanguageId(langId);
                    }
                    break;
                default:
                    // Unknown switch - could be a general formatting switch handled by base class
                    break;
            }
        }

        /// <summary>
        /// Gets the argument following the specified switch index.
        /// </summary>
        /// <param name="switchIndex">The index of the switch.</param>
        /// <returns>The argument following the switch, or null if none exists.</returns>
        private string? GetArgumentAfterSwitch(int switchIndex)
        {
            if (switchIndex + 1 < Source.Arguments.Count)
            {
                FieldArgument nextArg = Source.Arguments[switchIndex + 1];
                if (nextArg.Type != FieldArgumentType.Switch)
                {
                    return nextArg.Value?.ToString();
                }
            }
            return null;
        }

        /// <summary>
        /// Validates a letter range string for the \p switch.
        /// </summary>
        /// <param name="range">The letter range to validate.</param>
        /// <returns>True if the range is valid, false otherwise.</returns>
        private static bool ValidateLetterRange(string range)
        {
            if (string.IsNullOrEmpty(range))
            {
                return false;
            }

            // Handle special case where range starts with '!'
            if (range.StartsWith("!"))
            {
                if (range.Length == 1)
                {
                    return true; // Just '!' is valid
                }

                // Check if it's in format "!-letter"
                if (range.Length >= 3 && range[1] == '-')
                {
                    char endLetter = range[2];
                    return char.IsLetter(endLetter);
                }

                return false;
            }

            // Check if it's in format "letter-letter"
            if (range.Length >= 3 && range[1] == '-')
            {
                char startLetter = range[0];
                char endLetter = range[2];
                return char.IsLetter(startLetter) && char.IsLetter(endLetter);
            }

            // Single letter is valid
            if (range.Length == 1)
            {
                return char.IsLetter(range[0]);
            }

            return false;
        }

        /// <summary>
        /// Parses a language ID string to the corresponding enum value.
        /// </summary>
        /// <param name="languageValue">The language value to parse.</param>
        /// <returns>The parsed LanguageIdentifier.</returns>
        private static LanguageIdentifier ParseLanguageId(string languageValue)
        {
            if (string.IsNullOrEmpty(languageValue))
            {
                throw new ArgumentException("Language ID cannot be null or empty");
            }

            // Try to parse as LCID (numeric)
            if (int.TryParse(languageValue, out int lcid))
            {
                // Check if this numeric ID corresponds to a known LanguageIdentifier value
                foreach (LanguageIdentifier langId in Enum.GetValues<LanguageIdentifier>())
                {
                    if ((int)langId == lcid)
                    {
                        return langId;
                    }
                }
                throw new ArgumentException($"Unsupported LCID: {lcid}");
            }

            // Try to parse as enum name (e.g., "EnglishUS")
            if (
                Enum.TryParse<LanguageIdentifier>(
                    languageValue,
                    true,
                    out LanguageIdentifier parsedEnum
                )
            )
            {
                return parsedEnum;
            }

            // Try common culture name mappings
            return languageValue.ToLowerInvariant() switch
            {
                "en-us" or "english" => LanguageIdentifier.EnglishUS,
                "en-gb" or "en-uk" => LanguageIdentifier.EnglishUK,
                "en-ca" or "english-canada" => LanguageIdentifier.EnglishCanada,
                "en-au" or "english-australia" => LanguageIdentifier.EnglishAustralia,
                "fr-fr" or "french" => LanguageIdentifier.FrenchFrance,
                "fr-ca" or "french-canada" => LanguageIdentifier.FrenchCanada,
                "fr-be" or "french-belgium" => LanguageIdentifier.FrenchBelgium,
                "de-de" or "german" => LanguageIdentifier.GermanGermany,
                "de-at" or "german-austria" => LanguageIdentifier.GermanAustria,
                "de-ch" or "german-switzerland" => LanguageIdentifier.GermanSwitzerland,
                "es-es" or "spanish" => LanguageIdentifier.SpanishSpain,
                "es-mx" or "spanish-mexico" => LanguageIdentifier.SpanishMexico,
                "it-it" or "italian" => LanguageIdentifier.ItalianItaly,
                "pt-br" or "portuguese-brazil" => LanguageIdentifier.PortugueseBrazil,
                "pt-pt" or "portuguese-portugal" => LanguageIdentifier.PortuguesePortugal,
                "ja-jp" or "japanese" => LanguageIdentifier.Japanese,
                "zh-cn" or "chinese-simplified" => LanguageIdentifier.ChineseSimplified,
                "zh-tw" or "chinese-traditional" => LanguageIdentifier.ChineseTraditional,
                "ko-kr" or "korean" => LanguageIdentifier.Korean,
                "ru-ru" or "russian" => LanguageIdentifier.Russian,
                "ar-sa" or "arabic" => LanguageIdentifier.ArabicSaudiArabia,
                "hi-in" or "hindi" => LanguageIdentifier.Hindi,
                "th-th" or "thai" => LanguageIdentifier.Thai,
                "he-il" or "hebrew" => LanguageIdentifier.Hebrew,
                "tr-tr" or "turkish" => LanguageIdentifier.Turkish,
                "pl-pl" or "polish" => LanguageIdentifier.Polish,
                "cs-cz" or "czech" => LanguageIdentifier.Czech,
                "hu-hu" or "hungarian" => LanguageIdentifier.Hungarian,
                "sv-se" or "swedish" => LanguageIdentifier.Swedish,
                "nb-no" or "norwegian" => LanguageIdentifier.NorwegianBokmal,
                "fi-fi" or "finnish" => LanguageIdentifier.Finnish,
                "da-dk" or "danish" => LanguageIdentifier.Danish,
                _ => throw new ArgumentException($"Unsupported language: {languageValue}"),
            };
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToString()
        {
            List<string> result = new List<string> { "INDEX" };

            if (!string.IsNullOrEmpty(BookmarkName))
            {
                result.Add($"\\b \"{BookmarkName}\"");
            }

            if (NumberOfColumns.HasValue)
            {
                result.Add($"\\c \"{NumberOfColumns.Value}\"");
            }

            if (!string.IsNullOrEmpty(SequencePageSeparator))
            {
                result.Add($"\\d \"{SequencePageSeparator}\"");
            }

            if (!string.IsNullOrEmpty(EntryPageSeparator))
            {
                result.Add($"\\e \"{EntryPageSeparator}\"");
            }

            if (!string.IsNullOrEmpty(EntryTypeFilter))
            {
                result.Add($"\\f \"{EntryTypeFilter}\"");
            }

            if (!string.IsNullOrEmpty(PageRangeSeparator))
            {
                result.Add($"\\g \"{PageRangeSeparator}\"");
            }

            if (!string.IsNullOrEmpty(IndexHeadingText))
            {
                result.Add($"\\h \"{IndexHeadingText}\"");
            }

            if (!string.IsNullOrEmpty(CrossReferenceSeparator))
            {
                result.Add($"\\k \"{CrossReferenceSeparator}\"");
            }

            if (!string.IsNullOrEmpty(PageNumberSeparator))
            {
                result.Add($"\\l \"{PageNumberSeparator}\"");
            }

            if (!string.IsNullOrEmpty(LetterRange))
            {
                result.Add($"\\p \"{LetterRange}\"");
            }

            if (UseRunInFormat)
            {
                result.Add("\\r");
            }

            if (!string.IsNullOrEmpty(SequenceName))
            {
                result.Add($"\\s \"{SequenceName}\"");
            }

            if (EnableYomiText)
            {
                result.Add("\\y");
            }

            if (LanguageId.HasValue)
            {
                result.Add($"\\z \"{(int)LanguageId.Value}\"");
            }

            return string.Join(" ", result);
        }
    }
}

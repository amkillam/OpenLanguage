using System;
using System.Collections.Generic;
using System.Text;

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

    /// <summary>
    /// Represents a parsed address block template with merge field placeholders.
    /// </summary>
    public class AddressBlockTemplate
    {
        /// <summary>
        /// The raw template text.
        /// </summary>
        public string RawTemplate { get; set; } = string.Empty;

        /// <summary>
        /// The parsed merge field placeholders found in the template.
        /// </summary>
        public List<MergeFieldPlaceholder> Placeholders { get; set; } =
            new List<MergeFieldPlaceholder>();

        /// <summary>
        /// The template text with placeholders replaced by format specifiers.
        /// </summary>
        public string ProcessedTemplate { get; set; } = string.Empty;
    }

    /// <summary>
    /// Lexer states for parsing merge field placeholders.
    /// </summary>
    internal enum MergeFieldLexerState
    {
        /// <summary>
        /// Looking for the start of a merge field (« character).
        /// </summary>
        SearchingForStart,

        /// <summary>
        /// Inside a merge field, parsing the field name.
        /// </summary>
        ParsingFieldName,

        /// <summary>
        /// Inside a merge field, parsing a formatting switch after backslash.
        /// </summary>
        ParsingFormattingSwitch,

        /// <summary>
        /// Looking for the end of a merge field (» character).
        /// </summary>
        SearchingForEnd,
    }

    /// <summary>
    /// Lexer for parsing merge field placeholders and mail merge templates using character-by-character state machine parsing.
    /// </summary>
    public static class MergeFieldLexer
    {
        /// <summary>
        /// Parses a merge field placeholder string using character-by-character state machine parsing.
        /// </summary>
        /// <param name="placeholderText">The placeholder text to parse (e.g., "«FirstName»").</param>
        /// <returns>A parsed MergeFieldPlaceholder object.</returns>
        public static MergeFieldPlaceholder ParseMergeField(string? placeholderText)
        {
            if (string.IsNullOrEmpty(placeholderText))
            {
                return new MergeFieldPlaceholder { RawText = placeholderText ?? string.Empty };
            }

            MergeFieldPlaceholder placeholder = new MergeFieldPlaceholder
            {
                RawText = placeholderText,
            };

            MergeFieldLexerState state = MergeFieldLexerState.SearchingForStart;
            bool foundStart = false;
            bool foundEnd = false;
            StringBuilder fieldNameBuilder = new StringBuilder();
            StringBuilder formattingSwitchBuilder = new StringBuilder();

            for (int i = 0; i < placeholderText.Length; i++)
            {
                char currentChar = placeholderText[i];

                switch (state)
                {
                    case MergeFieldLexerState.SearchingForStart:
                        if (currentChar == '«')
                        {
                            foundStart = true;
                            state = MergeFieldLexerState.ParsingFieldName;
                        }
                        break;

                    case MergeFieldLexerState.ParsingFieldName:
                        if (currentChar == '\\')
                        {
                            state = MergeFieldLexerState.ParsingFormattingSwitch;
                            formattingSwitchBuilder.Append(currentChar);
                        }
                        else if (currentChar == '»')
                        {
                            foundEnd = true;
                            state = MergeFieldLexerState.SearchingForEnd;
                            break;
                        }
                        else if (!char.IsWhiteSpace(currentChar) || fieldNameBuilder.Length > 0)
                        {
                            fieldNameBuilder.Append(currentChar);
                        }
                        break;

                    case MergeFieldLexerState.ParsingFormattingSwitch:
                        if (currentChar == '»')
                        {
                            foundEnd = true;
                            state = MergeFieldLexerState.SearchingForEnd;
                            break;
                        }
                        else
                        {
                            formattingSwitchBuilder.Append(currentChar);
                        }
                        break;

                    case MergeFieldLexerState.SearchingForEnd:
                        // Already found the end, ignore remaining characters
                        break;
                }
            }

            // Clean up field name (trim whitespace)
            string fieldName = fieldNameBuilder.ToString().Trim();

            // A valid merge field must have both opening and closing guillemets.
            if (!foundStart || !foundEnd)
            {
                placeholder.FieldName = string.Empty;
                placeholder.FormattingSwitch = null;
                return placeholder;
            }

            placeholder.FieldName = fieldName;

            // Set formatting switch if present
            string formattingSwitch = formattingSwitchBuilder.ToString().Trim();
            if (!string.IsNullOrEmpty(formattingSwitch))
            {
                placeholder.FormattingSwitch = formattingSwitch;
            }

            return placeholder;
        }

        /// <summary>
        /// Parses an address block template containing merge field placeholders using character-by-character state machine parsing.
        /// </summary>
        /// <param name="templateText">The template text to parse.</param>
        /// <returns>A parsed AddressBlockTemplate object.</returns>
        public static AddressBlockTemplate ParseAddressBlockTemplate(string? templateText)
        {
            if (string.IsNullOrEmpty(templateText))
            {
                return new AddressBlockTemplate { RawTemplate = templateText ?? string.Empty };
            }

            AddressBlockTemplate template = new AddressBlockTemplate { RawTemplate = templateText };
            StringBuilder processedTextBuilder = new StringBuilder();

            List<MergeFieldPlaceholder> placeholders = ExtractMergeFieldPlaceholders(templateText);
            template.Placeholders = placeholders;

            // Process the template text, replacing merge fields with format specifiers
            int currentPosition = 0;
            int placeholderIndex = 0;

            while (currentPosition < templateText.Length)
            {
                bool foundMergeField = false;

                // Check if we're at the start of a merge field
                if (templateText[currentPosition] == '«')
                {
                    // Find the end of this merge field
                    int endPosition = FindMergeFieldEnd(templateText, currentPosition);
                    if (endPosition != -1)
                    {
                        // Replace with format specifier
                        processedTextBuilder.Append("{" + $"{placeholderIndex}" + "}");
                        placeholderIndex++;
                        currentPosition = endPosition + 1;
                        foundMergeField = true;
                    }
                }

                if (!foundMergeField)
                {
                    processedTextBuilder.Append(templateText[currentPosition]);
                    currentPosition++;
                }
            }

            template.ProcessedTemplate = processedTextBuilder.ToString();
            return template;
        }

        /// <summary>
        /// Extracts all merge field placeholders from text using character-by-character state machine parsing.
        /// </summary>
        /// <param name="text">The text to search for merge fields.</param>
        /// <returns>A list of merge field placeholders found in the text.</returns>
        private static List<MergeFieldPlaceholder> ExtractMergeFieldPlaceholders(string? text)
        {
            List<MergeFieldPlaceholder> placeholders = new List<MergeFieldPlaceholder>();

            if (string.IsNullOrEmpty(text))
            {
                return placeholders;
            }

            int position = 0;
            while (position < text.Length)
            {
                if (text[position] == '«')
                {
                    int endPosition = FindMergeFieldEnd(text, position);
                    if (endPosition != -1)
                    {
                        string mergeFieldText = text.Substring(
                            position,
                            endPosition - position + 1
                        );
                        MergeFieldPlaceholder placeholder = ParseMergeField(mergeFieldText);
                        placeholders.Add(placeholder);
                        position = endPosition + 1;
                    }
                    else
                    {
                        position++;
                    }
                }
                else
                {
                    position++;
                }
            }

            return placeholders;
        }

        /// <summary>
        /// Finds the end position of a merge field starting at the given position using character-by-character parsing.
        /// </summary>
        /// <param name="text">The text to search in.</param>
        /// <param name="startPosition">The position of the opening « character.</param>
        /// <returns>The position of the closing » character, or -1 if not found.</returns>
        private static int FindMergeFieldEnd(string text, int startPosition)
        {
            if (startPosition >= text.Length || text[startPosition] != '«')
            {
                return -1;
            }

            for (int i = startPosition + 1; i < text.Length; i++)
            {
                if (text[i] == '»')
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Extracts all merge field names from a text string using character-by-character parsing.
        /// </summary>
        /// <param name="text">The text to search for merge fields.</param>
        /// <returns>A list of unique merge field names found in the text.</returns>
        public static List<string> ExtractMergeFieldNames(string text)
        {
            List<string> fieldNames = new List<string>();

            if (string.IsNullOrEmpty(text))
            {
                return fieldNames;
            }

            List<MergeFieldPlaceholder> placeholders = ExtractMergeFieldPlaceholders(text);
            foreach (MergeFieldPlaceholder placeholder in placeholders)
            {
                if (
                    !string.IsNullOrEmpty(placeholder.FieldName)
                    && !fieldNames.Contains(placeholder.FieldName)
                )
                {
                    fieldNames.Add(placeholder.FieldName);
                }
            }

            return fieldNames;
        }

        /// <summary>
        /// Validates whether a string contains valid merge field syntax using character-by-character parsing.
        /// </summary>
        /// <param name="text">The text to validate.</param>
        /// <returns>True if the text contains valid merge field placeholders.</returns>
        public static bool ContainsValidMergeFields(string? text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            List<MergeFieldPlaceholder> placeholders = ExtractMergeFieldPlaceholders(text);
            foreach (MergeFieldPlaceholder placeholder in placeholders)
            {
                if (!string.IsNullOrEmpty(placeholder.FieldName))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Formats a merge field name with the standard merge field delimiters.
        /// </summary>
        /// <param name="fieldName">The field name to format.</param>
        /// <returns>The formatted merge field placeholder.</returns>
        public static string FormatMergeField(string? fieldName)
        {
            if (string.IsNullOrEmpty(fieldName))
            {
                return string.Empty;
            }

            return $"«{fieldName}»";
        }

        /// <summary>
        /// Formats a merge field name with a formatting switch.
        /// </summary>
        /// <param name="fieldName">The field name to format.</param>
        /// <param name="formattingSwitch">The formatting switch to apply.</param>
        /// <returns>The formatted merge field placeholder with switch.</returns>
        public static string FormatMergeFieldWithSwitch(string? fieldName, string? formattingSwitch)
        {
            if (string.IsNullOrEmpty(fieldName))
            {
                return string.Empty;
            }

            if (string.IsNullOrEmpty(formattingSwitch))
            {
                return FormatMergeField(fieldName);
            }

            return $"«{fieldName}\\{formattingSwitch}»";
        }

        /// <summary>
        /// Parses a language ID using the comprehensive LanguageIdentifier enum.
        /// </summary>
        /// <param name="languageIdText">The language ID text to parse.</param>
        /// <returns>The parsed LanguageIdentifier, or null if invalid.</returns>
        public static LanguageIdentifier? ParseLanguageId(string? languageIdText)
        {
            if (string.IsNullOrWhiteSpace(languageIdText))
            {
                return null;
            }

            string trimmedText = languageIdText.Trim();

            // Try to parse as integer first (LCID)
            if (int.TryParse(trimmedText, out int numericId))
            {
                // Check if this numeric ID corresponds to a known LanguageIdentifier value
                foreach (LanguageIdentifier langId in Enum.GetValues<LanguageIdentifier>())
                {
                    if ((int)langId == numericId)
                    {
                        return langId;
                    }
                }
                return null;
            }

            // Try to parse as enum name (e.g., "EnglishUS")
            if (
                Enum.TryParse<LanguageIdentifier>(
                    trimmedText,
                    true,
                    out LanguageIdentifier parsedEnum
                )
            )
            {
                return parsedEnum;
            }

            // Try common culture name mappings
            LanguageIdentifier? mappedLanguage = MapCultureNameToLanguageIdentifier(trimmedText);
            if (mappedLanguage.HasValue)
            {
                return mappedLanguage.Value;
            }

            return null;
        }

        private static readonly Dictionary<string, LanguageIdentifier> _cultureMap = new Dictionary<
            string,
            LanguageIdentifier
        >(StringComparer.OrdinalIgnoreCase)
        {
            { "en-US", LanguageIdentifier.EnglishUS },
            { "en-GB", LanguageIdentifier.EnglishUK },
            { "en-AU", LanguageIdentifier.EnglishAustralia },
            { "fr-FR", LanguageIdentifier.FrenchFrance },
            { "de-DE", LanguageIdentifier.GermanGermany },
            { "es-ES", LanguageIdentifier.SpanishSpain },
            { "it-IT", LanguageIdentifier.ItalianItaly },
            { "pt-BR", LanguageIdentifier.PortugueseBrazil },
            { "ja-JP", LanguageIdentifier.Japanese },
            { "ko-KR", LanguageIdentifier.Korean },
            { "zh-CN", LanguageIdentifier.ChineseSimplified },
            { "zh-TW", LanguageIdentifier.ChineseTraditional },
            { "en-CA", LanguageIdentifier.EnglishCanada },
            { "fr-CA", LanguageIdentifier.FrenchCanada },
            { "es-MX", LanguageIdentifier.SpanishMexico },
            { "ru-RU", LanguageIdentifier.Russian },
            { "ar-SA", LanguageIdentifier.ArabicSaudiArabia },
            { "hi-IN", LanguageIdentifier.Hindi },
            { "th-TH", LanguageIdentifier.Thai },
            { "vi-VN", LanguageIdentifier.Vietnamese },
            { "tr-TR", LanguageIdentifier.Turkish },
            { "pl-PL", LanguageIdentifier.Polish },
            { "nl-NL", LanguageIdentifier.DutchNetherlands },
            { "sv-SE", LanguageIdentifier.Swedish },
            { "da-DK", LanguageIdentifier.Danish },
            { "no-NO", LanguageIdentifier.NorwegianBokmal },
            { "fi-FI", LanguageIdentifier.Finnish },
            { "el-GR", LanguageIdentifier.Greek },
            { "he-IL", LanguageIdentifier.Hebrew },
            { "cs-CZ", LanguageIdentifier.Czech },
            { "hu-HU", LanguageIdentifier.Hungarian },
            { "sk-SK", LanguageIdentifier.Slovak },
            { "sl-SI", LanguageIdentifier.Slovenian },
            { "et-EE", LanguageIdentifier.Estonian },
            { "lv-LV", LanguageIdentifier.Latvian },
            { "lt-LT", LanguageIdentifier.Lithuanian },
            { "bg-BG", LanguageIdentifier.Bulgarian },
            { "hr-HR", LanguageIdentifier.Croatian },
            { "ro-RO", LanguageIdentifier.Romanian },
            { "uk-UA", LanguageIdentifier.Ukrainian },
            { "ar", LanguageIdentifier.ArabicSaudiArabia },
            { "ja", LanguageIdentifier.Japanese },
            { "ko", LanguageIdentifier.Korean },
            { "ru", LanguageIdentifier.Russian },
        };

        /// <summary>
        /// Maps common culture names to LanguageIdentifier enum values.
        /// </summary>
        /// <param name="cultureName">The culture name to map (e.g., "en-US").</param>
        /// <returns>The corresponding LanguageIdentifier, or null if not found.</returns>
        private static LanguageIdentifier? MapCultureNameToLanguageIdentifier(string? cultureName)
        {
            if (!string.IsNullOrWhiteSpace(cultureName))
            {
                if (_cultureMap.TryGetValue(cultureName.Trim(), out LanguageIdentifier mappedId))
                {
                    return mappedId;
                }
            }

            return null;
        }

        /// <summary>
        /// Parses a merge field placeholder string (alias for ParseMergeField).
        /// </summary>
        /// <param name="placeholderText">The placeholder text to parse.</param>
        /// <returns>A parsed MergeFieldPlaceholder object.</returns>
        public static MergeFieldPlaceholder Parse(string placeholderText)
        {
            return ParseMergeField(placeholderText);
        }

        /// <summary>
        /// Reconstructs a merge field placeholder from a MergeFieldPlaceholder object.
        /// </summary>
        /// <param name="placeholder">The placeholder object to reconstruct.</param>
        /// <returns>The reconstructed placeholder text.</returns>
        public static string Reconstruct(MergeFieldPlaceholder placeholder)
        {
            if (placeholder == null || string.IsNullOrEmpty(placeholder.FieldName))
            {
                return string.Empty;
            }

            StringBuilder result = new StringBuilder();
            result.Append("«");
            result.Append(placeholder.FieldName);

            if (!string.IsNullOrEmpty(placeholder.FormattingSwitch))
            {
                result.Append(" ");
                result.Append(placeholder.FormattingSwitch);
            }

            result.Append("»");
            return result.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Typed
{
    /// <summary>
    /// Represents a strongly-typed BIBLIOGRAPHY field instruction.
    /// Retrieves and displays the contents of the document's Bibliography part in the bibliographic style specified.
    /// </summary>
    public class BibliographyFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// Switch: \l field-argument
        /// Specifies the locale used to format bibliographic sources that do not specify a locale.
        /// </summary>
        public LanguageIdentifier? FormattingLanguageId { get; set; }

        /// <summary>
        /// Switch: \f field-argument
        /// Specifies the locale used to filter bibliographic data to only sources matching this LCID.
        /// </summary>
        public LanguageIdentifier? FilterLanguageId { get; set; }

        /// <summary>
        /// Switch: \m field-argument
        /// Specifies that only the source with a Tag element value matching this argument shall be displayed.
        /// </summary>
        public string? SourceTagFilter { get; set; }

        /// <summary>
        /// Initializes a new instance of the BibliographyFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public BibliographyFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "BIBLIOGRAPHY")
            {
                throw new ArgumentException(
                    $"Expected BIBLIOGRAPHY field, but got {Source.Instruction}"
                );
            }

            // BIBLIOGRAPHY has no field arguments, only switches
            List<FieldArgument> nonSwitchArgs = Source
                .Arguments.Where(arg => arg.Type != FieldArgumentType.Switch)
                .ToList();

            if (nonSwitchArgs.Count > 0)
            {
                throw new ArgumentException("BIBLIOGRAPHY field takes no arguments, only switches");
            }

            // Parse switches
            for (int i = 0; i < Source.Arguments.Count; i++)
            {
                FieldArgument arg = Source.Arguments[i];
                if (arg.Type == FieldArgumentType.Switch)
                {
                    string switchValue = arg.Value?.ToString() ?? string.Empty;
                    switch (switchValue.ToLowerInvariant())
                    {
                        case "l":
                            if (i + 1 < Source.Arguments.Count)
                            {
                                FieldArgument nextArg = Source.Arguments[i + 1];
                                if (nextArg.Type != FieldArgumentType.Switch)
                                {
                                    string languageValue =
                                        nextArg.Value?.ToString() ?? string.Empty;
                                    FormattingLanguageId = ParseLanguageId(languageValue);
                                    i++; // Skip consumed argument
                                }
                            }
                            break;
                        case "f":
                            if (i + 1 < Source.Arguments.Count)
                            {
                                FieldArgument nextArg = Source.Arguments[i + 1];
                                if (nextArg.Type != FieldArgumentType.Switch)
                                {
                                    string languageValue =
                                        nextArg.Value?.ToString() ?? string.Empty;
                                    FilterLanguageId = ParseLanguageId(languageValue);
                                    i++; // Skip consumed argument
                                }
                            }
                            break;
                        case "m":
                            if (i + 1 < Source.Arguments.Count)
                            {
                                FieldArgument nextArg = Source.Arguments[i + 1];
                                if (nextArg.Type != FieldArgumentType.Switch)
                                {
                                    SourceTagFilter = nextArg.Value?.ToString() ?? string.Empty;
                                    i++; // Skip consumed argument
                                }
                            }
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Parses a language ID string to the corresponding enum value.
        /// </summary>
        /// <param name="languageValue">The language value to parse.</param>
        /// <returns>The parsed LanguageIdentifier.</returns>
        private LanguageIdentifier ParseLanguageId(string languageValue)
        {
            if (string.IsNullOrEmpty(languageValue))
            {
                return LanguageIdentifier.EnglishUS;
            }

            // Try to parse as LCID (numeric)
            if (int.TryParse(languageValue, out int lcid))
            {
                if (Enum.IsDefined(typeof(LanguageIdentifier), lcid))
                {
                    return (LanguageIdentifier)lcid;
                }
                throw new ArgumentException($"Unsupported LCID: {lcid}");
            }

            // Try to parse as culture name
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
                "es-us" or "spanish-us" => LanguageIdentifier.SpanishUS,
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
            List<string> result = new List<string> { "BIBLIOGRAPHY" };

            // Add switches
            if (FormattingLanguageId.HasValue)
            {
                result.Add("\\l");
                result.Add(((int)FormattingLanguageId.Value).ToString());
            }

            if (FilterLanguageId.HasValue)
            {
                result.Add("\\f");
                result.Add(((int)FilterLanguageId.Value).ToString());
            }

            if (!string.IsNullOrEmpty(SourceTagFilter))
            {
                result.Add("\\m");
                result.Add(
                    SourceTagFilter.Contains(" ") ? $"\"{SourceTagFilter}\"" : SourceTagFilter
                );
            }

            return string.Join(" ", result);
        }
    }
}

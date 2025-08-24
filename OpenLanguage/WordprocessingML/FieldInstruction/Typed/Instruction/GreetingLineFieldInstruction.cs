using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Typed
{
    /// <summary>
    /// Represents a strongly-typed GREETINGLINE field instruction.
    /// Inserts a mail merge greeting line.
    /// </summary>
    public class GreetingLineFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// Switch: \c field-argument
        /// Specifies the text to include in the merge field if the name field in the data source is blank.
        /// </summary>
        public string? BlankNameText { get; set; }

        /// <summary>
        /// Switch: \f field-argument
        /// Specifies the format of the name included in the field.
        /// </summary>
        public NameFormat? Format { get; set; }

        /// <summary>
        /// Switch: \l field-argument
        /// Specifies the language ID used to format the name. Defaults to the language ID of the first character of the document.
        /// </summary>
        public LanguageIdentifier? LanguageId { get; set; }

        /// <summary>
        /// Initializes a new instance of the GreetingLineFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public GreetingLineFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "GREETINGLINE")
            {
                throw new ArgumentException(
                    $"Expected GREETINGLINE field, but got {Source.Instruction}"
                );
            }

            // GREETINGLINE has no field arguments, only switches
            List<FieldArgument> nonSwitchArgs = Source
                .Arguments.Where(arg => arg.Type != FieldArgumentType.Switch)
                .ToList();

            if (nonSwitchArgs.Count > 0)
            {
                throw new ArgumentException("GREETINGLINE field takes no arguments, only switches");
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
                        case "c":
                            if (i + 1 < Source.Arguments.Count)
                            {
                                FieldArgument nextArg = Source.Arguments[i + 1];
                                if (nextArg.Type != FieldArgumentType.Switch)
                                {
                                    BlankNameText = nextArg.Value?.ToString() ?? string.Empty;
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
                                    string formatValue = nextArg.Value?.ToString() ?? string.Empty;
                                    Format = ParseNameFormat(formatValue);
                                    i++; // Skip consumed argument
                                }
                            }
                            break;
                        case "l":
                            if (i + 1 < Source.Arguments.Count)
                            {
                                FieldArgument nextArg = Source.Arguments[i + 1];
                                if (nextArg.Type != FieldArgumentType.Switch)
                                {
                                    string languageValue =
                                        nextArg.Value?.ToString() ?? string.Empty;
                                    LanguageId = ParseLanguageId(languageValue);
                                    i++; // Skip consumed argument
                                }
                            }
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Parses a name format string to the corresponding enum value.
        /// </summary>
        /// <param name="formatValue">The format value to parse.</param>
        /// <returns>The parsed NameFormat.</returns>
        private NameFormat ParseNameFormat(string formatValue)
        {
            if (string.IsNullOrEmpty(formatValue))
            {
                return NameFormat.FirstName;
            }

            return formatValue.ToLowerInvariant() switch
            {
                "firstname" or "first" => NameFormat.FirstName,
                "lastname" or "last" => NameFormat.LastName,
                "firstlast" or "firstlastname" => NameFormat.FirstLastName,
                "lastfirst" or "lastfirstname" => NameFormat.LastFirstName,
                "titlelast" or "titlelastname" => NameFormat.TitleLastName,
                "fullformal" or "full" => NameFormat.FullFormalName,
                _ => throw new ArgumentException($"Invalid name format: {formatValue}"),
            };
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
            List<string> result = new List<string> { "GREETINGLINE" };

            // Add switches
            if (!string.IsNullOrEmpty(BlankNameText))
            {
                result.Add("\\c");
                result.Add(BlankNameText.Contains(" ") ? $"\"{BlankNameText}\"" : BlankNameText);
            }

            if (Format.HasValue)
            {
                result.Add("\\f");
                string formatValue = Format.Value switch
                {
                    NameFormat.FirstName => "FirstName",
                    NameFormat.LastName => "LastName",
                    NameFormat.FirstLastName => "FirstLastName",
                    NameFormat.LastFirstName => "LastFirstName",
                    NameFormat.TitleLastName => "TitleLastName",
                    NameFormat.FullFormalName => "FullFormalName",
                    _ => "FirstName",
                };
                result.Add(formatValue);
            }

            if (LanguageId.HasValue)
            {
                result.Add("\\l");
                result.Add(((int)LanguageId.Value).ToString());
            }

            return string.Join(" ", result);
        }
    }
}

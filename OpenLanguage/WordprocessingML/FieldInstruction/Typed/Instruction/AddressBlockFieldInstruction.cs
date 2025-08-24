using System;
using System.Collections.Generic;
using OpenLanguage.WordprocessingML.MergeField;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Typed
{
    /// <summary>
    /// Represents a strongly-typed ADDRESSBLOCK field instruction.
    /// The ADDRESSBLOCK field inserts a mail merge address block.
    /// </summary>
    public class AddressBlockFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// Switch: \c field-argument
        /// Specifies whether to include the country/region in the address block.
        /// </summary>
        public CountryRegionInclusion? CountryRegionInclusionSetting { get; set; }

        /// <summary>
        /// Gets or sets whether the address should be formatted according to the recipient's country/region.
        /// If false or null, addresses are formatted according to implementation-specific preference.
        /// </summary>
        public bool FormatByRecipientCountry { get; set; }

        /// <summary>
        /// Gets the list of countries/regions to exclude from the address block.
        /// Multiple exclusions are supported.
        /// </summary>
        public List<string> ExcludedCountriesRegions { get; }

        /// <summary>
        /// Switch: \f field-argument
        /// Name and address format template using merge-field placeholders.
        /// </summary>
        public List<MergeFieldPlaceholder>? FormatTemplate { get; set; }

        /// <summary>
        /// Gets or sets the language ID used to format the address.
        /// If null, uses the language ID of the first character of the document.
        /// </summary>
        public LanguageIdentifier? LanguageId { get; set; }

        public AddressBlockFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ExcludedCountriesRegions = new List<string>();
            ParseArguments(source.Arguments);
        }

        /// <summary>
        /// Creates a new ADDRESSBLOCK field instruction with default values.
        /// </summary>
        public AddressBlockFieldInstruction()
            : base(new FieldInstruction("ADDRESSBLOCK"))
        {
            ExcludedCountriesRegions = new List<string>();
        }

        private void ParseArguments(List<FieldArgument> arguments)
        {
            foreach (FieldArgument arg in arguments)
            {
                if (arg.Type == FieldArgumentType.Switch)
                {
                    string switchValue = arg.Value?.ToString() ?? string.Empty;
                    if (string.IsNullOrEmpty(switchValue) || switchValue.Length < 2)
                        continue;

                    string switchChar = switchValue.Substring(1).ToLowerInvariant();

                    switch (switchChar)
                    {
                        case "c":
                            // \c field-argument - Country/region inclusion
                            FieldArgument? cArg = GetNextArgumentAfter(arguments, arg);
                            if (
                                cArg != null
                                && int.TryParse(cArg.Value?.ToString(), out int cValue)
                            )
                            {
                                if (cValue >= 0 && cValue <= 2)
                                {
                                    CountryRegionInclusionSetting = (CountryRegionInclusion)cValue;
                                }
                            }
                            break;

                        case "d":
                            // \d - Format according to recipient's country/region
                            FormatByRecipientCountry = true;
                            break;

                        case "e":
                            // \e field-argument - Country/region to exclude
                            FieldArgument? eArg = GetNextArgumentAfter(arguments, arg);
                            if (eArg != null)
                            {
                                string excludeValue = eArg.Value?.ToString() ?? string.Empty;
                                if (!string.IsNullOrWhiteSpace(excludeValue))
                                {
                                    ExcludedCountriesRegions.Add(excludeValue);
                                }
                            }
                            break;

                        case "f":
                            // \f field-argument - Name and address format template
                            FieldArgument? fArg = GetNextArgumentAfter(arguments, arg);
                            if (fArg != null)
                            {
                                string templateText = fArg.Value?.ToString() ?? string.Empty;
                                MergeFieldPlaceholder placeholder = MergeFieldLexer.Parse(
                                    templateText
                                );
                                FormatTemplate = new List<MergeFieldPlaceholder> { placeholder };
                            }
                            break;

                        case "l":
                            // \l field-argument - Language ID
                            FieldArgument? lArg = GetNextArgumentAfter(arguments, arg);
                            if (lArg != null)
                            {
                                string languageValue = lArg.Value?.ToString() ?? string.Empty;
                                LanguageId = ParseLanguageId(languageValue);
                            }
                            break;
                    }
                }
            }
        }

        private FieldArgument? GetNextArgumentAfter(
            List<FieldArgument> arguments,
            FieldArgument switchArg
        )
        {
            int index = arguments.IndexOf(switchArg);
            if (index >= 0 && index + 1 < arguments.Count)
            {
                FieldArgument nextArg = arguments[index + 1];
                // Return the next argument if it's not another switch
                if (nextArg.Type != FieldArgumentType.Switch)
                {
                    return nextArg;
                }
            }
            return null;
        }

        /// <summary>
        /// Parses a language ID string to the corresponding enum value.
        /// </summary>
        /// <param name="languageValue">The language value to parse.</param>
        /// <returns>The parsed LanguageIdentifier.</returns>
        private LanguageIdentifier ParseLanguageId(string languageValue)
        {
            if (string.IsNullOrEmpty(languageValue))
                return LanguageIdentifier.EnglishUS;

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
        /// Rebuilds the field instruction arguments from the current property values.
        /// </summary>
        public void RebuildArguments()
        {
            Source.Arguments.Clear();

            // Add \c switch if specified
            if (CountryRegionInclusionSetting.HasValue)
            {
                Source.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\\c"));
                Source.Arguments.Add(
                    new FieldArgument(
                        FieldArgumentType.Identifier,
                        ((int)CountryRegionInclusionSetting.Value).ToString()
                    )
                );
            }

            // Add \d switch if specified
            if (FormatByRecipientCountry)
            {
                Source.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\\d"));
            }

            // Add \e switches for each excluded country/region
            foreach (string excluded in ExcludedCountriesRegions)
            {
                if (!string.IsNullOrWhiteSpace(excluded))
                {
                    Source.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\\e"));
                    Source.Arguments.Add(
                        new FieldArgument(FieldArgumentType.StringLiteral, excluded)
                    );
                }
            }

            // Add \f switch if specified
            if (FormatTemplate != null && FormatTemplate.Count > 0)
            {
                Source.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\\f"));
                string templateText = MergeFieldLexer.Reconstruct(FormatTemplate[0]);
                Source.Arguments.Add(
                    new FieldArgument(FieldArgumentType.StringLiteral, templateText)
                );
            }

            // Add \l switch if specified
            if (LanguageId.HasValue)
            {
                Source.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\\l"));
                Source.Arguments.Add(
                    new FieldArgument(
                        FieldArgumentType.Identifier,
                        ((int)LanguageId.Value).ToString()
                    )
                );
            }
        }

        /// <summary>
        /// Validates the current field instruction configuration.
        /// </summary>
        /// <returns>True if the configuration is valid, false otherwise.</returns>
        public bool IsValid()
        {
            // ADDRESSBLOCK field has no required arguments

            // Validate \c argument if present
            if (
                CountryRegionInclusionSetting.HasValue
                && !Enum.IsDefined(
                    typeof(CountryRegionInclusion),
                    CountryRegionInclusionSetting.Value
                )
            )
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Gets a string representation of the field instruction.
        /// </summary>
        /// <returns>The field instruction as a string.</returns>
        public override string ToString()
        {
            RebuildArguments();
            return Source.ToString();
        }
    }
}

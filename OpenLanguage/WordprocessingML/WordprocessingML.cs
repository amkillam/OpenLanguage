using System;

namespace OpenLanguage.WordprocessingML
{
    public static class LanguageIdentifierExtensions
    {
        /// <summary>
        /// Converts the LanguageIdentifier enum value to its corresponding LCID integer value.
        /// </summary>
        /// <param name="languageIdentifier">The LanguageIdentifier enum value.</param>
        /// <returns>The corresponding LCID integer value.</returns>
        public static int ToLcid(this LanguageIdentifier languageIdentifier) =>
            (int)languageIdentifier;

        /// <summary>
        /// Converts an LCID integer value to its corresponding LanguageIdentifier enum value.
        /// </summary>
        /// <param name="lcid">The LCID integer value.</param>
        /// <returns>The corresponding LanguageIdentifier enum value.</returns>
        /// <exception cref="ArgumentException">Thrown if the LCID does not correspond to any LanguageIdentifier.</exception>
        public static LanguageIdentifier FromLcid(int lcid)
        {
            if (Enum.IsDefined(typeof(LanguageIdentifier), lcid))
            {
                return (LanguageIdentifier)lcid;
            }
            throw new ArgumentException($"LCID {lcid} is not defined in LanguageIdentifier enum.");
        }

        // TryFromLcid
        /// <summary>
        /// Attempts to convert an LCID integer value to its corresponding LanguageIdentifier enum value.
        /// </summary>
        /// <param name="lcid">The LCID integer value.</param>
        /// <param name="languageIdentifier">The corresponding LanguageIdentifier enum value if conversion is successful; otherwise, default.</param>
        /// <returns>True if conversion is successful; otherwise, false.</returns>
        public static bool TryFromLcid(int lcid, out LanguageIdentifier? languageIdentifier)
        {
            if (Enum.IsDefined(typeof(LanguageIdentifier), lcid))
            {
                languageIdentifier = (LanguageIdentifier)lcid;
                return true;
            }
            languageIdentifier = null;
            return false;
        }

        // TryFromLcid
        /// <summary>
        /// Attempts to convert an LCID integer value to its corresponding LanguageIdentifier enum value.
        /// </summary>
        /// <param name="lcid">The LCID integer value.</param>
        /// <param name="languageIdentifier">The corresponding LanguageIdentifier enum value if conversion is successful; otherwise, default.</param>
        /// <returns>True if conversion is successful; otherwise, false.</returns>
        public static bool TryFromLcid(int lcid, out LanguageIdentifier languageIdentifier)
        {
            if (Enum.IsDefined(typeof(LanguageIdentifier), lcid))
            {
                languageIdentifier = (LanguageIdentifier)lcid;
                return true;
            }
            languageIdentifier = default;
            return false;
        }

        public static LanguageIdentifier? TryFromLcid(int lcid)
        {
            if (Enum.IsDefined(typeof(LanguageIdentifier), lcid))
            {
                return (LanguageIdentifier)lcid;
            }
            return null;
        }

        public static string ToString(this LanguageIdentifier languageIdentifier) =>
            languageIdentifier switch
            {
                LanguageIdentifier.EnglishUS => "en-US",
                LanguageIdentifier.EnglishUK => "en-GB",
                LanguageIdentifier.EnglishCanada => "en-CA",
                LanguageIdentifier.EnglishAustralia => "en-AU",
                LanguageIdentifier.EnglishNewZealand => "en-NZ",
                LanguageIdentifier.EnglishIreland => "en-IE",
                LanguageIdentifier.EnglishSouthAfrica => "en-ZA",
                LanguageIdentifier.EnglishJamaica => "en-JM",
                LanguageIdentifier.EnglishCaribbean => "en-029",
                LanguageIdentifier.EnglishBelize => "en-BZ",
                LanguageIdentifier.EnglishTrinidadTobago => "en-TT",
                LanguageIdentifier.EnglishZimbabwe => "en-ZW",
                LanguageIdentifier.EnglishPhilippines => "en-PH",
                LanguageIdentifier.EnglishIndia => "en-IN",
                LanguageIdentifier.EnglishMalaysia => "en-MY",
                LanguageIdentifier.EnglishSingapore => "en-SG",
                LanguageIdentifier.FrenchFrance => "fr-FR",
                LanguageIdentifier.FrenchBelgium => "fr-BE",
                LanguageIdentifier.FrenchCanada => "fr-CA",
                LanguageIdentifier.FrenchSwitzerland => "fr-CH",
                LanguageIdentifier.FrenchLuxembourg => "fr-LU",
                LanguageIdentifier.FrenchMonaco => "fr-MC",
                LanguageIdentifier.GermanGermany => "de-DE",
                LanguageIdentifier.GermanSwitzerland => "de-CH",
                LanguageIdentifier.GermanAustria => "de-AT",
                LanguageIdentifier.GermanLuxembourg => "de-LU",
                LanguageIdentifier.GermanLiechtenstein => "de-LI",
                LanguageIdentifier.SpanishSpain => "es-ES",
                LanguageIdentifier.SpanishMexico => "es-MX",
                LanguageIdentifier.SpanishGuatemala => "es-GT",
                LanguageIdentifier.SpanishCostaRica => "es-CR",
                LanguageIdentifier.SpanishPanama => "es-PA",
                LanguageIdentifier.SpanishDominicanRepublic => "es-DO",
                LanguageIdentifier.SpanishVenezuela => "es-VE",
                LanguageIdentifier.SpanishColombia => "es-CO",
                LanguageIdentifier.SpanishPeru => "es-PE",
                LanguageIdentifier.SpanishArgentina => "es-AR",
                LanguageIdentifier.SpanishEcuador => "es-EC",
                LanguageIdentifier.SpanishChile => "es-CL",
                LanguageIdentifier.SpanishUruguay => "es-UY",
                LanguageIdentifier.SpanishParaguay => "es-PY",
                LanguageIdentifier.SpanishBolivia => "es-BO",
                LanguageIdentifier.SpanishElSalvador => "es-SV",
                LanguageIdentifier.SpanishHonduras => "es-HN",
                LanguageIdentifier.SpanishNicaragua => "es-NI",
                LanguageIdentifier.SpanishPuertoRico => "es-PR",
                LanguageIdentifier.SpanishUS => "es-US",
                LanguageIdentifier.ItalianItaly => "it-IT",
                LanguageIdentifier.ItalianSwitzerland => "it-CH",
                LanguageIdentifier.PortugueseBrazil => "pt-BR",
                LanguageIdentifier.PortuguesePortugal => "pt-PT",
                LanguageIdentifier.Japanese => "ja-JP",
                LanguageIdentifier.ChineseSimplified => "zh-CN",
                LanguageIdentifier.ChineseTraditional => "zh-TW",
                LanguageIdentifier.ChineseSimplifiedSingapore => "zh-SG",
                LanguageIdentifier.ChineseTraditionalHongKong => "zh-HK",
                LanguageIdentifier.ChineseTraditionalMacao => "zh-MO",
                LanguageIdentifier.Korean => "ko-KR",
                LanguageIdentifier.DutchNetherlands => "nl-NL",
                LanguageIdentifier.DutchBelgium => "nl-BE",
                LanguageIdentifier.Russian => "ru-RU",
                LanguageIdentifier.ArabicSaudiArabia => "ar-SA",
                LanguageIdentifier.ArabicAlgeria => "ar-DZ",
                LanguageIdentifier.ArabicBahrain => "ar-BH",
                LanguageIdentifier.ArabicEgypt => "ar-EG",
                LanguageIdentifier.ArabicIraq => "ar-IQ",
                LanguageIdentifier.ArabicJordan => "ar-JO",
                LanguageIdentifier.ArabicKuwait => "ar-KW",
                LanguageIdentifier.ArabicLebanon => "ar-LB",
                LanguageIdentifier.ArabicLibya => "ar-LY",
                LanguageIdentifier.ArabicMorocco => "ar-MA",
                LanguageIdentifier.ArabicOman => "ar-OM",
                LanguageIdentifier.ArabicQatar => "ar-QA",
                LanguageIdentifier.ArabicSyria => "ar-SY",
                LanguageIdentifier.ArabicTunisia => "ar-TN",
                LanguageIdentifier.ArabicUAE => "ar-AE",
                LanguageIdentifier.ArabicYemen => "ar-YE",
                LanguageIdentifier.Hindi => "hi-IN",
                LanguageIdentifier.Thai => "th-TH",
                LanguageIdentifier.Hebrew => "he-IL",
                LanguageIdentifier.Turkish => "tr-TR",
                LanguageIdentifier.Polish => "pl-PL",
                LanguageIdentifier.Czech => "cs-CZ",
                LanguageIdentifier.Hungarian => "hu-HU",
                LanguageIdentifier.Swedish => "sv-SE",
                LanguageIdentifier.SwedishFinland => "sv-FI",
                LanguageIdentifier.NorwegianBokmal => "nb-NO",
                LanguageIdentifier.Finnish => "fi-FI",
                LanguageIdentifier.Danish => "da-DK",
                LanguageIdentifier.Vietnamese => "vi-VN",
                LanguageIdentifier.Bulgarian => "bg-BG",
                LanguageIdentifier.Croatian => "hr-HR",
                LanguageIdentifier.Estonian => "et-EE",
                LanguageIdentifier.Greek => "el-GR",
                LanguageIdentifier.Latvian => "lv-LV",
                LanguageIdentifier.Lithuanian => "lt-LT",
                LanguageIdentifier.Romanian => "ro-RO",
                LanguageIdentifier.Slovak => "sk-SK",
                LanguageIdentifier.Slovenian => "sl-SI",
                LanguageIdentifier.Ukrainian => "uk-UA",
                LanguageIdentifier.Afrikaans => "af-ZA",
                LanguageIdentifier.Albanian => "sq-AL",
                LanguageIdentifier.Amharic => "am-ET",
                LanguageIdentifier.Armenian => "hy-AM",
                LanguageIdentifier.Assamese => "as-IN",
                LanguageIdentifier.AzeriCyrillic => "az-Cyrl-AZ",
                LanguageIdentifier.AzeriLatin => "az-Latn-AZ",
                LanguageIdentifier.Basque => "eu-ES",
                LanguageIdentifier.Bengali => "bn-IN",
                LanguageIdentifier.Bosnian => "bs-Latn-BA",
                LanguageIdentifier.Catalan => "ca-ES",
                LanguageIdentifier.Farsi => "fa-IR",
                LanguageIdentifier.Filipino => "fil-PH",
                LanguageIdentifier.Galician => "gl-ES",
                LanguageIdentifier.Georgian => "ka-GE",
                LanguageIdentifier.Gujarati => "gu-IN",
                LanguageIdentifier.Hausa => "ha-Latn-NG",
                LanguageIdentifier.Icelandic => "is-IS",
                LanguageIdentifier.Igbo => "ig-NG",
                LanguageIdentifier.Indonesian => "id-ID",
                LanguageIdentifier.Irish => "ga-IE",
                LanguageIdentifier.Kannada => "kn-IN",
                LanguageIdentifier.Kashmiri => "ks-Arab-IN",
                LanguageIdentifier.Kazakh => "kk-KZ",
                LanguageIdentifier.Khmer => "km-KH",
                LanguageIdentifier.Konkani => "kok-IN",
                LanguageIdentifier.Kyrgyz => "ky-KG",
                LanguageIdentifier.Lao => "lo-LA",
                LanguageIdentifier.Macedonian => "mk-MK",
                LanguageIdentifier.Malay => "ms-MY",
                LanguageIdentifier.Malayalam => "ml-IN",
                LanguageIdentifier.Maltese => "mt-MT",
                LanguageIdentifier.Maori => "mi-NZ",
                LanguageIdentifier.Marathi => "mr-IN",
                LanguageIdentifier.Mongolian => "mn-MN",
                LanguageIdentifier.Nepali => "ne-NP",
                LanguageIdentifier.Oriya => "or-IN",
                LanguageIdentifier.Pashto => "ps-AF",
                LanguageIdentifier.Punjabi => "pa-IN",
                LanguageIdentifier.QuechuaBolivia => "qu-BO",
                LanguageIdentifier.QuechuaEcuador => "qu-EC",
                LanguageIdentifier.QuechuaPeru => "qu-PE",
                LanguageIdentifier.Sami => "se-NO",
                LanguageIdentifier.Sanskrit => "sa-IN",
                LanguageIdentifier.SerbianCyrillic => "sr-Cyrl-RS",
                LanguageIdentifier.SerbianLatin => "sr-Latn-RS",
                LanguageIdentifier.Sindhi => "sd-Arab-PK",
                LanguageIdentifier.Sinhala => "si-LK",
                LanguageIdentifier.Somali => "so-SO",
                LanguageIdentifier.Sotho => "nso-ZA",
                LanguageIdentifier.Swahili => "sw-KE",
                LanguageIdentifier.Syriac => "syr-SY",
                LanguageIdentifier.Tajik => "tg-Cyrl-TJ",
                LanguageIdentifier.Tamil => "ta-IN",
                LanguageIdentifier.Tatar => "tt-RU",
                LanguageIdentifier.Telugu => "te-IN",
                LanguageIdentifier.Tigrinya => "ti-ET",
                LanguageIdentifier.Tswana => "tn-ZA",
                LanguageIdentifier.Turkmen => "tk-TM",
                LanguageIdentifier.Urdu => "ur-PK",
                LanguageIdentifier.UzbekCyrillic => "uz-Cyrl-UZ",
                LanguageIdentifier.UzbekLatin => "uz-Latn-UZ",
                LanguageIdentifier.Welsh => "cy-GB",
                LanguageIdentifier.Xhosa => "xh-ZA",
                LanguageIdentifier.Yoruba => "yo-NG",
                LanguageIdentifier.Zulu => "zu-ZA",
                _ => "unknown",
            };

        public static string ToTag(this LanguageIdentifier languageIdentifier) =>
            languageIdentifier.ToString();

        public static LanguageIdentifier? TryFromTag(string langTag)
        {
            return langTag switch
            {
                "en-US" => LanguageIdentifier.EnglishUS,
                "en-GB" => LanguageIdentifier.EnglishUK,
                "en-CA" => LanguageIdentifier.EnglishCanada,
                "en-AU" => LanguageIdentifier.EnglishAustralia,
                "en-NZ" => LanguageIdentifier.EnglishNewZealand,
                "en-IE" => LanguageIdentifier.EnglishIreland,
                "en-ZA" => LanguageIdentifier.EnglishSouthAfrica,
                "en-JM" => LanguageIdentifier.EnglishJamaica,
                "en-029" => LanguageIdentifier.EnglishCaribbean,
                "en-BZ" => LanguageIdentifier.EnglishBelize,
                "en-TT" => LanguageIdentifier.EnglishTrinidadTobago,
                "en-ZW" => LanguageIdentifier.EnglishZimbabwe,
                "en-PH" => LanguageIdentifier.EnglishPhilippines,
                "en-IN" => LanguageIdentifier.EnglishIndia,
                "en-MY" => LanguageIdentifier.EnglishMalaysia,
                "en-SG" => LanguageIdentifier.EnglishSingapore,
                "fr-FR" => LanguageIdentifier.FrenchFrance,
                "fr-BE" => LanguageIdentifier.FrenchBelgium,
                "fr-CA" => LanguageIdentifier.FrenchCanada,
                "fr-CH" => LanguageIdentifier.FrenchSwitzerland,
                "fr-LU" => LanguageIdentifier.FrenchLuxembourg,
                "fr-MC" => LanguageIdentifier.FrenchMonaco,
                "de-DE" => LanguageIdentifier.GermanGermany,
                "de-CH" => LanguageIdentifier.GermanSwitzerland,
                "de-AT" => LanguageIdentifier.GermanAustria,
                "de-LU" => LanguageIdentifier.GermanLuxembourg,
                "de-LI" => LanguageIdentifier.GermanLiechtenstein,
                "es-ES" => LanguageIdentifier.SpanishSpain,
                "es-MX" => LanguageIdentifier.SpanishMexico,
                "es-GT" => LanguageIdentifier.SpanishGuatemala,
                "es-CR" => LanguageIdentifier.SpanishCostaRica,
                "es-PA" => LanguageIdentifier.SpanishPanama,
                "es-DO" => LanguageIdentifier.SpanishDominicanRepublic,
                "es-VE" => LanguageIdentifier.SpanishVenezuela,
                "es-CO" => LanguageIdentifier.SpanishColombia,
                "es-PE" => LanguageIdentifier.SpanishPeru,
                "es-AR" => LanguageIdentifier.SpanishArgentina,
                "es-EC" => LanguageIdentifier.SpanishEcuador,
                "es-CL" => LanguageIdentifier.SpanishChile,
                "es-UY" => LanguageIdentifier.SpanishUruguay,
                "es-PY" => LanguageIdentifier.SpanishParaguay,
                "es-BO" => LanguageIdentifier.SpanishBolivia,
                "es-SV" => LanguageIdentifier.SpanishElSalvador,
                "es-HN" => LanguageIdentifier.SpanishHonduras,
                "es-NI" => LanguageIdentifier.SpanishNicaragua,
                "es-PR" => LanguageIdentifier.SpanishPuertoRico,
                "es-US" => LanguageIdentifier.SpanishUS,
                "it-IT" => LanguageIdentifier.ItalianItaly,
                "it-CH" => LanguageIdentifier.ItalianSwitzerland,
                "pt-BR" => LanguageIdentifier.PortugueseBrazil,
                "pt-PT" => LanguageIdentifier.PortuguesePortugal,
                "ja-JP" => LanguageIdentifier.Japanese,
                "zh-CN" => LanguageIdentifier.ChineseSimplified,
                "zh-TW" => LanguageIdentifier.ChineseTraditional,
                "zh-SG" => LanguageIdentifier.ChineseSimplifiedSingapore,
                "zh-HK" => LanguageIdentifier.ChineseTraditionalHongKong,
                "zh-MO" => LanguageIdentifier.ChineseTraditionalMacao,
                "ko-KR" => LanguageIdentifier.Korean,
                "nl-NL" => LanguageIdentifier.DutchNetherlands,
                "nl-BE" => LanguageIdentifier.DutchBelgium,
                "ru-RU" => LanguageIdentifier.Russian,
                "ar-SA" => LanguageIdentifier.ArabicSaudiArabia,
                "ar-DZ" => LanguageIdentifier.ArabicAlgeria,
                "ar-BH" => LanguageIdentifier.ArabicBahrain,
                "ar-EG" => LanguageIdentifier.ArabicEgypt,
                "ar-IQ" => LanguageIdentifier.ArabicIraq,
                "ar-JO" => LanguageIdentifier.ArabicJordan,
                "ar-KW" => LanguageIdentifier.ArabicKuwait,
                "ar-LB" => LanguageIdentifier.ArabicLebanon,
                "ar-LY" => LanguageIdentifier.ArabicLibya,
                "ar-MA" => LanguageIdentifier.ArabicMorocco,
                "ar-OM" => LanguageIdentifier.ArabicOman,
                "ar-QA" => LanguageIdentifier.ArabicQatar,
                "ar-SY" => LanguageIdentifier.ArabicSyria,
                "ar-TN" => LanguageIdentifier.ArabicTunisia,
                "ar-AE" => LanguageIdentifier.ArabicUAE,
                "ar-YE" => LanguageIdentifier.ArabicYemen,
                "hi-IN" => LanguageIdentifier.Hindi,
                "th-TH" => LanguageIdentifier.Thai,
                "he-IL" => LanguageIdentifier.Hebrew,
                "tr-TR" => LanguageIdentifier.Turkish,
                "pl-PL" => LanguageIdentifier.Polish,
                "cs-CZ" => LanguageIdentifier.Czech,
                "hu-HU" => LanguageIdentifier.Hungarian,
                "sv-SE" => LanguageIdentifier.Swedish,
                "sv-FI" => LanguageIdentifier.SwedishFinland,
                "nb-NO" => LanguageIdentifier.NorwegianBokmal,
                "fi-FI" => LanguageIdentifier.Finnish,
                "da-DK" => LanguageIdentifier.Danish,
                "vi-VN" => LanguageIdentifier.Vietnamese,
                "bg-BG" => LanguageIdentifier.Bulgarian,
                "hr-HR" => LanguageIdentifier.Croatian,
                "et-EE" => LanguageIdentifier.Estonian,
                "el-GR" => LanguageIdentifier.Greek,
                "lv-LV" => LanguageIdentifier.Latvian,
                "lt-LT" => LanguageIdentifier.Lithuanian,
                "ro-RO" => LanguageIdentifier.Romanian,
                "sk-SK" => LanguageIdentifier.Slovak,
                "sl-SI" => LanguageIdentifier.Slovenian,
                "uk-UA" => LanguageIdentifier.Ukrainian,
                "af-ZA" => LanguageIdentifier.Afrikaans,
                "sq-AL" => LanguageIdentifier.Albanian,
                "am-ET" => LanguageIdentifier.Amharic,
                "hy-AM" => LanguageIdentifier.Armenian,
                "as-IN" => LanguageIdentifier.Assamese,
                "az-Cyrl-AZ" => LanguageIdentifier.AzeriCyrillic,
                "az-Latn-AZ" => LanguageIdentifier.AzeriLatin,
                "eu-ES" => LanguageIdentifier.Basque,
                "bn-IN" => LanguageIdentifier.Bengali,
                "bs-Latn-BA" => LanguageIdentifier.Bosnian,
                "ca-ES" => LanguageIdentifier.Catalan,
                "fa-IR" => LanguageIdentifier.Farsi,
                "fil-PH" => LanguageIdentifier.Filipino,
                "gl-ES" => LanguageIdentifier.Galician,
                "ka-GE" => LanguageIdentifier.Georgian,
                "gu-IN" => LanguageIdentifier.Gujarati,
                "ha-Latn-NG" => LanguageIdentifier.Hausa,
                "is-IS" => LanguageIdentifier.Icelandic,
                "ig-NG" => LanguageIdentifier.Igbo,
                "id-ID" => LanguageIdentifier.Indonesian,
                "ga-IE" => LanguageIdentifier.Irish,
                "kn-IN" => LanguageIdentifier.Kannada,
                "ks-Arab-IN" => LanguageIdentifier.Kashmiri,
                "kk-KZ" => LanguageIdentifier.Kazakh,
                "km-KH" => LanguageIdentifier.Khmer,
                "kok-IN" => LanguageIdentifier.Konkani,
                "ky-KG" => LanguageIdentifier.Kyrgyz,
                "lo-LA" => LanguageIdentifier.Lao,
                "mk-MK" => LanguageIdentifier.Macedonian,
                "ms-MY" => LanguageIdentifier.Malay,
                "ml-IN" => LanguageIdentifier.Malayalam,
                "mt-MT" => LanguageIdentifier.Maltese,
                "mi-NZ" => LanguageIdentifier.Maori,
                "mr-IN" => LanguageIdentifier.Marathi,
                "mn-MN" => LanguageIdentifier.Mongolian,
                "ne-NP" => LanguageIdentifier.Nepali,
                "or-IN" => LanguageIdentifier.Oriya,
                "ps-AF" => LanguageIdentifier.Pashto,
                "pa-IN" => LanguageIdentifier.Punjabi,
                "qu-BO" => LanguageIdentifier.QuechuaBolivia,
                "qu-EC" => LanguageIdentifier.QuechuaEcuador,
                "qu-PE" => LanguageIdentifier.QuechuaPeru,
                "se-NO" => LanguageIdentifier.Sami,
                "sa-IN" => LanguageIdentifier.Sanskrit,
                "sr-Cyrl-RS" => LanguageIdentifier.SerbianCyrillic,
                "sr-Latn-RS" => LanguageIdentifier.SerbianLatin,
                "sd-Arab-PK" => LanguageIdentifier.Sindhi,
                "si-LK" => LanguageIdentifier.Sinhala,
                "so-SO" => LanguageIdentifier.Somali,
                "nso-ZA" => LanguageIdentifier.Sotho,
                "sw-KE" => LanguageIdentifier.Swahili,
                "syr-SY" => LanguageIdentifier.Syriac,
                "tg-Cyrl-TJ" => LanguageIdentifier.Tajik,
                "ta-IN" => LanguageIdentifier.Tamil,
                "tt-RU" => LanguageIdentifier.Tatar,
                "te-IN" => LanguageIdentifier.Telugu,
                "ti-ET" => LanguageIdentifier.Tigrinya,
                "tn-ZA" => LanguageIdentifier.Tswana,
                "tk-TM" => LanguageIdentifier.Turkmen,
                "ur-PK" => LanguageIdentifier.Urdu,
                "uz-Cyrl-UZ" => LanguageIdentifier.UzbekCyrillic,
                "uz-Latn-UZ" => LanguageIdentifier.UzbekLatin,
                "cy-GB" => LanguageIdentifier.Welsh,
                "xh-ZA" => LanguageIdentifier.Xhosa,
                "yo-NG" => LanguageIdentifier.Yoruba,
                "zu-ZA" => LanguageIdentifier.Zulu,
                _ => null,
            };
        }

        public static LanguageIdentifier FromTag(string langTag)
        {
            LanguageIdentifier? lang = TryFromTag(langTag);
            if (lang is null)
            {
                throw new ArgumentException(
                    $"Language tag {langTag} is not defined in LanguageIdentifier enum."
                );
            }
            return lang.Value;
        }
    }

    /// <summary>
    /// Represents a language identifier for formatting based on Microsoft Windows LCID values.
    /// </summary>
    public enum LanguageIdentifier : int
    {
        /// <summary>
        /// English (United States) - LCID 1033.
        /// </summary>
        EnglishUS = 1033,

        /// <summary>
        /// English (United Kingdom) - LCID 2057.
        /// </summary>
        EnglishUK = 2057,

        /// <summary>
        /// English (Canada) - LCID 4105.
        /// </summary>
        EnglishCanada = 4105,

        /// <summary>
        /// English (Australia) - LCID 3081.
        /// </summary>
        EnglishAustralia = 3081,

        /// <summary>
        /// English (New Zealand) - LCID 5129.
        /// </summary>
        EnglishNewZealand = 5129,

        /// <summary>
        /// English (Ireland) - LCID 6153.
        /// </summary>
        EnglishIreland = 6153,

        /// <summary>
        /// English (South Africa) - LCID 7177.
        /// </summary>
        EnglishSouthAfrica = 7177,

        /// <summary>
        /// English (Jamaica) - LCID 8201.
        /// </summary>
        EnglishJamaica = 8201,

        /// <summary>
        /// English (Caribbean) - LCID 9225.
        /// </summary>
        EnglishCaribbean = 9225,

        /// <summary>
        /// English (Belize) - LCID 10249.
        /// </summary>
        EnglishBelize = 10249,

        /// <summary>
        /// English (Trinidad and Tobago) - LCID 11273.
        /// </summary>
        EnglishTrinidadTobago = 11273,

        /// <summary>
        /// English (Zimbabwe) - LCID 12297.
        /// </summary>
        EnglishZimbabwe = 12297,

        /// <summary>
        /// English (Philippines) - LCID 13321.
        /// </summary>
        EnglishPhilippines = 13321,

        /// <summary>
        /// English (India) - LCID 16393.
        /// </summary>
        EnglishIndia = 16393,

        /// <summary>
        /// English (Malaysia) - LCID 17417.
        /// </summary>
        EnglishMalaysia = 17417,

        /// <summary>
        /// English (Singapore) - LCID 18441.
        /// </summary>
        EnglishSingapore = 18441,

        /// <summary>
        /// French (France) - LCID 1036.
        /// </summary>
        FrenchFrance = 1036,

        /// <summary>
        /// French (Belgium) - LCID 2060.
        /// </summary>
        FrenchBelgium = 2060,

        /// <summary>
        /// French (Canada) - LCID 3084.
        /// </summary>
        FrenchCanada = 3084,

        /// <summary>
        /// French (Switzerland) - LCID 4108.
        /// </summary>
        FrenchSwitzerland = 4108,

        /// <summary>
        /// French (Luxembourg) - LCID 5132.
        /// </summary>
        FrenchLuxembourg = 5132,

        /// <summary>
        /// French (Monaco) - LCID 6156.
        /// </summary>
        FrenchMonaco = 6156,

        /// <summary>
        /// German (Germany) - LCID 1031.
        /// </summary>
        GermanGermany = 1031,

        /// <summary>
        /// German (Switzerland) - LCID 2055.
        /// </summary>
        GermanSwitzerland = 2055,

        /// <summary>
        /// German (Austria) - LCID 3079.
        /// </summary>
        GermanAustria = 3079,

        /// <summary>
        /// German (Luxembourg) - LCID 4103.
        /// </summary>
        GermanLuxembourg = 4103,

        /// <summary>
        /// German (Liechtenstein) - LCID 5127.
        /// </summary>
        GermanLiechtenstein = 5127,

        /// <summary>
        /// Spanish (Spain) - LCID 3082.
        /// </summary>
        SpanishSpain = 3082,

        /// <summary>
        /// Spanish (Mexico) - LCID 2058.
        /// </summary>
        SpanishMexico = 2058,

        /// <summary>
        /// Spanish (Guatemala) - LCID 4106.
        /// </summary>
        SpanishGuatemala = 4106,

        /// <summary>
        /// Spanish (Costa Rica) - LCID 5130.
        /// </summary>
        SpanishCostaRica = 5130,

        /// <summary>
        /// Spanish (Panama) - LCID 6154.
        /// </summary>
        SpanishPanama = 6154,

        /// <summary>
        /// Spanish (Dominican Republic) - LCID 7178.
        /// </summary>
        SpanishDominicanRepublic = 7178,

        /// <summary>
        /// Spanish (Venezuela) - LCID 8202.
        /// </summary>
        SpanishVenezuela = 8202,

        /// <summary>
        /// Spanish (Colombia) - LCID 9226.
        /// </summary>
        SpanishColombia = 9226,

        /// <summary>
        /// Spanish (Peru) - LCID 10250.
        /// </summary>
        SpanishPeru = 10250,

        /// <summary>
        /// Spanish (Argentina) - LCID 11274.
        /// </summary>
        SpanishArgentina = 11274,

        /// <summary>
        /// Spanish (Ecuador) - LCID 12298.
        /// </summary>
        SpanishEcuador = 12298,

        /// <summary>
        /// Spanish (Chile) - LCID 13322.
        /// </summary>
        SpanishChile = 13322,

        /// <summary>
        /// Spanish (Uruguay) - LCID 14346.
        /// </summary>
        SpanishUruguay = 14346,

        /// <summary>
        /// Spanish (Paraguay) - LCID 15370.
        /// </summary>
        SpanishParaguay = 15370,

        /// <summary>
        /// Spanish (Bolivia) - LCID 16394.
        /// </summary>
        SpanishBolivia = 16394,

        /// <summary>
        /// Spanish (El Salvador) - LCID 17418.
        /// </summary>
        SpanishElSalvador = 17418,

        /// <summary>
        /// Spanish (Honduras) - LCID 18442.
        /// </summary>
        SpanishHonduras = 18442,

        /// <summary>
        /// Spanish (Nicaragua) - LCID 19466.
        /// </summary>
        SpanishNicaragua = 19466,

        /// <summary>
        /// Spanish (Puerto Rico) - LCID 20490.
        /// </summary>
        SpanishPuertoRico = 20490,

        /// <summary>
        /// Spanish (United States) - LCID 21514.
        /// </summary>
        SpanishUS = 21514,

        /// <summary>
        /// Italian (Italy) - LCID 1040.
        /// </summary>
        ItalianItaly = 1040,

        /// <summary>
        /// Italian (Switzerland) - LCID 2064.
        /// </summary>
        ItalianSwitzerland = 2064,

        /// <summary>
        /// Portuguese (Brazil) - LCID 1046.
        /// </summary>
        PortugueseBrazil = 1046,

        /// <summary>
        /// Portuguese (Portugal) - LCID 2070.
        /// </summary>
        PortuguesePortugal = 2070,

        /// <summary>
        /// Japanese (Japan) - LCID 1041.
        /// </summary>
        Japanese = 1041,

        /// <summary>
        /// Chinese (Simplified, PRC) - LCID 2052.
        /// </summary>
        ChineseSimplified = 2052,

        /// <summary>
        /// Chinese (Traditional, Taiwan) - LCID 1028.
        /// </summary>
        ChineseTraditional = 1028,

        /// <summary>
        /// Chinese (Simplified, Singapore) - LCID 4100.
        /// </summary>
        ChineseSimplifiedSingapore = 4100,

        /// <summary>
        /// Chinese (Traditional, Hong Kong SAR) - LCID 3076.
        /// </summary>
        ChineseTraditionalHongKong = 3076,

        /// <summary>
        /// Chinese (Traditional, Macao SAR) - LCID 5124.
        /// </summary>
        ChineseTraditionalMacao = 5124,

        /// <summary>
        /// Korean (Korea) - LCID 1042.
        /// </summary>
        Korean = 1042,

        /// <summary>
        /// Dutch (Netherlands) - LCID 1043.
        /// </summary>
        DutchNetherlands = 1043,

        /// <summary>
        /// Dutch (Belgium) - LCID 2067.
        /// </summary>
        DutchBelgium = 2067,

        /// <summary>
        /// Russian (Russia) - LCID 1049.
        /// </summary>
        Russian = 1049,

        /// <summary>
        /// Arabic (Saudi Arabia) - LCID 1025.
        /// </summary>
        ArabicSaudiArabia = 1025,

        /// <summary>
        /// Hindi (India) - LCID 1081.
        /// </summary>
        Hindi = 1081,

        /// <summary>
        /// Thai (Thailand) - LCID 1054.
        /// </summary>
        Thai = 1054,

        /// <summary>
        /// Hebrew (Israel) - LCID 1037.
        /// </summary>
        Hebrew = 1037,

        /// <summary>
        /// Turkish (Turkey) - LCID 1055.
        /// </summary>
        Turkish = 1055,

        /// <summary>
        /// Polish (Poland) - LCID 1045.
        /// </summary>
        Polish = 1045,

        /// <summary>
        /// Czech (Czech Republic) - LCID 1029.
        /// </summary>
        Czech = 1029,

        /// <summary>
        /// Hungarian (Hungary) - LCID 1038.
        /// </summary>
        Hungarian = 1038,

        /// <summary>
        /// Swedish (Sweden) - LCID 1053.
        /// </summary>
        Swedish = 1053,

        /// <summary>
        /// Norwegian (Bokmål, Norway) - LCID 1044.
        /// </summary>
        NorwegianBokmal = 1044,

        /// <summary>
        /// Finnish (Finland) - LCID 1035.
        /// </summary>
        Finnish = 1035,

        /// <summary>
        /// Danish (Denmark) - LCID 1030.
        /// </summary>
        Danish = 1030,

        /// <summary>
        /// Vietnamese (Vietnam) - LCID 1066.
        /// </summary>
        Vietnamese = 1066,

        /// <summary>
        /// Bulgarian (Bulgaria) - LCID 1026.
        /// </summary>
        Bulgarian = 1026,

        /// <summary>
        /// Croatian (Croatia) - LCID 1050.
        /// </summary>
        Croatian = 1050,

        /// <summary>
        /// Estonian (Estonia) - LCID 1061.
        /// </summary>
        Estonian = 1061,

        /// <summary>
        /// Greek (Greece) - LCID 1032.
        /// </summary>
        Greek = 1032,

        /// <summary>
        /// Latvian (Latvia) - LCID 1062.
        /// </summary>
        Latvian = 1062,

        /// <summary>
        /// Lithuanian (Lithuania) - LCID 1063.
        /// </summary>
        Lithuanian = 1063,

        /// <summary>
        /// Romanian (Romania) - LCID 1048.
        /// </summary>
        Romanian = 1048,

        /// <summary>
        /// Slovak (Slovakia) - LCID 1051.
        /// </summary>
        Slovak = 1051,

        /// <summary>
        /// Slovenian (Slovenia) - LCID 1060.
        /// </summary>
        Slovenian = 1060,

        /// <summary>
        /// Ukrainian (Ukraine) - LCID 1058.
        /// </summary>
        Ukrainian = 1058,
        ArabicAlgeria = 5121,
        ArabicBahrain = 15361,
        ArabicEgypt = 3073,
        ArabicIraq = 2049,
        ArabicJordan = 11265,
        ArabicKuwait = 13313,
        ArabicLebanon = 12289,
        ArabicLibya = 4097,
        ArabicMorocco = 6145,
        ArabicOman = 8193,
        ArabicQatar = 16385,
        ArabicSyria = 10241,
        ArabicTunisia = 7169,
        ArabicUAE = 14337,
        ArabicYemen = 9217,
        SwedishFinland = 2077,
        Afrikaans = 1078,
        Albanian = 1052,
        Amharic = 1118,
        Armenian = 1067,
        Assamese = 1101,
        AzeriCyrillic = 2092,
        AzeriLatin = 1068,
        Basque = 1069,
        Bengali = 1093,
        Bosnian = 5146,
        Catalan = 1027,
        Farsi = 1065,
        Filipino = 1124,
        Galician = 1110,
        Georgian = 1079,
        Gujarati = 1095,
        Hausa = 1128,
        Icelandic = 1039,
        Igbo = 1136,
        Indonesian = 1057,
        Irish = 2108,
        Kannada = 1099,
        Kashmiri = 1120,
        Kazakh = 1087,
        Khmer = 1107,
        Konkani = 1111,
        Kyrgyz = 1088,
        Lao = 1108,
        Macedonian = 1071,
        Malay = 1086,
        Malayalam = 1100,
        Maltese = 1082,
        Maori = 1153,
        Marathi = 1102,
        Mongolian = 1104,
        Nepali = 1121,
        Oriya = 1096,
        Pashto = 1123,
        Punjabi = 1094,
        QuechuaBolivia = 1131,
        QuechuaEcuador = 2155,
        QuechuaPeru = 3179,
        Sami = 1083,
        Sanskrit = 1103,
        SerbianCyrillic = 3098,
        SerbianLatin = 2074,
        Sindhi = 1113,
        Sinhala = 1115,
        Somali = 1143,
        Sotho = 1072,
        Swahili = 1089,
        Syriac = 1114,
        Tajik = 1064,
        Tamil = 1097,
        Tatar = 1092,
        Telugu = 1098,
        Tigrinya = 1139,
        Tswana = 1074,
        Turkmen = 1090,
        Urdu = 1056,
        UzbekCyrillic = 2115,
        UzbekLatin = 1091,
        Welsh = 1106,
        Xhosa = 1076,
        Yoruba = 1130,
        Zulu = 1077,
    }
}

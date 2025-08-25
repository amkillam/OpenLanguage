# Language Identifiers and Localization

This document demonstrates how to work with the OpenLanguage WordprocessingML language identifier system for international document processing.

## Language Identifier Enumeration

### Basic Usage

```csharp
using OpenLanguage.WordprocessingML;

// Using predefined language identifiers
LanguageIdentifier english = LanguageIdentifier.EnglishUS;
LanguageIdentifier french = LanguageIdentifier.FrenchFrance;
LanguageIdentifier german = LanguageIdentifier.GermanGermany;

Console.WriteLine($"English US LCID: {(int)english}"); // 1033
Console.WriteLine($"French France LCID: {(int)french}"); // 1036
Console.WriteLine($"German Germany LCID: {(int)german}"); // 1031
```

### Working with Regional Variants

```csharp
using OpenLanguage.WordprocessingML;

// English variants
LanguageIdentifier[] englishVariants = {
    LanguageIdentifier.EnglishUS,           // 1033
    LanguageIdentifier.EnglishUK,           // 2057
    LanguageIdentifier.EnglishCanada,       // 4105
    LanguageIdentifier.EnglishAustralia,    // 3081
    LanguageIdentifier.EnglishNewZealand,   // 5129
    LanguageIdentifier.EnglishIndia,        // 16393
    LanguageIdentifier.EnglishSingapore     // 18441
};

foreach (var variant in englishVariants)
{
    Console.WriteLine($"{variant}: LCID {(int)variant}");
}

// Spanish variants
LanguageIdentifier[] spanishVariants = {
    LanguageIdentifier.SpanishSpain,        // 3082
    LanguageIdentifier.SpanishMexico,       // 2058
    LanguageIdentifier.SpanishArgentina,    // 11274
    LanguageIdentifier.SpanishChile,        // 13322
    LanguageIdentifier.SpanishUS           // 21514
};

foreach (var variant in spanishVariants)
{
    Console.WriteLine($"{variant}: LCID {(int)variant}");
}
```

### European Languages

```csharp
using OpenLanguage.WordprocessingML;

// Major European languages
var europeanLanguages = new Dictionary<string, LanguageIdentifier>
{
    ["French (France)"] = LanguageIdentifier.FrenchFrance,
    ["French (Belgium)"] = LanguageIdentifier.FrenchBelgium,
    ["French (Canada)"] = LanguageIdentifier.FrenchCanada,
    ["French (Switzerland)"] = LanguageIdentifier.FrenchSwitzerland,
    ["German (Germany)"] = LanguageIdentifier.GermanGermany,
    ["German (Austria)"] = LanguageIdentifier.GermanAustria,
    ["German (Switzerland)"] = LanguageIdentifier.GermanSwitzerland,
    ["Italian (Italy)"] = LanguageIdentifier.ItalianItaly,
    ["Italian (Switzerland)"] = LanguageIdentifier.ItalianSwitzerland,
    ["Dutch (Netherlands)"] = LanguageIdentifier.DutchNetherlands,
    ["Dutch (Belgium)"] = LanguageIdentifier.DutchBelgium
};

foreach (var kvp in europeanLanguages)
{
    Console.WriteLine($"{kvp.Key}: {(int)kvp.Value}");
}
```

### Asian Languages

```csharp
using OpenLanguage.WordprocessingML;

// Asian language examples
var asianLanguages = new Dictionary<string, LanguageIdentifier>
{
    ["Japanese"] = LanguageIdentifier.Japanese,                               // 1041
    ["Korean"] = LanguageIdentifier.Korean,                                   // 1042
    ["Chinese (Simplified)"] = LanguageIdentifier.ChineseSimplified,         // 2052
    ["Chinese (Traditional)"] = LanguageIdentifier.ChineseTraditional,       // 1028
    ["Chinese (Hong Kong)"] = LanguageIdentifier.ChineseTraditionalHongKong, // 3076
    ["Chinese (Singapore)"] = LanguageIdentifier.ChineseSimplifiedSingapore, // 4100
    ["Thai"] = LanguageIdentifier.Thai,                                       // 1054
    ["Vietnamese"] = LanguageIdentifier.Vietnamese,                           // 1066
    ["Hindi"] = LanguageIdentifier.Hindi                                      // 1081
};

foreach (var kvp in asianLanguages)
{
    Console.WriteLine($"{kvp.Key}: {(int)kvp.Value}");
}
```

## Practical Applications

### Document Language Detection

```csharp
using OpenLanguage.WordprocessingML;

public class LanguageDetector
{
    public static string GetLanguageName(LanguageIdentifier languageId)
    {
        return languageId switch
        {
            LanguageIdentifier.EnglishUS => "English (United States)",
            LanguageIdentifier.EnglishUK => "English (United Kingdom)",
            LanguageIdentifier.FrenchFrance => "French (France)",
            LanguageIdentifier.GermanGermany => "German (Germany)",
            LanguageIdentifier.SpanishSpain => "Spanish (Spain)",
            LanguageIdentifier.Japanese => "Japanese",
            LanguageIdentifier.ChineseSimplified => "Chinese (Simplified)",
            LanguageIdentifier.ChineseTraditional => "Chinese (Traditional)",
            _ => $"Language ID: {(int)languageId}"
        };
    }

    public static bool IsRightToLeft(LanguageIdentifier languageId)
    {
        return languageId switch
        {
            LanguageIdentifier.Hebrew or
            LanguageIdentifier.ArabicSaudiArabia or
            LanguageIdentifier.ArabicEgypt or
            LanguageIdentifier.ArabicIraq or
            LanguageIdentifier.ArabicJordan or
            LanguageIdentifier.ArabicKuwait or
            LanguageIdentifier.ArabicLebanon or
            LanguageIdentifier.ArabicLibya or
            LanguageIdentifier.ArabicMorocco or
            LanguageIdentifier.ArabicOman or
            LanguageIdentifier.ArabicQatar or
            LanguageIdentifier.ArabicSyria or
            LanguageIdentifier.ArabicTunisia or
            LanguageIdentifier.ArabicUAE or
            LanguageIdentifier.ArabicYemen => true,
            _ => false
        };
    }
}

// Usage
LanguageIdentifier[] testLanguages = {
    LanguageIdentifier.EnglishUS,
    LanguageIdentifier.Hebrew,
    LanguageIdentifier.ArabicSaudiArabia,
    LanguageIdentifier.Japanese
};

foreach (var lang in testLanguages)
{
    string name = LanguageDetector.GetLanguageName(lang);
    bool isRtl = LanguageDetector.IsRightToLeft(lang);
    Console.WriteLine($"{name}: RTL={isRtl}");
}
```

### Regional Formatting

```csharp
using OpenLanguage.WordprocessingML;
using System.Globalization;

public class RegionalFormatter
{
    public static CultureInfo GetCultureInfo(LanguageIdentifier languageId)
    {
        int lcid = (int)languageId;
        return new CultureInfo(lcid);
    }

    public static string FormatCurrency(decimal amount, LanguageIdentifier languageId)
    {
        var culture = GetCultureInfo(languageId);
        return amount.ToString("C", culture);
    }

    public static string FormatDate(DateTime date, LanguageIdentifier languageId)
    {
        var culture = GetCultureInfo(languageId);
        return date.ToString("D", culture);
    }

    public static string FormatNumber(double number, LanguageIdentifier languageId)
    {
        var culture = GetCultureInfo(languageId);
        return number.ToString("N", culture);
    }
}

// Usage examples
decimal price = 1234.56m;
DateTime today = DateTime.Now;
double largeNumber = 1234567.89;

var languages = new[] {
    LanguageIdentifier.EnglishUS,
    LanguageIdentifier.FrenchFrance,
    LanguageIdentifier.GermanGermany,
    LanguageIdentifier.Japanese
};

foreach (var lang in languages)
{
    Console.WriteLine($"Language: {LanguageDetector.GetLanguageName(lang)}");
    Console.WriteLine($"  Currency: {RegionalFormatter.FormatCurrency(price, lang)}");
    Console.WriteLine($"  Date: {RegionalFormatter.FormatDate(today, lang)}");
    Console.WriteLine($"  Number: {RegionalFormatter.FormatNumber(largeNumber, lang)}");
    Console.WriteLine();
}
```

### Language-Specific Processing

```csharp
using OpenLanguage.WordprocessingML;

public class LanguageSpecificProcessor
{
    public static string GetDefaultDateFormat(LanguageIdentifier languageId)
    {
        return languageId switch
        {
            LanguageIdentifier.EnglishUS => "MM/dd/yyyy",
            LanguageIdentifier.EnglishUK => "dd/MM/yyyy",
            LanguageIdentifier.GermanGermany => "dd.MM.yyyy",
            LanguageIdentifier.FrenchFrance => "dd/MM/yyyy",
            LanguageIdentifier.Japanese => "yyyy/MM/dd",
            LanguageIdentifier.ChineseSimplified => "yyyy-MM-dd",
            _ => "MM/dd/yyyy"
        };
    }

    public static string GetDefaultTimeFormat(LanguageIdentifier languageId)
    {
        return languageId switch
        {
            LanguageIdentifier.EnglishUS => "h:mm tt",
            LanguageIdentifier.EnglishUK => "HH:mm",
            LanguageIdentifier.GermanGermany => "HH:mm",
            LanguageIdentifier.FrenchFrance => "HH:mm",
            LanguageIdentifier.Japanese => "H:mm",
            _ => "h:mm tt"
        };
    }

    public static bool Uses24HourFormat(LanguageIdentifier languageId)
    {
        return languageId switch
        {
            LanguageIdentifier.EnglishUS => false,
            LanguageIdentifier.EnglishUK => true,
            LanguageIdentifier.GermanGermany => true,
            LanguageIdentifier.FrenchFrance => true,
            LanguageIdentifier.Japanese => true,
            _ => false
        };
    }
}

// Usage
foreach (var lang in new[] {
    LanguageIdentifier.EnglishUS,
    LanguageIdentifier.EnglishUK,
    LanguageIdentifier.GermanGermany,
    LanguageIdentifier.Japanese
})
{
    Console.WriteLine($"{LanguageDetector.GetLanguageName(lang)}:");
    Console.WriteLine($"  Date format: {LanguageSpecificProcessor.GetDefaultDateFormat(lang)}");
    Console.WriteLine($"  Time format: {LanguageSpecificProcessor.GetDefaultTimeFormat(lang)}");
    Console.WriteLine($"  24-hour format: {LanguageSpecificProcessor.Uses24HourFormat(lang)}");
    Console.WriteLine();
}
```

### Language Groups and Families

```csharp
using OpenLanguage.WordprocessingML;

public enum LanguageFamily
{
    Germanic,
    Romance,
    Slavic,
    SinoTibetan,
    Semitic,
    JapanoKorean,
    Other
}

public class LanguageFamilyClassifier
{
    public static LanguageFamily GetLanguageFamily(LanguageIdentifier languageId)
    {
        return languageId switch
        {
            LanguageIdentifier.EnglishUS or
            LanguageIdentifier.EnglishUK or
            LanguageIdentifier.EnglishCanada or
            LanguageIdentifier.EnglishAustralia or
            LanguageIdentifier.GermanGermany or
            LanguageIdentifier.GermanAustria or
            LanguageIdentifier.GermanSwitzerland or
            LanguageIdentifier.DutchNetherlands or
            LanguageIdentifier.DutchBelgium or
            LanguageIdentifier.Swedish or
            LanguageIdentifier.SwedishFinland or
            LanguageIdentifier.NorwegianBokmal or
            LanguageIdentifier.Danish => LanguageFamily.Germanic,

            LanguageIdentifier.FrenchFrance or
            LanguageIdentifier.FrenchBelgium or
            LanguageIdentifier.FrenchCanada or
            LanguageIdentifier.SpanishSpain or
            LanguageIdentifier.SpanishMexico or
            LanguageIdentifier.SpanishArgentina or
            LanguageIdentifier.ItalianItaly or
            LanguageIdentifier.PortugueseBrazil or
            LanguageIdentifier.PortuguesePortugal or
            LanguageIdentifier.Romanian => LanguageFamily.Romance,

            LanguageIdentifier.Russian or
            LanguageIdentifier.Polish or
            LanguageIdentifier.Czech or
            LanguageIdentifier.Slovak or
            LanguageIdentifier.Croatian or
            LanguageIdentifier.Bulgarian or
            LanguageIdentifier.Ukrainian => LanguageFamily.Slavic,

            LanguageIdentifier.ChineseSimplified or
            LanguageIdentifier.ChineseTraditional or
            LanguageIdentifier.ChineseSimplifiedSingapore or
            LanguageIdentifier.ChineseTraditionalHongKong => LanguageFamily.SinoTibetan,

            LanguageIdentifier.ArabicSaudiArabia or
            LanguageIdentifier.ArabicEgypt or
            LanguageIdentifier.Hebrew => LanguageFamily.Semitic,

            LanguageIdentifier.Japanese or
            LanguageIdentifier.Korean => LanguageFamily.JapanoKorean,

            _ => LanguageFamily.Other
        };
    }
}

// Usage
var sampleLanguages = new[] {
    LanguageIdentifier.EnglishUS,
    LanguageIdentifier.FrenchFrance,
    LanguageIdentifier.GermanGermany,
    LanguageIdentifier.Russian,
    LanguageIdentifier.ChineseSimplified,
    LanguageIdentifier.Japanese,
    LanguageIdentifier.ArabicSaudiArabia,
    LanguageIdentifier.Hindi
};

foreach (var lang in sampleLanguages)
{
    var family = LanguageFamilyClassifier.GetLanguageFamily(lang);
    Console.WriteLine($"{LanguageDetector.GetLanguageName(lang)}: {family}");
}
```

### Integration with Field Instructions

```csharp
using OpenLanguage.WordprocessingML;
using OpenLanguage.WordprocessingML.FieldInstruction;

public class LocalizedFieldGenerator
{
    public static FieldInstruction CreateLocalizedDateField(LanguageIdentifier languageId)
    {
        var dateFormat = LanguageSpecificProcessor.GetDefaultDateFormat(languageId);
        var field = new FieldInstruction("DATE");
        field.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\@"));
        field.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, dateFormat));
        return field;
    }

    public static FieldInstruction CreateLocalizedAddressBlock(LanguageIdentifier languageId)
    {
        var field = new FieldInstruction("ADDRESSBLOCK");

        // Set language-specific formatting
        field.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\l"));
        field.Arguments.Add(new FieldArgument(FieldArgumentType.Number, ((int)languageId).ToString()));

        return field;
    }
}

// Usage
var languages = new[] {
    LanguageIdentifier.EnglishUS,
    LanguageIdentifier.FrenchFrance,
    LanguageIdentifier.GermanGermany
};

foreach (var lang in languages)
{
    var dateField = LocalizedFieldGenerator.CreateLocalizedDateField(lang);
    var addressField = LocalizedFieldGenerator.CreateLocalizedAddressBlock(lang);

    Console.WriteLine($"Language: {LanguageDetector.GetLanguageName(lang)}");
    Console.WriteLine($"  Date field: {dateField}");
    Console.WriteLine($"  Address field: {addressField}");
    Console.WriteLine();
}
```

This example demonstrates comprehensive usage of the OpenLanguage language identifier system for creating internationalized and localized document processing applications.

# Special Types and Enums

The `OpenLanguage.WordprocessingML` namespaces include several specialized types and enumerations to provide type-safety and clarity when working with field instructions.

## Language Identifiers

The `LanguageIdentifier` enum provides a comprehensive list of language codes based on Microsoft Windows LCID values, used for localization in fields like `ADDRESSBLOCK` and `DATE`.

### Basic Usage

```csharp
using OpenLanguage.WordprocessingML;

// Using predefined language identifiers
LanguageIdentifier english = LanguageIdentifier.EnglishUS;
LanguageIdentifier french = LanguageIdentifier.FrenchFrance;

Console.WriteLine($"English US LCID: {(int)english}"); // 1033
```

### LanguageIdentifierExtensions

The `LanguageIdentifierExtensions` static class provides helper methods for conversion.

```csharp
using OpenLanguage.WordprocessingML;

// Get LCID from enum
int lcid = LanguageIdentifier.FrenchCanada.ToLcid(); // 3084

// Get enum from LCID
LanguageIdentifier lang = LanguageIdentifierExtensions.FromLcid(1033); // EnglishUS

// Convert to and from IETF language tags
string tag = LanguageIdentifier.GermanGermany.ToTag(); // "de-DE"
LanguageIdentifier? langFromTag = LanguageIdentifierExtensions.TryFromTag("en-GB"); // EnglishUK
```

### Integration with Field Instructions

```csharp
using OpenLanguage.WordprocessingML;
using OpenLanguage.WordprocessingML.FieldInstruction;
using OpenLanguage.WordprocessingML.FieldInstruction.Ast;
using OpenLanguage.WordprocessingML.Ast;
using System.Collections.Generic;

// Create a localized ADDRESSBLOCK field
var langIdArg = new FlaggedArgument<ExpressionNode>(
    new FlagNode(@"\l"),
    new NumericLiteralNode<int>(((int)LanguageIdentifier.FrenchFrance).ToString(), (int)LanguageIdentifier.FrenchFrance, "D")
);

var addressBlock = new AddressBlockFieldInstruction(
    instruction: new StringLiteralNode("ADDRESSBLOCK"),
    countryRegionInclusionSetting: null,
    formatByRecipientCountry: null,
    excludedCountriesRegions: null,
    formatTemplate: null,
    languageId: langIdArg,
    order: new List<AddressBlockArgument> { AddressBlockArgument.LanguageId }
);

Console.WriteLine(addressBlock.ToString()); // ADDRESSBLOCK \l 1036
```

## Programmatic Identifiers (ProgID)

The `ProgrammaticIdentifier` class is used in fields like `EMBED` and `LINK` to specify OLE objects. It is located in the `OpenLanguage.WordprocessingML.ProgrammaticIdentifier` namespace.

```csharp
using OpenLanguage.WordprocessingML.ProgrammaticIdentifier;

// Create a ProgID
var progId = new ProgrammaticIdentifier(
    Application.Excel,
    Object.Sheet,
    12
);

Console.WriteLine(progId.ToString()); // "Excel.Sheet.12"

// Parse a ProgID string
var progIdParser = new ProgrammaticIdentifier(Application.Word, Object.Document);
var parsedProgId = progIdParser.TryParse("Word.Document.8");
if (parsedProgId != null)
{
    Console.WriteLine($"Application: {parsedProgId.Application}");
    Console.WriteLine($"Object: {parsedProgId.Object}");
    Console.WriteLine($"Version: {parsedProgId.Version}");
}
```

## Comparison Operators

The `ComparisonOperator` enum provides a type-safe way to work with comparison operators in fields like `IF` and `COMPARE`. It is located in the `OpenLanguage.WordprocessingML.Operators` namespace.

```csharp
using OpenLanguage.WordprocessingML.Operators;

// Parse from string
var op = ComparisonOperatorExtensions.ParseOperator("<=");
Console.WriteLine(op); // LessThanOrEqual

// Convert to string
string opString = ComparisonOperatorExtensions.OperatorToString(ComparisonOperator.NotEqual);
Console.WriteLine(opString); // <>
```

## Field-Specific Enums

Many field instruction AST nodes have their own enums for arguments and switches, providing clarity and type safety.

### `ADDRESSBLOCK` Field

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction;

// Use CountryRegionInclusion enum
var inclusion = CountryRegionInclusion.IncludeIfDifferent;
Console.WriteLine($"Inclusion setting: {(int)inclusion}"); // 2
```

### `DATABASE` Field

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction;

// Combine attributes with bitwise flags
var attributes = DatabaseTableAttributes.Borders |
                 DatabaseTableAttributes.HeadingRows |
                 DatabaseTableAttributes.AutoFit;

Console.WriteLine($"Attribute value: {(int)attributes}");

// Use a predefined table format
var format = DatabaseTableFormat.Professional;
Console.WriteLine($"Table format: {(int)format}");
```

### `EQ` (Equation) Field

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction.Ast;

// Use enums for equation alignment and symbols
var alignment = EqArrayAlignment.Center;
var symbol = EqIntegralSymbol.Summation;

Console.WriteLine($"Alignment: {alignment}");
Console.WriteLine($"Symbol: {symbol}");
```

These specialized types ensure that you are working with valid values when constructing or manipulating field instruction ASTs, reducing errors and improving code readability.

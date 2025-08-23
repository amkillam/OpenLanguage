# Merge Field Lexer

The `OpenLanguage.WordprocessingML.MergeField` namespace provides lexical analysis functionality for parsing merge field placeholders using character-by-character state machine parsing.

## Overview

The merge field lexer provides:

- **Placeholder Parsing**: Parse merge field placeholders with « » delimiters
- **State Machine Parsing**: Character-by-character lexical analysis
- **Address Block Templates**: Process templates containing multiple merge fields
- **Language ID Parsing**: Parse language identifiers for localization

## Core Classes

### MergeFieldLexer

Static class providing lexical analysis methods:

```csharp
using OpenLanguage.WordprocessingML.MergeField;

// Parse a single merge field placeholder
var placeholder = MergeFieldLexer.ParseMergeField("«FirstName»");
Console.WriteLine($"Field Name: {placeholder.FieldName}"); // "FirstName"

// Parse with formatting switch
var formatted = MergeFieldLexer.ParseMergeField("«LastName\* Upper»");
Console.WriteLine($"Field: {formatted.FieldName}");        // "LastName"
Console.WriteLine($"Switch: {formatted.FormattingSwitch}"); // "\* Upper"
```

### MergeFieldPlaceholder

Represents a parsed merge field placeholder:

```csharp
public class MergeFieldPlaceholder
{
    public string FieldName { get; set; }           // Field name without delimiters
    public string RawText { get; set; }             // Original placeholder text
    public bool IsValid => !string.IsNullOrWhiteSpace(FieldName);
    public string? FormattingSwitch { get; set; }   // Optional formatting switch
}
```

### AddressBlockTemplate

Represents a parsed address block template with merge fields:

```csharp
public class AddressBlockTemplate
{
    public string RawTemplate { get; set; }                        // Original template text
    public List<MergeFieldPlaceholder> Placeholders { get; set; }  // Found placeholders
    public string ProcessedTemplate { get; set; }                  // Template with format specifiers
}
```

## Parsing Methods

### Single Merge Field Parsing

```csharp
// Parse a simple merge field
var simple = MergeFieldLexer.ParseMergeField("«CustomerName»");
Console.WriteLine($"Field: {simple.FieldName}");   // "CustomerName"
Console.WriteLine($"Valid: {simple.IsValid}");     // True

// Parse with formatting switch
var withSwitch = MergeFieldLexer.ParseMergeField("«Amount\* #,##0.00»");
Console.WriteLine($"Field: {withSwitch.FieldName}");           // "Amount"
Console.WriteLine($"Switch: {withSwitch.FormattingSwitch}");   // "\* #,##0.00"
```

### Address Block Template Parsing

```csharp
// Parse an address block template with multiple merge fields
string template = "«Title» «FirstName» «LastName»\n«Address1»\n«City», «State» «PostalCode»";
var addressBlock = MergeFieldLexer.ParseAddressBlockTemplate(template);

Console.WriteLine($"Found {addressBlock.Placeholders.Count} placeholders");
Console.WriteLine($"Processed template: {addressBlock.ProcessedTemplate}");
// Output: "Processed template: {0} {1} {2}\n{3}\n{4}, {5} {6}"

// Access individual placeholders
foreach (var placeholder in addressBlock.Placeholders)
{
    Console.WriteLine($"Field: {placeholder.FieldName}");
}
```

### Field Name Extraction

```csharp
// Extract all unique merge field names from text
string document = "Dear «FirstName» «LastName», your order «OrderNumber» is ready.";
var fieldNames = MergeFieldLexer.ExtractMergeFieldNames(document);

foreach (string fieldName in fieldNames)
{
    Console.WriteLine($"Found field: {fieldName}");
}
// Output: "FirstName", "LastName", "OrderNumber"
```

## Utility Methods

### Validation

```csharp
// Check if text contains valid merge fields
string text1 = "Hello «FirstName»!";
string text2 = "Hello World!";

bool hasFields1 = MergeFieldLexer.ContainsValidMergeFields(text1); // True
bool hasFields2 = MergeFieldLexer.ContainsValidMergeFields(text2); // False
```

### Formatting

```csharp
// Format a field name with merge field delimiters
string formatted = MergeFieldLexer.FormatMergeField("CustomerName");
Console.WriteLine(formatted); // "«CustomerName»"

// Format with a formatting switch
string withSwitch = MergeFieldLexer.FormatMergeFieldWithSwitch("Amount", "* #,##0.00");
Console.WriteLine(withSwitch); // "«Amount\* #,##0.00»"
```

### Reconstruction

```csharp
// Reconstruct a merge field from a placeholder object
var placeholder = new MergeFieldPlaceholder
{
    FieldName = "Total",
    FormattingSwitch = "* Currency"
};

string reconstructed = MergeFieldLexer.Reconstruct(placeholder);
Console.WriteLine(reconstructed); // "«Total * Currency»"
```

## Language ID Parsing

The lexer includes functionality for parsing language identifiers:

### Parse Language IDs

```csharp
// Parse numeric LCID
var langId1 = MergeFieldLexer.ParseLanguageId("1033");
Console.WriteLine(langId1); // EnglishUS

// Parse enum name
var langId2 = MergeFieldLexer.ParseLanguageId("FrenchFrance");
Console.WriteLine(langId2); // FrenchFrance

// Parse culture name
var langId3 = MergeFieldLexer.ParseLanguageId("en-US");
Console.WriteLine(langId3); // EnglishUS

// Invalid input returns null
var invalid = MergeFieldLexer.ParseLanguageId("invalid");
Console.WriteLine(invalid == null); // True
```

## State Machine Implementation

The lexer uses a character-by-character state machine for robust parsing:

### Lexer States

```csharp
internal enum MergeFieldLexerState
{
    SearchingForStart,          // Looking for « character
    ParsingFieldName,           // Inside field, parsing name
    ParsingFormattingSwitch,    // Parsing switch after backslash
    SearchingForEnd             // Looking for » character
}
```

### Parsing Process

1. **SearchingForStart**: Scans text looking for opening « delimiter
2. **ParsingFieldName**: Extracts field name until backslash or closing delimiter
3. **ParsingFormattingSwitch**: Captures formatting switch text after backslash
4. **SearchingForEnd**: Completes parsing when closing » delimiter is found

## Usage Examples

### Complete Parsing Example

```csharp
using OpenLanguage.WordprocessingML.MergeField;

string template = @"
Dear «Title» «FirstName» «LastName»,

Your account balance is «Balance\* Currency».
Please contact us at «CompanyPhone» if you have questions.

Sincerely,
«AgentName\* Upper»
";

// Parse the entire template
var addressBlock = MergeFieldLexer.ParseAddressBlockTemplate(template);

Console.WriteLine($"Original template:");
Console.WriteLine(addressBlock.RawTemplate);

Console.WriteLine($"\nFound {addressBlock.Placeholders.Count} merge fields:");
foreach (var placeholder in addressBlock.Placeholders)
{
    Console.WriteLine($"  Field: {placeholder.FieldName}");
    if (!string.IsNullOrEmpty(placeholder.FormattingSwitch))
    {
        Console.WriteLine($"    Switch: {placeholder.FormattingSwitch}");
    }
}

Console.WriteLine($"\nProcessed template:");
Console.WriteLine(addressBlock.ProcessedTemplate);
```

### Field Name Validation

```csharp
// Validate merge field syntax in user input
string userInput = "«FirstName» «InvalidField «LastName»";

if (MergeFieldLexer.ContainsValidMergeFields(userInput))
{
    var fieldNames = MergeFieldLexer.ExtractMergeFieldNames(userInput);
    Console.WriteLine($"Valid fields found: {string.Join(", ", fieldNames)}");
}
else
{
    Console.WriteLine("No valid merge fields found");
}
```

### Dynamic Field Generation

```csharp
// Generate merge fields programmatically
var fieldNames = new[] { "FirstName", "LastName", "Email", "Amount" };
var formattingSwitches = new[] { null, "* Upper", null, "* Currency" };

for (int i = 0; i < fieldNames.Length; i++)
{
    string mergeField;

    if (formattingSwitches[i] != null)
    {
        mergeField = MergeFieldLexer.FormatMergeFieldWithSwitch(
            fieldNames[i],
            formattingSwitches[i]
        );
    }
    else
    {
        mergeField = MergeFieldLexer.FormatMergeField(fieldNames[i]);
    }

    Console.WriteLine($"Generated: {mergeField}");
}
```

## Technical Details

- **Character-by-Character Parsing**: Uses state machine for robust parsing
- **Delimiter Support**: Recognizes « and » characters for merge field boundaries
- **Switch Parsing**: Handles formatting switches after backslash character
- **Language Support**: Includes comprehensive language ID mapping
- **Whitespace Handling**: Properly trims field names while preserving switch formatting
- **Error Tolerance**: Gracefully handles malformed input

## Limitations

- Only supports « » delimiter style (not {{ }} or other formats)
- Formatting switches are captured as strings but not further parsed
- No validation of switch syntax or values
- Language ID mapping covers common locales but may not be exhaustive

## See Also

- [Field Instructions](../FieldInstruction/FieldInstruction.md) - Generic field instruction handling
- [Unit Tests](../../../OpenLanguage.Test/WordprocessingML/FieldInstruction/) - Test examples showing usage

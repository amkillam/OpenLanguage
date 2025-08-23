# Field Instructions

The `OpenLanguage.WordprocessingML.FieldInstruction` namespace provides comprehensive parsing and processing of Microsoft Word field instructions.

## Overview

Field instructions in Word documents control dynamic content, formatting, and document automation. This component provides:

- **Complete Field Parsing**: Support for all standard Word field types
- **Type-Safe Processing**: Strongly-typed field instruction handling
- **Switch Processing**: Full support for field switches and formatting options
- **Validation**: Comprehensive field instruction validation

## Core Classes

### FieldInstructionParser

The main entry point for parsing field instructions.

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction;

var parser = new FieldInstructionParser();
var result = parser.Parse("MERGEFIELD FirstName \* MERGEFORMAT");
```

#### Methods

- `Parse(string instruction)` - Parses a field instruction string
- `Validate(string instruction)` - Validates field instruction syntax
- `GetFieldType(string instruction)` - Extracts the field type from an instruction

### FieldInstruction

Represents a parsed field instruction with its components.

```csharp
public class FieldInstruction
{
    public FieldType Type { get; }
    public string FieldName { get; }
    public IReadOnlyList<FieldSwitch> Switches { get; }
    public IReadOnlyList<string> Arguments { get; }
    public bool IsValid { get; }
    public IReadOnlyList<FieldError> Errors { get; }
}
```

## Supported Field Types

### Document Information Fields

| Field Type   | Description       | Example                      |
| ------------ | ----------------- | ---------------------------- |
| `AUTHOR`     | Document author   | `AUTHOR`                     |
| `TITLE`      | Document title    | `TITLE`                      |
| `SUBJECT`    | Document subject  | `SUBJECT`                    |
| `KEYWORDS`   | Document keywords | `KEYWORDS`                   |
| `COMMENTS`   | Document comments | `COMMENTS`                   |
| `CREATEDATE` | Creation date     | `CREATEDATE \@ "MM/dd/yyyy"` |
| `SAVEDATE`   | Last save date    | `SAVEDATE \@ "MM/dd/yyyy"`   |
| `PRINTDATE`  | Last print date   | `PRINTDATE \@ "MM/dd/yyyy"`  |

### Merge Fields

| Field Type   | Description           | Example                               |
| ------------ | --------------------- | ------------------------------------- |
| `MERGEFIELD` | Mail merge field      | `MERGEFIELD FirstName \* MERGEFORMAT` |
| `MERGEREC`   | Merge record number   | `MERGEREC`                            |
| `MERGESEQ`   | Merge sequence number | `MERGESEQ`                            |

### Calculation Fields

| Field Type | Description   | Example                |
| ---------- | ------------- | ---------------------- |
| `=`        | Formula field | `= SUM(A1:A10)`        |
| `FORMULA`  | Formula field | `FORMULA(SUM(A1:A10))` |

### Reference Fields

| Field Type  | Description     | Example                                      |
| ----------- | --------------- | -------------------------------------------- |
| `REF`       | Cross-reference | `REF bookmark1`                              |
| `PAGEREF`   | Page reference  | `PAGEREF bookmark1`                          |
| `HYPERLINK` | Hyperlink       | `HYPERLINK "http://example.com" "Link Text"` |

## Field Switches

Field switches modify the behavior and formatting of fields:

### Common Switches

| Switch | Description      | Example           |
| ------ | ---------------- | ----------------- |
| `\*`   | Format switch    | `\* MERGEFORMAT`  |
| `\@`   | Date/time format | `\@ "MM/dd/yyyy"` |
| `\#`   | Numeric format   | `\# "#,##0.00"`   |
| `\!`   | Lock result      | `\!`              |
| `\h`   | Hyperlink        | `\h`              |

### Format Switch Values

| Format        | Description          | Example                          |
| ------------- | -------------------- | -------------------------------- |
| `CAPS`        | All capitals         | `MERGEFIELD Name \* CAPS`        |
| `FIRSTCAP`    | First letter capital | `MERGEFIELD Name \* FIRSTCAP`    |
| `LOWER`       | All lowercase        | `MERGEFIELD Name \* LOWER`       |
| `UPPER`       | All uppercase        | `MERGEFIELD Name \* UPPER`       |
| `MERGEFORMAT` | Preserve formatting  | `MERGEFIELD Name \* MERGEFORMAT` |

## Usage Examples

### Basic Field Parsing

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction;

var parser = new FieldInstructionParser();

// Simple merge field
var mergeField = parser.Parse("MERGEFIELD FirstName");
Console.WriteLine($"Field type: {mergeField.Type}");
Console.WriteLine($"Field name: {mergeField.FieldName}");

// Field with formatting
var formattedField = parser.Parse("MERGEFIELD LastName \* UPPER");
Console.WriteLine($"Switches: {formattedField.Switches.Count}");
```

### Working with Switches

```csharp
var field = parser.Parse("CREATEDATE \@ "MMMM d, yyyy" \* MERGEFORMAT");

foreach (var switch in field.Switches)
{
    Console.WriteLine($"Switch type: {switch.Type}");
    Console.WriteLine($"Switch value: {switch.Value}");
}
```

### Date and Time Fields

```csharp
// Current date with custom format
var dateField = parser.Parse("DATE \@ "dddd, MMMM d, yyyy"");

// Creation date
var createField = parser.Parse("CREATEDATE \@ "MM/dd/yyyy h:mm AM/PM"");

// Save date with merge formatting
var saveField = parser.Parse("SAVEDATE \@ "yyyy-MM-dd" \* MERGEFORMAT");
```

### Formula Fields

```csharp
// Simple calculation
var formula1 = parser.Parse("= 10 + 5");

// Complex formula
var formula2 = parser.Parse("= SUM(A1:A10) / COUNT(A1:A10)");

// Formula with formatting
var formula3 = parser.Parse("= AVERAGE(A1:A10) \# "#,##0.00"");
```

### Hyperlink Fields

```csharp
// Simple hyperlink
var link1 = parser.Parse("HYPERLINK "http://example.com"");

// Hyperlink with display text
var link2 = parser.Parse("HYPERLINK "http://example.com" "Visit Example"");

// Hyperlink with formatting
var link3 = parser.Parse("HYPERLINK "mailto:user@example.com" "Send Email" \h");
```

## Advanced Features

### Custom Field Types

Extend the parser to support custom field types:

```csharp
parser.RegisterFieldType("CUSTOMFIELD", (instruction, args) => {
    // Custom field processing logic
    return new CustomFieldInstruction(instruction, args);
});
```

### Field Validation

```csharp
var instruction = "MERGEFIELD FirstName \* INVALIDFORMAT";
var result = parser.Parse(instruction);

if (!result.IsValid)
{
    foreach (var error in result.Errors)
    {
        Console.WriteLine($"Error: {error.Message} at position {error.Position}");
    }
}
```

### Performance Optimization

For high-volume field processing:

```csharp
// Reuse parser instances
private static readonly FieldInstructionParser _parser = new FieldInstructionParser();

// Pre-validate before parsing
if (_parser.Validate(instruction))
{
    var field = _parser.Parse(instruction);
    // Process field
}
```

## Thread Safety

The `FieldInstructionParser` class is thread-safe and can be used from multiple threads concurrently. The `FieldInstruction` instances returned are immutable and thread-safe.

## Error Handling

The parser provides detailed error information for invalid field instructions:

```csharp
var result = parser.Parse("MERGEFIELD \* CAPS"); // Missing field name

if (!result.IsValid)
{
    foreach (var error in result.Errors)
    {
        Console.WriteLine($"{error.Type}: {error.Message}");
        Console.WriteLine($"Position: {error.Position}");
        Console.WriteLine($"Suggested fix: {error.SuggestedFix}");
    }
}
```

## Integration with Word Documents

The field instruction parser integrates seamlessly with Word document processing:

```csharp
using DocumentFormat.OpenXml.Wordprocessing;

// Extract field instructions from Word document
foreach (var field in document.Descendants<FieldCode>())
{
    var instruction = field.Text;
    var parsed = parser.Parse(instruction);

    if (parsed.IsValid)
    {
        // Process the field instruction
        ProcessField(parsed);
    }
}
```

## See Also

- [Typed Field Instructions](./Typed.md) - Type-safe field instruction handling
- [Merge Fields](../MergeField/MergeField.md) - Specialized merge field processing
- [Expression Processing](../Expression/Expression.md) - Expression evaluation for formula fields

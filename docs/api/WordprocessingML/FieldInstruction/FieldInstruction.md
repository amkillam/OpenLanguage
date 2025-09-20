# Field Instructions

The `OpenLanguage.WordprocessingML.FieldInstruction` namespace provides classes for creating and manipulating Microsoft Word field instructions.

## Overview

This component provides:

- **Field Instruction Creation**: Build field instructions programmatically
- **Argument Handling**: Support for different argument types (identifiers, strings, switches, nested fields)
- **Field Reconstruction**: Convert field objects back to field instruction strings
- **Type Safety**: Strongly-typed field instruction factory

## Core Classes

### FieldInstruction

Represents a Word field instruction with its keyword and arguments.

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction;

// Create a field instruction
var instruction = new FieldInstruction("MERGEFIELD");
instruction.Arguments.Add(new FieldArgument(FieldArgumentType.Identifier, "FirstName"));
instruction.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\* Upper"));

// Reconstruct field instruction
Console.WriteLine(instruction.ToString()); // "MERGEFIELD FirstName \* Upper"
```

#### Properties and Methods

- `string Instruction` - The field keyword (e.g., "MERGEFIELD", "REF", "IF")
- `List<FieldArgument> Arguments` - List of field arguments that can be modified
- `ToString()` - Reconstructs the field instruction string

### FieldArgument

Represents a single argument within a field instruction.

```csharp
public class FieldArgument
{
    public FieldArgumentType Type { get; }    // Type of argument
    public object Value { get; }              // Argument value

    public override string ToString()         // Reconstructs argument as field instruction
}
```

## Argument Types

The `FieldArgumentType` enumeration defines the types of arguments that can be used in field instructions:

### FieldArgumentType Values

| Type            | Description                          | Example Usage                                                     |
| --------------- | ------------------------------------ | ----------------------------------------------------------------- |
| `Identifier`    | Simple identifier or bookmark name   | `new FieldArgument(FieldArgumentType.Identifier, "BookmarkName")` |
| `StringLiteral` | Quoted string literal                | `new FieldArgument(FieldArgumentType.StringLiteral, "text")`      |
| `Switch`        | Field switch (begins with backslash) | `new FieldArgument(FieldArgumentType.Switch, "\* Upper")`         |
| `NestedField`   | Complete nested field instruction    | `new FieldArgument(FieldArgumentType.NestedField, fieldObj)`      |
| `Text`          | Plain text value                     | `new FieldArgument(FieldArgumentType.Text, "plain text")`         |
| `Number`        | Numeric value                        | `new FieldArgument(FieldArgumentType.Number, "123")`              |

### String Literal Handling

String literals are automatically quoted when reconstructed:

```csharp
var stringArg = new FieldArgument(FieldArgumentType.StringLiteral, "Hello World");
Console.WriteLine(stringArg.ToString()); // "Hello World"

// Quotes in strings are escaped
var quotedArg = new FieldArgument(FieldArgumentType.StringLiteral, "Say "Hello"");
Console.WriteLine(quotedArg.ToString()); // "Say "Hello""
```

## Usage Examples

### Creating Field Instructions

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction;

// Create a simple field
var pageField = new FieldInstruction("PAGE");
Console.WriteLine(pageField.ToString()); // "PAGE"

// Create a field with arguments
var mergeField = new FieldInstruction("MERGEFIELD");
mergeField.Arguments.Add(new FieldArgument(FieldArgumentType.Identifier, "FirstName"));
mergeField.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\* MERGEFORMAT"));
Console.WriteLine(mergeField.ToString()); // "MERGEFIELD FirstName \* MERGEFORMAT"
```

### Working with Different Argument Types

```csharp
// Identifier argument
var refField = new FieldInstruction("REF");
refField.Arguments.Add(new FieldArgument(FieldArgumentType.Identifier, "MyBookmark"));

// String literal argument
var hyperlinkField = new FieldInstruction("HYPERLINK");
hyperlinkField.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, "http://example.com"));
hyperlinkField.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, "Link Text"));

// Switch argument
var dateField = new FieldInstruction("DATE");
dateField.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\@ "MM/dd/yyyy""));

Console.WriteLine(hyperlinkField.ToString());
// "HYPERLINK "http://example.com" "Link Text""
```

### Nested Field Instructions

```csharp
// Create a nested field
var innerField = new FieldInstruction("DATE");
var outerField = new FieldInstruction("IF");
outerField.Arguments.Add(new FieldArgument(FieldArgumentType.NestedField, innerField));
outerField.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, "Today"));
outerField.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, "No Date"));

Console.WriteLine(outerField.ToString());
// "IF { DATE } "Today" "No Date""
```

### Modifying Field Instructions

```csharp
// Create and modify a field
var field = new FieldInstruction("MERGEFIELD");
field.Arguments.Add(new FieldArgument(FieldArgumentType.Identifier, "LastName"));

// Add a formatting switch
field.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\* Upper"));

// Change the instruction type
field.Instruction = "DOCVARIABLE";

Console.WriteLine(field.ToString()); // "DOCVARIABLE LastName \* Upper"
```

## Helper Classes and Enumerations

The namespace includes several helper classes and enumerations for working with field instructions:

### Language Support

```csharp
// Language identifiers for formatting
var languageId = LanguageIdentifier.EnglishUS; // 1033
var frenchId = LanguageIdentifier.FrenchFrance; // 1036

// Country/region codes
var country = CountryRegion.UnitedStates;
var inclusion = CountryRegionInclusion.IncludeIfDifferent;
```

### Measurement Values

```csharp
// Points measurement (bounded -31 to 31)
var measurement = new PtsMeasurementValue(15);
Console.WriteLine(measurement.ToString()); // "15"

// Implicit conversion
int value = measurement; // 15
PtsMeasurementValue newMeasurement = 20;
```

### Postal Data Validation

```csharp
// ZIP code validation
var zipCode = new PostalData("12345");     // Valid 5-digit ZIP
var zipPlus4 = new PostalData("12345-6789"); // Valid 9-digit ZIP

// Implicit conversion
string zip = zipCode; // "12345"
PostalData newZip = "54321";
```

### Namespace Declarations

```csharp
// XML namespace validation
var ns = new NamespaceDeclaration("xmlns:w="http://schemas.openxmlformats.org/wordprocessingml/2006/main"");
Console.WriteLine(ns.Prefix);    // "w"
Console.WriteLine(ns.Uri);       // "http://schemas.openxmlformats.org/wordprocessingml/2006/main"
```

## Error Handling

Field instruction construction validates arguments:

```csharp
try
{
    // This will throw ArgumentException
    var invalidField = new FieldInstruction("");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Invalid instruction: {ex.Message}");
}

try
{
    // This will throw ArgumentOutOfRangeException
    var invalidMeasurement = new PtsMeasurementValue(50);
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"Invalid measurement: {ex.Message}");
}
```

## Integration with Typed Instructions

Field instructions can be converted to strongly-typed versions using the `TypedFieldInstructionFactory`:

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction.Typed;

// Create generic field instruction
var genericField = new FieldInstruction("REF");
genericField.Arguments.Add(new FieldArgument(FieldArgumentType.Identifier, "MyBookmark"));

// Convert to strongly-typed (if supported)
var typedField = TypedFieldInstructionFactory.Create(genericField);

if (typedField is RefFieldInstruction refInstruction)
{
    Console.WriteLine($"Bookmark: {refInstruction.BookmarkName}");
}
```

### Supported Field Types for Typed Instructions

The `TypedFieldInstructionFactory` supports over 60 field instruction types, providing strongly-typed access to field-specific properties and switches:

#### Document Information Fields

- `AUTHOR` → `AuthorFieldInstruction`
- `COMMENTS` → `CommentsFieldInstruction`
- `CREATEDATE` → `CreateDateFieldInstruction`
- `EDITTIME` → `EditTimeFieldInstruction`
- `FILENAME` → `FileNameFieldInstruction`
- `FILESIZE` → `FileSizeFieldInstruction`
- `KEYWORDS` → `KeywordsFieldInstruction`
- `LASTSAVEDBY` → `LastSavedByFieldInstruction`
- `NUMCHARS` → `NumCharsFieldInstruction`
- `NUMPAGES` → `NumPagesFieldInstruction`
- `NUMWORDS` → `NumWordsFieldInstruction`
- `REVNUM` → `RevNumFieldInstruction`
- `SAVEDATE` → `SaveDateFieldInstruction`
- `SUBJECT` → `SubjectFieldInstruction`
- `TEMPLATE` → `TemplateFieldInstruction`
- `TITLE` → `TitleFieldInstruction`

#### Date and Time Fields

- `DATE` → `DateFieldInstruction`
- `PRINTDATE` → `PrintDateFieldInstruction`
- `TIME` → `TimeFieldInstruction`

#### Mail Merge Fields

- `ADDRESSBLOCK` → `AddressBlockFieldInstruction`
- `GREETINGLINE` → `GreetingLineFieldInstruction`
- `MERGEFIELD` → `MergeFieldFieldInstruction`
- `MERGEREC` → `MergeRecFieldInstruction`
- `MERGESEQ` → `MergeSeqFieldInstruction`
- `NEXT` → `NextFieldInstruction`
- `NEXTIF` → `NextIfFieldInstruction`
- `SKIPIF` → `SkipIfFieldInstruction`

#### Reference Fields

- `REF` → `RefFieldInstruction`
- `PAGEREF` → `PageRefFieldInstruction`
- `STYLEREF` → `StyleRefFieldInstruction`
- `NOTEREF` → `NoteRefFieldInstruction`

#### Page and Section Fields

- `PAGE` → `PageFieldInstruction`
- `SECTION` → `SectionFieldInstruction`
- `SECTIONPAGES` → `SectionPagesFieldInstruction`

#### Numbering Fields

- `AUTONUM` → `AutoNumFieldInstruction`
- `AUTONUMLGL` → `AutoNumLglFieldInstruction`
- `AUTONUMOUT` → `AutoNumOutFieldInstruction`
- `LISTNUM` → `ListNumFieldInstruction`
- `SEQ` → `SeqFieldInstruction`

#### Index and Table Fields

- `INDEX` → `IndexFieldInstruction`
- `TOC` → `TocFieldInstruction`
- `TOA` → `ToaFieldInstruction`
- `XE` → `XeFieldInstruction`
- `TA` → `TaFieldInstruction`
- `TC` → `TcFieldInstruction`

#### Form Fields

- `FORMCHECKBOX` → `FormCheckBoxFieldInstruction`
- `FORMDROPDOWN` → `FormDropDownFieldInstruction`
- `FORMTEXT` → `FormTextFieldInstruction`

#### User Information Fields

- `USERNAME` → `UserNameFieldInstruction`
- `USERINITIALS` → `UserInitialsFieldInstruction`
- `USERADDRESS` → `UserAddressFieldInstruction`

#### Interactive Fields

- `ASK` → `AskFieldInstruction`
- `FILLIN` → `FillInFieldInstruction`

#### Button Fields

- `GOTOBUTTON` → `GoToButtonFieldInstruction`
- `MACROBUTTON` → `MacroButtonFieldInstruction`

#### Advanced Fields

- `DATABASE` → `DatabaseFieldInstruction`
- `EQ` → `EqFieldInstruction`
- `HYPERLINK` → `HyperlinkFieldInstruction`
- `QUOTE` → `QuoteFieldInstruction`

#### Conditional Fields

- `IF` → `IfFieldInstruction`
- `COMPARE` → `CompareFieldInstruction`

#### Other Fields

- `ADVANCE` → `AdvanceFieldInstruction`
- `AUTOTEXT` → `AutoTextFieldInstruction`
- `AUTOTEXTLIST` → `AutoTextListFieldInstruction`
- `BARCODE` → `BarcodeFieldInstruction`
- `BIBLIOGRAPHY` → `BibliographyFieldInstruction`
- `CITATION` → `CitationFieldInstruction`
- `DOCPROPERTY` → `DocPropertyFieldInstruction`
- `DOCVARIABLE` → `DocVariableFieldInstruction`
- `INCLUDEPICTURE` → `IncludePictureFieldInstruction`
- `INCLUDETEXT` → `IncludeTextFieldInstruction`
- `INFO` → `InfoFieldInstruction`
- `LINK` → `LinkFieldInstruction`
- `PRINT` → `PrintFieldInstruction`
- `RD` → `RdFieldInstruction`
- `SET` → `SetFieldInstruction`
- `SYMBOL` → `SymbolFieldInstruction`

### Factory Usage Examples

```csharp
// Mail merge field with formatting
var mergeField = new FieldInstruction("MERGEFIELD");
mergeField.Arguments.Add(new FieldArgument(FieldArgumentType.Identifier, "FirstName"));
mergeField.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\* Upper"));

var typedMerge = TypedFieldInstructionFactory.Create(mergeField) as MergeFieldFieldInstruction;
if (typedMerge != null)
{
    Console.WriteLine($"Field Name: {typedMerge.FieldName}");
    Console.WriteLine($"Text Format: {typedMerge.TextFormat}");
}

// Date field with custom format
var dateField = new FieldInstruction("DATE");
dateField.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\@ "MMMM d, yyyy""));

var typedDate = TypedFieldInstructionFactory.Create(dateField) as DateFieldInstruction;
if (typedDate != null)
{
    Console.WriteLine($"Date Format: {typedDate.DateFormat}");
}

// Hyperlink field
var hyperlinkField = new FieldInstruction("HYPERLINK");
hyperlinkField.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, "http://example.com"));
hyperlinkField.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\o "Tooltip text""));

var typedHyperlink = TypedFieldInstructionFactory.Create(hyperlinkField) as HyperlinkFieldInstruction;
if (typedHyperlink != null)
{
    Console.WriteLine($"URL: {typedHyperlink.Url}");
    Console.WriteLine($"Screen Tip: {typedHyperlink.ScreenTip}");
}
```

## Advanced Usage Patterns

### Field Instruction Parsing from Text

The library provides robust parsing capabilities for field instructions:

```csharp
// Parse complex nested fields
var complexField = "IF { MERGEFIELD Amount } > { QUOTE 1000 } "Large Order" "Standard Order"";
var instruction = FieldInstructionParser.Parse(complexField);

Console.WriteLine($"Instruction: {instruction.Instruction}"); // "IF"
Console.WriteLine($"Arguments: {instruction.Arguments.Count}"); // Number of parsed arguments

// Access nested fields
foreach (var arg in instruction.Arguments)
{
    if (arg.Type == FieldArgumentType.NestedField && arg.Value is FieldInstruction nested)
    {
        Console.WriteLine($"Nested: {nested.Instruction} - {nested.Arguments.Count} args");
    }
}
```

### Dynamic Field Construction

Build field instructions programmatically based on runtime conditions:

```csharp
public FieldInstruction CreateConditionalMergeField(string fieldName, string condition, string trueValue, string falseValue)
{
    var ifField = new FieldInstruction("IF");

    // Create nested MERGEFIELD
    var mergeField = new FieldInstruction("MERGEFIELD");
    mergeField.Arguments.Add(new FieldArgument(FieldArgumentType.Identifier, fieldName));

    // Add arguments to IF field
    ifField.Arguments.Add(new FieldArgument(FieldArgumentType.NestedField, mergeField));
    ifField.Arguments.Add(new FieldArgument(FieldArgumentType.Text, condition));
    ifField.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, trueValue));
    ifField.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, falseValue));

    return ifField;
}

// Usage
var conditionalField = CreateConditionalMergeField("Status", "> 5", "Active", "Inactive");
Console.WriteLine(conditionalField.ToString());
// "IF { MERGEFIELD Status } > 5 "Active" "Inactive""
```

### Field Instruction Validation

Implement validation for field-specific requirements:

```csharp
public bool ValidateFieldInstruction(FieldInstruction instruction)
{
    switch (instruction.Instruction.ToUpperInvariant())
    {
        case "MERGEFIELD":
            // MERGEFIELD requires at least one identifier argument
            return instruction.Arguments.Any(arg => arg.Type == FieldArgumentType.Identifier);

        case "REF":
        case "PAGEREF":
            // Reference fields require a bookmark name
            return instruction.Arguments.Any(arg => arg.Type == FieldArgumentType.Identifier);

        case "DATE":
        case "TIME":
            // Date/time fields can have format switches
            var hasValidFormat = true;
            foreach (var arg in instruction.Arguments.Where(a => a.Type == FieldArgumentType.Switch))
            {
                if (arg.Value.ToString().StartsWith("\@"))
                {
                    // Validate date format syntax here
                    hasValidFormat = ValidateDateFormat(arg.Value.ToString());
                }
            }
            return hasValidFormat;

        default:
            return true; // Unknown fields are considered valid
    }
}

private bool ValidateDateFormat(string formatSwitch)
{
    // Extract format string and validate
    // Implementation would check for valid date/time format patterns
    return !string.IsNullOrEmpty(formatSwitch);
}
```

### Field Instruction Transformation

Transform field instructions for different document contexts:

```csharp
public FieldInstruction TransformForMailMerge(FieldInstruction original)
{
    // Clone the original instruction
    var transformed = new FieldInstruction(original.Instruction);

    foreach (var arg in original.Arguments)
    {
        var newArg = arg;

        // Transform specific argument types
        if (arg.Type == FieldArgumentType.Identifier)
        {
            // Prefix field names for mail merge context
            var fieldName = arg.Value.ToString();
            newArg = new FieldArgument(FieldArgumentType.Identifier, $"MailMerge_{fieldName}");
        }
        else if (arg.Type == FieldArgumentType.NestedField && arg.Value is FieldInstruction nestedField)
        {
            // Recursively transform nested fields
            newArg = new FieldArgument(FieldArgumentType.NestedField, TransformForMailMerge(nestedField));
        }

        transformed.Arguments.Add(newArg);
    }

    return transformed;
}
```

### Batch Field Processing

Process multiple field instructions efficiently:

```csharp
public class FieldInstructionProcessor
{
    private readonly Dictionary<string, Func<FieldInstruction, string>> _processors;

    public FieldInstructionProcessor()
    {
        _processors = new Dictionary<string, Func<FieldInstruction, string>>
        {
            ["MERGEFIELD"] = ProcessMergeField,
            ["DATE"] = ProcessDateField,
            ["REF"] = ProcessRefField,
            ["HYPERLINK"] = ProcessHyperlinkField
        };
    }

    public List<string> ProcessFields(IEnumerable<FieldInstruction> fields)
    {
        var results = new List<string>();

        foreach (var field in fields)
        {
            if (_processors.TryGetValue(field.Instruction.ToUpperInvariant(), out var processor))
            {
                results.Add(processor(field));
            }
            else
            {
                results.Add($"Unsupported field: {field.Instruction}");
            }
        }

        return results;
    }

    private string ProcessMergeField(FieldInstruction field)
    {
        var typedField = TypedFieldInstructionFactory.Create(field) as MergeFieldFieldInstruction;
        return typedField != null
            ? $"Merge field for: {typedField.FieldName}"
            : "Invalid merge field";
    }

    private string ProcessDateField(FieldInstruction field)
    {
        var typedField = TypedFieldInstructionFactory.Create(field) as DateFieldInstruction;
        return typedField != null
            ? $"Date field with format: {typedField.DateFormat ?? "default"}"
            : "Invalid date field";
    }

    // Additional processors...
    private string ProcessRefField(FieldInstruction field) => "Reference field processed";
    private string ProcessHyperlinkField(FieldInstruction field) => "Hyperlink field processed";
}
```

### Field Instruction Serialization

Serialize field instructions for storage or transmission:

```csharp
public class FieldInstructionSerializer
{
    public string SerializeToJson(FieldInstruction instruction)
    {
        var data = new
        {
            Instruction = instruction.Instruction,
            Arguments = instruction.Arguments.Select(arg => new
            {
                Type = arg.Type.ToString(),
                Value = arg.Type == FieldArgumentType.NestedField && arg.Value is FieldInstruction nested
                    ? SerializeToJson(nested)
                    : arg.Value.ToString()
            }).ToArray()
        };

        return System.Text.Json.JsonSerializer.Serialize(data);
    }

    public FieldInstruction DeserializeFromJson(string json)
    {
        using var document = System.Text.Json.JsonDocument.Parse(json);
        var root = document.RootElement;

        var instruction = new FieldInstruction(root.GetProperty("Instruction").GetString());

        foreach (var argElement in root.GetProperty("Arguments").EnumerateArray())
        {
            var type = Enum.Parse<FieldArgumentType>(argElement.GetProperty("Type").GetString());
            var value = argElement.GetProperty("Value").GetString();

            if (type == FieldArgumentType.NestedField)
            {
                var nestedField = DeserializeFromJson(value);
                instruction.Arguments.Add(new FieldArgument(type, nestedField));
            }
            else
            {
                instruction.Arguments.Add(new FieldArgument(type, value));
            }
        }

        return instruction;
    }
}
```

## Technical Details

- Field instructions are mutable objects that can be modified after creation
- Arguments list can be manipulated directly (add, remove, modify)
- ToString() method reconstructs valid field instruction syntax
- All string values are properly escaped when reconstructed
- Nested fields are formatted with proper brace spacing
- The component includes comprehensive enumerations for Word-specific values
- Field instruction parsing handles complex nested structures and quoted strings
- Memory-efficient argument storage using object references
- Thread-safe factory methods for typed instruction creation

## See Also

- [Typed Field Instructions](./Typed.md) - Strongly-typed field instruction factory
- [Testing Documentation](../../../development/test.md) - Unit test examples

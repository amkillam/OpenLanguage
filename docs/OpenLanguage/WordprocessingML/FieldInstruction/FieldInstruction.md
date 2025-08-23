# Field Instructions

The `OpenLanguage.WordprocessingML.FieldInstruction` namespace provides classes for creating and manipulating Microsoft Word field instructions.

## Overview

This component provides:

- **Field Instruction Creation**: Build field instructions programmatically
- **Argument Handling**: Support for different argument types (identifiers, strings, switches, nested fields)
- **Field Reconstruction**: Convert field objects back to field code strings
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

// Reconstruct field code
Console.WriteLine(instruction.ToString()); // "MERGEFIELD FirstName \* Upper"
```

#### Properties and Methods

- `string Instruction` - The field keyword (e.g., "MERGEFIELD", "REF", "IF")
- `List<FieldArgument> Arguments` - List of field arguments that can be modified
- `ToString()` - Reconstructs the field code string

### FieldArgument

Represents a single argument within a field instruction.

```csharp
public class FieldArgument
{
    public FieldArgumentType Type { get; }    // Type of argument
    public object Value { get; }              // Argument value

    public override string ToString()         // Reconstructs argument as field code
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

Field instructions can be converted to strongly-typed versions:

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction.Typed;

// Create generic field instruction
var genericField = new FieldInstruction("REF");
genericField.Arguments.Add(new FieldArgument(FieldArgumentType.Identifier, "MyBookmark"));

// Convert to strongly-typed (if supported)
var typedField = TypedFieldInstructionFactory.Create(genericField);

if (typedField is RefInstruction refInstruction)
{
    Console.WriteLine($"Bookmark: {refInstruction.BookmarkName}");
}
```

## Technical Details

- Field instructions are mutable objects that can be modified after creation
- Arguments list can be manipulated directly (add, remove, modify)
- ToString() method reconstructs valid field code syntax
- All string values are properly escaped when reconstructed
- Nested fields are formatted with proper brace spacing
- The component includes comprehensive enumerations for Word-specific values

## See Also

- [Typed Field Instructions](./Typed.md) - Strongly-typed field instruction factory
- [Testing Documentation](../../../advanced/testing.md) - Unit test examples

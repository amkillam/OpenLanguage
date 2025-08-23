# Typed Field Instructions

The typed field instruction system provides a factory pattern for converting generic `FieldInstruction` objects into strongly-typed representations.

## Overview

The typed system offers:

- **Factory Pattern**: Convert generic field instructions to strongly-typed objects
- **Base Class**: Common base for all typed field instructions
- **Limited Implementation**: Currently supports only REF fields with basic functionality

## Core Classes

### TypedFieldInstruction

Base class for all strongly-typed field instructions:

```csharp
public class TypedFieldInstruction
{
    public FieldInstruction Source { get; }    // Original field instruction

    protected TypedFieldInstruction(FieldInstruction source)

    public override string ToString()          // Default implementation
}
```

## Implemented Typed Fields

### RefInstruction

Strongly-typed REF field for cross-references:

```csharp
public class RefInstruction : TypedFieldInstruction
{
    public string BookmarkName { get; set; }           // The bookmark being referenced
    public FieldArgument? FormattingSwitch { get; set; } // Optional formatting switch

    public RefInstruction(FieldInstruction source)     // Constructor validates arguments
}
```

#### Usage Example

```csharp
// Create a generic REF field instruction
var genericRef = new FieldInstruction("REF");
genericRef.Arguments.Add(new FieldArgument(FieldArgumentType.Identifier, "MyBookmark"));
genericRef.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\* MERGEFORMAT"));

// Convert to strongly-typed
var typedRef = new RefInstruction(genericRef);
Console.WriteLine($"Bookmark: {typedRef.BookmarkName}");        // "MyBookmark"
Console.WriteLine($"Switch: {typedRef.FormattingSwitch?.Value}"); // "\* MERGEFORMAT"
```

## TypedFieldInstructionFactory

Factory class for creating strongly-typed field instructions from generic ones:

```csharp
public static class TypedFieldInstructionFactory
{
    public static TypedFieldInstruction? Create(FieldInstruction genericInstruction)
}
```

### Supported Field Types

The factory currently recognizes these field instruction types:

- **REF**: Returns `RefInstruction` for cross-references
- **70+ Other Types**: The factory includes cases for many field types, but most return `null` (not implemented)

#### Example Usage

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction.Typed;

// Create a generic field instruction
var genericField = new FieldInstruction("REF");
genericField.Arguments.Add(new FieldArgument(FieldArgumentType.Identifier, "SectionTitle"));

// Convert to strongly-typed
var typedField = TypedFieldInstructionFactory.Create(genericField);

if (typedField is RefInstruction refField)
{
    Console.WriteLine($"This is a REF field pointing to: {refField.BookmarkName}");
}
else if (typedField == null)
{
    Console.WriteLine("Field type not supported or invalid arguments");
}
```

## Field Type Recognition

The factory recognizes field types by their instruction string (case-insensitive):

### Recognized Field Types

```csharp
// These field types are recognized but most return null (not implemented):
"ADDRESSBLOCK", "ADVANCE", "ASK", "AUTHOR", "AUTONUM", "AUTONUMLGL",
"AUTONUMOUT", "AUTOTEXT", "AUTOTEXTLIST", "BARCODE", "BIBLIOGRAPHY",
"CITATION", "COMMENTS", "COMPARE", "CREATEDATE", "DATABASE", "DATE",
"DOCPROPERTY", "DOCVARIABLE", "EDITTIME", "EQ", "FILENAME", "FILESIZE",
"FILLIN", "FORMCHECKBOX", "FORMDROPDOWN", "FORMTEXT", "GOTOBUTTON",
"GREETINGLINE", "HYPERLINK", "IF", "INCLUDEPICTURE", "INCLUDETEXT",
"INDEX", "INFO", "KEYWORDS", "LASTSAVEDBY", "LINK", "LISTNUM",
"MACROBUTTON", "MERGEFIELD", "MERGEREC", "MERGESEQ", "NEXT", "NEXTIF",
"NOTEREF", "NUMCHARS", "NUMPAGES", "NUMWORDS", "PAGE", "PAGEREF",
"PRINT", "PRINTDATE", "QUOTE", "RD", "REF", "REVNUM", "SAVEDATE",
"SECTION", "SECTIONPAGES", "SEQ", "SET", "SKIPIF", "STYLEREF",
"SUBJECT", "SYMBOL", "TA", "TC", "TEMPLATE", "TIME", "TITLE", "TOA",
"TOC", "USERADDRESS", "USERINITIALS", "USERNAME", "XE"
```

### Error Handling

```csharp
// Invalid field arguments will cause the factory to return null
var invalidRef = new FieldInstruction("REF"); // Missing bookmark argument
var result = TypedFieldInstructionFactory.Create(invalidRef);
Console.WriteLine(result == null); // True - invalid REF field

// ArgumentException is caught and null is returned
var malformedField = new FieldInstruction("REF");
malformedField.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\h")); // Wrong argument type
var result2 = TypedFieldInstructionFactory.Create(malformedField);
Console.WriteLine(result2 == null); // True
```

## Current Limitations

The typed field instruction system is currently in early development:

### Limited Implementation

- Only `RefInstruction` is fully implemented
- Most field types return `null` from the factory
- No fluent interface or advanced features

### RefInstruction Validation

The `RefInstruction` constructor validates that:

- The source field instruction is "REF"
- The first argument is an `Identifier` type (the bookmark name)
- Optionally finds formatting switches that start with `\*`

```csharp
// Valid REF field
var validRef = new FieldInstruction("REF");
validRef.Arguments.Add(new FieldArgument(FieldArgumentType.Identifier, "BookmarkName"));
var typed = new RefInstruction(validRef); // Success

// Invalid REF field - will throw ArgumentException
var invalidRef = new FieldInstruction("REF");
// Missing bookmark argument
var typed2 = new RefInstruction(invalidRef); // Throws ArgumentException
```

## Usage Patterns

### Basic Factory Usage

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction;
using OpenLanguage.WordprocessingML.FieldInstruction.Typed;

// Create a generic field
var genericField = new FieldInstruction("REF");
genericField.Arguments.Add(new FieldArgument(FieldArgumentType.Identifier, "Introduction"));

// Try to convert to typed version
var typedField = TypedFieldInstructionFactory.Create(genericField);

if (typedField != null)
{
    Console.WriteLine($"Created typed field: {typedField.GetType().Name}");

    // Cast to specific type if needed
    if (typedField is RefInstruction refField)
    {
        Console.WriteLine($"References bookmark: {refField.BookmarkName}");

        // Access the original field instruction
        Console.WriteLine($"Original field code: {refField.Source.ToString()}");
    }
}
else
{
    Console.WriteLine("Field type not supported or invalid");
}
```

### Batch Processing

```csharp
// Process multiple field instructions
var fieldInstructions = new List<FieldInstruction>
{
    CreateRefField("Bookmark1"),
    CreateRefField("Bookmark2"),
    CreateMergeField("FirstName"), // This will return null
};

foreach (var generic in fieldInstructions)
{
    var typed = TypedFieldInstructionFactory.Create(generic);

    if (typed != null)
    {
        Console.WriteLine($"Successfully typed: {generic.Instruction}");
    }
    else
    {
        Console.WriteLine($"Not supported: {generic.Instruction}");
    }
}
```

## Future Development

The typed field instruction system is designed for future expansion:

- Additional field types can be added by implementing new classes that inherit from `TypedFieldInstruction`
- The factory can be extended with more case statements
- Validation logic can be enhanced for each field type
- More sophisticated APIs can be built on top of the base classes

## Technical Details

- The factory uses case-insensitive string matching for field instruction types
- Exception handling ensures that invalid arguments don't crash the factory
- The base `TypedFieldInstruction` class provides access to the original `FieldInstruction` via the `Source` property
- Typed instructions inherit `ToString()` behavior from the base class, which returns the instruction name by default

## See Also

- [Field Instructions](./FieldInstruction.md) - Basic field instruction creation and manipulation
- [Unit Tests](../../../OpenLanguage.Test/WordprocessingML/FieldInstruction/TypedFieldInstructionTests.cs) - Examples of testing typed instructions

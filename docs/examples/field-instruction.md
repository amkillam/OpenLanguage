# Field Instruction Examples

This document demonstrates how to use the OpenLanguage WordprocessingML FieldInstruction parser to parse and manipulate Microsoft Word field instructions.

## Basic Usage

### Parsing Simple Field Instructions

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction;

// Parse a simple MERGEFIELD instruction
FieldInstruction mergeField = FieldParser.Parse("MERGEFIELD FirstName");
Console.WriteLine($"Instruction: {mergeField.Instruction}");
Console.WriteLine($"Arguments count: {mergeField.Arguments.Count}");
Console.WriteLine($"Reconstructed: {mergeField}");

// Parse a field with switches
FieldInstruction dateField = FieldParser.Parse("DATE \@ "MMMM d, yyyy"");
Console.WriteLine($"Date field: {dateField}");
```

### Safe Parsing with TryParse

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction;

string[] fieldCodes = {
    "MERGEFIELD LastName",
    "IF { MERGEFIELD Age } > 18 "Adult" "Minor"",
    "INVALID_FIELD_CODE",
    "HYPERLINK "https://example.com" "Click here""
};

foreach (string fieldCode in fieldCodes)
{
    FieldInstruction? result = FieldParser.TryParse(fieldCode);
    if (result != null)
    {
        Console.WriteLine($"✓ Successfully parsed: {result.Instruction}");
        Console.WriteLine($"  Arguments: {result.Arguments.Count}");
    }
    else
    {
        Console.WriteLine($"✗ Failed to parse: {fieldCode}");
    }
}
```

## Common Field Types

### MERGEFIELD Instructions

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction;

// Simple merge field
FieldInstruction simpleMerge = FieldParser.Parse("MERGEFIELD CustomerName");

// Merge field with formatting switch
FieldInstruction formattedMerge = FieldParser.Parse("MERGEFIELD OrderDate \@ "dddd, MMMM dd, yyyy"");

// Merge field with text formatting switches
FieldInstruction textMerge = FieldParser.Parse("MERGEFIELD CompanyName \* Upper \* FirstCap");

Console.WriteLine($"Simple merge: {simpleMerge}");
Console.WriteLine($"Formatted merge: {formattedMerge}");
Console.WriteLine($"Text formatted: {textMerge}");
```

### HYPERLINK Instructions

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction;

// Basic hyperlink
FieldInstruction basicLink = FieldParser.Parse("HYPERLINK "https://www.example.com"");

// Hyperlink with display text
FieldInstruction linkWithText = FieldParser.Parse("HYPERLINK "https://www.example.com" "Visit Example"");

// Hyperlink with switches
FieldInstruction linkWithSwitch = FieldParser.Parse("HYPERLINK "mailto:user@example.com" \o "Send email"");

Console.WriteLine($"Basic link: {basicLink}");
Console.WriteLine($"Link with text: {linkWithText}");
Console.WriteLine($"Link with switch: {linkWithSwitch}");
```

### IF Instructions

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction;

// Simple IF field
FieldInstruction simpleIf = FieldParser.Parse("IF 1 = 1 "True" "False"");

// IF field with nested MERGEFIELD
FieldInstruction nestedIf = FieldParser.Parse("IF { MERGEFIELD Age } > 18 "Adult" "Minor"");

// Complex IF with comparison operators
FieldInstruction complexIf = FieldParser.Parse("IF { MERGEFIELD Salary } >= 50000 "High earner" "Standard earner"");

Console.WriteLine($"Simple IF: {simpleIf}");
Console.WriteLine($"Nested IF: {nestedIf}");
Console.WriteLine($"Complex IF: {complexIf}");
```

### DATE and TIME Instructions

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction;

// Current date
FieldInstruction currentDate = FieldParser.Parse("DATE");

// Formatted date
FieldInstruction formattedDate = FieldParser.Parse("DATE \@ "MMMM d, yyyy"");

// Time field
FieldInstruction timeField = FieldParser.Parse("TIME \@ "h:mm AM/PM"");

// Creation time
FieldInstruction createTime = FieldParser.Parse("CREATEDATE \@ "MM/dd/yyyy h:mm AM/PM"");

Console.WriteLine($"Current date: {currentDate}");
Console.WriteLine($"Formatted date: {formattedDate}");
Console.WriteLine($"Time: {timeField}");
Console.WriteLine($"Creation time: {createTime}");
```

### DOCPROPERTY Instructions

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction;

// Document properties
FieldInstruction author = FieldParser.Parse("DOCPROPERTY Author");
FieldInstruction title = FieldParser.Parse("DOCPROPERTY Title");
FieldInstruction company = FieldParser.Parse("DOCPROPERTY Company");

// Custom properties
FieldInstruction customProp = FieldParser.Parse("DOCPROPERTY "Project Name"");

Console.WriteLine($"Author: {author}");
Console.WriteLine($"Title: {title}");
Console.WriteLine($"Company: {company}");
Console.WriteLine($"Custom property: {customProp}");
```

## Working with Arguments

### Accessing Field Arguments

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction;

FieldInstruction field = FieldParser.Parse("MERGEFIELD FirstName \* Upper \b "Default Text"");

Console.WriteLine($"Instruction: {field.Instruction}");
Console.WriteLine($"Number of arguments: {field.Arguments.Count}");

foreach (var arg in field.Arguments)
{
    Console.WriteLine($"  Type: {arg.Type}, Value: {arg.Value}");
}
```

### Modifying Field Arguments

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction;

// Parse an existing field
FieldInstruction field = FieldParser.Parse("MERGEFIELD CustomerName");

// Add formatting switches
field.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\* Upper"));
field.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\* FirstCap"));

// Add default text
field.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, "Unknown Customer"));

Console.WriteLine($"Modified field: {field}");
```

### Working with String Literals

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction;

// Field with quoted strings
FieldInstruction quotedField = FieldParser.Parse("HYPERLINK "https://example.com" "Visit "Example" Site"");

foreach (var arg in quotedField.Arguments)
{
    if (arg.Type == FieldArgumentType.StringLiteral)
    {
        Console.WriteLine($"String literal: {arg.Value}");
        Console.WriteLine($"Reconstructed: {arg}"); // Shows proper escaping
    }
}
```

## Advanced Examples

### Nested Field Instructions

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction;

// Complex nested field
string complexField = "IF { MERGEFIELD Department } = "Sales" { MERGEFIELD SalesBonus } { MERGEFIELD StandardBonus }";
FieldInstruction nested = FieldParser.Parse(complexField);

Console.WriteLine($"Nested field: {nested}");

// Access nested instructions
foreach (var arg in nested.Arguments)
{
    if (arg.Type == FieldArgumentType.NestedField && arg.Value is FieldInstruction nestedInstruction)
    {
        Console.WriteLine($"  Nested instruction: {nestedInstruction.Instruction}");
    }
}
```

### ADDRESSBLOCK Instructions

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction;

// Address block with formatting
FieldInstruction addressBlock = FieldParser.Parse("ADDRESSBLOCK \c 2 \d \e "United States" \f ""<<_RETURN_>>""");

Console.WriteLine($"Address block: {addressBlock}");

// Address block with language formatting
FieldInstruction addressLang = FieldParser.Parse("ADDRESSBLOCK \c 1 \l 1033");
Console.WriteLine($"Address with language: {addressLang}");
```

### GREETINGLINE Instructions

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction;

// Standard greeting line
FieldInstruction greeting = FieldParser.Parse("GREETINGLINE \f "Dear" \l "," \e "Dear Sir or Madam,"");

Console.WriteLine($"Greeting line: {greeting}");

// Custom greeting format
FieldInstruction customGreeting = FieldParser.Parse("GREETINGLINE \f "Hello" \l "!" \e "Hello there!"");
Console.WriteLine($"Custom greeting: {customGreeting}");
```

### DATABASE Instructions

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction;

// Database field with connection string
FieldInstruction database = FieldParser.Parse("DATABASE \d "Data Source=server;Initial Catalog=db;" \s "SELECT * FROM customers" \t 5");

Console.WriteLine($"Database field: {database}");
```

## Working with Switches

### Common Formatting Switches

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction;

// Date formatting switches
FieldInstruction dateFormat = FieldParser.Parse("DATE \@ "dddd, MMMM dd, yyyy"");

// Numeric formatting switches
FieldInstruction numFormat = FieldParser.Parse("MERGEFIELD Amount \# "$#,##0.00"");

// Text formatting switches
FieldInstruction textFormat = FieldParser.Parse("MERGEFIELD Name \* Upper \* FirstCap");

Console.WriteLine($"Date format: {dateFormat}");
Console.WriteLine($"Number format: {numFormat}");
Console.WriteLine($"Text format: {textFormat}");
```

### Custom Switch Processing

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction;

FieldInstruction field = FieldParser.Parse("MERGEFIELD Data \@ "custom format" \* Upper \b "default"");

// Process switches
foreach (var arg in field.Arguments)
{
    if (arg.Type == FieldArgumentType.Switch)
    {
        string switchValue = arg.Value?.ToString() ?? "";
        if (switchValue.StartsWith("\@"))
        {
            Console.WriteLine($"Found date/numeric format switch: {switchValue}");
        }
        else if (switchValue.StartsWith("\*"))
        {
            Console.WriteLine($"Found text format switch: {switchValue}");
        }
        else if (switchValue.StartsWith("\b"))
        {
            Console.WriteLine($"Found bookmark/default switch: {switchValue}");
        }
    }
}
```

## Field Reconstruction and Modification

### Rebuilding Fields

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction;

// Parse a simple field
FieldInstruction original = FieldParser.Parse("MERGEFIELD FirstName");

// Modify the instruction
original.Instruction = "MERGEFIELD";
original.Arguments.Clear();
original.Arguments.Add(new FieldArgument(FieldArgumentType.Identifier, "LastName"));
original.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\* Upper"));

string rebuilt = original.ToString();
Console.WriteLine($"Rebuilt field: {rebuilt}");

// Verify it parses correctly
FieldInstruction verified = FieldParser.Parse(rebuilt);
Console.WriteLine($"Verification successful: {verified}");
```

### Creating Fields Programmatically

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction;

// Create a new HYPERLINK field
FieldInstruction hyperlink = new FieldInstruction("HYPERLINK");
hyperlink.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, "https://www.example.com"));
hyperlink.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, "Visit Example Site"));
hyperlink.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\o"));
hyperlink.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, "Example tooltip"));

Console.WriteLine($"Created hyperlink: {hyperlink}");

// Create a complex IF field
FieldInstruction ifField = new FieldInstruction("IF");
ifField.Arguments.Add(new FieldArgument(FieldArgumentType.Identifier, "1"));
ifField.Arguments.Add(new FieldArgument(FieldArgumentType.Identifier, "="));
ifField.Arguments.Add(new FieldArgument(FieldArgumentType.Identifier, "1"));
ifField.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, "True"));
ifField.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, "False"));

Console.WriteLine($"Created IF field: {ifField}");
```

## Error Handling

### Handling Parse Errors

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction;
using System;

string[] invalidFields = {
    "",                    // Empty field
    "   ",                // Whitespace only
    "MERGEFIELD",         // Missing required argument
    "{ UNCLOSED",         // Unclosed brace
};

foreach (string fieldCode in invalidFields)
{
    try
    {
        FieldInstruction result = FieldParser.Parse(fieldCode);
        Console.WriteLine($"Unexpectedly succeeded: {result}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Expected error for '{fieldCode}': {ex.Message}");
    }
}
```

This comprehensive example demonstrates the core functionality of the OpenLanguage FieldInstruction parser, showing how to parse, manipulate, and reconstruct Microsoft Word field instructions.

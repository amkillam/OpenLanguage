# Field Instruction Examples

This document demonstrates how to use the OpenLanguage WordprocessingML FieldInstruction parser to parse and manipulate Microsoft Word field instructions.

## Basic Usage

### Parsing Simple Field Instructions

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction;
using OpenLanguage.WordprocessingML.FieldInstruction.Ast;
using OpenLanguage.WordprocessingML.Ast;

// Parse a simple MERGEFIELD instruction
var ast = FieldInstructionParser.Parse("MERGEFIELD FirstName");

if (ast is MergeFieldFieldInstruction mergeField)
{
    Console.WriteLine($"Instruction: {mergeField.Instruction}");
    Console.WriteLine($"Field Name: {mergeField.FieldName}");
    Console.WriteLine($"Reconstructed: {mergeField}");
}

// Parse a field with switches
var dateAst = FieldInstructionParser.Parse(@"DATE \@ ""MMMM d, yyyy""");
if (dateAst is DateFieldInstruction dateField)
{
    Console.WriteLine($"Date field: {dateField}");
    Console.WriteLine($"Date Format: {dateField.DateTimeFormat.Argument}");
}
```

### Safe Parsing with TryParse

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction;
using OpenLanguage.WordprocessingML.Ast;

string[] fieldCodes = {
    "MERGEFIELD LastName",
    @"IF { MERGEFIELD Age } > 18 ""Adult"" ""Minor""",
    "INVALID_FIELD_CODE",
    @"HYPERLINK ""https://example.com"" ""Click here"""
};

foreach (string fieldCode in fieldCodes)
{
    ExpressionNode? result = FieldInstructionParser.TryParse(fieldCode);
    if (result != null)
    {
        Console.WriteLine($"✓ Successfully parsed: {result}");
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
using OpenLanguage.WordprocessingML.FieldInstruction.Ast;

// Simple merge field
var simpleMerge = FieldInstructionParser.Parse("MERGEFIELD CustomerName") as MergeFieldFieldInstruction;

// Merge field with formatting switch
var formattedMerge = FieldInstructionParser.Parse(@"MERGEFIELD OrderDate \@ ""dddd, MMMM dd, yyyy""") as MergeFieldFieldInstruction;

// Merge field with text formatting switches
var textMerge = FieldInstructionParser.Parse("MERGEFIELD CompanyName \\* Upper") as MergeFieldFieldInstruction;

Console.WriteLine($"Simple merge: {simpleMerge}");
Console.WriteLine($"Formatted merge: {formattedMerge}");
Console.WriteLine($"Text formatted: {textMerge}");
```

### HYPERLINK Instructions

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction;
using OpenLanguage.WordprocessingML.FieldInstruction.Ast;

// Basic hyperlink
var basicLink = FieldInstructionParser.Parse(@"HYPERLINK ""https://www.example.com""") as HyperlinkFieldInstruction;

// Hyperlink with display text
var linkWithText = FieldInstructionParser.Parse(@"HYPERLINK ""https://www.example.com"" ""Visit Example""") as HyperlinkFieldInstruction;

// Hyperlink with switches
var linkWithSwitch = FieldInstructionParser.Parse(@"HYPERLINK ""mailto:user@example.com"" \o ""Send email""") as HyperlinkFieldInstruction;

Console.WriteLine($"Basic link: {basicLink}");
Console.WriteLine($"Link with text: {linkWithText}");
Console.WriteLine($"Link with switch: {linkWithSwitch}");
```

### IF Instructions

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction.Ast;
using OpenLanguage.WordprocessingML.FieldInstruction;

// Simple IF field
var simpleIf = FieldInstructionParser.Parse(@"IF 1 = 1 ""True"" ""False""") as IfFieldInstruction;

// IF field with nested MERGEFIELD
var nestedIf = FieldInstructionParser.Parse(@"IF { MERGEFIELD Age } > 18 ""Adult"" ""Minor""") as IfFieldInstruction;

// Complex IF with comparison operators
var complexIf = FieldInstructionParser.Parse(@"IF { MERGEFIELD Salary } >= 50000 ""High earner"" ""Standard earner""") as IfFieldInstruction;

Console.WriteLine($"Simple IF: {simpleIf}");
Console.WriteLine($"Nested IF: {nestedIf}");
Console.WriteLine($"Complex IF: {complexIf}");
```

### DATE and TIME Instructions

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction.Ast;
using OpenLanguage.WordprocessingML.FieldInstruction;

// Current date
var currentDate = FieldInstructionParser.Parse("DATE") as DateFieldInstruction;

// Formatted date
var formattedDate = FieldInstructionParser.Parse(@"DATE \@ ""MMMM d, yyyy""") as DateFieldInstruction;

// Time field
var timeField = FieldInstructionParser.Parse(@"TIME \@ ""h:mm AM/PM""") as TimeFieldInstruction;

// Creation time
var createTime = FieldInstructionParser.Parse(@"CREATEDATE \@ ""MM/dd/yyyy h:mm AM/PM""") as CreateDateFieldInstruction;

Console.WriteLine($"Current date: {currentDate}");
Console.WriteLine($"Formatted date: {formattedDate}");
Console.WriteLine($"Time: {timeField}");
Console.WriteLine($"Creation time: {createTime}");
```

### DOCPROPERTY Instructions

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction.Ast;

// Document properties
var author = FieldInstructionParser.Parse("DOCPROPERTY Author") as DocPropertyFieldInstruction;
var title = FieldInstructionParser.Parse("DOCPROPERTY Title") as DocPropertyFieldInstruction;
var company = FieldInstructionParser.Parse("DOCPROPERTY Company") as DocPropertyFieldInstruction;

// Custom properties
var customProp = FieldInstructionParser.Parse(@"DOCPROPERTY ""Project Name""") as DocPropertyFieldInstruction;

Console.WriteLine($"Author: {author}");
Console.WriteLine($"Title: {title}");
Console.WriteLine($"Company: {company}");
Console.WriteLine($"Custom property: {customProp}");
```

## Working with the AST

### Accessing Field Properties

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction;
using OpenLanguage.WordprocessingML.FieldInstruction.Ast;
using OpenLanguage.WordprocessingML.Ast;

var ast = FieldInstructionParser.Parse(@"MERGEFIELD FirstName \* Upper \b ""Default Text""");

if (ast is MergeFieldFieldInstruction field)
{
    Console.WriteLine($"Instruction: {field.Instruction}");
    Console.WriteLine($"Field Name: {field.FieldName}");
    Console.WriteLine($"General Format: {field.GeneralFormat?.Argument}");
    Console.WriteLine($"Text Before: {field.TextBefore?.Argument}");
}
```

### Modifying the AST

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction;
using OpenLanguage.WordprocessingML.FieldInstruction.Ast;
using OpenLanguage.WordprocessingML.Ast;

// Parse an existing field
var ast = FieldInstructionParser.Parse("MERGEFIELD CustomerName");

if (ast is MergeFieldFieldInstruction field)
{
    // Add a formatting switch
    field.GeneralFormat = new FlaggedArgument<ExpressionNode>(
        new FlagNode(@"\*"),
        new StringLiteralNode("Upper")
    );
    field.Order.Add(MergeFieldArgument.GeneralFormat);

    Console.WriteLine($"Modified field: {field}");
}
```

## Advanced Examples

### Nested Field Instructions

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction;
using OpenLanguage.WordprocessingML.FieldInstruction.Ast;
using OpenLanguage.WordprocessingML.Ast;

// Complex nested field
string complexField = @"IF { MERGEFIELD Department } = ""Sales"" { MERGEFIELD SalesBonus } { MERGEFIELD StandardBonus }";
var ast = FieldInstructionParser.Parse(complexField);

if (ast is IfFieldInstruction ifField)
{
    Console.WriteLine($"Nested field: {ifField}");

    // Access nested instructions
    if (ifField.Condition is EqualNode condition)
    {
        if (condition.LeftOperand is NestedFieldInstruction nested)
        {
            Console.WriteLine($"  Nested instruction: {nested.NestedInstruction}");
        }
    }
}
```

### Error Handling

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
        var result = FieldInstructionParser.Parse(fieldCode);
        Console.WriteLine($"Unexpectedly succeeded: {result}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Expected error for '{fieldCode}': {ex.Message}");
    }
}
```

This comprehensive example demonstrates the core functionality of the OpenLanguage FieldInstruction parser, showing how to parse, manipulate, and reconstruct Microsoft Word field instructions using a strongly-typed AST.

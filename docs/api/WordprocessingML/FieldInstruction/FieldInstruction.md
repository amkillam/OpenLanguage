# Field Instructions

The `OpenLanguage.WordprocessingML.FieldInstruction` namespace provides a robust parser for Microsoft Word field instructions, converting them into a strongly-typed Abstract Syntax Tree (AST).

## Overview

This component provides:

- **Grammar-Based Parsing**: Uses a GPLEX/GPPG parser to accurately parse complex field instructions.
- **Strongly-Typed AST**: Represents each field instruction as a specific C# class, providing type-safe access to its arguments and switches.
- **Complete Support**: Support for all field instructions - both standard ECMA variations and those specified in the ISO docs for legacy compatibility
- **Round-Trip Fidelity**: Parsed ASTs can be converted back to their original string representation, preserving all components.

## Core Classes

### FieldInstructionParser

A static class for parsing field instruction strings.

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction;
using OpenLanguage.WordprocessingML.FieldInstruction.Ast;
using OpenLanguage.WordprocessingML.Ast;

// Parse a field instruction
var ast = FieldInstructionParser.Parse("MERGEFIELD FirstName \\* Upper");

// The result is a strongly-typed AST node
if (ast is MergeFieldFieldInstruction mergeField)
{
    Console.WriteLine($"Field Name: {mergeField.FieldName}");
    if (mergeField.GeneralFormat?.Argument is StringLiteralNode format)
    {
        Console.WriteLine($"General Format: {format.Value}");
    }
}
```

#### Methods

- `Parse(string fieldInstruction)`: Parses a field instruction string and returns the root `ExpressionNode` of the AST. Throws `InvalidOperationException` on failure.
- `TryParse(string fieldInstruction)`: Attempts to parse a field instruction and returns `null` if parsing fails.

### FieldInstruction AST Nodes

The parser generates a tree of nodes, with each field type represented by a specific class inheriting from `OpenLanguage.WordprocessingML.FieldInstruction.Ast.FieldInstruction`. This provides direct, type-safe access to arguments and switches.

**Example Node:** `MergeFieldFieldInstruction`

```csharp
public class MergeFieldFieldInstruction : FieldInstruction
{
    public ExpressionNode FieldName { get; set; }
    public FlaggedArgument<ExpressionNode>? TextBefore { get; set; }
    public FlaggedArgument<ExpressionNode>? TextAfter { get; set; }
    // ... and other properties for switches
}
```

## Supported Field Types

The library provides strongly-typed classes for most Word field instructions. For a complete list, see [Supported Field Instructions](SupportedFields.md). Some examples include:

- `AuthorFieldInstruction`
- `DateFieldInstruction`
- `IfFieldInstruction`
- `MergeFieldFieldInstruction`
- `PageRefFieldInstruction`
- `TocFieldInstruction`

## Usage Examples

### Parsing Common Field Types

#### MERGEFIELD

```csharp
var ast = FieldInstructionParser.Parse(@"MERGEFIELD Amount \# ""$#,##0.00""");
if (ast is MergeFieldFieldInstruction mergeField)
{
    Console.WriteLine($"Field: {mergeField.FieldName}");
    Console.WriteLine($"Numeric Format: {mergeField.NumericFormat.Argument}");
}
```

#### IF

```csharp
var ast = FieldInstructionParser.Parse(@"IF { MERGEFIELD Amount } > 1000 ""High"" ""Low""");
if (ast is IfFieldInstruction ifField)
{
    Console.WriteLine($"Condition: {ifField.Condition}");
    Console.WriteLine($"True Value: {ifField.TrueExpression}");
    Console.WriteLine($"False Value: {ifField.FalseExpression}");
}
```

#### HYPERLINK

```csharp
var ast = FieldInstructionParser.Parse(@"HYPERLINK ""http://example.com"" \o ""Tooltip"" \t ""_blank""");
if (ast is HyperlinkFieldInstruction hyperlink)
{
    Console.WriteLine($"URI: {hyperlink.Uri}");
    Console.WriteLine($"Screen Tip: {hyperlink.ScreenTipText.Argument}");
    Console.WriteLine($"Target: {hyperlink.InstrFrameTarget.Argument}");
}
```

### Working with the AST

The AST is fully navigable and mutable.

```csharp
using OpenLanguage.WordprocessingML.Ast;
using OpenLanguage.WordprocessingML.FieldInstruction.Ast;

var ast = FieldInstructionParser.Parse("PAGE \\* Arabic");

if (ast is PageFieldInstruction pageField)
{
    // Access a property
    Console.WriteLine($"Original format: {pageField.GeneralFormat.Argument}");

    // Modify the AST
    var newFormat = new StringLiteralNode("Roman");
    pageField.GeneralFormat.Argument = newFormat;

    // Reconstruct the field code
    Console.WriteLine($"Modified field: {pageField.ToString()}");
    // Output: Modified field: PAGE \* Roman
}
```

### Nested Fields

The parser correctly handles nested field instructions, representing them as `NestedFieldInstruction` nodes within the parent's AST.

```csharp
var ast = FieldInstructionParser.Parse("IF { COMPARE { REF a } > { REF b } } = 1 \"Greater\" \"Smaller\"");

if (ast is IfFieldInstruction ifField && ifField.Condition is EqualNode condition)
{
    if (condition.LeftOperand is NestedFieldInstruction nested)
    {
        Console.WriteLine($"Nested field type: {nested.NestedInstruction.GetType().Name}");
        // Output: Nested field type: CompareFieldInstruction
    }
}
```

## See Also

- [WordprocessingML Expression Parser](../Expression/Expression.md)
- [WordprocessingML Merge Fields](../MergeField/MergeField.md)
- [WordprocessingML Abstract Syntax Tree](../Ast.md)

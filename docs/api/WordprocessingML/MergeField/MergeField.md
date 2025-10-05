# Merge Field Parser

The `OpenLanguage.WordprocessingML.MergeField` namespace provides parsers for `MERGEFIELD` placeholders and templates containing them.

## Overview

The Merge Field component offers:

- **Placeholder Parsing**: Parse `«MERGEFIELD»` placeholders into an Abstract Syntax Tree (AST).
- **Template Parsing**: Parse strings containing a mix of literal text and merge field placeholders.
- **Grammar-Based**: Uses GPLEX/GPPG for robust and accurate parsing.
- **AST Representation**: Provides a structured tree of nodes for easy manipulation and analysis.

## Core Classes

### MergeFieldParser

A static class for parsing a single `«MERGEFIELD»` placeholder.

```csharp
using OpenLanguage.WordprocessingML.MergeField;
using OpenLanguage.WordprocessingML.Ast;

// Parse a simple merge field
MergeFieldNode mergeField = MergeFieldParser.Parse("«FirstName»");
Console.WriteLine($"Field Name: {mergeField.FieldName}");

// Parse with a formatting switch
MergeFieldNode formatted = MergeFieldParser.Parse(@"«Amount \* MERGEFORMAT»");
Console.WriteLine($"Field Name: {formatted.FieldName}");
Console.WriteLine($"Formatting Switch: {formatted.FormattingSwitch}");
```

#### Methods

- `Parse(string placeholderText)`: Parses a merge field placeholder string and returns a `MergeFieldNode`.
- `TryParse(string placeholderText)`: Attempts to parse a placeholder and returns `null` on failure.

### Template Parsing

The `OpenLanguage.WordprocessingML.MergeFieldTemplate` namespace provides a parser for strings containing a mix of literal text and merge field placeholders. This is used internally by the `FieldInstructionParser` for fields like `ADDRESSBLOCK`.

## AST Nodes

- `MergeFieldNode`: Represents a `«MERGEFIELD»` placeholder parsed by `MergeFieldParser`.
- `TemplateNode`: Represents a parsed template string, containing a list of `TextElementNode` and `MergeFieldElementNode` objects.
- `TextElementNode`: Represents literal text within a template.
- `MergeFieldElementNode`: Represents a merge field placeholder within a template.

## Usage Examples

### Parsing a Single Merge Field

```csharp
using OpenLanguage.WordprocessingML.MergeField;
using OpenLanguage.WordprocessingML.Ast;

var node = MergeFieldParser.Parse(@"«Amount \* MERGEFORMAT»");

Console.WriteLine($"Field Name: {node.FieldName}");
Console.WriteLine($"Formatting Switch: {node.FormattingSwitch}");
Console.WriteLine($"Reconstructed: {node.ToString()}");
```

### Accessing a Parsed Template

Templates are parsed as part of other field instructions, such as `ADDRESSBLOCK`.

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction;
using OpenLanguage.WordprocessingML.FieldInstruction.Ast;
using OpenLanguage.WordprocessingML.Ast;

string fieldCode = @"ADDRESSBLOCK \f ""«FirstName» «LastName»\n«Address»""";
var ast = FieldInstructionParser.Parse(fieldCode);

if (ast is AddressBlockFieldInstruction addressBlock && addressBlock.FormatTemplate?.Argument is Quoted<ExpressionNode> quoted)
{
    if (quoted.Inner is TemplateNode template)
    {
        Console.WriteLine($"Found {template.Elements.Count} elements in template.");
        foreach (var element in template.Elements)
        {
            if (element is MergeFieldElementNode mergeField)
            {
                Console.WriteLine($"  - Merge Field: {mergeField.FieldName}");
            }
            else if (element is TextElementNode text)
            {
                Console.WriteLine($"  - Text: '{text.Text}'");
            }
        }
    }
}
```

## See Also

- [Field Instructions](../FieldInstruction/FieldInstruction.md)
- [Abstract Syntax Tree (AST)](../Ast.md)

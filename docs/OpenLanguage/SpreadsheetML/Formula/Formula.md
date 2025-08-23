# Formula Processing

The `OpenLanguage.SpreadsheetML.Formula` namespace provides comprehensive Excel formula parsing and evaluation capabilities.

## Overview

The Formula component offers:

- **Complete Excel Formula Parsing**: Support for all standard Excel formula syntax
- **Function Categories**: Standard, Future, Command, and Macro functions
- **Grammar-Based Parsing**: Robust YACC/LEX-based parser for accurate syntax analysis
- **Performance Optimized**: High-performance parsing with minimal allocations

## Core Classes

### FormulaParser

The main entry point for formula parsing operations.

```csharp
using OpenLanguage.SpreadsheetML.Formula;

var parser = new FormulaParser();
var result = parser.Parse("SUM(A1:A10) + AVERAGE(B1:B10)");
```

#### Methods

- `Parse(string formula)` - Parses a formula string and returns the parsed result
- `Validate(string formula)` - Validates formula syntax without full parsing
- `GetTokens(string formula)` - Returns lexical tokens for the formula

### Formula

Represents a parsed formula with its components.

```csharp
public class Formula
{
    public string OriginalText { get; }
    public IReadOnlyList<FormulaToken> Tokens { get; }
    public FormulaNode RootNode { get; }
    public bool IsValid { get; }
    public IReadOnlyList<FormulaError> Errors { get; }
}
```

## Grammar Specification

The formula parser is built using a comprehensive grammar that supports:

### Basic Operators

| Operator | Description          | Example   |
| -------- | -------------------- | --------- |
| `+`      | Addition             | `A1 + B1` |
| `-`      | Subtraction          | `A1 - B1` |
| `*`      | Multiplication       | `A1 * B1` |
| `/`      | Division             | `A1 / B1` |
| `^`      | Exponentiation       | `A1 ^ 2`  |
| `&`      | String concatenation | `A1 & B1` |

### Comparison Operators

| Operator | Description           | Example    |
| -------- | --------------------- | ---------- |
| `=`      | Equal                 | `A1 = B1`  |
| `<>`     | Not equal             | `A1 <> B1` |
| `<`      | Less than             | `A1 < B1`  |
| `<=`     | Less than or equal    | `A1 <= B1` |
| `>`      | Greater than          | `A1 > B1`  |
| `>=`     | Greater than or equal | `A1 >= B1` |

### Cell References

- **Single Cell**: `A1`, `$A$1`, `$A1`, `A$1`
- **Range**: `A1:B10`, `$A$1:$B$10`
- **Named Ranges**: `MyRange`, `Sheet1!MyRange`
- **3D References**: `Sheet1:Sheet3!A1`

### Functions

The parser supports all Excel function categories:

#### Standard Functions

- Mathematical: `SUM`, `AVERAGE`, `MAX`, `MIN`, `COUNT`
- Logical: `IF`, `AND`, `OR`, `NOT`
- Text: `CONCATENATE`, `LEFT`, `RIGHT`, `MID`, `LEN`
- Date/Time: `TODAY`, `NOW`, `DATE`, `TIME`

#### Example Usage

```csharp
// Mathematical functions
var mathFormula = parser.Parse("SUM(A1:A10) + AVERAGE(B1:B10)");

// Logical functions
var logicalFormula = parser.Parse("IF(A1 > 0, "Positive", "Negative")");

// Nested functions
var nestedFormula = parser.Parse("IF(AND(A1 > 0, B1 < 100), SUM(C1:C10), 0)");
```

## Advanced Features

### Error Handling

The parser provides comprehensive error reporting:

```csharp
var result = parser.Parse("SUM(A1:A10");  // Missing closing parenthesis
if (!result.IsValid)
{
    foreach (var error in result.Errors)
    {
        Console.WriteLine($"Error at position {error.Position}: {error.Message}");
    }
}
```

### Custom Functions

Extend the parser with custom functions:

```csharp
parser.RegisterFunction("CUSTOMSUM", (args) => {
    // Custom function implementation
    return args.Sum();
});
```

### Performance Optimization

For high-performance scenarios:

```csharp
// Reuse parser instances
private static readonly FormulaParser _parser = new FormulaParser();

// Use validation for syntax checking without full parsing
if (_parser.Validate(formula))
{
    var result = _parser.Parse(formula);
    // Process result
}
```

## Grammar Files

The formula parser is built from grammar files located in:

- **Lexer**: `SpreadsheetML/Formula/Lang/Lex/formula.lex`
- **Parser**: `SpreadsheetML/Formula/Lang/Parse/formula.y`
- **Functions**: `SpreadsheetML/Formula/Lang/Lex/functions/*.lex`

These files are processed during build to generate the C# parser code.

## Thread Safety

The `FormulaParser` class is thread-safe and can be used from multiple threads concurrently. However, the `Formula` instances returned by parsing operations are not thread-safe.

## Examples

### Basic Formula Parsing

```csharp
using OpenLanguage.SpreadsheetML.Formula;

var parser = new FormulaParser();

// Simple arithmetic
var formula1 = parser.Parse("A1 + B1 * C1");

// Function calls
var formula2 = parser.Parse("SUM(A1:A10)");

// Complex nested formula
var formula3 = parser.Parse("IF(AVERAGE(A1:A10) > 50, "Pass", "Fail")");
```

### Working with Parse Results

```csharp
var result = parser.Parse("SUM(A1:A10) + AVERAGE(B1:B10)");

if (result.IsValid)
{
    Console.WriteLine($"Original: {result.OriginalText}");
    Console.WriteLine($"Tokens: {result.Tokens.Count}");

    // Access the parse tree
    var rootNode = result.RootNode;
    Console.WriteLine($"Root node type: {rootNode.Type}");
}
```

### Error Handling

```csharp
var result = parser.Parse("SUM(A1:A10, B1:B10, "); // Incomplete formula

if (!result.IsValid)
{
    Console.WriteLine("Formula has errors:");
    foreach (var error in result.Errors)
    {
        Console.WriteLine($"  {error.Type}: {error.Message} at position {error.Position}");
    }
}
```

## See Also

- [Function Categories](./Functions.md) - Complete list of supported functions
- [Grammar Reference](./Grammar.md) - Detailed grammar specification
- [Performance Guide](../../guides/performance.md) - Optimization strategies

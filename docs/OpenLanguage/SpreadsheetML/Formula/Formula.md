# Formula Processing

The `OpenLanguage.SpreadsheetML.Formula` namespace provides Excel formula parsing capabilities using GPLEX/GPPG-generated lexer and parser.

## Overview

The Formula component offers:

- **Excel Formula Parsing**: Parse Excel formulas into Abstract Syntax Trees (AST)
- **Grammar-Based Parsing**: Uses GPLEX lexer (.lex) and GPPG parser (.y) for robust parsing
- **AST Manipulation**: Access and modify parsed formula structures programmatically
- **Formula Reconstruction**: Convert ASTs back to valid Excel formula strings

## Core Classes

### FormulaParser

Static class providing the main entry point for formula parsing operations.

```csharp
using OpenLanguage.SpreadsheetML.Formula;

// Parse a formula
var formula = FormulaParser.Parse("=SUM(A1:A10) * 2");

// Try parsing with error handling
var maybeFormula = FormulaParser.TryParse("=INVALID_SYNTAX(");
```

#### Methods

- `Parse(string formulaText)` - Parses a formula string and returns a Formula object
- `TryParse(string formulaText)` - Attempts to parse, returns null on failure

### Formula

Represents a parsed formula with its original text and AST.

```csharp
public class Formula
{
    public string FormulaText { get; }      // Original formula text
    public Node AstRoot { get; }            // Root node of the AST

    public override string ToString()       // Reconstructs formula from AST
}
```

## Parser Implementation

The formula parser is built using GPLEX/GPPG tools:

### Grammar Files

- **Lexer**: `SpreadsheetML/Formula/Lang/Lex/formula.lex` - Tokenizes formula text
- **Parser**: `SpreadsheetML/Formula/Lang/Parse/formula.y` - Defines grammar rules

### Supported Syntax

Based on the test cases, the parser supports:

#### Literals and Identifiers

- Numbers: `123`
- Strings: `"hello"`
- Booleans: `TRUE`, `FALSE`
- Errors: `#VALUE!`
- Cell references: `A1`
- Named ranges: `MyNamedRange`

#### Binary Operations

- Arithmetic: `1+2*3`, `(1+2)*3`, `10/2*5`
- Power: `2^3^2` (right-associative)
- Range operations: `A1:B2 C3:D4` (intersection), `A1:B2,C3:D4` (union)

#### Unary Operations

- Negative: `-5`
- Positive: `+A1`
- Applied to ranges: `-A1:B2`

#### Function Calls

- Basic: `SUM(1, 2, 3)`
- Nested: `IF(A1>B1, "Yes", "No")`
- With references: `VLOOKUP(A1, Sheet2!A:B, 2, FALSE)`

#### Array Literals

- Row arrays: `{1,2,3}`
- Column arrays: `{1;2;3}`
- 2D arrays: `{"a","b";"c","d"}`

#### Advanced References

- Table references: `Table1[@Column1]`

#### Example Usage

```csharp
// Parse various formula types
var literal = FormulaParser.Parse("123");
var arithmetic = FormulaParser.Parse("1+2*3");
var function = FormulaParser.Parse("SUM(A1:A10)");
var complex = FormulaParser.Parse("IF(A1>B1, "Yes", "No")");
```

## Error Handling

The parser throws `InvalidOperationException` for syntax errors:

```csharp
try
{
    var formula = FormulaParser.Parse("=SUM(1,");  // Missing closing parenthesis
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Parse error: {ex.Message}");
}

// Or use TryParse for error handling
var maybeFormula = FormulaParser.TryParse("=INVALID_SYNTAX(");
if (maybeFormula == null)
{
    Console.WriteLine("Parse failed");
}
```

## AST Manipulation

The parsed AST can be modified and reconstructed:

```csharp
var formula = FormulaParser.Parse("=A1+B1");

// Access the AST
var astRoot = formula.AstRoot;

// Modify the AST (implementation-specific)
// ...

// Reconstruct the formula
var reconstructed = formula.ToString(); // Uses AstRoot.ToString()
```

## Build Process

The grammar files are processed during build:

1. `formula.lex` is processed by GPLEX to generate the lexer
2. `formula.y` is processed by GPPG to generate the parser
3. Generated code is placed in the `Generated/` directory
4. The build system uses CMake to orchestrate this process

## Examples

### Basic Usage

```csharp
using OpenLanguage.SpreadsheetML.Formula;

// Parse a simple formula
var formula = FormulaParser.Parse("=1+2*3");
Console.WriteLine($"Original: {formula.FormulaText}");
Console.WriteLine($"Reconstructed: {formula.ToString()}");

// Parse with functions
var funcFormula = FormulaParser.Parse("=SUM(A1:A10)");
Console.WriteLine($"Function formula: {funcFormula}");
```

### Error Handling

```csharp
// Handle parse errors gracefully
var result = FormulaParser.TryParse("=SUM(1,"); // Invalid syntax

if (result != null)
{
    Console.WriteLine("Parsed successfully");
}
else
{
    Console.WriteLine("Parse failed - check syntax");
}
```

### Working with ASTs

```csharp
var formula = FormulaParser.Parse("=A1+B1");

// The AstRoot property gives access to the parsed tree structure
var root = formula.AstRoot;

// Convert back to string representation
var reconstructed = root.ToString();
Console.WriteLine($"Reconstructed: {reconstructed}");
```

## Technical Details

- Uses GPLEX for lexical analysis and GPPG for parsing
- Generates C# code from .lex and .y grammar files
- Supports Excel formula syntax including functions, operators, and references
- AST nodes implement ToString() for formula reconstruction
- Thread-safe static parsing methods

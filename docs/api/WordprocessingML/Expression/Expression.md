# Expression Lexer

The `OpenLanguage.WordprocessingML.Expression` namespace provides lexical analysis for parsing expressions using character-by-character state machine parsing.

## Overview

The Expression lexer provides:

- **Expression Tokenization**: Parse expressions into individual tokens
- **Binary Expression Parsing**: Extract operands and operators from simple comparisons
- **Multiple Token Types**: Support for strings, numbers, operators, identifiers, merge fields
- **State Machine Parsing**: Character-by-character lexical analysis

## Core Classes

### ExpressionLexer

Static class providing lexical analysis methods:

```csharp
using OpenLanguage.WordprocessingML.Expression;

// Parse an expression into tokens
var tokens = ExpressionLexer.TokenizeExpression("Amount > 100");

foreach (var token in tokens)
{
    Console.WriteLine($"{token.Type}: {token.Value}");
}
// Output:
// Identifier: Amount
// Whitespace:
// Operator: >
// Whitespace:
// Number: 100
```

### Expression

Represents a parsed expression with tokens and binary components:

```csharp
public class Expression
{
    public string RawText { get; set; }                    // Original expression text
    public List<ExpressionToken> Tokens { get; set; }     // Parsed tokens
    public string? LeftOperand { get; set; }              // Left side of binary expression
    public ComparisonOperator? Operator { get; set; }     // Comparison operator
    public string? RightOperand { get; set; }             // Right side of binary expression

    // Constructors for different creation scenarios
    public Expression()
    public Expression(string rawText)
    public Expression(string leftOperand, ComparisonOperator op, string rightOperand)
}
```

### ExpressionToken

Represents a single token within an expression:

```csharp
public class ExpressionToken
{
    public ExpressionTokenType Type { get; set; }    // Type of token
    public string Value { get; set; }                // Token value
    public int Position { get; set; }               // Position in source text
}
```

## Token Types

The lexer recognizes these token types:

### ExpressionTokenType Enumeration

| Type         | Description            | Example         |
| ------------ | ---------------------- | --------------- |
| `String`     | Quoted string literal  | `"Hello"`       |
| `Number`     | Numeric literal        | `123`, `-45.6`  |
| `MergeField` | Merge field reference  | `«FirstName»`   |
| `Operator`   | Comparison operator    | `=`, `<>`, `>=` |
| `Identifier` | Variable or field name | `Amount`        |
| `Whitespace` | Whitespace characters  | ` `, `\t`       |
| `Unknown`    | Unrecognized token     | `@`, `#`        |

## Comparison Operators

The lexer supports these comparison operators from the `ComparisonOperator` enum:

| Operator | ComparisonOperator Value | Description           |
| -------- | ------------------------ | --------------------- |
| `=`      | `Equal`                  | Equal                 |
| `<>`     | `NotEqual`               | Not equal             |
| `<`      | `LessThan`               | Less than             |
| `<=`     | `LessThanOrEqual`        | Less than or equal    |
| `>`      | `GreaterThan`            | Greater than          |
| `>=`     | `GreaterThanOrEqual`     | Greater than or equal |

## Parsing Methods

### Expression Parsing

```csharp
// Parse a complete expression
var expression = ExpressionLexer.ParseExpression("CustomerType = "Premium"");

Console.WriteLine($"Raw text: {expression.RawText}");
Console.WriteLine($"Left operand: {expression.LeftOperand}");    // "CustomerType"
Console.WriteLine($"Operator: {expression.Operator}");           // Equal
Console.WriteLine($"Right operand: {expression.RightOperand}");  // ""Premium""

// Check if expression contains merge fields
Console.WriteLine($"Has merge fields: {expression.ContainsMergeFields}");

// Check if expression is a literal value
Console.WriteLine($"Is literal: {expression.IsLiteral}");
```

### Token-Level Parsing

```csharp
// Get individual tokens from an expression
var tokens = ExpressionLexer.TokenizeExpression("Amount >= «MinimumAmount»");

foreach (var token in tokens)
{
    Console.WriteLine($"Type: {token.Type}, Value: '{token.Value}', Position: {token.Position}");
}

// Output:
// Type: Identifier, Value: 'Amount', Position: 0
// Type: Whitespace, Value: ' ', Position: 6
// Type: Operator, Value: '>=', Position: 7
// Type: Whitespace, Value: ' ', Position: 9
// Type: MergeField, Value: '«MinimumAmount»', Position: 10
```

## Expression Creation

### Creating Expressions Programmatically

```csharp
// Create from raw text
var expr1 = new Expression("Status = "Active"");

// Create binary expression directly
var expr2 = new Expression("Amount", ComparisonOperator.GreaterThan, "100");
Console.WriteLine(expr2.ToString()); // "Amount > 100"

// Create empty expression and set properties
var expr3 = new Expression();
expr3.RawText = "Count <= 50";
expr3.LeftOperand = "Count";
expr3.Operator = ComparisonOperator.LessThanOrEqual;
expr3.RightOperand = "50";
```

### String Tokenization

```csharp
// Parse quoted strings with escape sequences
var tokens = ExpressionLexer.TokenizeExpression(@"""Hello ""World"" Test""");
// Handles escaped quotes within strings

// Parse numbers including negative values
var numTokens = ExpressionLexer.TokenizeExpression("-123.45");
// Recognizes negative numbers as single tokens

// Parse merge fields
var mergeTokens = ExpressionLexer.TokenizeExpression("«FirstName» + «LastName»");
// Tokenizes merge field delimiters properly
```

## Operator Parsing

### Operator Utilities

```csharp
// Parse operator strings
var op1 = ExpressionLexer.ParseOperator(">=");
Console.WriteLine(op1); // GreaterThanOrEqual

// Convert operators back to strings
var opString = ExpressionLexer.OperatorToString(ComparisonOperator.NotEqual);
Console.WriteLine(opString); // "<>"

// Handle invalid operators
try
{
    var invalidOp = ExpressionLexer.ParseOperator("??");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Error: {ex.Message}"); // Unknown comparison operator
}
```

## State Machine Implementation

The lexer uses character-by-character state machine parsing:

### Internal Lexer States

```csharp
internal enum LexerState
{
    Initial,        // Starting state
    InString,       // Inside quoted string
    InNumber,       // Parsing numeric literal
    InIdentifier,   // Parsing identifier/variable name
    InOperator,     // Parsing comparison operator
    InMergeField,   // Inside merge field delimiters
    InWhitespace    // Processing whitespace
}
```

### Parsing Process

1. **Initial**: Determines token type based on first character
2. **InString**: Handles quoted strings with escape sequence support
3. **InNumber**: Parses numeric literals including negative numbers and decimals
4. **InIdentifier**: Extracts variable names and identifiers
5. **InOperator**: Recognizes single and multi-character operators
6. **InMergeField**: Processes merge field delimiters (« »)
7. **InWhitespace**: Groups consecutive whitespace characters

## Usage Examples

### Complete Expression Analysis

```csharp
using OpenLanguage.WordprocessingML.Expression;

string expressionText = @"«CustomerType» = ""Premium"" AND Amount >= 1000.00";

// Parse the full expression
var expression = ExpressionLexer.ParseExpression(expressionText);

Console.WriteLine($"Original: {expression.RawText}");
Console.WriteLine($"Tokens: {expression.Tokens.Count}");

// Examine each token
foreach (var token in expression.Tokens)
{
    if (token.Type != ExpressionTokenType.Whitespace)
    {
        Console.WriteLine($"  {token.Type}: '{token.Value}' at position {token.Position}");
    }
}

// For simple binary expressions, components are extracted
if (expression.LeftOperand != null)
{
    Console.WriteLine($"Binary expression detected:");
    Console.WriteLine($"  Left: {expression.LeftOperand}");
    Console.WriteLine($"  Operator: {expression.Operator}");
    Console.WriteLine($"  Right: {expression.RightOperand}");
}
```

### Expression Properties

```csharp
// Create expressions and check their properties
var mergeExpr = new Expression("«Amount» > 100");
Console.WriteLine($"Contains merge fields: {mergeExpr.ContainsMergeFields}"); // True

var literalExpr = new Expression("42");
Console.WriteLine($"Is literal: {literalExpr.IsLiteral}"); // True

var binaryExpr = new Expression("Status", ComparisonOperator.Equal, "Active");
Console.WriteLine($"Binary expression: {binaryExpr.ToString()}"); // "Status = Active"
```

## Technical Details

- **Character-by-Character Parsing**: Robust state machine implementation
- **Escape Sequence Support**: Handles escaped quotes in string literals
- **Multi-Character Operators**: Recognizes <=, >=, <> operators
- **Merge Field Support**: Parses « » delimited merge fields
- **Binary Expression Extraction**: Automatically extracts operands from simple comparisons
- **Position Tracking**: Maintains character positions for error reporting

## Limitations

- Only lexical analysis - no expression evaluation
- Limited to comparison operators (no arithmetic operators)
- Binary expression extraction works only for simple cases
- No validation of merge field syntax within delimiters
- String escape sequences support is basic (quotes and backslashes only)

## See Also

- [Field Instructions](../FieldInstruction/FieldInstruction.md) - Generic field instruction handling
- [MergeField Lexer](../MergeField/MergeField.md) - Merge field specific parsing

# Expression Parser

The `OpenLanguage.WordprocessingML.Expression` namespace provides a robust parser for expressions found within WordprocessingML field instructions.

## Overview

The Expression parser provides:

- **Expression Parsing**: Parse expressions into an Abstract Syntax Tree (AST).
- **Grammar-Based Parsing**: Uses a GPLEX/GPPG-based parser for accuracy and maintainability.
- **AST Representation**: Represents expressions as a tree of nodes, including literals, identifiers, operators, and nested fields.
- **Round-Trip Fidelity**: Parsed expressions can be reconstructed into their original string representation.

## Core Classes

### ExpressionParser

A static class for parsing expression strings.

```csharp
using OpenLanguage.WordprocessingML.Expression;
using OpenLanguage.WordprocessingML.Ast;

// Parse an expression
ExpressionNode expression = ExpressionParser.Parse("Amount > 100");

// The result is an AST node, e.g., a BinaryOperatorNode
if (expression is BinaryOperatorNode binaryOp)
{
    Console.WriteLine($"Left: {binaryOp.LeftOperand}");
    Console.WriteLine($"Operator: {binaryOp.Operator}");
    Console.WriteLine($"Right: {binaryOp.RightOperand}");
}
```

#### Methods

- `Parse(string expression)`: Parses an expression string and returns the root `ExpressionNode` of the AST. Throws `InvalidOperationException` on failure.
- `TryParse(string expression)`: Attempts to parse an expression and returns `null` if parsing fails.

### AST Nodes

The parser generates a tree of nodes derived from `OpenLanguage.WordprocessingML.Ast.ExpressionNode`. Common node types include:

- `IdentifierNode`: For unquoted identifiers like bookmark names.
- `StringLiteralNode`: For text content.
- `Quoted<T>`: For quoted content.
- `NumericLiteralNode<T>`: For numbers.
- `BinaryOperatorNode`: Base for operations like `+`, `-`, `*`, `/`, `=`, `>`.
  - `AddNode`, `SubtractNode`, `MultiplyNode`, `DivideNode`, `EqualNode`, etc.
- `UnaryOperatorNode`: Base for operations like unary `-`.
  - `UnaryMinusNode`, `UnaryPlusNode`.
- `MergeFieldNode`: For `«MergeField»` placeholders.
- `ParenthesizedExpressionNode`: For expressions enclosed in `()`.

## Usage Examples

### Parsing Different Expression Types

```csharp
// Numeric comparison
var numericExpr = ExpressionParser.Parse("123.45 >= 100");

// String comparison
var stringExpr = ExpressionParser.Parse(@"""apples"" = ""oranges""");

// Identifier (e.g., bookmark)
var identifierExpr = ExpressionParser.Parse("MyBookmark");

// Expression with a merge field
var mergeFieldExpr = ExpressionParser.Parse("«CustomerType» = ""Premium""");

// Reconstruct the expression
Console.WriteLine(mergeFieldExpr.ToString());
```

### Working with the AST

```csharp
using OpenLanguage.WordprocessingML.Ast;
using OpenLanguage.WordprocessingML.Expression;

var ast = ExpressionParser.Parse("(«Amount» + 50) * 2");

// Traverse the AST
if (ast is MultiplyNode multiply)
{
    Console.WriteLine($"Main operator: {multiply.Operator}"); // *

    if (multiply.LeftOperand is ParenthesizedExpressionNode p)
    {
        if (p.Inner is AddNode add)
        {
            Console.WriteLine($"Nested operator: {add.Operator}"); // +
            Console.WriteLine($"Left operand of sum: {add.LeftOperand}"); // «Amount»
            Console.WriteLine($"Right operand of sum: {add.RightOperand}"); // 50
        }
    }
}
```

## Error Handling

The `Parse` method throws an exception for invalid syntax, while `TryParse` provides a safe way to handle potential errors.

```csharp
// Safe parsing
var result = ExpressionParser.TryParse("1 +"); // Incomplete expression
if (result == null)
{
    Console.WriteLine("Failed to parse expression.");
}

// Exception-based parsing
try
{
    ExpressionParser.Parse("1 + (2 *"); // Unmatched parenthesis
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
```

## See Also

- [Field Instructions](../FieldInstruction/FieldInstruction.md)
- [Abstract Syntax Tree (AST)](../Ast.md)

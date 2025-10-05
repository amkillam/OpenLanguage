# Abstract Syntax Tree (AST)

The `OpenLanguage.WordprocessingML.Ast` namespace contains the core nodes that form the Abstract Syntax Tree (AST) for parsed expressions and field instructions.

## Core Node Types

### `Node`

The abstract base class for all AST nodes. It defines the fundamental structure for tree traversal and reconstruction.

- `Children<O>()`: Enumerates child nodes of a specific type.
- `ReplaceChild(int index, Node replacement)`: Replaces a child node at a given index.
- `ToString()`: Reconstructs the node's original string representation, including whitespace.
- `ToRawString()`: Gets the node's content without leading/trailing whitespace.

### `ExpressionNode`

The base class for all nodes that can be evaluated to a value. It inherits from `Node` and adds:

- `LeadingWhitespace` and `TrailingWhitespace`: Lists of `WhitespaceNode`s for round-trip fidelity.
- `Precedence`: An integer value for handling operator precedence.

## Common AST Nodes

### Literals

- `StringLiteralNode`: Represents literal text.
- `NumericLiteralNode<T>`: Represents numbers (integer, float, etc.).
- `CharacterLiteralNode`: Base for single characters like operators and delimiters.
  - `PlusLiteralNode`, `MinusLiteralNode`, `CommaNode`, etc.

### Structural Nodes

- `IdentifierNode`: Represents unquoted identifiers, like bookmark names.
- `Quoted<T>`: Wraps a node that was enclosed in quotes.
- `ParenthesizedExpressionNode`: Represents an expression enclosed in `()`.
- `BracedExpressionNode`: Represents an expression enclosed in `{}`.
- `BracketedExpressionNode`: Represents an expression enclosed in `[]`.

### Operator Nodes

- `UnaryOperatorNode`: Base class for operators with one operand (e.g., `-5`).
  - `UnaryMinusNode`, `UnaryPlusNode`.
- `BinaryOperatorNode`: Base class for operators with two operands (e.g., `A + B`).
  - `AddNode`, `SubtractNode`, `MultiplyNode`, `DivideNode`, `EqualNode`, etc.

### Function Nodes

- `FunctionNode`: Base class for a function's name (e.g., `SUM`).
- `FunctionCallNode`: Base class for a complete function call (e.g., `SUM(A1, B2)`).
- `ExpressionListNode`: Represents a comma-delimited list of arguments in a function call.

### Merge Field Nodes

- `MergeFieldNode`: Represents a `«MERGEFIELD»` placeholder.

### Table and Cell Nodes

- `CellReferenceNode`: Base class for nodes that refer to table cells.
- `A1CellNode`: Represents a cell in A1-style notation (e.g., `A1`).
- `CellRangeNode`: Represents a range of cells (e.g., `A1:B2`).
- `TableReferenceNode`: Represents a reference to a table by name.

## AST Traversal and Manipulation

The AST is designed to be fully navigable and mutable.

```csharp
using OpenLanguage.WordprocessingML.Ast;
using OpenLanguage.WordprocessingML.Expression;

// Parse an expression to get an AST
var ast = ExpressionParser.Parse("(1 + 2) * 3");

// Traverse the AST
if (ast is MultiplyNode multiply)
{
    Console.WriteLine($"Operator: {multiply.Operator}"); // *

    if (multiply.LeftOperand is ParenthesizedExpressionNode p)
    {
        // Modify a node
        if (p.Inner is AddNode add)
        {
            add.RightOperand = new NumericLiteralNode<int>("5", 5, "D");
        }
    }
}

// Reconstruct the modified expression
Console.WriteLine(ast.ToString()); // (1 + 5) * 3
```

This structured AST allows for complex analysis, transformation, and validation of WordprocessingML expressions and field instructions.

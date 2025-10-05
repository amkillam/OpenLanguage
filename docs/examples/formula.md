# Formula Parsing Examples

This document demonstrates how to use the OpenLanguage SpreadsheetML Formula parser to parse and manipulate Excel formulas.

## Basic Usage

### Parsing Simple Formulas

```csharp
using OpenLanguage.SpreadsheetML.Formula;

// Parse a simple arithmetic formula
Ast.Node formula = FormulaParser.Parse("=1+2*3");
Console.WriteLine($"Parsed AST: {formula}");

// Parse cell references
Ast.Node cellRef = FormulaParser.Parse("=A1+B2");
Console.WriteLine($"Cell reference formula: {cellRef}");

// Parse function calls
Ast.Node func = FormulaParser.Parse("=SUM(A1:A10)");
Console.WriteLine($"Function call: {func}");
```

### Safe Parsing with TryParse

```csharp
using OpenLanguage.SpreadsheetML.Formula;

string[] testFormulas = {
    "=A1+B1",
    "=SUM(1,2,3)",
    "=INVALID_SYNTAX(",
    "=IF(A1>0,\"Positive\",\"Non-positive\")"
};

foreach (string formulaText in testFormulas)
{
    Ast.Node? result = FormulaParser.TryParse(formulaText);
    if (result != null)
    {
        Console.WriteLine($"✓ Successfully parsed: {result}");
    }
    else
    {
        Console.WriteLine($"✗ Failed to parse: {formulaText}");
    }
}
```

## Working with Different Formula Types

### Arithmetic Operations

```csharp
using OpenLanguage.SpreadsheetML.Formula;

// Basic arithmetic
Ast.Node addition = FormulaParser.Parse("=10+5");
Ast.Node subtraction = FormulaParser.Parse("=10-5");
Ast.Node multiplication = FormulaParser.Parse("=10*5");
Ast.Node division = FormulaParser.Parse("=10/5");
Ast.Node exponentiation = FormulaParser.Parse("=2^3");

// Complex expressions with precedence
Ast.Node complex = FormulaParser.Parse("=(1+2)*3-4/2");
Console.WriteLine($"Complex expression: {complex}");
```

### Cell References

```csharp
using OpenLanguage.SpreadsheetML.Formula;

// Relative references
Ast.Node relative = FormulaParser.Parse("=A1+B2");

// Absolute references
Ast.Node absolute = FormulaParser.Parse("=$A$1+$B$2");

// Mixed references
Ast.Node mixed = FormulaParser.Parse("=$A1+B$2");

// Range references
Ast.Node range = FormulaParser.Parse("=SUM(A1:B10)");

Console.WriteLine($"Range formula: {range}");
```

### Function Calls

```csharp
using OpenLanguage.SpreadsheetML.Formula;

// Simple functions
Ast.Node sum = FormulaParser.Parse("=SUM(1,2,3,4,5)");
Ast.Node average = FormulaParser.Parse("=AVERAGE(A1:A10)");
Ast.Node count = FormulaParser.Parse("=COUNT(A1:A10)");

// Nested functions
Ast.Node nested = FormulaParser.Parse("=IF(SUM(A1:A10)>0,AVERAGE(A1:A10),0)");
Console.WriteLine($"Nested function: {nested}");

// Functions with string literals
Ast.Node vlookup = FormulaParser.Parse("=VLOOKUP(A1,Sheet2!A:B,2,FALSE)");
Console.WriteLine($"VLOOKUP: {vlookup}");
```

### Array Literals

```csharp
using OpenLanguage.SpreadsheetML.Formula;
using OpenLanguage.SpreadsheetML.Formula.Ast;

// Horizontal array
Node horizontalArray = FormulaParser.Parse("={1,2,3,4}");

// Vertical array
Node verticalArray = FormulaParser.Parse("={1;2;3;4}");

// 2D array
Node twoDArray = FormulaParser.Parse("={\"Name\",\"Age\";\"John\",25;\"Jane\",30}");

Console.WriteLine($"2D Array: {twoDArray}");
```

### Logical Operations

```csharp
using OpenLanguage.SpreadsheetML.Formula;
using OpenLanguage.SpreadsheetML.Formula.Ast;

// Comparison operations
Node comparison = FormulaParser.Parse("=A1>B1");
Node equality = FormulaParser.Parse("=A1=B1");
Node inequality = FormulaParser.Parse("=A1<>B1");

// Logical functions
Node ifFunction = FormulaParser.Parse("=IF(A1>0,\"Positive\",\"Non-positive\")");
Node and = FormulaParser.Parse("=AND(A1>0,B1<10)");
Node or = FormulaParser.Parse("=OR(A1>100,B1<0)");

Console.WriteLine($"IF function: {ifFunction}");
```

## Advanced Examples

### Working with Named Ranges

```csharp
using OpenLanguage.SpreadsheetML.Formula;

// Named range references
Ast.Node namedRange = FormulaParser.Parse("=SUM(SalesData)");
Ast.Node namedRangeCalc = FormulaParser.Parse("=TotalRevenue/TotalCosts");

Console.WriteLine($"Named range calculation: {namedRangeCalc}");
```

### Table References (Excel Tables)

```csharp
using OpenLanguage.SpreadsheetML.Formula;

// Structured table references
Ast.Node tableRef = FormulaParser.Parse("=Table1[@Column1]");
Ast.Node tableSum = FormulaParser.Parse("=SUM(Table1[Revenue])");

Console.WriteLine($"Table reference: {tableRef}");
```

### Error Values

```csharp
using OpenLanguage.SpreadsheetML.Formula;

// Excel error values
Ast.Node divByZero = FormulaParser.Parse("=#DIV/0!");
Ast.Node naError = FormulaParser.Parse("=#N/A");
Ast.Node valueError = FormulaParser.Parse("=#VALUE!");

Console.WriteLine($"Error value: {valueError}");
```

## Modifying Parsed Formulas

### Accessing and Modifying AST Nodes

The parser returns a tree of AST nodes that can be traversed and modified.

```csharp
using OpenLanguage.SpreadsheetML.Formula;
using OpenLanguage.SpreadsheetML.Formula.Ast;

// Parse a formula
var formula = FormulaParser.Parse("=A1+B1");

// The root of a formula starting with '=' is an EqualPrefixedNode
var rootNode = (EqualPrefixedNode)formula;

// The Expression property contains the actual formula structure
var addNode = (AddNode)rootNode.Expression;

// Access operands
var left = addNode.Left;
var right = addNode.Right;

Console.WriteLine($"Left: {left}, Operator: {addNode.Operator}, Right: {right}");

// Modify the AST: change the operator from + to *
addNode.Operator = new AsteriskLiteralNode("*");

// Reconstruct the formula from the modified AST
Console.WriteLine($"Modified formula: {rootNode.ToString()}"); // Output: =A1*B1
```

### Formula Reconstruction

```csharp
using OpenLanguage.SpreadsheetML.Formula;
using OpenLanguage.SpreadsheetML.Formula.Ast;

// Parse a formula
Node original = FormulaParser.Parse("=SUM(A1:A10)/COUNT(A1:A10)");

// The ToString() method reconstructs the formula from the AST
string reconstructed = original.ToString();
Console.WriteLine($"Reconstructed: {reconstructed}");

// Verify they're equivalent
Node reparsed = FormulaParser.Parse(reconstructed);
Console.WriteLine($"Reparsed successfully: {reparsed}");
```

## Error Handling

### Invalid Formula Handling

```csharp
using OpenLanguage.SpreadsheetML.Formula;
using OpenLanguage.SpreadsheetML.Formula.Ast;
using System;

string[] invalidFormulas = {
    "=1+",           // Incomplete expression
    "=(1+2",         // Unmatched parenthesis
    "=SUM(1,",       // Incomplete function call
    "=INVALID(",     // Unknown function with incomplete syntax
};

foreach (string formula in invalidFormulas)
{
    try
    {
        Node result = FormulaParser.Parse(formula);
        Console.WriteLine($"Unexpectedly succeeded: {result}");
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine($"Expected error for '{formula}': {ex.Message}");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"Argument error for '{formula}': {ex.Message}");
    }
}
```

## Performance Considerations

### Batch Processing

```csharp
using OpenLanguage.SpreadsheetML.Formula;
using OpenLanguage.SpreadsheetML.Formula.Ast;
using System.Diagnostics;

string[] formulas = {
    "=SUM(A1:A1000)",
    "=AVERAGE(B1:B1000)",
    "=COUNT(C1:C1000)",
    "=IF(D1>0,D1*E1,0)",
    "=VLOOKUP(F1,Sheet2!A:Z,10,FALSE)"
};

Stopwatch sw = Stopwatch.StartNew();

foreach (string formulaText in formulas)
{
    Node? result = FormulaParser.TryParse(formulaText);
    if (result != null)
    {
        // Process the parsed formula
        string reconstructed = result.ToString();
    }
}

sw.Stop();
Console.WriteLine($"Processed {formulas.Length} formulas in {sw.ElapsedMilliseconds}ms");
```

This example demonstrates the core functionality of the OpenLanguage Formula parser, showing how to parse various types of Excel formulas and work with the resulting Abstract Syntax Tree (AST).

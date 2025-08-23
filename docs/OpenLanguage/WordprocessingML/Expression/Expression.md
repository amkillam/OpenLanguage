# Expression Processing

The `OpenLanguage.WordprocessingML.Expression` namespace provides powerful expression evaluation capabilities for Word documents.

## Overview

The Expression component offers:

- **Mathematical Expressions**: Full arithmetic expression evaluation
- **String Operations**: Text manipulation and concatenation
- **Logical Operations**: Boolean logic and conditional expressions
- **Variable Support**: Dynamic variable resolution
- **Function Library**: Extensive built-in function set

## Core Classes

### ExpressionLexer

Lexical analysis for expression syntax:

```csharp
using OpenLanguage.WordprocessingML.Expression;

var lexer = new ExpressionLexer();
var tokens = lexer.Tokenize("(Amount * TaxRate) + ShippingCost");
```

### ExpressionEvaluator

Main class for expression evaluation:

```csharp
var evaluator = new ExpressionEvaluator();
var context = new ExpressionContext();

context.SetVariable("Amount", 100.0);
context.SetVariable("TaxRate", 0.08);
context.SetVariable("ShippingCost", 15.0);

var result = evaluator.Evaluate("(Amount * TaxRate) + ShippingCost", context);
Console.WriteLine($"Result: {result}"); // Output: 23
```

## Supported Operations

### Arithmetic Operations

| Operator | Description    | Example        |
| -------- | -------------- | -------------- |
| `+`      | Addition       | `5 + 3` → `8`  |
| `-`      | Subtraction    | `10 - 4` → `6` |
| `*`      | Multiplication | `6 * 7` → `42` |
| `/`      | Division       | `15 / 3` → `5` |
| `%`      | Modulo         | `10 % 3` → `1` |
| `^`      | Exponentiation | `2 ^ 3` → `8`  |

### Comparison Operations

| Operator | Description           | Example           |
| -------- | --------------------- | ----------------- |
| `==`     | Equal                 | `5 == 5` → `true` |
| `!=`     | Not equal             | `5 != 3` → `true` |
| `<`      | Less than             | `3 < 5` → `true`  |
| `<=`     | Less than or equal    | `5 <= 5` → `true` |
| `>`      | Greater than          | `7 > 5` → `true`  |
| `>=`     | Greater than or equal | `5 >= 5` → `true` |

### Logical Operations

| Operator | Description | Example                    |
| -------- | ----------- | -------------------------- |
| `&&`     | Logical AND | `true && false` → `false`  |
| `\|\|`   | Logical OR  | `true \|\| false` → `true` |
| `!`      | Logical NOT | `!true` → `false`          |

### String Operations

| Operation    | Description       | Example                                |
| ------------ | ----------------- | -------------------------------------- |
| `+`          | Concatenation     | `"Hello" + " World"` → `"Hello World"` |
| `CONTAINS`   | Contains check    | `"Hello" CONTAINS "ell"` → `true`      |
| `STARTSWITH` | Starts with check | `"Hello" STARTSWITH "Hel"` → `true`    |
| `ENDSWITH`   | Ends with check   | `"Hello" ENDSWITH "llo"` → `true`      |

## Built-in Functions

### Mathematical Functions

```csharp
// Basic math functions
var result1 = evaluator.Evaluate("ABS(-5)"); // 5
var result2 = evaluator.Evaluate("SQRT(16)"); // 4
var result3 = evaluator.Evaluate("ROUND(3.14159, 2)"); // 3.14

// Trigonometric functions
var result4 = evaluator.Evaluate("SIN(PI() / 2)"); // 1
var result5 = evaluator.Evaluate("COS(0)"); // 1
var result6 = evaluator.Evaluate("TAN(PI() / 4)"); // 1
```

### String Functions

```csharp
// String manipulation
var result1 = evaluator.Evaluate("UPPER("hello")"); // "HELLO"
var result2 = evaluator.Evaluate("LOWER("WORLD")"); // "world"
var result3 = evaluator.Evaluate("LEFT("Hello", 3)"); // "Hel"
var result4 = evaluator.Evaluate("RIGHT("World", 3)"); // "rld"
var result5 = evaluator.Evaluate("MID("Hello", 2, 2)"); // "el"
var result6 = evaluator.Evaluate("LEN("Hello")"); // 5
```

### Date/Time Functions

```csharp
// Date and time operations
var result1 = evaluator.Evaluate("NOW()"); // Current date/time
var result2 = evaluator.Evaluate("TODAY()"); // Current date
var result3 = evaluator.Evaluate("YEAR(TODAY())"); // Current year
var result4 = evaluator.Evaluate("MONTH(TODAY())"); // Current month
var result5 = evaluator.Evaluate("DAY(TODAY())"); // Current day
```

### Conditional Functions

```csharp
// IF function
var result1 = evaluator.Evaluate("IF(Amount > 100, "High", "Low")");

// CHOOSE function
var result2 = evaluator.Evaluate("CHOOSE(2, "First", "Second", "Third")"); // "Second"

// SWITCH function (C# style)
var result3 = evaluator.Evaluate("SWITCH(Status, "Active", "Running", "Inactive", "Stopped", "Unknown")");
```

## Variable Context

### Setting Variables

```csharp
var context = new ExpressionContext();

// Set simple values
context.SetVariable("Price", 29.99);
context.SetVariable("Quantity", 3);
context.SetVariable("CustomerName", "John Doe");

// Set complex objects
context.SetVariable("Customer", new Customer
{
    Name = "John Doe",
    Age = 30,
    IsActive = true
});

// Access object properties
var result = evaluator.Evaluate("Customer.Name + " is " + Customer.Age + " years old"", context);
```

### Dynamic Variables

```csharp
// Set up dynamic variable resolution
context.SetDynamicResolver(variableName =>
{
    switch (variableName.ToUpper())
    {
        case "CURRENTUSER":
            return Environment.UserName;
        case "CURRENTDATE":
            return DateTime.Now.ToString("yyyy-MM-dd");
        default:
            return null;
    }
});

var result = evaluator.Evaluate("CURRENTUSER + " logged in on " + CURRENTDATE", context);
```

## Custom Functions

### Registering Custom Functions

```csharp
// Register a simple function
evaluator.RegisterFunction("DOUBLE", args =>
{
    if (args.Length != 1) throw new ArgumentException("DOUBLE requires exactly 1 argument");
    return Convert.ToDouble(args[0]) * 2;
});

// Register a complex function
evaluator.RegisterFunction("FORMATCURRENCY", args =>
{
    if (args.Length < 1 || args.Length > 2)
        throw new ArgumentException("FORMATCURRENCY requires 1-2 arguments");

    var amount = Convert.ToDecimal(args[0]);
    var currency = args.Length > 1 ? args[1].ToString() : "USD";

    return $"{amount:C} {currency}";
});

// Usage
var result1 = evaluator.Evaluate("DOUBLE(5)"); // 10
var result2 = evaluator.Evaluate("FORMATCURRENCY(123.45, "EUR")"); // "$123.45 EUR"
```

### Function Categories

```csharp
// Organize functions into categories
evaluator.RegisterFunctionCategory("Math", new Dictionary<string, Func<object[], object>>
{
    ["FACTORIAL"] = args => Factorial(Convert.ToInt32(args[0])),
    ["GCD"] = args => GCD(Convert.ToInt32(args[0]), Convert.ToInt32(args[1])),
    ["LCM"] = args => LCM(Convert.ToInt32(args[0]), Convert.ToInt32(args[1]))
});

evaluator.RegisterFunctionCategory("Text", new Dictionary<string, Func<object[], object>>
{
    ["REVERSE"] = args => new string(args[0].ToString().Reverse().ToArray()),
    ["WORDCOUNT"] = args => args[0].ToString().Split(' ', StringSplitOptions.RemoveEmptyEntries).Length
});
```

## Advanced Features

### Expression Compilation

```csharp
// Compile expressions for better performance
var compiledExpression = evaluator.Compile("(Amount * TaxRate) + ShippingCost");

// Reuse compiled expressions
var result1 = compiledExpression.Evaluate(context1);
var result2 = compiledExpression.Evaluate(context2);
var result3 = compiledExpression.Evaluate(context3);
```

### Expression Validation

```csharp
// Validate expression syntax
var validationResult = evaluator.Validate("(Amount * TaxRate) + ShippingCost");

if (!validationResult.IsValid)
{
    foreach (var error in validationResult.Errors)
    {
        Console.WriteLine($"Error at position {error.Position}: {error.Message}");
    }
}
```

### Type Safety

```csharp
// Enable strict type checking
var options = new ExpressionOptions
{
    StrictTypeChecking = true,
    AllowImplicitConversions = false
};

evaluator.SetOptions(options);

// This will throw a type mismatch error
try
{
    var result = evaluator.Evaluate(""Hello" + 123"); // Error: Cannot add string and number
}
catch (ExpressionTypeException ex)
{
    Console.WriteLine($"Type error: {ex.Message}");
}
```

## Performance Optimization

### Expression Caching

```csharp
// Enable expression caching
evaluator.EnableCache(maxSize: 1000, expiration: TimeSpan.FromHours(1));

// Expressions are automatically cached and reused
var result1 = evaluator.Evaluate(expression, context); // Compiled and cached
var result2 = evaluator.Evaluate(expression, context); // Retrieved from cache
```

### Parallel Evaluation

```csharp
// Evaluate multiple expressions in parallel
var expressions = new[]
{
    "Amount * TaxRate",
    "Quantity * UnitPrice",
    "Total - Discount"
};

var results = evaluator.EvaluateParallel(expressions, context);
```

## Integration Examples

### Word Document Integration

```csharp
using DocumentFormat.OpenXml.Wordprocessing;

public void ProcessDocumentExpressions(WordprocessingDocument document)
{
    var evaluator = new ExpressionEvaluator();
    var context = CreateDocumentContext(document);

    // Find all expression fields
    var expressionFields = document.MainDocumentPart.Document
        .Descendants<FieldCode>()
        .Where(fc => fc.Text.StartsWith("= "))
        .ToList();

    foreach (var field in expressionFields)
    {
        var expression = field.Text.Substring(2); // Remove "= " prefix
        var result = evaluator.Evaluate(expression, context);

        // Replace field with result
        ReplaceFieldWithResult(field, result.ToString());
    }
}
```

### Mail Merge Integration

```csharp
public class ExpressionMergeProcessor
{
    private readonly ExpressionEvaluator _evaluator = new ExpressionEvaluator();

    public void ProcessMergeExpressions(DataRecord record)
    {
        var context = new ExpressionContext();

        // Add all record fields to context
        foreach (var kvp in record)
        {
            context.SetVariable(kvp.Key, kvp.Value);
        }

        // Process calculated fields
        var calculatedFields = GetCalculatedFields();

        foreach (var field in calculatedFields)
        {
            var result = _evaluator.Evaluate(field.Expression, context);
            record[field.Name] = result;
        }
    }
}
```

## See Also

- [Field Instructions](../FieldInstruction/FieldInstruction.md) - Field instruction parsing
- [Merge Fields](../MergeField/MergeField.md) - Mail merge functionality
- [Formula Processing](../../SpreadsheetML/Formula/Formula.md) - Excel formula evaluation

# Testing

OpenLanguage uses a comprehensive testing strategy built on xUnit to ensure reliability, correctness, and performance. This document covers the testing architecture, methodologies, test organization, and development practices.

## Overview

The testing framework is designed to validate:

- **Parser correctness**: Accurate parsing of SpreadsheetML formulas and WordprocessingML field instructions
- **AST integrity**: Proper Abstract Syntax Tree construction and manipulation
- **Round-trip fidelity**: Ensuring parsed structures can be reconstructed to original form
- **Error handling**: Graceful handling of invalid input and edge cases
- **Performance**: Parsing performance with various input sizes and complexities

## Test Project Structure

```
OpenLanguage.Test/
├── OpenLanguage.Test.csproj          # Test project configuration
├── SpreadsheetML/
│   └── Formula/
│       └── ParserTests.cs            # SpreadsheetML formula parser tests
└── WordprocessingML/
    └── FieldInstruction/
        ├── FieldInstructionTests.cs  # Core field instruction tests
        ├── LexerTests.cs             # Field instruction lexer tests
        └── TypedFieldInstructionTests.cs # Typed instruction factory tests
```

## Test Project Configuration

### OpenLanguage.Test.csproj

The test project is configured to work with the main `OpenLanguage` project and includes settings for testing, code coverage, and data handling.

**Key Configuration Features:**

- **TargetFrameworks**: `net8.0;net9.0`
- **Package References**:
  - `Microsoft.NET.Test.Sdk`
  - `xunit` and `xunit.runner.visualstudio` for running tests.
  - `coverlet.collector` for code coverage data collection.
- **Project Reference**: Includes a reference to the main `OpenLanguage.csproj`.
- **Compiler Defines**: `TRACE_ACTIONS` and `EXPORT_GPPG` are defined, which can be used for conditional compilation during tests.

## Testing Framework

### xUnit Integration

OpenLanguage uses xUnit as the primary testing framework, providing:

- **Theory-based testing**: Data-driven tests with multiple input values
- **Fact-based testing**: Single-case unit tests
- **Async testing support**: For asynchronous operations
- **Parallel test execution**: Improved test performance
- **Rich assertion library**: Comprehensive assertion methods

### Test Categories

#### Unit Tests

Test individual components in isolation:

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction;
using OpenLanguage.WordprocessingML.FieldInstruction.Ast;

[Fact]
public void Parse_SimpleInstruction_ReturnsCorrectAstNode()
{
    // Arrange
    string instruction = "PAGE";

    // Act
    var ast = FieldInstructionParser.Parse(instruction);

    // Assert
    Assert.IsType<PageFieldInstruction>(ast);
    var pageField = (PageFieldInstruction)ast;
    Assert.Equal("PAGE", pageField.Instruction.Value);
}
```

#### Integration Tests

Test component interactions:

```csharp
using OpenLanguage.SpreadsheetML.Formula;
using OpenLanguage.SpreadsheetML.Formula.Ast;

[Theory]
[InlineData("=SUM(A1:A10)", typeof(FunctionCallNode))]
[InlineData("=A1+B1", typeof(AddNode))]
public void Parse_ValidFormula_ReturnsCorrectASTType(string formula, Type expectedType)
{
    // Act
    var result = FormulaParser.Parse(formula);

    // The root is an EqualPrefixedNode, we check its expression
    var expression = result;
    if (result is EqualPrefixedNode equalPrefixed)
    {
        expression = equalPrefixed.Expression;
    }

    // Assert
    Assert.IsType(expectedType, expression);
}
```

#### Round-Trip Tests

Verify parsing and reconstruction fidelity:

```csharp
[Theory]
[InlineData("=SUM(1,2,3)")]
[InlineData("=IF(A1>B1,\"Yes\",\"No\")")]
[InlineData("=VLOOKUP(A1,Sheet2!A:B,2,FALSE)")]
public void TestParseFunctionCall(string formulaString)
{
    // Act
    Node formula = FormulaParser.Parse(formulaString);

    // Assert - Round-trip test
    Assert.Equal(formulaString, formula.ToString());
}
```

## SpreadsheetML Formula Testing

### Parser Tests (ParserTests.cs)

The formula parser tests are organized into several categories:

#### Literal and Identifier Tests

```csharp
[Theory]
[InlineData("123")]                    // Numeric literal
[InlineData("\"hello\"")]              // String literal
[InlineData("TRUE")]                   // Boolean literal
[InlineData("#VALUE!")]                // Error literal
[InlineData("A1")]                     // Cell reference
[InlineData("MyNamedRange")]           // Named range
public void TestParseLiteralAndIdentifier(string formulaString)
{
    Node formula = FormulaParser.Parse(formulaString);
    Assert.Equal(formulaString, formula.ToString());
}
```

#### Binary Operation Tests

```csharp
[Theory]
[InlineData("1+2*3")]                  // Precedence test
[InlineData("(1+2)*3")]                // Parentheses test
[InlineData("1+2-3")]                  // Left associativity
[InlineData("10/2*5")]                 // Left associativity
[InlineData("2^3^2")]                  // Right associativity
[InlineData("A1:B2 C3:D4")]            // Range intersection
[InlineData("A1:B2,C3:D4")]            // Range union
public void TestParseBinaryOperation(string formulaString)
{
    Node formula = FormulaParser.Parse(formulaString);
    Assert.Equal(formulaString, formula.ToString());
}
```

#### Unary Operation Tests

```csharp
[Theory]
[InlineData("-5")]                     // Negative number
[InlineData("+A1")]                    // Positive reference
[InlineData("-A1:B2")]                 // Negative range
public void TestParseUnaryOperation(string formulaString)
{
    Node formula = FormulaParser.Parse(formulaString);
    Assert.Equal(formulaString, formula.ToString());
}
```

#### Function Call Tests

```csharp
[Theory]
[InlineData("SUM(1, 2, 3)")]
[InlineData("IF(A1>B1, \"Yes\", \"No\")")]
[InlineData("VLOOKUP(A1, Sheet2!A:B, 2, FALSE)")]
[InlineData("INDIRECT("A" & ROW())")]
public void TestParseFunctionCall(string formulaString)
{
    Node formula = FormulaParser.Parse(formulaString);
    Assert.Equal(formulaString, formula.ToString());
}
```

### Test Data Organization

Tests use inline data attributes for maintainable test cases:

```csharp
public static IEnumerable<object[]> ComplexFormulaTestData()
{
    yield return new object[] { "=SUM(A1:A10)*COUNT(B:B)", "Arithmetic with functions" };
    yield return new object[] { "=IF(AND(A1>0,B1<100),\"Valid\",\"Invalid\")", "Nested logical functions" };
    yield return new object[] { "=VLOOKUP(A1,Table1,2,0)+VLOOKUP(A1,Table2,3,0)", "Multiple lookups" };
}

[Theory]
[MemberData(nameof(ComplexFormulaTestData))]
public void TestComplexFormulas(string formula, string description)
{
    // Test implementation
}
```

## WordprocessingML Field Instruction Testing

### Parser Tests (FieldInstructionTests.cs)

The `FieldInstructionParser` is tested to ensure it correctly parses various field codes into their strongly-typed AST node representations.

#### Validation Tests

```csharp
[Theory]
[InlineData(null)]
[InlineData("")]
[InlineData("    ")]
public void Parse_InvalidInput_ThrowsArgumentException(string? instruction)
{
    // Act & Assert
    Assert.Throws<ArgumentException>(() => FieldInstructionParser.Parse(instruction!));
}
```

#### Argument Handling Tests

```csharp
[Fact]
public void Parse_MergeFieldWithSwitches_SetsProperties()
{
    // Arrange
    string instruction = @"MERGEFIELD FirstName \* Upper";

    // Act
    var ast = FieldInstructionParser.Parse(instruction);

    // Assert
    var mergeField = Assert.IsType<MergeFieldFieldInstruction>(ast);
    Assert.Equal("FirstName", mergeField.FieldName.ToRawString());
    Assert.NotNull(mergeField.GeneralFormat);
    Assert.Equal("Upper", mergeField.GeneralFormat.Argument.ToRawString());
}
```

### Lexer Tests (LexerTests.cs)

Test the field instruction lexical analyzer:

```csharp
[Theory]
[InlineData("PAGE", TokenType.Instruction)]
[InlineData("\* MERGEFORMAT", TokenType.Switch)]
[InlineData("\"Hello World\"", TokenType.StringLiteral)]
[InlineData("123", TokenType.Number)]
public void Tokenize_ValidInput_ReturnsCorrectTokens(string input, TokenType expectedType)
{
    // Arrange
    var lexer = new FieldInstructionLexer();

    // Act
    var tokens = lexer.Tokenize(input);

    // Assert
    Assert.Single(tokens);
    Assert.Equal(expectedType, tokens[0].Type);
}
```

### AST Node Property Tests

Tests verify that the correct properties are set on the strongly-typed AST nodes.

```csharp
[Fact]
public void Parse_MergeFieldInstruction_ReturnsTypedInstanceWithCorrectProperties()
{
    // Arrange
    var instruction = FieldInstructionParser.Parse("MERGEFIELD FirstName");

    // Act
    var mergeField = Assert.IsType<MergeFieldFieldInstruction>(instruction);

    // Assert
    Assert.Equal("FirstName", mergeField.FieldName.ToRawString());
}
```

## Test Execution

### Running Tests

#### Command Line

```bash
# Run all tests
dotnet test

# Run tests with detailed output
dotnet test --verbosity normal

# Run tests with code coverage
dotnet test --collect:"XPlat Code Coverage"

# Run specific test project
dotnet test OpenLanguage.Test/

# Run specific test class
dotnet test --filter "ClassName=ParserTests"

# Run specific test method
dotnet test --filter "MethodName=TestParseLiteralAndIdentifier"
```

#### CMake Integration

```bash
# Run tests through CMake build system
cmake --build build --target test
```

This executes the `test` target defined in `CMakeLists.txt`, which runs:
`dotnet test OpenLanguage.Test/OpenLanguage.Test.csproj --configuration="Release" --framework="net9.0"`

### Continuous Integration

The testing strategy integrates with CI/CD pipelines. The `CMakeLists.txt` file provides a `test` target that can be used in CI.

```yaml
# Example GitHub Actions workflow
name: CI
on: [push, pull_request]

jobs:
  test:
    runs-on: ubuntu-latest
    steps:
      - uses: actions/checkout@v3

      - name: Setup .NET
        uses: actions/setup-dotnet@v3
        with:
          dotnet-version: "9.0.x"

      - name: Configure CMake
        run: cmake -B build

      - name: Run CI test target
        run: cmake --build build --target test-ci
```

## Test Development Practices

### Writing Effective Tests

#### Test Naming Convention

```csharp
// Pattern: MethodName_StateUnderTest_ExpectedBehavior
[Fact]
public void Parse_ValidFormula_ReturnsFormulaWithCorrectAST()

[Fact]
public void Constructor_NullInstruction_ThrowsArgumentException()

[Theory]
[InlineData("SUM(A1:A10)")]
public void ToString_ParsedFormula_ReturnsOriginalString(string input)
```

#### Arrange-Act-Assert Pattern

```csharp
[Fact]
public void Parse_SimpleAddition_CreatesCorrectAST()
{
    // Arrange
    string formula = "A1+B1";

    // Act
    var result = FormulaParser.Parse(formula);

    // Assert
    Assert.IsType<BinaryOperatorNode>(result);
    var binOp = (BinaryOperatorNode)result;
    Assert.Equal("+", binOp.Operator);
}
```

#### Theory-Based Testing

Use theories for testing multiple similar cases:

```csharp
[Theory]
[InlineData("SUM", true)]
[InlineData("AVERAGE", true)]
[InlineData("UNKNOWN", false)]
public void IsKnownFunction_VariousFunctions_ReturnsExpected(string functionName, bool expected)
{
    // Act
    bool result = FunctionRegistry.IsKnownFunction(functionName);

    // Assert
    Assert.Equal(expected, result);
}
```

### Test Data Management

#### Complex Test Cases

```csharp
public static IEnumerable<object[]> FormulaTestCases()
{
    // Basic arithmetic
    yield return new object[] { "1+2", typeof(BinaryOperatorNode) };
    yield return new object[] { "A1*B1", typeof(BinaryOperatorNode) };

    // Function calls
    yield return new object[] { "SUM(A1:A10)", typeof(FunctionCallNode) };
    yield return new object[] { "IF(A1>0,"Positive","Non-positive")", typeof(FunctionCallNode) };

    // Complex nested expressions
    yield return new object[] { "SUM(A1:A10)+AVERAGE(B1:B10)*2", typeof(BinaryOperatorNode) };
}

[Theory]
[MemberData(nameof(FormulaTestCases))]
public void Parse_VariousFormulas_ReturnsCorrectASTType(string formula, Type expectedType)
{
    var result = FormulaParser.Parse(formula);
    Assert.IsType(expectedType, result);
}
```

#### External Test Data

For large test datasets, consider external files:

```csharp
[Theory]
[JsonFileData("TestData/large-formula-set.json")]
public void Parse_LargeFormulaSet_AllParseSuccessfully(string formula)
{
    // Act & Assert
    var exception = Record.Exception(() => FormulaParser.Parse(formula));
    Assert.Null(exception);
}
```

### Error Testing

#### Exception Testing

```csharp
[Theory]
[InlineData("")]
[InlineData("   ")]
[InlineData(null)]
public void Parse_InvalidInput_ThrowsArgumentException(string input)
{
    // Act & Assert
    Assert.Throws<ArgumentException>(() => FormulaParser.Parse(input));
}
```

#### Error Recovery Testing

```csharp
[Theory]
[InlineData("=SUM(A1:A10")] // Missing closing parenthesis
[InlineData("=A1++B1")]     // Invalid operator sequence
public void TryParse_InvalidFormula_ReturnsNull(string formula)
{
    // Act
    var result = FormulaParser.TryParse(formula);

    // Assert
    Assert.Null(result);
}
```

## Performance Testing

### Benchmark Tests

```csharp
[Theory]
[InlineData(10)]
[InlineData(100)]
[InlineData(1000)]
public void Parse_RepeatedCalls_PerformanceWithinLimits(int iterations)
{
    // Arrange
    string formula = "SUM(A1:A100)+AVERAGE(B1:B100)*COUNT(C1:C100)";
    var stopwatch = Stopwatch.StartNew();

    // Act
    for (int i = 0; i < iterations; i++)
    {
        FormulaParser.Parse(formula);
    }
    stopwatch.Stop();

    // Assert
    var averageTime = stopwatch.ElapsedMilliseconds / (double)iterations;
    Assert.True(averageTime < 10, $"Average parse time {averageTime}ms exceeds limit");
}
```

### Memory Testing

```csharp
[Fact]
public void Parse_LargeFormula_MemoryUsageReasonable()
{
    // Arrange
    var largeFormula = GenerateLargeFormula(1000); // Generate complex formula
    var initialMemory = GC.GetTotalMemory(true);

    // Act
    var result = FormulaParser.Parse(largeFormula);
    var finalMemory = GC.GetTotalMemory(false);

    // Assert
    var memoryIncrease = finalMemory - initialMemory;
    Assert.True(memoryIncrease < 1_000_000, $"Memory increase {memoryIncrease} bytes exceeds limit");
}
```

## Test Maintenance

### Refactoring Tests

When refactoring production code, update tests accordingly:

1. **Update test names** to reflect new behavior
2. **Modify assertions** for changed return types or values
3. **Add new test cases** for new functionality
4. **Remove obsolete tests** for removed functionality

### Test Documentation

Document complex test scenarios:

```csharp
/// <summary>
/// Tests that Excel-style structured references are parsed correctly.
/// This includes table references like Table1[Column1] and special
/// item specifiers like [#Headers], [#Data], [#Totals].
/// </summary>
[Theory]
[InlineData("Table1[Column1]")]
[InlineData("Table1[[#Headers],[Column1]]")]
[InlineData("Table1[#Data]")]
public void Parse_StructuredReferences_CreatesCorrectAST(string formula)
{
    // Test implementation
}
```

## Debugging Tests

### Test Debugging Strategies

1.  **Use descriptive test names** that clearly indicate what's being tested.
2.  **Add intermediate assertions** to isolate failure points.
3.  **Use debugger breakpoints** in both test and production code.
4.  **Add logging** for complex test scenarios.

```csharp
[Fact]
public void Parse_ComplexFormula_DebugExample()
{
    // Arrange
    string formula = "=SUM(A1:A10)+AVERAGE(B1:B10)";

    // Act
    var result = FormulaParser.Parse(formula);

    // Debug assertions
    Assert.NotNull(result);
    var root = Assert.IsType<EqualPrefixedNode>(result);
    var addNode = Assert.IsType<AddNode>(root.Expression);

    // Main assertion
    Assert.Equal("+", addNode.Operator.ToRawString());

    // Verify operands
    Assert.IsType<FunctionCallNode>(addNode.Left);
    Assert.IsType<FunctionCallNode>(addNode.Right);
}
```

### Test Isolation

Tests are designed to be independent. xUnit creates a new instance of the test class for each test method, ensuring isolation.

## Integration with Development Workflow

### Pre-commit Testing

The git pre-commit hook (configured via `.husky/pre-commit`) runs tests before allowing commits to ensure code quality.

### Test-Driven Development

1. **Write failing test** for new functionality
2. **Implement minimal code** to make test pass
3. **Refactor** while keeping tests green
4. **Add more test cases** to cover edge cases

### Code Coverage

Monitor test coverage to ensure comprehensive testing:

```bash
# Generate coverage report
dotnet test --collect:"XPlat Code Coverage"

# View coverage report
dotnet tool install -g dotnet-reportgenerator-globaltool
reportgenerator -reports:"**/coverage.cobertura.xml" -targetdir:"coverage-report"
```

## Best Practices Summary

1. **Write tests first** or alongside implementation
2. **Use descriptive test names** that explain the scenario
3. **Follow AAA pattern** (Arrange-Act-Assert)
4. **Test edge cases** and error conditions
5. **Keep tests simple** and focused on single behaviors
6. **Use theories** for testing multiple similar cases
7. **Mock dependencies** appropriately
8. **Maintain test performance** - tests should run quickly
9. **Update tests** when refactoring production code
10. **Document complex test scenarios**

This comprehensive testing strategy ensures OpenLanguage maintains high quality, reliability, and performance while supporting confident refactoring and feature development.

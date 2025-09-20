# OpenLanguage

[![Build Status](https://github.com/amkillam/OpenLanguage/workflows/CI/badge.svg)](https://github.com/amkillam/OpenLanguage/actions)
[![NuGet Version](https://img.shields.io/nuget/v/OpenLanguage.svg)](https://www.nuget.org/packages/OpenLanguage/)
[![License: GPL v2](https://img.shields.io/badge/License-GPL_v2-blue.svg)](https://www.gnu.org/licenses/old-licenses/gpl-2.0.en.html)

OpenLanguage is a C# library providing lexers, parsers, and other processing tools for major DSLs used in Open Office XML.

## Features

### WordprocessingML

- **Field Instructions**: Parse Word field codes into structured objects with arguments
- **Typed Field Instructions**: Factory pattern for converting generic instructions to strongly-typed objects
- **Comprehensive Field Types**: Support for 70+ Word field instruction types (REF, MERGEFIELD, IF, etc.) - intended to be comprehensive
- **Argument Handling**: Process identifiers, string literals, switches, and nested fields
- **Field Reconstruction**: Convert parsed instructions back to valid field code strings

### SpreadsheetML

- **Formula Parsing**: Parse SpreadsheetML formulas into Abstract Syntax Trees (AST)
- **Grammar-Based**: Uses GPLEX GNU LEX-style lexer (.lex) and GPPG GNU YACC-style parser for concise and efficient grammar specification and parsing logic
- **AST Manipulation**: Access and modify parsed formula structures programmatically
- **Formula Reconstruction**: Convert modified ASTs back to valid Excel formula strings
- **Reference Support**: Handle A1, R1C1, table references, structured, and external references

## Installation

Install via NuGet Package Manager:

```bash
dotnet add package OpenLanguage
```

Or via Package Manager Console:

```powershell
Install-Package OpenLanguage
```

## Quick Start

### Formula Parsing

```csharp
using OpenLanguage.SpreadsheetML.Formula;

// Parse an Excel formula
Ast.Node formula = FormulaParser.Parse("=SUM(A1:A10) * 2");

// Access the AST
Console.WriteLine($"Reconstructed: {formula.ToString()}");

// Try parsing with error handling
Ast.Node? maybeFormula = FormulaParser.TryParse("=INVALID_SYNTAX(");
if (maybeFormula == null)
{
    Console.WriteLine("Parse failed - invalid syntax");
}
```

### Field Instruction Processing

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction;
using OpenLanguage.WordprocessingML.FieldInstruction.Typed;

// Create a field instruction
var instruction = new FieldInstruction("MERGEFIELD");
instruction.Arguments.Add(new FieldArgument(FieldArgumentType.Identifier, "FirstName"));
instruction.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\* Upper"));

// Convert to strongly-typed (if available)
var typedInstruction = TypedFieldInstructionFactory.Create(instruction);

// Reconstruct field code
Console.WriteLine($"Field Code: {instruction.ToString()}");
```

## Building from Source

### Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [CMake 3.20+](https://cmake.org/download/) (for build system)
- [cpp](https://gcc.gnu.org/) (C preprocessor for .y/.lex file processing)

### Build Commands

The project uses a CMake-based build system with multiple targets:

```bash
# Configure build
cmake -B build

# Process .y/.lex files and generate code
cmake --build build --target process

# Build the solution
cmake --build build --target build

# Run tests
cmake --build build --target test

# Format code
cmake --build build --target format

# Generate documentation
cmake --build build --target doc

# Package for NuGet
cmake --build build --target publish

# Install git hooks
cmake --build build --target install-hooks

# Clean all build artifacts
cmake --build build --target clean-all
```

### Alternative: Direct dotnet commands

```bash
# Restore dependencies
dotnet restore

# Build solution
dotnet build --configuration Release

# Run tests
dotnet test --configuration Release

# Format code
dotnet csharpier .

# Pack for NuGet
dotnet pack --configuration Release
```

## Project Structure

```
OpenLanguage/
├── OpenLanguage/                    # Main library
│   ├── SpreadsheetML/
│   │   └── Formula/                 # SpreadsheetML formula processing
│   │       ├── Lang/
│   │       │   ├── Lex/            # Lexical analysis (.lex files)
│   │       │   └── Parse/          # Grammar parsing (.y files)
│   │       ├── Formula.cs          # Main formula API
│   │       └── FormulaParser.cs    # Parser implementation
│   └── WordprocessingML/
│       ├── FieldInstruction/       # WordprocessingML field instructions
│       ├── MergeField/            # Mail merge functionality
│       └── Expression/            # Expression evaluation
├── OpenLanguage.Test/              # Unit tests
├── docs/                          # Documentation
└── CMakeLists.txt                 # Build system configuration
```

## Grammar Files

The project uses GNU YACC/LEX style grammar files for robust parsing:

- **Formula Grammar**: `SpreadsheetML/Formula/Lang/Parse/formula.y`
- **Formula Lexer**: `SpreadsheetML/Formula/Lang/Lex/formula.lex`
- **Function Definitions**: `SpreadsheetML/Formula/Lang/Lex/functions/*.lex`

These files are processed during build to generate C# parser code.

## Documentation

- [API Documentation](./docs/) - Comprehensive API reference
- [Formula Grammar](./docs/SpreadsheetML/Formula/) - Excel formula syntax guide
- [Field Instructions](./docs/WordprocessingML/FieldInstruction/) - Word field processing
- [Examples](./docs/examples/) - Usage examples and tutorials

## Development

### Code Style

This project uses [CSharpier](https://csharpier.com/) for code formatting:

```bash
# Format entire solution
dotnet csharpier format .

# Check formatting
dotnet csharpier check .
```

### Git Hooks

Install git hooks to ensure code quality:

```bash
cmake --build build --target install-hooks
```

This installs a pre-commit hook that:

- Runs code formatting
- Executes all tests
- Prevents commits if tests fail

### Testing

The project uses xUnit for testing:

```bash
# Run all tests
dotnet test

# Run tests with coverage
dotnet test --collect:"XPlat Code Coverage"

# Run specific test project
dotnet test OpenLanguage.Test/
```

## Performance

OpenLanguage is built with performance as a primary concern:

- **Native AOT Ready**: Full compatibility with .NET Native AOT
- **Optimized Grammar**: LALR YACC-style parser used for SpreadsheetML formula parsing with highly optimized, minimal LEX-style grammar.
  Compared against the ABNF grammar specification at each step of implementation.

## Compatibility

- **.NET 9.0**: Primary target framework
- **Native AOT**: Full support for ahead-of-time compilation

## TODO

### Restructure

- [ ] Abstract and reuse formula parser's expression lexing and parsing in all
      applicable parsers
- [ ] Remove hand-written C# expression lexer and parser in WordprocessingML
      namespace

### WordprocessingML

**Parsers**

- [ ] Rewrite field instruction parser with yacc-style GPPG parser.
- [ ] Rewrite field instruction lexer with flex-style GPLEX lexer.
- [ ] Refactor field instruction classes to use derived classes for strongly-typed instructions
      rather than using factories and explicit conversion to strongly typed representation.
- [ ] Rewrite merge field parser with yacc-style GPPG parser.
- [ ] Rewrite merge field lexer with flex-style GPLEX lexer.

**Test Coverage**

- [ ] Greatly expand field instruction parsing and lexing test coverage. Current
      coverage is insufficient for a best-effort proof of efficacy.
- [ ] Greatly expand mergefield parsing and lexing test coverage. Current
      coverage is minimal and does not prove even minimal efficacy.

**Misc**

- [ ] Complete exhaustive enumeration of `CountryRegion` enumerations. The
      current implementation is missing all but the most common enumerations.

**Evaluation**

- [ ] Implement per-class evaluation of strongly typed field instructions.
- [ ] Implement evaluation of parsed merge field.

### SpreadsheetML

Test coverage is quite comprehensive, as are grammar and parser rule
specifications - there should not be anything left to complete here as far as
implementation of parsing, parsing dependencies, nor AST. However, optimization leaves a bit to be desired, and evaluation is unimplemented.

**Optimization**

- [ ] Runtime memory consumption of `FormulaParser` and AST node classes, as
      well as size of generated parser code, jumped by ~10x on adding the
      `builtin_function_call_head_raw` rule. Investigate the cause and resolve.
- [ ] Many Shift, Reduce, Shift/Reduce, and Reduce/Reduce conflicts are
      automatically resolved on code generation of parser. Investigate the cause and
      resolve.

**Evaluation**

- [ ] Implement evaluation of formula, with a per-AST node class method called
      `Evaluate`, on the abstract `ExpressionNode` class and overriden by derived
      classes.
  - [ ] Implement all builtin SpreadsheetML functions.
  - [ ] Implement cell, sheet, table, and range reference resolution for read
        and write of underlying value.
  - [ ] Implement arithmetic expression evaluation.
  - [ ] Implement function reference resolution and call evaluation -
        regardless of whether user-defined, `_xlpm.`-prefixed function references, or
        `LAMBDA` functions.
- [ ] Bonus: implement a shared `SpreadsheetContext` to abstract common data
      reading and writing operations
  - [ ] Bonus if completed: in `SpreadsheetContext`, use generic underlying data representation which
        is derived from a common `Spreadsheet` class, allowing any underlying
        matrix-like data representation to be manipulated by formulas.

**Example Usage**

- [ ] Write a toy formula interpreter when evaluation is implemented.
  - [ ] Bonus: Realtime display and update of spreadsheet cell values in TUI
        with matrix display and formula input prompt as well as vim-style selection of
        corresponding cells. Simulaneously update underlying OPC package on modifying
        values.

## Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Make your changes
4. Ensure tests pass (`cmake --build build --target test`)
5. Ensure code is formatted (`cmake --build build --target format`)
6. Commit your changes (`git commit -m 'Add amazing feature'`)
7. Push to the branch (`git push origin feature/amazing-feature`)
8. Open a Pull Request

## License

This project is licensed under the GNU General Public License v2.0 - see the [LICENSE](LICENSE) file for details.

## Acknowledgments

- Built with [YaccLexTools](https://www.nuget.org/packages/YaccLexTools/) for code generation from GPPG and GPLEX grammar specification and logic
- Uses [DocumentFormat.OpenXml](https://github.com/OfficeDev/Open-XML-SDK) for Open Office XML handling

## Support

- 📖 [Documentation](./docs/)
- 🐛 [Issue Tracker](https://github.com/amkillam/OpenLanguage/issues)
- 💬 [Discussions](https://github.com/amkillam/OpenLanguage/discussions)

# OpenLanguage

[![Build Status](https://github.com/amkillam/OpenLanguage/workflows/CI/badge.svg)](https://github.com/amkillam/OpenLanguage/actions)
[![NuGet Version](https://img.shields.io/nuget/v/OpenLanguage.svg)](https://www.nuget.org/packages/OpenLanguage/)
[![License: GPL v2](https://img.shields.io/badge/License-GPL_v2-blue.svg)](https://www.gnu.org/licenses/old-licenses/gpl-2.0.en.html)

OpenLanguage is a C# library providing lexers, parsers, and other processing tools for Open Office XML DSLs.

## Features

### WordprocessingML

- **Field Instructions**: Parse field instructions into strongly-typed Abstract Syntax Trees (AST)
- **Grammar-Based**: Uses GPLEX/GPPG for robust parsing of field instructions, expressions, and merge fields
- **Comprehensive Field Types**: Support for all field instructions - both standard ECMA variations and those specified in the ISO docs for legacy compatibility
- **AST Manipulation**: Programmatically access and modify parsed structures
- **Field Reconstruction**: Convert ASTs back to valid field instruction strings with round-trip fidelity

### SpreadsheetML

- **Formula Parsing**: Parse SpreadsheetML formulas into Abstract Syntax Trees (AST)
- **Grammar-Based**: Uses GPLEX lexer (.lex) and GPPG yacc parser (.y) for concise and efficient grammar specification and parsing logic
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
using OpenLanguage.WordprocessingML.FieldInstruction.Ast;
using OpenLanguage.WordprocessingML.Ast;

// Parse a field instruction into a strongly-typed AST node
var ast = FieldInstructionParser.Parse("MERGEFIELD FirstName \\* Upper");

// Check the type and use specific properties
if (ast is MergeFieldFieldInstruction mergeField)
{
    Console.WriteLine($"Field Name: {mergeField.FieldName}");
    if (mergeField.GeneralFormat?.Argument is StringLiteralNode format)
    {
        Console.WriteLine($"General Format: {format.Value}");
    }
}

// Reconstruct field instruction
Console.WriteLine($"Field instruction: {ast.ToString()}");
```

## Building from Source

### Prerequisites

- [.NET 8.0+ SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
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
cmake --build build --target pack

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
├── OpenLanguage/                  # Main library
│   ├── SpreadsheetML/
│   │   └── Formula/               # SpreadsheetML formula processing
│   │       ├── Lang/
│   │       │   ├── Lex/           # Lexical analysis (.lex files)
│   │       │   └── Parse/         # Grammar parsing (.y files)
│   │       └── FormulaParser.cs   # Main formula API and parser implementation
│   └── WordprocessingML/
│       ├── FieldInstruction/      # WordprocessingML field instructions
│       ├── MergeField/            # Mail merge functionality
│       └── Expression/            # Expression evaluation
├── OpenLanguage.Test/             # Unit tests
├── docs/                          # Documentation for docfx
├── docfx/                         # Docfx configuration
└── CMakeLists.txt                 # Build system configuration
```

## Grammar Files

The project uses POSIX yacc/lex style grammar files for robust parsing:

- **Formula Grammar**: `SpreadsheetML/Formula/Lang/Parse/formula.y`
- **Formula Lexer**: `SpreadsheetML/Formula/Lang/Lex/formula.lex`
- **Function Definitions**: `SpreadsheetML/Formula/Lang/Lex/function/*.lex`

These files are processed during build to generate C# parser code.

## Documentation

For detailed documentation, please visit the [project documentation site](https://amkillam.github.io/OpenLanguage/).

The source for the documentation is in the `docs/` and `docfx/` directories.

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
- **Optimized Grammar**: LALR yacc parser used for SpreadsheetML formula parsing with highly optimized, minimal lex grammar.
  Compared against the ABNF grammar specification at each step of implementation.

## Compatibility

- **Multi-framework**: Supports both .NET 8.0 and .NET 9.0
- **Native AOT**: Full support for ahead-of-time compilation

## TODO

### WordprocessingML

#### Field Instruction

**Evaluation**

- [ ] Implement per-class evaluation of strongly typed field instructions.
- [ ] Implement execution of parsed merge field.
- [ ] Ensure evaluation is implemented with respect to configured [`decimalSymbol`](https://learn.microsoft.com/en-us/dotnet/api/documentformat.openxml.wordprocessing.decimalsymbol?view=openxml-3.0.1)

**Misc**

- [ ] Allow configuration option for `decimalSymbol` used for parsing floating point numbers
- [ ] Complete exhaustive enumeration of `CountryRegion` enumerations.

#### LevelText

- [ ] Define and implement paragraph numbering level text [placeholder syntax](https://learn.microsoft.com/en-us/dotnet/api/documentformat.openxml.wordprocessing.leveltext?view=openxml-3.0.1) grammar
- [ ] Implement AST parsing of paragraph numbering level text
- [ ] Implement placeholder value evaluator
- [ ] Add API for final, evaluated numbering level text construction

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

### PowerBI

- [ ] Define and implement grammar for Power Query
- [ ] Implement Power Query AST and parser

### VBA

- [ ] Define and implement grammar for VBA
- [ ] Implement VBA AST and parser

### Misc

**Numbering Format**

- [ ] Define and implement a [numbering format](https://support.microsoft.com/en-us/office/review-guidelines-for-customizing-a-number-format-c0a1d1fa-d3f4-4018-96b7-9c9354dd99f5) grammar
- [ ] Implement numbering format AST representation
- [ ] Implement numbering format parser
- [ ] Implement numbering format applicator from AST class

**See also**

- [ST_NumberFormat OOXML WML XSD Type](https://www.datypic.com/sc/ooxml/t-w_ST_NumberFormat.html)
- [Similar JS implementer specific to SML](https://www.npmjs.com/package/ssf)
- [Another similar JS implementer specific to SML](https://www.npmjs.com/package/numfmt/v/2.5.2)
- [Standard format codes](https://c-rex.net/samples/ooxml/e1/Part4/OOXML_P4_DOCX_numFmt_topic_ID0EHDH6.html)
- [XSLT 1.0 Number Format Syntax](https://www.w3schools.com/xml/func_formatnumber.asp). Very similar to SML's, seems to be identical to WML's except for possible differing defaults/keyword-based codes

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

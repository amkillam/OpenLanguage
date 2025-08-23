# OpenLanguage Documentation

Welcome to the documentation for OpenLanguage, a .NET library for parsing Microsoft Office document languages using GPLEX/GPPG-generated lexers and parsers.

## Table of Contents

### Core Library Documentation

#### SpreadsheetML

- [Formula Processing](./OpenLanguage/SpreadsheetML/Formula/Formula.md) - Excel formula parsing with AST generation

#### WordprocessingML

- [Field Instructions](./OpenLanguage/WordprocessingML/FieldInstruction/FieldInstruction.md) - Word field instruction parsing
- [Typed Field Instructions](./OpenLanguage/WordprocessingML/FieldInstruction/Typed.md) - Strongly-typed field instruction factory
- [MergeField Processing](./OpenLanguage/WordprocessingML/MergeField/MergeField.md) - Mail merge field lexing
- [Expression Processing](./OpenLanguage/WordprocessingML/Expression/Expression.md) - Expression lexical analysis
- [ODBC Support](./OpenLanguage/WordprocessingML/ODBC/ODBC.md) - ODBC-related parsing components

### Development

- [Build System](./advanced/build-system.md) - CMake build system with .y/.lex processing
- [Grammar Files](./advanced/grammar-files.md) - Working with YACC and LEX grammar files
- [Testing](./advanced/testing.md) - Unit test documentation

## API Reference

The API reference is generated from XML documentation comments in the source code.

## Quick Navigation

| Component          | Description                    | Documentation                                                                               |
| ------------------ | ------------------------------ | ------------------------------------------------------------------------------------------- |
| Formula Parser     | Excel formula AST parsing      | [Formula.md](./OpenLanguage/SpreadsheetML/Formula/Formula.md)                               |
| Field Instructions | Word field instruction parsing | [FieldInstruction.md](./OpenLanguage/WordprocessingML/FieldInstruction/FieldInstruction.md) |
| Typed Instructions | Strongly-typed field factory   | [Typed.md](./OpenLanguage/WordprocessingML/FieldInstruction/Typed.md)                       |
| MergeField Lexer   | Mail merge field lexing        | [MergeField.md](./OpenLanguage/WordprocessingML/MergeField/MergeField.md)                   |
| Expression Lexer   | Expression lexical analysis    | [Expression.md](./OpenLanguage/WordprocessingML/Expression/Expression.md)                   |
| ODBC Components    | ODBC parsing support           | [ODBC.md](./OpenLanguage/WordprocessingML/ODBC/ODBC.md)                                     |

## Project Structure

OpenLanguage consists of:

- **SpreadsheetML.Formula**: Excel formula parser using GPLEX/GPPG
  - Formula.cs: Main API for parsing formulas into ASTs
  - FormulaParser.cs: Static parser methods
  - Lang/Lex/formula.lex: Lexical grammar for Excel formulas
  - Lang/Parse/formula.y: YACC grammar for Excel formulas
- **WordprocessingML.FieldInstruction**: Word field instruction parser

  - FieldInstruction.cs: Core field instruction and argument classes
  - Typed/: Factory and base classes for strongly-typed instructions
  - Parser.cs & Lexer.cs: Generated parser components

- **Other WordprocessingML Components**:
  - MergeField, Expression, ODBC: Additional lexer components

## Build System

The project uses CMake to process .y and .lex files with the C preprocessor (cpp) before compilation. Generated code is placed in the Generated/ directory.

## Testing

Unit tests are located in OpenLanguage.Test/ and use xUnit framework. Tests cover:

- Formula parsing with various Excel syntax
- Field instruction creation and manipulation
- Argument type validation
- AST reconstruction and round-trip testing

## Support

- 📖 View source code for implementation details
- 🐛 [Issue Tracker](https://github.com/amkillam/OpenLanguage/issues)
- 📧 Contact the maintainers through GitHub

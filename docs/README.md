# OpenLanguage Documentation

Welcome to the documentation for OpenLanguage, a .NET library for parsing Microsoft Office document languages using GPLEX/GPPG-generated lexers and parsers.

## Table of Contents

### Core Library Documentation

#### SpreadsheetML

- [Formula Processing](api/SpreadsheetML/Formula/Formula.md) - SpreadsheetML formula parsing with AST generation

#### WordprocessingML

- [Field Instructions](api/WordprocessingML/FieldInstruction/FieldInstruction.md) - WordprocessingML field instruction parsing
- [Typed Field Instructions](api/WordprocessingML/FieldInstruction/Typed.md) - Strongly-typed field instruction factory
- [MergeField Processing](api/WordprocessingML/MergeField/MergeField.md) - Mail merge field lexing
- [Expression Processing](api/WordprocessingML/Expression/Expression.md) - Expression lexical analysis

### Development

- [Build System](development/build.md) - CMake build system with GPPG GNU YACC-style parser generation and GPLEX GNU Flex-style lexer generation
- [Grammar Files](development/grammar.md) - Working with YACC and LEX grammar files
- [Testing](development/test.md) - Unit test documentation

## API Reference

The API reference is generated from XML documentation comments in the source code.

## Quick Navigation

| Component          | Description                                | Documentation                                                                    |
| ------------------ | ------------------------------------------ | -------------------------------------------------------------------------------- |
| Formula Parser     | SpreadsheetML formula AST parsing          | [Formula.md](api/SpreadsheetML/Formula/Formula.md)                               |
| Field Instructions | WordprocessingML field instruction parsing | [FieldInstruction.md](api/WordprocessingML/FieldInstruction/FieldInstruction.md) |
| Typed Instructions | Strongly-typed field factory               | [Typed.md](api/WordprocessingML/FieldInstruction/Typed.md)                       |
| MergeField Lexer   | Mail merge field lexing                    | [MergeField.md](api/WordprocessingML/MergeField/MergeField.md)                   |
| Expression Lexer   | Expression lexical analysis                | [Expression.md](api/WordprocessingML/Expression/Expression.md)                   |

## Project Structure

OpenLanguage consists of:

- **SpreadsheetML.Formula**: SpreadsheetML formula parser using GPLEX/GPPG
  - Formula.cs: Main API for parsing formulas into ASTs
  - FormulaParser.cs: Static parser methods
  - Lang/Lex/formula.lex: Lexical grammar for SpreadsheetML formulas
  - Lang/Parse/formula.y: YACC grammar for SpreadsheetML formulas
- **WordprocessingML.FieldInstruction**: WordprocessingML field instruction parser

  - FieldInstruction.cs: Core field instruction and argument classes
  - Typed/: Factory and base classes for strongly-typed instructions
  - Parser.cs & Lexer.cs: Parser components

- **Other WordprocessingML Components**:
  - MergeField, Expression: Additional lexer components

## Build System

The project uses CMake to process .y and .lex files with the C preprocessor (cpp) before compilation. Generated code is placed in the Generated/ directory.

## Testing

Unit tests are located in OpenLanguage.Test/ and use xUnit framework. Tests cover:

- Formula parsing with various combinations of pattern cases
- Field instruction creation and manipulation
- Argument type validation
- AST reconstruction and round-trip testing

## Support

- 📖 [View source code](https://github.com/amkillam/OpenLanguage) for implementation details
- 🐛 [Issue Tracker](https://github.com/amkillam/OpenLanguage/issues)
- 📧 Contact the maintainers through GitHub

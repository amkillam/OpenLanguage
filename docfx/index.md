# OpenLanguage

Welcome to the documentation for OpenLanguage, a C# library for parsing Microsoft Office document languages.

## Overview

OpenLanguage provides robust, grammar-based parsers for:

- **SpreadsheetML Formulas**: Full support for Excel formula syntax, including functions, operators, and all reference types.
- **WordprocessingML**:
  - **Field Instructions**: Support for parsing all field instructions - both standard ECMA variations and those specified in the ISO docs for legacy compatibility - into a strongly-typed Abstract Syntax Tree (AST).
  - **Expressions**: A parser for expressions used commonly in WordprocessingML values (e.g., conditional formatting, content controls, field instructions).
  - **Merge Fields**: Parsers for `MERGEFIELD` placeholders and templates.

The library's parsers and lexers are built using GPLEX and GPPG, allowing concise, declarative grammar definitions that are easy to extend and maintain.

## Key Features

- **Strongly-Typed ASTs**: Convert complex language strings into easy-to-navigate C# object models.
- **Round-Trip Fidelity**: Reconstruct the original string from the parsed AST, preserving all components including whitespace.
- **Extensible Grammar**: The yacc/lex-based grammar is modular and easy to extend.
- **High Performance**: Designed with performance in mind, including support for Native AOT.

## Getting Started

To get started with OpenLanguage, install the package from NuGet and explore the examples.

```bash
dotnet add package OpenLanguage
```

- **[Formula Parsing Examples](examples/formula.md)**
- **[Field Instruction Examples](examples/field-instruction.md)**

## API Reference

Browse the [API documentation](api/OpenLanguage.html) for detailed information about classes, methods, and interfaces.

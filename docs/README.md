# OpenLanguage Documentation

Welcome to the comprehensive documentation for OpenLanguage, a powerful .NET library for processing Microsoft Office Open XML documents.

## Table of Contents

### Core Library Documentation

#### SpreadsheetML

- [Formula Processing](./OpenLanguage/SpreadsheetML/Formula/Formula.md) - Excel formula parsing and evaluation
- [Formula Grammar Reference](./OpenLanguage/SpreadsheetML/Formula/Grammar.md) - Complete grammar specification
- [Function Categories](./OpenLanguage/SpreadsheetML/Formula/Functions.md) - Available function categories

#### WordprocessingML

- [Field Instructions](./OpenLanguage/WordprocessingML/FieldInstruction/FieldInstruction.md) - Word field instruction processing
- [Typed Field Instructions](./OpenLanguage/WordprocessingML/FieldInstruction/Typed.md) - Type-safe field instruction handling
- [Merge Fields](./OpenLanguage/WordprocessingML/MergeField/MergeField.md) - Mail merge functionality
- [Expression Processing](./OpenLanguage/WordprocessingML/Expression/Expression.md) - Expression evaluation engine
- [ODBC Integration](./OpenLanguage/WordprocessingML/ODBC/ODBC.md) - Database connectivity features

### Guides and Examples

- [Getting Started](./guides/getting-started.md) - Quick start guide
- [Examples](./examples/) - Code examples and tutorials
- [Best Practices](./guides/best-practices.md) - Recommended usage patterns
- [Performance Guide](./guides/performance.md) - Optimization strategies

### Advanced Topics

- [Grammar Files](./advanced/grammar-files.md) - Working with .y and .lex files
- [Build System](./advanced/build-system.md) - CMake build system documentation
- [Contributing](./advanced/contributing.md) - Development and contribution guidelines

## API Reference

The complete API reference is generated automatically from XML documentation comments and is available at:

- [Online API Documentation](https://amkillam.github.io/OpenLanguage/docs/latest/)
- [Latest Release Documentation](https://amkillam.github.io/OpenLanguage/docs/)

## Quick Navigation

| Component          | Description           | Documentation                                                                               |
| ------------------ | --------------------- | ------------------------------------------------------------------------------------------- |
| Formula Parser     | Excel formula parsing | [Formula.md](./OpenLanguage/SpreadsheetML/Formula/Formula.md)                               |
| Field Instructions | Word field processing | [FieldInstruction.md](./OpenLanguage/WordprocessingML/FieldInstruction/FieldInstruction.md) |
| Merge Fields       | Mail merge operations | [MergeField.md](./OpenLanguage/WordprocessingML/MergeField/MergeField.md)                   |
| ODBC Integration   | Database connectivity | [ODBC.md](./OpenLanguage/WordprocessingML/ODBC/ODBC.md)                                     |
| Expression Engine  | Expression evaluation | [Expression.md](./OpenLanguage/WordprocessingML/Expression/Expression.md)                   |

## Documentation Standards

All documentation in this project follows these standards:

- **Markdown Format**: All documentation uses GitHub-flavored Markdown
- **Code Examples**: Every API includes working code examples
- **Version Information**: Documentation is versioned alongside releases
- **Cross-References**: Extensive linking between related topics
- **Accessibility**: Documentation is accessible and screen-reader friendly

## Contributing to Documentation

We welcome contributions to improve our documentation! Please see our [Contributing Guide](./advanced/contributing.md) for details on:

- Documentation style guide
- How to add new documentation
- Review process for documentation changes
- Building documentation locally

## Support

If you need help with OpenLanguage:

1. Check this documentation first
2. Look at our [Examples](./examples/)
3. Search existing [Issues](https://github.com/amkillam/OpenLanguage/issues)
4. Create a new issue if needed

---

_This documentation is automatically updated with each release of OpenLanguage._

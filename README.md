# OpenLanguage

[![Build Status](https://github.com/amkillam/OpenLanguage/workflows/CI/badge.svg)](https://github.com/amkillam/OpenLanguage/actions)
[![NuGet Version](https://img.shields.io/nuget/v/OpenLanguage.svg)](https://www.nuget.org/packages/OpenLanguage/)
[![License: GPL v2](https://img.shields.io/badge/License-GPL_v2-blue.svg)](https://www.gnu.org/licenses/old-licenses/gpl-2.0.en.html)

A comprehensive .NET library for parsing and processing Microsoft Office Open XML documents, with advanced language processing capabilities for WordprocessingML and SpreadsheetML formats.

## Features

### 🔍 WordprocessingML Support

- **Field Instructions**: Parse and process Word document field instructions
- **Merge Fields**: Handle mail merge field operations
- **ODBC Integration**: Support for database connectivity in Word documents
- **Expression Processing**: Evaluate complex expressions within documents

### 📊 SpreadsheetML Support

- **Formula Parsing**: Complete Excel formula parser with support for all standard functions
- **Function Categories**:
  - Standard worksheet functions
  - Future functions
  - Command functions
  - Macro functions
- **Advanced Grammar**: YACC/LEX-based parsing for robust formula processing

### ⚡ Performance & Quality

- **AOT Compatible**: Full support for Native AOT compilation
- **Optimized**: Built with performance-first approach
- **Type Safe**: Nullable reference types enabled throughout
- **Zero Warnings**: Treats warnings as errors for maximum code quality

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
var formula = "SUM(A1:A10) + AVERAGE(B1:B10)";
var parser = new FormulaParser();
var result = parser.Parse(formula);

// Access parsed components
Console.WriteLine($"Parsed formula: {result}");
```

### Field Instruction Processing

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction;

// Process Word field instructions
var fieldInstruction = "MERGEFIELD FirstName \* MERGEFORMAT";
var parser = new FieldInstructionParser();
var parsed = parser.Parse(fieldInstruction);

Console.WriteLine($"Field type: {parsed.FieldType}");
Console.WriteLine($"Field name: {parsed.FieldName}");
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
│   │   └── Formula/                 # Excel formula processing
│   │       ├── Lang/
│   │       │   ├── Lex/            # Lexical analysis (.lex files)
│   │       │   └── Parse/          # Grammar parsing (.y files)
│   │       ├── Formula.cs          # Main formula API
│   │       └── FormulaParser.cs    # Parser implementation
│   ├── WordprocessingML/
│   │   ├── FieldInstruction/       # Word field instructions
│   │   ├── MergeField/            # Mail merge functionality
│   │   ├── Expression/            # Expression evaluation
│   │   └── ODBC/                  # Database connectivity
│   └── Generated/                  # Auto-generated code (ignored in git)
├── OpenLanguage.Test/              # Unit tests
├── docs/                          # Documentation
└── CMakeLists.txt                 # Build system configuration
```

## Grammar Files

The project uses YACC/LEX grammar files for robust parsing:

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
dotnet csharpier .

# Check formatting
dotnet csharpier --check .
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

## Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Make your changes
4. Ensure tests pass (`cmake --build build --target test`)
5. Ensure code is formatted (`cmake --build build --target format`)
6. Commit your changes (`git commit -m 'Add amazing feature'`)
7. Push to the branch (`git push origin feature/amazing-feature`)
8. Open a Pull Request

## Performance

OpenLanguage is built with performance as a primary concern:

- **Native AOT Ready**: Full compatibility with .NET Native AOT
- **Zero Allocation Parsing**: Minimal memory allocations during parsing
- **Optimized Grammar**: Hand-tuned YACC/LEX grammars for maximum performance
- **Unsafe Code**: Strategic use of unsafe code for performance-critical paths

## Compatibility

- **.NET 9.0**: Primary target framework
- **Native AOT**: Full support for ahead-of-time compilation
- **Trimming**: Compatible with .NET trimming for smaller deployments
- **Nullable**: Full nullable reference type annotations

## License

This project is licensed under the GNU General Public License v2.0 - see the [LICENSE](LICENSE) file for details.

## Acknowledgments

- Built with [YaccLexTools](https://www.nuget.org/packages/YaccLexTools/) for grammar processing
- Uses [DocumentFormat.OpenXml](https://github.com/OfficeDev/Open-XML-SDK) for Open Office XML handling
- Inspired by the Microsoft Office Open XML specification

## Support

- 📖 [Documentation](./docs/)
- 🐛 [Issue Tracker](https://github.com/amkillam/OpenLanguage/issues)
- 💬 [Discussions](https://github.com/amkillam/OpenLanguage/discussions)
- 📧 Email: support@openlanguage.dev

---

**OpenLanguage** - Empowering developers with robust Office document processing capabilities.

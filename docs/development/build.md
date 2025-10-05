# Build System

OpenLanguage uses a sophisticated CMake-based build system designed to handle .NET projects with yacc/lex grammar file preprocessing. This document provides comprehensive information about the build system architecture, targets, and usage.

## Overview

The build system is architected around CMake 3.20+ and provides several key capabilities:

- **Cross-platform .NET Runtime Identifier (RID) detection and configuration**
- **Automatic preprocessing of .y (yacc) and .lex (lex) grammar files using the C preprocessor**
- **Multi-target compilation for different runtime architectures**
- **Integration with .NET toolchain for building, testing, and packaging**
- **Code formatting and documentation generation**
- **Git hooks installation for development workflow**

## Architecture

### Project Structure

```
OpenLanguage/
├── CMakeLists.txt              # Main build configuration
├── OpenLanguage/               # Main .NET project
│   ├── OpenLanguage.csproj    # .NET project file
│   ├── Generated/             # Preprocessed grammar files (created during build)
│   └── SpreadsheetML/Formula/Lang/
│       ├── Parse/formula.y    # yacc grammar file
│       └── Lex/               # lex lexer files
│           ├── formula.lex    # Main lexer
│           └── function/      # Function definition lexer files
├── OpenLanguage.Test/         # Unit test project
├── hooks/                     # Git hooks
└── build/                     # CMake build directory (created during build)
```

### Build Process Flow

1. **RID Detection**: Automatically detects the target platform and architecture
2. **Grammar Preprocessing**: Processes .y and .lex files with cpp (C preprocessor)
3. **Code Generation**: GPPG/GPLEX tools generate C# parser/lexer code from grammar files
4. **Compilation**: Builds the .NET solution for specified RIDs
5. **Testing**: Runs xUnit tests with the compiled assemblies
6. **Packaging**: Creates NuGet packages for distribution

## Runtime Identifier (RID) Configuration

### Automatic Detection

The build system automatically detects the platform and architecture:

**Supported Architectures:**

- `x64` (x86_64, AMD64)
- `arm64` (aarch64, arm64)
- `x86` (i386-i686, x86)

**Supported Operating Systems:**

- `linux` (Linux)
- `osx` (macOS)
- `win` (Windows)
- `freebsd` (FreeBSD)

**Example RIDs:**

- `linux-x64`
- `win-x64`
- `osx-arm64`

### Manual Override

You can override the detected RID:

```bash
# Configure for specific RID
cmake -B build -DRUNTIMES="linux-x64"

# Configure for multiple RIDs
cmake -B build -DRUNTIMES="linux-x64;win-x64;osx-arm64"
```

## Grammar File Processing

### Overview

The build system automatically processes yacc (.y) and lex (.lex) files using the C preprocessor before compilation. This enables:

- **Conditional compilation** using `#ifdef`, `#ifndef`, `#define`
- **File inclusion** using `#include`
- **Macro expansion** for code reuse
- **Platform-specific grammar variants**

### Processing Pipeline

1. **Discovery**: CMake scans for all `.y` and `.lex` files in the project
2. **Filtering**: Excludes files already in the `Generated/` directory
3. **Preprocessing**: Runs `cpp -P` with `-Wno-invalid-pp-token` flag
4. **Output**: Places processed files in `Generated/` directory maintaining folder structure

### Example

**Source**: `OpenLanguage/SpreadsheetML/Formula/Lang/Lex/formula.lex`
**Output**: `OpenLanguage/Generated/SpreadsheetML/Formula/Lang/Lex/formula.lex`

The preprocessed files are then used by GPPG/GPLEX tools to generate C# parser code.

## Build Targets

### Core Targets

#### `process`

Preprocesses all .y and .lex files using cpp.

```bash
cmake --build build --target process
```

**Dependencies**: None  
**Output**: Processed grammar files in `Generated/` directory

#### `build`

Compiles the solution for all configured RIDs.

```bash
cmake --build build --target build
```

**Dependencies**: `process`  
**Output**: Compiled binaries in `build/publish/` directory

#### `test`

Runs all unit tests using xUnit.

```bash
cmake --build build --target test
```

**Dependencies**: `build`  
**Command**: `dotnet test --configuration Release --no-build --verbosity normal`

### Utility Targets

#### `format`

Formats all C# code using CSharpier.

```bash
cmake --build build --target format
```

**Commands**:

```bash
dotnet tool restore
dotnet csharpier format .
```

#### `doc`

Generates API documentation using DocFX.

```bash
cmake --build build --target doc
```

**Dependencies**: `build`  
**Output**: Generated documentation in `docfx/_site/`

#### `pack`

Packs NuGet packages for distribution.

```bash
cmake --build build --target pack
```

**Dependencies**: `build`  
**Output**: NuGet packages in `build/packages/`

#### `install-hooks`

Installs git pre-commit hooks for development.

```bash
cmake --build build --target install-hooks
```

**Actions**:

- Copies `hooks/pre-commit` to `.git/hooks/pre-commit`
- Makes the hook executable with `chmod +x`

#### `clean-all`

Removes all build artifacts and generated files.

```bash
cmake --build build --target clean-all
```

**Actions**:

- Removes `build/` directory
- Removes `Generated/` directory
- Removes all `obj/` and `bin/` directories

### Default Target

#### `default` (ALL)

The default target that runs when no specific target is specified.

```bash
cmake --build build
```

**Dependencies**: `process`, `build`

## Build Configuration

### CMake Variables

| Variable           | Description                           | Default           |
| ------------------ | ------------------------------------- | ----------------- |
| `RUNTIMES`         | Semicolon-separated list of .NET RIDs | Auto-detected RID |
| `CMAKE_BUILD_TYPE` | Build configuration                   | Release           |

### Project Variables

| Variable           | Description               |
| ------------------ | ------------------------- |
| `SOLUTION_FILE`    | Path to .sln file         |
| `PROJECT_DIR`      | Main project directory    |
| `GENERATED_DIR`    | Generated files directory |
| `TEST_PROJECT_DIR` | Test project directory    |

### .NET Project Configuration

The `OpenLanguage.csproj` file includes:

```xml
<PropertyGroup>
  <TargetFramework>net9.0</TargetFramework>
  <PublishAot>true</PublishAot>
  <PublishTrimmed>true</PublishTrimmed>
  <Nullable>enable</Nullable>
  <TreatWarningsAsErrors>true</TreatWarningsAsErrors>
</PropertyGroup>
```

**Key Features:**

- **AOT Compilation**: Native ahead-of-time compilation support
- **Trimming**: Removes unused code for smaller binaries
- **Nullable Reference Types**: Enhanced type safety
- **Warnings as Errors**: Strict code quality enforcement

## Usage Examples

### Basic Development Workflow

```bash
# Initial setup
cmake -B build

# Development cycle
cmake --build build --target format  # Format code
cmake --build build --target build   # Build solution
cmake --build build --target test    # Run tests

# Install git hooks (one-time setup)
cmake --build build --target install-hooks
```

### Multi-Platform Build

```bash
# Configure for multiple platforms
cmake -B build -DRUNTIMES="linux-x64;win-x64;osx-arm64"

# Build for all platforms
cmake --build build --target build

# Artifacts will be in:
# build/publish/OpenLanguage/linux-x64/
# build/publish/OpenLanguage/win-x64/
# build/publish/OpenLanguage/osx-arm64/
```

### Grammar File Development

```bash
# After modifying .y or .lex files
cmake --build build --target process  # Preprocess grammar files
cmake --build build --target build    # Rebuild with new grammar
cmake --build build --target test     # Verify changes
```

### Release Preparation

```bash
# Full release build
cmake --build build --target clean-all  # Clean everything
cmake -B build                          # Reconfigure
cmake --build build --target format     # Format code
cmake --build build --target build      # Build solution
cmake --build build --target test       # Run tests
cmake --build build --target doc        # Generate docs
cmake --build build --target pack       # Pack for distribution
```

## Integration with .NET Tools

### YaccLexTools Integration

The project uses YaccLexTools packages for grammar processing:

- **YaccLexTools.Gppg**: yacc parser generator
- **YaccLexTools.GPLEX**: lex lexer generator

The .csproj file configures these tools:

```xml
<YaccFile Include="Generated/SpreadsheetML/Formula/Lang/Parse/formula.y">
  <OutputFile>Generated/SpreadsheetML/Formula/Lang/Parse/Formula.Parser.Generated.cs</OutputFile>
  <Arguments>/GPLEX /nolines</Arguments>
</YaccFile>
```

### CSharpier Integration

Code formatting is handled by CSharpier:

```bash
# Format entire solution
dotnet csharpier format .

# Check formatting without changes
dotnet csharpier check .
```

### DocFX Integration

Documentation generation uses DocFX:

```bash
# Generate API documentation
docfx metadata docfx/docfx.json
docfx build docfx/docfx.json
```

## Troubleshooting

### Common Issues

**Issue**: Grammar file changes not reflected in build  
**Solution**: Run `cmake --build build --target process` to regenerate preprocessed files

**Issue**: RID detection fails  
**Solution**: Manually specify RID with `-DRUNTIMES="your-rid"`

**Issue**: Build fails with missing cpp  
**Solution**: Install GCC or Clang toolchain for C preprocessor

**Issue**: Tests fail after grammar changes  
**Solution**: Rebuild completely with `clean-all` then `build`

### Build Dependencies

**Required Tools:**

- CMake 3.20+
- .NET 8.0 or .NET 9.0
- C preprocessor (cpp) - usually part of GCC/Clang
- Git (for hooks installation)

**Optional Tools:**

- DocFX (for documentation generation)
- CSharpier (for code formatting - installed via dotnet tool restore)

### Performance Optimization

**Parallel Builds:**

```bash
# Use multiple CPU cores
cmake --build build --parallel $(nproc)
```

**Incremental Builds:**
The build system supports incremental builds - only changed files are reprocessed and recompiled.

**Build Cache:**
Generated files are cached in the `Generated/` directory and only regenerated when source grammar files change.

## Advanced Configuration

### Custom Preprocessor Flags

You can modify the preprocessing step by editing the CMakeLists.txt file:

```cmake
# Add custom preprocessor definitions
add_custom_command(
    TARGET process PRE_BUILD
    COMMAND cpp -P ${yacc_FILE} -o ${OUTPUT_FILE} -DCUSTOM_FLAG -Wno-invalid-pp-token
    COMMENT "Processing ${yacc_FILE} -> ${OUTPUT_FILE}"
)
```

### Custom Build Targets

Add custom targets for specific workflows:

```cmake
# Custom target for development builds
add_custom_target(dev
    COMMAND cmake --build . --target format
    COMMAND cmake --build . --target build
    COMMAND cmake --build . --target test
    COMMENT "Development build cycle"
)
```

## Integration with IDEs

### Visual Studio Code

Recommended extensions:

- C# Dev Kit
- CMake Tools
- EditorConfig for VS Code

### Visual Studio

The solution file `OpenLanguage.sln` can be opened directly in Visual Studio. Use the CMake build targets from the command line or integrate with VS build system.

### JetBrains Rider

Rider supports both the .NET solution and CMake build system. Configure CMake profiles for different RID targets.

## Continuous Integration

The build system is designed for CI/CD pipelines:

```yaml
# Example GitHub Actions workflow
- name: Configure CMake
  run: cmake -B build

- name: Build
  run: cmake --build build --target build

- name: Test
  run: cmake --build build --target test

- name: Pack
  run: cmake --build build --target pack
```

The build system's deterministic output and cross-platform support make it ideal for automated build environments.

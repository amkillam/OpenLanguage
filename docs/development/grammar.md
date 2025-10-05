# Grammar Files

OpenLanguage uses POSIX yacc and lex style grammar files to define the lexical analysis and parsing rules for Microsoft Office document languages. This document provides comprehensive information about working with these grammar files, their structure, and the code generation process.

## Overview

The grammar files in OpenLanguage serve as the foundation for parsing SpreadsheetML formulas and WordprocessingML field instructions. The system uses:

- **GPPG (GNU Parser Parser Generator)**: A yacc-compatible parser generator for .NET
- **GPLEX (GNU Parser Lexer Generator)**: A lex-compatible lexer generator for .NET
- **C Preprocessor Integration**: Enables conditional compilation and macro expansion

## Grammar File Architecture

### File Organization

The grammar files are organized by language component:

**SpreadsheetML Formula Parser:**

```
OpenLanguage/SpreadsheetML/Formula/Lang/
├── Lex/
│   ├── core.lex
│   ├── formula.lex
│   ├── function/
│   │   ├── command.lex
│   │   ├── future.lex
│   │   ├── macro.lex
│   │   ├── standard.lex
│   │   └── worksheet.lex
│   └── whitespace.lex
└── Parse/
    ├── formula.y
    └── function/
        ├── command/
        │   ├── nodes.inc
        │   ├── rules.inc
        │   ├── tokens.inc
        │   └── types.inc
        ├── future/
        │   ├── nodes.inc
        │   ├── rules.inc
        │   ├── tokens.inc
        │   └── types.inc
        ├── macro/
        │   ├── nodes.inc
        │   ├── rules.inc
        │   ├── tokens.inc
        │   └── types.inc
        ├── standard/
        │   ├── nodes.inc
        │   ├── rules.inc
        │   ├── tokens.inc
        │   └── types.inc
        └── worksheet/
            ├── nodes.inc
            ├── rules.inc
            ├── tokens.inc
            └── types.inc
```

**WordprocessingML Parsers:**

```
OpenLanguage/WordprocessingML/
├── Expression/Lang/
│   ├── Lex/
│   │   ├── expression.lex
│   │   └── whitespace.lex
│   └── Parse/expression.y
├── FieldInstruction/Lang/
│   ├── Lex/
│   │   ├── field_instruction.lex
│   │   ├── switch.lex
│   │   └── whitespace.lex
│   └── Parse/
│       ├── field_instruction.y
│       ├── instruction/
│       │   ├── rule.inc
│       │   ├── token.inc
│       │   └── type.inc
│       └── switch/
│           ├── rule.inc
│           ├── token.inc
│           └── type.inc
└── MergeField/Lang/
    ├── Lex/
    │   ├── merge_field.lex
    │   ├── template.lex
    │   └── whitespace.lex
    └── Parse/
        ├── merge_field.y
        └── template.y
```

### Processing Pipeline

1. **Source Grammar Files**: Original .y and .lex files with preprocessor directives
2. **Preprocessing**: C preprocessor (cpp) processes conditional compilation and includes
3. **Generated Grammar Files**: Processed files placed in `Generated/` directory
4. **Code Generation**: GPPG/GPLEX generate C# parser and lexer classes
5. **Compilation**: Generated C# code compiled into the final assembly

## yacc Grammar Files (.y)

### Structure

yacc grammar files define the syntactic structure of the language using BNF-like notation.

#### Header Section

```yacc
%namespace OpenLanguage.SpreadsheetML.Formula.Generated
%parsertype Parser
%tokentype Tokens
%visibility public

%using OpenLanguage.SpreadsheetML.Formula.Ast;
%using System.Linq;
```

**Key Directives:**

- `%namespace`: Specifies the namespace for generated code
- `%parsertype`: Names the generated parser class
- `%tokentype`: Defines the token enumeration type
- `%visibility`: Sets access modifier for generated classes
- `%using`: Adds using statements to generated code

#### Union Section

```yacc
%union
{
    public double doubleVal;
    public int integerVal;
    public string stringVal;
    public Node nodeVal;
    public ExpressionNode expressionVal;
    public List<ExpressionNode> expressionListVal;
    // ... additional types
}
```

The union section defines the data types that can be associated with grammar symbols.

#### Token Declarations

```yacc
%token T_EQUALS T_PLUS T_MINUS T_MULTIPLY T_DIVIDE
%token T_POWER T_PERCENT T_CONCAT
%token T_LT T_LE T_GT T_GE T_EQ T_NE
%token <stringVal> T_IDENTIFIER T_STRING_LITERAL
%token <doubleVal> T_NUMBER
```

**Token Types:**

- **Operators**: Mathematical and logical operators
- **Literals**: Numbers, strings, booleans
- **Identifiers**: Cell references, named ranges, functions
- **Delimiters**: Parentheses, brackets, commas
- **Special**: Structured references, array delimiters

#### Grammar Rules

```yacc
expression:
    non_union_expression { $$ = $1; }
  | expression T_COMMA non_union_expression { $$ = new UnionNode($1, new CommaNode($2), $3); }
  ;

non_union_expression:
    primary                                                  { $$ = $1; }
  | non_union_expression T_PLUS non_union_expression         { $$ = new AddNode($1, new PlusLiteralNode($2), $3); }
  | non_union_expression T_MINUS non_union_expression        { $$ = new SubtractNode($1, new MinusLiteralNode($2), $3); }
  ;
```

**Grammar Rule Components:**

- **Left-hand side**: Non-terminal symbol being defined
- **Right-hand side**: Sequence of terminals and non-terminals
- **Semantic action**: C# code in braces `{ }` that constructs AST nodes
- **`$$`**: Represents the value of the left-hand side symbol
- **`$1`, `$2`, etc.**: Represent values of right-hand side symbols

### AST Node Construction

The grammar rules construct Abstract Syntax Tree (AST) nodes:

```yacc
function_call
    : function_call_head T_LPAREN argument_list T_RPAREN
    {
        $$ = new FunctionCallNode($1, $3);
    }
    ;

argument_list
    : /* empty */               { $$ = new List<ExpressionNode>(); }
    | expression               { $$ = new List<ExpressionNode> { $1 }; }
    | argument_list T_COMMA expression
    {
        $1.Add($3);
        $$ = $1;
    }
    ;
```

### Precedence and Associativity

```yacc
%right T_COMMA
%left T_INTERSECTION T_NEWLINE
%left T_COLON
%left T_EQ T_NE T_LT T_LE T_GT T_GE
%left T_AMPERSAND
%left T_PLUS T_MINUS
%left T_ASTERISK T_SLASH
%right T_CARET
%left UMINUS
%left T_PERCENT
%right T_POUND
```

**Precedence Rules:**

- **Lower precedence**: Listed first (T_COMMA)
- **Higher precedence**: Listed last (T_PERCENT)
- **Associativity**: `%left` (left-associative), `%right` (right-associative)

## lex Grammar Files (.lex)

### Structure

lex files define lexical analysis rules using regular expressions.

#### Header Section

```lex
%using OpenLanguage.Utils;
%namespace OpenLanguage.SpreadsheetML.Formula.Generated
%scannertype FormulaScanner
%tokentype Tokens
%visibility internal

%{
    private System.Text.StringBuilder stringBuffer = new System.Text.StringBuilder();
    public Parser Parser { get; set; }
%}
```

#### State Declarations

```lex
%x IN_STRING
%x IN_QUOTED_SHEET_NAME
%x IN_A1_CELL
%x IN_R1C1_CELL
```

**Start Conditions:**

- `%x`: Exclusive start condition
- `%s`: Inclusive start condition

Start conditions enable context-sensitive lexical analysis.

#### Pattern Rules

```lex
%%

<INITIAL>{
    "                  { BEGIN(IN_STRING); stringBuffer.Clear(); }
    "<>"                { return (int)Tokens.T_NE; }
    ">="                { return (int)Tokens.T_GE; }
    "<="                { return (int)Tokens.T_LE; }

    [A-Z]+[1-9][0-9]*   { return (int)Tokens.T_A1_CELL; }
    [0-9]+(\.[0-9]+)?   { return (int)Tokens.T_NUMBER; }
    [A-Za-z_][A-Za-z0-9_]* { return (int)Tokens.T_IDENTIFIER; }
}

<IN_STRING>{
    \"\"                  { stringBuffer.Append('"'); }
    \"                    { BEGIN(SR_POSSIBLE); yylval.stringVal = stringBuffer.ToString(); return (int)Tokens.T_STRING_CONSTANT; }
    [^"]+                { stringBuffer.Append(yytext); }
}
```

**Pattern Syntax:**

- **Character classes**: `[A-Z]`, `[0-9]`, `[^"]`
- **Quantifiers**: `+` (one or more), `*` (zero or more), `?` (optional)
- **Anchors**: `^` (start of line), `$` (end of line)
- **Groups**: `()` for grouping
- **Alternation**: `|` for alternatives

### Function Definition Files

The SpreadsheetML formula lexer includes separate files for different function categories:

#### standard.lex

```lex
/* Standard Function Keywords */
"ABS"       { return (int)Tokens.T_FUNC_ABS; }
"AVERAGE"   { return (int)Tokens.T_FUNC_AVERAGE; }
"COUNT"     { return (int)Tokens.T_FUNC_COUNT; }
"MAX"       { return (int)Tokens.T_FUNC_MAX; }
"MIN"       { return (int)Tokens.T_FUNC_MIN; }
"SUM"       { return (int)Tokens.T_FUNC_SUM; }
```

#### worksheet.lex

```lex
/* Worksheet Function Keywords */
"FILTER"   { return (int)Tokens.T_FUNC_FILTER; }
"SORT"     { return (int)Tokens.T_FUNC_SORT; }
"PY"       { return (int)Tokens.T_FUNC_PY; }
```

This modular approach enables:

- **Organized function definitions** by category
- **Easy maintenance** and updates
- **Conditional inclusion** of function sets
- **Extensibility** for new function categories

## Code Generation Process

### GPPG Parser Generation

The yacc file is processed by GPPG to generate a C# parser class:

```xml
<YaccFile Include="Generated/SpreadsheetML/Formula/Lang/Parse/formula.y">
  <OutputFile>Generated/SpreadsheetML/Formula/Lang/Parse/Formula.Parser.Generated.cs</OutputFile>
  <Arguments>/GPLEX /nolines</Arguments>
</YaccFile>
```

**Generated Components:**

- **Parser class**: Implements LALR(1) parsing algorithm
- **Token enumeration**: Defines all terminal symbols
- **Parse tables**: State transition and action tables
- **Error handling**: Syntax error reporting and recovery

### GPLEX Lexer Generation

The lex file is processed by GPLEX to generate a C# lexer class:

```xml
<LexFile Include="Generated/SpreadsheetML/Formula/Lang/Lex/formula.lex">
  <OutputFile>Generated/SpreadsheetML/Formula/Lang/Lex/Formula.Lexer.Generated.cs</OutputFile>
</LexFile>
```

**Generated Components:**

- **Scanner class**: Implements finite automaton for tokenization
- **State machine**: DFA for pattern matching
- **Token methods**: Return appropriate token types
- **Buffer management**: Efficient input handling

## Preprocessor Integration

### Conditional Compilation

Grammar files can use C preprocessor directives:

```lex
#ifdef INCLUDE_EXPERIMENTAL_FUNCTIONS
"LAMBDA"    { return (int)Tokens.T_FUNC_LAMBDA; }
"LET"       { return (int)Tokens.T_FUNC_LET; }
#endif

#ifndef MINIMAL_BUILD
#include "function/future.lex"
#endif
```

### Include Files

Modularize grammar definitions:

```lex
/* Main formula.lex file */
%{
    // Common definitions
%}

%%

<INITIAL>{
    /* Core patterns */

#include "function/standard.lex"
#include "function/worksheet.lex"
#include "function/command.lex"
}
```

### Macro Definitions

Define reusable patterns:

```lex
%{
#define DIGIT [0-9]
#define LETTER [A-Za-z]
#define IDENTIFIER {LETTER}({LETTER}|{DIGIT}|_)*
%}

%%

{IDENTIFIER}    { return (int)Tokens.T_IDENTIFIER; }
{DIGIT}+        { return (int)Tokens.T_INTEGER; }
```

## Development Workflow

### Modifying Grammar Files

1. **Edit source grammar files** in their original locations
2. **Run preprocessing**: `cmake --build build --target process`
3. **Rebuild project**: `cmake --build build --target build`
4. **Test changes**: `cmake --build build --target test`

### Adding New Tokens

1. **Add token to lex file**:

   ```lex
   "NEW_KEYWORD"   { return (int)Tokens.T_NEW_KEYWORD; }
   ```

2. **Add token to yacc file**:

   ```yacc
   %token T_NEW_KEYWORD
   ```

3. **Add grammar rules**:
   ```yacc
   new_construct
       : T_NEW_KEYWORD expression { $$ = new NewConstructNode($2); }
       ;
   ```

### Adding New Functions

1. **Choose appropriate function file** (standard.lex, worksheet.lex, etc.)
2. **Add function pattern**:
   ```lex
   "NEWFUNCTION"   { return (int)Tokens.T_FUNC_NEWFUNCTION; }
   ```
3. **Update parser if needed** for special syntax
4. **Add tests** for the new function

### Debugging Grammar Issues

#### Parser Conflicts

GPPG reports shift/reduce and reduce/reduce conflicts:

```
warning: 1 shift/reduce conflict
State 42: shift/reduce conflict on token T_IDENTIFIER
```

**Resolution strategies:**

- **Add precedence declarations** to resolve conflicts
- **Refactor grammar rules** to eliminate ambiguity
- **Use GLR parsing** for inherently ambiguous grammars

#### Lexer Issues

Common lexer problems:

- **Pattern order matters**: More specific patterns should come first
- **Overlapping patterns**: Use start conditions to disambiguate
- **Greedy matching**: lex uses longest match rule

### Testing Grammar Changes

#### Unit Tests

```csharp
[Theory]
[InlineData("NEW_KEYWORD(123)", typeof(NewConstructNode))]
public void TestNewConstruct(string input, Type expectedType)
{
    var formula = FormulaParser.Parse(input);
    Assert.IsType(expectedType, formula);
}
```

#### Integration Tests

```csharp
[Fact]
public void TestComplexFormulaWithNewConstruct()
{
    var input = "SUM(NEW_KEYWORD(A1:A10), B1)";
    var formula = FormulaParser.Parse(input);

    // Verify AST structure
    Assert.IsType<FunctionCallNode>(formula);
    // ... additional assertions
}
```

## Best Practices

### Grammar Design

1. **Keep rules simple**: Avoid overly complex right-hand sides
2. **Use consistent naming**: Follow established token naming conventions
3. **Document complex rules**: Add comments explaining non-obvious grammar constructs
4. **Consider precedence**: Ensure operator precedence matches Excel behavior

### Lexer Design

1. **Order patterns carefully**: More specific patterns first
2. **Use start conditions**: For context-sensitive tokenization
3. **Handle whitespace appropriately**: Preserve or skip as needed
4. **Escape special characters**: In regular expressions

### Code Generation

1. **Meaningful AST nodes**: Create specific node types for different constructs
2. **Preserve source information**: Include location data for error reporting
3. **Handle errors gracefully**: Provide meaningful error messages
4. **Optimize for performance**: Consider parser table size and generation time

### Maintenance

1. **Version control grammar files**: Track changes to language specification
2. **Document grammar changes**: Maintain changelog for grammar modifications
3. **Test thoroughly**: Ensure backward compatibility
4. **Performance testing**: Monitor parser performance with large inputs

## Advanced Features

### Error Recovery

Implement error recovery in yacc rules:

```yacc
statement_list
    : statement
    | statement_list statement
    | statement_list error statement    { yyerrok; }
    ;
```

### Semantic Predicates

Use semantic actions for context-sensitive parsing:

```yacc
identifier_or_function
    : T_IDENTIFIER
    {
        if (IsKnownFunction($1))
            $$ = new FunctionNameNode($1);
        else
            $$ = new IdentifierNode($1);
    }
    ;
```

## Performance Considerations

### Parser Performance

- **LALR(1) parsing**: Efficient for most grammar constructs
- **Table size**: Balance between grammar complexity and table size
- **Action complexity**: Keep semantic actions lightweight

### Lexer Performance

- **DFA optimization**: GPLEX generates efficient state machines
- **Pattern complexity**: Simpler patterns generally perform better
- **Buffer management**: Efficient for large input files

### Memory Usage

- **AST node design**: Minimize memory footprint of AST nodes
- **String interning**: Consider interning for frequently used strings
- **Garbage collection**: Design for efficient GC behavior

## Troubleshooting

### Common Issues

**Issue**: Parser conflicts  
**Solution**: Add precedence declarations or refactor grammar

**Issue**: Lexer not recognizing tokens  
**Solution**: Check pattern order and regular expression syntax

**Issue**: Build errors after grammar changes  
**Solution**: Clean and rebuild: `cmake --build build --target clean-all && cmake --build build`

**Issue**: Performance degradation  
**Solution**: Profile parser and optimize grammar rules or AST construction

### Debugging Tools

1. **GPPG verbose output**: Use `/verbose` flag for detailed parser information
2. **GPLEX trace output**: Enable tracing for lexer debugging
3. **Visual Studio debugger**: Step through generated parser code
4. **Unit tests**: Isolate and test specific grammar constructs

## Integration with .NET

### Generated Code Structure

```csharp
namespace OpenLanguage.SpreadsheetML.Formula.Generated
{
    public partial class Parser
    {
        public FormulaScanner Scanner { get; set; }

        public ExpressionNode Parse()
        {
            // Generated parsing logic
        }
    }

    internal partial class FormulaScanner
    {
        public int yylex()
        {
            // Generated lexical analysis logic
        }
    }
}
```

### API Integration

The generated parser integrates with the main API:

```csharp
public static class FormulaParser
{
    public static Ast.Node Parse(string? formulaText)
    {
        // ...
        var scanner = new Generated.FormulaScanner();
        scanner.SetSource(formulaText, 0);
        var parser = new Generated.Parser(scanner);
        parser.Parse();
        return parser.root;
    }
}
```

This comprehensive grammar system enables OpenLanguage to provide accurate, high-performance parsing of Open Office XML Domain-specific Languages while maintaining flexibility for future extensions and modifications.

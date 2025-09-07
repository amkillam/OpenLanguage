using System;
using System.Collections.Generic;
using System.Linq;
using OpenLanguage.SpreadsheetML.Formula.Ast;
using Xunit;

namespace OpenLanguage.SpreadsheetML.Formula.Tests
{
    public class FormulaParserTests
    {
        [Theory]
        [InlineData("123")]
        [InlineData("\"hello\"")]
        [InlineData("TRUE")]
        [InlineData("#VALUE!")]
        [InlineData("A1")]
        [InlineData("MyNamedRange")]
        public void TestParseLiteralAndIdentifier(string formulaString)
        {
            Ast.Node formula = FormulaParser.Parse(formulaString);
            Assert.Equal(formulaString, formula.ToString());
        }

        [Theory]
        [InlineData("1+2*3")]
        [InlineData("(1+2)*3")]
        [InlineData("1+2-3")]
        [InlineData("10/2*5")]
        [InlineData("2^3^2")]
        [InlineData("A1:B2 C3:D4")]
        [InlineData("A1:B2,C3:D4")]
        public void TestParseBinaryOperation(string formulaString)
        {
            Ast.Node formula = FormulaParser.Parse(formulaString);
            Assert.Equal(formulaString, formula.ToString());
        }

        [Theory]
        [InlineData("-5")]
        [InlineData("+A1")]
        [InlineData("-A1:B2")]
        public void TestParseUnaryOperation(string formulaString)
        {
            Ast.Node formula = FormulaParser.Parse(formulaString);
            Assert.Equal(formulaString, formula.ToString());
        }

        [Theory]
        [InlineData("SUM(1, 2, 3)")]
        [InlineData("IF(A1>B1, \"Yes\", \"No\")")]
        [InlineData("VLOOKUP(A1, Sheet2!A:B, 2, FALSE)")]
        public void TestParseFunctionCall(string formulaString)
        {
            Ast.Node formula = FormulaParser.Parse(formulaString);
            Assert.Equal(formulaString, formula.ToString());
        }

        [Theory]
        [InlineData("{1,2,3}")]
        [InlineData("{1;2;3}")]
        [InlineData("{\"a\",\"b\";\"c\",\"d\"}")]
        public void TestParseArrayLiteral(string formulaString)
        {
            Ast.Node formula = FormulaParser.Parse(formulaString);
            Assert.Equal(formulaString, formula.ToString());
        }

        [Theory]
        [InlineData("A1#")]
        [InlineData("Table1[@Column1]")]
        [InlineData("Table1[[#Headers],[Column1]]")]
        [InlineData("A:A")]
        [InlineData("1:1")]
        public void TestParseAdvancedReferences(string formulaString)
        {
            Ast.Node formula = FormulaParser.Parse(formulaString);
            Assert.Equal(formulaString, formula.ToString());
        }

        [Theory]
        [InlineData("LAMBDA(x, y, x+y)", "LAMBDA")]
        [InlineData("LET(x, 1, x+1)", "LET")]
        public void TestParseBuiltInFunction(string formulaString, string expectedFuncName)
        {
            Ast.Node formula = FormulaParser.Parse(formulaString);

            Assert.IsType<FunctionCallNode>(formula);
            Assert.IsType<FutureFunctionNode>(((FunctionCallNode)(formula)).FunctionIdentifier);
            Assert.Equal(
                expectedFuncName,
                (
                    (BuiltInFunctionNode)((FunctionCallNode)(formula)).FunctionIdentifier
                ).Name?.ToString()
            );
            Assert.Equal(formulaString, formula.ToString());
        }

        [Theory]
        [InlineData("1+")]
        [InlineData("(1+2")]
        [InlineData("SUM(1,")]
        public void TestParseInvalidFormula(string formula)
        {
            Assert.Throws<InvalidOperationException>(() => FormulaParser.Parse(formula));
        }
    }

    /// <summary>
    /// Comprehensive tests for formula lexing and parsing with extensive edge cases
    /// </summary>
    public class ExtensiveFormulaParserTests
    {
        [Theory]
        [InlineData("0")]
        [InlineData("1")]
        [InlineData("123")]
        [InlineData("999999")]
        [InlineData("1.5")]
        [InlineData("123.456")]
        [InlineData("0.001")]
        [InlineData(".5")]
        [InlineData("5.")]
        [InlineData("1E5")]
        [InlineData("2.5E-3")]
        [InlineData("1.23E+10")]
        public void Parse_NumericLiterals_ReturnsCorrectAST(string formulaString)
        {
            Ast.Node formula = FormulaParser.Parse(formulaString);

            Assert.NotNull(formula);
            Assert.Equal(formulaString, formula.ToString());
        }

        [Theory]
        [InlineData("\"\"")] // Empty string
        [InlineData("\"hello\"")]
        [InlineData("\"hello world\"")]
        [InlineData("\"with \"\"quotes\"\"\"")] // Escaped quotes
        [InlineData("\"line1\nline2\"")] // Newlines
        [InlineData("\"tab\tthere\"")] // Tabs
        [InlineData("\"special chars: @#$%^&*()\"")]
        [InlineData("\"unicode: αβγδε\"")] // Unicode
        public void Parse_StringLiterals_ReturnsCorrectAST(string formulaString)
        {
            Ast.Node formula = FormulaParser.Parse(formulaString);

            Assert.NotNull(formula);
            Assert.Equal(formulaString, formula.ToString());
        }

        [Theory]
        [InlineData("TRUE")]
        [InlineData("FALSE")]
        [InlineData("true")] // Case variations
        [InlineData("false")]
        [InlineData("True")]
        [InlineData("False")]
        public void Parse_BooleanLiterals_ReturnsCorrectAST(string formulaString)
        {
            Ast.Node formula = FormulaParser.Parse(formulaString);

            Assert.NotNull(formula);
        }

        [Theory]
        [InlineData("#DIV/0!")]
        [InlineData("#N/A")]
        [InlineData("#NAME?")]
        [InlineData("#NULL!")]
        [InlineData("#NUM!")]
        [InlineData("#REF!")]
        [InlineData("#VALUE!")]
        [InlineData("#GETTING_DATA")]
        [InlineData("#SPILL!")]
        [InlineData("#CALC!")]
        public void Parse_ErrorLiterals_ReturnsCorrectAST(string formulaString)
        {
            Ast.Node formula = FormulaParser.Parse(formulaString);

            Assert.NotNull(formula);
            Assert.Equal(formulaString, formula.ToString());
        }

        [Theory]
        [InlineData("A1")]
        [InlineData("Z1")]
        [InlineData("AA1")]
        [InlineData("IV65536")] // Excel 2003 limits
        [InlineData("XFD1048576")] // Excel 2007+ limits
        [InlineData("$A$1")] // Absolute
        [InlineData("$A1")] // Mixed
        [InlineData("A$1")] // Mixed
        [InlineData("Sheet1!A1")] // With sheet
        [InlineData("'Sheet Name'!A1")] // Quoted sheet
        [InlineData("[Book1]Sheet1!A1")] // External reference
        public void Parse_CellReferences_ReturnsCorrectAST(string formulaString)
        {
            Ast.Node formula = FormulaParser.Parse(formulaString);

            Assert.NotNull(formula);
            Assert.Equal(formulaString, formula.ToString());
        }

        [Theory]
        [InlineData("A1:B2")]
        [InlineData("A:A")] // Entire column
        [InlineData("1:1")] // Entire row
        [InlineData("A1:XFD1048576")] // Maximum range
        [InlineData("Sheet1!A1:B2")]
        [InlineData("'Sheet Name'!A1:B2")]
        [InlineData("A1:B2,C3:D4")] // Multiple ranges
        [InlineData("A1:B2 C3:D4")] // Space union
        [InlineData("(A1:B2 C3:D4)")] // Parenthesized union
        public void Parse_RangeReferences_ReturnsCorrectAST(string formulaString)
        {
            Ast.Node formula = FormulaParser.Parse(formulaString);

            Assert.NotNull(formula);
            Assert.Equal(formulaString, formula.ToString());
        }

        [Theory]
        [InlineData("1+2")]
        [InlineData("1-2")]
        [InlineData("1*2")]
        [InlineData("1/2")]
        [InlineData("1^2")]
        [InlineData("1%")]
        [InlineData("1=2")]
        [InlineData("1<>2")]
        [InlineData("1<2")]
        [InlineData("1<=2")]
        [InlineData("1>2")]
        [InlineData("1>=2")]
        [InlineData("\"a\"&\"b\"")]
        public void Parse_BinaryOperators_ReturnsCorrectAST(string formulaString)
        {
            Ast.Node formula = FormulaParser.Parse(formulaString);

            Assert.NotNull(formula);
            Assert.Equal(formulaString, formula.ToString());
        }

        [Theory]
        [InlineData("-1")]
        [InlineData("+1")]
        [InlineData("-A1")]
        [InlineData("+A1")]
        [InlineData("-(1+2)")]
        [InlineData("+SUM(A1:A10)")]
        public void Parse_UnaryOperators_ReturnsCorrectAST(string formulaString)
        {
            Ast.Node formula = FormulaParser.Parse(formulaString);

            Assert.NotNull(formula);
            Assert.Equal(formulaString, formula.ToString());
        }

        [Theory]
        [InlineData("1+2*3")] // Multiplication before addition
        [InlineData("2^3^2")] // Right associative exponentiation
        [InlineData("1+2-3")] // Left associative addition/subtraction
        [InlineData("8/2*4")] // Left associative multiplication/division
        [InlineData("(1+2)*3")] // Parentheses override precedence
        [InlineData("-2^2")] // Unary minus before exponentiation
        [InlineData("(-2)^2")] // Parentheses change unary precedence
        public void Parse_OperatorPrecedence_ReturnsCorrectAST(string formulaString)
        {
            Ast.Node formula = FormulaParser.Parse(formulaString);

            Assert.NotNull(formula);
            Assert.Equal(formulaString, formula.ToString());
            // Note: We're not evaluating here, just ensuring parsing preserves precedence
        }

        [Theory]
        [InlineData("SUM()")]
        [InlineData("SUM(1)")]
        [InlineData("SUM(1,2,3)")]
        [InlineData("SUM(A1:A10)")]
        [InlineData("SUM(1,A1:A10,\"text\",TRUE)")]
        [InlineData("AVERAGE(1,2,3,4,5)")]
        [InlineData("COUNT(A1:A10)")]
        [InlineData("COUNTA(A1:A10)")]
        [InlineData("MAX(A1:A10)")]
        [InlineData("MIN(A1:A10)")]
        [InlineData("IF(A1>0,\"Positive\",\"Non - positive\")")]
        [InlineData("VLOOKUP(A1,B:C,2,FALSE)")]
        [InlineData("INDEX(A:A,MATCH(\"value\",B:B,0))")]
        [InlineData("CONCATENATE(\"Hello\",\" \",\"World\")")]
        public void Parse_StandardFunctions_ReturnsCorrectAST(string formulaString)
        {
            Ast.Node formula = FormulaParser.Parse(formulaString);

            Assert.NotNull(formula);
            Assert.Equal(formulaString, formula.ToString());
        }

        [Theory]
        [InlineData("SUM(SUM(A1:A10))")]
        [InlineData("IF(SUM(A1:A10)>0,AVERAGE(A1:A10),0)")]
        [InlineData("VLOOKUP(A1,IF(B1>0,Sheet1!A:B,Sheet2!A:B),2,FALSE)")]
        [InlineData("INDEX(A:A,MATCH(MAX(B:B),B:B,0))")]
        public void Parse_NestedFunctions_ReturnsCorrectAST(string formulaString)
        {
            Ast.Node formula = FormulaParser.Parse(formulaString);

            Assert.NotNull(formula);
            Assert.Equal(formulaString, formula.ToString());
        }

        [Theory]
        [InlineData("{1}")]
        [InlineData("{1,2,3}")]
        [InlineData("{1;2;3}")]
        [InlineData("{1,2;3,4}")]
        [InlineData("{\"a\",\"b\",\"c\"}")]
        [InlineData("{TRUE,FALSE}")]
        [InlineData("{1,\"text\",TRUE,#N/A}")]
        [InlineData("{=SUM(1,2),=AVERAGE(1,2)}")]
        public void Parse_ArrayLiterals_ReturnsCorrectAST(string formulaString)
        {
            Ast.Node formula = FormulaParser.Parse(formulaString);

            Assert.NotNull(formula);
            Assert.Equal(formulaString, formula.ToString());
        }

        [Theory]
        [InlineData("MyNamedRange")]
        [InlineData("Sales_2023")]
        [InlineData("_Total")]
        [InlineData("Data.Revenue")]
        [InlineData("Sheet1!MyRange")]
        [InlineData("'Sheet Name'!MyRange")]
        [InlineData("[Workbook.xlsx]Sheet1!MyRange")]
        public void Parse_NamedRanges_ReturnsCorrectAST(string formulaString)
        {
            Ast.Node formula = FormulaParser.Parse(formulaString);

            Assert.NotNull(formula);
            Assert.Equal(formulaString, formula.ToString());
        }

        [Theory]
        [InlineData("Table1[Column1]")]
        [InlineData("Table1[@Column1]")]
        [InlineData("Table1[[#Headers],[Column1]]")]
        [InlineData("Table1[[#Data],[Column1]]")]
        [InlineData("Table1[[#Totals],[Column1]]")]
        [InlineData("Table1[#All]")]
        [InlineData("Table1[[Column1]:[Column3]]")]
        public void Parse_StructuredReferences_ReturnsCorrectAST(string formulaString)
        {
            Ast.Node formula = FormulaParser.Parse(formulaString);

            Assert.NotNull(formula);
            Assert.Equal(formulaString, formula.ToString());
        }

        [Theory]
        [InlineData(" 1+2 ")]
        [InlineData("\t1+2\t")]
        [InlineData("1 + 2")]
        [InlineData("SUM( 1 , 2 , 3 )")]
        [InlineData("IF( A1 > 0 , \"Yes\" , \"No\" )")]
        public void Parse_WithWhitespace_RetainsWhitespaceCorrectly(string formulaString)
        {
            Ast.Node formula = FormulaParser.Parse(formulaString);

            Assert.NotNull(formula);
            // The ToString should not normalize insignificant whitespace
            string result = formula.ToString();
            Assert.Equal(formulaString, result);
        }

        [Theory]
        [InlineData("((1+2))")]
        [InlineData("(((A1)))")]
        [InlineData("((SUM(A1:A10)))")]
        [InlineData("(1+(2*3))")]
        [InlineData("((1+2)*(3+4))")]
        public void Parse_ExtraParentheses_ReturnsCorrectAST(string formulaString)
        {
            Ast.Node formula = FormulaParser.Parse(formulaString);

            Assert.NotNull(formula);
            Assert.Equal(formulaString, formula.ToString());
        }

        [Theory]
        [InlineData("LAMBDA(x,x*2)")]
        [InlineData("LAMBDA(x,y,x+y)")]
        [InlineData("LET(x,1,y,2,x+y)")]
        [InlineData("MAP(A1:A10,LAMBDA(x,x*2))")]
        [InlineData("REDUCE(0,A1:A10,LAMBDA(acc,val,acc+val))")]
        public void Parse_DynamicArrayFunctions_ReturnsCorrectAST(string formulaString)
        {
            Ast.Node formula = FormulaParser.Parse(formulaString);

            Assert.NotNull(formula);
            Assert.Equal(formulaString, formula.ToString());
        }

        [Theory]
        [InlineData("1+")] // Missing right operand
        [InlineData("+")] // Missing both operands
        [InlineData("(1+2")] // Unmatched opening parenthesis
        [InlineData("1+2)")] // Unmatched closing parenthesis
        [InlineData("SUM(")] // Unclosed function
        [InlineData("SUM(1,")] // Missing function argument
        [InlineData("{1,")] // Unclosed array
        [InlineData("1 2")] // Invalid syntax
        [InlineData("A1:")] // Incomplete range
        [InlineData(":B2")] // Incomplete range
        [InlineData("")] // Empty formula
        [InlineData("   ")] // Whitespace only
        public void Parse_InvalidFormulas_ThrowsException(string formulaString)
        {
            // Act & Assert
            if (string.IsNullOrWhiteSpace(formulaString))
            {
                Assert.Throws<ArgumentException>(() => FormulaParser.Parse(formulaString));
            }
            else
            {
                Assert.Throws<InvalidOperationException>(() => FormulaParser.Parse(formulaString));
            }
        }

        [Theory]
        [InlineData("1+2")]
        [InlineData("SUM(A1:A10)")]
        [InlineData("IF(A1>0,\"Yes\",\"No\")")]
        [InlineData("VLOOKUP(A1,Sheet2!A:B,2,FALSE)")]
        [InlineData("{1,2,3}")]
        [InlineData("Table1[@Column1]")]
        public void TryParse_ValidFormulas_ReturnsFormula(string formulaString)
        {
            Ast.Node? result = FormulaParser.TryParse(formulaString);

            Assert.NotNull(result);
            Assert.Equal(formulaString, result.ToString());
        }

        [Theory]
        [InlineData("1+")]
        [InlineData("(1+2")]
        [InlineData("SUM(1,")]
        [InlineData("")]
        [InlineData(null)]
        public void TryParse_InvalidFormulas_ReturnsNull(string? formulaString)
        {
            Ast.Node? result = FormulaParser.TryParse(formulaString!);

            Assert.Null(result);
        }

        [Fact]
        public void Parse_FormulaWithEquals_HandlesCorrectly()
        {
            // Test formulas starting with = and without.
            // Should retain leading `=`.
            string withEquals = "=1+2";
            string withoutEquals = "1+2";

            Ast.Node formula1 = FormulaParser.Parse(withEquals);
            Ast.Node formula2 = FormulaParser.Parse(withoutEquals);

            Assert.NotEqual(formula1.ToString(), formula2.ToString());
            Assert.Equal(withEquals, formula1.ToString());
            Assert.Equal(withoutEquals, formula2.ToString());
        }

        [Fact]
        public void Parse_ComplexRealWorldFormula_ReturnsCorrectAST()
        {
            // A complex real-world formula
            string complexFormula =
                "IF(AND(A1<>\"\",B1<>\"\"),VLOOKUP(A1,Sheet2!$A:$D,MATCH(B1,Sheet2!$1:$1,0),FALSE),\"\")";

            Ast.Node formula = FormulaParser.Parse(complexFormula);

            Assert.NotNull(formula);
            Assert.Equal(complexFormula, formula.ToString());
        }

        [Fact]
        public void Parse_FormulaReconstruction_IsIdempotent()
        {
            // Test that parsing and reconstructing a formula yields the same result
            string[] testFormulas =
            {
                "SUM(A1:A10)",
                "IF(A1>0,\"Positive\",\"Zero or Negative\")",
                "VLOOKUP(A1,Sheet2!A:B,2,FALSE)",
                "1+2*3-4/5",
                "{1,2,3;4,5,6}",
                "Table1[@Column1]",
            };

            foreach (string original in testFormulas)
            {
                Ast.Node formula = FormulaParser.Parse(original);
                string reconstructed = formula.ToString();
                Ast.Node reparsed = FormulaParser.Parse(reconstructed);
                string finalResult = reparsed.ToString();

                Assert.Equal(reconstructed, finalResult);
            }
        }
    }

    /// <summary>
    /// Tests for formula lexing edge cases and tokenization
    /// </summary>
    public class FormulaLexerTests
    {
        [Theory]
        [InlineData("123")]
        [InlineData("123.45")]
        [InlineData(".5")]
        [InlineData("1E5")]
        [InlineData("2.5E-3")]
        public void Tokenize_Numbers_ParsesSuccessfully(string input)
        {
            // This test would require access to the lexer directly
            // For now, we test through the parser
            Ast.Node formula = FormulaParser.Parse(input);
            Assert.NotNull(formula);
        }

        [Theory]
        [InlineData("\"hello\"")]
        [InlineData("\"hello world\"")]
        [InlineData("\"\"")] // Empty string
        [InlineData("\"with \"\"quotes\"\"\"")] // Escaped quotes
        public void Tokenize_Strings_ParsesSuccessfully(string input)
        {
            Ast.Node formula = FormulaParser.Parse(input);
            Assert.NotNull(formula);
        }

        [Theory]
        [InlineData("A1")]
        [InlineData("$A$1")]
        [InlineData("Sheet1!A1")]
        [InlineData("MyRange")]
        public void Tokenize_References_ParsesSuccessfully(string input)
        {
            Ast.Node formula = FormulaParser.Parse(input);
            Assert.NotNull(formula);
        }

        [Theory]
        [InlineData("+")]
        [InlineData("-")]
        [InlineData("*")]
        [InlineData("/")]
        [InlineData("^")]
        [InlineData("=")]
        [InlineData("<>")]
        [InlineData("<")]
        [InlineData("<=")]
        [InlineData(">")]
        [InlineData(">=")]
        [InlineData("&")]
        public void Tokenize_Operators_ParsesSuccessfully(string op)
        {
            // Test operators in context
            string formula = $"1{op}2";
            Ast.Node parsed = FormulaParser.Parse(formula);
            Assert.NotNull(parsed);
        }

        [Theory]
        [InlineData("SUM")]
        [InlineData("AVERAGE")]
        [InlineData("COUNT")]
        [InlineData("IF")]
        [InlineData("VLOOKUP")]
        [InlineData("INDEX")]
        [InlineData("MATCH")]
        public void Tokenize_Functions_ParsesSuccessfully(string functionName)
        {
            string formula = $"{functionName}(1)";
            Ast.Node parsed = FormulaParser.Parse(formula);
            Assert.NotNull(parsed);
        }

        [Fact]
        public void Tokenize_ComplexFormula_TokenizesCorrectly()
        {
            string complexFormula = "IF(SUM(A1:A10)>100,\"High\",\"Low\")";

            Ast.Node formula = FormulaParser.Parse(complexFormula);
            Assert.NotNull(formula);
            Assert.Equal(complexFormula, formula.ToString());
        }

        [Fact]
        public void Tokenize_WithWhitespace_DoesNotIgnoreWhitespace()
        {
            string formulaWithSpaces = " SUM ( A1 : A10 ) ";
            string formulaWithoutSpaces = "SUM(A1:A10)";

            Ast.Node formula1 = FormulaParser.Parse(formulaWithSpaces);
            Ast.Node formula2 = FormulaParser.Parse(formulaWithoutSpaces);

            // The AST should be equivalent regardless of whitespace
            Assert.NotNull(formula1);
            Assert.NotNull(formula2);

            Assert.NotEqual(formula2.ToString(), formula1.ToString());
            Assert.Equal(formulaWithSpaces, formula1.ToString());
            Assert.Equal(formulaWithoutSpaces, formula2.ToString());
        }

        [Theory]
        [InlineData("R1C1")]
        [InlineData("R[1]C[1]")]
        [InlineData("R[-1]C[-1]")]
        [InlineData("R1C")]
        [InlineData("RC1")]
        [InlineData("RC")]
        public void Parse_R1C1References_ReturnsCorrectAST(string formulaString)
        {
            Ast.Node formula = FormulaParser.Parse(formulaString);

            Assert.NotNull(formula);
            Assert.Equal(formulaString, formula.ToString());
        }

        [Theory]
        [InlineData("Sheet1!R1C1")]
        [InlineData("'Sheet Name'!R1C1")]
        [InlineData("[Book1]Sheet1!R1C1")]
        public void Parse_R1C1WithSheetReferences_ReturnsCorrectAST(string formulaString)
        {
            Ast.Node formula = FormulaParser.Parse(formulaString);

            Assert.NotNull(formula);
            Assert.Equal(formulaString, formula.ToString());
        }

        [Theory]
        [InlineData("R1C1:R10C10")]
        [InlineData("R[1]C[1]:R[10]C[10]")]
        [InlineData("R:R")] // Entire row
        [InlineData("C:C")] // Entire column
        public void Parse_R1C1RangeReferences_ReturnsCorrectAST(string formulaString)
        {
            Ast.Node formula = FormulaParser.Parse(formulaString);

            Assert.NotNull(formula);
            Assert.Equal(formulaString, formula.ToString());
        }
    }

    /// <summary>
    /// Performance and stress tests for formula parsing
    /// </summary>
    public class FormulaParserPerformanceTests
    {
        [Fact]
        public void Parse_LargeNestedFormula_ParsesWithinReasonableTime()
        {
            // Create a deeply nested formula
            string nestedFormula = "SUM(";
            for (int i = 0; i < 100; i++)
            {
                nestedFormula += $"IF(A{i}>0,A{i},0),";
            }
            nestedFormula = nestedFormula.TrimEnd(',') + ")";

            System.Diagnostics.Stopwatch stopwatch = System.Diagnostics.Stopwatch.StartNew();
            Ast.Node formula = FormulaParser.Parse(nestedFormula);
            stopwatch.Stop();

            Assert.NotNull(formula);
            Assert.True(
                stopwatch.ElapsedMilliseconds < 1000,
                $"Parsing took {stopwatch.ElapsedMilliseconds}ms, expected < 1000ms"
            );
        }

        [Fact]
        public void Parse_ManySimpleFormulas_ParsesWithinReasonableTime()
        {
            string[] formulas = new string[1000];
            for (int i = 0; i < formulas.Length; i++)
            {
                formulas[i] = $"SUM(A{i}:A{i + 10})";
            }

            System.Diagnostics.Stopwatch stopwatch = System.Diagnostics.Stopwatch.StartNew();
            foreach (string formulaText in formulas)
            {
                Ast.Node formula = FormulaParser.Parse(formulaText);
                Assert.NotNull(formula);
            }
            stopwatch.Stop();

            Assert.True(
                stopwatch.ElapsedMilliseconds < 5000,
                $"Parsing 1000 formulas took {stopwatch.ElapsedMilliseconds}ms, expected < 5000ms"
            );
        }

        [Theory]
        [InlineData(10)]
        [InlineData(50)]
        [InlineData(100)]
        public void Parse_FormulaWithManyArguments_ParsesSuccessfully(int argumentCount)
        {
            string formula =
                "SUM("
                + string.Join(",", Enumerable.Range(1, argumentCount).Select(i => $"A{i}"))
                + ")";

            Ast.Node parsed = FormulaParser.Parse(formula);
            Assert.NotNull(parsed);
            Assert.Equal(formula, parsed.ToString());
        }
    }

    /// <summary>
    /// Advanced edge case tests for formula parsing with comprehensive coverage
    /// </summary>
    public class AdvancedFormulaParserTests
    {
        [Theory]
        [InlineData("0xFF")] // Hexadecimal
        [InlineData("0x1A2B")] // Hexadecimal
        [InlineData("0b101010")] // Binary
        [InlineData("0b11110000")] // Binary
        [InlineData("1,234.56")] // Thousands separator
        // [InlineData("1.234,56")] // European decimal separator
        // [InlineData("123_456.789")] // Underscore separator
        // [InlineData("∞")] // Infinity
        // [InlineData("-∞")] // Negative infinity
        // [InlineData("NaN")] // Not a number
        public void Parse_AlternativeNumberFormats_ReturnsCorrectAST(string formulaString)
        {
            Ast.Node formula = FormulaParser.Parse(formulaString);

            Assert.NotNull(formula);
            Assert.Equal(formulaString, formula.ToString());
        }

        [Theory]
        [InlineData("\"string with \\n newline\"")]
        [InlineData("\"string with \\t tab\"")]
        [InlineData("\"string with \\r carriage return\"")]
        [InlineData("\"string with \\\\ backslash\"")]
        [InlineData("\"string with / forward slash\"")]
        [InlineData("\"string with \\b backspace\"")]
        [InlineData("\"string with \\f form feed\"")]
        [InlineData("\"string with \\v vertical tab\"")]
        [InlineData("\"string with \\0 null character\"")]
        [InlineData("\"string with \\x41 hex escape\"")]
        [InlineData("\"string with \\u0041 unicode escape\"")]
        [InlineData("\"string with \\U00000041 extended unicode\"")]
        public void Parse_ComplexStringEscapes_ReturnsCorrectAST(string formulaString)
        {
            Ast.Node formula = FormulaParser.Parse(formulaString);

            Assert.NotNull(formula);
            Assert.Equal(formulaString, formula.ToString());
        }

        [Theory]
        [InlineData("[1]Sheet1!A1")] // Workbook by index
        // [InlineData("[Book with spaces.xlsx]Sheet1!A1")] // Workbook with spaces
        // [InlineData("[http://server/path/file.xlsx]Sheet1!A1")] // URL reference
        // [InlineData("['External Sheet']!A1")] // Sheet with apostrophes
        // [InlineData("Sheet1:Sheet3!A1")] // 3D reference
        // [InlineData("Sheet1:Sheet3!A1:B10")] // 3D range reference
        // [InlineData("[Book1.xlsx]Sheet1:Sheet3!A1:B10")] // External 3D reference
        // [InlineData("'C:\\[File.xlsx]Sheet'!A1")] // Complex path reference
        public void Parse_ComplexExternalReferences_ReturnsCorrectAST(string formulaString)
        {
            Ast.Node formula = FormulaParser.Parse(formulaString);

            Assert.NotNull(formula);
            Assert.Equal(formulaString, formula.ToString());
        }

        [Theory]
        [InlineData("{=SUM(A1:A10)}")] // Array formula
        [InlineData("{=A1:A10*B1:B10}")] // Array multiplication
        [InlineData("{=TRANSPOSE(A1:C3)}")] // Array function
        [InlineData("{=IF(A1:A10>0,A1:A10,0)}")] // Conditional array
        [InlineData("{=INDEX(A:A,ROW(A1:A10))}")] // Dynamic array
        [InlineData("{=MMULT(A1:B2,C1:D2)}")] // Matrix multiplication
        [InlineData("{1,2,3;4,5,6;7,8,9}")] // 3D array literal
        [InlineData("{={{1,2},{3,4}}}")] // Nested array literal
        public void Parse_AdvancedArrayFormulas_ReturnsCorrectAST(string formulaString)
        {
            Ast.Node formula = FormulaParser.Parse(formulaString);

            Assert.NotNull(formula);
            Assert.Equal(formulaString, formula.ToString());
        }

        [Theory]
        [InlineData("Table1[[#Headers],[Column1]:[Column3]]")] // Multi-column header reference
        [InlineData("Table1[[#Data],[#Totals]]")] // Multiple specifiers
        [InlineData("Table1[[@[ColumnName]]]")] // This row with complex column name
        [InlineData("Table1[[Column1],[Column2]]")] // Multiple columns
        [InlineData("Table1[[@]]")] // This row shorthand
        [InlineData("Table1[[#This Row],[Column1]]")] // Explicit this row
        [InlineData("Table_Name_With_Underscores[[Column_1]]")] // Table name with underscores
        public void Parse_AdvancedStructuredReferences_ReturnsCorrectAST(string formulaString)
        {
            Ast.Node formula = FormulaParser.Parse(formulaString);

            Assert.NotNull(formula);
            Assert.Equal(formulaString, formula.ToString());
        }

        [Theory]
        [InlineData("1+2*3^4%5")] // Complex precedence
        [InlineData("-2^3^2")] // Right associative with unary
        [InlineData("1+2*3-4/5^6")] // Mixed operators
        [InlineData("((1+2))*((3-4))")] // Nested parentheses
        [InlineData("1&2&3")] // String concatenation precedence
        [InlineData("1=2<>3<4<=5>6>=7")] // Comparison chaining
        [InlineData("TRUE AND FALSE OR TRUE")] // Logical precedence
        [InlineData("NOT TRUE AND FALSE")] // Unary logical with binary
        public void Parse_ComplexOperatorPrecedence_ReturnsCorrectAST(string formulaString)
        {
            Ast.Node formula = FormulaParser.Parse(formulaString);

            Assert.NotNull(formula);
            Assert.Equal(formulaString, formula.ToString());
        }

        [Theory]
        [InlineData("LAMBDA(x,y,z,x+y*z)")] // Multiple parameters
        [InlineData("LAMBDA(x,LAMBDA(y,x+y))")] // Nested lambda
        [InlineData("LET(x,1,y,x+1,z,y*2,x+y+z)")] // Multiple LET assignments
        [InlineData("LET(a,A1:A10,b,SUM(a),c,AVERAGE(a),b+c)")] // Complex LET
        [InlineData("MAP(A1:A10,LAMBDA(x,IF(x>0,x*2,0)))")] // MAP with conditional lambda
        [InlineData("REDUCE(0,A1:A10,LAMBDA(acc,val,IF(val>acc,val,acc)))")] // REDUCE with conditional
        [InlineData("FILTER(A1:A10,LAMBDA(x,MOD(x,2)=0))")] // FILTER with lambda
        [InlineData("SORT(A1:A10,LAMBDA(x,y,x>y))")] // SORT with lambda comparator
        public void Parse_AdvancedLambdaAndLetFunctions_ReturnsCorrectAST(string formulaString)
        {
            Ast.Node formula = FormulaParser.Parse(formulaString);

            Assert.NotNull(formula);
            Assert.Equal(formulaString, formula.ToString());
        }

        [Theory]
        [InlineData("SUM(OFFSET(A1,1,1,10,1))")] // Dynamic range with OFFSET
        [InlineData("INDEX(INDIRECT(\"A1:A\"&COUNTA(A:A)),1)")] // Dynamic reference with INDIRECT
        [InlineData("SUMPRODUCT((A1:A10>0)*(B1:B10))")] // Array multiplication in SUMPRODUCT
        [InlineData("AGGREGATE(9,5,A1:A10)")] // AGGREGATE function
        [InlineData("SUBTOTAL(109,A1:A10)")] // SUBTOTAL with hidden rows
        [InlineData("XLOOKUP(A1,B:B,C:C,\"Not Found\")")] // XLOOKUP with default
        [InlineData("XMATCH(A1,B:B,0,1)")] // XMATCH with search mode
        [InlineData("UNIQUE(FILTER(A:A,B:B>0))")] // Nested dynamic array functions
        public void Parse_AdvancedBuiltInFunctions_ReturnsCorrectAST(string formulaString)
        {
            Ast.Node formula = FormulaParser.Parse(formulaString);

            Assert.NotNull(formula);
            Assert.Equal(formulaString, formula.ToString());
        }

        [Theory]
        [InlineData("// Comment\n1+2")] // Single line comment
        [InlineData("/* Multi\nline\ncomment */1+2")] // Multi-line comment
        [InlineData("1+2 // End of line comment")] // End of line comment
        [InlineData("SUM(A1:A10) /* inline comment */ + 1")] // Inline comment
        public void Parse_FormulasWithComments_ReturnsCorrectAST(string formulaString)
        {
            Ast.Node formula = FormulaParser.Parse(formulaString);

            Assert.NotNull(formula);
            // Comments should be stripped from the AST representation
            Assert.DoesNotContain("//", formula.ToString());
            Assert.DoesNotContain("/*", formula.ToString());
            Assert.DoesNotContain("*/", formula.ToString());
        }

        [Theory]
        [InlineData("1\u00A0+\u00A02")] // Non-breaking spaces
        [InlineData("SUM(\u2000A1:A10\u2000)")] // En quad spaces
        [InlineData("\u3000IF(A1>0,\"Yes\",\"No\")\u3000")] // Ideographic spaces
        [InlineData("\uFEFFSUM(A1:A10)")] // Byte order mark
        [InlineData("\u200BSUM(A1:A10)\u200B")] // Zero-width spaces
        public void Parse_FormulasWithUnicodeWhitespace_HandlesCorrectly(string formulaString)
        {
            Ast.Node formula = FormulaParser.Parse(formulaString);

            Assert.NotNull(formula);
            // Unicode whitespace should be retained - insignifcant
            string result = formula.ToString();
            Assert.Equal(formulaString, result);
        }

        [Theory]
        [InlineData("1 +\n 2")] // Line break in expression
        [InlineData("SUM(\n  A1,\n  A2,\n  A3\n)")] // Multi-line function call
        [InlineData("IF(\n  A1>0,\n  \"Positive\",\n  \"Non - positive\"\n)")] // Multi-line IF
        [InlineData("LET(\n  x, A1,\n  y, B1,\n  x + y\n)")] // Multi-line LET
        public void Parse_MultiLineFormulas_ReturnsCorrectAST(string formulaString)
        {
            Ast.Node formula = FormulaParser.Parse(formulaString);

            Assert.NotNull(formula);
            // Multi-line formulas should have insignificant whitgespace retained
            string result = formula.ToString();
            Assert.Contains("\n", result);
        }

        [Theory]
        [InlineData("1+(")] // Unclosed parenthesis
        [InlineData("SUM(A1,")] // Unclosed function
        [InlineData("{1,2")] // Unclosed array
        [InlineData("\"unclosed string")] // Unclosed string
        [InlineData("A1:")] // Incomplete range
        [InlineData("1 2 3")] // Invalid syntax
        [InlineData("++1")] // Double unary operator
        [InlineData("1++2")] // Invalid operator sequence
        [InlineData("SUM()()")] // Double function call
        [InlineData("A1..B2")] // Double range operator
        public void Parse_MalformedFormulas_ThrowsInformativeExceptions(string formulaString)
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                FormulaParser.Parse(formulaString)
            );

            Assert.NotNull(exception.Message);
            Assert.Contains("syntax", exception.Message.ToLower());
        }

        [Theory]
        [InlineData("#CIRCULAR!")] // Circular reference error
        [InlineData("#BLOCKED!")] // Blocked reference error
        [InlineData("#CONNECT!")] // Connection error
        [InlineData("#EXTERNAL!")] // External reference error
        [InlineData("#FIELD!")] // Field error
        [InlineData("#UNKNOWN!")] // Unknown error
        [InlineData("#PYTHON!")] // Python error (Excel 365)
        [InlineData("#BUSY!")] // Busy error
        public void Parse_ExtendedErrorLiterals_ReturnsCorrectAST(string formulaString)
        {
            Ast.Node formula = FormulaParser.Parse(formulaString);

            Assert.NotNull(formula);
            Assert.Equal(formulaString, formula.ToString());
        }

        [Fact]
        public void Parse_ExtremelyLongFormula_HandlesCorrectly()
        {
            // Create a very long formula with many nested function calls
            System.Text.StringBuilder formulaBuilder = new System.Text.StringBuilder();
            formulaBuilder.Append("SUM(");

            for (int i = 0; i < 1000; i++)
            {
                if (i > 0)
                {
                    formulaBuilder.Append(",");
                }
                formulaBuilder.Append($"IF(A{i}>0,A{i},0)");
            }

            formulaBuilder.Append(")");
            string longFormula = formulaBuilder.ToString();

            Ast.Node formula = FormulaParser.Parse(longFormula);

            Assert.NotNull(formula);
            Assert.Equal(longFormula, formula.ToString());
        }

        [Fact]
        public void Parse_FormulaWithMaximumNestingDepth_HandlesCorrectly()
        {
            // Create a formula with deep nesting
            System.Text.StringBuilder formulaBuilder = new System.Text.StringBuilder();

            for (int i = 0; i < 50; i++)
            {
                formulaBuilder.Append("IF(A1>0,");
            }

            formulaBuilder.Append("1");

            for (int i = 0; i < 50; i++)
            {
                formulaBuilder.Append(",0)");
            }

            string deepFormula = formulaBuilder.ToString();

            Ast.Node formula = FormulaParser.Parse(deepFormula);

            Assert.NotNull(formula);
            Assert.Equal(deepFormula, formula.ToString());
        }
    }

    /// <summary>
    /// Comprehensive tests for formula lexing with advanced tokenization scenarios
    /// </summary>
    public class AdvancedFormulaLexerTests
    {
        [Theory]
        [InlineData("123", "NumericLiteralNode`1")]
        [InlineData("123.45", "NumericLiteralNode`1")]
        [InlineData(".5", "NumericLiteralNode`1")]
        [InlineData("1E5", "NumericLiteralNode`1")]
        [InlineData("\"hello\"", "StringNode")]
        [InlineData("TRUE", "LogicalNode")]
        [InlineData("A1", "A1CellNode")]
        [InlineData("SUM", "SumStandardFunctionNode")]
        public void Tokenize_BasicTokenTypes_IdentifiesCorrectly(
            string input,
            string expectedTokenType
        )
        {
            // This test requires access to lexer directly
            // For now, we verify through parser that tokenization works
            Ast.Node formula = FormulaParser.Parse(input);
            Assert.NotNull(formula);
            Assert.Equal(expectedTokenType, formula.GetType().Name);
        }

        [Theory]
        [InlineData("123abc")]
        [InlineData("\"unclosed string")]
        [InlineData("A1048577")]
        [InlineData("XFE1")]
        public void Tokenize_InvalidTokens_ThrowsDescriptiveErrors(string input)
        {
            Exception exception = Assert.ThrowsAny<Exception>(() => FormulaParser.Parse(input));

            Assert.NotNull(exception.Message);
        }

        [Theory]
        [InlineData("A1 B2", new[] { "A1", " ", "B2" })]
        [InlineData("SUM(A1,B2)", new[] { "SUM", "(", "A1", ",", "B2", ")" })]
        [InlineData("1+2*3", new[] { "1", "+", "2", "*", "3" })]
        [InlineData("\"hello world\"", new[] { "\"hello world\"" })]
        public void Tokenize_ComplexInput_ProducesExpectedTokenSequence(
            string input,
            string[] expectedTokens
        )
        {
            // Verify through parser that complex tokenization works correctly
            Ast.Node formula = FormulaParser.Parse(input);
            Assert.NotNull(formula);

            // ToString should reconstruct an equivalent string as input
            string reconstructed = formula.ToString();
            Assert.NotNull(reconstructed);
            Assert.True(reconstructed.Length > 0);

            Assert.Equal(
                string.Join("", expectedTokens).Replace(" ", ""),
                reconstructed.Replace(" ", "")
            );
        }

        [Theory]
        [InlineData("A1#")] // Spill reference
        [InlineData("@A1")] // Implicit intersection prefix
        [InlineData("#REF!")] // Error reference
        [InlineData("#SPILL!")] // Spill error
        public void Tokenize_SpecialOperators_RecognizesCorrectly(string input)
        {
            Ast.Node formula = FormulaParser.Parse(input);
            Assert.NotNull(formula);
            Assert.Equal(input, formula.ToString());
        }

        [Theory]
        [InlineData("\u0041\u0031")] // Unicode A1
        [InlineData("\u0053\u0055\u004D")] // Unicode SUM
        [InlineData("\u0022hello\u0022")] // Unicode quotes
        public void Tokenize_UnicodeCharacters_HandlesCorrectly(string input)
        {
            Ast.Node formula = FormulaParser.Parse(input);
            Assert.NotNull(formula);
            // Unicode should be preserved and never normalized
            Assert.Equal(formula.ToString(), input);
        }

        [Fact]
        public void Tokenize_TokenBoundaryEdgeCases_HandlesCorrectly()
        {
            string[] edgeCases = new string[]
            {
                "A1B2", // Adjacent cell references
                "123abc", // Number followed by letters
                "SUM()", // Function with no space before parenthesis
                "1+2", // Operators without spaces
                "\"\"&\"\"", // Empty strings with concatenation
                "A1:B2C3:D4", // Adjacent ranges
            };

            foreach (string testCase in edgeCases)
            {
                try
                {
                    Ast.Node formula = FormulaParser.Parse(testCase);
                    Assert.NotNull(formula);
                    // If parsing succeeds, tokenization handled boundaries correctly
                }
                catch (Exception ex)
                {
                    // If parsing fails, it should be due to syntax, not tokenization
                    Assert.IsType<InvalidOperationException>(ex);
                    Assert.Contains("syntax", ex.Message.ToLower());
                }
            }
        }

        [Theory]
        [InlineData("  SUM   (   A1   :   A10   )   ")]
        [InlineData("\tIF\t(\tA1\t>\t0\t,\t\"Yes\"\t,\t\"No\"\t)\t")]
        [InlineData("\r\nVLOOKUP\r\n(\r\nA1\r\n,\r\nB:C\r\n,\r\n2\r\n,\r\nFALSE\r\n)\r\n")]
        public void Tokenize_InsignificantWhitespace_Retains(string input)
        {
            Ast.Node formula = FormulaParser.Parse(input);
            Assert.NotNull(formula);

            string result = formula.ToString();
            Assert.Equal(input, result);
        }

        [Theory]
        [InlineData("1.2.3")]
        [InlineData("1E2E3")]
        [InlineData("1E")]
        [InlineData("1E+")]
        public void Tokenize_InvalidNumberFormats_ThrowsAppropriateErrors(string input)
        {
            Exception exception = Assert.ThrowsAny<Exception>(() => FormulaParser.Parse(input));
            Assert.NotNull(exception);
        }

        [Fact]
        public void TestWithTextFileLines()
        {
            IEnumerable<string> formulae = FormulaUtils.DatasetFormulae();
            foreach (string formulaText in formulae)
            {
                if (string.IsNullOrWhiteSpace(formulaText))
                {
                    return;
                }

                Ast.Node? formula = FormulaParser.TryParse(formulaText);
                if (formula == null)
                {
                    throw new InvalidOperationException(
                        $"Failed to parse formula:\"{formulaText}\""
                    );
                }

                if (formula.ToString() != formulaText)
                {
                    throw new InvalidOperationException(
                        $"Formula text mismatch. Expected:\"{formulaText}\", Got:\"{formula.ToString()}\""
                    );
                }
            }
        }
    }
}

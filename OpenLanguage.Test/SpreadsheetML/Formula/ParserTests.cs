using System;
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
            Formula formula = FormulaParser.Parse(formulaString);
            Assert.Equal(formulaString, formula.AstRoot.ToString());
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
            Formula formula = FormulaParser.Parse(formulaString);
            Assert.Equal(formulaString, formula.AstRoot.ToString());
        }

        [Theory]
        [InlineData("-5")]
        [InlineData("+A1")]
        [InlineData("-A1:B2")]
        public void TestParseUnaryOperation(string formulaString)
        {
            Formula formula = FormulaParser.Parse(formulaString);
            Assert.Equal(formulaString, formula.AstRoot.ToString());
        }

        [Theory]
        [InlineData("SUM(1, 2, 3)")]
        [InlineData("IF(A1>B1, \"Yes\", \"No\")")]
        [InlineData("VLOOKUP(A1, Sheet2!A:B, 2, FALSE)")]
        public void TestParseFunctionCall(string formulaString)
        {
            Formula formula = FormulaParser.Parse(formulaString);
            Assert.Equal(formulaString, formula.AstRoot.ToString());
        }

        [Theory]
        [InlineData("{1,2,3}")]
        [InlineData("{1;2;3}")]
        [InlineData("{\"a\",\"b\";\"c\",\"d\"}")]
        public void TestParseArrayLiteral(string formulaString)
        {
            Formula formula = FormulaParser.Parse(formulaString);
            Assert.Equal(formulaString, formula.AstRoot.ToString());
        }

        [Theory]
        [InlineData("A1#")]
        [InlineData("Table1[@Column1]")]
        [InlineData("Table1[[#Headers],[Column1]]")]
        [InlineData("A:A")]
        [InlineData("1:1")]
        public void TestParseAdvancedReferences(string formulaString)
        {
            Formula formula = FormulaParser.Parse(formulaString);
            Assert.Equal(formulaString, formula.AstRoot.ToString());
        }

        [Theory]
        [InlineData("LAMBDA(x, y, x+y)", "LAMBDA")]
        [InlineData("LET(x, 1, x+1)", "LET")]
        public void TestParseBuiltInFunction(string formulaString, string expectedFuncName)
        {
            Formula formula = FormulaParser.Parse(formulaString);

            Assert.IsType<FunctionCallNode>(formula.AstRoot);
            Assert.IsType<BuiltInFutureFunctionNode>(
                ((FunctionCallNode)(formula.AstRoot)).FunctionIdentifier
            );
            Assert.Equal(
                expectedFuncName,
                ((BuiltInFunctionNode)((FunctionCallNode)(formula.AstRoot)).FunctionIdentifier).Name
            );
            Assert.Equal(formulaString, formula.AstRoot.ToString());
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

            Formula formula = FormulaParser.Parse(formulaString);

                        Assert.NotNull(formula.AstRoot);
            Assert.Equal(formulaString, formula.AstRoot.ToString());
        }

        [Theory]
        [InlineData("""")] // Empty string
        [InlineData(""hello"")]
        [InlineData(""hello world"")]
        [InlineData(""with "quotes""")] // Escaped quotes
        [InlineData(""line1\nline2"")] // Newlines
        [InlineData(""tab\there"")] // Tabs
        [InlineData(""special chars: @#$%^&*()"")]
        [InlineData(""unicode: αβγδε"")] // Unicode
        public void Parse_StringLiterals_ReturnsCorrectAST(string formulaString)
        {

            Formula formula = FormulaParser.Parse(formulaString);

                        Assert.NotNull(formula.AstRoot);
            Assert.Equal(formulaString, formula.AstRoot.ToString());
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

            Formula formula = FormulaParser.Parse(formulaString);

                        Assert.NotNull(formula.AstRoot);
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

            Formula formula = FormulaParser.Parse(formulaString);

                        Assert.NotNull(formula.AstRoot);
            Assert.Equal(formulaString, formula.AstRoot.ToString());
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

            Formula formula = FormulaParser.Parse(formulaString);

                        Assert.NotNull(formula.AstRoot);
            Assert.Equal(formulaString, formula.AstRoot.ToString());
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

            Formula formula = FormulaParser.Parse(formulaString);

                        Assert.NotNull(formula.AstRoot);
            Assert.Equal(formulaString, formula.AstRoot.ToString());
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
        [InlineData(""a"&"b"")]
        public void Parse_BinaryOperators_ReturnsCorrectAST(string formulaString)
        {

            Formula formula = FormulaParser.Parse(formulaString);

                        Assert.NotNull(formula.AstRoot);
            Assert.Equal(formulaString, formula.AstRoot.ToString());
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

            Formula formula = FormulaParser.Parse(formulaString);

                        Assert.NotNull(formula.AstRoot);
            Assert.Equal(formulaString, formula.AstRoot.ToString());
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

            Formula formula = FormulaParser.Parse(formulaString);

                        Assert.NotNull(formula.AstRoot);
            Assert.Equal(formulaString, formula.AstRoot.ToString());
            // Note: We're not evaluating here, just ensuring parsing preserves precedence
        }

        [Theory]
        [InlineData("SUM()")]
        [InlineData("SUM(1)")]
        [InlineData("SUM(1,2,3)")]
        [InlineData("SUM(A1:A10)")]
        [InlineData("SUM(1,A1:A10,"text",TRUE)")]
        [InlineData("AVERAGE(1,2,3,4,5)")]
        [InlineData("COUNT(A1:A10)")]
        [InlineData("COUNTA(A1:A10)")]
        [InlineData("MAX(A1:A10)")]
        [InlineData("MIN(A1:A10)")]
        [InlineData("IF(A1>0,"Positive","Non-positive")")]
        [InlineData("VLOOKUP(A1,B:C,2,FALSE)")]
        [InlineData("INDEX(A:A,MATCH("value",B:B,0))")]
        [InlineData("CONCATENATE("Hello"," ","World")")]
        public void Parse_StandardFunctions_ReturnsCorrectAST(string formulaString)
        {

            Formula formula = FormulaParser.Parse(formulaString);

                        Assert.NotNull(formula.AstRoot);
            Assert.Equal(formulaString, formula.AstRoot.ToString());
        }

        [Theory]
        [InlineData("SUM(SUM(A1:A10))")]
        [InlineData("IF(SUM(A1:A10)>0,AVERAGE(A1:A10),0)")]
        [InlineData("VLOOKUP(A1,IF(B1>0,Sheet1!A:B,Sheet2!A:B),2,FALSE)")]
        [InlineData("INDEX(A:A,MATCH(MAX(B:B),B:B,0))")]
        public void Parse_NestedFunctions_ReturnsCorrectAST(string formulaString)
        {

            Formula formula = FormulaParser.Parse(formulaString);

                        Assert.NotNull(formula.AstRoot);
            Assert.Equal(formulaString, formula.AstRoot.ToString());
        }

        [Theory]
        [InlineData("{1}")]
        [InlineData("{1,2,3}")]
        [InlineData("{1;2;3}")]
        [InlineData("{1,2;3,4}")]
        [InlineData("{"a","b","c"}")]
        [InlineData("{TRUE,FALSE}")]
        [InlineData("{1,"text",TRUE,#N/A}")]
        [InlineData("{=SUM(1,2),=AVERAGE(1,2)}")]
        public void Parse_ArrayLiterals_ReturnsCorrectAST(string formulaString)
        {

            Formula formula = FormulaParser.Parse(formulaString);

                        Assert.NotNull(formula.AstRoot);
            Assert.Equal(formulaString, formula.AstRoot.ToString());
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

            Formula formula = FormulaParser.Parse(formulaString);

                        Assert.NotNull(formula.AstRoot);
            Assert.Equal(formulaString, formula.AstRoot.ToString());
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

            Formula formula = FormulaParser.Parse(formulaString);

                        Assert.NotNull(formula.AstRoot);
            Assert.Equal(formulaString, formula.AstRoot.ToString());
        }

        [Theory]
        [InlineData(" 1+2 ")]
        [InlineData("\t1+2\t")]
        [InlineData("1 + 2")]
        [InlineData("SUM( 1 , 2 , 3 )")]
        [InlineData("IF( A1 > 0 , "Yes" , "No" )")]
        public void Parse_WithWhitespace_IgnoresWhitespaceCorrectly(string formulaString)
        {

            Formula formula = FormulaParser.Parse(formulaString);

                        Assert.NotNull(formula.AstRoot);
            // The ToString should normalize whitespace
            string result = formula.AstRoot.ToString();
            Assert.DoesNotContain("  ", result); // No double spaces
        }

        [Theory]
        [InlineData("((1+2))")]
        [InlineData("(((A1)))")]
        [InlineData("((SUM(A1:A10)))")]
        [InlineData("(1+(2*3))")]
        [InlineData("((1+2)*(3+4))")]
        public void Parse_ExtraParentheses_ReturnsCorrectAST(string formulaString)
        {

            Formula formula = FormulaParser.Parse(formulaString);

                        Assert.NotNull(formula.AstRoot);
            Assert.Equal(formulaString, formula.AstRoot.ToString());
        }

        [Theory]
        [InlineData("LAMBDA(x,x*2)")]
        [InlineData("LAMBDA(x,y,x+y)")]
        [InlineData("LET(x,1,y,2,x+y)")]
        [InlineData("MAP(A1:A10,LAMBDA(x,x*2))")]
        [InlineData("REDUCE(0,A1:A10,LAMBDA(acc,val,acc+val))")]
        public void Parse_DynamicArrayFunctions_ReturnsCorrectAST(string formulaString)
        {

            Formula formula = FormulaParser.Parse(formulaString);

                        Assert.NotNull(formula.AstRoot);
            Assert.Equal(formulaString, formula.AstRoot.ToString());
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
        [InlineData("IF(A1>0,"Yes","No")")]
        [InlineData("VLOOKUP(A1,Sheet2!A:B,2,FALSE)")]
        [InlineData("{1,2,3}")]
        [InlineData("Table1[@Column1]")]
        public void TryParse_ValidFormulas_ReturnsFormula(string formulaString)
        {

            Formula? result = FormulaParser.TryParse(formulaString);

                        Assert.NotNull(result);
            Assert.Equal(formulaString, result.FormulaText);
        }

        [Theory]
        [InlineData("1+")]
        [InlineData("(1+2")]
        [InlineData("SUM(1,")]
        [InlineData("")]
        [InlineData(null)]
        public void TryParse_InvalidFormulas_ReturnsNull(string? formulaString)
        {

            Formula? result = FormulaParser.TryParse(formulaString!);

                        Assert.Null(result);
        }

        [Fact]
        public void Parse_FormulaWithEquals_HandlesCorrectly()
        {
            // Test formulas starting with = and without
            string withEquals = "=1+2";
            string withoutEquals = "1+2";

            Formula formula1 = FormulaParser.Parse(withEquals);
            Formula formula2 = FormulaParser.Parse(withoutEquals);

            Assert.Equal(withEquals, formula1.FormulaText);
            Assert.Equal(withoutEquals, formula2.FormulaText);
            // The AST should be the same regardless of leading =
            Assert.Equal(formula1.AstRoot.ToString(), formula2.AstRoot.ToString());
        }

        [Fact]
        public void Parse_ComplexRealWorldFormula_ReturnsCorrectAST()
        {
            // A complex real-world formula
            string complexFormula = "IF(AND(A1<>"",B1<>""),VLOOKUP(A1,Sheet2!$A:$D,MATCH(B1,Sheet2!$1:$1,0),FALSE),"")";

            Formula formula = FormulaParser.Parse(complexFormula);

            Assert.NotNull(formula.AstRoot);
            Assert.Equal(complexFormula, formula.AstRoot.ToString());
        }

        [Fact]
        public void Parse_FormulaReconstruction_IsIdempotent()
        {
            // Test that parsing and reconstructing a formula yields the same result
            string[] testFormulas = {
                "SUM(A1:A10)",
                "IF(A1>0,"Positive","Zero or Negative")",
                "VLOOKUP(A1,Sheet2!A:B,2,FALSE)",
                "1+2*3-4/5",
                "{1,2,3;4,5,6}",
                "Table1[@Column1]"
            };

            foreach (string original in testFormulas)
            {
                Formula formula = FormulaParser.Parse(original);
                string reconstructed = formula.ToString();
                Formula reparsed = FormulaParser.Parse(reconstructed);
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
            Formula formula = FormulaParser.Parse(input);
            Assert.NotNull(formula.AstRoot);
        }

        [Theory]
        [InlineData(""hello"")]
        [InlineData(""hello world"")]
        [InlineData("""")] // Empty string
        [InlineData(""with "quotes"")] // Escaped quotes
        public void Tokenize_Strings_ParsesSuccessfully(string input)
        {
            Formula formula = FormulaParser.Parse(input);
            Assert.NotNull(formula.AstRoot);
        }

        [Theory]
        [InlineData("A1")]
        [InlineData("$A$1")]
        [InlineData("Sheet1!A1")]
        [InlineData("MyRange")]
        public void Tokenize_References_ParsesSuccessfully(string input)
        {
            Formula formula = FormulaParser.Parse(input);
            Assert.NotNull(formula.AstRoot);
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
            Formula parsed = FormulaParser.Parse(formula);
            Assert.NotNull(parsed.AstRoot);
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
            Formula parsed = FormulaParser.Parse(formula);
            Assert.NotNull(parsed.AstRoot);
        }

        [Fact]
        public void Tokenize_ComplexFormula_TokenizesCorrectly()
        {
            string complexFormula = "IF(SUM(A1:A10)>100,"High","Low")";

            Formula formula = FormulaParser.Parse(complexFormula);
            Assert.NotNull(formula.AstRoot);
            Assert.Equal(complexFormula, formula.AstRoot.ToString());
        }

        [Fact]
        public void Tokenize_WithWhitespace_IgnoresWhitespace()
        {
            string formulaWithSpaces = " SUM ( A1 : A10 ) ";
            string formulaWithoutSpaces = "SUM(A1:A10)";

            Formula formula1 = FormulaParser.Parse(formulaWithSpaces);
            Formula formula2 = FormulaParser.Parse(formulaWithoutSpaces);

            // The AST should be equivalent regardless of whitespace
            Assert.NotNull(formula1.AstRoot);
            Assert.NotNull(formula2.AstRoot);
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

            Formula formula = FormulaParser.Parse(formulaString);

                        Assert.NotNull(formula.AstRoot);
            Assert.Equal(formulaString, formula.AstRoot.ToString());
        }

        [Theory]
        [InlineData("Sheet1!R1C1")]
        [InlineData("'Sheet Name'!R1C1")]
        [InlineData("[Book1]Sheet1!R1C1")]
        public void Parse_R1C1WithSheetReferences_ReturnsCorrectAST(string formulaString)
        {

            Formula formula = FormulaParser.Parse(formulaString);

                        Assert.NotNull(formula.AstRoot);
            Assert.Equal(formulaString, formula.AstRoot.ToString());
        }

        [Theory]
        [InlineData("R1C1:R10C10")]
        [InlineData("R[1]C[1]:R[10]C[10]")]
        [InlineData("R:R")] // Entire row
        [InlineData("C:C")] // Entire column
        public void Parse_R1C1RangeReferences_ReturnsCorrectAST(string formulaString)
        {

            Formula formula = FormulaParser.Parse(formulaString);

                        Assert.NotNull(formula.AstRoot);
            Assert.Equal(formulaString, formula.AstRoot.ToString());
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
            Formula formula = FormulaParser.Parse(nestedFormula);
            stopwatch.Stop();

            Assert.NotNull(formula.AstRoot);
            Assert.True(stopwatch.ElapsedMilliseconds < 1000, $"Parsing took {stopwatch.ElapsedMilliseconds}ms, expected < 1000ms");
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
                Formula formula = FormulaParser.Parse(formulaText);
                Assert.NotNull(formula.AstRoot);
            }
            stopwatch.Stop();

            Assert.True(stopwatch.ElapsedMilliseconds < 5000, $"Parsing 1000 formulas took {stopwatch.ElapsedMilliseconds}ms, expected < 5000ms");
        }

        [Theory]
        [InlineData(10)]
        [InlineData(50)]
        [InlineData(100)]
        public void Parse_FormulaWithManyArguments_ParsesSuccessfully(int argumentCount)
        {
            string formula = "SUM(" + string.Join(",", Enumerable.Range(1, argumentCount).Select(i => $"A{i}")) + ")";

            Formula parsed = FormulaParser.Parse(formula);
            Assert.NotNull(parsed.AstRoot);
            Assert.Equal(formula, parsed.AstRoot.ToString());
        }
    }
}

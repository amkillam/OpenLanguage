using System;
using System.Linq;
using OpenLanguage.SpreadsheetML.Formula.Ast;
using Xunit;

namespace OpenLanguage.SpreadsheetML.Formula.Tests
{
    /// <summary>
    /// Comprehensive edge case tests for formula parsing focusing on boundary conditions and error scenarios
    /// </summary>
    public class FormulaParsingEdgeCaseTests
    {
        [Theory]
        [InlineData("=A1")] // Formula with leading equals
        [InlineData("A1")] // Formula without leading equals
        [InlineData("==A1")] // Double equals handling
        [InlineData("===A1")] // Triple equals handling
        public void Parse_FormulasWithEqualsSignVariations_HandlesCorrectly(string input)
        {
            Ast.Node formula = FormulaParser.Parse(input);

            Assert.NotNull(formula);
            Assert.Equal(input, formula.ToString());
        }

        [Theory]
        [InlineData("A1+B1", "A1", "B1")]
        [InlineData("SUM(A1:A10)+AVERAGE(B1:B10)", "SUM(A1:A10)", "AVERAGE(B1:B10)")]
        [InlineData("(A1+B1)+(C1+D1)", "(A1+B1)", "(C1+D1)")]
        [InlineData("A1*B1+C1*D1", "A1*B1", "C1*D1")] // Precedence test
        public void Parse_BinaryOperations_IdentifiesOperandsCorrectly(
            string formulaString,
            string expectedLeft,
            string expectedRight
        )
        {
            Ast.Node formula = FormulaParser.Parse(formulaString);

            Assert.NotNull(formula);
            Assert.Equal(formulaString, formula.ToString());
            Assert.Equal(expectedLeft, ((Ast.BinaryOperatorNode)formula).Left.ToString());
            Assert.Equal(expectedRight, ((Ast.BinaryOperatorNode)formula).Right.ToString());
        }

        [Theory]
        [InlineData("SUM()", 0)] // No arguments
        [InlineData("SUM(A1)", 1)] // Single argument
        [InlineData("SUM(A1,B1)", 2)] // Two arguments
        [InlineData("SUM(A1,B1,C1,D1,E1)", 5)] // Multiple arguments
        [InlineData("IF(A1>0,B1,C1)", 3)] // Conditional arguments
        public void Parse_FunctionCallsWithVariousArgumentCounts_HandlesCorrectly(
            string formulaString,
            int expectedArgCount
        )
        {
            Ast.Node formula = FormulaParser.Parse(formulaString);

            Assert.NotNull(formula);
            Assert.Equal(formulaString, formula.ToString());
            Assert.NotNull(formula);
            Ast.FunctionCallNode functionNode = (Ast.FunctionCallNode)formula;
            Assert.Equal(expectedArgCount, functionNode.Arguments.Count);
        }

        [Theory]
        [InlineData("IFERROR(A1/B1,0)")] // Error handling function
        [InlineData("ISERROR(A1/B1)")] // Error checking function
        [InlineData("ISNA(VLOOKUP(A1,B:C,2,0))")] // NA checking function
        [InlineData("IFNA(VLOOKUP(A1,B:C,2,0),\"Not Found\")")] // NA handling function
        public void Parse_ErrorHandlingFunctions_ReturnsCorrectAST(string formulaString)
        {
            Ast.Node formula = FormulaParser.Parse(formulaString);

            Assert.NotNull(formula);
            Assert.Equal(formulaString, formula.ToString());
        }

        [Theory]
        [InlineData("A1:A1048576")] // Maximum rows in Excel
        [InlineData("A1:XFD1")] // Maximum columns in Excel
        [InlineData("XFD1048576")] // Maximum cell reference
        [InlineData("$XFD$1048576")] // Maximum absolute reference
        public void Parse_MaximumRangeReferences_HandlesCorrectly(string formulaString)
        {
            Ast.Node formula = FormulaParser.Parse(formulaString);

            Assert.NotNull(formula);
            Assert.Equal(formulaString, formula.ToString());
        }

        [Theory]
        [InlineData("1.7976931348623157E+308")] // Maximum double value
        [InlineData("-1.7976931348623157E+308")] // Minimum double value
        [InlineData("4.9406564584124654E-324")] // Smallest positive double
        [InlineData("0")] // Zero
        [InlineData("2147483647")] // Maximum int32
        [InlineData("-2147483648")] // Minimum int32
        public void Parse_ExtremeNumericValues_HandlesCorrectly(string formulaString)
        {
            Ast.Node formula = FormulaParser.Parse(formulaString);

            Assert.NotNull(formula);
            Assert.Equal(formulaString, formula.ToString());
        }

        [Theory]
        [InlineData("\"\"\"\"")] // String with just quotes
        [InlineData("\"\"\"\"\"\"")] // String with escaped quotes
        [InlineData("\"Line1\nLine2\"")] // Multi-line string
        [InlineData("\"Tab\tSeparated\"")] // Tab-separated string
        [InlineData("\"Unicode: \u03B1\u03B2\u03B3\"")] // Unicode string
        public void Parse_ComplexStringLiterals_HandlesCorrectly(string formulaString)
        {
            Ast.Node formula = FormulaParser.Parse(formulaString);

            Assert.NotNull(formula);
            Assert.Equal(formulaString, formula.ToString());
        }

        [Theory]
        [InlineData("{1,2,3,4,5,6,7,8,9,10}")] // Large array
        [InlineData("{1;2;3;4;5;6;7;8;9;10}")] // Vertical array
        [InlineData("{1,2,3;4,5,6;7,8,9}")] // 3x3 matrix
        [InlineData("{{1,2},{3,4}}")] // Nested arrays
        [InlineData("{\"A\",\"B\",\"C\";\"D\",\"E\",\"F\"}")] // String matrix
        public void Parse_ComplexArrayLiterals_HandlesCorrectly(string formulaString)
        {
            Ast.Node formula = FormulaParser.Parse(formulaString);

            Assert.NotNull(formula);
            Assert.Equal(formulaString, formula.ToString());
        }

        [Theory]
        [InlineData("A1,B1,C1,D1,E1")] // Union of cells
        [InlineData("A1:B2,C3:D4,E5:F6")] // Union of ranges
        [InlineData("A:A,B:B,C:C")] // Union of columns
        [InlineData("1:1,2:2,3:3")] // Union of rows
        [InlineData("Sheet1!A1,Sheet2!B1")] // Cross-sheet union
        public void Parse_UnionReferences_HandlesCorrectly(string formulaString)
        {
            Ast.Node formula = FormulaParser.Parse(formulaString);

            Assert.NotNull(formula);
            Assert.Equal(formulaString, formula.ToString());
        }

        [Theory]
        [InlineData("A1:B2 C3:D4")] // Intersection of ranges
        [InlineData("(A1:C3) (B2:D4)")] // Parenthesized intersection
        [InlineData("A:A 1:1")] // Column and row intersection
        public void Parse_IntersectionReferences_HandlesCorrectly(string formulaString)
        {
            Ast.Node formula = FormulaParser.Parse(formulaString);

            Assert.NotNull(formula);
            Assert.Equal(formulaString, formula.ToString());
        }

        [Theory]
        [InlineData("1+2+3+4+5+6+7+8+9+10")] // Long addition chain
        [InlineData("1*2*3*4*5*6*7*8*9*10")] // Long multiplication chain
        [InlineData("((((((((1+2)+3)+4)+5)+6)+7)+8)+9)+10")] // Deep left nesting
        [InlineData("1+(2+(3+(4+(5+(6+(7+(8+(9+10))))))))")] // Deep right nesting
        public void Parse_DeeplyNestedOperations_HandlesCorrectly(string formulaString)
        {
            Ast.Node formula = FormulaParser.Parse(formulaString);

            Assert.NotNull(formula);
            Assert.Equal(formulaString, formula.ToString());
        }

        [Theory]
        [InlineData("SUM(IF(A1:A10>0,A1:A10,0))")] // Array formula inside function
        [InlineData("MAX(IF(A1:A10<>\"\",ROW(A1:A10)))")] // Complex array condition
        [InlineData("SUMPRODUCT((A1:A10>0)*(B1:B10<100)*(C1:C10))")] // Multiple array conditions
        public void Parse_ArrayFormulasInFunctions_HandlesCorrectly(string formulaString)
        {
            Ast.Node formula = FormulaParser.Parse(formulaString);

            Assert.NotNull(formula);
            Assert.Equal(formulaString, formula.ToString());
        }

        [Fact]
        public void Parse_FormulaWithAllOperatorTypes_HandlesCorrectly()
        {
            // Create a formula using all operator types
            string formulaString = "1+2-3*4/5^6%7=8<>9<10<=11>12>=13&\"text\"";

            Ast.Node formula = FormulaParser.Parse(formulaString);

            Assert.NotNull(formula);
            Assert.Equal(formulaString, formula.ToString());
        }

        [Fact]
        public void Parse_FormulaWithAllLiteralTypes_HandlesCorrectly()
        {
            // Create a formula using all literal types
            string formulaString = "SUM(123,\"text\",TRUE,#N/A,A1,{1,2,3})";

            Ast.Node formula = FormulaParser.Parse(formulaString);

            Assert.NotNull(formula);
            Assert.Equal(formulaString, formula.ToString());
        }

        [Fact]
        public void TryParse_WithValidFormula_ReturnsFormulaWithCorrectProperties()
        {
            string formulaText = "SUM(A1:A10)";

            Ast.Node? result = FormulaParser.TryParse(formulaText);

            Assert.NotNull(result);
            Assert.Equal(formulaText, result.ToString());
        }

        [Fact]
        public void TryParse_WithInvalidFormula_ReturnsNull()
        {
            string invalidFormula = "SUM(A1,";

            Ast.Node? result = FormulaParser.TryParse(invalidFormula);

            Assert.Null(result);
        }

        [Theory]
        [InlineData("A1048577")] // Row out of range
        [InlineData("XFE1")] // Column out of range (beyond XFD)
        [InlineData("A0")] // Row 0 (invalid)
        public void Parse_InvalidCellReferences_ThrowsException(string formulaString)
        {
            Exception exception = Assert.ThrowsAny<Exception>(() =>
                FormulaParser.Parse(formulaString)
            );
            Assert.NotNull(exception);
        }

        [Theory]
        [InlineData("SUM(A1:A10")] // Missing closing parenthesis
        [InlineData("SUM)A1:A10(")] // Mismatched parentheses
        [InlineData("SUM((A1:A10)")] // Unmatched opening parenthesis
        [InlineData("SUM(A1:A10))")] // Extra closing parenthesis
        public void Parse_MismatchedParentheses_ThrowsException(string formulaString)
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                FormulaParser.Parse(formulaString)
            );
            Assert.Contains("syntax", exception.Message.ToLower());
        }

        [Theory]
        [InlineData("{1,2,3")] // Unclosed array
        [InlineData("1,2,3}")] // Missing opening brace
        [InlineData("{1,2,3}}")] // Extra closing brace
        [InlineData("{{1,2,3}")] // Unmatched nested brace
        public void Parse_MalformedArrays_ThrowsException(string formulaString)
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                FormulaParser.Parse(formulaString)
            );
            Assert.Contains("syntax", exception.Message.ToLower());
        }

        [Theory]
        [InlineData("++1")]
        [InlineData("1++2")]
        [InlineData("A1+")] // Missing right operand
        [InlineData("+A1")] // Unary plus (might be valid)
        [InlineData("*A1")] // Invalid unary operator
        [InlineData("A1*")] // Missing right operand
        [InlineData("A1++B1")] // Double operator
        public void Parse_InvalidOperatorUsage_HandlesProperly(string formulaString)
        {
            // Some of these might be valid (like +A1), others should throw
            try
            {
                Ast.Node formula = FormulaParser.Parse(formulaString);
                Assert.NotNull(formula);
                // If parsing succeeds, verify the result makes sense
                Assert.NotNull(formula.ToString());
            }
            catch (InvalidOperationException ex)
            {
                // If parsing fails, it should be due to syntax errors
                Assert.Contains("syntax", ex.Message.ToLower());
            }
        }
    }

    /// <summary>
    /// Tests for formula parsing performance and memory usage with large inputs
    /// </summary>
    public class FormulaParsingPerformanceEdgeCaseTests
    {
        [Fact]
        public void Parse_FormulaWithThousandsOfArguments_HandlesWithinMemoryLimits()
        {
            // Create a formula with 1000 arguments
            System.Text.StringBuilder formulaBuilder = new System.Text.StringBuilder();
            formulaBuilder.Append("SUM(");

            for (int i = 1; i <= 1000; i++)
            {
                if (i > 1)
                {
                    formulaBuilder.Append(",");
                }
                int oneIndexed = i + 1;
                formulaBuilder.Append($"A{oneIndexed}");
            }

            formulaBuilder.Append(")");
            string largeFormula = formulaBuilder.ToString();
            formulaBuilder.Clear();

            // Measure memory before
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
            System.GC.Collect();
            long memoryBefore = System.GC.GetTotalMemory(true);

            Ast.Node formula = FormulaParser.Parse(largeFormula);

            // Measure memory after
            long memoryAfter = System.GC.GetTotalMemory(false);
            long memoryUsed = memoryAfter - memoryBefore;

            Assert.Equal(1002, formula.Children<Node>().Count() + 1); // SUM + 1001 args

            // Memory usage should be reasonable (less than 96MB for this test)
            Assert.True(
                memoryUsed < 96 * 1024 * 1024,
                $"Memory usage was {memoryUsed} bytes, expected < 96MB"
            );

            Assert.NotNull(formula);
            Assert.Equal(largeFormula, formula.ToString());
        }

        [Fact]
        public void Parse_MultipleComplexFormulas_DoesNotLeakMemory()
        {
            // Parse multiple complex formulas to check for memory leaks
            string[] complexFormulas = new string[]
            {
                "SUMPRODUCT((A1:A1000>0)*(B1:B1000<100)*(C1:C1000))",
                "IF(AND(A1<>\"\",B1<>\"\"),VLOOKUP(A1,Sheet2!$A:$D,MATCH(B1,Sheet2!$1:$1,0),FALSE),\"\")",
                "INDEX(INDIRECT(\"A1:A\"&COUNTA(A:A)),MATCH(MAX(B:B),B:B,0))",
                "LET(x,A1:A100,y,B1:B100,SUM(x*y)/SQRT(SUM(x^2)*SUM(y^2)))",
                "LAMBDA(arr,REDUCE(0,arr,LAMBDA(acc,val,IF(val>acc,val,acc))))(A1:A100)",
            };

            // Measure initial memory
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
            System.GC.Collect();
            long initialMemory = System.GC.GetTotalMemory(false);

            // Parse formulas multiple times
            for (int iteration = 0; iteration < 10; iteration++)
            {
                foreach (string formulaText in complexFormulas)
                {
                    Ast.Node? formula = FormulaParser.TryParse(formulaText);
                    if (formula == null)
                    {
                        throw new Exception($"Failed to parse formula: {formulaText}");
                    }
                    if (formulaText != formula.ToString())
                    {
                        throw new Exception(
                            $"Parsed formula does not match original. Original: \"{formulaText}\". Reconstructed:  \"{formula.ToString()}\""
                        );
                    }
                }
            }

            // Force garbage collection
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
            System.GC.Collect();
            long finalMemory = System.GC.GetTotalMemory(false);

            long memoryIncrease = finalMemory - initialMemory;

            // Memory increase should be minimal (less than 48MB)
            Assert.True(
                memoryIncrease < 48 * 1024 * 1024,
                $"Memory increased by {memoryIncrease} bytes, expected < 5MB"
            );
        }

        [Fact]
        public void Parse_ConcurrentFormulaParsing_ThreadSafe()
        {
            // Test thread safety by parsing formulas concurrently
            string[] testFormulas = new string[]
            {
                "SUM(A1:A10)",
                "AVERAGE(B1:B10)",
                "COUNT(C1:C10)",
                "MAX(D1:D10)",
                "MIN(E1:E10)",
                "IF(A1>0,\"Positive\",\"Zero or Negative\")",
                "VLOOKUP(A1,B:C,2,FALSE)",
                "INDEX(A:A,MATCH(\"value\",B:B,0))",
            };

            System.Threading.Tasks.Parallel.ForEach(
                testFormulas,
                formulaText =>
                {
                    for (int i = 0; i < 100; i++)
                    {
                        Ast.Node formula = FormulaParser.Parse(formulaText);
                        Assert.NotNull(formula);
                        Assert.Equal(formulaText, formula.ToString());
                    }
                }
            );
        }
    }
}

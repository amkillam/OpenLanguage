using System;
using OpenLanguage.SpreadsheetML.Formula;
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
    // [InlineData("A1#")]
    [InlineData("Table1[@Column1]")]
    // [InlineData("Table1[[#Headers],[Column1]]")]
    // [InlineData("A:A")]
    // [InlineData("1:1")]
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
}

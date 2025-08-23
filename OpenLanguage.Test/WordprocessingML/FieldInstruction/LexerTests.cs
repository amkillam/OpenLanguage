using System;
using System.Collections.Generic;
using System.Linq;
using OpenLanguage;
using Xunit;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Tests
{
  public class ExpressionLexerTests
  {
    [Theory]
    [InlineData("simple", new[] { "simple" })]
    [InlineData("two words", new[] { "two", "words" })]
    [InlineData("\"quoted string\"", new[] { "quoted string" })]
    [InlineData("field = value", new[] { "field", "=", "value" })]
    [InlineData("a > b", new[] { "a", ">", "b" })]
    [InlineData("x <= y", new[] { "x", "<=", "y" })]
    [InlineData("name <> \"test\"", new[] { "name", "<>", "test" })]
    public void Parse_WithValidExpressions_ReturnsExpectedTokens(
      string expression,
      string[] expectedTokens
    )
    {
      // Act
      Expression result = ExpressionLexer.Parse(expression);

      // Assert
      List<ExpressionToken> actualTokens = result
        .Tokens.Where(t => t.Type != ExpressionTokenType.Whitespace)
        .ToList();
      Assert.Equal(expectedTokens.Length, actualTokens.Count);
      for (Int32 i = 0; i < expectedTokens.Length; i++)
      {
        Assert.Equal(expectedTokens[i], actualTokens[i].Value);
      }
    }

    [Theory]
    [InlineData("")]
    [InlineData("    ")]
    [InlineData(null)]
    public void Parse_WithEmptyOrNullExpression_ReturnsEmptyList(string? expression)
    {
      // Act
      Expression result = ExpressionLexer.Parse(expression!);

      // Assert
      Assert.Empty(result.Tokens);
    }

    [Fact]
    public void Parse_WithComplexExpression_HandlesAllOperators()
    {
      // Arrange
      string expression = "field1 = \"value1\" AND field2 > 10 OR field3 <> \"test\"";

      // Act
      Expression result = ExpressionLexer.Parse(expression);

      // Assert
      string[] actualTokens = result
        .Tokens.Where(t => t.Type != ExpressionTokenType.Whitespace)
        .Select(t => t.Value)
        .ToArray();
      Assert.Contains("field1", actualTokens);
      Assert.Contains("=", actualTokens);
      Assert.Contains("value1", actualTokens);
      Assert.Contains("AND", actualTokens);
      Assert.Contains("field2", actualTokens);
      Assert.Contains(">", actualTokens);
      Assert.Contains("10", actualTokens);
      Assert.Contains("OR", actualTokens);
      Assert.Contains("field3", actualTokens);
      Assert.Contains("<>", actualTokens);
      Assert.Contains("test", actualTokens);
    }

    [Fact]
    public void Parse_WithQuotedStringsContainingSpaces_PreservesQuotedContent()
    {
      // Arrange
      string expression = "name = \"John Smith\" AND age > 25";

      // Act
      Expression result = ExpressionLexer.Parse(expression);

      // Assert
      List<string> tokenValues = result.Tokens.Select(t => t.Value ?? string.Empty).ToList();
      Assert.Contains("John Smith", tokenValues);
      Assert.DoesNotContain("\"John Smith\"", tokenValues);
    }

    [Theory]
    [InlineData("field1=value1", new[] { "field1", "=", "value1" })]
    [InlineData("a>b", new[] { "a", ">", "b" })]
    [InlineData("x<=y", new[] { "x", "<=", "y" })]
    public void Parse_WithoutSpaces_StillTokenizesCorrectly(
      string expression,
      string[] expectedTokens
    )
    {
      // Act
      Expression result = ExpressionLexer.Parse(expression);

      // Assert
      List<ExpressionToken> actualTokens = result
        .Tokens.Where(t => t.Type != ExpressionTokenType.Whitespace)
        .ToList();
      Assert.Equal(expectedTokens.Length, actualTokens.Count);
      for (Int32 i = 0; i < expectedTokens.Length; i++)
      {
        Assert.Equal(expectedTokens[i], actualTokens[i].Value);
      }
    }

    [Fact]
    public void Parse_WithNestedQuotes_HandlesCorrectly()
    {
      // Arrange
      string expression = "field = \"value with \\\"nested\\\" quotes\"";

      // Act
      Expression result = ExpressionLexer.Parse(expression);

      // Assert
      List<ExpressionToken> actualTokens = result
        .Tokens.Where(t => t.Type != ExpressionTokenType.Whitespace)
        .ToList();
      Assert.Equal(3, actualTokens.Count);
      Assert.Equal("field", actualTokens[0].Value);
      Assert.Equal("=", actualTokens[1].Value);
      Assert.Equal("value with \"nested\" quotes", actualTokens[2].Value);
    }

    [Theory]
    [InlineData("    field   =   value   ", new[] { "field", "=", "value" })]
    [InlineData("\tfield\t=\tvalue\t", new[] { "field", "=", "value" })]
    [InlineData(" \t field \t = \t value \t ", new[] { "field", "=", "value" })]
    public void Parse_WithExtraWhitespace_TrimsCorrectly(string expression, string[] expectedTokens)
    {
      // Act
      Expression result = ExpressionLexer.Parse(expression);

      // Assert
      List<ExpressionToken> actualTokens = result
        .Tokens.Where(t => t.Type != ExpressionTokenType.Whitespace)
        .ToList();
      Assert.Equal(expectedTokens.Length, actualTokens.Count);
      for (Int32 i = 0; i < expectedTokens.Length; i++)
      {
        Assert.Equal(expectedTokens[i], actualTokens[i].Value);
      }
    }
  }

  public class MergeFieldLexerTests
  {
    [Theory]
    [InlineData("«FirstName»", "FirstName", null)]
    [InlineData("«LastName»", "LastName", null)]
    [InlineData("«Address1»", "Address1", null)]
    [InlineData("«FirstName\\* Upper»", "FirstName", "\\* Upper")]
    [InlineData("«LastName\\* Lower»", "LastName", "\\* Lower")]
    public void ParseMergeField_WithValidPlaceholders_ReturnsCorrectPlaceholder(
      string placeholderText,
      string expectedFieldName,
      string? expectedSwitch
    )
    {
      // Act
      MergeFieldPlaceholder result = MergeFieldLexer.ParseMergeField(placeholderText);

      // Assert
      Assert.Equal(placeholderText, result.RawText);
      Assert.Equal(expectedFieldName, result.FieldName);
      Assert.Equal(expectedSwitch, result.FormattingSwitch);
      Assert.True(result.IsValid);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("FirstName")]
    [InlineData("«»")]
    [InlineData("«  »")]
    public void ParseMergeField_WithInvalidPlaceholders_ReturnsInvalidPlaceholder(
      string? placeholderText
    )
    {
      // Act
      MergeFieldPlaceholder result = MergeFieldLexer.ParseMergeField(placeholderText);

      // Assert
      Assert.Equal(placeholderText ?? string.Empty, result.RawText);
      Assert.False(result.IsValid);
    }

    [Fact]
    public void ParseMergeField_WithWhitespaceInFieldName_TrimsCorrectly()
    {
      // Arrange
      string placeholderText = "«  FirstName  »";

      // Act
      MergeFieldPlaceholder result = MergeFieldLexer.ParseMergeField(placeholderText);

      // Assert
      Assert.Equal("FirstName", result.FieldName);
      Assert.True(result.IsValid);
    }

    [Theory]
    [InlineData("Hello «FirstName», welcome!", new[] { "FirstName" })]
    [InlineData("«FirstName» «LastName»", new[] { "FirstName", "LastName" })]
    [InlineData(
      "Address: «Address1» «City», «State» «ZipCode»",
      new[] { "Address1", "City", "State", "ZipCode" }
    )]
    [InlineData("No merge fields here", new string[0])]
    public void ExtractMergeFieldNames_WithVariousTexts_ReturnsExpectedFieldNames(
      string text,
      string[] expectedFieldNames
    )
    {
      // Act
      List<string> result = MergeFieldLexer.ExtractMergeFieldNames(text);

      // Assert
      Assert.Equal(expectedFieldNames.Length, result.Count);
      foreach (string expectedName in expectedFieldNames)
      {
        Assert.Contains(expectedName, result);
      }
    }

    [Fact]
    public void ExtractMergeFieldNames_WithDuplicateFields_ReturnsUniqueNames()
    {
      // Arrange
      string text = "Hello «FirstName», your name is «FirstName»";

      // Act
      List<string> result = MergeFieldLexer.ExtractMergeFieldNames(text);

      // Assert
      Assert.Single(result);
      Assert.Equal("FirstName", result[0]);
    }

    [Theory]
    [InlineData("Hello «FirstName»!", true)]
    [InlineData("«Address1» «City»", true)]
    [InlineData("No merge fields", false)]
    [InlineData("", false)]
    [InlineData(null, false)]
    public void ContainsValidMergeFields_WithVariousTexts_ReturnsExpectedResult(
      string? text,
      bool expected
    )
    {
      // Act
      bool result = MergeFieldLexer.ContainsValidMergeFields(text);

      // Assert
      Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("FirstName", "«FirstName»")]
    [InlineData("LastName", "«LastName»")]
    [InlineData("", "")]
    [InlineData(null, "")]
    public void FormatMergeField_WithFieldNames_ReturnsFormattedField(
      string? fieldName,
      string expected
    )
    {
      // Act
      string result = MergeFieldLexer.FormatMergeField(fieldName);

      // Assert
      Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("FirstName", "* Upper", "«FirstName\\* Upper»")]
    [InlineData("LastName", "* Lower", "«LastName\\* Lower»")]
    [InlineData("FirstName", null, "«FirstName»")]
    [InlineData("FirstName", "", "«FirstName»")]
    public void FormatMergeFieldWithSwitch_WithFieldNamesAndSwitches_ReturnsFormattedField(
      string fieldName,
      string? formattingSwitch,
      string expected
    )
    {
      // Act
      string result = MergeFieldLexer.FormatMergeFieldWithSwitch(fieldName, formattingSwitch);

      // Assert
      Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1033", LanguageIdentifier.EnglishUS)]
    [InlineData("1036", LanguageIdentifier.FrenchFrance)]
    [InlineData("1031", LanguageIdentifier.GermanGermany)]
    [InlineData("en-US", LanguageIdentifier.EnglishUS)]
    [InlineData("fr-FR", LanguageIdentifier.FrenchFrance)]
    [InlineData("de-DE", LanguageIdentifier.GermanGermany)]
    [InlineData("EnglishUS", LanguageIdentifier.EnglishUS)]
    public void ParseLanguageId_WithValidInputs_ReturnsCorrectLanguageIdentifier(
      string input,
      LanguageIdentifier expected
    )
    {
      // Act
      LanguageIdentifier? result = MergeFieldLexer.ParseLanguageId(input);

      // Assert
      Assert.NotNull(result);
      Assert.Equal(expected, result.Value);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("    ")]
    [InlineData("invalid")]
    [InlineData("99999")]
    [InlineData("xx-XX")]
    public void ParseLanguageId_WithInvalidInputs_ReturnsNull(string? input)
    {
      // Act
      LanguageIdentifier? result = MergeFieldLexer.ParseLanguageId(input!);

      // Assert
      Assert.Null(result);
    }

    [Fact]
    public void ParseAddressBlockTemplate_WithMergeFields_ParsesCorrectly()
    {
      // Arrange
      string template = "«FirstName» «LastName»\n«Address1»\n«City», «State» «ZipCode»";

      // Act
      AddressBlockTemplate result = MergeFieldLexer.ParseAddressBlockTemplate(template);

      // Assert
      Assert.Equal(template, result.RawTemplate);
      Assert.Equal(6, result.Placeholders.Count);
      Assert.Contains(result.Placeholders, p => p.FieldName == "FirstName");
      Assert.Contains(result.Placeholders, p => p.FieldName == "LastName");
      Assert.Contains(result.Placeholders, p => p.FieldName == "Address1");
      Assert.Contains(result.Placeholders, p => p.FieldName == "City");
      Assert.Contains(result.Placeholders, p => p.FieldName == "State");
      Assert.Contains(result.Placeholders, p => p.FieldName == "ZipCode");

      // Check processed template has format specifiers
      Assert.Contains("{0}", result.ProcessedTemplate);
      Assert.Contains("{1}", result.ProcessedTemplate);
      Assert.Contains("{2}", result.ProcessedTemplate);
      Assert.Contains("{3}", result.ProcessedTemplate);
      Assert.Contains("{4}", result.ProcessedTemplate);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("No merge fields here")]
    public void ParseAddressBlockTemplate_WithNoMergeFields_ReturnsEmptyPlaceholders(
      string? template
    )
    {
      // Act
      AddressBlockTemplate result = MergeFieldLexer.ParseAddressBlockTemplate(template);

      // Assert
      Assert.Equal(template ?? string.Empty, result.RawTemplate);
      Assert.Empty(result.Placeholders);
      Assert.Equal(template ?? string.Empty, result.ProcessedTemplate);
    }
  }

  public class ODBCConnectionLexerTests
  {
    [Theory]
    [InlineData("DSN=myDSN", "myDSN")]
    [InlineData("Driver={Microsoft Access Driver (*.mdb)}", "{Microsoft Access Driver (*.mdb)}")]
    [InlineData("DBQ=C:\\database.mdb", "C:\\database.mdb")]
    [InlineData("Provider=Microsoft.Jet.OLEDB.4.0", "Microsoft.Jet.OLEDB.4.0")]
    [InlineData("Data Source=server", "server")]
    [InlineData("Initial Catalog=database", "database")]
    public void Parse_WithValidComponents_ReturnsExpectedComponents(
      string connectionString,
      string expectedValue
    )
    {
      // Act
      System.Data.Odbc.OdbcConnectionStringBuilder? result = ODBCConnectionLexer.Parse(
        connectionString
      );

      // Assert
      Assert.NotNull(result);
      // For ODBC connection strings, we verify that parsing succeeded by checking the connection string is not empty
      Assert.False(string.IsNullOrEmpty(result.ConnectionString));

      // Note: We can't easily test individual component types with ODBC builder,
      // but we can verify the parsing succeeded and connection string contains expected content
      Assert.Contains(expectedValue, result.ConnectionString);
    }

    [Fact]
    public void Parse_WithMultipleComponents_ReturnsAllComponents()
    {
      // Arrange
      string connectionString = @"DSN=myDSN;UID=user;PWD=password;DBQ=C:\test.mdb";

      // Act
      System.Data.Odbc.OdbcConnectionStringBuilder? result = ODBCConnectionLexer.Parse(
        connectionString
      );

      // Assert
      Assert.NotNull(result);
      Assert.False(string.IsNullOrEmpty(result.ConnectionString));
      // Verify that the parsed connection string contains the expected key-value pairs
      Assert.True(result.ContainsKey("DSN"));
      Assert.Equal("myDSN", result["DSN"]);
      Assert.True(result.ContainsKey("UID"));
      Assert.Equal("user", result["UID"]);
      Assert.True(result.ContainsKey("PWD"));
      Assert.Equal("password", result["PWD"]);
      Assert.True(result.ContainsKey("DBQ"));
      // Use the expected backslash format
      string dbqValue = result["DBQ"] as string ?? string.Empty;
      Assert.True(
        dbqValue.Contains(@"test.mdb"),
        $"Expected path to contain test.mdb, but got: {dbqValue}"
      );
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("    ")]
    public void Parse_WithEmptyOrNullString_ReturnsNull(string? connectionString)
    {
      // Act
      System.Data.Odbc.OdbcConnectionStringBuilder? result = ODBCConnectionLexer.Parse(
        connectionString
      );

      // Assert
      Assert.Null(result);
    }

    [Fact]
    public void Parse_WithQuotedValues_HandlesQuotesCorrectly()
    {
      // Arrange
      string connectionString = "Driver={SQL Server};Server=\"server name\";ODBC='db name'";

      // Act
      System.Data.Odbc.OdbcConnectionStringBuilder? result = ODBCConnectionLexer.Parse(
        connectionString
      );

      // Assert
      Assert.NotNull(result);
      Assert.True(result.ContainsKey("Driver"));
      Assert.Equal("{SQL Server}", result["Driver"]);
      Assert.True(result.ContainsKey("Server"));
      // ODBC connection string builder may preserve or strip quotes depending on implementation
      string serverValue = result["Server"] as string ?? string.Empty;
      Assert.True(
        serverValue.Contains("server name"),
        $"Expected server name to be contained, but got: {serverValue}"
      );
      Assert.True(result.ContainsKey("ODBC"));
      string databaseValue = result["ODBC"] as string ?? string.Empty;
      Assert.True(
        databaseValue.Contains("db name"),
        $"Expected db name to be contained, but got: {databaseValue}"
      );
    }

    [Fact]
    public void Parse_WithCaseInsensitiveKeys_HandlesCorrectly()
    {
      // Arrange
      string connectionString = "dsn=test;UID=user;pwd=pass";

      // Act
      System.Data.Odbc.OdbcConnectionStringBuilder? result = ODBCConnectionLexer.Parse(
        connectionString
      );

      // Assert
      Assert.NotNull(result);
      // ODBC connection string builder is case-insensitive for keys
      Assert.True(result.ContainsKey("dsn") || result.ContainsKey("DSN"));
      Assert.True(result.ContainsKey("UID"));
      Assert.True(result.ContainsKey("pwd") || result.ContainsKey("PWD"));
    }

    [Fact]
    public void Parse_WithSpecialCharactersInValues_HandlesCorrectly()
    {
      // Arrange
      string connectionString = "DBQ=C:\\Path With Spaces\\database.mdb;PWD=p@ssw0rd!";

      // Act
      System.Data.Odbc.OdbcConnectionStringBuilder? result = ODBCConnectionLexer.Parse(
        connectionString
      );

      // Assert
      Assert.NotNull(result);
      Assert.True(result.ContainsKey("DBQ"));
      Assert.Equal("C:\\Path With Spaces\\database.mdb", result["DBQ"]);
      Assert.True(result.ContainsKey("PWD"));
      Assert.Equal("p@ssw0rd!", result["PWD"]);
    }

    [Fact]
    public void ODBCConnectionComponentType_EnumHasExpectedValues()
    {
      // Act
      ODBCConnectionComponentType[] values = Enum.GetValues<ODBCConnectionComponentType>();

      // Assert
      Assert.True(values.Length >= 10, "Should have comprehensive connection component type list");

      // Test some key components exist
      Assert.Contains(ODBCConnectionComponentType.DataSourceName, values);
      Assert.Contains(ODBCConnectionComponentType.Driver, values);
      Assert.Contains(ODBCConnectionComponentType.Provider, values);
      Assert.Contains(ODBCConnectionComponentType.DataSource, values);
      Assert.Contains(ODBCConnectionComponentType.InitialCatalog, values);
      Assert.Contains(ODBCConnectionComponentType.UID, values);
      Assert.Contains(ODBCConnectionComponentType.PWD, values);
      Assert.Contains(ODBCConnectionComponentType.IntegratedSecurity, values);
      Assert.Contains(ODBCConnectionComponentType.Server, values);
      Assert.Contains(ODBCConnectionComponentType.Database, values);
    }
  }

  public class ExpressionTests
  {
    [Fact]
    public void Constructor_WithValidParameters_SetsProperties()
    {
      // Arrange
      string leftOperand = "field1";
      ComparisonOperator op = ComparisonOperator.Equal;
      string rightOperand = "value1";

      // Act
      Expression expression = new Expression(leftOperand, op, rightOperand);

      // Assert
      Assert.Equal(leftOperand, expression.LeftOperand);
      Assert.Equal(op, expression.Operator);
      Assert.Equal(rightOperand, expression.RightOperand);
    }

    [Theory]
    [InlineData(ComparisonOperator.Equal, "=")]
    [InlineData(ComparisonOperator.NotEqual, "<>")]
    [InlineData(ComparisonOperator.LessThan, "<")]
    [InlineData(ComparisonOperator.LessThanOrEqual, "<=")]
    [InlineData(ComparisonOperator.GreaterThan, ">")]
    [InlineData(ComparisonOperator.GreaterThanOrEqual, ">=")]
    public void ToString_WithDifferentOperators_ReturnsCorrectFormat(
      ComparisonOperator op,
      string expectedOperator
    )
    {
      // Arrange
      Expression expression = new Expression("left", op, "right");

      // Act
      string result = expression.ToString();

      // Assert
      Assert.Equal($"left {expectedOperator} right", result);
    }

    [Theory]
    [InlineData("field", "\"value\"", "field = \"value\"")]
    [InlineData("age", "25", "age = 25")]
    [InlineData("status", "active", "status = active")]
    public void ToString_WithVariousOperands_FormatsCorrectly(
      string left,
      string right,
      string expected
    )
    {
      // Arrange
      Expression expression = new Expression(left, ComparisonOperator.Equal, right);

      // Act
      string result = expression.ToString();

      // Assert
      Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(null, ComparisonOperator.Equal, "value")]
    [InlineData("field", ComparisonOperator.Equal, null)]
    [InlineData("", ComparisonOperator.Equal, "value")]
    [InlineData("field", ComparisonOperator.Equal, "")]
    public void Constructor_WithNullOrEmptyOperands_DoesNotThrow(
      string? left,
      ComparisonOperator op,
      string? right
    )
    {
      // Act & Assert
      Expression expression = new Expression(left, op, right);
      Assert.NotNull(expression);
      Assert.Equal(left, expression.LeftOperand);
      Assert.Equal(right, expression.RightOperand);
    }

    [Fact]
    public void ToString_WithNullOperands_HandlesGracefully()
    {
      // Arrange
      Expression expression = new Expression(null, ComparisonOperator.Equal, null);

      // Act
      string result = expression.ToString();

      // Assert
      Assert.Equal(" = ", result);
    }
  }
}

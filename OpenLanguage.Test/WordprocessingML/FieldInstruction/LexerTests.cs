using System;
using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Expression;
using OpenLanguage.WordprocessingML.MergeField;
using OpenLanguage.WordprocessingML.ODBC;
using OpenLanguage.WordprocessingML.Operators;
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
            Expression.Expression result = ExpressionLexer.Parse(expression);

            List<ExpressionToken> actualTokens = result
                .Tokens.Where(t => t.Type != ExpressionTokenType.Whitespace)
                .ToList();
            Assert.Equal(expectedTokens.Length, actualTokens.Count);
            for (int i = 0; i < expectedTokens.Length; i++)
            {
                Assert.Equal(expectedTokens[i], actualTokens[i].Value);
            }
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        public void Parse_WithEmptyOrNullExpression_ReturnsEmptyList(string? expression)
        {
            Expression.Expression result = ExpressionLexer.Parse(expression!);

            Assert.Empty(result.Tokens);
        }

        [Fact]
        public void Parse_WithComplexExpression_HandlesAllOperators()
        {
            string expression = "field1 = \"value1\" AND field2 > 10 OR field3 <> \"test\"";

            Expression.Expression result = ExpressionLexer.Parse(expression);

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
            string expression = "name = \"John Smith\" AND age > 25";

            Expression.Expression result = ExpressionLexer.Parse(expression);

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
            Expression.Expression result = ExpressionLexer.Parse(expression);

            List<ExpressionToken> actualTokens = result
                .Tokens.Where(t => t.Type != ExpressionTokenType.Whitespace)
                .ToList();
            Assert.Equal(expectedTokens.Length, actualTokens.Count);
            for (int i = 0; i < expectedTokens.Length; i++)
            {
                Assert.Equal(expectedTokens[i], actualTokens[i].Value);
            }
        }

        [Fact]
        public void Parse_WithNestedQuotes_HandlesCorrectly()
        {
            string expression = "field = \"value with \\\"nested\\\" quotes\"";

            Expression.Expression result = ExpressionLexer.Parse(expression);

            List<ExpressionToken> actualTokens = result
                .Tokens.Where(t => t.Type != ExpressionTokenType.Whitespace)
                .ToList();
            Assert.Equal(3, actualTokens.Count);
            Assert.Equal("field", actualTokens[0].Value);
            Assert.Equal("=", actualTokens[1].Value);
            Assert.Equal("value with \"nested\" quotes", actualTokens[2].Value);
        }

        [Theory]
        [InlineData("   field   =   value   ", new[] { "field", "=", "value" })]
        [InlineData("\tfield\t=\tvalue\t", new[] { "field", "=", "value" })]
        [InlineData(" \t field \t = \t value \t ", new[] { "field", "=", "value" })]
        public void Parse_WithExtraWhitespace_TrimsCorrectly(
            string expression,
            string[] expectedTokens
        )
        {
            Expression.Expression result = ExpressionLexer.Parse(expression);

            List<ExpressionToken> actualTokens = result
                .Tokens.Where(t => t.Type != ExpressionTokenType.Whitespace)
                .ToList();
            Assert.Equal(expectedTokens.Length, actualTokens.Count);
            for (int i = 0; i < expectedTokens.Length; i++)
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
            MergeFieldPlaceholder result = MergeFieldLexer.ParseMergeField(placeholderText);

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
            MergeFieldPlaceholder result = MergeFieldLexer.ParseMergeField(placeholderText);

            Assert.Equal(placeholderText ?? string.Empty, result.RawText);
            Assert.False(result.IsValid);
        }

        [Fact]
        public void ParseMergeField_WithWhitespaceInFieldName_TrimsCorrectly()
        {
            string placeholderText = "«  FirstName  »";

            MergeFieldPlaceholder result = MergeFieldLexer.ParseMergeField(placeholderText);

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
            List<string> result = MergeFieldLexer.ExtractMergeFieldNames(text);

            Assert.Equal(expectedFieldNames.Length, result.Count);
            foreach (string expectedName in expectedFieldNames)
            {
                Assert.Contains(expectedName, result);
            }
        }

        [Fact]
        public void ExtractMergeFieldNames_WithDuplicateFields_ReturnsUniqueNames()
        {
            string text = "Hello «FirstName», your name is «FirstName»";

            List<string> result = MergeFieldLexer.ExtractMergeFieldNames(text);

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
            bool result = MergeFieldLexer.ContainsValidMergeFields(text);

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
            string result = MergeFieldLexer.FormatMergeField(fieldName);

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
            string result = MergeFieldLexer.FormatMergeFieldWithSwitch(fieldName, formattingSwitch);

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
            LanguageIdentifier? result = MergeFieldLexer.ParseLanguageId(input);

            Assert.NotNull(result);
            Assert.Equal(expected, result.Value);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("   ")]
        [InlineData("invalid")]
        [InlineData("99999")]
        [InlineData("xx-XX")]
        public void ParseLanguageId_WithInvalidInputs_ReturnsNull(string? input)
        {
            LanguageIdentifier? result = MergeFieldLexer.ParseLanguageId(input!);

            Assert.Null(result);
        }

        [Fact]
        public void ParseAddressBlockTemplate_WithMergeFields_ParsesCorrectly()
        {
            string template = "«FirstName» «LastName»\n«Address1»\n«City», «State» «ZipCode»";

            AddressBlockTemplate result = MergeFieldLexer.ParseAddressBlockTemplate(template);

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
            AddressBlockTemplate result = MergeFieldLexer.ParseAddressBlockTemplate(template);

            Assert.Equal(template ?? string.Empty, result.RawTemplate);
            Assert.Empty(result.Placeholders);
            Assert.Equal(template ?? string.Empty, result.ProcessedTemplate);
        }
    }

    public class ODBCConnectionLexerTests
    {
        [Theory]
        [InlineData("DSN=myDSN", "myDSN")]
        [InlineData(
            "Driver={Microsoft Access Driver (*.mdb)}",
            "{Microsoft Access Driver (*.mdb)}"
        )]
        [InlineData("DBQ=C:\\database.mdb", "C:\\database.mdb")]
        [InlineData("Provider=Microsoft.Jet.OLEDB.4.0", "Microsoft.Jet.OLEDB.4.0")]
        [InlineData("Data Source=server", "server")]
        [InlineData("Initial Catalog=database", "database")]
        public void Parse_WithValidComponents_ReturnsExpectedComponents(
            string connectionString,
            string expectedValue
        )
        {
            System.Data.Odbc.OdbcConnectionStringBuilder? result = ODBCConnectionLexer.Parse(
                connectionString
            );

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
            string connectionString = @"DSN=myDSN;UID=user;PWD=password;DBQ=C:\test.mdb";

            System.Data.Odbc.OdbcConnectionStringBuilder? result = ODBCConnectionLexer.Parse(
                connectionString
            );

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
        [InlineData("   ")]
        public void Parse_WithEmptyOrNullString_ReturnsNull(string? connectionString)
        {
            System.Data.Odbc.OdbcConnectionStringBuilder? result = ODBCConnectionLexer.Parse(
                connectionString
            );

            Assert.Null(result);
        }

        [Fact]
        public void Parse_WithQuotedValues_HandlesQuotesCorrectly()
        {
            string connectionString = "Driver={SQL Server};Server=\"server name\";ODBC='db name'";

            System.Data.Odbc.OdbcConnectionStringBuilder? result = ODBCConnectionLexer.Parse(
                connectionString
            );

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
            string connectionString = "dsn=test;UID=user;pwd=pass";

            System.Data.Odbc.OdbcConnectionStringBuilder? result = ODBCConnectionLexer.Parse(
                connectionString
            );

            Assert.NotNull(result);
            // ODBC connection string builder is case-insensitive for keys
            Assert.True(result.ContainsKey("dsn") || result.ContainsKey("DSN"));
            Assert.True(result.ContainsKey("UID"));
            Assert.True(result.ContainsKey("pwd") || result.ContainsKey("PWD"));
        }

        [Fact]
        public void Parse_WithSpecialCharactersInValues_HandlesCorrectly()
        {
            string connectionString = "DBQ=C:\\Path With Spaces\\database.mdb;PWD=p@ssw0rd!";

            System.Data.Odbc.OdbcConnectionStringBuilder? result = ODBCConnectionLexer.Parse(
                connectionString
            );

            Assert.NotNull(result);
            Assert.True(result.ContainsKey("DBQ"));
            Assert.Equal("C:\\Path With Spaces\\database.mdb", result["DBQ"]);
            Assert.True(result.ContainsKey("PWD"));
            Assert.Equal("p@ssw0rd!", result["PWD"]);
        }

        [Fact]
        public void ODBCConnectionComponentType_EnumHasExpectedValues()
        {
            ODBCConnectionComponentType[] values = Enum.GetValues<ODBCConnectionComponentType>();

            Assert.True(
                values.Length >= 10,
                "Should have comprehensive connection component type list"
            );

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
            string leftOperand = "field1";
            ComparisonOperator op = ComparisonOperator.Equal;
            string rightOperand = "value1";

            Expression.Expression expression = new Expression.Expression(
                leftOperand,
                op,
                rightOperand
            );

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
            Expression.Expression expression = new Expression.Expression("left", op, "right");

            string result = expression.ToString();

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
            Expression.Expression expression = new Expression.Expression(
                left,
                ComparisonOperator.Equal,
                right
            );

            string result = expression.ToString();

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
            Expression.Expression expression = new Expression.Expression(left, op, right);
            Assert.NotNull(expression);
            Assert.Equal(left, expression.LeftOperand);
            Assert.Equal(right, expression.RightOperand);
        }

        [Fact]
        public void ToString_WithNullOperands_HandlesGracefully()
        {
            Expression.Expression expression = new Expression.Expression(
                null,
                ComparisonOperator.Equal,
                null
            );

            string result = expression.ToString();

            Assert.Equal(" = ", result);
        }
    }

    /// <summary>
    /// Advanced edge case tests for expression lexing with comprehensive coverage
    /// </summary>
    public class AdvancedExpressionLexerTests
    {
        [Theory]
        [InlineData(
            "field1 = 'value with single quotes'",
            new[] { "field1", "=", "value with single quotes" }
        )]
        [InlineData(
            "field1 = \"value with double quotes\"",
            new[] { "field1", "=", "value with double quotes" }
        )]
        [InlineData(
            "field1 = 'value with \"mixed\" quotes'",
            new[] { "field1", "=", "value with \"mixed\" quotes" }
        )]
        [InlineData(
            "field1 = \"value with 'mixed' quotes\"",
            new[] { "field1", "=", "value with 'mixed' quotes" }
        )]
        [InlineData(
            "field1 = 'value with ''escaped'' quotes'",
            new[] { "field1", "=", "value with 'escaped' quotes" }
        )]
        [InlineData(
            "field1 = \"value with \"\"escaped\"\" quotes\"",
            new[] { "field1", "=", "value with \"escaped\" quotes" }
        )]
        public void Parse_ComplexQuotedStrings_ReturnsExpectedTokens(
            string expression,
            string[] expectedTokens
        )
        {
            Expression.Expression result = ExpressionLexer.Parse(expression);

            List<ExpressionToken> actualTokens = result
                .Tokens.Where(t => t.Type != ExpressionTokenType.Whitespace)
                .ToList();
            Assert.Equal(expectedTokens.Length, actualTokens.Count);
            for (int i = 0; i < expectedTokens.Length; i++)
            {
                Assert.Equal(expectedTokens[i], actualTokens[i].Value);
            }
        }

        [Theory]
        [InlineData("field1 LIKE 'pattern%'", new[] { "field1", "LIKE", "pattern%" })]
        [InlineData(
            "field1 IN ('value1', 'value2', 'value3')",
            new[] { "field1", "IN", "(", "value1", ",", "value2", ",", "value3", ")" }
        )]
        [InlineData("field1 BETWEEN 10 AND 20", new[] { "field1", "BETWEEN", "10", "AND", "20" })]
        [InlineData("field1 IS NULL", new[] { "field1", "IS", "NULL" })]
        [InlineData("field1 IS NOT NULL", new[] { "field1", "IS", "NOT", "NULL" })]
        [InlineData("field1 EXISTS", new[] { "field1", "EXISTS" })]
        [InlineData("NOT field1 = 'value'", new[] { "NOT", "field1", "=", "value" })]
        public void Parse_AdvancedOperators_ReturnsExpectedTokens(
            string expression,
            string[] expectedTokens
        )
        {
            Expression.Expression result = ExpressionLexer.Parse(expression);

            List<ExpressionToken> actualTokens = result
                .Tokens.Where(t => t.Type != ExpressionTokenType.Whitespace)
                .ToList();
            Assert.Equal(expectedTokens.Length, actualTokens.Count);
            for (int i = 0; i < expectedTokens.Length; i++)
            {
                Assert.Equal(expectedTokens[i], actualTokens[i].Value);
            }
        }

        [Theory]
        [InlineData("field1=123", new[] { "field1", "=", "123" })]
        [InlineData("field1=123.45", new[] { "field1", "=", "123.45" })]
        [InlineData("field1=-123", new[] { "field1", "=", "-123" })]
        [InlineData("field1=+123", new[] { "field1", "=", "+123" })]
        [InlineData("field1=1.23E10", new[] { "field1", "=", "1.23E10" })]
        [InlineData("field1=1.23E-10", new[] { "field1", "=", "1.23E-10" })]
        [InlineData("field1=0xFF", new[] { "field1", "=", "0xFF" })]
        [InlineData("field1=0b1010", new[] { "field1", "=", "0b1010" })]
        public void Parse_NumericLiterals_ReturnsExpectedTokens(
            string expression,
            string[] expectedTokens
        )
        {
            Expression.Expression result = ExpressionLexer.Parse(expression);

            List<ExpressionToken> actualTokens = result
                .Tokens.Where(t => t.Type != ExpressionTokenType.Whitespace)
                .ToList();
            Assert.Equal(expectedTokens.Length, actualTokens.Count);
            for (int i = 0; i < expectedTokens.Length; i++)
            {
                Assert.Equal(expectedTokens[i], actualTokens[i].Value);
            }
        }

        [Theory]
        [InlineData("field_name = 'value'", new[] { "field_name", "=", "value" })]
        [InlineData("field$name = 'value'", new[] { "field$name", "=", "value" })]
        [InlineData("field@domain.com = 'value'", new[] { "field@domain.com", "=", "value" })]
        [InlineData("field.subfield = 'value'", new[] { "field.subfield", "=", "value" })]
        [InlineData("[Field With Spaces] = 'value'", new[] { "Field With Spaces", "=", "value" })]
        [InlineData(
            "`Field With Backticks` = 'value'",
            new[] { "Field With Backticks", "=", "value" }
        )]
        [InlineData("\"Field With Quotes\" = 'value'", new[] { "Field With Quotes", "=", "value" })]
        public void Parse_ComplexFieldNames_ReturnsExpectedTokens(
            string expression,
            string[] expectedTokens
        )
        {
            Expression.Expression result = ExpressionLexer.Parse(expression);

            List<ExpressionToken> actualTokens = result
                .Tokens.Where(t => t.Type != ExpressionTokenType.Whitespace)
                .ToList();
            Assert.Equal(expectedTokens.Length, actualTokens.Count);
            for (int i = 0; i < expectedTokens.Length; i++)
            {
                Assert.Equal(expectedTokens[i], actualTokens[i].Value);
            }
        }

        [Theory]
        [InlineData(
            "field1 = 'value with unicode: αβγδε'",
            new[] { "field1", "=", "value with unicode: αβγδε" }
        )]
        [InlineData(
            "field1 = 'value with emoji: 🚀💻📊'",
            new[] { "field1", "=", "value with emoji: 🚀💻📊" }
        )]
        [InlineData(
            "field1 = 'value with chinese: 你好世界'",
            new[] { "field1", "=", "value with chinese: 你好世界" }
        )]
        [InlineData(
            "field1 = 'value with arabic: مرحبا بالعالم'",
            new[] { "field1", "=", "value with arabic: مرحبا بالعالم" }
        )]
        [InlineData(
            "field1 = 'value with russian: Привет мир'",
            new[] { "field1", "=", "value with russian: Привет мир" }
        )]
        public void Parse_UnicodeStrings_ReturnsExpectedTokens(
            string expression,
            string[] expectedTokens
        )
        {
            Expression.Expression result = ExpressionLexer.Parse(expression);

            List<ExpressionToken> actualTokens = result
                .Tokens.Where(t => t.Type != ExpressionTokenType.Whitespace)
                .ToList();
            Assert.Equal(expectedTokens.Length, actualTokens.Count);
            for (int i = 0; i < expectedTokens.Length; i++)
            {
                Assert.Equal(expectedTokens[i], actualTokens[i].Value);
            }
        }

        [Theory]
        [InlineData("field1 = 'value with\nnewline'")]
        [InlineData("field1 = 'value with\ttab'")]
        [InlineData("field1 = 'value with\rcarriage return'")]
        [InlineData("field1 = 'value with\\backslash'")]
        [InlineData("field1 = 'value with/forward slash'")]
        [InlineData("field1 = 'value with\bbackspace'")]
        [InlineData("field1 = 'value with\fform feed'")]
        [InlineData("field1 = 'value with\vvertical tab'")]
        public void Parse_StringsWithEscapeSequences_HandlesCorrectly(string expression)
        {
            Expression.Expression result = ExpressionLexer.Parse(expression);

            Assert.NotNull(result);
            Assert.NotEmpty(result.Tokens);
            List<ExpressionToken> nonWhitespaceTokens = result
                .Tokens.Where(t => t.Type != ExpressionTokenType.Whitespace)
                .ToList();
            Assert.Equal(3, nonWhitespaceTokens.Count); // field, operator, value
        }

        [Theory]
        [InlineData("(field1 = 'value1') AND (field2 = 'value2')")]
        [InlineData("((field1 = 'value1') AND (field2 = 'value2')) OR (field3 = 'value3')")]
        [InlineData("NOT (field1 = 'value1' AND field2 = 'value2')")]
        [InlineData("(field1 IN ('value1', 'value2')) AND (field3 LIKE 'pattern%')")]
        public void Parse_ComplexNestedExpressions_HandlesCorrectly(string expression)
        {
            Expression.Expression result = ExpressionLexer.Parse(expression);

            Assert.NotNull(result);
            Assert.NotEmpty(result.Tokens);

            // Verify that parentheses are properly tokenized
            List<ExpressionToken> parenTokens = result
                .Tokens.Where(t => t.Value == "(" || t.Value == ")")
                .ToList();

            int openParens = parenTokens.Count(t => t.Value == "(");
            int closeParens = parenTokens.Count(t => t.Value == ")");
            Assert.Equal(openParens, closeParens);
        }

        [Theory]
        [InlineData("field1   =   'value'   AND   field2   >   10")]
        [InlineData("field1\t=\t'value'\tAND\tfield2\t>\t10")]
        [InlineData("field1 \t = \t 'value' \t AND \t field2 \t > \t 10")]
        [InlineData("   field1 = 'value' AND field2 > 10   ")]
        public void Parse_ExpressionWithVariousWhitespace_HandlesCorrectly(string expression)
        {
            Expression.Expression result = ExpressionLexer.Parse(expression);

            Assert.NotNull(result);
            Assert.NotEmpty(result.Tokens);

            List<ExpressionToken> nonWhitespaceTokens = result
                .Tokens.Where(t => t.Type != ExpressionTokenType.Whitespace)
                .ToList();

            // Should have the expected non-whitespace tokens
            Assert.True(nonWhitespaceTokens.Count >= 7); // At least: field1, =, value, AND, field2, >, 10
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("\t\t\t")]
        [InlineData("\n\r\n")]
        public void Parse_EmptyOrWhitespaceOnlyExpressions_ReturnsEmptyTokenList(string expression)
        {
            Expression.Expression result = ExpressionLexer.Parse(expression);

            Assert.NotNull(result);
            Assert.Empty(result.Tokens);
        }

        [Theory]
        [InlineData("field1 = 'unterminated string")]
        [InlineData("field1 = \"unterminated string")]
        [InlineData("field1 = 'string with unescaped ' quote'")]
        [InlineData("field1 = \"string with unescaped \" quote\"")]
        public void Parse_MalformedStrings_ThrowsException(string expression)
        {
            Exception exception = Assert.ThrowsAny<Exception>(() =>
                ExpressionLexer.Parse(expression)
            );
            Assert.NotNull(exception);
        }

        [Theory]
        [InlineData("field1 = 123.45.67")] // Invalid number format
        [InlineData("field1 = 123E")] // Incomplete scientific notation
        [InlineData("field1 = 123E+")] // Incomplete scientific notation with sign
        [InlineData("field1 = .E5")] // Invalid decimal point
        public void Parse_InvalidNumberFormats_ThrowsException(string expression)
        {
            Exception exception = Assert.ThrowsAny<Exception>(() =>
                ExpressionLexer.Parse(expression)
            );
            Assert.NotNull(exception);
        }

        [Fact]
        public void Parse_ExpressionWithComments_HandlesCorrectly()
        {
            string expression = "field1 = 'value' /* this is a comment */ AND field2 > 10";

            Expression.Expression result = ExpressionLexer.Parse(expression);

            Assert.NotNull(result);
            Assert.NotEmpty(result.Tokens);

            // Comments should be either preserved as special tokens or stripped
            List<ExpressionToken> tokens = result.Tokens.ToList();
            bool hasCommentTokens = tokens.Any(t =>
                t.Value != null && t.Value.Contains("comment")
            );
            bool commentStripped = !tokens.Any(t => t.Value != null && t.Value.Contains("/*"));

            Assert.True(hasCommentTokens || commentStripped);
        }

        [Fact]
        public void Parse_VeryLongExpression_HandlesCorrectly()
        {
            System.Text.StringBuilder expressionBuilder = new System.Text.StringBuilder();
            expressionBuilder.Append("(");

            for (int i = 0; i < 100; i++)
            {
                if (i > 0)
                {
                    expressionBuilder.Append(" OR ");
                }
                expressionBuilder.Append($"field{i} = 'value{i}'");
            }

            expressionBuilder.Append(")");
            string longExpression = expressionBuilder.ToString();

            Expression.Expression result = ExpressionLexer.Parse(longExpression);

            Assert.NotNull(result);
            Assert.NotEmpty(result.Tokens);

            List<ExpressionToken> nonWhitespaceTokens = result
                .Tokens.Where(t => t.Type != ExpressionTokenType.Whitespace)
                .ToList();

            // Should have many tokens for the long expression
            Assert.True(nonWhitespaceTokens.Count > 300); // 100 * 3 tokens + OR operators + parentheses
        }

        [Fact]
        public void Parse_DeeplyNestedExpression_HandlesCorrectly()
        {
            System.Text.StringBuilder expressionBuilder = new System.Text.StringBuilder();

            for (int i = 0; i < 20; i++)
            {
                expressionBuilder.Append("(");
            }

            expressionBuilder.Append("field1 = 'value'");

            for (int i = 0; i < 20; i++)
            {
                expressionBuilder.Append(" AND field2 > 10)");
            }

            string deepExpression = expressionBuilder.ToString();

            Expression.Expression result = ExpressionLexer.Parse(deepExpression);

            Assert.NotNull(result);
            Assert.NotEmpty(result.Tokens);

            List<ExpressionToken> parenTokens = result
                .Tokens.Where(t => t.Value == "(" || t.Value == ")")
                .ToList();

            int openParens = parenTokens.Count(t => t.Value == "(");
            int closeParens = parenTokens.Count(t => t.Value == ")");
            Assert.Equal(20, openParens);
            Assert.Equal(20, closeParens);
        }
    }

    /// <summary>
    /// Advanced tests for merge field lexing with comprehensive edge cases
    /// </summary>
    public class AdvancedMergeFieldLexerTests
    {
        [Theory]
        [InlineData("«FirstName\\* UPPER»", "FirstName", "\\* UPPER")]
        [InlineData("«LastName\\* Lower»", "LastName", "\\* Lower")]
        [InlineData("«Amount\\# \"$#,##0.00\"»", "Amount", "\\# \"$#,##0.00\"")]
        [InlineData("«Date\\@ \"MMMM d, yyyy\"»", "Date", "\\@ \"MMMM d, yyyy\"")]
        [InlineData("«Field\\* Caps»", "Field", "\\* Caps")]
        [InlineData("«Field\\* FirstCap»", "Field", "\\* FirstCap")]
        [InlineData("«Field\\* Arabic»", "Field", "\\* Arabic")]
        [InlineData("«Field\\* Roman»", "Field", "\\* Roman")]
        [InlineData("«Field\\* Ordinal»", "Field", "\\* Ordinal")]
        [InlineData("«Field\\* CardText»", "Field", "\\* CardText")]
        public void ParseMergeField_WithAdvancedFormattingSwitches_ReturnsCorrectPlaceholder(
            string placeholderText,
            string expectedFieldName,
            string expectedSwitch
        )
        {
            MergeFieldPlaceholder result = MergeFieldLexer.ParseMergeField(placeholderText);

            Assert.Equal(placeholderText, result.RawText);
            Assert.Equal(expectedFieldName, result.FieldName);
            Assert.Equal(expectedSwitch, result.FormattingSwitch);
            Assert.True(result.IsValid);
        }

        [Theory]
        [InlineData("«Field_Name_With_Underscores»", "Field_Name_With_Underscores")]
        [InlineData("«Field-Name-With-Hyphens»", "Field-Name-With-Hyphens")]
        [InlineData("«Field.Name.With.Dots»", "Field.Name.With.Dots")]
        [InlineData("«Field$Name$With$Dollars»", "Field$Name$With$Dollars")]
        [InlineData("«Field@Domain.Com»", "Field@Domain.Com")]
        [InlineData("«Field123WithNumbers»", "Field123WithNumbers")]
        [InlineData("«123FieldStartingWithNumber»", "123FieldStartingWithNumber")]
        public void ParseMergeField_WithComplexFieldNames_ReturnsCorrectPlaceholder(
            string placeholderText,
            string expectedFieldName
        )
        {
            MergeFieldPlaceholder result = MergeFieldLexer.ParseMergeField(placeholderText);

            Assert.Equal(placeholderText, result.RawText);
            Assert.Equal(expectedFieldName, result.FieldName);
            Assert.True(result.IsValid);
        }

        [Theory]
        [InlineData(
            "«FieldName\\* UPPER\\# \"$#,##0.00\"»",
            "FieldName",
            "\\* UPPER\\# \"$#,##0.00\""
        )]
        [InlineData("«Date\\@ \"MMMM d, yyyy\"\\* CAPS»", "Date", "\\@ \"MMMM d, yyyy\"\\* CAPS")]
        [InlineData(
            "«Amount\\# \"#,##0.00\"\\* MERGEFORMAT»",
            "Amount",
            "\\# \"#,##0.00\"\\* MERGEFORMAT"
        )]
        public void ParseMergeField_WithMultipleFormattingSwitches_ReturnsCorrectPlaceholder(
            string placeholderText,
            string expectedFieldName,
            string expectedSwitch
        )
        {
            MergeFieldPlaceholder result = MergeFieldLexer.ParseMergeField(placeholderText);

            Assert.Equal(placeholderText, result.RawText);
            Assert.Equal(expectedFieldName, result.FieldName);
            Assert.Equal(expectedSwitch, result.FormattingSwitch);
            Assert.True(result.IsValid);
        }

        [Theory]
        [InlineData("«FieldNameWithUnicode_αβγδε»", "FieldNameWithUnicode_αβγδε")]
        [InlineData("«字段名称»", "字段名称")]
        [InlineData("«اسم_الحقل»", "اسم_الحقل")]
        [InlineData("«имя_поля»", "имя_поля")]
        [InlineData("«フィールド名»", "フィールド名")]
        public void ParseMergeField_WithUnicodeFieldNames_ReturnsCorrectPlaceholder(
            string placeholderText,
            string expectedFieldName
        )
        {
            MergeFieldPlaceholder result = MergeFieldLexer.ParseMergeField(placeholderText);

            Assert.Equal(placeholderText, result.RawText);
            Assert.Equal(expectedFieldName, result.FieldName);
            Assert.True(result.IsValid);
        }

        [Theory]
        [InlineData(
            "Dear «Title» «FirstName» «LastName»,\n\nThank you for your order of «Amount».\n\nBest regards,\nThe Team"
        )]
        [InlineData("Address:\n«Address1»\n«Address2»\n«City», «State» «ZipCode»\n«Country»")]
        [InlineData(
            "Order Details:\n- Product: «ProductName»\n- Quantity: «Quantity»\n- Price: «Price»\n- Total: «Total»"
        )]
        public void ExtractMergeFieldNames_FromComplexTemplates_ReturnsAllFieldNames(
            string template
        )
        {
            List<string> result = MergeFieldLexer.ExtractMergeFieldNames(template);

            Assert.NotNull(result);
            Assert.NotEmpty(result);

            // Verify that all fields in the template are extracted
            int expectedFieldCount = template.Count(c => c == '«');
            Assert.Equal(expectedFieldCount, result.Distinct().Count());

            // Verify uniqueness
            Assert.Equal(result.Count, result.Distinct().Count());
        }

        [Theory]
        [InlineData("«First Name»", "First Name")] // Space in name
        [InlineData("«  FirstName  »", "FirstName")] // Extra spaces
        [InlineData("«\tFirstName\t»", "FirstName")] // Tabs
        [InlineData("«\nFirstName\n»", "FirstName")] // Newlines
        public void ParseMergeField_WithWhitespaceVariations_HandlesCorrectly(
            string placeholderText,
            string expectedFieldName
        )
        {
            MergeFieldPlaceholder result = MergeFieldLexer.ParseMergeField(placeholderText);

            Assert.Equal(expectedFieldName, result.FieldName);
            Assert.True(result.IsValid);
        }

        [Theory]
        [InlineData("«»")] // Empty field name
        [InlineData("«   »")] // Whitespace only
        [InlineData("«\\* UPPER»")] // Switch without field name
        [InlineData("FirstName")] // Missing guillemets
        [InlineData("«FirstName")] // Missing closing guillemet
        [InlineData("FirstName»")] // Missing opening guillemet
        public void ParseMergeField_WithInvalidFormats_ReturnsInvalidPlaceholder(
            string placeholderText
        )
        {
            MergeFieldPlaceholder result = MergeFieldLexer.ParseMergeField(placeholderText);

            Assert.False(result.IsValid);
        }

        [Fact]
        public void ParseAddressBlockTemplate_WithNestedMergeFields_ParsesCorrectly()
        {
            string template =
                @"«IF «Title»<>""""«Title»"""" »«FirstName» «LastName»\n«IF «Address2»<>""""«Address1»\n«Address2»«ELSE»«Address1»»\n«City», «State» «ZipCode»";

            AddressBlockTemplate result = MergeFieldLexer.ParseAddressBlockTemplate(template);

            Assert.Equal(template, result.RawTemplate);
            Assert.NotEmpty(result.Placeholders);

            // Should extract all unique field names, including nested ones
            List<string> fieldNames = result.Placeholders.Select(p => p.FieldName).ToList();
            Assert.Contains("Title", fieldNames);
            Assert.Contains("FirstName", fieldNames);
            Assert.Contains("LastName", fieldNames);
            Assert.Contains("Address1", fieldNames);
            Assert.Contains("Address2", fieldNames);
            Assert.Contains("City", fieldNames);
            Assert.Contains("State", fieldNames);
            Assert.Contains("ZipCode", fieldNames);
        }

        [Theory]
        [InlineData("1025", LanguageIdentifier.ArabicSaudiArabia)]
        [InlineData("1028", LanguageIdentifier.ChineseTraditional)]
        [InlineData("1041", LanguageIdentifier.Japanese)]
        [InlineData("1042", LanguageIdentifier.Korean)]
        [InlineData("1049", LanguageIdentifier.Russian)]
        [InlineData("ar", LanguageIdentifier.ArabicSaudiArabia)]
        [InlineData("zh-TW", LanguageIdentifier.ChineseTraditional)]
        [InlineData("ja", LanguageIdentifier.Japanese)]
        [InlineData("ko", LanguageIdentifier.Korean)]
        [InlineData("ru", LanguageIdentifier.Russian)]
        public void ParseLanguageId_WithAdditionalLanguages_ReturnsCorrectLanguageIdentifier(
            string input,
            LanguageIdentifier expected
        )
        {
            LanguageIdentifier? result = MergeFieldLexer.ParseLanguageId(input);

            Assert.NotNull(result);
            Assert.Equal(expected, result.Value);
        }

        [Theory]
        [InlineData("zh-CN", LanguageIdentifier.ChineseSimplified)]
        [InlineData("pt-BR", LanguageIdentifier.PortugueseBrazil)]
        [InlineData("es-MX", LanguageIdentifier.SpanishMexico)]
        [InlineData("en-GB", LanguageIdentifier.EnglishUK)]
        [InlineData("en-AU", LanguageIdentifier.EnglishAustralia)]
        public void ParseLanguageId_WithRegionalVariants_ReturnsCorrectLanguageIdentifier(
            string input,
            LanguageIdentifier expected
        )
        {
            LanguageIdentifier? result = MergeFieldLexer.ParseLanguageId(input);

            Assert.NotNull(result);
            Assert.Equal(expected, result.Value);
        }

        [Fact]
        public void FormatMergeFieldWithSwitch_WithComplexFormatting_ReturnsCorrectFormat()
        {
            string fieldName = "Amount";
            string formattingSwitch = @"# ""$#,##0.00_);($#,##0.00)""";

            string result = MergeFieldLexer.FormatMergeFieldWithSwitch(fieldName, formattingSwitch);

            Assert.Equal($"«{fieldName}\\{formattingSwitch}»", result);
        }

        [Fact]
        public void ExtractMergeFieldNames_WithMalformedFields_SkipsInvalidFields()
        {
            string template =
                "Valid: «FirstName» Invalid: «» Another valid: «LastName» Invalid: «   »";

            List<string> result = MergeFieldLexer.ExtractMergeFieldNames(template);

            Assert.Equal(2, result.Count);
            Assert.Contains("FirstName", result);
            Assert.Contains("LastName", result);
        }
    }

    /// <summary>
    /// Advanced tests for ODBC connection lexing with comprehensive edge cases
    /// </summary>
    public class AdvancedODBCConnectionLexerTests
    {
        [Theory]
        [InlineData("DSN=TestDSN;UID=username;PWD=password;DATABASE=testdb")]
        [InlineData("DRIVER={SQL Server};SERVER=localhost;DATABASE=testdb;UID=sa;PWD=password")]
        [InlineData(
            "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\test.xlsx;Extended Properties=\"Excel 12.0 Xml;HDR=YES\""
        )]
        [InlineData("DRIVER={Microsoft Access Driver (*.mdb, *.accdb)};DBQ=C:\\test.accdb;")]
        public void Parse_ComplexConnectionStrings_ParsesSuccessfully(string connectionString)
        {
            System.Data.Odbc.OdbcConnectionStringBuilder? result = ODBCConnectionLexer.Parse(
                connectionString
            );

            Assert.NotNull(result);
            Assert.False(string.IsNullOrEmpty(result.ConnectionString));
            Assert.True(result.Keys.Count > 0);
        }

        [Theory]
        [InlineData("DSN=\"Data Source Name\";UID=\"user name\";PWD=\"pass word\"")]
        [InlineData("DRIVER={SQL Server};SERVER=\"server name\";DATABASE=\"database name\"")]
        [InlineData(
            "Provider='Microsoft.Jet.OLEDB.4.0';Data Source='C:\\My Documents\\database.mdb'"
        )]
        public void Parse_ConnectionStringsWithQuotedValues_HandlesQuotesCorrectly(
            string connectionString
        )
        {
            System.Data.Odbc.OdbcConnectionStringBuilder? result = ODBCConnectionLexer.Parse(
                connectionString
            );

            Assert.NotNull(result);
            Assert.False(string.IsNullOrEmpty(result.ConnectionString));

            // Verify that quoted values are handled properly
            foreach (object key in result.Keys)
            {
                string keyStr = key.ToString() ?? string.Empty;
                if (result.TryGetValue(keyStr, out object? value))
                {
                    string valueStr = value?.ToString() ?? string.Empty;
                    // Values should not contain surrounding quotes
                    Assert.DoesNotMatch("^['\"].*['\"]$", valueStr);
                }
            }
        }

        [Theory]
        [InlineData("DSN=TestDSN;UID=user;PWD=p@ssw0rd!#$%")]
        [InlineData("DRIVER={SQL Server};SERVER=server\\instance;DATABASE=test-db")]
        [InlineData("DBQ=C:\\Program Files\\Database\\test.mdb;PWD=password123!")]
        [InlineData("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\\\\server\\share\\database.mdb")]
        public void Parse_ConnectionStringsWithSpecialCharacters_HandlesCorrectly(
            string connectionString
        )
        {
            System.Data.Odbc.OdbcConnectionStringBuilder? result = ODBCConnectionLexer.Parse(
                connectionString
            );

            Assert.NotNull(result);
            Assert.False(string.IsNullOrEmpty(result.ConnectionString));
            Assert.True(result.Keys.Count > 0);
        }

        [Theory]
        [InlineData("Trusted_Connection=yes;Integrated Security=SSPI")]
        [InlineData("Persist Security Info=false;Pooling=true")]
        [InlineData("Connection Timeout=30;Command Timeout=60")]
        [InlineData("MultipleActiveResultSets=true;Application Name=MyApp")]
        public void Parse_ConnectionStringsWithBooleanAndNumericValues_HandlesCorrectly(
            string connectionString
        )
        {
            System.Data.Odbc.OdbcConnectionStringBuilder? result = ODBCConnectionLexer.Parse(
                connectionString
            );

            Assert.NotNull(result);
            Assert.False(string.IsNullOrEmpty(result.ConnectionString));
            Assert.True(result.Keys.Count > 0);
        }

        [Theory]
        [InlineData("DSN=TestDSN ; UID = username ; PWD = password")]
        [InlineData("DRIVER = {SQL Server} ; SERVER = localhost ; DATABASE = testdb")]
        [InlineData("   DSN   =   TestDSN   ;   UID   =   username   ")]
        public void Parse_ConnectionStringsWithExtraWhitespace_HandlesCorrectly(
            string connectionString
        )
        {
            System.Data.Odbc.OdbcConnectionStringBuilder? result = ODBCConnectionLexer.Parse(
                connectionString
            );

            Assert.NotNull(result);
            Assert.False(string.IsNullOrEmpty(result.ConnectionString));
            Assert.True(result.Keys.Count > 0);
        }

        [Theory]
        [InlineData("dsn=testdsn;uid=username;pwd=password")]
        [InlineData("DRIVER={sql server};SERVER=localhost;database=testdb")]
        [InlineData("Provider=microsoft.jet.oledb.4.0;data source=test.mdb")]
        public void Parse_ConnectionStringsWithMixedCase_HandlesCorrectly(string connectionString)
        {
            System.Data.Odbc.OdbcConnectionStringBuilder? result = ODBCConnectionLexer.Parse(
                connectionString
            );

            Assert.NotNull(result);
            Assert.False(string.IsNullOrEmpty(result.ConnectionString));
            Assert.True(result.Keys.Count > 0);
        }

        [Theory]
        [InlineData("DSN=TestDSN;;")] // Extra semicolon
        [InlineData(";DSN=TestDSN;UID=username")] // Leading semicolon
        [InlineData("DSN=TestDSN;UID=username;")] // Trailing semicolon
        [InlineData("DSN=TestDSN;;UID=username")] // Double semicolon
        public void Parse_ConnectionStringsWithExtraSemicolons_HandlesCorrectly(
            string connectionString
        )
        {
            System.Data.Odbc.OdbcConnectionStringBuilder? result = ODBCConnectionLexer.Parse(
                connectionString
            );

            Assert.NotNull(result);
            Assert.False(string.IsNullOrEmpty(result.ConnectionString));
        }

        [Theory]
        [InlineData("DSN=")] // Empty value
        [InlineData("=TestDSN")] // Empty key
        [InlineData("DSN")] // Missing equals sign
        [InlineData("DSN=TestDSN;UID")] // Missing value for UID
        public void Parse_MalformedConnectionStrings_HandlesMalformedParts(string connectionString)
        {
            System.Data.Odbc.OdbcConnectionStringBuilder? result = ODBCConnectionLexer.Parse(
                connectionString
            );

            if (result != null)
            {
                Assert.NotNull(result.ConnectionString);
            }
            // If result is null, that's also acceptable for malformed input
        }

        [Fact]
        public void Parse_VeryLongConnectionString_HandlesCorrectly()
        {
            System.Text.StringBuilder connectionBuilder = new System.Text.StringBuilder();
            connectionBuilder.Append("DSN=TestDSN;UID=username;PWD=password");

            for (int i = 0; i < 100; i++)
            {
                connectionBuilder.Append($";CustomProperty{i}=Value{i}");
            }

            string longConnectionString = connectionBuilder.ToString();

            System.Data.Odbc.OdbcConnectionStringBuilder? result = ODBCConnectionLexer.Parse(
                longConnectionString
            );

            Assert.NotNull(result);
            Assert.False(string.IsNullOrEmpty(result.ConnectionString));
            Assert.True(result.Keys.Count >= 100); // Should have at least 100 custom properties plus standard ones
        }

        [Theory]
        [InlineData("DSN=数据源名称;UID=用户名;PWD=密码")] // Chinese
        [InlineData("DSN=مصدر_البيانات;UID=اسم_المستخدم;PWD=كلمة_المرور")] // Arabic
        [InlineData("DSN=источник_данных;UID=имя_пользователя;PWD=пароль")] // Russian
        public void Parse_ConnectionStringsWithUnicodeValues_HandlesCorrectly(
            string connectionString
        )
        {
            System.Data.Odbc.OdbcConnectionStringBuilder? result = ODBCConnectionLexer.Parse(
                connectionString
            );

            Assert.NotNull(result);
            Assert.False(string.IsNullOrEmpty(result.ConnectionString));
            Assert.True(result.Keys.Count > 0);
        }

        [Fact]
        public void Parse_ConnectionStringWithAllComponentTypes_HandlesCorrectly()
        {
            string connectionString =
                "DSN=TestDSN;DRIVER={SQL Server};Provider=MSOLEDBSQL;Data Source=server;Initial Catalog=database;UID=user;PWD=password;Integrated Security=SSPI;Server=localhost;Database=testdb";

            System.Data.Odbc.OdbcConnectionStringBuilder? result = ODBCConnectionLexer.Parse(
                connectionString
            );

            Assert.NotNull(result);
            Assert.False(string.IsNullOrEmpty(result.ConnectionString));

            // Verify that different component types are recognized
            Assert.True(result.ContainsKey("DSN") || result.ContainsKey("dsn"));
            Assert.True(result.ContainsKey("DRIVER") || result.ContainsKey("driver"));
            Assert.True(result.ContainsKey("UID") || result.ContainsKey("uid"));
            Assert.True(result.ContainsKey("PWD") || result.ContainsKey("pwd"));
        }
    }
}

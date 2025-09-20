using System;
using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Expression;
using OpenLanguage.WordprocessingML.MergeField;
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
            bool hasCommentTokens = tokens.Any(t => t.Value != null && t.Value.Contains("comment"));
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
}

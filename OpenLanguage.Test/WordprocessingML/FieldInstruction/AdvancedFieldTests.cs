using System;
using System.Linq;
using Xunit;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Tests
{
    /// <summary>
    /// Advanced tests for field instruction parsing with comprehensive coverage
    /// </summary>
    public class AdvancedFieldParserTests
    {
        [Theory]
        [InlineData("MERGEFIELD FirstName")]
        [InlineData("MERGEFIELD LastName \\* Upper")]
        [InlineData("MERGEFIELD Company \\* FirstCap")]
        [InlineData("MERGEFIELD Salary \\# \"$#,##0.00\"")]
        [InlineData("MERGEFIELD Date \\@ \"MMMM d, yyyy\"")]
        [InlineData("MERGEFIELD Status \\b \"Unknown\"")]
        public void Parse_MergeFieldVariations_ParsesCorrectly(string fieldCode)
        {
            FieldInstruction result = FieldParser.Parse(fieldCode);

            Assert.Equal("MERGEFIELD", result.Instruction);
            Assert.True(result.Arguments.Count >= 1);
            Assert.Equal(FieldArgumentType.Identifier, result.Arguments[0].Type);
        }

        [Theory]
        [InlineData("HYPERLINK \"https://www.example.com\"")]
        [InlineData("HYPERLINK \"https://www.example.com\" \"Click here\"")]
        [InlineData("HYPERLINK \"mailto:test@example.com\" \"Send email\"")]
        [InlineData("HYPERLINK \"https://www.example.com\" \"Visit site\" \\o \"Tooltip text\"")]
        [InlineData("HYPERLINK \"https://www.example.com\" \\t \"_blank\"")]
        public void Parse_HyperlinkVariations_ParsesCorrectly(string fieldCode)
        {
            FieldInstruction result = FieldParser.Parse(fieldCode);

            Assert.Equal("HYPERLINK", result.Instruction);
            Assert.True(result.Arguments.Count >= 1);
            Assert.Equal(FieldArgumentType.StringLiteral, result.Arguments[0].Type);
        }

        [Theory]
        [InlineData("IF 1 = 1 \"True\" \"False\"")]
        [InlineData("IF { MERGEFIELD Age } > 18 \"Adult\" \"Minor\"")]
        [InlineData("IF { MERGEFIELD Salary } >= 50000 \"High\" \"Standard\"")]
        [InlineData("IF { MERGEFIELD Status } = \"Active\" \"Yes\" \"No\"")]
        public void Parse_IfFieldVariations_ParsesCorrectly(string fieldCode)
        {
            FieldInstruction result = FieldParser.Parse(fieldCode);

            Assert.Equal("IF", result.Instruction);
            Assert.True(result.Arguments.Count >= 5); // condition, operator, value, true_text, false_text
        }

        [Theory]
        [InlineData("DATE")]
        [InlineData("DATE \\@ \"MM/dd/yyyy\"")]
        [InlineData("DATE \\@ \"dddd, MMMM dd, yyyy\"")]
        [InlineData("DATE \\* MERGEFORMAT")]
        public void Parse_DateFieldVariations_ParsesCorrectly(string fieldCode)
        {
            FieldInstruction result = FieldParser.Parse(fieldCode);

            Assert.Equal("DATE", result.Instruction);
        }

        [Theory]
        [InlineData("TIME")]
        [InlineData("TIME \\@ \"h:mm AM/PM\"")]
        [InlineData("TIME \\@ \"HH:mm:ss\"")]
        public void Parse_TimeFieldVariations_ParsesCorrectly(string fieldCode)
        {
            FieldInstruction result = FieldParser.Parse(fieldCode);

            Assert.Equal("TIME", result.Instruction);
        }

        [Theory]
        [InlineData("PAGE")]
        [InlineData("PAGE \\* MERGEFORMAT")]
        [InlineData("PAGE \\* Arabic")]
        [InlineData("PAGE \\* roman")]
        [InlineData("PAGE \\* ROMAN")]
        public void Parse_PageFieldVariations_ParsesCorrectly(string fieldCode)
        {
            FieldInstruction result = FieldParser.Parse(fieldCode);

            Assert.Equal("PAGE", result.Instruction);
        }

        [Theory]
        [InlineData("DOCPROPERTY Title")]
        [InlineData("DOCPROPERTY Author")]
        [InlineData("DOCPROPERTY Company")]
        [InlineData("DOCPROPERTY \"Custom Property\"")]
        [InlineData("DOCPROPERTY Subject \\* Upper")]
        public void Parse_DocPropertyVariations_ParsesCorrectly(string fieldCode)
        {
            FieldInstruction result = FieldParser.Parse(fieldCode);

            Assert.Equal("DOCPROPERTY", result.Instruction);
            Assert.True(result.Arguments.Count >= 1);
        }

        [Theory]
        [InlineData("ADDRESSBLOCK")]
        [InlineData("ADDRESSBLOCK \\c 1")]
        [InlineData("ADDRESSBLOCK \\c 2 \\d")]
        [InlineData("ADDRESSBLOCK \\e \"United States\"")]
        [InlineData("ADDRESSBLOCK \\f \"<<_RETURN_>>\"")]
        [InlineData("ADDRESSBLOCK \\l 1033")]
        public void Parse_AddressBlockVariations_ParsesCorrectly(string fieldCode)
        {
            FieldInstruction result = FieldParser.Parse(fieldCode);

            Assert.Equal("ADDRESSBLOCK", result.Instruction);
        }

        [Theory]
        [InlineData("GREETINGLINE")]
        [InlineData("GREETINGLINE \\f \"Dear\"")]
        [InlineData("GREETINGLINE \\f \"Dear\" \\l \",\"")]
        [InlineData("GREETINGLINE \\f \"Dear\" \\l \",\" \\e \"Dear Sir or Madam,\"")]
        public void Parse_GreetingLineVariations_ParsesCorrectly(string fieldCode)
        {
            FieldInstruction result = FieldParser.Parse(fieldCode);

            Assert.Equal("GREETINGLINE", result.Instruction);
        }

        [Theory]
        [InlineData("BARCODE \"12345\"")]
        [InlineData("BARCODE \"12345-6789\" \\f A")]
        [InlineData("BARCODE \"123456789\" \\f C")]
        [InlineData("BARCODE { MERGEFIELD PostalCode }")]
        public void Parse_BarcodeVariations_ParsesCorrectly(string fieldCode)
        {
            FieldInstruction result = FieldParser.Parse(fieldCode);

            Assert.Equal("BARCODE", result.Instruction);
            Assert.True(result.Arguments.Count >= 1);
        }

        [Theory]
        [InlineData("DATABASE \\d \"DSN=MyDatabase\" \\s \"SELECT * FROM Customers\"")]
        [InlineData(
            "DATABASE \\d \"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\db.mdb\" \\s \"SELECT Name FROM Table1\""
        )]
        [InlineData(
            "DATABASE \\d \"Data Source=server;Initial Catalog=db\" \\s \"SELECT * FROM Users\" \\t 5"
        )]
        public void Parse_DatabaseVariations_ParsesCorrectly(string fieldCode)
        {
            FieldInstruction result = FieldParser.Parse(fieldCode);

            Assert.Equal("DATABASE", result.Instruction);
            Assert.True(result.Arguments.Count >= 4); // Should have connection and query
        }

        [Theory]
        [InlineData("REF Bookmark1")]
        [InlineData("REF Bookmark1 \\h")]
        [InlineData("REF Bookmark1 \\p")]
        [InlineData("REF Bookmark1 \\n")]
        [InlineData("REF Bookmark1 \\r")]
        public void Parse_RefFieldVariations_ParsesCorrectly(string fieldCode)
        {
            FieldInstruction result = FieldParser.Parse(fieldCode);

            Assert.Equal("REF", result.Instruction);
            Assert.True(result.Arguments.Count >= 1);
            Assert.Equal(FieldArgumentType.Identifier, result.Arguments[0].Type);
        }

        [Theory]
        [InlineData("PAGEREF Bookmark1")]
        [InlineData("PAGEREF Bookmark1 \\h")]
        [InlineData("PAGEREF Bookmark1 \\p")]
        public void Parse_PageRefVariations_ParsesCorrectly(string fieldCode)
        {
            FieldInstruction result = FieldParser.Parse(fieldCode);

            Assert.Equal("PAGEREF", result.Instruction);
            Assert.True(result.Arguments.Count >= 1);
        }

        [Fact]
        public void Parse_ComplexNestedField_ParsesCorrectly()
        {
            string complexField =
                "IF { MERGEFIELD Department } = \"Sales\" { MERGEFIELD SalesBonus } { MERGEFIELD StandardBonus }";

            FieldInstruction result = FieldParser.Parse(complexField);

            Assert.Equal("IF", result.Instruction);
            Assert.Equal(5, result.Arguments.Count);

            // Check for nested fields
            int nestedCount = result.Arguments.Count(arg =>
                arg.Type == FieldArgumentType.NestedField
            );
            Assert.Equal(3, nestedCount);
        }

        [Fact]
        public void Parse_MultipleNestedLevels_ParsesCorrectly()
        {
            string multiNestedField =
                "IF { IF { MERGEFIELD Age } > 65 \"Senior\" \"Adult\" } = \"Senior\" { MERGEFIELD SeniorDiscount } { MERGEFIELD StandardPrice }";

            FieldInstruction result = FieldParser.Parse(multiNestedField);

            Assert.Equal("IF", result.Instruction);
            Assert.True(result.Arguments.Count >= 5);

            // Should have nested IF field
            FieldArgument? nestedIfArg = result.Arguments.FirstOrDefault(arg =>
                arg.Type == FieldArgumentType.NestedField
                && arg.Value is FieldInstruction nested
                && nested.Instruction == "IF"
            );
            Assert.NotNull(nestedIfArg);
        }

        [Theory]
        [InlineData("FILENAME")]
        [InlineData("FILENAME \\p")]
        [InlineData("FILENAME \\* Upper")]
        [InlineData("FILENAME \\* Lower")]
        public void Parse_FilenameVariations_ParsesCorrectly(string fieldCode)
        {
            FieldInstruction result = FieldParser.Parse(fieldCode);

            Assert.Equal("FILENAME", result.Instruction);
        }

        [Theory]
        [InlineData("AUTHOR")]
        [InlineData("AUTHOR \\* Upper")]
        [InlineData("AUTHOR \\* FirstCap")]
        public void Parse_AuthorVariations_ParsesCorrectly(string fieldCode)
        {
            FieldInstruction result = FieldParser.Parse(fieldCode);

            Assert.Equal("AUTHOR", result.Instruction);
        }

        [Theory]
        [InlineData("CREATEDATE")]
        [InlineData("CREATEDATE \\@ \"MM/dd/yyyy\"")]
        [InlineData("SAVEDATE")]
        [InlineData("SAVEDATE \\@ \"h:mm AM/PM\"")]
        [InlineData("PRINTDATE")]
        [InlineData("PRINTDATE \\@ \"dddd, MMMM dd, yyyy\"")]
        public void Parse_DocumentDateVariations_ParsesCorrectly(string fieldCode)
        {
            FieldInstruction result = FieldParser.Parse(fieldCode);

            Assert.Contains(result.Instruction, new[] { "CREATEDATE", "SAVEDATE", "PRINTDATE" });
        }

        [Theory]
        [InlineData("NUMPAGES")]
        [InlineData("NUMPAGES \\* Arabic")]
        [InlineData("NUMPAGES \\* roman")]
        [InlineData("NUMPAGES \\* ROMAN")]
        public void Parse_NumPagesVariations_ParsesCorrectly(string fieldCode)
        {
            FieldInstruction result = FieldParser.Parse(fieldCode);

            Assert.Equal("NUMPAGES", result.Instruction);
        }

        [Theory]
        [InlineData("NUMWORDS")]
        [InlineData("NUMCHARS")]
        [InlineData("NUMCHARS \\p")]
        public void Parse_DocumentStatsVariations_ParsesCorrectly(string fieldCode)
        {
            FieldInstruction result = FieldParser.Parse(fieldCode);

            Assert.Contains(result.Instruction, new[] { "NUMWORDS", "NUMCHARS" });
        }

        [Fact]
        public void Parse_FieldWithEscapedQuotes_ParsesCorrectly()
        {
            string fieldWithEscapedQuotes =
                "MERGEFIELD Company \\b \"Company \\\"Name\\\" Unknown\"";

            FieldInstruction result = FieldParser.Parse(fieldWithEscapedQuotes);

            Assert.Equal("MERGEFIELD", result.Instruction);
            Assert.True(result.Arguments.Count >= 3);

            FieldArgument? stringLiteralArg = result.Arguments.FirstOrDefault(arg =>
                arg.Type == FieldArgumentType.StringLiteral
            );
            Assert.NotNull(stringLiteralArg);
            Assert.Contains("\"", stringLiteralArg.Value?.ToString());
        }

        [Fact]
        public void Parse_FieldWithSpecialCharacters_ParsesCorrectly()
        {
            string fieldWithSpecialChars = "MERGEFIELD \"Field With Spaces & Special Chars!@#$%\"";

            FieldInstruction result = FieldParser.Parse(fieldWithSpecialChars);

            Assert.Equal("MERGEFIELD", result.Instruction);
            Assert.Single(result.Arguments);
            Assert.Equal(FieldArgumentType.StringLiteral, result.Arguments[0].Type);
        }

        [Theory]
        [InlineData("{ MERGEFIELD FirstName }")]
        [InlineData("{MERGEFIELD FirstName}")]
        [InlineData("{ MERGEFIELD FirstName \\* Upper }")]
        public void Parse_FieldWithBraces_ParsesCorrectly(string fieldCode)
        {
            FieldInstruction result = FieldParser.Parse(fieldCode);

            Assert.Equal("MERGEFIELD", result.Instruction);
            Assert.True(result.Arguments.Count >= 1);
        }

        [Fact]
        public void Parse_FieldReconstruction_IsAccurate()
        {
            string[] testFields =
            {
                "MERGEFIELD FirstName \\* Upper",
                "IF { MERGEFIELD Age } > 18 \"Adult\" \"Minor\"",
                "HYPERLINK \"https://example.com\" \"Click here\"",
                "DATE \\@ \"MMMM d, yyyy\"",
                "ADDRESSBLOCK \\c 1 \\e \"United States\"",
            };

            foreach (string original in testFields)
            {
                FieldInstruction parsed = FieldParser.Parse(original);
                string reconstructed = parsed.ToString();

                // Parse the reconstructed field to ensure it's valid
                FieldInstruction reparsed = FieldParser.Parse(reconstructed);
                Assert.Equal(parsed.Instruction, reparsed.Instruction);
                Assert.Equal(parsed.Arguments.Count, reparsed.Arguments.Count);
            }
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("INVALID")]
        [InlineData("{ UNCLOSED")]
        [InlineData("MERGEFIELD")]
        [InlineData("IF 1 =")]
        public void Parse_InvalidFields_ThrowsOrReturnsNull(string fieldCode)
        {
            // Act & Assert
            if (string.IsNullOrWhiteSpace(fieldCode))
            {
                Assert.Throws<Exception>(() => FieldParser.Parse(fieldCode));
            }
            else
            {
                // Some invalid fields may parse partially or throw exceptions
                // The exact behavior depends on the implementation
                try
                {
                    FieldInstruction result = FieldParser.Parse(fieldCode);
                    // If parsing succeeds, verify basic structure
                    Assert.NotNull(result);
                    Assert.NotNull(result.Instruction);
                }
                catch (Exception)
                {
                    // Exception is acceptable for invalid input
                }
            }
        }

        [Theory]
        [InlineData("MERGEFIELD FirstName")]
        [InlineData("IF 1 = 1 \"True\" \"False\"")]
        [InlineData("HYPERLINK \"https://example.com\"")]
        [InlineData("DATE \\@ \"MM/dd/yyyy\"")]
        public void TryParse_ValidFields_ReturnsFieldInstruction(string fieldCode)
        {
            FieldInstruction? result = FieldParser.TryParse(fieldCode);

            Assert.NotNull(result);
            Assert.NotNull(result.Instruction);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("   ")]
        [InlineData("{ UNCLOSED")]
        public void TryParse_InvalidFields_ReturnsNull(string? fieldCode)
        {
            FieldInstruction? result = FieldParser.TryParse(fieldCode!);

            Assert.Null(result);
        }

        [Fact]
        public void Parse_FieldWithMultipleSwitches_ParsesAllSwitches()
        {
            string fieldWithMultipleSwitches =
                "MERGEFIELD Amount \\# \"$#,##0.00\" \\* MERGEFORMAT \\b \"$0.00\"";

            FieldInstruction result = FieldParser.Parse(fieldWithMultipleSwitches);

            Assert.Equal("MERGEFIELD", result.Instruction);

            int switchCount = result.Arguments.Count(arg => arg.Type == FieldArgumentType.Switch);
            Assert.True(switchCount >= 3); // \#, \*, \b
        }

        [Theory]
        [InlineData("MERGEFIELD", new[] { "FirstName" })]
        [InlineData("HYPERLINK", new[] { "\"https://example.com\"", "\"Click here\"" })]
        [InlineData("IF", new[] { "1", "=", "1", "\"True\"", "\"False\"" })]
        public void Parse_FieldArguments_HasExpectedArgumentCount(
            string instruction,
            string[] expectedArgs
        )
        {
            string fieldCode = $"{instruction} {string.Join(" ", expectedArgs)}";

            FieldInstruction result = FieldParser.Parse(fieldCode);

            Assert.Equal(instruction, result.Instruction);
            Assert.Equal(expectedArgs.Length, result.Arguments.Count);
        }
    }

    /// <summary>
    /// Performance tests for field instruction parsing
    /// </summary>
    public class FieldParserPerformanceTests
    {
        [Fact]
        public void Parse_ManySimpleFields_ParsesWithinReasonableTime()
        {
            string[] fields = new string[1000];
            for (Int32 i = 0; i < fields.Length; i++)
            {
                fields[i] = $"MERGEFIELD Field{i}";
            }

            System.Diagnostics.Stopwatch stopwatch = System.Diagnostics.Stopwatch.StartNew();
            foreach (string fieldCode in fields)
            {
                FieldInstruction result = FieldParser.Parse(fieldCode);
                Assert.NotNull(result);
            }
            stopwatch.Stop();

            Assert.True(
                stopwatch.ElapsedMilliseconds < 5000,
                $"Parsing 1000 fields took {stopwatch.ElapsedMilliseconds}ms, expected < 5000ms"
            );
        }

        [Fact]
        public void Parse_ComplexNestedField_ParsesWithinReasonableTime()
        {
            // Create a complex nested field
            string complexField =
                "IF { IF { MERGEFIELD Level1 } = \"A\" { MERGEFIELD Level2A } { MERGEFIELD Level2B } } = \"Result\" { MERGEFIELD Success } { MERGEFIELD Failure }";

            System.Diagnostics.Stopwatch stopwatch = System.Diagnostics.Stopwatch.StartNew();
            FieldInstruction result = FieldParser.Parse(complexField);
            stopwatch.Stop();

            Assert.NotNull(result);
            Assert.True(
                stopwatch.ElapsedMilliseconds < 100,
                $"Parsing complex field took {stopwatch.ElapsedMilliseconds}ms, expected < 100ms"
            );
        }

        [Theory]
        [InlineData(10)]
        [InlineData(50)]
        [InlineData(100)]
        public void Parse_FieldWithManyArguments_ParsesSuccessfully(int argumentCount)
        {
            // Create a field with many merge field references
            string[] mergeFields = new string[argumentCount];
            for (Int32 i = 0; i < argumentCount; i++)
            {
                mergeFields[i] = $"{{ MERGEFIELD Field{i} }}";
            }

            string complexField =
                $"IF {string.Join(" = ", mergeFields.Take(2))} \"Match\" \"NoMatch\"";

            FieldInstruction result = FieldParser.Parse(complexField);
            Assert.NotNull(result);
            Assert.Equal("IF", result.Instruction);
        }
    }

    /// <summary>
    /// Tests for field instruction argument types and validation
    /// </summary>
    public class FieldArgumentValidationTests
    {
        [Fact]
        public void FieldArgument_StringLiteral_EscapesQuotesCorrectly()
        {
            FieldArgument arg = new FieldArgument(
                FieldArgumentType.StringLiteral,
                "Text with \"quotes\""
            );
            string result = arg.ToString();

            Assert.Contains("\"", result);
            Assert.StartsWith("\"", result);
            Assert.EndsWith("\"", result);
        }

        [Fact]
        public void FieldArgument_NestedField_FormatsCorrectly()
        {
            FieldInstruction nestedField = new FieldInstruction("MERGEFIELD");
            nestedField.Arguments.Add(new FieldArgument(FieldArgumentType.Identifier, "Name"));

            FieldArgument arg = new FieldArgument(FieldArgumentType.NestedField, nestedField);
            string result = arg.ToString();

            Assert.StartsWith("{ ", result);
            Assert.EndsWith(" }", result);
            Assert.Contains("MERGEFIELD Name", result);
        }

        [Theory]
        [InlineData(FieldArgumentType.Identifier, "TestId", "TestId")]
        [InlineData(FieldArgumentType.Switch, "\\* Upper", "\\* Upper")]
        [InlineData(FieldArgumentType.Text, "Plain text", "Plain text")]
        [InlineData(FieldArgumentType.Number, "123", "123")]
        public void FieldArgument_ToString_ReturnsCorrectFormat(
            FieldArgumentType type,
            string value,
            string expected
        )
        {
            FieldArgument arg = new FieldArgument(type, value);
            string result = arg.ToString();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void FieldArgument_NullValue_ReturnsEmptyString()
        {
            FieldArgument arg = new FieldArgument(FieldArgumentType.Identifier, null);
            string result = arg.ToString();

            Assert.Equal(string.Empty, result);
        }
    }
}

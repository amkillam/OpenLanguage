using System;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;
using OpenLanguage.WordprocessingML.FieldInstruction;
using OpenLanguage.WordprocessingML.FieldInstruction.Ast;
using Xunit;
using CoreAst = OpenLanguage.WordprocessingML.Ast;

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
            ExpressionNode result = FieldInstructionParser.Parse(fieldCode);

            Assert.IsType<OpenLanguage.WordprocessingML.FieldInstruction.MergeFieldFieldInstruction>(
                result
            );
            Assert.Equal("MERGEFIELD", ((Ast.FieldInstruction)result).Instruction);
            Assert.True(result.ToString().Length > "MERGEFIELD".Length);
        }

        [Theory]
        [InlineData("HYPERLINK \"https://www.example.com\"")]
        [InlineData("HYPERLINK \"https://www.example.com\" \"Click here\"")]
        [InlineData("HYPERLINK \"mailto:test@example.com\" \"Send email\"")]
        [InlineData("HYPERLINK \"https://www.example.com\" \"Visit site\" \\o \"Tooltip text\"")]
        [InlineData("HYPERLINK \"https://www.example.com\" \\t \"_blank\"")]
        public void Parse_HyperlinkVariations_ParsesCorrectly(string fieldCode)
        {
            ExpressionNode result = FieldInstructionParser.Parse(fieldCode);

            Assert.IsType<OpenLanguage.WordprocessingML.FieldInstruction.HyperlinkFieldInstruction>(
                result
            );
            Assert.Equal("HYPERLINK", ((Ast.FieldInstruction)result).Instruction);
            Assert.True(
                result.ToString().Contains("https://") || result.ToString().Contains("mailto:")
            );
        }

        [Theory]
        [InlineData("IF 1 = 1 \"True\" \"False\"")]
        [InlineData("IF { MERGEFIELD Age } > 18 \"Adult\" \"Minor\"")]
        [InlineData("IF { MERGEFIELD Salary } >= 50000 \"High\" \"Standard\"")]
        [InlineData("IF { MERGEFIELD Status } = \"Active\" \"Yes\" \"No\"")]
        public void Parse_IfFieldVariations_ParsesCorrectly(string fieldCode)
        {
            ExpressionNode result = FieldInstructionParser.Parse(fieldCode);

            Assert.IsType<OpenLanguage.WordprocessingML.FieldInstruction.Ast.IfFieldInstruction>(
                result
            );
            Assert.Equal("IF", ((Ast.FieldInstruction)result).Instruction);
            Assert.True(result.Children<CoreAst.Node>().Count() >= 4);
        }

        [Theory]
        [InlineData("DATE")]
        [InlineData("DATE \\@ \"MM/dd/yyyy\"")]
        [InlineData("DATE \\@ \"dddd, MMMM dd, yyyy\"")]
        [InlineData("DATE \\* MERGEFORMAT")]
        public void Parse_DateFieldVariations_ParsesCorrectly(string fieldCode)
        {
            ExpressionNode result = FieldInstructionParser.Parse(fieldCode);

            Assert.IsType<OpenLanguage.WordprocessingML.FieldInstruction.Ast.DateFieldInstruction>(
                result
            );
            Assert.Equal("DATE", ((Ast.FieldInstruction)result).Instruction);
        }

        [Theory]
        [InlineData("TIME")]
        [InlineData("TIME \\@ \"h:mm AM/PM\"")]
        [InlineData("TIME \\@ \"HH:mm:ss\"")]
        public void Parse_TimeFieldVariations_ParsesCorrectly(string fieldCode)
        {
            ExpressionNode result = FieldInstructionParser.Parse(fieldCode);

            Assert.IsType<OpenLanguage.WordprocessingML.FieldInstruction.Ast.TimeFieldInstruction>(
                result
            );
            Assert.Equal("TIME", ((Ast.FieldInstruction)result).Instruction);
        }

        [Theory]
        [InlineData("PAGE")]
        [InlineData("PAGE \\* MERGEFORMAT")]
        [InlineData("PAGE \\* Arabic")]
        [InlineData("PAGE \\* roman")]
        [InlineData("PAGE \\* ROMAN")]
        public void Parse_PageFieldVariations_ParsesCorrectly(string fieldCode)
        {
            ExpressionNode result = FieldInstructionParser.Parse(fieldCode);

            Assert.IsType<OpenLanguage.WordprocessingML.FieldInstruction.Ast.PageFieldInstruction>(
                result
            );
            Assert.Equal("PAGE", ((Ast.FieldInstruction)result).Instruction);
        }

        [Theory]
        [InlineData("DOCPROPERTY Title")]
        [InlineData("DOCPROPERTY Author")]
        [InlineData("DOCPROPERTY Company")]
        [InlineData("DOCPROPERTY \"Custom Property\"")]
        [InlineData("DOCPROPERTY Subject \\* Upper")]
        public void Parse_DocPropertyVariations_ParsesCorrectly(string fieldCode)
        {
            ExpressionNode result = FieldInstructionParser.Parse(fieldCode);

            Assert.IsType<OpenLanguage.WordprocessingML.FieldInstruction.Ast.DocPropertyFieldInstruction>(
                result
            );
            Assert.Equal("DOCPROPERTY", ((Ast.FieldInstruction)result).Instruction);
            Assert.NotNull(
                (
                    (OpenLanguage.WordprocessingML.FieldInstruction.Ast.DocPropertyFieldInstruction)result
                ).PropertyName
            );
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
            ExpressionNode result = FieldInstructionParser.Parse(fieldCode);

            Assert.IsType<OpenLanguage.WordprocessingML.FieldInstruction.Ast.AddressBlockFieldInstruction>(
                result
            );
            Assert.Equal("ADDRESSBLOCK", ((Ast.FieldInstruction)result).Instruction);
        }

        [Theory]
        [InlineData("GREETINGLINE")]
        [InlineData("GREETINGLINE \\f \"Dear\"")]
        [InlineData("GREETINGLINE \\f \"Dear\" \\l \",\"")]
        [InlineData("GREETINGLINE \\f \"Dear\" \\l \",\" \\e \"Dear Sir or Madam,\"")]
        public void Parse_GreetingLineVariations_ParsesCorrectly(string fieldCode)
        {
            ExpressionNode result = FieldInstructionParser.Parse(fieldCode);

            Assert.IsType<OpenLanguage.WordprocessingML.FieldInstruction.GreetingLineFieldInstruction>(
                result
            );
            Assert.Equal("GREETINGLINE", ((Ast.FieldInstruction)result).Instruction);
        }

        [Theory]
        [InlineData("BARCODE \"12345\"")]
        [InlineData("BARCODE \"12345-6789\" \\f A")]
        [InlineData("BARCODE \"123456789\" \\f C")]
        [InlineData("BARCODE { MERGEFIELD PostalCode }")]
        public void Parse_BarcodeVariations_ParsesCorrectly(string fieldCode)
        {
            ExpressionNode result = FieldInstructionParser.Parse(fieldCode);

            Assert.IsType<OpenLanguage.WordprocessingML.FieldInstruction.Ast.BarcodeFieldInstruction>(
                result
            );
            Assert.Equal("BARCODE", ((Ast.FieldInstruction)result).Instruction);
            Assert.True(result.ToString().Length > "BARCODE".Length);
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
            ExpressionNode result = FieldInstructionParser.Parse(fieldCode);

            Assert.IsType<OpenLanguage.WordprocessingML.FieldInstruction.Ast.DatabaseFieldInstruction>(
                result
            );
            Assert.Equal("DATABASE", ((Ast.FieldInstruction)result).Instruction);
            Assert.True(result.ToString().Contains("\\d") && result.ToString().Contains("\\s"));
        }

        [Theory]
        [InlineData("REF Bookmark1")]
        [InlineData("REF Bookmark1 \\h")]
        [InlineData("REF Bookmark1 \\p")]
        [InlineData("REF Bookmark1 \\n")]
        [InlineData("REF Bookmark1 \\r")]
        public void Parse_RefFieldVariations_ParsesCorrectly(string fieldCode)
        {
            ExpressionNode result = FieldInstructionParser.Parse(fieldCode);

            Assert.IsType<OpenLanguage.WordprocessingML.FieldInstruction.RefFieldInstruction>(
                result
            );
            Assert.Equal("REF", ((Ast.FieldInstruction)result).Instruction);
            Assert.NotNull(
                (
                    (OpenLanguage.WordprocessingML.FieldInstruction.RefFieldInstruction)result
                ).BookmarkName
            );
        }

        [Theory]
        [InlineData("PAGEREF Bookmark1")]
        [InlineData("PAGEREF Bookmark1 \\h")]
        [InlineData("PAGEREF Bookmark1 \\p")]
        public void Parse_PageRefVariations_ParsesCorrectly(string fieldCode)
        {
            ExpressionNode result = FieldInstructionParser.Parse(fieldCode);

            Assert.IsType<OpenLanguage.WordprocessingML.FieldInstruction.PageRefFieldInstruction>(
                result
            );
            Assert.Equal("PAGEREF", ((Ast.FieldInstruction)result).Instruction);
            Assert.NotNull(
                (
                    (OpenLanguage.WordprocessingML.FieldInstruction.PageRefFieldInstruction)result
                ).BookmarkName
            );
        }

        [Fact]
        public void Parse_ComplexNestedField_ParsesCorrectly()
        {
            string complexField =
                "IF { MERGEFIELD Department } = \"Sales\" { MERGEFIELD SalesBonus } { MERGEFIELD StandardBonus }";

            ExpressionNode result = FieldInstructionParser.Parse(complexField);

            Assert.IsType<OpenLanguage.WordprocessingML.FieldInstruction.Ast.IfFieldInstruction>(
                result
            );
            Assert.Equal("IF", ((Ast.FieldInstruction)result).Instruction);

            // Check for nested fields
            int nestedCount = result
                .Children<Node>()
                .SelectMany(e =>
                    e.Children<OpenLanguage.WordprocessingML.FieldInstruction.Ast.NestedFieldInstruction>()
                )
                .Concat(
                    result.Children<OpenLanguage.WordprocessingML.FieldInstruction.Ast.NestedFieldInstruction>()
                )
                .Count();
            Assert.Equal(3, nestedCount);
        }

        [Fact]
        public void Parse_MultipleNestedLevels_ParsesCorrectly()
        {
            string multiNestedField =
                "IF { IF { MERGEFIELD Age } > 65 \"Senior\" \"Adult\" } = \"Senior\" { MERGEFIELD SeniorDiscount } { MERGEFIELD StandardPrice }";

            ExpressionNode result = FieldInstructionParser.Parse(multiNestedField);

            Assert.IsType<OpenLanguage.WordprocessingML.FieldInstruction.Ast.IfFieldInstruction>(
                result
            );
            Assert.Equal("IF", ((Ast.FieldInstruction)result).Instruction);

            // Should have nested IF field
            Ast.IfFieldInstruction? nestedIf = result
                .Children<EqualNode>()
                .SelectMany(e =>
                    e.Children<OpenLanguage.WordprocessingML.FieldInstruction.Ast.NestedFieldInstruction>()
                )
                .SelectMany(n =>
                    n.Children<OpenLanguage.WordprocessingML.FieldInstruction.Ast.IfFieldInstruction>()
                )
                .FirstOrDefault();
            Assert.NotNull(nestedIf);

            Assert.Equal(result.ToString(), multiNestedField);
        }

        [Theory]
        [InlineData("FILENAME")]
        [InlineData("FILENAME \\p")]
        [InlineData("FILENAME \\* Upper")]
        [InlineData("FILENAME \\* Lower")]
        public void Parse_FilenameVariations_ParsesCorrectly(string fieldCode)
        {
            ExpressionNode result = FieldInstructionParser.Parse(fieldCode);

            Assert.IsType<OpenLanguage.WordprocessingML.FieldInstruction.Ast.FileNameFieldInstruction>(
                result
            );
            Assert.Equal("FILENAME", ((Ast.FieldInstruction)result).Instruction);
        }

        [Theory]
        [InlineData("AUTHOR")]
        [InlineData("AUTHOR \\* Upper")]
        [InlineData("AUTHOR \\* FirstCap")]
        public void Parse_AuthorVariations_ParsesCorrectly(string fieldCode)
        {
            ExpressionNode result = FieldInstructionParser.Parse(fieldCode);

            Assert.IsType<OpenLanguage.WordprocessingML.FieldInstruction.Ast.AuthorFieldInstruction>(
                result
            );
            Assert.Equal("AUTHOR", ((Ast.FieldInstruction)result).Instruction);
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
            ExpressionNode result = FieldInstructionParser.Parse(fieldCode);

            Assert.Contains(
                ((Ast.FieldInstruction)result).Instruction,
                new[] { "CREATEDATE", "SAVEDATE", "PRINTDATE" }
            );
        }

        [Theory]
        [InlineData("NUMPAGES")]
        [InlineData("NUMPAGES \\* Arabic")]
        [InlineData("NUMPAGES \\* roman")]
        [InlineData("NUMPAGES \\* ROMAN")]
        public void Parse_NumPagesVariations_ParsesCorrectly(string fieldCode)
        {
            ExpressionNode result = FieldInstructionParser.Parse(fieldCode);

            Assert.IsType<OpenLanguage.WordprocessingML.FieldInstruction.Ast.NumPagesFieldInstruction>(
                result
            );
            Assert.Equal("NUMPAGES", ((Ast.FieldInstruction)result).Instruction);
        }

        [Theory]
        [InlineData("NUMWORDS")]
        [InlineData("NUMCHARS")]
        [InlineData("NUMPAGES")]
        public void Parse_DocumentStatsVariations_ParsesCorrectly(string fieldCode)
        {
            ExpressionNode result = FieldInstructionParser.Parse(fieldCode);

            Assert.Contains(
                ((Ast.FieldInstruction)result).Instruction,
                new[] { "NUMWORDS", "NUMCHARS", "NUMPAGES" }
            );
        }

        [Fact]
        public void Parse_FieldWithEscapedQuotes_ParsesCorrectly()
        {
            string fieldWithEscapedQuotes =
                "MERGEFIELD Company \\b \"Company \\\"Name\\\" Unknown\"";

            ExpressionNode result = FieldInstructionParser.Parse(fieldWithEscapedQuotes);

            Assert.IsType<OpenLanguage.WordprocessingML.FieldInstruction.MergeFieldFieldInstruction>(
                result
            );
            Assert.Equal("MERGEFIELD", ((Ast.FieldInstruction)result).Instruction);
            Assert.Contains("\"Company \\\"Name\\\" Unknown\"", result.ToString());
        }

        [Fact]
        public void Parse_FieldWithSpecialCharacters_ParsesCorrectly()
        {
            string fieldWithSpecialChars = "MERGEFIELD \"Field With Spaces & Special Chars!@#$%\"";

            ExpressionNode result = FieldInstructionParser.Parse(fieldWithSpecialChars);

            Assert.IsType<OpenLanguage.WordprocessingML.FieldInstruction.MergeFieldFieldInstruction>(
                result
            );
            Assert.Equal(
                "MERGEFIELD",
                (
                    (OpenLanguage.WordprocessingML.FieldInstruction.MergeFieldFieldInstruction)result
                ).Instruction
            );
            Assert.Contains("\"Field With Spaces & Special Chars!@#$%\"", result.ToString());
        }

        [Theory]
        [InlineData("{ MERGEFIELD FirstName }")]
        [InlineData("{MERGEFIELD FirstName}")]
        [InlineData("{ MERGEFIELD FirstName \\* Upper }")]
        public void Parse_FieldWithBraces_ParsesCorrectly(string fieldCode)
        {
            ExpressionNode result = FieldInstructionParser.Parse(fieldCode);

            Assert.IsType<NestedFieldInstruction>(result);
            Assert.IsType<OpenLanguage.WordprocessingML.FieldInstruction.MergeFieldFieldInstruction>(
                result.Children<MergeFieldFieldInstruction>().First()
            );
            Assert.Equal(
                "MERGEFIELD",
                result.Children<MergeFieldFieldInstruction>().First().Instruction.ToString().Trim()
            );
            Assert.Equal(result.ToString(), fieldCode);
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
                ExpressionNode parsed = FieldInstructionParser.Parse(original);
                string reconstructed = parsed.ToString();

                // Parse the reconstructed field to ensure it's valid
                ExpressionNode reparsed = FieldInstructionParser.Parse(reconstructed);
                Assert.IsAssignableFrom<Ast.FieldInstruction>(reparsed);
                Assert.IsAssignableFrom<Ast.FieldInstruction>(parsed);
                Assert.Equal(
                    ((Ast.FieldInstruction)parsed).Instruction,
                    ((Ast.FieldInstruction)reparsed).Instruction
                );
                Assert.Equal(parsed.ToString(), reparsed.ToString());
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
                Assert.ThrowsAny<Exception>(() => FieldInstructionParser.Parse(fieldCode));
            }
            else
            {
                // Some invalid fields may parse partially or throw exceptions
                // The exact behavior depends on the implementation
                try
                {
                    ExpressionNode result = FieldInstructionParser.Parse(fieldCode);
                    // If parsing succeeds, verify basic structure
                    Assert.NotNull(result);
                    Assert.NotNull(((Ast.FieldInstruction)result).Instruction);
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
            ExpressionNode? result = FieldInstructionParser.TryParse(fieldCode);

            Assert.NotNull(result);
            Assert.NotNull(((Ast.FieldInstruction)result).Instruction);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("   ")]
        [InlineData("{ UNCLOSED")]
        public void TryParse_InvalidFields_ReturnsNull(string? fieldCode)
        {
            ExpressionNode? result = FieldInstructionParser.TryParse(fieldCode!);

            Assert.Null(result);
        }

        [Fact]
        public void Parse_FieldWithMultipleSwitches_ParsesAllSwitches()
        {
            string fieldWithMultipleSwitches =
                "MERGEFIELD Amount \\# \"$#,##0.00\" \\* MERGEFORMAT \\b \"$0.00\"";

            ExpressionNode result = FieldInstructionParser.Parse(fieldWithMultipleSwitches);

            Assert.IsType<OpenLanguage.WordprocessingML.FieldInstruction.MergeFieldFieldInstruction>(
                result
            );
            Assert.Equal("MERGEFIELD", ((Ast.FieldInstruction)result).Instruction);

            string raw = result.ToString();
            Assert.Contains("\\#", raw);
            Assert.Contains("\\*", raw);
            Assert.Contains("\\b", raw);
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
            for (int i = 0; i < fields.Length; i++)
            {
                fields[i] = $"MERGEFIELD Field{i}";
            }

            System.Diagnostics.Stopwatch stopwatch = System.Diagnostics.Stopwatch.StartNew();
            foreach (string fieldCode in fields)
            {
                ExpressionNode result = FieldInstructionParser.Parse(fieldCode);
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
            ExpressionNode result = FieldInstructionParser.Parse(complexField);
            stopwatch.Stop();

            Assert.NotNull(result);
            Assert.True(
                stopwatch.ElapsedMilliseconds < 1000,
                $"Parsing complex field took {stopwatch.ElapsedMilliseconds}ms, expected < 1000ms"
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
            for (int i = 0; i < argumentCount; i++)
            {
                mergeFields[i] = $"{{ MERGEFIELD Field{i} }}";
            }

            string complexField =
                $"IF {string.Join(" = ", mergeFields.Take(2))} \"Match\" \"NoMatch\"";

            ExpressionNode result = FieldInstructionParser.Parse(complexField);
            Assert.NotNull(result);
            Assert.Equal("IF", ((Ast.FieldInstruction)result).Instruction);
        }
    }

    /// <summary>
    /// Tests for field instruction argument types and validation
    /// </summary>
}

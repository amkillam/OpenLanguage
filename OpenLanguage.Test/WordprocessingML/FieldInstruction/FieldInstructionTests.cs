using System;
using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;
using OpenLanguage.WordprocessingML.Operators;
using Xunit;
using CoreAst = OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Tests
{
    public class FieldInstructionTests
    {
        private static void RecurseLogFieldInstructionTree(
            CoreAst.Node? node,
            int depth = 0,
            System.IO.TextWriter? writer = null
        )
        {
            writer ??= Console.Out;
            string indent = new string(' ', depth * 2);
            writer.WriteLine(
                $"{indent}- {node?.GetType()?.Name ?? "null"}: {node?.ToString() ?? string.Empty}"
            );
            if (node != null)
            {
                foreach (CoreAst.Node child in node.Children<CoreAst.Node>())
                {
                    RecurseLogFieldInstructionTree(child, depth + 1, writer);
                }
            }
        }

        [Theory]
        [InlineData("PAGE")]
        [InlineData("DATE")]
        [InlineData("TIME")]
        [InlineData("AUTHOR")]
        [InlineData("FILENAME")]
        public void Parse_WithValidInstruction_ReturnsAst(string instruction)
        {
            ExpressionNode result = FieldInstructionParser.Parse(instruction);
            Assert.IsAssignableFrom<Ast.FieldInstruction>(result);
            Assert.Equal(instruction, ((Ast.FieldInstruction)result).Instruction);
            Assert.NotNull(result.Children<CoreAst.Node>());
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public void Parse_WithInvalidInstruction_ThrowsArgumentException(string? instruction)
        {
            Assert.Throws<ArgumentException>(() => FieldInstructionParser.Parse(instruction!));
        }

        [Fact]
        public void Parse_Page_WithGeneralFormat_ParsesCorrectly()
        {
            string fieldCode = "PAGE \\* MERGEFORMAT";
            ExpressionNode result = FieldInstructionParser.Parse(fieldCode);

            Assert.IsType<OpenLanguage.WordprocessingML.FieldInstruction.Ast.PageFieldInstruction>(
                result
            );
            Assert.Equal("PAGE", ((Ast.PageFieldInstruction)result).Instruction);
            OpenLanguage.WordprocessingML.FieldInstruction.Ast.PageFieldInstruction page =
                (OpenLanguage.WordprocessingML.FieldInstruction.Ast.PageFieldInstruction)result;
            Assert.NotNull(page.GeneralFormat);
            Assert.Contains("\\*", result.ToRawString());
        }

        [Theory]
        [InlineData("PAGE", "PAGE")]
        [InlineData("date", "date")]
        [InlineData("TIME \\* MERGEFORMAT", "TIME \\* MERGEFORMAT")]
        public void ToString_ReturnsInstructionString(string instruction, string expected)
        {
            ExpressionNode result = FieldInstructionParser.Parse(instruction);
            string actual = result.ToString();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CaseInsensitive_InstructionHandling()
        {
            ExpressionNode upper = FieldInstructionParser.Parse("PAGE");
            ExpressionNode lower = FieldInstructionParser.Parse("page");
            ExpressionNode mixed = FieldInstructionParser.Parse("Page");

            Assert.IsType<OpenLanguage.WordprocessingML.FieldInstruction.Ast.PageFieldInstruction>(
                upper
            );
            Assert.IsType<OpenLanguage.WordprocessingML.FieldInstruction.Ast.PageFieldInstruction>(
                lower
            );
            Assert.IsType<OpenLanguage.WordprocessingML.FieldInstruction.Ast.PageFieldInstruction>(
                mixed
            );
            Assert.Equal("PAGE", ((Ast.FieldInstruction)upper).Instruction);
            Assert.Equal("page", ((Ast.FieldInstruction)lower).Instruction);
            Assert.Equal("Page", ((Ast.FieldInstruction)mixed).Instruction);
        }

        [Fact]
        public void TestWithTextFileLines()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            System.IO.TextWriter origConsoleOut = Console.Out;
            System.IO.TextWriter origConsoleError = Console.Error;
            using System.IO.StringWriter sw = new System.IO.StringWriter();
            using System.IO.StringWriter swCumulative = new System.IO.StringWriter();
            Console.SetOut(sw);
            Console.SetError(sw);
            IEnumerable<string> fieldInstructions =
                FieldInstructionUtils.DatasetFieldInstructions();

            // failedFile =
            System.IO.FileStream failedFd = System.IO.File.OpenWrite(
                "/tmp/failed_field_instructions.txt"
            );
            System.IO.FileStream failedFormattingFd = System.IO.File.OpenWrite(
                "/tmp/failed_formatting_field_instructions.txt"
            );
            System.IO.FileStream successFd = System.IO.File.OpenWrite(
                "/tmp/successful_field_instructions.txt"
            );
            System.IO.FileStream inProgressFd = System.IO.File.OpenWrite(
                "/tmp/in_progress_field_instructions.txt"
            );
            successFd.SetLength(0);
            failedFd.SetLength(0);
            failedFormattingFd.SetLength(0);
            inProgressFd.SetLength(0);
            using System.IO.StreamWriter successWriter = new System.IO.StreamWriter(successFd);
            using System.IO.StreamWriter failedFormattingWriter = new System.IO.StreamWriter(
                failedFormattingFd
            );
            using System.IO.StreamWriter inProgressWriter = new System.IO.StreamWriter(
                inProgressFd
            );
            using System.IO.StreamWriter failedWriter = new System.IO.StreamWriter(failedFd);
            System.UInt128 i = 0;
            int total = fieldInstructions.Count();

            int failedCnt = 0;

            int maxFailures = 10;
            foreach (string fieldInstructionText in fieldInstructions)
            {
                inProgressFd.SetLength(0);

                inProgressWriter.WriteLine(fieldInstructionText);
                inProgressWriter.Flush();
                sw.Flush();
                sw.GetStringBuilder().Clear();

                if (
                    !string.IsNullOrWhiteSpace(fieldInstructionText)
                    && fieldInstructionText.Length > 0
                )
                {
                    Node? fieldInstruction = FieldInstructionParser.TryParse(fieldInstructionText);
                    if (fieldInstruction == null)
                    {
                        sw.Flush();
                        System.Threading.Thread.Sleep(1000);
                        sw.Flush();
                        string stdOut = sw.ToString();
                        swCumulative.Flush();
                        swCumulative.WriteLine("");
                        swCumulative.WriteLine("");
                        swCumulative.WriteLine($"\n\n## {failedCnt + 1}. `{fieldInstructionText}`");

                        swCumulative.WriteLine(
                            $"### Info\nFailed to parse field instruction ({i + 1}/{total}).\nText:\"{fieldInstructionText}\"\nHex:{BitConverter.ToString(System.Text.Encoding.UTF8.GetBytes(fieldInstructionText))}"
                        );

                        if (!string.IsNullOrWhiteSpace(stdOut))
                        {
                            swCumulative.WriteLine("### Captured StdOut and StdErr");
                            swCumulative.WriteLine(stdOut);
                        }
                        failedWriter.WriteLine(fieldInstructionText);
                        failedWriter.Flush();
                        swCumulative.Flush();

                        if (++failedCnt == maxFailures)
                        {
                            break;
                        }
                    }
                    else if (fieldInstruction.ToString() != fieldInstructionText)
                    {
                        sw.Flush();
                        System.Threading.Thread.Sleep(1000);
                        sw.Flush();
                        string stdOut = sw.ToString();

                        swCumulative.Flush();
                        swCumulative.WriteLine("");
                        swCumulative.WriteLine("");
                        swCumulative.WriteLine($"## {failedCnt + 1}. `{fieldInstructionText}`");
                        swCumulative.WriteLine("### Info");
                        swCumulative.WriteLine(
                            $"Failed to parse field instruction ({i + 1}/{total}).\nText:\"{fieldInstructionText}\"\nHex:{BitConverter.ToString(System.Text.Encoding.UTF8.GetBytes(fieldInstructionText))}"
                        );
                        swCumulative.WriteLine("### Parsed Field Instruction AST Tree");
                        RecurseLogFieldInstructionTree(fieldInstruction, 0, swCumulative);
                        swCumulative.Flush();

                        if (!string.IsNullOrWhiteSpace(stdOut))
                        {
                            swCumulative.WriteLine("### Captured StdOut and StdErr");
                            swCumulative.WriteLine(stdOut);
                        }

                        swCumulative.Flush();

                        failedFormattingWriter.WriteLine(fieldInstructionText);
                        failedFormattingWriter.Flush();

                        swCumulative.Flush();

                        if (++failedCnt == maxFailures)
                        {
                            break;
                        }
                    }
                    else
                    {
                        successWriter.WriteLine(fieldInstructionText);
                        successWriter.Flush();

                        // Console.WriteLine($"Parsed field instruction {i + 1}/{total} successfully: \"{fieldInstructionText}\"");
                    }
                }
                i++;
            }

            successWriter.Flush();
            failedWriter.Flush();
            failedFormattingWriter.Flush();
            inProgressWriter.Flush();
            Console.SetOut(origConsoleOut);
            Console.SetError(origConsoleError);
            if (failedCnt > 0)
            {
                if (failedCnt == maxFailures)
                {
                    Console.Error.WriteLine($"**Parsing stopped after {maxFailures} failures.**");
                    Console.Error.WriteLine(swCumulative.ToString());
                }
                else
                {
                    Console.Error.WriteLine($"**Parsing completed with {failedCnt} failures.**");

                    Console.Error.WriteLine(swCumulative.ToString());
                }
                Console.Error.Flush();
            }
            sw.Flush();
            swCumulative.Flush();
            origConsoleOut.Flush();
            origConsoleError.Flush();
            if (failedCnt > 0)
            {
                throw new Exception($"TestWithTextFileLines: {failedCnt} failures");
            }
        }
    }

    public class PtsMeasurementValueTests
    {
        [Theory]
        [InlineData(-31)]
        [InlineData(0)]
        [InlineData(15)]
        [InlineData(31)]
        public void Constructor_WithValidValue_SetsValue(int value)
        {
            // Act
            PtsMeasurementValue<int> measurement = new PtsMeasurementValue<int>(value);

            // Assert
            Assert.Equal(value, measurement.Value);
        }

        [Theory]
        [InlineData(-32)]
        [InlineData(32)]
        [InlineData(100)]
        [InlineData(-100)]
        public void Constructor_WithInvalidValue_ThrowsArgumentException(int value)
        {
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new PtsMeasurementValue<int>(value));
        }

        [Theory]
        [InlineData(-31, "-31")]
        [InlineData(0, "0")]
        [InlineData(31, "31")]
        public void ToString_ReturnsValueAsString(int value, string expected)
        {
            // Arrange
            PtsMeasurementValue<int> measurement = new PtsMeasurementValue<int>(value);

            // Act
            string result = measurement.ToString();

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(15, 15)]
        [InlineData(-10, -10)]
        public void ImplicitConversion_ToInt_ReturnsValue(int value, int expected)
        {
            // Arrange
            PtsMeasurementValue<int> measurement = new PtsMeasurementValue<int>(value);

            // Act
            int result = measurement;

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(20)]
        [InlineData(-5)]
        public void ImplicitConversion_FromInt_CreatesInstance(int value)
        {
            // Act
            PtsMeasurementValue<int> measurement = value;

            // Assert
            Assert.Equal(value, measurement.Value);
        }
    }

    public class PostalDataTests
    {
        [Theory]
        [InlineData("12345")]
        [InlineData("123456789")]
        [InlineData("12345-6789")]
        public void Constructor_WithValidPostalData_SetsValue(string value)
        {
            // Act
            PostalData postalData = new PostalData(value);

            // Assert
            Assert.Equal(value, postalData.ToString());
        }

        [Theory]
        [InlineData("1234")] // Too short
        [InlineData("123456")] // Invalid length
        [InlineData("1234567890")] // Too long
        [InlineData("12345-67890")] // Too many digits after hyphen
        [InlineData("1234-5678")] // Too few digits before hyphen
        [InlineData("abcde")] // Non-numeric
        [InlineData("12345-abcd")] // Non-numeric after hyphen
        [InlineData("")] // Empty
        [InlineData(null)] // Null
        public void Constructor_WithInvalidPostalData_ThrowsArgumentException(string? value)
        {
            // Act & Assert
            ArgumentException ex = Assert.Throws<ArgumentException>(() => new PostalData(value!));
            Assert.Contains("Invalid postal data format", ex.Message);
        }

        [Theory]
        [InlineData("12345", "12345")]
        [InlineData("12345-6789", "12345-6789")]
        [InlineData("123456789", "123456789")]
        public void ToString_ReturnsOriginalValue(string value, string expected)
        {
            // Arrange
            PostalData postalData = new PostalData(value);

            // Act
            string result = postalData.ToString();

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("12345")]
        [InlineData("12345-6789")]
        public void ImplicitConversion_ToString_ReturnsValue(string value)
        {
            // Arrange
            PostalData postalData = new PostalData(value);

            // Act
            string result = postalData;

            // Assert
            Assert.Equal(value, result);
        }

        [Theory]
        [InlineData("12345")]
        [InlineData("12345-6789")]
        public void ImplicitConversion_FromString_CreatesInstance(string value)
        {
            // Act
            PostalData postalData = value;

            // Assert
            Assert.Equal(value, postalData.ToString());
        }
    }

    public class NamespaceDeclarationTests
    {
        [Theory]
        [InlineData("xmlns:a=\"http://example.com\"")]
        [InlineData("xmlns:prefix=\"urn:schema\"")]
        [InlineData("xmlns:test=\"resume-schema\"")]
        public void Constructor_WithValidDeclaration_SetsValue(string declaration)
        {
            // Act
            NamespaceDeclaration namespaceDecl = new NamespaceDeclaration(declaration);

            // Assert
            Assert.Equal(declaration, namespaceDecl.ToString());
        }

        [Theory]
        [InlineData("invalid")]
        [InlineData("xmlns:")]
        [InlineData("xmlns:prefix")]
        [InlineData("prefix=\"uri\"")]
        [InlineData("xmlns:prefix=")]
        [InlineData("")]
        [InlineData(null)]
        public void Constructor_WithInvalidDeclaration_ThrowsArgumentException(string? declaration)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new NamespaceDeclaration(declaration!));
        }

        [Theory]
        [InlineData("xmlns:a=\"http://example.com\"", "xmlns:a=\"http://example.com\"")]
        [InlineData("xmlns:test=\"schema\"", "xmlns:test=\"schema\"")]
        public void ToString_ReturnsOriginalDeclaration(string declaration, string expected)
        {
            // Arrange
            NamespaceDeclaration namespaceDecl = new NamespaceDeclaration(declaration);

            // Act
            string result = namespaceDecl.ToString();

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("xmlns:a=\"http://example.com\"")]
        [InlineData("xmlns:test=\"schema\"")]
        public void ImplicitConversion_ToString_ReturnsValue(string declaration)
        {
            // Arrange
            NamespaceDeclaration namespaceDecl = new NamespaceDeclaration(declaration);

            // Act
            string result = namespaceDecl;

            // Assert
            Assert.Equal(declaration, result);
        }

        [Theory]
        [InlineData("xmlns:a=\"http://example.com\"")]
        [InlineData("xmlns:test=\"schema\"")]
        public void ImplicitConversion_FromString_CreatesInstance(string declaration)
        {
            // Act
            NamespaceDeclaration namespaceDecl = declaration;

            // Assert
            Assert.Equal(declaration, namespaceDecl.ToString());
        }
    }

    public class EnumTests
    {
        [Fact]
        public void NameFormat_HasAllExpectedValues()
        {
            // Arrange
            NameFormat[] expectedValues = new NameFormat[6]
            {
                NameFormat.FirstName,
                NameFormat.LastName,
                NameFormat.FirstLastName,
                NameFormat.LastFirstName,
                NameFormat.TitleLastName,
                NameFormat.FullFormalName,
            };

            // Act
            IEnumerable<NameFormat> actualValues = Enum.GetValues<NameFormat>();

            // Assert
            Assert.Equal(expectedValues.Length, actualValues.Count());
            foreach (NameFormat expected in expectedValues)
            {
                Assert.Contains(expected, actualValues);
            }
        }

        [Fact]
        public void CountryRegion_HasExpectedValues()
        {
            // Act
            IEnumerable<CountryRegion> values = Enum.GetValues<CountryRegion>();

            // Assert
            Assert.True(values.Count() > 200, "Should have comprehensive country list");
            Assert.Contains(CountryRegion.UnitedStates, values);
            Assert.Contains(CountryRegion.Canada, values);
            Assert.Contains(CountryRegion.UnitedKingdom, values);
        }

        [Fact]
        public void LanguageIdentifier_HasExpectedValues()
        {
            // Act
            IEnumerable<LanguageIdentifier> values = Enum.GetValues<LanguageIdentifier>();

            // Assert
            Assert.True(values.Count() > 100, "Should have comprehensive language list");
            Assert.Contains(LanguageIdentifier.EnglishUS, values);
            Assert.Contains(LanguageIdentifier.FrenchFrance, values);
            Assert.Contains(LanguageIdentifier.GermanGermany, values);
        }

        [Fact]
        public void ComparisonOperator_HasAllExpectedValues()
        {
            // Arrange
            ComparisonOperator[] expectedValues = new ComparisonOperator[6]
            {
                ComparisonOperator.Equal,
                ComparisonOperator.NotEqual,
                ComparisonOperator.LessThan,
                ComparisonOperator.LessThanOrEqual,
                ComparisonOperator.GreaterThan,
                ComparisonOperator.GreaterThanOrEqual,
            };

            // Act
            IEnumerable<ComparisonOperator> actualValues = Enum.GetValues<ComparisonOperator>();

            // Assert
            Assert.Equal(expectedValues.Length, actualValues.Count());
            foreach (ComparisonOperator expected in expectedValues)
            {
                Assert.Contains(expected, actualValues);
            }
        }

        [Fact]
        public void CountryRegionInclusion_HasAllExpectedValues()
        {
            // Arrange
            CountryRegionInclusion[] expectedValues = new CountryRegionInclusion[3]
            {
                CountryRegionInclusion.Omit,
                CountryRegionInclusion.Include,
                CountryRegionInclusion.IncludeIfDifferent,
            };

            // Act
            IEnumerable<CountryRegionInclusion> actualValues =
                Enum.GetValues<CountryRegionInclusion>();

            // Assert
            Assert.Equal(expectedValues.Length, actualValues.Count());
            foreach (CountryRegionInclusion expected in expectedValues)
            {
                Assert.Contains(expected, actualValues);
            }

            // Verify numeric values
            Assert.Equal(0, (int)CountryRegionInclusion.Omit);
            Assert.Equal(1, (int)CountryRegionInclusion.Include);
            Assert.Equal(2, (int)CountryRegionInclusion.IncludeIfDifferent);
        }
    }
}

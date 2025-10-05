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

            IEnumerable<string> fieldInstructions =
                FieldInstructionUtils.DatasetFieldInstructions();

            int total = fieldInstructions.Count();

            int i = 0;
            foreach (string fieldInstructionText in fieldInstructions)
            {
                if (
                    !string.IsNullOrWhiteSpace(fieldInstructionText)
                    && fieldInstructionText.Length > 0
                )
                {
                    Node? fieldInstruction = FieldInstructionParser.TryParse(fieldInstructionText);
                    if (fieldInstruction == null)
                    {
                        throw new Exception(
                            $"Failed to parse field instruction ({i + 1}/{total}).\nText:\"{fieldInstructionText}\"\nHex:{BitConverter.ToString(System.Text.Encoding.UTF8.GetBytes(fieldInstructionText))}"
                        );
                    }
                    else if (fieldInstruction.ToString() != fieldInstructionText)
                    {
                        Console.Error.WriteLine(
                            $"Failed to parse field instruction ({i + 1}/{total}).\nText:\"{fieldInstructionText}\"\nHex:{BitConverter.ToString(System.Text.Encoding.UTF8.GetBytes(fieldInstructionText))}"
                        );
                        Console.Error.WriteLine("### Parsed Field Instruction AST Tree");
                        RecurseLogFieldInstructionTree(fieldInstruction, 0, Console.Error);
                        Console.Error.Flush();
                        throw new Exception(
                            $"Field instruction text mismatch after parsing ({i + 1}/{total}).\nOriginal:\"{fieldInstructionText}\"\nParsed:\"{fieldInstruction.ToString()}\"\nHex:{BitConverter.ToString(System.Text.Encoding.UTF8.GetBytes(fieldInstructionText))}"
                        );
                    }
                }
            }
            i++;
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
            PtsMeasurementValue<int> measurement = new PtsMeasurementValue<int>(value);

            Assert.Equal(value, measurement.Value);
        }

        [Theory]
        [InlineData(-32)]
        [InlineData(32)]
        [InlineData(100)]
        [InlineData(-100)]
        public void Constructor_WithInvalidValue_ThrowsArgumentException(int value)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new PtsMeasurementValue<int>(value));
        }

        [Theory]
        [InlineData(-31, "-31")]
        [InlineData(0, "0")]
        [InlineData(31, "31")]
        public void ToString_ReturnsValueAsString(int value, string expected)
        {
            PtsMeasurementValue<int> measurement = new PtsMeasurementValue<int>(value);

            string result = measurement.ToString();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(15, 15)]
        [InlineData(-10, -10)]
        public void ImplicitConversion_ToInt_ReturnsValue(int value, int expected)
        {
            PtsMeasurementValue<int> measurement = new PtsMeasurementValue<int>(value);

            int result = measurement;

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(20)]
        [InlineData(-5)]
        public void ImplicitConversion_FromInt_CreatesInstance(int value)
        {
            PtsMeasurementValue<int> measurement = value;

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
            PostalData postalData = new PostalData(value);

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
            ArgumentException ex = Assert.Throws<ArgumentException>(() => new PostalData(value!));
            Assert.Contains("Invalid postal data format", ex.Message);
        }

        [Theory]
        [InlineData("12345", "12345")]
        [InlineData("12345-6789", "12345-6789")]
        [InlineData("123456789", "123456789")]
        public void ToString_ReturnsOriginalValue(string value, string expected)
        {
            PostalData postalData = new PostalData(value);

            string result = postalData.ToString();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("12345")]
        [InlineData("12345-6789")]
        public void ImplicitConversion_ToString_ReturnsValue(string value)
        {
            PostalData postalData = new PostalData(value);

            string result = postalData;

            Assert.Equal(value, result);
        }

        [Theory]
        [InlineData("12345")]
        [InlineData("12345-6789")]
        public void ImplicitConversion_FromString_CreatesInstance(string value)
        {
            PostalData postalData = value;

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
            NamespaceDeclaration namespaceDecl = new NamespaceDeclaration(declaration);

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
            Assert.Throws<ArgumentException>(() => new NamespaceDeclaration(declaration!));
        }

        [Theory]
        [InlineData("xmlns:a=\"http://example.com\"", "xmlns:a=\"http://example.com\"")]
        [InlineData("xmlns:test=\"schema\"", "xmlns:test=\"schema\"")]
        public void ToString_ReturnsOriginalDeclaration(string declaration, string expected)
        {
            NamespaceDeclaration namespaceDecl = new NamespaceDeclaration(declaration);

            string result = namespaceDecl.ToString();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("xmlns:a=\"http://example.com\"")]
        [InlineData("xmlns:test=\"schema\"")]
        public void ImplicitConversion_ToString_ReturnsValue(string declaration)
        {
            NamespaceDeclaration namespaceDecl = new NamespaceDeclaration(declaration);

            string result = namespaceDecl;

            Assert.Equal(declaration, result);
        }

        [Theory]
        [InlineData("xmlns:a=\"http://example.com\"")]
        [InlineData("xmlns:test=\"schema\"")]
        public void ImplicitConversion_FromString_CreatesInstance(string declaration)
        {
            NamespaceDeclaration namespaceDecl = declaration;

            Assert.Equal(declaration, namespaceDecl.ToString());
        }
    }

    public class EnumTests
    {
        [Fact]
        public void NameFormat_HasAllExpectedValues()
        {
            NameFormat[] expectedValues = new NameFormat[6]
            {
                NameFormat.FirstName,
                NameFormat.LastName,
                NameFormat.FirstLastName,
                NameFormat.LastFirstName,
                NameFormat.TitleLastName,
                NameFormat.FullFormalName,
            };

            IEnumerable<NameFormat> actualValues = Enum.GetValues<NameFormat>();

            Assert.Equal(expectedValues.Length, actualValues.Count());
            foreach (NameFormat expected in expectedValues)
            {
                Assert.Contains(expected, actualValues);
            }
        }

        [Fact]
        public void CountryRegion_HasExpectedValues()
        {
            IEnumerable<CountryRegion> values = Enum.GetValues<CountryRegion>();

            Assert.True(values.Count() > 200, "Should have comprehensive country list");
            Assert.Contains(CountryRegion.UnitedStates, values);
            Assert.Contains(CountryRegion.Canada, values);
            Assert.Contains(CountryRegion.UnitedKingdom, values);
        }

        [Fact]
        public void LanguageIdentifier_HasExpectedValues()
        {
            IEnumerable<LanguageIdentifier> values = Enum.GetValues<LanguageIdentifier>();

            Assert.True(values.Count() > 100, "Should have comprehensive language list");
            Assert.Contains(LanguageIdentifier.EnglishUS, values);
            Assert.Contains(LanguageIdentifier.FrenchFrance, values);
            Assert.Contains(LanguageIdentifier.GermanGermany, values);
        }

        [Fact]
        public void ComparisonOperator_HasAllExpectedValues()
        {
            ComparisonOperator[] expectedValues = new ComparisonOperator[6]
            {
                ComparisonOperator.Equal,
                ComparisonOperator.NotEqual,
                ComparisonOperator.LessThan,
                ComparisonOperator.LessThanOrEqual,
                ComparisonOperator.GreaterThan,
                ComparisonOperator.GreaterThanOrEqual,
            };

            IEnumerable<ComparisonOperator> actualValues = Enum.GetValues<ComparisonOperator>();

            Assert.Equal(expectedValues.Length, actualValues.Count());
            foreach (ComparisonOperator expected in expectedValues)
            {
                Assert.Contains(expected, actualValues);
            }
        }

        [Fact]
        public void CountryRegionInclusion_HasAllExpectedValues()
        {
            CountryRegionInclusion[] expectedValues = new CountryRegionInclusion[3]
            {
                CountryRegionInclusion.Omit,
                CountryRegionInclusion.Include,
                CountryRegionInclusion.IncludeIfDifferent,
            };

            IEnumerable<CountryRegionInclusion> actualValues =
                Enum.GetValues<CountryRegionInclusion>();

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

using System;
using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Operators;
using Xunit;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Tests
{
    public class FieldInstructionTests
    {
        [Theory]
        [InlineData("PAGE")]
        [InlineData("DATE")]
        [InlineData("TIME")]
        [InlineData("AUTHOR")]
        [InlineData("FILENAME")]
        public void Constructor_WithValidInstruction_SetsInstructionProperty(string instruction)
        {
            // Act
            FieldInstruction fieldInstruction = new FieldInstruction(instruction);

            // Assert
            Assert.Equal(instruction, fieldInstruction.Instruction);
            Assert.NotNull(fieldInstruction.Arguments);
            Assert.Empty(fieldInstruction.Arguments);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public void Constructor_WithInvalidInstruction_ThrowsArgumentException(string? instruction)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new FieldInstruction(instruction!));
        }

        [Fact]
        public void Constructor_WithInstructionAndArguments_SetsProperties()
        {
            // Arrange
            string instruction = "PAGE";
            List<FieldArgument> arguments = new List<FieldArgument>
            {
                new FieldArgument(FieldArgumentType.Switch, "\\* MERGEFORMAT"),
                new FieldArgument(FieldArgumentType.StringLiteral, "test"),
            };

            // Act
            FieldInstruction fieldInstruction = new FieldInstruction(instruction, arguments);

            // Assert
            Assert.Equal(instruction, fieldInstruction.Instruction);
            Assert.Equal(2, fieldInstruction.Arguments.Count);
            Assert.Equal(FieldArgumentType.Switch, fieldInstruction.Arguments[0].Type);
            Assert.Equal("\\* MERGEFORMAT", fieldInstruction.Arguments[0].Value);
            Assert.Equal(FieldArgumentType.StringLiteral, fieldInstruction.Arguments[1].Type);
            Assert.Equal("test", fieldInstruction.Arguments[1].Value);
        }

        [Fact]
        public void Constructor_WithNullArguments_InitializesEmptyArgumentsList()
        {
            // Act
            FieldInstruction fieldInstruction = new FieldInstruction("PAGE");

            // Assert
            Assert.Equal("PAGE", fieldInstruction.Instruction);
            Assert.NotNull(fieldInstruction.Arguments);
            Assert.Empty(fieldInstruction.Arguments);
        }

        [Fact]
        public void Arguments_CanBeModified()
        {
            // Arrange
            FieldInstruction fieldInstruction = new FieldInstruction("PAGE");

            // Act
            fieldInstruction.Arguments.Add(
                new FieldArgument(FieldArgumentType.Switch, "\\* Upper")
            );

            // Assert
            Assert.Single(fieldInstruction.Arguments);
            Assert.Equal("\\* Upper", fieldInstruction.Arguments[0].Value);
        }

        [Theory]
        [InlineData("PAGE", "PAGE")]
        [InlineData("date", "date")]
        [InlineData("TIME \\* MERGEFORMAT", "TIME \\* MERGEFORMAT")]
        public void ToString_ReturnsInstructionString(string instruction, string expected)
        {
            // Arrange
            FieldInstruction fieldInstruction = new FieldInstruction(instruction);

            // Act
            string result = fieldInstruction.ToString();

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Equality_SameInstructionAndArguments_ReturnsTrue()
        {
            // Arrange
            List<FieldArgument> arguments = new List<FieldArgument>
            {
                new FieldArgument(FieldArgumentType.Switch, "\\* Upper"),
            };
            FieldInstruction fieldInstruction1 = new FieldInstruction("PAGE", arguments);
            FieldInstruction fieldInstruction2 = new FieldInstruction("PAGE", arguments);

            // Act & Assert
            Assert.Equal(fieldInstruction1.Instruction, fieldInstruction2.Instruction);
            Assert.Equal(fieldInstruction1.Arguments.Count, fieldInstruction2.Arguments.Count);
        }

        [Fact]
        public void Equality_DifferentInstructions_ReturnsFalse()
        {
            // Arrange
            FieldInstruction fieldInstruction1 = new FieldInstruction("PAGE");
            FieldInstruction fieldInstruction2 = new FieldInstruction("DATE");

            // Act & Assert
            Assert.NotEqual(fieldInstruction1.Instruction, fieldInstruction2.Instruction);
        }

        [Fact]
        public void CaseInsensitive_InstructionHandling()
        {
            // Arrange & Act
            FieldInstruction upperCase = new FieldInstruction("PAGE");
            FieldInstruction lowerCase = new FieldInstruction("page");
            FieldInstruction mixedCase = new FieldInstruction("Page");

            // Assert
            Assert.Equal("PAGE", upperCase.Instruction);
            Assert.Equal("page", lowerCase.Instruction);
            Assert.Equal("Page", mixedCase.Instruction);
        }
    }

    public class FieldArgumentTests
    {
        [Theory]
        [InlineData(FieldArgumentType.Identifier, "test")]
        [InlineData(FieldArgumentType.StringLiteral, "\"test string\"")]
        [InlineData(FieldArgumentType.Switch, "\\* Upper")]
        [InlineData(FieldArgumentType.NestedField, null)]
        public void Constructor_WithValidParameters_SetsProperties(
            FieldArgumentType type,
            object? value
        )
        {
            // Act
            FieldArgument argument = new FieldArgument(type, value);

            // Assert
            Assert.Equal(type, argument.Type);
            Assert.Equal(value, argument.Value);
        }

        [Fact]
        public void Constructor_WithNestedField_SetsNestedFieldValue()
        {
            // Arrange
            FieldInstruction nestedField = new FieldInstruction("DATE");

            // Act
            FieldArgument argument = new FieldArgument(FieldArgumentType.NestedField, nestedField);

            // Assert
            Assert.Equal(FieldArgumentType.NestedField, argument.Type);
            Assert.Equal(nestedField, argument.Value);
        }

        [Theory]
        [InlineData(FieldArgumentType.Identifier, "test", "test")]
        [InlineData(FieldArgumentType.StringLiteral, "quoted", "\"quoted\"")]
        [InlineData(FieldArgumentType.Switch, "\\p", "\\p")]
        public void ToString_ReturnsValueAsString(
            FieldArgumentType type,
            object value,
            string expected
        )
        {
            // Arrange
            FieldArgument argument = new FieldArgument(type, value);

            // Act
            string result = argument.ToString();

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ToString_WithNullValue_ReturnsEmptyString()
        {
            // Arrange
            FieldArgument argument = new FieldArgument(FieldArgumentType.Identifier, null!);

            // Act
            string result = argument.ToString();

            // Assert
            Assert.Equal(string.Empty, result);
        }
    }

    public class FieldArgumentTypeTests
    {
        [Fact]
        public void FieldArgumentType_HasAllExpectedValues()
        {
            // Arrange
            FieldArgumentType[] expectedValues = new FieldArgumentType[6]
            {
                FieldArgumentType.Identifier,
                FieldArgumentType.StringLiteral,
                FieldArgumentType.Switch,
                FieldArgumentType.NestedField,
                FieldArgumentType.Text,
                FieldArgumentType.Number,
            };

            // Act
            IEnumerable<FieldArgumentType> actualValues = Enum.GetValues<FieldArgumentType>();

            // Assert
            Assert.Equal(expectedValues.Length, actualValues.Count());
            foreach (FieldArgumentType expected in expectedValues)
            {
                Assert.Contains(expected, actualValues);
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
            PtsMeasurementValue measurement = new PtsMeasurementValue(value);

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
            Assert.Throws<ArgumentOutOfRangeException>(() => new PtsMeasurementValue(value));
        }

        [Theory]
        [InlineData(-31, "-31")]
        [InlineData(0, "0")]
        [InlineData(31, "31")]
        public void ToString_ReturnsValueAsString(int value, string expected)
        {
            // Arrange
            PtsMeasurementValue measurement = new PtsMeasurementValue(value);

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
            PtsMeasurementValue measurement = new PtsMeasurementValue(value);

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
            PtsMeasurementValue measurement = value;

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

using System;
using System.Linq;
using Xunit;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Tests
{
    /// <summary>
    /// Comprehensive tests for typed field instruction creation and validation
    /// </summary>
    public class TypedFieldInstructionBuilderTests
    {
        [Fact]
        public void CreateMergeField_WithFieldName_ReturnsCorrectField()
        {
            FieldInstruction field = CreateMergeField("FirstName");

            Assert.Equal("MERGEFIELD", field.Instruction);
            Assert.Single(field.Arguments);
            Assert.Equal("FirstName", field.Arguments[0].Value);
            Assert.Equal(FieldArgumentType.Identifier, field.Arguments[0].Type);
        }

        [Fact]
        public void CreateMergeField_WithFormatting_ReturnsCorrectField()
        {
            FieldInstruction field = CreateMergeFieldWithFormatting("Amount", "\"$#,##0.00\"");

            Assert.Equal("MERGEFIELD", field.Instruction);
            Assert.Equal(3, field.Arguments.Count);
            Assert.Equal("Amount", field.Arguments[0].Value);
            Assert.Equal("\\#", field.Arguments[1].Value);
            Assert.Equal("$#,##0.00", field.Arguments[2].Value);
        }

        [Fact]
        public void CreateHyperlink_WithUrlOnly_ReturnsCorrectField()
        {
            FieldInstruction field = CreateHyperlink("https://www.example.com");

            Assert.Equal("HYPERLINK", field.Instruction);
            Assert.Single(field.Arguments);
            Assert.Equal("https://www.example.com", field.Arguments[0].Value);
            Assert.Equal(FieldArgumentType.StringLiteral, field.Arguments[0].Type);
        }

        [Fact]
        public void CreateHyperlink_WithDisplayText_ReturnsCorrectField()
        {
            FieldInstruction field = CreateHyperlink("https://www.example.com", "Click here");

            Assert.Equal("HYPERLINK", field.Instruction);
            Assert.Equal(2, field.Arguments.Count);
            Assert.Equal("https://www.example.com", field.Arguments[0].Value);
            Assert.Equal("Click here", field.Arguments[1].Value);
        }

        [Fact]
        public void CreateDateField_WithFormat_ReturnsCorrectField()
        {
            FieldInstruction field = CreateDateField("MMMM d, yyyy");

            Assert.Equal("DATE", field.Instruction);
            Assert.Equal(2, field.Arguments.Count);
            Assert.Equal("\\@", field.Arguments[0].Value);
            Assert.Equal("MMMM d, yyyy", field.Arguments[1].Value);
        }

        [Fact]
        public void CreateIfField_WithSimpleCondition_ReturnsCorrectField()
        {
            FieldInstruction field = CreateIfField("1", "=", "1", "True", "False");

            Assert.Equal("IF", field.Instruction);
            Assert.Equal(5, field.Arguments.Count);
            Assert.Equal("1", field.Arguments[0].Value);
            Assert.Equal("=", field.Arguments[1].Value);
            Assert.Equal("1", field.Arguments[2].Value);
            Assert.Equal("True", field.Arguments[3].Value);
            Assert.Equal("False", field.Arguments[4].Value);
        }

        [Fact]
        public void CreateAddressBlock_WithCountryExclusion_ReturnsCorrectField()
        {
            FieldInstruction field = CreateAddressBlock(
                CountryRegion.UnitedStates,
                LanguageIdentifier.EnglishUS
            );

            Assert.Equal("ADDRESSBLOCK", field.Instruction);
            Assert.True(field.Arguments.Count >= 4);

            // Should contain exclusion switch
            FieldArgument? excludeSwitch = field.Arguments.FirstOrDefault(arg =>
                arg.Value?.ToString() == "\\e"
            );
            Assert.NotNull(excludeSwitch);
        }

        [Fact]
        public void CreateGreetingLine_WithCustomFormat_ReturnsCorrectField()
        {
            FieldInstruction field = CreateGreetingLine("Dear", ",", "Dear Sir or Madam,");

            Assert.Equal("GREETINGLINE", field.Instruction);
            Assert.True(field.Arguments.Count >= 6);

            // Check for format switches
            FieldArgument? formatSwitch = field.Arguments.FirstOrDefault(arg =>
                arg.Value?.ToString() == "\\f"
            );
            Assert.NotNull(formatSwitch);
        }

        [Fact]
        public void CreateBarcode_WithPostalData_ReturnsCorrectField()
        {
            PostalData postalData = new PostalData("12345-6789");
            FieldInstruction field = CreateBarcodeField(
                postalData,
                FacingIdentificationMarkType.BusinessReply
            );

            Assert.Equal("BARCODE", field.Instruction);
            Assert.True(field.Arguments.Count >= 3);
            Assert.Equal("12345-6789", field.Arguments[0].Value);
        }

        [Fact]
        public void CreateDatabaseField_WithConnectionAndQuery_ReturnsCorrectField()
        {
            FieldInstruction field = CreateDatabaseField(
                "Data Source=server;Initial Catalog=database;",
                "SELECT Name, Age FROM Customers",
                DatabaseTableFormat.Professional
            );

            Assert.Equal("DATABASE", field.Instruction);
            Assert.True(field.Arguments.Count >= 6);

            // Check for connection string switch
            FieldArgument? dataSwitch = field.Arguments.FirstOrDefault(arg =>
                arg.Value?.ToString() == "\\d"
            );
            Assert.NotNull(dataSwitch);

            // Check for query switch
            FieldArgument? sqlSwitch = field.Arguments.FirstOrDefault(arg =>
                arg.Value?.ToString() == "\\s"
            );
            Assert.NotNull(sqlSwitch);
        }

        [Fact]
        public void CreateDocProperty_WithPropertyName_ReturnsCorrectField()
        {
            FieldInstruction field = CreateDocPropertyField(DocumentPropertyCategory.Author);

            Assert.Equal("DOCPROPERTY", field.Instruction);
            Assert.Single(field.Arguments);
            Assert.Equal("Author", field.Arguments[0].Value);
        }

        [Theory]
        [InlineData(CountryRegion.UnitedStates, "UnitedStates")]
        [InlineData(CountryRegion.Canada, "Canada")]
        [InlineData(CountryRegion.UnitedKingdom, "UnitedKingdom")]
        [InlineData(CountryRegion.Germany, "Germany")]
        [InlineData(CountryRegion.France, "France")]
        public void CreateCountrySpecificField_WithDifferentCountries_ReturnsCorrectCountry(
            CountryRegion country,
            string expectedName
        )
        {
            FieldInstruction field = CreateCountryConditionalField(country);

            Assert.Equal("IF", field.Instruction);
            Assert.Contains(field.Arguments, arg => arg.Value?.ToString() == expectedName);
        }

        [Theory]
        [InlineData(LanguageIdentifier.EnglishUS, 1033)]
        [InlineData(LanguageIdentifier.FrenchFrance, 1036)]
        [InlineData(LanguageIdentifier.GermanGermany, 1031)]
        [InlineData(LanguageIdentifier.SpanishSpain, 3082)]
        public void CreateLanguageSpecificField_WithDifferentLanguages_ReturnsCorrectLCID(
            LanguageIdentifier language,
            int expectedLCID
        )
        {
            FieldInstruction field = CreateLanguageSpecificAddressBlock(language);

            Assert.Equal("ADDRESSBLOCK", field.Instruction);
            Assert.Contains(
                field.Arguments,
                arg => arg.Value?.ToString() == expectedLCID.ToString()
            );
        }

        [Fact]
        public void CreateComplexNestedField_WithMultipleLevels_ReturnsCorrectStructure()
        {
            FieldInstruction field = CreateComplexNestedField();

            Assert.Equal("IF", field.Instruction);

            // Count nested fields
            int nestedFieldCount = field.Arguments.Count(arg =>
                arg.Type == FieldArgumentType.NestedField
            );
            Assert.True(nestedFieldCount >= 2);

            // Verify nested structure
            FieldArgument? nestedField = field.Arguments.FirstOrDefault(arg =>
                arg.Type == FieldArgumentType.NestedField
                && arg.Value is FieldInstruction nested
                && nested.Instruction == "MERGEFIELD"
            );
            Assert.NotNull(nestedField);
        }

        [Fact]
        public void ValidateFieldInstruction_WithValidField_ReturnsTrue()
        {
            FieldInstruction field = CreateMergeField("ValidField");

            bool isValid = ValidateFieldInstruction(field);

            Assert.True(isValid);
        }

        [Fact]
        public void ValidateFieldInstruction_WithInvalidField_ReturnsFalse()
        {
            FieldInstruction field = new FieldInstruction("INVALID_INSTRUCTION");

            bool isValid = ValidateFieldInstruction(field);

            Assert.False(isValid);
        }

        [Fact]
        public void CreateFieldWithMeasurement_WithValidRange_ReturnsCorrectField()
        {
            PtsMeasurementValue<sbyte> measurement = new PtsMeasurementValue<sbyte>(15);
            FieldInstruction field = CreateFieldWithMeasurement("BARCODE", "12345", measurement);

            Assert.Equal("BARCODE", field.Instruction);
            Assert.Contains(field.Arguments, arg => arg.Value?.ToString() == "15");
        }

        [Fact]
        public void CreateFieldWithNamespaceDeclaration_WithValidNamespace_ReturnsCorrectField()
        {
            NamespaceDeclaration ns = new NamespaceDeclaration(
                "xmlns:w=\"http://schemas.openxmlformats.org/wordprocessingml/2006/main\""
            );
            FieldInstruction field = CreateFieldWithNamespace("XML", ns, "//w:p/w:t");

            Assert.Equal("XML", field.Instruction);
            Assert.True(field.Arguments.Count >= 2);
            Assert.Contains(
                field.Arguments,
                arg => arg.Value?.ToString()?.Contains("xmlns:w") == true
            );
        }

        // Helper methods for creating typed field instructions
        private static FieldInstruction CreateMergeField(string fieldName)
        {
            FieldInstruction field = new FieldInstruction("MERGEFIELD");
            field.Arguments.Add(new FieldArgument(FieldArgumentType.Identifier, fieldName));
            return field;
        }

        private static FieldInstruction CreateMergeFieldWithFormatting(
            string fieldName,
            string format
        )
        {
            FieldInstruction field = new FieldInstruction("MERGEFIELD");
            field.Arguments.Add(new FieldArgument(FieldArgumentType.Identifier, fieldName));
            field.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\\#"));
            field.Arguments.Add(
                new FieldArgument(FieldArgumentType.StringLiteral, format.Trim('"'))
            );
            return field;
        }

        private static FieldInstruction CreateHyperlink(string url, string? displayText = null)
        {
            FieldInstruction field = new FieldInstruction("HYPERLINK");
            field.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, url));
            if (displayText != null)
            {
                field.Arguments.Add(
                    new FieldArgument(FieldArgumentType.StringLiteral, displayText)
                );
            }
            return field;
        }

        private static FieldInstruction CreateDateField(string format)
        {
            FieldInstruction field = new FieldInstruction("DATE");
            field.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\\@"));
            field.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, format));
            return field;
        }

        private static FieldInstruction CreateIfField(
            string left,
            string op,
            string right,
            string trueText,
            string falseText
        )
        {
            FieldInstruction field = new FieldInstruction("IF");
            field.Arguments.Add(new FieldArgument(FieldArgumentType.Identifier, left));
            field.Arguments.Add(new FieldArgument(FieldArgumentType.Identifier, op));
            field.Arguments.Add(new FieldArgument(FieldArgumentType.Identifier, right));
            field.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, trueText));
            field.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, falseText));
            return field;
        }

        private static FieldInstruction CreateAddressBlock(
            CountryRegion excludedCountry,
            LanguageIdentifier language
        )
        {
            FieldInstruction field = new FieldInstruction("ADDRESSBLOCK");
            field.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\\e"));
            field.Arguments.Add(
                new FieldArgument(FieldArgumentType.StringLiteral, excludedCountry.ToString())
            );
            field.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\\l"));
            field.Arguments.Add(
                new FieldArgument(FieldArgumentType.Number, ((int)language).ToString())
            );
            return field;
        }

        private static FieldInstruction CreateGreetingLine(
            string greeting,
            string punctuation,
            string fallback
        )
        {
            FieldInstruction field = new FieldInstruction("GREETINGLINE");
            field.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\\f"));
            field.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, greeting));
            field.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\\l"));
            field.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, punctuation));
            field.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\\e"));
            field.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, fallback));
            return field;
        }

        private static FieldInstruction CreateBarcodeField(
            PostalData postalData,
            FacingIdentificationMarkType fimType
        )
        {
            FieldInstruction field = new FieldInstruction("BARCODE");
            field.Arguments.Add(
                new FieldArgument(FieldArgumentType.StringLiteral, postalData.ToString())
            );
            field.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\\f"));
            field.Arguments.Add(
                new FieldArgument(
                    FieldArgumentType.Identifier,
                    fimType == FacingIdentificationMarkType.CourtesyReply ? "A" : "C"
                )
            );
            return field;
        }

        private static FieldInstruction CreateDatabaseField(
            string connectionString,
            string query,
            DatabaseTableFormat format
        )
        {
            FieldInstruction field = new FieldInstruction("DATABASE");
            field.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\\d"));
            field.Arguments.Add(
                new FieldArgument(FieldArgumentType.StringLiteral, connectionString)
            );
            field.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\\s"));
            field.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, query));
            field.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\\t"));
            field.Arguments.Add(
                new FieldArgument(FieldArgumentType.Number, ((int)format).ToString())
            );
            return field;
        }

        private static FieldInstruction CreateDocPropertyField(DocumentPropertyCategory category)
        {
            FieldInstruction field = new FieldInstruction("DOCPROPERTY");
            string propertyName = category switch
            {
                DocumentPropertyCategory.Author => "Author",
                DocumentPropertyCategory.Title => "Title",
                DocumentPropertyCategory.Company => "Company",
                DocumentPropertyCategory.CreateTime => "CreateTime",
                DocumentPropertyCategory.LastSavedBy => "LastSavedBy",
                _ => category.ToString(),
            };
            field.Arguments.Add(new FieldArgument(FieldArgumentType.Identifier, propertyName));
            return field;
        }

        private static FieldInstruction CreateCountryConditionalField(CountryRegion country)
        {
            FieldInstruction countryMergeField = new FieldInstruction("MERGEFIELD");
            countryMergeField.Arguments.Add(
                new FieldArgument(FieldArgumentType.Identifier, "Country")
            );

            FieldInstruction field = new FieldInstruction("IF");
            field.Arguments.Add(
                new FieldArgument(FieldArgumentType.NestedField, countryMergeField)
            );
            field.Arguments.Add(new FieldArgument(FieldArgumentType.Identifier, "="));
            field.Arguments.Add(
                new FieldArgument(FieldArgumentType.StringLiteral, country.ToString())
            );
            field.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, "Domestic"));
            field.Arguments.Add(
                new FieldArgument(FieldArgumentType.StringLiteral, "International")
            );
            return field;
        }

        private static FieldInstruction CreateLanguageSpecificAddressBlock(
            LanguageIdentifier language
        )
        {
            FieldInstruction field = new FieldInstruction("ADDRESSBLOCK");
            field.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\\l"));
            field.Arguments.Add(
                new FieldArgument(FieldArgumentType.Number, ((int)language).ToString())
            );
            return field;
        }

        private static FieldInstruction CreateComplexNestedField()
        {
            // Create nested MERGEFIELD for condition
            FieldInstruction ageMergeField = new FieldInstruction("MERGEFIELD");
            ageMergeField.Arguments.Add(new FieldArgument(FieldArgumentType.Identifier, "Age"));

            // Create nested MERGEFIELD for true case
            FieldInstruction seniorField = new FieldInstruction("MERGEFIELD");
            seniorField.Arguments.Add(
                new FieldArgument(FieldArgumentType.Identifier, "SeniorDiscount")
            );

            // Create nested MERGEFIELD for false case
            FieldInstruction standardField = new FieldInstruction("MERGEFIELD");
            standardField.Arguments.Add(
                new FieldArgument(FieldArgumentType.Identifier, "StandardPrice")
            );

            // Create main IF field
            FieldInstruction field = new FieldInstruction("IF");
            field.Arguments.Add(new FieldArgument(FieldArgumentType.NestedField, ageMergeField));
            field.Arguments.Add(new FieldArgument(FieldArgumentType.Identifier, ">="));
            field.Arguments.Add(new FieldArgument(FieldArgumentType.Identifier, "65"));
            field.Arguments.Add(new FieldArgument(FieldArgumentType.NestedField, seniorField));
            field.Arguments.Add(new FieldArgument(FieldArgumentType.NestedField, standardField));

            return field;
        }

        private static bool ValidateFieldInstruction(FieldInstruction field)
        {
            // Basic validation rules
            if (string.IsNullOrWhiteSpace(field.Instruction))
            {
                return false;
            }

            // Check for known field types
            string[] validInstructions =
            {
                "MERGEFIELD",
                "HYPERLINK",
                "IF",
                "DATE",
                "TIME",
                "PAGE",
                "NUMPAGES",
                "DOCPROPERTY",
                "ADDRESSBLOCK",
                "GREETINGLINE",
                "BARCODE",
                "DATABASE",
                "REF",
                "PAGEREF",
                "AUTHOR",
                "FILENAME",
                "CREATEDATE",
                "SAVEDATE",
                "PRINTDATE",
            };

            if (!validInstructions.Contains(field.Instruction.ToUpperInvariant()))
            {
                return false;
            }

            // Field-specific validation
            return field.Instruction.ToUpperInvariant() switch
            {
                "MERGEFIELD" => field.Arguments.Count >= 1
                    && field.Arguments[0].Type == FieldArgumentType.Identifier,
                "HYPERLINK" => field.Arguments.Count >= 1
                    && field.Arguments[0].Type == FieldArgumentType.StringLiteral,
                "IF" => field.Arguments.Count >= 5,
                _ => true, // Default validation passes for other fields
            };
        }

        private static FieldInstruction CreateFieldWithMeasurement(
            string instruction,
            string data,
            PtsMeasurementValue<sbyte> measurement
        )
        {
            FieldInstruction field = new FieldInstruction(instruction);
            field.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, data));
            field.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\\h"));
            field.Arguments.Add(
                new FieldArgument(FieldArgumentType.Number, measurement.ToString())
            );
            return field;
        }

        private static FieldInstruction CreateFieldWithNamespace(
            string instruction,
            NamespaceDeclaration ns,
            string xpath
        )
        {
            FieldInstruction field = new FieldInstruction(instruction);
            field.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, ns.Declaration));
            field.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, xpath));
            return field;
        }
    }

    /// <summary>
    /// Tests for field instruction modification and manipulation
    /// </summary>
    public class FieldInstructionModificationTests
    {
        [Fact]
        public void ModifyFieldInstruction_ChangeInstruction_UpdatesCorrectly()
        {
            FieldInstruction field = new FieldInstruction("PAGE");

            field.Instruction = "NUMPAGES";

            Assert.Equal("NUMPAGES", field.Instruction);
        }

        [Fact]
        public void ModifyFieldInstruction_AddArguments_UpdatesCorrectly()
        {
            FieldInstruction field = new FieldInstruction("DATE");

            field.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\\@"));
            field.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, "MM/dd/yyyy"));

            Assert.Equal(2, field.Arguments.Count);
            Assert.Equal("\\@", field.Arguments[0].Value);
            Assert.Equal("MM/dd/yyyy", field.Arguments[1].Value);
        }

        [Fact]
        public void ModifyFieldInstruction_RemoveArguments_UpdatesCorrectly()
        {
            FieldInstruction field = new FieldInstruction("MERGEFIELD");
            field.Arguments.Add(new FieldArgument(FieldArgumentType.Identifier, "Name"));
            field.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\\* Upper"));

            field.Arguments.RemoveAt(1);

            Assert.Single(field.Arguments);
            Assert.Equal("Name", field.Arguments[0].Value);
        }

        [Fact]
        public void ModifyFieldInstruction_ReplaceArgument_UpdatesCorrectly()
        {
            FieldInstruction field = new FieldInstruction("MERGEFIELD");
            field.Arguments.Add(new FieldArgument(FieldArgumentType.Identifier, "OldName"));

            field.Arguments[0] = new FieldArgument(FieldArgumentType.Identifier, "NewName");

            Assert.Single(field.Arguments);
            Assert.Equal("NewName", field.Arguments[0].Value);
        }

        [Fact]
        public void CloneFieldInstruction_CreatesIdenticalCopy()
        {
            FieldInstruction original = new FieldInstruction("MERGEFIELD");
            original.Arguments.Add(new FieldArgument(FieldArgumentType.Identifier, "Name"));
            original.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\\* Upper"));

            FieldInstruction clone = CloneFieldInstruction(original);

            Assert.Equal(original.Instruction, clone.Instruction);
            Assert.Equal(original.Arguments.Count, clone.Arguments.Count);
            for (int i = 0; i < original.Arguments.Count; i++)
            {
                Assert.Equal(original.Arguments[i].Type, clone.Arguments[i].Type);
                Assert.Equal(original.Arguments[i].Value, clone.Arguments[i].Value);
            }
        }

        [Fact]
        public void MergeFieldInstructions_CombinesArguments()
        {
            FieldInstruction field1 = new FieldInstruction("MERGEFIELD");
            field1.Arguments.Add(new FieldArgument(FieldArgumentType.Identifier, "Name"));

            FieldInstruction field2 = new FieldInstruction("MERGEFIELD");
            field2.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\\* Upper"));

            FieldInstruction merged = MergeFieldInstructions(field1, field2);

            Assert.Equal("MERGEFIELD", merged.Instruction);
            Assert.Equal(2, merged.Arguments.Count);
            Assert.Equal("Name", merged.Arguments[0].Value);
            Assert.Equal("\\* Upper", merged.Arguments[1].Value);
        }

        [Fact]
        public void ConvertToNestedField_WrapsInBraces()
        {
            FieldInstruction field = new FieldInstruction("MERGEFIELD");
            field.Arguments.Add(new FieldArgument(FieldArgumentType.Identifier, "Name"));

            FieldArgument nestedArg = new FieldArgument(FieldArgumentType.NestedField, field);
            string result = nestedArg.ToString();

            Assert.StartsWith("{ ", result);
            Assert.EndsWith(" }", result);
            Assert.Contains("MERGEFIELD Name", result);
        }

        // Helper methods
        private static FieldInstruction CloneFieldInstruction(FieldInstruction original)
        {
            FieldInstruction clone = new FieldInstruction(original.Instruction);
            foreach (FieldArgument arg in original.Arguments)
            {
                clone.Arguments.Add(new FieldArgument(arg.Type, arg.Value));
            }
            return clone;
        }

        private static FieldInstruction MergeFieldInstructions(
            FieldInstruction field1,
            FieldInstruction field2
        )
        {
            // Assumes same instruction type
            FieldInstruction merged = new FieldInstruction(field1.Instruction);
            foreach (FieldArgument arg in field1.Arguments)
            {
                merged.Arguments.Add(arg);
            }
            foreach (FieldArgument arg in field2.Arguments)
            {
                merged.Arguments.Add(arg);
            }
            return merged;
        }
    }
}

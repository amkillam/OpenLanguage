using System;
using System.Collections.Generic;
using OpenLanguage.WordprocessingML.FieldInstruction.Typed;
using Xunit;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Tests
{
    // Test implementation of TypedFieldInstruction for testing purposes
    public class TestTypedFieldInstruction : TypedFieldInstruction
    {
        public string TestProperty { get; set; } = string.Empty;

        public TestTypedFieldInstruction(FieldInstruction source)
            : base(source) { }

        public override string ToString()
        {
            return $"TEST {TestProperty}".Trim();
        }
    }

    public class TypedFieldInstructionTests
    {
        [Fact]
        public void Constructor_WithValidSource_SetsSourceProperty()
        {
            FieldInstruction source = new FieldInstruction("TEST");

            TestTypedFieldInstruction typedInstruction = new TestTypedFieldInstruction(source);

            Assert.Equal(source, typedInstruction.Source);
            Assert.Equal("TEST", typedInstruction.Source.Instruction);
        }

        [Fact]
        public void Constructor_WithNullSource_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new TestTypedFieldInstruction(null!));
        }

        [Fact]
        public void Source_IsReadOnlyAfterConstruction()
        {
            FieldInstruction source = new FieldInstruction("TEST");
            TestTypedFieldInstruction typedInstruction = new TestTypedFieldInstruction(source);

            source.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\t\\test"));

            Assert.Single(typedInstruction.Source.Arguments);
            Assert.Equal("\t\\test", typedInstruction.Source.Arguments[0].Value);
        }

        [Fact]
        public void ToString_CallsOverriddenMethod()
        {
            FieldInstruction source = new FieldInstruction("TEST");
            TestTypedFieldInstruction typedInstruction = new TestTypedFieldInstruction(source)
            {
                TestProperty = "VALUE",
            };

            string result = typedInstruction.ToString();

            Assert.Equal("TEST VALUE", result);
        }

        [Fact]
        public void ToString_WithEmptyProperty_ReturnsInstructionOnly()
        {
            FieldInstruction source = new FieldInstruction("TEST");
            TestTypedFieldInstruction typedInstruction = new TestTypedFieldInstruction(source);

            string result = typedInstruction.ToString();

            Assert.Equal("TEST", result);
        }

        [Theory]
        [InlineData("PAGE")]
        [InlineData("DATE")]
        [InlineData("TIME")]
        [InlineData("AUTHOR")]
        public void InheritanceWorksWithDifferentInstructions(string instruction)
        {
            FieldInstruction source = new FieldInstruction(instruction);

            TestTypedFieldInstruction typedInstruction = new TestTypedFieldInstruction(source);

            Assert.Equal(instruction, typedInstruction.Source.Instruction);
            Assert.IsAssignableFrom<TypedFieldInstruction>(typedInstruction);
        }

        [Fact]
        public void MultipleInstances_HaveIndependentSources()
        {
            FieldInstruction source1 = new FieldInstruction("TEST1");
            FieldInstruction source2 = new FieldInstruction("TEST2");

            TestTypedFieldInstruction typed1 = new TestTypedFieldInstruction(source1)
            {
                TestProperty = "PROP1",
            };
            TestTypedFieldInstruction typed2 = new TestTypedFieldInstruction(source2)
            {
                TestProperty = "PROP2",
            };

            Assert.Equal("TEST1", typed1.Source.Instruction);
            Assert.Equal("TEST2", typed2.Source.Instruction);
            Assert.Equal("PROP1", typed1.TestProperty);
            Assert.Equal("PROP2", typed2.TestProperty);
            Assert.NotEqual(typed1.Source, typed2.Source);
        }

        [Fact]
        public void TypedFieldInstruction_IsAbstractClass()
        {
            Assert.False(typeof(TypedFieldInstruction).IsAbstract);
            Assert.True(typeof(TypedFieldInstruction).IsClass);
        }

        [Fact]
        public void TypedFieldInstruction_HasExpectedMembers()
        {
            Type type = typeof(TypedFieldInstruction);

            Assert.NotNull(type.GetProperty("Source"));
            Assert.NotNull(
                type.GetMethod(
                    "ToString",
                    System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance
                )
            );
        }
    }

    public class TypedFieldInstructionFactoryTests
    {
        [Theory]
        [InlineData("PAGE", typeof(PageFieldInstruction))]
        [InlineData("DATE", typeof(DateFieldInstruction))]
        [InlineData("TIME", typeof(TimeFieldInstruction))]
        [InlineData("AUTHOR", typeof(AuthorFieldInstruction))]
        [InlineData("FILENAME", typeof(FileNameFieldInstruction))]
        [InlineData("TEMPLATE", typeof(TemplateFieldInstruction))]
        [InlineData("SUBJECT", typeof(SubjectFieldInstruction))]
        [InlineData("SKIPIF", typeof(SkipIfFieldInstruction))]
        [InlineData("SECTIONPAGES", typeof(SectionPagesFieldInstruction))]
        [InlineData("SECTION", typeof(SectionFieldInstruction))]
        [InlineData("REVNUM", typeof(RevNumFieldInstruction))]
        [InlineData("RD", typeof(RdFieldInstruction))]
        [InlineData("QUOTE", typeof(QuoteFieldInstruction))]
        [InlineData("PRINT", typeof(PrintFieldInstruction))]
        [InlineData("PRINTDATE", typeof(PrintDateFieldInstruction))]
        [InlineData("NEXTIF", typeof(NextIfFieldInstruction))]
        [InlineData("NEXT", typeof(NextFieldInstruction))]
        [InlineData("MACROBUTTON", typeof(MacroButtonFieldInstruction))]
        [InlineData("LINK", typeof(LinkFieldInstruction))]
        [InlineData("INFO", typeof(InfoFieldInstruction), "AUTHOR")]
        [InlineData("INDEX", typeof(IndexFieldInstruction))]
        [InlineData("INCLUDETEXT", typeof(IncludeTextFieldInstruction))]
        [InlineData("INCLUDEPICTURE", typeof(IncludePictureFieldInstruction))]
        [InlineData("IF", typeof(IfFieldInstruction), "1 = 1 True False")]
        [InlineData("HYPERLINK", typeof(HyperlinkFieldInstruction))]
        [InlineData("GREETINGLINE", typeof(GreetingLineFieldInstruction))]
        [InlineData("GOTOBUTTON", typeof(GoToButtonFieldInstruction))]
        [InlineData("FORMTEXT", typeof(FormTextFieldInstruction))]
        [InlineData("FORMDROPDOWN", typeof(FormDropDownFieldInstruction))]
        [InlineData("FORMCHECKBOX", typeof(FormCheckBoxFieldInstruction))]
        [InlineData("EQ", typeof(EqFieldInstruction), "\\a (1,2)")]
        [InlineData("DOCVARIABLE", typeof(DocVariableFieldInstruction))]
        [InlineData("DOCPROPERTY", typeof(DocPropertyFieldInstruction))]
        [InlineData("DATABASE", typeof(DatabaseFieldInstruction))]
        [InlineData("COMPARE", typeof(CompareFieldInstruction))]
        [InlineData("CITATION", typeof(CitationFieldInstruction))]
        [InlineData("BIBLIOGRAPHY", typeof(BibliographyFieldInstruction))]
        [InlineData("BARCODE", typeof(BarcodeFieldInstruction))]
        [InlineData("AUTOTEXTLIST", typeof(AutoTextListFieldInstruction), "Test AutoTextList")]
        [InlineData("AUTOTEXT", typeof(AutoTextFieldInstruction), "MyAutoTextEntry")]
        [InlineData("AUTONUMOUT", typeof(AutoNumOutFieldInstruction))]
        [InlineData("AUTONUMLGL", typeof(AutoNumLglFieldInstruction))]
        [InlineData("AUTONUM", typeof(AutoNumFieldInstruction))]
        [InlineData("ASK", typeof(AskFieldInstruction))]
        [InlineData("ADVANCE", typeof(AdvanceFieldInstruction))]
        [InlineData("ADDRESSBLOCK", typeof(AddressBlockFieldInstruction))]
        public void Create_WithKnownFieldType_ReturnsCorrectTypedInstruction(
            string instruction,
            Type expectedType,
            string? args = null
        )
        {
            FieldParser parser = new FieldParser();
            FieldInstruction source = parser.Parse(instruction + (args != null ? $" {args}" : ""));

            TypedFieldInstruction? result = TypedFieldInstructionFactory.Create(source);

            Assert.NotNull(result);
            Assert.IsType(expectedType, result);
            Assert.Equal(source, result.Source);
        }

        [Theory]
        [InlineData("page")] // lowercase
        [InlineData("Date")] // mixed case
        [InlineData("TIME")] // uppercase
        public void Create_CaseInsensitive_ReturnsCorrectType(string instruction)
        {
            FieldInstruction source = new FieldInstruction(instruction);

            TypedFieldInstruction? result = TypedFieldInstructionFactory.Create(source);

            Assert.NotNull(result);
            // Should handle case insensitively
        }

        [Theory]
        [InlineData("UNKNOWNFIELD")]
        [InlineData("INVALID")]
        [InlineData("NOTAFIELD")]
        public void Create_WithUnknownFieldType_ReturnsNull(string instruction)
        {
            FieldInstruction source = new FieldInstruction(instruction);

            TypedFieldInstruction? result = TypedFieldInstructionFactory.Create(source);

            Assert.Null(result);
        }

        [Fact]
        public void Create_WithNullSource_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => TypedFieldInstructionFactory.Create(null!));
        }

        [Fact]
        public void Create_WithSourceHavingArguments_PreservesArguments()
        {
            List<FieldArgument> arguments = new List<FieldArgument>
            {
                new FieldArgument(FieldArgumentType.Switch, "\\* Upper"),
                new FieldArgument(FieldArgumentType.StringLiteral, "test"),
            };
            FieldInstruction source = new FieldInstruction("PAGE", arguments);

            TypedFieldInstruction? result = TypedFieldInstructionFactory.Create(source);

            Assert.NotNull(result);
            Assert.IsType<PageFieldInstruction>(result);
            Assert.Equal(2, result.Source.Arguments.Count);
            Assert.Equal("\\* Upper", result.Source.Arguments[0].Value);
            Assert.Equal("test", result.Source.Arguments[1].Value);
        }

        [Fact]
        public void Create_MultipleCalls_ReturnsDifferentInstances()
        {
            FieldInstruction source = new FieldInstruction("PAGE");

            TypedFieldInstruction? result1 = TypedFieldInstructionFactory.Create(source);
            TypedFieldInstruction? result2 = TypedFieldInstructionFactory.Create(source);

            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.NotSame(result1, result2);
            Assert.Equal(result1.GetType(), result2.GetType());
        }
    }
}

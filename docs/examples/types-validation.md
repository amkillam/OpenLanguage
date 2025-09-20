# Working with Data Types and Validation

This document demonstrates how to use the specialized data types and validation classes provided by OpenLanguage WordprocessingML.

## Measurement Values (PtsMeasurementValue)

### Basic Usage

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction;

// Create measurement values within valid range (-31 to 31 points)
PtsMeasurementValue<int> smallMargin = new PtsMeasurementValue<int>(5);
PtsMeasurementValue<int> largeMargin = new PtsMeasurementValue<int>(20);
PtsMeasurementValue<int> negativeOffset = new PtsMeasurementValue<int>(-10);

Console.WriteLine($"Small margin: {smallMargin} points");
Console.WriteLine($"Large margin: {largeMargin} points");
Console.WriteLine($"Negative offset: {negativeOffset} points");

// Implicit conversion from int
PtsMeasurementValue<int> converted = 15;
Console.WriteLine($"Converted value: {converted}");

// Implicit conversion to int
int pointValue = converted;
Console.WriteLine($"Point value: {pointValue}");
```

### Validation and Error Handling

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction;
using System;

// Test boundary values
int[] testValues = { -32, -31, 0, 31, 32 };

foreach (int value in testValues)
{
    try
    {
        PtsMeasurementValue<int> measurement = new PtsMeasurementValue<int>(value);
        Console.WriteLine($"✓ Valid: {value} points = {measurement}");
    }
    catch (ArgumentOutOfRangeException ex)
    {
        Console.WriteLine($"✗ Invalid: {value} points - {ex.Message}");
    }
}
```

### Practical Applications

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction;

public class DocumentFormatter
{
    public static FieldInstruction CreatePositionedBarcode(
        string barcodeData,
        PtsMeasurementValue horizontalOffset,
        PtsMeasurementValue verticalOffset)
    {
        var field = new FieldInstruction("BARCODE");
        field.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, barcodeData));
        field.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\h"));
        field.Arguments.Add(new FieldArgument(FieldArgumentType.Number, horizontalOffset.ToString()));
        field.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\v"));
        field.Arguments.Add(new FieldArgument(FieldArgumentType.Number, verticalOffset.ToString()));

        return field;
    }
}

// Usage
PtsMeasurementValue leftMargin = 10;
PtsMeasurementValue topMargin = -5;

FieldInstruction barcode = DocumentFormatter.CreatePositionedBarcode(
    "123456789",
    leftMargin,
    topMargin
);

Console.WriteLine($"Positioned barcode field: {barcode}");
```

## Postal Data Validation (PostalData)

### ZIP Code Validation

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction;

// Valid ZIP code formats
string[] validZipCodes = {
    "12345",        // 5-digit
    "12345-6789",   // 9-digit with hyphen
    "123456789"     // 9-digit without hyphen
};

foreach (string zip in validZipCodes)
{
    try
    {
        PostalData postalData = new PostalData(zip);
        Console.WriteLine($"✓ Valid ZIP: {postalData}");

        // Implicit conversion
        string zipString = postalData;
        Console.WriteLine($"  As string: {zipString}");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"✗ Invalid ZIP: {zip} - {ex.Message}");
    }
}
```

### Invalid ZIP Code Handling

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction;
using System;

string[] invalidZipCodes = {
    "",             // Empty
    "1234",         // Too short
    "123456",       // Invalid length
    "12345-678",    // Invalid 9-digit format
    "12345-67890",  // Too long
    "abcde",        // Non-numeric
    "12345-abcd"    // Non-numeric extension
};

foreach (string zip in invalidZipCodes)
{
    try
    {
        PostalData postalData = new PostalData(zip);
        Console.WriteLine($"Unexpectedly valid: {postalData}");
    }
    catch (ArgumentException)
    {
        Console.WriteLine($"✓ Correctly rejected: '{zip}'");
    }
}
```

### Integration with Mail Merge Fields

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction;

public class AddressFieldGenerator
{
    public static FieldInstruction CreateBarcodeField(PostalData zipCode, FacingIdentificationMarkType fimType)
    {
        var field = new FieldInstruction("BARCODE");
        field.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, zipCode.ToString()));

        // Add FIM type
        field.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\f"));
        string fimValue = fimType == FacingIdentificationMarkType.CourtesyReply ? "A" : "C";
        field.Arguments.Add(new FieldArgument(FieldArgumentType.Identifier, fimValue));

        return field;
    }

    public static FieldInstruction CreateConditionalZipField(string mergeFieldName)
    {
        // Create IF field that validates ZIP code format
        var ifField = new FieldInstruction("IF");

        // Create nested MERGEFIELD for ZIP code
        var zipMergeField = new FieldInstruction("MERGEFIELD");
        zipMergeField.Arguments.Add(new FieldArgument(FieldArgumentType.Identifier, mergeFieldName));

        ifField.Arguments.Add(new FieldArgument(FieldArgumentType.NestedField, zipMergeField));
        ifField.Arguments.Add(new FieldArgument(FieldArgumentType.Identifier, "<>"));
        ifField.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, ""));
        ifField.Arguments.Add(new FieldArgument(FieldArgumentType.NestedField, zipMergeField));
        ifField.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, "No ZIP code"));

        return ifField;
    }
}

// Usage
PostalData validZip = "12345-6789";
FieldInstruction barcodeField = AddressFieldGenerator.CreateBarcodeField(
    validZip,
    FacingIdentificationMarkType.BusinessReply
);

FieldInstruction conditionalZip = AddressFieldGenerator.CreateConditionalZipField("PostalCode");

Console.WriteLine($"Barcode field: {barcodeField}");
Console.WriteLine($"Conditional ZIP field: {conditionalZip}");
```

## XML Namespace Declarations (NamespaceDeclaration)

### Basic Namespace Handling

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction;

// Valid namespace declarations
string[] validDeclarations = {
    "xmlns:w="http://schemas.openxmlformats.org/wordprocessingml/2006/main"",
    "xmlns:r="http://schemas.openxmlformats.org/officeDocument/2006/relationships"",
    "xmlns:wp="http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing"",
    "xmlns:custom="http://example.com/custom-namespace""
};

foreach (string declaration in validDeclarations)
{
    try
    {
        NamespaceDeclaration ns = new NamespaceDeclaration(declaration);
        Console.WriteLine($"✓ Valid namespace:");
        Console.WriteLine($"  Prefix: {ns.Prefix}");
        Console.WriteLine($"  URI: {ns.Uri}");
        Console.WriteLine($"  Declaration: {ns.Declaration}");
        Console.WriteLine();
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"✗ Invalid: {declaration} - {ex.Message}");
    }
}
```

### Invalid Namespace Handling

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction;
using System;

string[] invalidDeclarations = {
    "",                                              // Empty
    "xmlns:prefix=uri",                             // Missing quotes
    "prefix="http://example.com"",                // Missing xmlns:
    "xmlns:="http://example.com"",                // Empty prefix
    "xmlns:invalid-prefix="http://example.com"",  // Invalid prefix character
    "xmlns:prefix=""",                            // Empty URI
    "xmlns:prefix=http://example.com",              // Missing quotes around URI
};

foreach (string declaration in invalidDeclarations)
{
    try
    {
        NamespaceDeclaration ns = new NamespaceDeclaration(declaration);
        Console.WriteLine($"Unexpectedly valid: {ns}");
    }
    catch (ArgumentException)
    {
        Console.WriteLine($"✓ Correctly rejected: '{declaration}'");
    }
}
```

### Working with XML in Fields

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction;
using System.Xml.Linq;

public class XmlFieldProcessor
{
    public static FieldInstruction CreateXmlField(NamespaceDeclaration namespaceDecl, string xpath)
    {
        var field = new FieldInstruction("XML");
        field.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, namespaceDecl.Declaration));
        field.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, xpath));

        return field;
    }

    public static void ProcessXmlNamespace(NamespaceDeclaration namespaceDecl)
    {
        // Use the validated namespace in XML processing
        XNamespace ns = namespaceDecl.Namespace;
        XName elementName = ns + "element";

        Console.WriteLine($"Created XName: {elementName}");
        Console.WriteLine($"Namespace: {elementName.Namespace}");
        Console.WriteLine($"Local name: {elementName.LocalName}");
    }
}

// Usage
NamespaceDeclaration wordNamespace = "xmlns:w="http://schemas.openxmlformats.org/wordprocessingml/2006/main"";
FieldInstruction xmlField = XmlFieldProcessor.CreateXmlField(wordNamespace, "//w:p/w:t");

Console.WriteLine($"XML field: {xmlField}");

XmlFieldProcessor.ProcessXmlNamespace(wordNamespace);
```

## Enumeration Usage Examples

### Document Property Categories

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction;

public class DocumentPropertyFieldGenerator
{
    public static FieldInstruction CreateDocPropertyField(DocumentPropertyCategory category)
    {
        var field = new FieldInstruction("DOCPROPERTY");

        string propertyName = category switch
        {
            DocumentPropertyCategory.Author => "Author",
            DocumentPropertyCategory.Title => "Title",
            DocumentPropertyCategory.Company => "Company",
            DocumentPropertyCategory.CreateTime => "CreateTime",
            DocumentPropertyCategory.LastSavedBy => "LastSavedBy",
            DocumentPropertyCategory.Pages => "Pages",
            DocumentPropertyCategory.Words => "Words",
            DocumentPropertyCategory.Characters => "Characters",
            _ => category.ToString()
        };

        field.Arguments.Add(new FieldArgument(FieldArgumentType.Identifier, propertyName));
        return field;
    }
}

// Usage
DocumentPropertyCategory[] properties = {
    DocumentPropertyCategory.Author,
    DocumentPropertyCategory.Title,
    DocumentPropertyCategory.Company,
    DocumentPropertyCategory.Pages,
    DocumentPropertyCategory.Words
};

foreach (var property in properties)
{
    FieldInstruction field = DocumentPropertyFieldGenerator.CreateDocPropertyField(property);
    Console.WriteLine($"{property}: {field}");
}
```

### Database Table Attributes

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction;

public class DatabaseFieldGenerator
{
    public static FieldInstruction CreateDatabaseField(
        string connectionString,
        string query,
        DatabaseTableFormat format,
        DatabaseTableAttributes attributes)
    {
        var field = new FieldInstruction("DATABASE");

        // Add connection string
        field.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\d"));
        field.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, connectionString));

        // Add SQL query
        field.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\s"));
        field.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, query));

        // Add table format
        field.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\t"));
        field.Arguments.Add(new FieldArgument(FieldArgumentType.Number, ((int)format).ToString()));

        // Add attributes (bitwise combination)
        if (attributes != DatabaseTableAttributes.None)
        {
            field.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\a"));
            field.Arguments.Add(new FieldArgument(FieldArgumentType.Number, ((int)attributes).ToString()));
        }

        return field;
    }
}

// Usage with combined attributes
DatabaseTableAttributes combinedAttributes =
    DatabaseTableAttributes.Borders |
    DatabaseTableAttributes.Shading |
    DatabaseTableAttributes.HeadingRows;

FieldInstruction dbField = DatabaseFieldGenerator.CreateDatabaseField(
    "Data Source=server;Initial Catalog=database;",
    "SELECT Name, Age, Salary FROM Employees",
    DatabaseTableFormat.Professional,
    combinedAttributes
);

Console.WriteLine($"Database field: {dbField}");
Console.WriteLine($"Attributes value: {(int)combinedAttributes}"); // Shows bitwise combination
```

### Frame Targets and Country Regions

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction;

public class HyperlinkFieldGenerator
{
    public static FieldInstruction CreateHyperlinkWithTarget(string url, string displayText, FrameTarget target)
    {
        var field = new FieldInstruction("HYPERLINK");
        field.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, url));
        field.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, displayText));

        // Add frame target
        field.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\t"));
        field.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, FrameTargetUtils.FrameTargetText(target)));

        return field;
    }

    public static FieldInstruction CreateLocalizedAddressBlock(CountryRegion excludedCountry)
    {
        var field = new FieldInstruction("ADDRESSBLOCK");

        // Exclude specific country from address block
        field.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\e"));
        field.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, excludedCountry.ToString()));

        return field;
    }
}

// Usage
FrameTarget[] targets = { FrameTarget.Blank, FrameTarget.Self, FrameTarget.Top };

foreach (var target in targets)
{
    FieldInstruction hyperlink = HyperlinkFieldGenerator.CreateHyperlinkWithTarget(
        "https://example.com",
        "Example Link",
        target
    );
    Console.WriteLine($"Target {target}: {hyperlink}");
}

// Country-specific address block
FieldInstruction addressBlock = HyperlinkFieldGenerator.CreateLocalizedAddressBlock(CountryRegion.UnitedStates);
Console.WriteLine($"Address block excluding US: {addressBlock}");
```

This comprehensive example demonstrates how to work with the various data types, validation classes, and enumerations provided by the OpenLanguage WordprocessingML system for robust document processing applications.

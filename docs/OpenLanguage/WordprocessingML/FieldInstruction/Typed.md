# Typed Field Instructions

The typed field instruction system provides strongly-typed, compile-time safe handling of Word field instructions with full IntelliSense support.

## Overview

The typed system offers:

- **Compile-Time Safety**: Catch field instruction errors at compile time
- **IntelliSense Support**: Full IDE support with autocomplete and documentation
- **Type-Specific APIs**: Specialized methods for each field type
- **Fluent Interface**: Chainable method calls for building complex fields

## Core Interfaces

### ITypedFieldInstruction<T>

Base interface for all typed field instructions:

```csharp
public interface ITypedFieldInstruction<T> where T : ITypedFieldInstruction<T>
{
    string FieldType { get; }
    IReadOnlyList<FieldSwitch> Switches { get; }
    string ToFieldCode();
    T WithSwitch(FieldSwitch switch);
    T WithFormat(string format);
}
```

## Typed Field Classes

### MergeFieldInstruction

Strongly-typed merge field with validation:

```csharp
var mergeField = new MergeFieldInstruction("FirstName")
    .WithFormat(MergeFormat.Upper)
    .WithMergeFormat();

Console.WriteLine(mergeField.ToFieldCode());
// Output: MERGEFIELD FirstName \* UPPER \* MERGEFORMAT
```

#### Available Methods

```csharp
public class MergeFieldInstruction : ITypedFieldInstruction<MergeFieldInstruction>
{
    // Constructors
    public MergeFieldInstruction(string fieldName);

    // Formatting methods
    public MergeFieldInstruction WithFormat(MergeFormat format);
    public MergeFieldInstruction WithMergeFormat();
    public MergeFieldInstruction WithCaps();
    public MergeFieldInstruction WithFirstCap();
    public MergeFieldInstruction WithLower();
    public MergeFieldInstruction WithUpper();

    // Properties
    public string FieldName { get; }
    public MergeFormat Format { get; }
    public bool PreserveFormatting { get; }
}
```

### DateFieldInstruction

Type-safe date field handling:

```csharp
var dateField = new DateFieldInstruction(DateFieldType.CreateDate)
    .WithFormat("MMMM d, yyyy")
    .WithMergeFormat();

// Or use the fluent builder
var currentDate = DateField.Current()
    .WithFormat("dd/MM/yyyy")
    .Build();
```

#### Supported Date Field Types

```csharp
public enum DateFieldType
{
    Date,           // DATE
    CreateDate,     // CREATEDATE
    SaveDate,       // SAVEDATE
    PrintDate,      // PRINTDATE
    EditTime,       // EDITTIME
    Time            // TIME
}
```

### FormulaFieldInstruction

Type-safe formula fields:

```csharp
var formula = new FormulaFieldInstruction("SUM(A1:A10)")
    .WithNumericFormat("#,##0.00")
    .WithLockResult();

// Using the builder pattern
var complexFormula = FormulaField
    .Create("AVERAGE(A1:A10) * 1.2")
    .WithFormat("#0.00%")
    .Build();
```

### HyperlinkFieldInstruction

Strongly-typed hyperlinks:

```csharp
var hyperlink = new HyperlinkFieldInstruction("http://example.com")
    .WithDisplayText("Visit Example")
    .WithTooltip("Click to visit example.com")
    .WithTarget("_blank");

// Email hyperlink
var emailLink = HyperlinkField.Email("user@example.com")
    .WithDisplayText("Send Email")
    .WithSubject("Hello from Word")
    .Build();
```

## Builder Pattern

### FieldBuilder

Fluent builder for complex field instructions:

```csharp
var field = FieldBuilder
    .MergeField("CustomerName")
    .WithFormat(MergeFormat.FirstCap)
    .WithMergeFormat()
    .Build();

var dateField = FieldBuilder
    .Date(DateFieldType.SaveDate)
    .WithFormat("yyyy-MM-dd HH:mm:ss")
    .Build();
```

### Conditional Fields

Build conditional field logic:

```csharp
var conditionalField = FieldBuilder
    .If("CustomerType = "Premium"")
    .Then(FieldBuilder.MergeField("PremiumDiscount"))
    .Else(FieldBuilder.Text("Standard Rate"))
    .Build();
```

## Validation and Error Handling

### Compile-Time Validation

The typed system prevents common errors at compile time:

```csharp
// This won't compile - invalid format for merge field
// var invalid = new MergeFieldInstruction("Name").WithFormat("##0.00");

// This is valid
var valid = new MergeFieldInstruction("Name").WithFormat(MergeFormat.Upper);
```

### Runtime Validation

Runtime validation for dynamic scenarios:

```csharp
var builder = new MergeFieldInstruction("DynamicField");
var validationResult = builder.Validate();

if (!validationResult.IsValid)
{
    foreach (var error in validationResult.Errors)
    {
        Console.WriteLine($"Validation error: {error.Message}");
    }
}
```

## Advanced Features

### Custom Field Types

Create custom typed field instructions:

```csharp
public class CustomFieldInstruction : ITypedFieldInstruction<CustomFieldInstruction>
{
    private readonly string _customValue;

    public CustomFieldInstruction(string customValue)
    {
        _customValue = customValue;
    }

    public string FieldType => "CUSTOMFIELD";

    public string ToFieldCode() => $"CUSTOMFIELD {_customValue}";

    public CustomFieldInstruction WithCustomOption(string option)
    {
        return new CustomFieldInstruction($"{_customValue} {option}");
    }
}
```

### Field Collections

Manage collections of typed fields:

```csharp
var fieldCollection = new TypedFieldCollection();

fieldCollection.Add(new MergeFieldInstruction("FirstName"));
fieldCollection.Add(new MergeFieldInstruction("LastName"));
fieldCollection.Add(new DateFieldInstruction(DateFieldType.Date));

// Generate all field codes
var fieldCodes = fieldCollection.Select(f => f.ToFieldCode()).ToList();

// Validate all fields
var validationResults = fieldCollection.ValidateAll();
```

### Field Templates

Create reusable field templates:

```csharp
public static class FieldTemplates
{
    public static MergeFieldInstruction StandardName(string fieldName)
    {
        return new MergeFieldInstruction(fieldName)
            .WithFormat(MergeFormat.FirstCap)
            .WithMergeFormat();
    }

    public static DateFieldInstruction StandardDate(DateFieldType dateType)
    {
        return new DateFieldInstruction(dateType)
            .WithFormat("MMMM d, yyyy")
            .WithMergeFormat();
    }
}

// Usage
var customerName = FieldTemplates.StandardName("CustomerName");
var invoiceDate = FieldTemplates.StandardDate(DateFieldType.Date);
```

## Integration Examples

### Document Generation

```csharp
using DocumentFormat.OpenXml.Wordprocessing;

public void InsertTypedField(Paragraph paragraph, ITypedFieldInstruction field)
{
    var fieldCode = new FieldCode(field.ToFieldCode());
    var fieldChar1 = new FieldChar() { FieldCharType = FieldCharValues.Begin };
    var fieldChar2 = new FieldChar() { FieldCharType = FieldCharValues.End };

    var run1 = new Run(fieldChar1);
    var run2 = new Run(fieldCode);
    var run3 = new Run(fieldChar2);

    paragraph.Append(run1, run2, run3);
}
```

### Mail Merge Document Creation

```csharp
public class MailMergeDocumentBuilder
{
    private readonly List<ITypedFieldInstruction> _fields = new();

    public MailMergeDocumentBuilder AddMergeField(string name, MergeFormat format = MergeFormat.None)
    {
        var field = new MergeFieldInstruction(name);
        if (format != MergeFormat.None)
            field = field.WithFormat(format);

        _fields.Add(field);
        return this;
    }

    public MailMergeDocumentBuilder AddCurrentDate(string format = "MMMM d, yyyy")
    {
        _fields.Add(new DateFieldInstruction(DateFieldType.Date).WithFormat(format));
        return this;
    }

    public WordprocessingDocument Build()
    {
        // Create document with typed fields
        var document = CreateDocument();

        foreach (var field in _fields)
        {
            InsertField(document, field);
        }

        return document;
    }
}
```

## Performance Considerations

### Field Caching

Cache commonly used field instances:

```csharp
public static class CachedFields
{
    private static readonly ConcurrentDictionary<string, MergeFieldInstruction> _mergeFields
        = new ConcurrentDictionary<string, MergeFieldInstruction>();

    public static MergeFieldInstruction GetMergeField(string name)
    {
        return _mergeFields.GetOrAdd(name, n => new MergeFieldInstruction(n));
    }
}
```

### Bulk Operations

Optimize bulk field operations:

```csharp
public class BulkFieldProcessor
{
    public IEnumerable<string> GenerateFieldCodes(IEnumerable<ITypedFieldInstruction> fields)
    {
        return fields.AsParallel().Select(f => f.ToFieldCode());
    }

    public ValidationResult ValidateFields(IEnumerable<ITypedFieldInstruction> fields)
    {
        var results = fields.AsParallel().Select(f => f.Validate()).ToList();
        return ValidationResult.Combine(results);
    }
}
```

## See Also

- [Field Instructions](./FieldInstruction.md) - Basic field instruction parsing
- [Merge Fields](../MergeField/MergeField.md) - Specialized merge field processing
- [Examples](../../examples/) - Complete usage examples

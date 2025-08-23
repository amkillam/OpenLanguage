# Merge Fields

The `OpenLanguage.WordprocessingML.MergeField` namespace provides specialized functionality for handling Word mail merge operations.

## Overview

Mail merge functionality includes:

- **Data Source Integration**: Connect to various data sources (CSV, database, JSON)
- **Field Mapping**: Map data columns to merge fields
- **Conditional Merging**: Support for conditional merge logic
- **Bulk Operations**: Efficient processing of large datasets

## Core Classes

### MergeFieldLexer

Lexical analysis for merge field syntax:

```csharp
using OpenLanguage.WordprocessingML.MergeField;

var lexer = new MergeFieldLexer();
var tokens = lexer.Tokenize("MERGEFIELD FirstName \* UPPER \* MERGEFORMAT");
```

### MergeFieldProcessor

Main class for merge field processing:

```csharp
var processor = new MergeFieldProcessor();
var dataSource = new CsvDataSource("customers.csv");

processor.SetDataSource(dataSource);
var result = processor.ProcessDocument("template.docx", "output.docx");
```

## Data Source Support

### CSV Data Sources

```csharp
var csvSource = new CsvDataSource("data.csv")
{
    HasHeaders = true,
    Delimiter = ",",
    Encoding = Encoding.UTF8
};

processor.SetDataSource(csvSource);
```

### Database Data Sources

```csharp
var dbSource = new DatabaseDataSource("Server=.;Database=MyDB;Trusted_Connection=true;")
{
    Query = "SELECT FirstName, LastName, Email FROM Customers",
    CommandTimeout = 30
};

processor.SetDataSource(dbSource);
```

### JSON Data Sources

```csharp
var jsonSource = new JsonDataSource("data.json");
processor.SetDataSource(jsonSource);
```

### Custom Data Sources

```csharp
public class CustomDataSource : IDataSource
{
    public IEnumerable<DataRecord> GetRecords()
    {
        // Custom data retrieval logic
        yield return new DataRecord
        {
            ["FirstName"] = "John",
            ["LastName"] = "Doe",
            ["Email"] = "john.doe@example.com"
        };
    }
}
```

## Field Mapping

### Automatic Mapping

```csharp
// Automatic mapping based on field names
processor.MapFields(autoMap: true);
```

### Manual Mapping

```csharp
processor.MapField("MERGEFIELD_FirstName", "First_Name_Column");
processor.MapField("MERGEFIELD_LastName", "Last_Name_Column");
processor.MapField("MERGEFIELD_Email", "Email_Address_Column");
```

### Conditional Mapping

```csharp
processor.MapFieldConditionally("MERGEFIELD_Discount",
    record => record["CustomerType"] == "Premium" ? "10%" : "5%");
```

## Processing Options

### MergeOptions

Configure merge behavior:

```csharp
var options = new MergeOptions
{
    RemoveEmptyParagraphs = true,
    PreserveFormatting = true,
    HandleMissingFields = MissingFieldBehavior.RemoveField,
    DateFormat = "MM/dd/yyyy",
    NumberFormat = "#,##0.00"
};

processor.SetOptions(options);
```

### Formatting Options

```csharp
// Apply formatting to specific fields
processor.SetFieldFormat("MERGEFIELD_Amount", "#,##0.00");
processor.SetFieldFormat("MERGEFIELD_Date", "MMMM d, yyyy");

// Apply conditional formatting
processor.SetConditionalFormat("MERGEFIELD_Status",
    value => value == "Active" ? "color:green" : "color:red");
```

## Advanced Features

### Conditional Merge Logic

```csharp
// IF field support
processor.AddConditionalLogic("IF CustomerType = "Premium"",
    thenAction: record => "Premium Customer Benefits",
    elseAction: record => "Standard Customer Information");

// COMPARE field support
processor.AddComparison("COMPARE Amount GT 1000",
    trueAction: record => "High Value Customer",
    falseAction: record => "Standard Customer");
```

### Nested Merge Fields

```csharp
// Support for nested field structures
processor.EnableNestedFields();

// Process nested table structures
processor.ProcessNestedTable("OrderItems",
    parentField: "CustomerID",
    childDataSource: orderItemsSource);
```

### Mail Merge Events

```csharp
processor.BeforeFieldMerge += (sender, e) =>
{
    // Modify field value before merging
    if (e.FieldName == "Email")
    {
        e.Value = e.Value.ToString().ToLower();
    }
};

processor.AfterFieldMerge += (sender, e) =>
{
    // Post-processing after field merge
    Console.WriteLine($"Merged {e.FieldName}: {e.Value}");
};

processor.DocumentProcessed += (sender, e) =>
{
    Console.WriteLine($"Processed document with {e.RecordCount} records");
};
```

## Bulk Processing

### Batch Operations

```csharp
var batchProcessor = new BatchMergeProcessor();

var batch = new MergeBatch()
    .AddTemplate("template1.docx", "customers.csv")
    .AddTemplate("template2.docx", "orders.csv")
    .AddTemplate("template3.docx", "products.csv");

var results = await batchProcessor.ProcessBatchAsync(batch);
```

### Parallel Processing

```csharp
var parallelOptions = new ParallelMergeOptions
{
    MaxDegreeOfParallelism = Environment.ProcessorCount,
    ChunkSize = 100
};

var results = await processor.ProcessParallelAsync(dataSource, parallelOptions);
```

## Error Handling

### Merge Validation

```csharp
var validator = new MergeValidator();
var validationResult = validator.ValidateTemplate("template.docx");

if (!validationResult.IsValid)
{
    foreach (var error in validationResult.Errors)
    {
        Console.WriteLine($"Template error: {error.Message}");
        Console.WriteLine($"Field: {error.FieldName}");
        Console.WriteLine($"Location: {error.Location}");
    }
}
```

### Data Validation

```csharp
processor.AddDataValidator("Email", value =>
{
    return IsValidEmail(value.ToString())
        ? ValidationResult.Success()
        : ValidationResult.Error("Invalid email format");
});

processor.AddDataValidator("Amount", value =>
{
    return decimal.TryParse(value.ToString(), out _)
        ? ValidationResult.Success()
        : ValidationResult.Error("Invalid amount format");
});
```

## Performance Optimization

### Caching Strategies

```csharp
// Enable template caching
processor.EnableTemplateCache(maxSize: 100);

// Enable data source caching
processor.EnableDataCache(TimeSpan.FromMinutes(30));
```

### Memory Management

```csharp
// Configure memory usage for large datasets
var memoryOptions = new MergeMemoryOptions
{
    MaxMemoryUsage = 500 * 1024 * 1024, // 500MB
    EnableStreaming = true,
    ChunkSize = 1000
};

processor.SetMemoryOptions(memoryOptions);
```

## Integration Examples

### ASP.NET Core Integration

```csharp
[ApiController]
[Route("api/[controller]")]
public class MergeController : ControllerBase
{
    private readonly IMergeFieldProcessor _processor;

    public MergeController(IMergeFieldProcessor processor)
    {
        _processor = processor;
    }

    [HttpPost("merge")]
    public async Task<IActionResult> MergeDocument([FromBody] MergeRequest request)
    {
        try
        {
            var result = await _processor.ProcessAsync(request.Template, request.Data);
            return File(result.DocumentBytes, "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
        }
        catch (MergeException ex)
        {
            return BadRequest(new { error = ex.Message, details = ex.ValidationErrors });
        }
    }
}
```

### Background Service Integration

```csharp
public class MergeBackgroundService : BackgroundService
{
    private readonly IMergeFieldProcessor _processor;
    private readonly ILogger<MergeBackgroundService> _logger;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var mergeJobs = await GetPendingMergeJobs();

            foreach (var job in mergeJobs)
            {
                try
                {
                    await _processor.ProcessJobAsync(job);
                    await MarkJobCompleted(job.Id);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Failed to process merge job {JobId}", job.Id);
                    await MarkJobFailed(job.Id, ex.Message);
                }
            }

            await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken);
        }
    }
}
```

## See Also

- [Field Instructions](../FieldInstruction/FieldInstruction.md) - Basic field instruction parsing
- [Typed Field Instructions](../FieldInstruction/Typed.md) - Type-safe field handling
- [ODBC Integration](../ODBC/ODBC.md) - Database connectivity features

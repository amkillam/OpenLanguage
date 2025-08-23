# ODBC Integration

The `OpenLanguage.WordprocessingML.ODBC` namespace provides comprehensive database connectivity for Word document processing through ODBC.

## Overview

ODBC integration features:

- **Multi-Database Support**: Connect to SQL Server, Oracle, MySQL, PostgreSQL, and more
- **Query Execution**: Execute parameterized queries safely
- **Data Binding**: Bind query results to Word document fields
- **Connection Management**: Efficient connection pooling and management
- **Transaction Support**: Full transaction control for data operations

## Core Classes

### OdbcParser

Parses ODBC-related field instructions:

```csharp
using OpenLanguage.WordprocessingML.ODBC;

var parser = new OdbcParser();
var query = parser.Parse("DATABASE \s "SELECT * FROM Customers WHERE Region = 'West'"");
```

### OdbcLexer

Lexical analysis for ODBC syntax:

```csharp
var lexer = new OdbcLexer();
var tokens = lexer.Tokenize("DATABASE \s "SELECT Name, Email FROM Users"");
```

### DatabaseConnection

Manages database connections:

```csharp
var connection = new DatabaseConnection("Driver={SQL Server};Server=localhost;Database=MyDB;Trusted_Connection=yes;");
await connection.OpenAsync();

var result = await connection.ExecuteQueryAsync("SELECT * FROM Customers");
await connection.CloseAsync();
```

## Connection Configuration

### Connection Strings

```csharp
// SQL Server
var sqlServerConnection = new DatabaseConnection(
    "Driver={ODBC Driver 17 for SQL Server};Server=localhost;Database=MyDB;Trusted_Connection=yes;");

// MySQL
var mysqlConnection = new DatabaseConnection(
    "Driver={MySQL ODBC 8.0 Driver};Server=localhost;Database=MyDB;User=root;Password=password;");

// PostgreSQL
var postgresConnection = new DatabaseConnection(
    "Driver={PostgreSQL Unicode};Server=localhost;Port=5432;Database=MyDB;Uid=postgres;Pwd=password;");

// Oracle
var oracleConnection = new DatabaseConnection(
    "Driver={Oracle in OraClient12Home1};Dbq=localhost:1521/XE;Uid=hr;Pwd=password;");
```

### Connection Pooling

```csharp
var poolConfig = new ConnectionPoolConfig
{
    MinPoolSize = 5,
    MaxPoolSize = 50,
    ConnectionTimeout = TimeSpan.FromSeconds(30),
    IdleTimeout = TimeSpan.FromMinutes(10)
};

var connectionManager = new DatabaseConnectionManager(poolConfig);
```

## Query Execution

### Simple Queries

```csharp
var connection = new DatabaseConnection(connectionString);

// Execute query and get results
var customers = await connection.ExecuteQueryAsync<Customer>(
    "SELECT CustomerID, Name, Email FROM Customers");

// Execute scalar query
var customerCount = await connection.ExecuteScalarAsync<int>(
    "SELECT COUNT(*) FROM Customers");

// Execute non-query (INSERT, UPDATE, DELETE)
var rowsAffected = await connection.ExecuteNonQueryAsync(
    "UPDATE Customers SET LastLogin = GETDATE() WHERE CustomerID = 123");
```

### Parameterized Queries

```csharp
// Safe parameterized queries
var parameters = new Dictionary<string, object>
{
    ["@Region"] = "West",
    ["@MinOrderValue"] = 1000
};

var customers = await connection.ExecuteQueryAsync<Customer>(
    "SELECT * FROM Customers WHERE Region = @Region AND TotalOrders >= @MinOrderValue",
    parameters);
```

### Stored Procedures

```csharp
// Execute stored procedure
var parameters = new Dictionary<string, object>
{
    ["@CustomerID"] = 123,
    ["@StartDate"] = new DateTime(2024, 1, 1),
    ["@EndDate"] = new DateTime(2024, 12, 31)
};

var orders = await connection.ExecuteStoredProcedureAsync<Order>(
    "GetCustomerOrders", parameters);
```

## Data Binding

### Field Binding

```csharp
var binder = new DatabaseFieldBinder(connection);

// Bind single field
binder.BindField("MERGEFIELD CustomerName",
    "SELECT Name FROM Customers WHERE CustomerID = @ID");

// Bind multiple fields
binder.BindFields(new Dictionary<string, string>
{
    ["MERGEFIELD CustomerName"] = "SELECT Name FROM Customers WHERE CustomerID = @ID",
    ["MERGEFIELD CustomerEmail"] = "SELECT Email FROM Customers WHERE CustomerID = @ID",
    ["MERGEFIELD OrderCount"] = "SELECT COUNT(*) FROM Orders WHERE CustomerID = @ID"
});
```

### Document Processing

```csharp
public async Task ProcessDocumentWithDatabase(string templatePath, string outputPath)
{
    var processor = new DatabaseDocumentProcessor(connectionString);

    // Set global parameters
    processor.SetParameter("@CurrentDate", DateTime.Now);
    processor.SetParameter("@UserID", currentUserId);

    // Process document
    await processor.ProcessDocumentAsync(templatePath, outputPath);
}
```

## Advanced Features

### Transaction Management

```csharp
using var transaction = await connection.BeginTransactionAsync();

try
{
    // Execute multiple operations within transaction
    await connection.ExecuteNonQueryAsync(
        "INSERT INTO Customers (Name, Email) VALUES (@Name, @Email)",
        new { Name = "John Doe", Email = "john@example.com" },
        transaction);

    await connection.ExecuteNonQueryAsync(
        "INSERT INTO Orders (CustomerID, Amount) VALUES (@CustomerID, @Amount)",
        new { CustomerID = newCustomerId, Amount = 100.00 },
        transaction);

    await transaction.CommitAsync();
}
catch (Exception)
{
    await transaction.RollbackAsync();
    throw;
}
```

### Bulk Operations

```csharp
// Bulk insert
var customers = new List<Customer>
{
    new Customer { Name = "John Doe", Email = "john@example.com" },
    new Customer { Name = "Jane Smith", Email = "jane@example.com" }
};

await connection.BulkInsertAsync("Customers", customers);

// Bulk update
var updateData = customers.Select(c => new {
    CustomerID = c.ID,
    LastUpdated = DateTime.Now
}).ToList();

await connection.BulkUpdateAsync("Customers", updateData, "CustomerID");
```

### Dynamic Queries

```csharp
var queryBuilder = new DynamicQueryBuilder();

// Build query dynamically based on conditions
var query = queryBuilder
    .Select("CustomerID", "Name", "Email")
    .From("Customers")
    .Where("Region = @Region")
    .WhereIf(includeInactive, "Status = 'Active'")
    .OrderBy("Name")
    .Build();

var results = await connection.ExecuteQueryAsync(query.Sql, query.Parameters);
```

## Error Handling

### Database Exceptions

```csharp
try
{
    var result = await connection.ExecuteQueryAsync("SELECT * FROM NonExistentTable");
}
catch (DatabaseConnectionException ex)
{
    Console.WriteLine($"Connection error: {ex.Message}");
}
catch (DatabaseQueryException ex)
{
    Console.WriteLine($"Query error: {ex.Message}");
    Console.WriteLine($"SQL: {ex.SqlCommand}");
}
catch (DatabaseTimeoutException ex)
{
    Console.WriteLine($"Timeout error: {ex.Message}");
    Console.WriteLine($"Timeout duration: {ex.TimeoutDuration}");
}
```

### Retry Policies

```csharp
var retryPolicy = new DatabaseRetryPolicy
{
    MaxRetries = 3,
    RetryDelay = TimeSpan.FromSeconds(1),
    BackoffMultiplier = 2.0
};

connection.SetRetryPolicy(retryPolicy);

// Connection will automatically retry on transient failures
var result = await connection.ExecuteQueryAsync("SELECT * FROM Customers");
```

## Performance Optimization

### Query Caching

```csharp
// Enable query result caching
connection.EnableQueryCache(new QueryCacheOptions
{
    MaxCacheSize = 100,
    DefaultExpiration = TimeSpan.FromMinutes(10)
});

// Cache specific queries
var result = await connection.ExecuteQueryAsync(
    "SELECT * FROM Products",
    cacheKey: "all-products",
    cacheExpiration: TimeSpan.FromHours(1));
```

### Connection Optimization

```csharp
// Optimize connection settings
var options = new ConnectionOptions
{
    CommandTimeout = TimeSpan.FromSeconds(30),
    EnableConnectionPooling = true,
    MaxConnectionLifetime = TimeSpan.FromMinutes(30),
    EnableStatementCaching = true
};

connection.SetOptions(options);
```

## Security Features

### SQL Injection Prevention

```csharp
// Always use parameterized queries
var safeQuery = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password";
var parameters = new { Username = username, Password = hashedPassword };

var user = await connection.ExecuteQueryAsync<User>(safeQuery, parameters);

// NEVER do this (SQL injection vulnerable)
// var unsafeQuery = $"SELECT * FROM Users WHERE Username = '{username}'";
```

### Connection Security

```csharp
// Use encrypted connections
var secureConnection = new DatabaseConnection(
    "Driver={SQL Server};Server=localhost;Database=MyDB;Encrypt=yes;TrustServerCertificate=no;");

// Use integrated authentication when possible
var integratedAuth = new DatabaseConnection(
    "Driver={SQL Server};Server=localhost;Database=MyDB;Trusted_Connection=yes;");
```

## Integration Examples

### Mail Merge with Database

```csharp
public class DatabaseMailMerge
{
    private readonly DatabaseConnection _connection;

    public DatabaseMailMerge(string connectionString)
    {
        _connection = new DatabaseConnection(connectionString);
    }

    public async Task<byte[]> GenerateMailMergeDocument(string templatePath, int customerId)
    {
        // Get customer data
        var customer = await _connection.ExecuteQueryAsync<Customer>(
            "SELECT * FROM Customers WHERE CustomerID = @CustomerID",
            new { CustomerID = customerId });

        // Get related data
        var orders = await _connection.ExecuteQueryAsync<Order>(
            "SELECT * FROM Orders WHERE CustomerID = @CustomerID",
            new { CustomerID = customerId });

        // Process document with data
        var processor = new MailMergeProcessor();
        processor.SetDataSource(customer);
        processor.SetRelatedData("Orders", orders);

        return await processor.ProcessDocumentAsync(templatePath);
    }
}
```

### Real-time Document Updates

```csharp
public class RealtimeDocumentProcessor
{
    private readonly DatabaseConnection _connection;
    private readonly IHubContext<DocumentHub> _hubContext;

    public async Task ProcessDocumentWithLiveUpdates(string documentId)
    {
        // Set up database change notifications
        _connection.OnDataChanged += async (sender, e) =>
        {
            if (e.TableName == "DocumentData")
            {
                await RefreshDocumentData(documentId);
                await _hubContext.Clients.Group(documentId)
                    .SendAsync("DocumentUpdated", documentId);
            }
        };

        // Start monitoring
        await _connection.StartChangeMonitoringAsync("DocumentData");
    }
}
```

## See Also

- [Field Instructions](../FieldInstruction/FieldInstruction.md) - Field instruction parsing
- [Merge Fields](../MergeField/MergeField.md) - Mail merge functionality
- [Expression Processing](../Expression/Expression.md) - Expression evaluation

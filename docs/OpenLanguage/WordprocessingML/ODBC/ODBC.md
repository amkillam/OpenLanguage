# ODBC Support Components

The ODBC-related namespaces provide support for database connection string parsing and SQL query validation for Word document database field processing.

## Overview

The ODBC support includes:

- **Connection String Parsing**: Parse and validate database connection strings
- **SQL Query Validation**: Validate SQL syntax for different database types
- **Database Type Detection**: Identify query types (SQL, Excel, Access QBE, etc.)
- **Connection Component Analysis**: Parse connection string components

## Namespaces

### OpenLanguage.ODBC

Contains SQL query parsing and validation:

```csharp
using OpenLanguage.ODBC;

// Create and validate a database query
var query = new DatabaseQuery("SELECT * FROM Customers WHERE Region = 'West'");
Console.WriteLine($"Query type: {query.QueryType}"); // Sql
Console.WriteLine($"Query text: {query.QueryText}");
```

### OpenLanguage.WordprocessingML.ODBC

Contains ODBC connection string parsing:

```csharp
using OpenLanguage.WordprocessingML.ODBC;

// Parse a connection string
var builder = ODBCConnectionLexer.Parse("Driver={SQL Server};Server=localhost;Database=MyDB;");
Console.WriteLine($"Driver: {builder["Driver"]}");
Console.WriteLine($"Server: {builder["Server"]}");
```

## DatabaseQuery Class

Represents a validated database query with syntax checking:

```csharp
public class DatabaseQuery
{
    public string QueryText { get; }           // The validated query text
    public DatabaseQueryType QueryType { get; } // Detected query type

    public DatabaseQuery(string queryText)     // Constructor with validation

    // Implicit conversions
    public static implicit operator string(DatabaseQuery databaseQuery)
    public static implicit operator DatabaseQuery(string queryText)
}
```

### Query Type Detection

The system can identify these query types:

```csharp
public enum DatabaseQueryType
{
    Sql,            // Standard SQL queries
    AccessQbe,      // Microsoft Access Query-by-Example
    DBase,          // dBase query expressions
    FoxPro,         // FoxPro query expressions
    Paradox,        // Paradox queries
    Excel,          // Excel range references
    Odbc,           // ODBC-compatible queries
    OleDb,          // OLE DB queries
    Unknown         // Unrecognized query type
}
```

### SQL Command Types

For SQL queries, the system recognizes these command types:

```csharp
public enum SqlCommandType
{
    Select, Insert, Update, Delete,     // DML commands
    Create, Alter, Drop, Truncate,      // DDL commands
    Grant, Revoke,                      // DCL commands
    Commit, Rollback, Savepoint,       // TCL commands
    Execute,                            // Stored procedures
    Unknown                             // Unrecognized commands
}
```

## Query Validation Examples

### SQL Query Validation

```csharp
// Valid SQL queries
var selectQuery = new DatabaseQuery("SELECT * FROM Customers WHERE Region = 'West'");
var insertQuery = new DatabaseQuery("INSERT INTO Customers (Name, Email) VALUES ('John', 'john@example.com')");
var updateQuery = new DatabaseQuery("UPDATE Customers SET LastLogin = GETDATE() WHERE ID = 123");

// Query type is automatically detected
Console.WriteLine(selectQuery.QueryType); // Sql

// Invalid SQL queries throw ArgumentException
try
{
    var invalidQuery = new DatabaseQuery("SELECT * FROM"); // Missing table name
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Validation error: {ex.Message}");
}
```

### Excel Range Validation

```csharp
// Valid Excel range references
var excelRange1 = new DatabaseQuery("Sheet1$A1:C10");
var excelRange2 = new DatabaseQuery("MyNamedRange");
var excelRange3 = new DatabaseQuery("'Sales Data'!A:C");

Console.WriteLine(excelRange1.QueryType); // Excel
```

### Access QBE and Other Formats

```csharp
// Access Query-by-Example format
var qbeQuery = new DatabaseQuery("CustomerName, OrderDate FROM Orders WHERE OrderDate > #2024-01-01#");

// dBase filter expression
var dbaseQuery = new DatabaseQuery("FOR CustomerType = 'Premium'");

// System detects the appropriate query type
Console.WriteLine(qbeQuery.QueryType);  // AccessQbe
Console.WriteLine(dbaseQuery.QueryType); // DBase
```

## Connection String Parsing

### ODBCConnectionLexer

Static class for parsing ODBC connection strings:

```csharp
using System.Data.Odbc;
using OpenLanguage.WordprocessingML.ODBC;

// Parse a connection string
string connectionString = "Driver={SQL Server};Server=localhost;Database=MyDB;Trusted_Connection=yes;";
var builder = ODBCConnectionLexer.Parse(connectionString);

if (builder != null)
{
    Console.WriteLine($"Driver: {builder["Driver"]}");
    Console.WriteLine($"Server: {builder["Server"]}");
    Console.WriteLine($"Database: {builder["Database"]}");
}
```

### Connection String Components

The lexer recognizes these connection component types:

```csharp
public enum ODBCConnectionComponentType
{
    // ODBC Components
    DataSourceName, DBQ, FIL, Driver, Server, Database,
    UID, PWD, ConnectionTimeout, CommandTimeout,

    // OLE DB Components
    Provider, DataSource, InitialCatalog, IntegratedSecurity,
    TrustedConnection, PersistSecurityInfo, Pooling,

    // SQL Server Specific
    ServerInstance, NetworkLibrary, ApplicationName, WorkstationID,
    PacketSize, Encrypt, TrustServerCertificate, MultipleActiveResultSets,

    // Access/Jet Specific
    SystemDB, Exclusive, ReadOnly, JetOLEDBEngineType,
    JetOLEDBDatabasePassword, JetOLEDBSystemDatabase,

    // Oracle, MySQL, Excel, dBase, Text/CSV specific components...
    // (Many more component types supported)

    Custom  // Unknown component types
}
```

### ODBCConnectionComponent

Represents a parsed connection string component:

```csharp
public class ODBCConnectionComponent
{
    public ODBCConnectionComponentType ComponentType { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }

    public ODBCConnectionComponent(string key, string value)

    public override string ToString() // Reconstructs key=value format
}
```

## Usage Examples

### Connection String Parsing

```csharp
using System.Data.Odbc;
using OpenLanguage.WordprocessingML.ODBC;

// Parse various connection string formats
string[] connectionStrings = {
    "Driver={SQL Server};Server=localhost;Database=MyDB;Trusted_Connection=yes;",
    "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\mydb.mdb;",
    "Driver={MySQL ODBC 8.0 Driver};Server=localhost;Database=test;User=root;Password=secret;",
    "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\myfile.xlsx;Extended Properties="Excel 12.0 Xml;HDR=YES";"
};

foreach (string connStr in connectionStrings)
{
    var builder = ODBCConnectionLexer.Parse(connStr);
    if (builder != null)
    {
        Console.WriteLine($"Connection string: {connStr}");
        foreach (string key in builder.Keys)
        {
            Console.WriteLine($"  {key} = {builder[key]}");
        }
        Console.WriteLine();
    }
}
```

### Manual Connection String Reconstruction

```csharp
// Create connection components manually
var components = new List<ODBCConnectionComponent>
{
    new ODBCConnectionComponent("Driver", "{SQL Server}"),
    new ODBCConnectionComponent("Server", "localhost"),
    new ODBCConnectionComponent("Database", "MyDB"),
    new ODBCConnectionComponent("Trusted_Connection", "yes")
};

// Reconstruct connection string
string reconstructed = ODBCConnectionLexer.Reconstruct(components);
Console.WriteLine(reconstructed);
// Output: Driver={SQL Server}; Server=localhost; Database=MyDB; Trusted_Connection=yes
```

### Query Validation with Different Database Types

```csharp
using OpenLanguage.ODBC;

// Test various query formats
string[] queries = {
    "SELECT * FROM Customers WHERE Region = 'West'",           // SQL
    "CustomerName, OrderDate FROM Orders",                      // Access QBE
    "Sheet1$A1:C10",                                           // Excel range
    "FOR CustomerType = 'Premium'",                            // dBase
    "MyNamedRange"                                             // Excel named range
};

foreach (string queryText in queries)
{
    try
    {
        var query = new DatabaseQuery(queryText);
        Console.WriteLine($"Query: {queryText}");
        Console.WriteLine($"  Type: {query.QueryType}");
        Console.WriteLine($"  Valid: Yes");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"Query: {queryText}");
        Console.WriteLine($"  Valid: No - {ex.Message}");
    }
    Console.WriteLine();
}
```

## Syntax Validation Details

### SQL Validation Rules

The `DatabaseQuery` class validates SQL syntax with these rules:

- **SELECT**: Must contain FROM clause (or reference DUAL)
- **INSERT**: Must contain INTO clause
- **UPDATE**: Must contain SET clause
- **DELETE**: Must contain FROM clause
- **CREATE/DROP**: Must specify object type (TABLE, DATABASE, INDEX, etc.)
- **All queries**: Must have balanced parentheses and quotes

### Basic Syntax Validation

For non-SQL query types, basic validation includes:

- Balanced parentheses `()`
- Balanced single quotes `''`
- Balanced double quotes `""`
- Excel range format validation (alphanumeric, $, :, !, single quotes)

## Technical Details

- **Connection String Parsing**: Uses `OdbcConnectionStringBuilder` with manual fallback
- **Query Type Detection**: Based on first keyword and structural patterns
- **Component Type Recognition**: Extensive mapping of connection string keys
- **Error Handling**: Throws `ArgumentException` for invalid syntax
- **Implicit Conversions**: Support for string ↔ DatabaseQuery conversion
- **Quote Handling**: Proper escaping and unescaping of quoted values

## Limitations

- No actual database connectivity (parsing and validation only)
- Limited to syntax validation (no semantic validation)
- Connection string parsing may not handle all edge cases
- Query type detection based on heuristics, not full parsing
- No support for complex nested queries or advanced SQL features

## See Also

- [Field Instructions](../FieldInstruction/FieldInstruction.md) - Generic field instruction handling
- [Unit Tests](../../../OpenLanguage.Test/) - Test examples showing usage patterns

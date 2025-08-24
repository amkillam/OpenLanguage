using System;
using System.Linq;

namespace OpenLanguage.WordprocessingML.ODBC
{
    /// <summary>
    /// Represents the type of SQL command being executed.
    /// </summary>
    public enum SqlCommandType
    {
        /// <summary>Data Query Language - SELECT statements</summary>
        Select,

        /// <summary>Data Manipulation Language - INSERT statements</summary>
        Insert,

        /// <summary>Data Manipulation Language - UPDATE statements</summary>
        Update,

        /// <summary>Data Manipulation Language - DELETE statements</summary>
        Delete,

        /// <summary>Data Definition Language - CREATE statements</summary>
        Create,

        /// <summary>Data Definition Language - ALTER statements</summary>
        Alter,

        /// <summary>Data Definition Language - DROP statements</summary>
        Drop,

        /// <summary>Data Definition Language - TRUNCATE statements</summary>
        Truncate,

        /// <summary>Data Control Language - GRANT statements</summary>
        Grant,

        /// <summary>Data Control Language - REVOKE statements</summary>
        Revoke,

        /// <summary>Transaction Control Language - COMMIT statements</summary>
        Commit,

        /// <summary>Transaction Control Language - ROLLBACK statements</summary>
        Rollback,

        /// <summary>Transaction Control Language - SAVEPOINT statements</summary>
        Savepoint,

        /// <summary>Stored procedure calls</summary>
        Execute,

        /// <summary>Unknown or unrecognized command type</summary>
        Unknown,
    }

    /// <summary>
    /// Represents the type of database query being executed.
    /// </summary>
    public enum DatabaseQueryType
    {
        /// <summary>SQL query for relational databases</summary>
        Sql,

        /// <summary>Microsoft Access Query-by-Example (QBE)</summary>
        AccessQbe,

        /// <summary>dBase query expression</summary>
        DBase,

        /// <summary>FoxPro query expression</summary>
        FoxPro,

        /// <summary>Paradox query</summary>
        Paradox,

        /// <summary>Excel range or named range</summary>
        Excel,

        /// <summary>ODBC-compatible query</summary>
        Odbc,

        /// <summary>OLE DB query</summary>
        OleDb,

        /// <summary>Unknown or unrecognized query type</summary>
        Unknown,
    }

    /// <summary>
    /// Represents a validated database query with its command type and syntax validation.
    /// </summary>
    public class DatabaseQuery
    {
        private readonly string _queryText;
        private readonly DatabaseQueryType _queryType;

        public DatabaseQuery(string queryText)
        {
            if (string.IsNullOrWhiteSpace(queryText))
            {
                throw new ArgumentException(
                    "Database query text cannot be null or empty",
                    nameof(queryText)
                );
            }

            _queryText = queryText.Trim();
            _queryType = DetermineQueryType(_queryText);

            ValidateQuerySyntax(_queryText, _queryType);
        }

        public string QueryText => _queryText;
        public DatabaseQueryType QueryType => _queryType;

        private static DatabaseQueryType DetermineQueryType(string query)
        {
            string upperQuery = query.ToUpperInvariant().Trim();
            string firstWord =
                upperQuery
                    .Split(
                        new char[] { ' ', '\t', '\n', '\r' },
                        StringSplitOptions.RemoveEmptyEntries
                    )
                    .FirstOrDefault()
                ?? string.Empty;

            // SQL keywords
            if (
                firstWord == "SELECT"
                || firstWord == "INSERT"
                || firstWord == "UPDATE"
                || firstWord == "DELETE"
                || firstWord == "CREATE"
                || firstWord == "ALTER"
                || firstWord == "DROP"
                || firstWord == "EXEC"
                || firstWord == "EXECUTE"
            )
            {
                return DatabaseQueryType.Sql;
            }

            // Access QBE often uses field names directly or starts with table references
            if (upperQuery.Contains("FROM") && !upperQuery.StartsWith("SELECT"))
            {
                return DatabaseQueryType.AccessQbe;
            }

            // Excel range references (e.g., "Sheet1$A1:C10", "NamedRange")
            if (
                upperQuery.Contains("$")
                || (!upperQuery.Contains(" ") && !upperQuery.Contains("SELECT"))
            )
            {
                return DatabaseQueryType.Excel;
            }

            // dBase filter expressions often use FOR clauses
            if (upperQuery.Contains("FOR ") && !upperQuery.Contains("SELECT"))
            {
                return DatabaseQueryType.DBase;
            }

            // FoxPro queries often use SET FILTER or similar
            if (upperQuery.StartsWith("SET ") || upperQuery.Contains("FILTER"))
            {
                return DatabaseQueryType.FoxPro;
            }

            return DatabaseQueryType.Unknown;
        }

        private static void ValidateQuerySyntax(string query, DatabaseQueryType queryType)
        {
            switch (queryType)
            {
                case DatabaseQueryType.Sql:
                    ValidateSqlSyntax(query);
                    break;

                case DatabaseQueryType.Excel:
                    ValidateExcelRangeSyntax(query);
                    break;

                case DatabaseQueryType.AccessQbe:
                case DatabaseQueryType.DBase:
                case DatabaseQueryType.FoxPro:
                case DatabaseQueryType.Paradox:
                case DatabaseQueryType.Odbc:
                case DatabaseQueryType.OleDb:
                    // Basic validation - ensure balanced quotes and parentheses
                    ValidateBasicSyntax(query);
                    break;

                case DatabaseQueryType.Unknown:
                    // Allow unknown query types but validate basic syntax
                    ValidateBasicSyntax(query);
                    break;
            }
        }

        private static void ValidateSqlSyntax(string sql)
        {
            string upperSql = sql.ToUpperInvariant();
            string firstWord =
                upperSql
                    .Split(
                        new char[] { ' ', '\t', '\n', '\r' },
                        StringSplitOptions.RemoveEmptyEntries
                    )
                    .FirstOrDefault()
                ?? string.Empty;

            switch (firstWord)
            {
                case "SELECT":
                    if (!upperSql.Contains("FROM") && !upperSql.Contains("DUAL"))
                    {
                        throw new ArgumentException(
                            "SELECT statements must contain a FROM clause or reference DUAL"
                        );
                    }
                    break;

                case "INSERT":
                    if (!upperSql.Contains("INTO"))
                    {
                        throw new ArgumentException(
                            "INSERT statements must contain an INTO clause"
                        );
                    }
                    break;

                case "UPDATE":
                    if (!upperSql.Contains("SET"))
                    {
                        throw new ArgumentException("UPDATE statements must contain a SET clause");
                    }
                    break;

                case "DELETE":
                    if (!upperSql.Contains("FROM"))
                    {
                        throw new ArgumentException("DELETE statements must contain a FROM clause");
                    }
                    break;

                case "CREATE":
                    if (
                        !upperSql.Contains("TABLE")
                        && !upperSql.Contains("DATABASE")
                        && !upperSql.Contains("INDEX")
                        && !upperSql.Contains("VIEW")
                        && !upperSql.Contains("PROCEDURE")
                        && !upperSql.Contains("FUNCTION")
                    )
                    {
                        throw new ArgumentException(
                            "CREATE statements must specify what to create (TABLE, DATABASE, INDEX, VIEW, etc.)"
                        );
                    }
                    break;

                case "DROP":
                    if (
                        !upperSql.Contains("TABLE")
                        && !upperSql.Contains("DATABASE")
                        && !upperSql.Contains("INDEX")
                        && !upperSql.Contains("VIEW")
                        && !upperSql.Contains("PROCEDURE")
                        && !upperSql.Contains("FUNCTION")
                    )
                    {
                        throw new ArgumentException(
                            "DROP statements must specify what to drop (TABLE, DATABASE, INDEX, VIEW, etc.)"
                        );
                    }
                    break;
            }

            ValidateBasicSyntax(sql);
        }

        private static void ValidateExcelRangeSyntax(string range)
        {
            // Excel ranges can be:
            // - Sheet references: Sheet1$A1:C10
            // - Named ranges: MyNamedRange
            // - Simple ranges: A1:C10
            if (string.IsNullOrWhiteSpace(range))
            {
                throw new ArgumentException("Excel range cannot be empty");
            }

            // Allow alphanumeric characters, $, :, !, and single quotes for sheet names
            if (!System.Text.RegularExpressions.Regex.IsMatch(range, @"^[A-Za-z0-9_$:!'.\s-]+$"))
            {
                throw new ArgumentException($"Invalid Excel range format: {range}");
            }
        }

        private static void ValidateBasicSyntax(string query)
        {
            // Check for balanced parentheses
            Int32 openParens = query.Count(c => c == '(');
            Int32 closeParens = query.Count(c => c == ')');
            if (openParens != closeParens)
            {
                throw new ArgumentException("Query has unbalanced parentheses");
            }

            // Check for balanced quotes
            Int32 singleQuotes = query.Count(c => c == '\'');
            if (singleQuotes % 2 != 0)
            {
                throw new ArgumentException("Query has unbalanced single quotes");
            }

            Int32 doubleQuotes = query.Count(c => c == '"');
            if (doubleQuotes % 2 != 0)
            {
                throw new ArgumentException("Query has unbalanced double quotes");
            }
        }

        public override string ToString() => _queryText;

        public static implicit operator string(DatabaseQuery databaseQuery) =>
            databaseQuery._queryText;

        public static implicit operator DatabaseQuery(string queryText) =>
            new DatabaseQuery(queryText);
    }
}

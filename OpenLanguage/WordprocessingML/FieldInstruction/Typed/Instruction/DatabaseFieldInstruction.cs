using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Typed
{
    /// <summary>
    /// Represents a strongly-typed DATABASE field instruction.
    /// Inserts the results of a database query into a WordprocessingML table.
    /// </summary>
    public class DatabaseFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// Switch: \b field-argument
        /// Specifies table formatting attributes using bitwise combination of DatabaseTableAttributes values.
        /// Default is AutoFit (16) if \l switch is blank.
        /// </summary>
        public DatabaseTableAttributes? TableAttributes { get; set; }

        /// <summary>
        /// Switch: \c field-argument
        /// Specifies the database connection string.
        /// </summary>
        public OdbcConnectionStringBuilder? ConnectionStringBuilder { get; set; }

        /// <summary>
        /// The complete ODBC command built from the connection string and query.
        /// This is automatically constructed when both ConnectionStringBuilder and DatabaseQueryInstruction are available.
        /// </summary>
        public OdbcCommand? Command { get; set; }

        /// <summary>
        /// Switch: \d field-argument
        /// Specifies the complete path and file name of the database.
        /// Used for all database queries except SQL database queries using ODBC.
        /// </summary>
        public string? DatabasePath { get; set; }

        /// <summary>
        /// Switch: \f field-argument
        /// Specifies the integral record number of the first data record to insert.
        /// </summary>
        public int? FirstRecord { get; set; }

        /// <summary>
        /// Switch: \h
        /// Inserts field names from the database as column headings in the resulting table.
        /// </summary>
        public bool IncludeHeaders { get; set; }

        /// <summary>
        /// Switch: \l field-argument
        /// Specifies the format to be applied to the result of the database query.
        /// If used without \b switch, an unformatted table is inserted.
        /// </summary>
        public DatabaseTableFormat? TableFormat { get; set; }

        /// <summary>
        /// Switch: \o field-argument
        /// Performance optimization - gets data at beginning of merge instead of once per record.
        /// Only use when database field doesn't rely on record-specific information.
        /// </summary>
        public DatabaseOptimizationFlag? OptimizationFlag { get; set; }

        /// <summary>
        /// Switch: \s field-argument
        /// Specifies database query instructions (SQL, QBE, Excel ranges, etc.).
        /// Quotation marks in instructions must be preceded by backslash (\).
        /// </summary>
        public string? DatabaseQueryInstruction { get; set; }

        /// <summary>
        /// Switch: \t field-argument
        /// Specifies the integral record number of the last data record to insert.
        /// </summary>
        public int? LastRecord { get; set; }

        /// <summary>
        /// Initializes a new instance of the DatabaseFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public DatabaseFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "DATABASE")
            {
                throw new ArgumentException(
                    $"Expected DATABASE field, but got {Source.Instruction}"
                );
            }

            // DATABASE field has no primary field argument, only switches
            if (
                Source.Arguments.Any(arg =>
                    arg.Type == FieldArgumentType.Identifier
                    || arg.Type == FieldArgumentType.StringLiteral
                )
            )
            {
                FieldArgument? firstNonSwitch = Source.Arguments.FirstOrDefault(arg =>
                    arg.Type == FieldArgumentType.Identifier
                    || arg.Type == FieldArgumentType.StringLiteral
                );
                if (firstNonSwitch != null && !IsSwitchArgument(firstNonSwitch))
                {
                    throw new ArgumentException(
                        "DATABASE field does not accept field arguments, only switches"
                    );
                }
            }

            // Parse switches
            for (int i = 0; i < Source.Arguments.Count; i++)
            {
                FieldArgument arg = Source.Arguments[i];
                if (arg.Type == FieldArgumentType.Switch)
                {
                    string switchValue = arg.Value?.ToString() ?? string.Empty;
                    switch (switchValue.ToLowerInvariant())
                    {
                        case "\\b":
                            TableAttributes = ParseTableAttributes(GetNextArgumentAfter(i));
                            break;
                        case "\\c":
                            string connectionString = GetNextArgumentAfter(i);
                            if (!string.IsNullOrEmpty(connectionString))
                            {
                                try
                                {
                                    ConnectionStringBuilder = new OdbcConnectionStringBuilder(
                                        connectionString
                                    );
                                    BuildOdbcCommand();
                                }
                                catch
                                {
                                    // If parsing fails, set to null
                                    ConnectionStringBuilder = null;
                                }
                            }
                            break;
                        case "\\d":
                            DatabasePath = GetNextArgumentAfter(i);
                            break;
                        case "\\f":
                            FirstRecord = ParseIntegerArgument(GetNextArgumentAfter(i));
                            break;
                        case "\\h":
                            IncludeHeaders = true;
                            break;
                        case "\\l":
                            TableFormat = ParseTableFormat(GetNextArgumentAfter(i));
                            break;
                        case "\\o":
                            OptimizationFlag = ParseOptimizationFlag(GetNextArgumentAfter(i));
                            break;
                        case "\\s":
                            string queryText = GetNextArgumentAfter(i);
                            if (!string.IsNullOrWhiteSpace(queryText))
                            {
                                DatabaseQueryInstruction = queryText;
                                BuildOdbcCommand();
                            }
                            break;
                        case "\\t":
                            LastRecord = ParseIntegerArgument(GetNextArgumentAfter(i));
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Gets the next argument after the specified switch index.
        /// </summary>
        private string GetNextArgumentAfter(int switchIndex)
        {
            if (switchIndex + 1 < Source.Arguments.Count)
            {
                FieldArgument nextArg = Source.Arguments[switchIndex + 1];
                if (nextArg.Type != FieldArgumentType.Switch)
                {
                    return nextArg.Value?.ToString() ?? string.Empty;
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// Parses table attributes from a string value.
        /// </summary>
        private DatabaseTableAttributes? ParseTableAttributes(string? attributesText)
        {
            if (
                !string.IsNullOrWhiteSpace(attributesText)
                && int.TryParse(attributesText.Trim(), out int attributeValue)
            )
            {
                return (DatabaseTableAttributes)attributeValue;
            }

            return null;
        }

        /// <summary>
        /// Parses an integer argument from a string value.
        /// </summary>
        private int? ParseIntegerArgument(string? argumentText)
        {
            if (
                !string.IsNullOrWhiteSpace(argumentText)
                && int.TryParse(argumentText.Trim(), out int value)
            )
            {
                return value;
            }

            return null;
        }

        /// <summary>
        /// Parses table format from a string value.
        /// </summary>
        private DatabaseTableFormat? ParseTableFormat(string? formatText)
        {
            if (
                !string.IsNullOrWhiteSpace(formatText)
                && int.TryParse(formatText.Trim(), out int formatValue)
                && (formatValue >= 0 && formatValue <= 41)
            )
            {
                return (DatabaseTableFormat)formatValue;
            }

            return null;
        }

        /// <summary>
        /// Parses optimization flag from a string value.
        /// </summary>
        private DatabaseOptimizationFlag? ParseOptimizationFlag(string? flagText)
        {
            if (string.IsNullOrWhiteSpace(flagText))
            {
                return null;
            }

            return flagText.Trim().ToLowerInvariant() switch
            {
                "0" or "none" => DatabaseOptimizationFlag.None,
                "1" or "queryonce" => DatabaseOptimizationFlag.QueryOnce,
                "2" or "cache" => DatabaseOptimizationFlag.CacheResults,
                "3" or "pooling" => DatabaseOptimizationFlag.UseConnectionPooling,
                "4" or "largedata" => DatabaseOptimizationFlag.OptimizeForLargeData,
                "5" or "smalldata" => DatabaseOptimizationFlag.OptimizeForSmallData,
                _ => DatabaseOptimizationFlag.None,
            };
        }

        /// <summary>
        /// Builds the OdbcCommand when both connection string and query are available.
        /// </summary>
        private void BuildOdbcCommand()
        {
            if (
                ConnectionStringBuilder != null
                && !string.IsNullOrWhiteSpace(DatabaseQueryInstruction)
            )
            {
                try
                {
                    System.Data.Odbc.OdbcConnection connection =
                        new System.Data.Odbc.OdbcConnection(
                            ConnectionStringBuilder.ConnectionString
                        );
                    Command = new OdbcCommand(DatabaseQueryInstruction, connection);
                }
                catch
                {
                    // If building fails, set to null
                    Command = null;
                }
            }
            else
            {
                Command = null;
            }
        }

        /// <summary>
        /// Determines if an argument is a switch argument (follows a switch).
        /// </summary>
        private bool IsSwitchArgument(FieldArgument argument)
        {
            int argumentIndex = Source.Arguments.IndexOf(argument);
            if (argumentIndex > 0)
            {
                FieldArgument previousArg = Source.Arguments[argumentIndex - 1];
                return previousArg.Type == FieldArgumentType.Switch;
            }
            return false;
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToString()
        {
            List<string> result = new List<string> { "DATABASE" };

            if (TableAttributes.HasValue)
            {
                result.Add("\\b");
                result.Add(((int)TableAttributes.Value).ToString());
            }

            if (
                ConnectionStringBuilder != null
                && !string.IsNullOrEmpty(ConnectionStringBuilder.ConnectionString)
            )
            {
                result.Add("\\c");
                result.Add($"\"{ConnectionStringBuilder.ConnectionString}\"");
            }

            if (!string.IsNullOrWhiteSpace(DatabasePath))
            {
                result.Add("\\d");
                result.Add($"\"{DatabasePath}\"");
            }

            if (FirstRecord.HasValue)
            {
                result.Add("\\f");
                result.Add($"\"{FirstRecord.Value}\"");
            }

            if (IncludeHeaders)
            {
                result.Add("\\h");
            }

            if (TableFormat.HasValue)
            {
                result.Add("\\l");
                string formatValue = ((int)TableFormat.Value).ToString();
                result.Add($"\"{formatValue}\"");
            }

            if (OptimizationFlag.HasValue)
            {
                result.Add("\\o");
                string flagValue = OptimizationFlag.Value switch
                {
                    DatabaseOptimizationFlag.None => "0",
                    DatabaseOptimizationFlag.QueryOnce => "1",
                    DatabaseOptimizationFlag.CacheResults => "2",
                    DatabaseOptimizationFlag.UseConnectionPooling => "3",
                    DatabaseOptimizationFlag.OptimizeForLargeData => "4",
                    DatabaseOptimizationFlag.OptimizeForSmallData => "5",
                    _ => "0",
                };
                result.Add($"\"{flagValue}\"");
            }

            if (
                DatabaseQueryInstruction != null
                && !string.IsNullOrWhiteSpace(DatabaseQueryInstruction)
            )
            {
                result.Add("\\s");
                // Escape quotes in query text
                string escapedQuery = DatabaseQueryInstruction.Replace("\"", "\\\"");
                result.Add($"\"{escapedQuery}\"");
            }

            if (LastRecord.HasValue)
            {
                result.Add("\\t");
                result.Add($"\"{LastRecord.Value}\"");
            }

            return string.Join(" ", result);
        }
    }
}

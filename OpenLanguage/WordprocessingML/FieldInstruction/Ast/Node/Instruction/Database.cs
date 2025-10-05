using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    public enum DatabaseArgument
    {
        TableAttributes,
        ConnectionString,
        DatabasePath,
        FirstRecord,
        IncludeHeaders,
        TableFormat,
        OptimizationFlag,
        DatabaseQueryInstruction,
        LastRecord,
    }

    /// <summary>
    /// Represents a strongly-typed DATABASE field instruction.
    /// Inserts the results of a database query into a WordprocessingML table.
    /// </summary>
    public class DatabaseFieldInstruction : FieldInstruction
    {
        /// <summary>
        /// Switch: \b field-argument
        /// Specifies table formatting attributes using bitwise combination of DatabaseTableAttributes values.
        /// Default is AutoFit (16) if \l switch is blank.
        /// </summary>
        public FlaggedArgument<DatabaseTableAttributesNode>? TableAttributes { get; set; }

        /// <summary>
        /// Switch: \c field-argument
        /// Specifies the database connection string.
        /// </summary>
        public FlaggedArgument<OdbcConnectionStringNode>? ConnectionString { get; set; }

        /// <summary>
        /// Switch: \d field-argument
        /// Specifies the complete path and file name of the database.
        /// Used for all database queries except SQL database queries using ODBC.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? DatabasePath { get; set; }

        /// <summary>
        /// Switch: \f field-argument
        /// Specifies the integral record number of the first data record to insert.
        /// </summary>
        public FlaggedArgument<NumericLiteralNode<int>>? FirstRecord { get; set; }

        /// <summary>
        /// Switch: \h
        /// Inserts field names from the database as column headings in the resulting table.
        /// </summary>
        public BoolFlagNode? IncludeHeaders { get; set; }

        /// <summary>
        /// Switch: \l field-argument
        /// Specifies the format to be applied to the result of the database query.
        /// If used without \b switch, an unformatted table is inserted.
        /// </summary>
        public FlaggedArgument<DatabaseTableFormatNode>? TableFormat { get; set; }

        /// <summary>
        /// Switch: \o field-argument
        /// Performance optimization - gets data at beginning of merge instead of once per record.
        /// Only use when database field doesn't rely on record-specific information.
        /// </summary>
        public FlaggedArgument<DatabaseOptimizationFlagNode>? OptimizationFlag { get; set; }

        /// <summary>
        /// Switch: \s field-argument
        /// Specifies database query instructions (SQL, QBE, Excel ranges, etc.).
        /// Quotation marks in instructions must be preceded by backslash (\).
        /// </summary>
        public FlaggedArgument<ExpressionNode>? DatabaseQueryInstruction { get; set; }

        /// <summary>
        /// Switch: \t field-argument
        /// Specifies the integral record number of the last data record to insert.
        /// </summary>
        public FlaggedArgument<NumericLiteralNode<int>>? LastRecord { get; set; }

        public List<DatabaseArgument> Order { get; set; } = new List<DatabaseArgument>();

        public DatabaseFieldInstruction(
            StringLiteralNode instruction,
            FlaggedArgument<DatabaseTableAttributesNode>? tableAttributes,
            FlaggedArgument<OdbcConnectionStringNode>? connectionStringBuilder,
            FlaggedArgument<ExpressionNode>? databasePath,
            FlaggedArgument<NumericLiteralNode<int>>? firstRecord,
            BoolFlagNode? includeHeaders,
            FlaggedArgument<DatabaseTableFormatNode>? tableFormat,
            FlaggedArgument<DatabaseOptimizationFlagNode>? optimizationFlag,
            FlaggedArgument<ExpressionNode>? databaseQueryInstruction,
            FlaggedArgument<NumericLiteralNode<int>>? lastRecord,
            List<DatabaseArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            TableAttributes = tableAttributes;
            ConnectionString = connectionStringBuilder;
            DatabasePath = databasePath;
            FirstRecord = firstRecord;
            IncludeHeaders = includeHeaders;
            TableFormat = tableFormat;
            OptimizationFlag = optimizationFlag;
            DatabaseQueryInstruction = databaseQueryInstruction;
            LastRecord = lastRecord;
            Order = order;
        }

        public System.Data.Odbc.OdbcCommand? OdbcCommand
        {
            get
            {
                string? queryInstr = DatabaseQueryInstruction?.Argument?.ToString();
                OdbcConnectionStringBuilder? connectionStr = ConnectionString?.Argument?.Value;
                if (connectionStr != null && !string.IsNullOrWhiteSpace(queryInstr))
                {
                    try
                    {
                        System.Data.Odbc.OdbcConnection connection =
                            new System.Data.Odbc.OdbcConnection(connectionStr.ToString());
                        return new OdbcCommand(queryInstr, connection);
                    }
                    catch
                    {
                        // If building fails, set to null
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToRawString() =>
            Instruction.ToString()
            + string.Concat(
                Order.Select(arg =>
                    arg switch
                    {
                        DatabaseArgument.TableAttributes => TableAttributes?.ToString()
                            ?? string.Empty,
                        DatabaseArgument.ConnectionString => ConnectionString?.ToString()
                            ?? string.Empty,
                        DatabaseArgument.DatabasePath => DatabasePath?.ToString() ?? string.Empty,
                        DatabaseArgument.FirstRecord => FirstRecord?.ToString() ?? string.Empty,
                        DatabaseArgument.IncludeHeaders => IncludeHeaders?.ToString()
                            ?? string.Empty,
                        DatabaseArgument.TableFormat => TableFormat?.ToString() ?? string.Empty,
                        DatabaseArgument.OptimizationFlag => OptimizationFlag?.ToString()
                            ?? string.Empty,
                        DatabaseArgument.DatabaseQueryInstruction =>
                            DatabaseQueryInstruction?.ToString() ?? string.Empty,
                        DatabaseArgument.LastRecord => LastRecord?.ToString() ?? string.Empty,
                        _ => string.Empty,
                    }
                )
            );

        public override IEnumerable<O> Children<O>()
        {
            if (Instruction is O o1)
            {
                yield return o1;
            }
            foreach (DatabaseArgument arg in Order)
            {
                switch (arg)
                {
                    case DatabaseArgument.TableAttributes:
                        if (TableAttributes is O ta)
                        {
                            yield return ta;
                        }
                        break;
                    case DatabaseArgument.ConnectionString:
                        if (ConnectionString is O cs)
                        {
                            yield return cs;
                        }
                        break;
                    case DatabaseArgument.DatabasePath:
                        if (DatabasePath is O dp)
                        {
                            yield return dp;
                        }
                        break;
                    case DatabaseArgument.FirstRecord:
                        if (FirstRecord is O fr)
                        {
                            yield return fr;
                        }
                        break;
                    case DatabaseArgument.IncludeHeaders:
                        if (IncludeHeaders is O ih)
                        {
                            yield return ih;
                        }
                        break;
                    case DatabaseArgument.TableFormat:
                        if (TableFormat is O tf)
                        {
                            yield return tf;
                        }
                        break;
                    case DatabaseArgument.OptimizationFlag:
                        if (OptimizationFlag is O of)
                        {
                            yield return of;
                        }
                        break;
                    case DatabaseArgument.DatabaseQueryInstruction:
                        if (DatabaseQueryInstruction is O dqi)
                        {
                            yield return dqi;
                        }
                        break;
                    case DatabaseArgument.LastRecord:
                        if (LastRecord is O lr)
                        {
                            yield return lr;
                        }
                        break;
                }
            }
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;

            if (index == 0 && replacement is StringLiteralNode instr)
            {
                current = Instruction;
                Instruction = instr;
            }
            else
            {
                index--;
                if (index >= 0 && index < Order.Count)
                {
                    DatabaseArgument arg = Order[index];
                    switch (arg)
                    {
                        case DatabaseArgument.TableAttributes:
                            if (replacement is FlaggedArgument<DatabaseTableAttributesNode> ta)
                            {
                                current = TableAttributes;
                                TableAttributes = ta;
                            }
                            break;
                        case DatabaseArgument.ConnectionString:
                            if (replacement is FlaggedArgument<OdbcConnectionStringNode> cs)
                            {
                                current = ConnectionString;
                                ConnectionString = cs;
                            }
                            break;
                        case DatabaseArgument.DatabasePath:
                            if (replacement is FlaggedArgument<ExpressionNode> dp)
                            {
                                current = DatabasePath;
                                DatabasePath = dp;
                            }
                            break;
                        case DatabaseArgument.FirstRecord:
                            if (replacement is FlaggedArgument<NumericLiteralNode<int>> fr)
                            {
                                current = FirstRecord;
                                FirstRecord = fr;
                            }
                            break;
                        case DatabaseArgument.IncludeHeaders:
                            if (replacement is BoolFlagNode ih)
                            {
                                current = IncludeHeaders;
                                IncludeHeaders = ih;
                            }
                            break;
                        case DatabaseArgument.TableFormat:
                            if (replacement is FlaggedArgument<DatabaseTableFormatNode> tf)
                            {
                                current = TableFormat;
                                TableFormat = tf;
                            }
                            break;
                        case DatabaseArgument.OptimizationFlag:
                            if (replacement is FlaggedArgument<DatabaseOptimizationFlagNode> of)
                            {
                                current = OptimizationFlag;
                                OptimizationFlag = of;
                            }
                            break;
                        case DatabaseArgument.DatabaseQueryInstruction:
                            if (replacement is FlaggedArgument<ExpressionNode> dqi)
                            {
                                current = DatabaseQueryInstruction;
                                DatabaseQueryInstruction = dqi;
                            }
                            break;
                        case DatabaseArgument.LastRecord:
                            if (replacement is FlaggedArgument<NumericLiteralNode<int>> lr)
                            {
                                current = LastRecord;
                                LastRecord = lr;
                            }
                            break;
                    }
                }
            }

            return current;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Text;

namespace OpenLanguage.WordprocessingML.ODBC
{
    /// <summary>
    /// Represents the types of database connection components for all supported database types.
    /// </summary>
    public enum ODBCConnectionComponentType
    {
        // ODBC Components
        /// <summary>Data Source Name for ODBC connections</summary>
        DataSourceName,

        /// <summary>Database file path/location (ODBC)</summary>
        DBQ,

        /// <summary>File type/format identifier (ODBC)</summary>
        FIL,

        /// <summary>Database driver name (ODBC)</summary>
        Driver,

        /// <summary>Server name or address</summary>
        Server,

        /// <summary>Database name</summary>
        Database,

        /// <summary>User ID for authentication</summary>
        UID,

        /// <summary>Password for authentication</summary>
        PWD,

        /// <summary>Connection timeout value</summary>
        ConnectionTimeout,

        /// <summary>Command timeout value</summary>
        CommandTimeout,

        // OLE DB Components
        /// <summary>Provider name for OLE DB connections</summary>
        Provider,

        /// <summary>Data Source for OLE DB connections</summary>
        DataSource,

        /// <summary>Initial Catalog (database name)</summary>
        InitialCatalog,

        /// <summary>Integrated Security setting</summary>
        IntegratedSecurity,

        /// <summary>Trusted Connection setting</summary>
        TrustedConnection,

        /// <summary>Persist Security Info setting</summary>
        PersistSecurityInfo,

        /// <summary>Connection pooling setting</summary>
        Pooling,

        // SQL Server Specific
        /// <summary>SQL Server instance name</summary>
        ServerInstance,

        /// <summary>Network Library (SQL Server)</summary>
        NetworkLibrary,

        /// <summary>Application Name (SQL Server)</summary>
        ApplicationName,

        /// <summary>Workstation ID (SQL Server)</summary>
        WorkstationID,

        /// <summary>Packet Size (SQL Server)</summary>
        PacketSize,

        /// <summary>Encrypt connection (SQL Server)</summary>
        Encrypt,

        /// <summary>Trust Server Certificate (SQL Server)</summary>
        TrustServerCertificate,

        /// <summary>Multiple Active Result Sets (SQL Server)</summary>
        MultipleActiveResultSets,

        /// <summary>Connection Lifetime (SQL Server)</summary>
        ConnectionLifetime,

        /// <summary>Connection Reset (SQL Server)</summary>
        ConnectionReset,

        /// <summary>Enlist (SQL Server)</summary>
        Enlist,

        /// <summary>Load Balance Timeout (SQL Server)</summary>
        LoadBalanceTimeout,

        /// <summary>Max Pool Size (SQL Server)</summary>
        MaxPoolSize,

        /// <summary>Min Pool Size (SQL Server)</summary>
        MinPoolSize,

        // Access/Jet Specific
        /// <summary>System Database (Access/Jet)</summary>
        SystemDB,

        /// <summary>Exclusive mode (Access/Jet)</summary>
        Exclusive,

        /// <summary>Read Only mode (Access/Jet)</summary>
        ReadOnly,

        /// <summary>Jet OLEDB Engine Type</summary>
        JetOLEDBEngineType,

        /// <summary>Jet OLEDB Database Password</summary>
        JetOLEDBDatabasePassword,

        /// <summary>Jet OLEDB System Database</summary>
        JetOLEDBSystemDatabase,

        /// <summary>Jet OLEDB Registry Path</summary>
        JetOLEDBRegistryPath,

        /// <summary>Jet OLEDB Create System Database</summary>
        JetOLEDBCreateSystemDatabase,

        /// <summary>Jet OLEDB New Database Password</summary>
        JetOLEDBNewDatabasePassword,

        /// <summary>Jet OLEDB Encrypt Database</summary>
        JetOLEDBEncryptDatabase,

        /// <summary>Jet OLEDB Don't Copy Locale on Compact</summary>
        JetOLEDBDontCopyLocaleOnCompact,

        /// <summary>Jet OLEDB Compact Without Replica Repair</summary>
        JetOLEDBCompactWithoutReplicaRepair,

        // Oracle Specific
        /// <summary>Oracle Data Source</summary>
        OracleDataSource,

        /// <summary>Oracle User Id</summary>
        OracleUserId,

        /// <summary>Oracle Password</summary>
        OraclePassword,

        /// <summary>Oracle Connection Lifetime</summary>
        OracleConnectionLifetime,

        /// <summary>Oracle Connection Timeout</summary>
        OracleConnectionTimeout,

        /// <summary>Oracle Command Timeout</summary>
        OracleCommandTimeout,

        /// <summary>Oracle Pooling</summary>
        OraclePooling,

        /// <summary>Oracle Max Pool Size</summary>
        OracleMaxPoolSize,

        /// <summary>Oracle Min Pool Size</summary>
        OracleMinPoolSize,

        // MySQL Specific
        /// <summary>MySQL Server</summary>
        MySQLServer,

        /// <summary>MySQL Port</summary>
        MySQLPort,

        /// <summary>MySQL User</summary>
        MySQLUser,

        /// <summary>MySQL Password</summary>
        MySQLPassword,

        /// <summary>MySQL Database</summary>
        MySQLDatabase,

        /// <summary>MySQL Connection Timeout</summary>
        MySQLConnectionTimeout,

        /// <summary>MySQL Default Command Timeout</summary>
        MySQLDefaultCommandTimeout,

        /// <summary>MySQL SSL Mode</summary>
        MySQLSSLMode,

        /// <summary>MySQL Charset</summary>
        MySQLCharset,

        // Excel Specific
        /// <summary>Excel version identifier</summary>
        ExcelVersion,

        /// <summary>HDR (Header Row) setting for Excel</summary>
        HDR,

        /// <summary>IMEX (Import/Export Mode) for Excel</summary>
        IMEX,

        /// <summary>Extended Properties for Excel</summary>
        ExtendedProperties,

        // dBase/FoxPro Specific
        /// <summary>dBase/FoxPro file path</summary>
        DBasePath,

        /// <summary>dBase/FoxPro CollatingSequence</summary>
        CollatingSequence,

        /// <summary>dBase/FoxPro Deleted records handling</summary>
        Deleted,

        /// <summary>dBase/FoxPro Statistics setting</summary>
        Statistics,

        /// <summary>dBase/FoxPro Threads setting</summary>
        Threads,

        /// <summary>dBase/FoxPro UserCommitSync setting</summary>
        UserCommitSync,

        // Text/CSV Specific
        /// <summary>Text file format</summary>
        Format,

        /// <summary>Text file character set</summary>
        CharacterSet,

        /// <summary>Text file first row contains column names</summary>
        FirstRowHasNames,

        /// <summary>Text file delimiter</summary>
        Delimiter,

        // General/Common
        /// <summary>Custom/unknown connection component</summary>
        Custom,
    }

    /// <summary>
    /// Represents a parsed database connection string component.
    /// </summary>
    public class ODBCConnectionComponent
    {
        /// <summary>
        /// The type of the connection component.
        /// </summary>
        public ODBCConnectionComponentType ComponentType { get; set; }

        /// <summary>
        /// The key name of the connection component.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The value of the connection component.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Initializes a new instance of the ODBCConnectionComponent class.
        /// </summary>
        public ODBCConnectionComponent(string key, string value)
        {
            Key = key;
            Value = value;
            ComponentType = ParseComponentType(key);
        }

        /// <summary>
        /// Parses the component type from the key name.
        /// </summary>
        private ODBCConnectionComponentType ParseComponentType(string key)
        {
            return key.ToUpperInvariant().Replace(" ", "").Replace("_", "") switch
            {
                // ODBC Components
                "DSN" => ODBCConnectionComponentType.DataSourceName,
                "DBQ" => ODBCConnectionComponentType.DBQ,
                "FIL" => ODBCConnectionComponentType.FIL,
                "DRIVER" => ODBCConnectionComponentType.Driver,
                "SERVER" => ODBCConnectionComponentType.Server,
                "DATABASE" => ODBCConnectionComponentType.Database,
                "UID" or "USERID" => ODBCConnectionComponentType.UID,
                "PWD" or "PASSWORD" => ODBCConnectionComponentType.PWD,
                "CONNECTIONTIMEOUT" => ODBCConnectionComponentType.ConnectionTimeout,
                "COMMANDTIMEOUT" => ODBCConnectionComponentType.CommandTimeout,

                // OLE DB Components
                "PROVIDER" => ODBCConnectionComponentType.Provider,
                "DATASOURCE" => ODBCConnectionComponentType.DataSource,
                "INITIALCATALOG" => ODBCConnectionComponentType.InitialCatalog,
                "INTEGRATEDSECURITY" => ODBCConnectionComponentType.IntegratedSecurity,
                "TRUSTEDCONNECTION" => ODBCConnectionComponentType.TrustedConnection,
                "PERSISTSECURITYINFO" => ODBCConnectionComponentType.PersistSecurityInfo,
                "POOLING" => ODBCConnectionComponentType.Pooling,

                // SQL Server Specific
                "SERVERINSTANCE" => ODBCConnectionComponentType.ServerInstance,
                "NETWORKLIBRARY" => ODBCConnectionComponentType.NetworkLibrary,
                "APPLICATIONNAME" => ODBCConnectionComponentType.ApplicationName,
                "WORKSTATIONID" => ODBCConnectionComponentType.WorkstationID,
                "PACKETSIZE" => ODBCConnectionComponentType.PacketSize,
                "ENCRYPT" => ODBCConnectionComponentType.Encrypt,
                "TRUSTSERVERCERTIFICATE" => ODBCConnectionComponentType.TrustServerCertificate,
                "MULTIPLEACTIVERESULTSETS" or "MARS" =>
                    ODBCConnectionComponentType.MultipleActiveResultSets,
                "CONNECTIONLIFETIME" => ODBCConnectionComponentType.ConnectionLifetime,
                "CONNECTIONRESET" => ODBCConnectionComponentType.ConnectionReset,
                "ENLIST" => ODBCConnectionComponentType.Enlist,
                "LOADBALANCETIMEOUT" => ODBCConnectionComponentType.LoadBalanceTimeout,
                "MAXPOOLSIZE" => ODBCConnectionComponentType.MaxPoolSize,
                "MINPOOLSIZE" => ODBCConnectionComponentType.MinPoolSize,

                // Access/Jet Specific
                "SYSTEMDB" => ODBCConnectionComponentType.SystemDB,
                "EXCLUSIVE" => ODBCConnectionComponentType.Exclusive,
                "READONLY" => ODBCConnectionComponentType.ReadOnly,
                "JETOLEDBENGINEYPE" => ODBCConnectionComponentType.JetOLEDBEngineType,
                "JETOLEDBDATABASEPASSWORD" => ODBCConnectionComponentType.JetOLEDBDatabasePassword,
                "JETOLEDBSYSTEMDATABASE" => ODBCConnectionComponentType.JetOLEDBSystemDatabase,
                "JETOLEDBREGISTRYPATH" => ODBCConnectionComponentType.JetOLEDBRegistryPath,
                "JETOLEDBCREATESYSTEMDATABASE" =>
                    ODBCConnectionComponentType.JetOLEDBCreateSystemDatabase,
                "JETOLEDBNEWDATABASEPASSWORD" =>
                    ODBCConnectionComponentType.JetOLEDBNewDatabasePassword,
                "JETOLEDBENCRYPTDATABASE" => ODBCConnectionComponentType.JetOLEDBEncryptDatabase,
                "JETOLEDBDONTCOPYLOCALONCOMPACT" =>
                    ODBCConnectionComponentType.JetOLEDBDontCopyLocaleOnCompact,
                "JETOLEDBCOMPACTWITHOUTREPLICAREPAIR" =>
                    ODBCConnectionComponentType.JetOLEDBCompactWithoutReplicaRepair,

                // Oracle Specific
                "ORACLEDATASOURCE" => ODBCConnectionComponentType.OracleDataSource,
                "ORACLEUSERID" => ODBCConnectionComponentType.OracleUserId,
                "ORACLEPASSWORD" => ODBCConnectionComponentType.OraclePassword,
                "ORACLECONNECTIONLIFETIME" => ODBCConnectionComponentType.OracleConnectionLifetime,
                "ORACLECONNECTIONTIMEOUT" => ODBCConnectionComponentType.OracleConnectionTimeout,
                "ORACLECOMMANDTIMEOUT" => ODBCConnectionComponentType.OracleCommandTimeout,
                "ORACLEPOOLING" => ODBCConnectionComponentType.OraclePooling,
                "ORACLEMAXPOOLSIZE" => ODBCConnectionComponentType.OracleMaxPoolSize,
                "ORACLEMINPOOLSIZE" => ODBCConnectionComponentType.OracleMinPoolSize,

                // MySQL Specific
                "MYSQLSERVER" => ODBCConnectionComponentType.MySQLServer,
                "MYSQLPORT" or "PORT" => ODBCConnectionComponentType.MySQLPort,
                "MYSQLUSER" or "USER" => ODBCConnectionComponentType.MySQLUser,
                "MYSQLPASSWORD" => ODBCConnectionComponentType.MySQLPassword,
                "MYSQLDATABASE" => ODBCConnectionComponentType.MySQLDatabase,
                "MYSQLCONNECTIONTIMEOUT" => ODBCConnectionComponentType.MySQLConnectionTimeout,
                "MYSQLDEFAULTCOMMANDTIMEOUT" =>
                    ODBCConnectionComponentType.MySQLDefaultCommandTimeout,
                "MYSQLSSLMODE" => ODBCConnectionComponentType.MySQLSSLMode,
                "MYSQLCHARSET" => ODBCConnectionComponentType.MySQLCharset,

                // Excel Specific
                "EXCELVERSION" => ODBCConnectionComponentType.ExcelVersion,
                "HDR" => ODBCConnectionComponentType.HDR,
                "IMEX" => ODBCConnectionComponentType.IMEX,
                "EXTENDEDPROPERTIES" => ODBCConnectionComponentType.ExtendedProperties,

                // dBase/FoxPro Specific
                "DBASEPATH" => ODBCConnectionComponentType.DBasePath,
                "COLLATINGSEQUENCE" => ODBCConnectionComponentType.CollatingSequence,
                "DELETED" => ODBCConnectionComponentType.Deleted,
                "STATISTICS" => ODBCConnectionComponentType.Statistics,
                "THREADS" => ODBCConnectionComponentType.Threads,
                "USERCOMMITSYNC" => ODBCConnectionComponentType.UserCommitSync,

                // Text/CSV Specific
                "FORMAT" => ODBCConnectionComponentType.Format,
                "CHARACTERSET" or "CHARSET" => ODBCConnectionComponentType.CharacterSet,
                "FIRSTROWHASNAMES" => ODBCConnectionComponentType.FirstRowHasNames,
                "DELIMITER" => ODBCConnectionComponentType.Delimiter,

                _ => ODBCConnectionComponentType.Custom,
            };
        }

        /// <summary>
        /// Returns the string representation of the connection component.
        /// </summary>
        public override string ToString()
        {
            string formattedKey = Key.Contains(" ") && !Key.StartsWith("\"") ? $"\"{Key}\"" : Key;
            string formattedValue =
                Value.Contains(" ") && !Value.StartsWith("\"") ? $"\"{Value}\"" : Value;
            return $"{formattedKey}={formattedValue}";
        }
    }

    /// <summary>
    /// Lexer for parsing database connection strings used in DATABASE field instructions.
    /// Handles standard connection string formats with key=value pairs separated by semicolons.
    /// </summary>
    public static class ODBCConnectionLexer
    {
        /// <summary>
        /// Parses a database connection string into an OdbcConnectionStringBuilder.
        /// </summary>
        /// <param name="connectionString">The connection string to parse.</param>
        /// <returns>An OdbcConnectionStringBuilder with parsed components.</returns>
        public static OdbcConnectionStringBuilder? Parse(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                return null;

            try
            {
                // First try parsing with OdbcConnectionStringBuilder directly
                OdbcConnectionStringBuilder builder = new OdbcConnectionStringBuilder(
                    connectionString
                );
                return builder;
            }
            catch
            {
                // If that fails, fall back to manual parsing for custom formats
                return ParseManually(connectionString);
            }
        }

        /// <summary>
        /// Manually parses a database connection string when standard ODBC parsing fails.
        /// </summary>
        /// <param name="connectionString">The connection string to parse.</param>
        /// <returns>An OdbcConnectionStringBuilder with manually parsed components.</returns>
        private static OdbcConnectionStringBuilder? ParseManually(string connectionString)
        {
            OdbcConnectionStringBuilder builder = new OdbcConnectionStringBuilder();

            if (string.IsNullOrWhiteSpace(connectionString))
                return builder;

            int currentIndex = 0;
            while (currentIndex < connectionString.Length)
            {
                // Find the end of the current component (key=value pair)
                int componentEnd = currentIndex;
                bool inQuotes = false;
                char quoteChar = '\0';

                while (componentEnd < connectionString.Length)
                {
                    char c = connectionString[componentEnd];
                    if (c == '"' || c == '\'')
                    {
                        if (inQuotes && c == quoteChar)
                        {
                            inQuotes = false;
                        }
                        else if (!inQuotes)
                        {
                            inQuotes = true;
                            quoteChar = c;
                        }
                    }
                    else if (c == ';' && !inQuotes)
                    {
                        break;
                    }
                    componentEnd++;
                }

                string componentStr = connectionString.Substring(
                    currentIndex,
                    componentEnd - currentIndex
                );
                currentIndex = componentEnd + 1;

                // Parse the key-value pair
                int equalsIndex = componentStr.IndexOf('=');
                if (equalsIndex > 0)
                {
                    string key = componentStr.Substring(0, equalsIndex).Trim();
                    string value = componentStr.Substring(equalsIndex + 1).Trim();

                    // Unquote value if necessary
                    if (
                        (value.StartsWith("\"") && value.EndsWith("\""))
                        || (value.StartsWith("'") && value.EndsWith("'"))
                    )
                    {
                        value = value.Substring(1, value.Length - 2);
                    }

                    if (!string.IsNullOrEmpty(key))
                    {
                        try
                        {
                            builder[key] = value;
                        }
                        catch
                        {
                            // If setting fails, ignore this component
                        }
                    }
                }
            }

            return builder;
        }

        /// <summary>
        /// Reconstructs a connection string from a list of components.
        /// </summary>
        /// <param name="components">The connection components.</param>
        /// <returns>The reconstructed connection string.</returns>
        public static string Reconstruct(List<ODBCConnectionComponent> components)
        {
            if (components == null || components.Count == 0)
                return string.Empty;

            List<string> parts = new List<string>();

            foreach (ODBCConnectionComponent component in components)
            {
                string value = component.Value;

                // Quote value if it contains spaces, semicolons, or special characters
                if (
                    value.Contains(" ")
                    || value.Contains(";")
                    || value.Contains("=")
                    || value.Contains("\"")
                    || value.Contains("'")
                )
                {
                    // Escape quotes in value
                    string escapedValue = value.Replace("\"", "\"\"");
                    parts.Add($"{component.Key}=\"{escapedValue}\"");
                }
                else
                {
                    parts.Add($"{component.Key}={value}");
                }
            }

            return string.Join("; ", parts);
        }
    }
}

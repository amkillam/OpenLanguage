using System;

namespace OpenLanguage.WordprocessingML
{
    /// <summary>
    /// Represents optimization flag options for DATABASE field instructions.
    /// </summary>
    public enum DatabaseOptimizationFlag
    {
        /// <summary>
        /// No optimization - query runs for each record.
        /// </summary>
        None,

        /// <summary>
        /// Query once at beginning of merge operation.
        /// </summary>
        QueryOnce,

        /// <summary>
        /// Cache results for improved performance.
        /// </summary>
        CacheResults,

        /// <summary>
        /// Use connection pooling.
        /// </summary>
        UseConnectionPooling,

        /// <summary>
        /// Optimize for large datasets.
        /// </summary>
        OptimizeForLargeData,

        /// <summary>
        /// Optimize for small datasets.
        /// </summary>
        OptimizeForSmallData,
    }

    public static class DatabaseOptimizationFlagExtensions
    {
        public static DatabaseOptimizationFlag? TryParse(string? s)
        {
            return s?.Trim().ToLowerInvariant() switch
            {
                "none" => DatabaseOptimizationFlag.None,
                "queryonce" or "query_once" or "query-once" => DatabaseOptimizationFlag.QueryOnce,
                "cacheresults" or "cache_results" or "cache-results" =>
                    DatabaseOptimizationFlag.CacheResults,
                "useconnectionpooling" or "use_connection_pooling" or "use-connection-pooling" =>
                    DatabaseOptimizationFlag.UseConnectionPooling,
                "optimizeforlargedata" or "optimize_for_large_data" or "optimize-for-large-data" =>
                    DatabaseOptimizationFlag.OptimizeForLargeData,
                "optimizeforsmalldata" or "optimize_for_small_data" or "optimize-for-small-data" =>
                    DatabaseOptimizationFlag.OptimizeForSmallData,
                _ => null,
            };
        }

        public static DatabaseOptimizationFlag Parse(string? s)
        {
            DatabaseOptimizationFlag? val = TryParse(s);
            if (val == null)
            {
                throw new ArgumentException($"Invalid database optimization flag: {s}");
            }

            return val.Value;
        }
    }
}

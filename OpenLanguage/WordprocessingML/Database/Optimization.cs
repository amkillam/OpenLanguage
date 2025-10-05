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
}

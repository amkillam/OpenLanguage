using System;

namespace OpenLanguage.WordprocessingML
{
    /// <summary>
    /// Represents table formatting attributes for DATABASE field instructions.
    /// Values can be combined using bitwise OR operations.
    /// </summary>
    [Flags]
    public enum DatabaseTableAttributes : int
    {
        /// <summary>
        /// No formatting attributes (0).
        /// </summary>
        None = 0,

        /// <summary>
        /// Apply borders to the table (1).
        /// </summary>
        Borders = 1,

        /// <summary>
        /// Apply shading to the table (2).
        /// </summary>
        Shading = 2,

        /// <summary>
        /// Apply font formatting to the table (4).
        /// </summary>
        Font = 4,

        /// <summary>
        /// Apply color formatting to the table (8).
        /// </summary>
        Color = 8,

        /// <summary>
        /// Apply AutoFit to the table (16).
        /// </summary>
        AutoFit = 16,

        /// <summary>
        /// Apply special formatting to heading rows (32).
        /// </summary>
        HeadingRows = 32,

        /// <summary>
        /// Apply special formatting to the last row (64).
        /// </summary>
        LastRow = 64,

        /// <summary>
        /// Apply special formatting to the first column (128).
        /// </summary>
        FirstColumn = 128,

        /// <summary>
        /// Apply special formatting to the last column (256).
        /// </summary>
        LastColumn = 256,
    }
}

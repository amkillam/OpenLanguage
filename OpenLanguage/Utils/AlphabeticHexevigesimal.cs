using System;
using System.Text;

namespace OpenLanguage.Utils
{
    /// <summary>
    /// Provides formatting services to convert a UInt64 to and from an Excel-style
    /// alphabetic column string (e.g., 1 -> "A", 27 -> "AA").
    ///
    /// Usage for formatting:
    ///   UInt64 value = 27;
    ///   string formatted = value.ToString("AH", AlphabeticHexevigesimalProvider.Instance); // "AA"
    ///
    /// Usage for parsing:
    ///   string column = "AA";
    ///   UInt64 parsed = AlphabeticHexevigesimalProvider.Parse(column); // 27
    /// </summary>
    public class AlphabeticHexevigesimalProvider : IFormatProvider, ICustomFormatter
    {
        /// <summary>
        /// A convenient singleton instance for use in formatting calls.
        /// </summary>
        private const int Base = 26;

        #region Parsing (String -> UInt64)

        /// <summary>
        /// Converts the Excel-style alphabetic string to its UInt64 equivalent.
        /// Note: This is a static helper method because UInt64.TryParse is not extensible
        /// for custom alphabetic systems via IFormatProvider.
        /// </summary>
        /// <param name="s">A string containing the alphabetic number to convert (e.g., "A", "AZ").</param>
        /// <returns>The UInt64 equivalent of the number contained in s.</returns>
        /// <exception cref="ArgumentNullException">s is null.</exception>
        /// <exception cref="FormatException">s is not in the correct format (A-Z).</exception>
        /// <exception cref="OverflowException">s represents a number larger than UInt64.MaxValue.</exception>
        public static UInt64 Parse(string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException(nameof(s));
            }
            if (TryParse(s, out UInt64 result))
            {
                return result;
            }
            throw new FormatException(
                "Input string was not in a correct format. It must contain only characters A-Z."
            );
        }

        /// <summary>
        /// Tries to convert the Excel-style alphabetic string to its UInt64 equivalent.
        /// </summary>
        /// <param name="s">A string containing the alphabetic number to convert.</param>
        /// <param name="result">When this method returns, contains the UInt64 equivalent, if the conversion succeeded.</param>
        /// <returns>true if s was converted successfully; otherwise, false.</returns>
        public static bool TryParse(string s, out UInt64 result)
        {
            result = 0;
            if (string.IsNullOrEmpty(s))
            {
                return false;
            }

            UInt64 value = 0;
            foreach (char c in s)
            {
                char upperChar = char.ToUpperInvariant(c);
                if (upperChar < 'A' || upperChar > 'Z')
                {
                    return false; // Invalid character
                }

                try
                {
                    // checked block throws OverflowException on overflow
                    checked
                    {
                        value *= Base;
                        value += (UInt64)(upperChar - 'A' + 1);
                    }
                }
                catch (OverflowException)
                {
                    return false;
                }
            }

            result = value;
            return true;
        }

        #endregion

        #region Formatting (UInt64 -> String) - IFormatProvider and ICustomFormatter

        /// <summary>
        /// Returns an object that provides formatting services for the specified type.
        /// </summary>
        public object? GetFormat(Type? formatType)
        {
            // Return this object if a custom formatter is requested.
            return formatType == typeof(ICustomFormatter) ? this : null;
        }

        /// <summary>
        /// Converts the value of a specified object to an equivalent string representation
        /// using specified format and culture-specific formatting information.
        /// </summary>
        public string Format(string? format, object? arg, IFormatProvider? formatProvider)
        {
            // We only handle our custom "AH" (Alphabetic Hexevigesimal) format specifier.
            if (
                string.IsNullOrEmpty(format)
                || !format.Equals("AH", StringComparison.OrdinalIgnoreCase)
            )
            {
                return HandleDefaultFormat(format, arg, formatProvider);
            }

            // We only format unsigned integer types.
            if (arg is not (UInt64 or UInt32 or UInt16 or byte))
            {
                return HandleDefaultFormat(format, arg, formatProvider);
            }

            UInt64 value = Convert.ToUInt64(arg);

            if (value == 0)
            {
                return string.Empty;
            }

            StringBuilder sb = new StringBuilder();
            UInt64 current = value;

            while (current > 0)
            {
                UInt64 remainder = (current - 1) % Base;
                sb.Insert(0, (char)('A' + remainder));
                current = (current - 1) / Base;
            }

            return sb.ToString();
        }

        private static string HandleDefaultFormat(
            string? format,
            object? arg,
            IFormatProvider? formatProvider
        )
        {
            if (arg is IFormattable formattable)
            {
                return formattable.ToString(format, formatProvider);
            }
            return arg?.ToString() ?? string.Empty;
        }

        #endregion
    }
}

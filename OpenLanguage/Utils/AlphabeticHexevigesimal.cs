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
        private const byte Base = 26;

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
        public static N Parse<N>(string? s)
            where N : System.Numerics.INumber<N>,
                System.Numerics.IBinaryNumber<N>,
                System.Numerics.INumberBase<N>,
                IParsable<N>,
                IFormattable,
                System.Numerics.IMinMaxValue<N>
        {
            if (s == null)
            {
                throw new ArgumentNullException(nameof(s));
            }
            if (TryParse(s, out N result))
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
        public static bool TryParse<N>(string? s, out N result)
            where N : System.Numerics.INumber<N>,
                System.Numerics.IBinaryNumber<N>,
                System.Numerics.INumberBase<N>,
                IParsable<N>,
                IFormattable,
                System.Numerics.IMinMaxValue<N>
        {
            result = N.CreateChecked(0);
            if (string.IsNullOrEmpty(s))
            {
                return false;
            }

            N value = N.CreateChecked(0);
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
                        value *= N.CreateChecked(Base);
                        value += N.CreateChecked(upperChar - 'A' + 1);
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
        public string Format<N>(string? format, N? arg, IFormatProvider? formatProvider = null)
            where N : System.Numerics.INumber<N>,
                System.Numerics.IBinaryNumber<N>,
                System.Numerics.INumberBase<N>,
                IParsable<N>,
                IFormattable,
                System.Numerics.IMinMaxValue<N>
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
            if (arg is not (ulong or uint or ushort or byte))
            {
                return HandleDefaultFormat(format, arg, formatProvider);
            }

            N value = arg;

            if (value == N.CreateChecked(0))
            {
                return string.Empty;
            }

            StringBuilder sb = new StringBuilder();
            N current = value;

            while (current > N.CreateChecked(0))
            {
                N remainder = (current - N.CreateChecked(1)) % N.CreateChecked(Base);
                sb.Insert(0, Convert.ToChar(N.CreateChecked('A') + remainder));
                current = (current - N.CreateChecked(1)) / N.CreateChecked(Base);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Converts the value of a specified object to an equivalent string representation
        /// using specified format and culture-specific formatting information.
        /// </summary>
        public string Format(string? format, object? arg, IFormatProvider? formatProvider = null)
        {
            switch (arg)
            {
                case ulong u64:
                    return Format(format, u64, formatProvider);
                case uint u32:
                    return Format(format, u32, formatProvider);
                case ushort u16:
                    return Format(format, u16, formatProvider);
                case byte b:
                    return Format(format, b, formatProvider);
                default:
                    return HandleDefaultFormat(format, arg, formatProvider);
            }
        }

        private static string HandleDefaultFormat(
            string? format,
            object? arg,
            IFormatProvider? formatProvider
        )
        {
            return arg switch
            {
                null => string.Empty,
                string s => s,
                UInt128 u128 => u128.ToString(format, formatProvider),
                Int128 i128 => i128.ToString(format, formatProvider),
                UIntPtr uptr => uptr.ToString(format, formatProvider),
                IntPtr iptr => iptr.ToString(format, formatProvider),
                UInt64 u64 => u64.ToString(format, formatProvider),
                Int64 i64 => i64.ToString(format, formatProvider),
                UInt32 u32 => u32.ToString(format, formatProvider),
                Int32 i32 => i32.ToString(format, formatProvider),
                UInt16 u16 => u16.ToString(format, formatProvider),
                Int16 i16 => i16.ToString(format, formatProvider),
                Byte b => b.ToString(format, formatProvider),
                SByte sb => sb.ToString(format, formatProvider),
                IFormattable formattable => formattable.ToString(format, formatProvider),
                _ => arg?.ToString() ?? string.Empty,
            };
        }
    }
}

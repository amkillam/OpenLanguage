using System;
using System.Linq;
using System.Text;

namespace OpenLanguage.Utils
{
    /// <summary>
    /// Provides formatting services to convert a UInt64 to and from an Excel-style
    /// alphabetic column string (e.g., 1 -> "A", 27 -> "AA").
    ///
    /// Usage for formatting:
    ///   UInt64 value = 27;
    ///   string formatted = value.ToString("AH", new AlphabeticHexevigesimalProvider()); // "AA"
    ///
    /// Usage for parsing:
    ///   string column = "AA";
    ///   UInt64 parsed = AlphabeticHexevigesimalProvider.Parse<UInt64>(column); // 27
    /// </summary>
    public class AlphabeticHexevigesimalProvider : IFormatProvider, ICustomFormatter
    {
        private const byte Base = 26;

        /// <summary>
        /// Converts the Excel-style alphabetic string to its numeric equivalent.
        /// </summary>
        /// <param name="s">A string containing the alphabetic number to convert (e.g., "A", "AZ").</param>
        /// <returns>The numeric equivalent of the number contained in s.</returns>
        /// <exception cref="ArgumentException">s is null, empty, whitespace, or contains invalid characters.</exception>
        /// <exception cref="OverflowException">s represents a number larger than the specified type can hold.</exception>
        public static N Parse<N>(string? s)
            where N : System.Numerics.INumber<N>,
                System.Numerics.IBinaryNumber<N>,
                System.Numerics.INumberBase<N>,
                IParsable<N>,
                IFormattable,
                System.Numerics.IMinMaxValue<N>
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                throw new ArgumentException(
                    "Input cannot be null, empty, or whitespace.",
                    nameof(s)
                );
            }

            if (s.Any(c => c < 'A' || c > 'Z'))
            {
                throw new ArgumentException(
                    "Input string must contain only uppercase letters A-Z.",
                    nameof(s)
                );
            }

            if (!TryParse(s, out N result))
            {
                throw new OverflowException(
                    "The input string represents a number larger than the specified type can hold."
                );
            }

            return result;
        }

        /// <summary>
        /// Tries to convert the Excel-style alphabetic string to its numeric equivalent.
        /// </summary>
        /// <param name="s">A string containing the alphabetic number to convert.</param>
        /// <param name="result">When this method returns, contains the numeric equivalent, if the conversion succeeded.</param>
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
                if (c < 'A' || c > 'Z')
                {
                    return false; // Invalid character
                }

                try
                {
                    checked
                    {
                        value *= N.CreateChecked(Base);
                        value += N.CreateChecked(c - 'A' + 1);
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
            if (
                string.IsNullOrEmpty(format)
                || !format.Equals("AH", StringComparison.OrdinalIgnoreCase)
            )
            {
                throw new FormatException($"The format of '{format}' is invalid.");
            }

            if (arg == null)
            {
                throw new ArgumentNullException(nameof(arg));
            }

            if (N.IsZero(arg) || N.IsNegative(arg))
            {
                throw new ArgumentOutOfRangeException(
                    nameof(arg),
                    "Value must be a positive number."
                );
            }

            N value = arg;
            StringBuilder sb = new StringBuilder();
            N current = value;

            while (current > N.CreateChecked(0))
            {
                N remainder = (current - N.CreateChecked(1)) % N.CreateChecked(Base);
                sb.Insert(0, (char)('A' + byte.CreateChecked(remainder)));
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
                case long i64:
                    if (i64 < 0)
                    {
                        throw new ArgumentOutOfRangeException(
                            nameof(arg),
                            "Value must be a positive number."
                        );
                    }
                    return Format(format, (ulong)i64, formatProvider);
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
                IFormattable formattable => formattable.ToString(format, formatProvider),
                _ => arg?.ToString() ?? string.Empty,
            };
        }
    }
}

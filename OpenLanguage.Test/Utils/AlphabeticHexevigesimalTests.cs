using System;
using Xunit;

namespace OpenLanguage.Utils.Tests
{
    /// <summary>
    /// Tests for the AlphabeticHexevigesimal utility class
    /// </summary>
    public class AlphabeticHexevigesimalTests
    {
        private readonly AlphabeticHexevigesimalProvider _provider =
            new AlphabeticHexevigesimalProvider();

        [Theory]
        [InlineData(1, "A")]
        [InlineData(2, "B")]
        [InlineData(26, "Z")]
        [InlineData(27, "AA")]
        [InlineData(28, "AB")]
        [InlineData(52, "AZ")]
        [InlineData(53, "BA")]
        [InlineData(702, "ZZ")]
        [InlineData(703, "AAA")]
        [InlineData(728, "AAZ")]
        [InlineData(729, "ABA")]
        public void Format_WithValidNumbers_ReturnsCorrectAlphabeticRepresentation(
            ulong input,
            string expected
        )
        {
            string result = _provider.Format("AH", input, _provider);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("A", 1)]
        [InlineData("B", 2)]
        [InlineData("Z", 26)]
        [InlineData("AA", 27)]
        [InlineData("AB", 28)]
        [InlineData("AZ", 52)]
        [InlineData("BA", 53)]
        [InlineData("ZZ", 702)]
        [InlineData("AAA", 703)]
        [InlineData("AAZ", 728)]
        [InlineData("ABA", 729)]
        public void Parse_WithValidAlphabeticStrings_ReturnsCorrectNumber(
            string input,
            ulong expected
        )
        {
            ulong result = AlphabeticHexevigesimalProvider.Parse<ulong>(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0)]
        public void Format_WithZero_ThrowsArgumentException(ulong input)
        {
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(
                () => _provider.Format("AH", input, _provider)
            );
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("0")]
        [InlineData("1")]
        [InlineData("ABC1")]
        [InlineData("A1B")]
        [InlineData("@")]
        [InlineData("a")] // lowercase
        public void Parse_WithInvalidStrings_ThrowsArgumentException(string? input)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
                AlphabeticHexevigesimalProvider.Parse<ulong>(input!)
            );
        }

        [Fact]
        public void Format_Parse_RoundTrip_ReturnsOriginalValue()
        {
            // Test round-trip conversion for various values
            ulong[] testValues = { 1, 26, 27, 52, 53, 702, 703, 728, 729, 1000, 16384 };

            foreach (ulong original in testValues)
            {
                string formatted = _provider.Format("AH", original, _provider);
                ulong parsed = AlphabeticHexevigesimalProvider.Parse<ulong>(formatted);

                Assert.Equal(original, parsed);
            }
        }

        [Fact]
        public void Parse_Format_RoundTrip_ReturnsOriginalString()
        {
            // Test round-trip conversion for various strings
            string[] testStrings = { "A", "Z", "AA", "AZ", "BA", "ZZ", "AAA", "ABC", "XFD" };

            foreach (string original in testStrings)
            {
                ulong parsed = AlphabeticHexevigesimalProvider.Parse<ulong>(original);
                string formatted = _provider.Format("AH", parsed, _provider);

                Assert.Equal(original, formatted);
            }
        }

        [Theory]
        [InlineData("XFD", 16384)] // Excel's maximum column
        [InlineData("IV", 256)] // Excel 2003's maximum column
        public void Parse_ExcelColumnLimits_ReturnsCorrectValues(
            string columnString,
            ulong expectedValue
        )
        {
            ulong result = AlphabeticHexevigesimalProvider.Parse<ulong>(columnString);

            Assert.Equal(expectedValue, result);
        }

        [Theory]
        [InlineData(16384, "XFD")] // Excel's maximum column
        [InlineData(256, "IV")] // Excel 2003's maximum column
        public void Format_ExcelColumnLimits_ReturnsCorrectStrings(
            ulong columnNumber,
            string expectedString
        )
        {
            string result = _provider.Format("AH", columnNumber, _provider);

            Assert.Equal(expectedString, result);
        }

        [Fact]
        public void Format_LargeNumbers_HandlesCorrectly()
        {
            // Test with increasingly large numbers
            ulong[] largeNumbers = { 18278, 475254, 12356630 }; // AAA + some, AAAA + some, etc.

            foreach (ulong number in largeNumbers)
            {
                string formatted = _provider.Format("AH", number, _provider);
                ulong parsed = AlphabeticHexevigesimalProvider.Parse<ulong>(formatted);

                Assert.Equal(number, parsed);
                Assert.True(formatted.Length > 0);
                Assert.All(formatted, c => Assert.True(c >= 'A' && c <= 'Z'));
            }
        }

        [Theory]
        [InlineData("A", 1)]
        [InlineData("AA", 2)]
        [InlineData("AAA", 3)]
        [InlineData("AAAA", 4)]
        public void Parse_StringLength_CorrespondsToExpectedPattern(
            string input,
            int expectedCharCount
        )
        {
            // This test verifies the length pattern for strings with all A's
            ulong result = AlphabeticHexevigesimalProvider.Parse<ulong>(input);

            // Verify that the string has the expected length
            Assert.Equal(expectedCharCount, input.Length);

            // Verify that we can format it back
            string formatted = _provider.Format("AH", result, _provider);
            Assert.Equal(input, formatted);
        }

        [Fact]
        public void Provider_ImplementsIFormatProvider()
        {
            // Act & Assert
            Assert.IsAssignableFrom<IFormatProvider>(_provider);
        }

        [Fact]
        public void Provider_GetFormat_ReturnsCorrectType()
        {
            object? result = _provider.GetFormat(typeof(ICustomFormatter));

            Assert.NotNull(result);
            Assert.IsType<AlphabeticHexevigesimalProvider>(result);
        }

        [Fact]
        public void Provider_GetFormat_WithWrongType_ReturnsNull()
        {
            object? result = _provider.GetFormat(typeof(string));

            Assert.Null(result);
        }

        [Theory]
        [InlineData("AH")]
        [InlineData("ah")]
        [InlineData("Ah")]
        [InlineData("aH")]
        public void Format_WithDifferentFormatCases_HandlesCorrectly(string format)
        {
            string result = _provider.Format(format, 1UL, _provider);

            Assert.Equal("A", result);
        }

        [Theory]
        [InlineData("G")] // Invalid format string
        [InlineData("ABC")] // Invalid format string
        [InlineData("")] // Empty format string
        [InlineData(null)] // Null format string
        public void Format_WithInvalidFormat_ThrowsFormatException(string? format)
        {
            // Act & Assert
            Assert.Throws<FormatException>(() => _provider.Format(format!, 1UL, _provider));
        }

        [Fact]
        public void AlphabeticHexevigesimal_Sequential_ValuesAreCorrect()
        {
            // Test the first several values in sequence
            string[] expectedSequence =
            {
                "A",
                "B",
                "C",
                "D",
                "E",
                "F",
                "G",
                "H",
                "I",
                "J",
                "K",
                "L",
                "M",
                "N",
                "O",
                "P",
                "Q",
                "R",
                "S",
                "T",
                "U",
                "V",
                "W",
                "X",
                "Y",
                "Z",
                "AA",
                "AB",
                "AC",
                "AD",
                "AE",
            };

            for (int i = 0; i < expectedSequence.Length; i++)
            {
                ulong value = (ulong)(i + 1);
                string formatted = _provider.Format("AH", value, _provider);
                Assert.Equal(expectedSequence[i], formatted);

                ulong parsed = AlphabeticHexevigesimalProvider.Parse<ulong>(expectedSequence[i]);
                Assert.Equal(value, parsed);
            }
        }

        [Fact]
        public void AlphabeticHexevigesimal_Performance_HandlesLargeValues()
        {
            // Test performance with reasonably large values
            System.Diagnostics.Stopwatch stopwatch = System.Diagnostics.Stopwatch.StartNew();

            for (ulong i = 1; i <= 10000; i++)
            {
                string formatted = _provider.Format("AH", i, _provider);
                ulong parsed = AlphabeticHexevigesimalProvider.Parse<ulong>(formatted);
                Assert.Equal(i, parsed);
            }

            stopwatch.Stop();
            Assert.True(
                stopwatch.ElapsedMilliseconds < 5000,
                $"Performance test took {stopwatch.ElapsedMilliseconds}ms, expected < 5000ms"
            );
        }
    }
}
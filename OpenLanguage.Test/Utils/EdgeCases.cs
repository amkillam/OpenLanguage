using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace OpenLanguage.Utils.Tests
{
    /// <summary>
    /// Comprehensive edge case tests for utility functions with explicit typing
    /// </summary>
    public class UtilEdgeCaseTests
    {
        public static readonly AlphabeticHexevigesimalProvider _provider =
            new AlphabeticHexevigesimalProvider();

        [Theory]
        [InlineData(1, "A")]
        [InlineData(26, "Z")]
        [InlineData(27, "AA")]
        [InlineData(52, "AZ")]
        [InlineData(53, "BA")]
        [InlineData(702, "ZZ")]
        [InlineData(703, "AAA")]
        [InlineData(728, "AAZ")]
        [InlineData(729, "ABA")]
        [InlineData(18278, "ZZZ")]
        [InlineData(18279, "AAAA")]
        [InlineData(475254, "ZZZZ")]
        [InlineData(475255, "AAAAA")]
        public void Format_WithValidInputs_ReturnsExpectedString(ulong input, string expected)
        {
            string result = UtilEdgeCaseTests._provider.Format("AH", input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("A", 1uL)]
        [InlineData("Z", 26uL)]
        [InlineData("AA", 27uL)]
        [InlineData("AZ", 52uL)]
        [InlineData("BA", 53uL)]
        [InlineData("ZZ", 702uL)]
        [InlineData("AAA", 703uL)]
        [InlineData("AAZ", 728uL)]
        [InlineData("ABA", 729uL)]
        [InlineData("ZZZ", 18278uL)]
        [InlineData("AAAA", 18279uL)]
        [InlineData("ZZZZ", 475254uL)]
        [InlineData("AAAAA", 475255uL)]
        public void Parse_WithValidInputs_ReturnsExpectedNumber(string input, ulong expected)
        {
            ulong result = AlphabeticHexevigesimalProvider.Parse<ulong>(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-100)]
        [InlineData(long.MinValue)]
        public void Format_WithInvalidInputs_ThrowsArgumentException(long input)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _provider.Format("AH", input));
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("\t\n\r")]
        [InlineData(null)]
        public void Parse_WithNullOrWhitespace_ThrowsArgumentException(string? input)
        {
            Assert.Throws<ArgumentException>(() =>
                AlphabeticHexevigesimalProvider.Parse<ulong>(input!)
            );
        }

        [Theory]
        [InlineData("1")]
        [InlineData("AB1")]
        [InlineData("A1B")]
        [InlineData("123")]
        [InlineData("A@B")]
        [InlineData("A-B")]
        [InlineData("A_B")]
        [InlineData("A B")]
        public void Parse_WithInvalidCharacters_ThrowsArgumentException(string input)
        {
            Assert.Throws<ArgumentException>(() =>
                AlphabeticHexevigesimalProvider.Parse<ulong>(input)
            );
        }

        [Theory]
        [InlineData(1)]
        [InlineData(26)]
        [InlineData(27)]
        [InlineData(702)]
        [InlineData(703)]
        [InlineData(18278)]
        [InlineData(18279)]
        [InlineData(475254)]
        [InlineData(1000000)]
        public void RoundTripConversion_IsConsistent(ulong originalNumber)
        {
            string alphabetic = UtilEdgeCaseTests._provider.Format("AH", originalNumber);
            ulong convertedBack = AlphabeticHexevigesimalProvider.Parse<ulong>(alphabetic);

            Assert.Equal(originalNumber, convertedBack);
        }

        [Theory]
        [InlineData("A")]
        [InlineData("Z")]
        [InlineData("AA")]
        [InlineData("ZZ")]
        [InlineData("AAA")]
        [InlineData("ZZZ")]
        [InlineData("AAAA")]
        [InlineData("ZZZZ")]
        [InlineData("AAAAA")]
        public void ReverseRoundTripConversion_IsConsistent(string originalString)
        {
            ulong number = AlphabeticHexevigesimalProvider.Parse<ulong>(originalString);
            string convertedBack = UtilEdgeCaseTests._provider.Format("AH", number);

            Assert.Equal(originalString, convertedBack);
        }

        [Fact]
        public void Format_WithMaxUInt64_HandlesCorrectly()
        {
            ulong maxValue = ulong.MaxValue;

            string result = UtilEdgeCaseTests._provider.Format("AH", maxValue);

            Assert.NotNull(result);
            Assert.True(result.Length > 0);
            Assert.All(result, c => Assert.True(c >= 'A' && c <= 'Z'));

            // Verify round trip
            ulong convertedBack = AlphabeticHexevigesimalProvider.Parse<ulong>(result);
            Assert.Equal(maxValue, convertedBack);
        }

        [Fact]
        public void Parse_WithVeryLongString_HandlesCorrectly()
        {
            string longString = new string('A', 10); // AAAAAAAAAA

            ulong result = AlphabeticHexevigesimalProvider.Parse<ulong>(longString);

            Assert.True(result > 0);

            // Verify round trip
            string convertedBack = UtilEdgeCaseTests._provider.Format("AH", result);
            Assert.Equal(longString, convertedBack);
        }

        [Theory]
        [InlineData("A", "B")]
        [InlineData("Z", "AA")]
        [InlineData("AZ", "BA")]
        [InlineData("ZZ", "AAA")]
        [InlineData("AAZ", "ABA")]
        public void SequentialValues_FollowCorrectPattern(string current, string expectedNext)
        {
            ulong currentNumber = AlphabeticHexevigesimalProvider.Parse<ulong>(current);
            ulong nextNumber = currentNumber + 1;
            string actualNext = UtilEdgeCaseTests._provider.Format("AH", nextNumber);

            Assert.Equal(expectedNext, actualNext);
        }

        [Fact]
        public void ConversionPerformance_HandlesLargeVolume()
        {
            ulong[] testNumbers = Enumerable
                .Range(1, 10000)
                .Select((int v) => Convert.ToUInt64(v))
                .ToArray();

            System.Diagnostics.Stopwatch stopwatch = System.Diagnostics.Stopwatch.StartNew();

            foreach (ulong number in testNumbers)
            {
                string alphabetic = UtilEdgeCaseTests._provider.Format("AH", number);
                ulong converted = AlphabeticHexevigesimalProvider.Parse<ulong>(alphabetic);
                Assert.Equal(number, converted);
            }

            stopwatch.Stop();

            Assert.True(
                stopwatch.ElapsedMilliseconds < 1000,
                $"Converting 10000 numbers took {stopwatch.ElapsedMilliseconds}ms, expected < 1000ms"
            );
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(26, 1)]
        [InlineData(27, 2)]
        [InlineData(702, 2)]
        [InlineData(703, 3)]
        [InlineData(18278, 3)]
        [InlineData(18279, 4)]
        [InlineData(475254, 4)]
        [InlineData(475255, 5)]
        public void AlphabeticLength_FollowsExpectedPattern(ulong input, int expectedLength)
        {
            string result = UtilEdgeCaseTests._provider.Format("AH", input);

            Assert.Equal(expectedLength, result.Length);
        }

        [Fact]
        public void ConcurrentConversions_ThreadSafe()
        {
            ulong[] testNumbers = Enumerable
                .Range(1, 1000)
                .Select((int v) => Convert.ToUInt64(v))
                .ToArray();

            System.Threading.Tasks.Parallel.ForEach(
                testNumbers,
                number =>
                {
                    string alphabetic = UtilEdgeCaseTests._provider.Format("AH", number);
                    ulong converted = AlphabeticHexevigesimalProvider.Parse<ulong>(alphabetic);
                    Assert.Equal(number, converted);
                }
            );
        }

        [Theory]
        [InlineData("CRPXNLS", 1148355331UL)]
        public void Parse_WithLargeValue_HandlesCorrectly(string input, ulong expected)
        {
            ulong result = AlphabeticHexevigesimalProvider.Parse<ulong>(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Format_WithBoundaryValues_HandlesCorrectly()
        {
            // Test boundary values where the pattern changes
            Dictionary<ulong, string> boundaryTests = new Dictionary<ulong, string>
            {
                { 25, "Y" },
                { 26, "Z" },
                { 27, "AA" },
                { 51, "AY" },
                { 52, "AZ" },
                { 53, "BA" },
                { 701, "ZY" },
                { 702, "ZZ" },
                { 703, "AAA" },
                { 18277, "ZZY" },
                { 18278, "ZZZ" },
                { 18279, "AAAA" },
            };

            foreach (KeyValuePair<ulong, string> test in boundaryTests)
            {
                string result = UtilEdgeCaseTests._provider.Format("AH", test.Key);

                Assert.Equal(test.Value, result);
            }
        }
    }

    /// <summary>
    /// Tests for edge cases in string and text processing utilities
    /// </summary>
    public class StringUtilityEdgeCaseTests
    {
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("\t")]
        [InlineData("\n")]
        [InlineData("\r")]
        [InlineData("\r\n")]
        [InlineData("   ")]
        [InlineData("\t\n\r")]
        public void IsNullOrWhiteSpace_WithVariousWhitespace_ReturnsTrue(string input)
        {
            bool result = string.IsNullOrWhiteSpace(input);

            Assert.True(result);
        }

        [Theory]
        [InlineData("a")]
        [InlineData("A")]
        [InlineData("1")]
        [InlineData("!")]
        [InlineData(" a")]
        [InlineData("a ")]
        [InlineData(" a ")]
        [InlineData("hello world")]
        public void IsNullOrWhiteSpace_WithNonWhitespace_ReturnsFalse(string input)
        {
            bool result = string.IsNullOrWhiteSpace(input);

            Assert.False(result);
        }

        [Theory]
        [InlineData("hello", "HELLO")]
        [InlineData("Hello", "HELLO")]
        [InlineData("HELLO", "HELLO")]
        [InlineData("hELLo", "HELLO")]
        [InlineData("123", "123")]
        [InlineData("hello123", "HELLO123")]
        [InlineData("hello world", "HELLO WORLD")]
        [InlineData("", "")]
        public void ToUpperInvariant_WithVariousInputs_ReturnsExpectedResult(
            string input,
            string expected
        )
        {
            string result = input.ToUpperInvariant();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("HELLO", "hello")]
        [InlineData("Hello", "hello")]
        [InlineData("hello", "hello")]
        [InlineData("HeLLo", "hello")]
        [InlineData("123", "123")]
        [InlineData("HELLO123", "hello123")]
        [InlineData("HELLO WORLD", "hello world")]
        [InlineData("", "")]
        public void ToLowerInvariant_WithVariousInputs_ReturnsExpectedResult(
            string input,
            string expected
        )
        {
            string result = input.ToLowerInvariant();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("  hello  ", "hello")]
        [InlineData("\thello\t", "hello")]
        [InlineData("\nhello\n", "hello")]
        [InlineData("\r\nhello\r\n", "hello")]
        [InlineData("   hello world   ", "hello world")]
        [InlineData("hello", "hello")]
        [InlineData("   ", "")]
        public void Trim_WithVariousWhitespace_ReturnsExpectedResult(string input, string expected)
        {
            string result = input.Trim();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("hello,world", ',', new[] { "hello", "world" })]
        [InlineData("a,b,c,d", ',', new[] { "a", "b", "c", "d" })]
        [InlineData("hello", ',', new[] { "hello" })]
        [InlineData("", ',', new[] { "" })]
        [InlineData(",", ',', new[] { "", "" })]
        [InlineData("a,,b", ',', new[] { "a", "", "b" })]
        [InlineData(",a,b,", ',', new[] { "", "a", "b", "" })]
        public void Split_WithCharSeparator_ReturnsExpectedParts(
            string input,
            char separator,
            string[] expected
        )
        {
            string[] result = input.Split(separator);

            Assert.Equal(expected.Length, result.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.Equal(expected[i], result[i]);
            }
        }

        [Theory]
        [InlineData("hello world", "hello", true)]
        [InlineData("hello world", "world", true)]
        [InlineData("hello world", "lo wo", true)]
        [InlineData("hello world", "HELLO", false)]
        [InlineData("hello world", "xyz", false)]
        [InlineData("", "", true)]
        [InlineData("hello", "", true)]
        [InlineData("", "hello", false)]
        public void Contains_WithVariousInputs_ReturnsExpectedResult(
            string input,
            string value,
            bool expected
        )
        {
            bool result = input.Contains(value);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("hello", "h", true)]
        [InlineData("hello", "hello", true)]
        [InlineData("hello", "H", false)]
        [InlineData("hello", "world", false)]
        [InlineData("", "", true)]
        [InlineData("hello", "", true)]
        [InlineData("", "h", false)]
        public void StartsWith_WithVariousInputs_ReturnsExpectedResult(
            string input,
            string value,
            bool expected
        )
        {
            bool result = input.StartsWith(value);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("hello", "o", true)]
        [InlineData("hello", "hello", true)]
        [InlineData("hello", "O", false)]
        [InlineData("hello", "world", false)]
        [InlineData("", "", true)]
        [InlineData("hello", "", true)]
        [InlineData("", "o", false)]
        public void EndsWith_WithVariousInputs_ReturnsExpectedResult(
            string input,
            string value,
            bool expected
        )
        {
            bool result = input.EndsWith(value);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("hello world", "world", "universe", "hello universe")]
        [InlineData("hello world world", "world", "universe", "hello universe universe")]
        [InlineData("hello", "world", "universe", "hello")]
        [InlineData("", "world", "universe", "")]
        [InlineData("world", "world", "universe", "universe")]
        [InlineData("worldworld", "world", "universe", "universeuniverse")]
        public void Replace_WithVariousInputs_ReturnsExpectedResult(
            string input,
            string oldValue,
            string newValue,
            string expected
        )
        {
            string result = input.Replace(oldValue, newValue);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("hello", 0, 3, "hel")]
        [InlineData("hello", 1, 3, "ell")]
        [InlineData("hello", 2, 3, "llo")]
        [InlineData("hello", 0, 5, "hello")]
        [InlineData("hello", 5, 0, "")]
        [InlineData("", 0, 0, "")]
        public void Substring_WithValidParameters_ReturnsExpectedResult(
            string input,
            int startIndex,
            int length,
            string expected
        )
        {
            string result = input.Substring(startIndex, length);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("hello", -1, 3)]
        [InlineData("hello", 0, 6)]
        [InlineData("hello", 6, 0)]
        [InlineData("hello", 3, 3)]
        public void Substring_WithInvalidParameters_ThrowsArgumentOutOfRangeException(
            string input,
            int startIndex,
            int length
        )
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => input.Substring(startIndex, length));
        }

        [Fact]
        public void StringComparison_WithUnicodeCharacters_HandlesCorrectly()
        {
            string unicodeString1 = "café";
            string unicodeString2 = "café"; // Same visually but must ensure preservation for each
            string unicodeString3 = "CAFÉ";

            Assert.Equal(unicodeString2, unicodeString1, StringComparer.Ordinal);
            Assert.NotEqual(unicodeString3, unicodeString1, StringComparer.Ordinal);
            Assert.Equal(unicodeString3, unicodeString1, StringComparer.OrdinalIgnoreCase);
        }

        [Fact]
        public void StringInterning_WorksCorrectly()
        {
            string literal = "test";
            string constructed = new string("test".ToCharArray());
            string interned = string.Intern(constructed);

            Assert.True(ReferenceEquals(literal, interned));
            Assert.False(ReferenceEquals(literal, constructed));
        }
    }

    /// <summary>
    /// Tests for collection and enumerable utility edge cases
    /// </summary>
    public class CollectionUtilityEdgeCaseTests
    {
        [Fact]
        public void EmptyList_HasCorrectProperties()
        {
            List<string> emptyList = new List<string>();

            Assert.Empty(emptyList);
            Assert.False(emptyList.Any());
        }

        [Fact]
        public void SingleItemList_HasCorrectProperties()
        {
            List<string> singleItemList = new List<string> { "item" };

            Assert.Single(singleItemList);
            Assert.Equal("item", singleItemList.First());
            Assert.Equal("item", singleItemList.Last());
        }

        [Fact]
        public void ListWithNullItems_HandlesCorrectly()
        {
            List<string?> listWithNulls = new List<string?> { "item1", null, "item3", null };

            Assert.Equal(4, listWithNulls.Count);
            Assert.Equal(2, listWithNulls.Count(item => item == null));
            Assert.Equal(2, listWithNulls.Count(item => item != null));
            Assert.Contains(null, listWithNulls);
            Assert.Contains("item1", listWithNulls);
        }

        [Fact]
        public void DuplicateItemsList_HandlesCorrectly()
        {
            List<string> listWithDuplicates = new List<string> { "a", "b", "a", "c", "b", "a" };

            IEnumerable<string> distinctItems = listWithDuplicates.Distinct();
            IEnumerable<IGrouping<string, string>> groupedItems = listWithDuplicates.GroupBy(x =>
                x
            );

            Assert.Equal(6, listWithDuplicates.Count);
            Assert.Equal(3, distinctItems.Count());
            Assert.Equal(3, groupedItems.Count());
            Assert.Equal(3, groupedItems.First(g => g.Key == "a").Count());
        }

        [Fact]
        public void ListSorting_WithCustomComparer_WorksCorrectly()
        {
            List<string> unsortedList = new List<string> { "banana", "Apple", "cherry", "Date" };

            List<string> sortedOrdinal = unsortedList
                .OrderBy(x => x, StringComparer.Ordinal)
                .ToList();
            List<string> sortedIgnoreCase = unsortedList
                .OrderBy(x => x, StringComparer.OrdinalIgnoreCase)
                .ToList();

            Assert.Equal(new[] { "Apple", "Date", "banana", "cherry" }, sortedOrdinal);
            Assert.Equal(new[] { "Apple", "banana", "cherry", "Date" }, sortedIgnoreCase);
        }

        [Fact]
        public void EnumerableOperations_WithLargeSequence_PerformEfficiently()
        {
            IEnumerable<ulong> largeSequence = Enumerable
                .Range(1, 1000000)
                .Select((int v) => Convert.ToUInt64(v));

            System.Diagnostics.Stopwatch stopwatch = System.Diagnostics.Stopwatch.StartNew();

            ulong sum = Convert.ToUInt64(largeSequence.Select(n => (long)n).Sum());
            int count = largeSequence.Count();
            ulong max = largeSequence.Max();
            ulong min = largeSequence.Min();
            double average = (double)sum / (double)count;

            stopwatch.Stop();

            Assert.Equal(500000500000uL, sum);
            Assert.Equal(1000000, count);
            Assert.Equal(1000000uL, max);
            Assert.Equal(1uL, min);
            Assert.Equal(500000.5, average);
            Assert.True(
                stopwatch.ElapsedMilliseconds < 1000,
                $"Operations took {stopwatch.ElapsedMilliseconds}ms, expected < 1000ms"
            );
        }

        [Fact]
        public void ConcurrentCollectionOperations_ThreadSafe()
        {
            System.Collections.Concurrent.ConcurrentBag<ulong> concurrentBag =
                new System.Collections.Concurrent.ConcurrentBag<ulong>();
            ulong[] numbersToAdd = Enumerable
                .Range(1, 10000)
                .Select((int v) => Convert.ToUInt64(v))
                .ToArray();

            System.Threading.Tasks.Parallel.ForEach(
                numbersToAdd,
                number =>
                {
                    concurrentBag.Add(number);
                }
            );

            Assert.Equal(10000, concurrentBag.Count);
            Assert.Contains(1uL, concurrentBag);
            Assert.Contains(10000uL, concurrentBag);
            Assert.Equal(
                numbersToAdd.Select((ulong v) => Convert.ToInt64(v)).Sum(),
                concurrentBag.Select((ulong v) => Convert.ToInt64(v)).Sum()
            );
        }
    }
}

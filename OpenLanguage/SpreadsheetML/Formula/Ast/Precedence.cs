using System;

namespace OpenLanguage.SpreadsheetML.Formula
{
    internal static class Precedence
    {
        public const Int32 Primary = 10;
        public const Int32 Percent = 9;
        public const Int32 Unary = 8;
        public const Int32 Power = 7;
        public const Int32 Multiplicative = 6;
        public const Int32 Additive = 5;
        public const Int32 Concat = 4;
        public const Int32 Comparison = 3;
        public const Int32 Range = 2;
        public const Int32 Intersection = 2;
        public const Int32 Union = 1;
        public const Int32 Default = 0;
    }
}

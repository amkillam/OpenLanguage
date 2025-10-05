using System;

namespace OpenLanguage.WordprocessingML.Ast
{
    internal static class Precedence
    {
        public const int Primary = 10;
        public const int Percent = 9;
        public const int Unary = 8;
        public const int Power = 7;
        public const int Multiplicative = 6;
        public const int Additive = 5;
        public const int Concat = 4;
        public const int Comparison = 3;
        public const int Range = 2;
        public const int Intersection = 2;
        public const int Union = 1;
        public const int Default = 0;
    }
}

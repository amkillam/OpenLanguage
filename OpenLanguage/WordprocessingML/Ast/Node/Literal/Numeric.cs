using System.Collections.Generic;

namespace OpenLanguage.WordprocessingML.Ast
{
    public class NumericLiteralNode<T> : ExpressionNode
        where T : System.IComparable<T>,
            System.IEquatable<T>,
            System.Numerics.INumber<T>,
            System.Numerics.INumberBase<T>,
            System.Numerics.IMinMaxValue<T>
    {
        public string Raw { get; set; }
        public T Value { get; set; }
        public string FormatSpecifier { get; set; }
        public ExpressionNode? Unit { get; set; } // E.g. `"`

        public NumericLiteralNode(
            string raw,
            T value,
            string formatSpecifier,
            ExpressionNode? unit = null, // E.g. `"`
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Raw = raw;
            Value = value;
            FormatSpecifier = formatSpecifier;
            Unit = unit;
        }

        public override string ToRawString() => Raw + (Unit?.ToRawString() ?? string.Empty);

        public NumericLiteralNode(
            T value,
            string formatSpecifier,
            ExpressionNode? unit = null, // E.g. `"`
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Value = value;
            FormatSpecifier = formatSpecifier;
            Raw =
                value?.ToString(formatSpecifier, System.Globalization.CultureInfo.InvariantCulture)
                ?? string.Empty;
            Unit = unit;
        }

        public NumericLiteralNode(
            T value,
            ExpressionNode? unit = null, // E.g. `"`
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Value = value;
            FormatSpecifier = string.Empty;
            Raw = value?.ToString() ?? string.Empty;
            Unit = unit;
        }

        public override IEnumerable<O> Children<O>()
        {
            if (Unit is O unit)
            {
                yield return unit;
            }

            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;
            if (index == 0 && replacement is ExpressionNode expr)
            {
                current = Unit;
                Unit = expr;
            }
            return current;
        }

        public static implicit operator NumericLiteralNode<byte>(NumericLiteralNode<T> node)
        {
            return new NumericLiteralNode<byte>(
                node.Raw,
                byte.CreateSaturating(node.Value),
                node.FormatSpecifier,
                node.Unit,
                node.LeadingWhitespace,
                node.TrailingWhitespace
            );
        }

        public static implicit operator NumericLiteralNode<char>(NumericLiteralNode<T> node)
        {
            return new NumericLiteralNode<char>(
                node.Raw,
                (char)(byte.CreateSaturating(node.Value)),
                node.FormatSpecifier,
                node.Unit,
                node.LeadingWhitespace,
                node.TrailingWhitespace
            );
        }

        public static implicit operator NumericLiteralNode<decimal>(NumericLiteralNode<T> node)
        {
            return new NumericLiteralNode<decimal>(
                node.Raw,
                decimal.CreateSaturating(node.Value),
                node.FormatSpecifier,
                node.Unit,
                node.LeadingWhitespace,
                node.TrailingWhitespace
            );
        }

        public static implicit operator NumericLiteralNode<double>(NumericLiteralNode<T> node)
        {
            return new NumericLiteralNode<double>(
                node.Raw,
                double.CreateSaturating(node.Value),
                node.FormatSpecifier,
                node.Unit,
                node.LeadingWhitespace,
                node.TrailingWhitespace
            );
        }

        public static implicit operator NumericLiteralNode<float>(NumericLiteralNode<T> node)
        {
            return new NumericLiteralNode<float>(
                node.Raw,
                float.CreateSaturating(node.Value),
                node.FormatSpecifier,
                node.Unit,
                node.LeadingWhitespace,
                node.TrailingWhitespace
            );
        }

        public static implicit operator NumericLiteralNode<int>(NumericLiteralNode<T> node)
        {
            return new NumericLiteralNode<int>(
                node.Raw,
                int.CreateSaturating(node.Value),
                node.FormatSpecifier,
                node.Unit,
                node.LeadingWhitespace,
                node.TrailingWhitespace
            );
        }

        public static implicit operator NumericLiteralNode<long>(NumericLiteralNode<T> node)
        {
            return new NumericLiteralNode<long>(
                node.Raw,
                long.CreateSaturating(node.Value),
                node.FormatSpecifier,
                node.Unit,
                node.LeadingWhitespace,
                node.TrailingWhitespace
            );
        }

        public static implicit operator NumericLiteralNode<nint>(NumericLiteralNode<T> node)
        {
            return new NumericLiteralNode<nint>(
                node.Raw,
                nint.CreateSaturating(node.Value),
                node.FormatSpecifier,
                node.Unit,
                node.LeadingWhitespace,
                node.TrailingWhitespace
            );
        }

        public static implicit operator NumericLiteralNode<nuint>(NumericLiteralNode<T> node)
        {
            return new NumericLiteralNode<nuint>(
                node.Raw,
                nuint.CreateSaturating(node.Value),
                node.FormatSpecifier,
                node.Unit,
                node.LeadingWhitespace,
                node.TrailingWhitespace
            );
        }

        public static implicit operator NumericLiteralNode<sbyte>(NumericLiteralNode<T> node)
        {
            return new NumericLiteralNode<sbyte>(
                node.Raw,
                sbyte.CreateSaturating(node.Value),
                node.FormatSpecifier,
                node.Unit,
                node.LeadingWhitespace,
                node.TrailingWhitespace
            );
        }

        public static implicit operator NumericLiteralNode<short>(NumericLiteralNode<T> node)
        {
            return new NumericLiteralNode<short>(
                node.Raw,
                short.CreateSaturating(node.Value),
                node.FormatSpecifier,
                node.Unit,
                node.LeadingWhitespace,
                node.TrailingWhitespace
            );
        }

        public static implicit operator NumericLiteralNode<uint>(NumericLiteralNode<T> node)
        {
            return new NumericLiteralNode<uint>(
                node.Raw,
                uint.CreateSaturating(node.Value),
                node.FormatSpecifier,
                node.Unit,
                node.LeadingWhitespace,
                node.TrailingWhitespace
            );
        }

        public static implicit operator NumericLiteralNode<ulong>(NumericLiteralNode<T> node)
        {
            return new NumericLiteralNode<ulong>(
                node.Raw,
                ulong.CreateSaturating(node.Value),
                node.FormatSpecifier,
                node.Unit,
                node.LeadingWhitespace,
                node.TrailingWhitespace
            );
        }

        public static implicit operator NumericLiteralNode<ushort>(NumericLiteralNode<T> node)
        {
            return new NumericLiteralNode<ushort>(
                node.Raw,
                ushort.CreateSaturating(node.Value),
                node.FormatSpecifier,
                node.Unit,
                node.LeadingWhitespace,
                node.TrailingWhitespace
            );
        }
    }

    public class EmptyNumericLiteralNode<T> : NumericLiteralNode<T>
        where T : System.IComparable<T>,
            System.IEquatable<T>,
            System.Numerics.INumber<T>,
            System.Numerics.INumberBase<T>,
            System.Numerics.IMinMaxValue<T>
    {
        public EmptyNumericLiteralNode(
            ExpressionNode? unit = null, // E.g. `"`
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(string.Empty, T.Zero, string.Empty, unit, leadingWhitespace, trailingWhitespace)
        { }
    }
}

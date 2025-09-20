using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using OpenLanguage.Utils;

namespace OpenLanguage.SpreadsheetML.Formula.Ast
{
    public class NumericLiteralFormatSpecifier<N>
        where N : System.Numerics.INumber<N>,
            System.Numerics.IBinaryNumber<N>,
            System.Numerics.INumberBase<N>,
            IParsable<N>,
            IFormattable,
            System.Numerics.IMinMaxValue<N>,
            System.IConvertible
    {
        public string Specifier { get; set; } = "G9";

        public NumericLiteralFormatSpecifier(string? specifier = null)
        {
            if (specifier == null)
            {
                if (NumericUtils.IsIntegerType<N>())
                {
                    Specifier = "D";
                }
                else
                {
                    Specifier = "G9";
                }
            }
            else
            {
                Specifier = specifier;
            }
        }
    }

    public class NumericLiteralNode<N> : ExpressionNode
        where N : struct,
            System.Numerics.INumber<N>,
            System.Numerics.IBinaryNumber<N>,
            System.Numerics.INumberBase<N>,
            IParsable<N>,
            IFormattable,
            System.Numerics.IMinMaxValue<N>,
            System.IConvertible
    {
        public N? Value { get; set; } = null;
        private string RawValue { get; set; }
        public NumericLiteralFormatSpecifier<N> FormatSpecifier { get; set; } =
            new NumericLiteralFormatSpecifier<N>();
        public override int Precedence => Ast.Precedence.Primary;

        public NumericLiteralNode(
            N value,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Value = value;
            RawValue = value.ToString(FormatSpecifier.Specifier, CultureInfo.InvariantCulture);
        }

        private static N? TryParseOctal(string rawText)
        {
            string trimmed = rawText.Trim();
            string octalPart =
                trimmed.Length >= 2
                && (trimmed.StartsWith("0o", StringComparison.OrdinalIgnoreCase))
                    ? trimmed.Substring(2)
                    : trimmed;
            octalPart = octalPart.Trim();
            if (string.IsNullOrEmpty(octalPart))
            {
                return null;
            }

            N result = N.CreateChecked(0);
            foreach (char c in octalPart)
            {
                switch (c)
                {
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                        result = result * N.CreateChecked(8) + N.CreateChecked(c - '0');
                        break;
                    default:
                        {
                            if (!char.IsWhiteSpace(c))
                            {
                                return null;
                            }
                            break;
                        }
                }
            }
            return result;
        }

        private static N? TryParseByPrefix(string rawText)
        {
            string trimmed = rawText.Trim();
            if (string.IsNullOrEmpty(trimmed))
            {
                return null;
            }

            string prefix =
                trimmed.Length >= 2 ? trimmed.Substring(0, 2).ToLowerInvariant() : string.Empty;

            N? result = null;
            switch (prefix)
            {
                case "0x":
                case "&h":
                    {
                        if (
                            N.TryParse(
                                trimmed,
                                NumberStyles.HexNumber | NumberStyles.AllowHexSpecifier,
                                CultureInfo.InvariantCulture,
                                out N parseHexResult
                            )
                        )
                        {
                            result = parseHexResult;
                        }
                        break;
                    }
                case "0b":
                case "&b":
                    {
                        // NOTE: 'NumberStyles.BinaryNumber' does not exist. The correct style for
                        // parsing binary strings with a "0b" prefix is 'AllowBinarySpecifier'
                        // (requires .NET 7 or later).
                        if (
                            N.TryParse(
                                trimmed,
                                NumberStyles.AllowBinarySpecifier | NumberStyles.BinaryNumber,
                                CultureInfo.InvariantCulture,
                                out N parseBinaryResult
                            )
                        )
                        {
                            result = parseBinaryResult;
                        }
                        else if (
                            N.TryParse(
                                trimmed,
                                NumberStyles.HexNumber,
                                CultureInfo.InvariantCulture,
                                out N parseBinaryHexFallbackResult
                            )
                        )
                        {
                            result = parseBinaryHexFallbackResult;
                        }
                        break;
                    }
                case "0o":
                case "&o":
                    {
                        N? parseOctalResult = TryParseOctal(trimmed);
                        if (parseOctalResult != null)
                        {
                            result = parseOctalResult.Value;
                        }
                        break;
                    }
                default:
                    {
                        if (
                            N.TryParse(
                                trimmed,
                                NumberStyles.Any,
                                CultureInfo.InvariantCulture,
                                out N parseDecimalResult
                            )
                        )
                        {
                            result = parseDecimalResult;
                        }
                        break;
                    }
            }
            return result;
        }

        public NumericLiteralNode(
            string rawText,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            RawValue = rawText;
            Value = TryParseByPrefix(rawText);
        }

        public NumericLiteralNode(
            string rawText,
            string formatSpecifier,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            RawValue = rawText;
            Value = TryParseByPrefix(rawText);
            FormatSpecifier = new NumericLiteralFormatSpecifier<N>(formatSpecifier);
        }

        public NumericLiteralNode(
            N value,
            string formatSpecifier,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Value = value;
            FormatSpecifier = new NumericLiteralFormatSpecifier<N>(formatSpecifier);
            RawValue = value.ToString(FormatSpecifier.Specifier, CultureInfo.InvariantCulture);
        }

        public override string ToRawString() => RawValue;

        public override IEnumerable<O> Children<O>()
        {
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement) => null;
    }

    public class StringNode : ExpressionNode
    {
        public string Value { get; set; }
        public override int Precedence => Ast.Precedence.Primary;

        public StringNode(
            string value,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Value = value;
        }

        public override string ToRawString() => $"\"{Value.Replace("\"", "\"\"")}\"";

        public override IEnumerable<O> Children<O>()
        {
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement) => null;
    }

    public class LogicalNode : ExpressionNode
    {
        public bool Value { get; set; }
        public string RawText { get; set; }
        public override int Precedence => Ast.Precedence.Primary;

        public LogicalNode(
            bool value,
            string rawText,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Value = value;
            RawText = rawText;
        }

        public override string ToRawString() => RawText;

        public override IEnumerable<O> Children<O>()
        {
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement) => null;
    }

    public class EmptyArgumentNode : ExpressionNode
    {
        public override int Precedence => Ast.Precedence.Primary;

        public EmptyArgumentNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace) { }

        public override string ToRawString() => string.Empty;

        public override IEnumerable<O> Children<O>()
        {
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement) => null;
    }

    public class WhitespaceNode : Node
    {
        public string Raw { get; set; }

        public WhitespaceNode(string whitespaceStr)
        {
            Raw = whitespaceStr;
        }

        public override string ToString() => Raw;

        public override IEnumerable<O> Children<O>()
        {
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement) => null;
    }

    public class LeftBracketNode : CharacterLiteralNode
    {
        public LeftBracketNode(
            string rawStr,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(rawStr, leadingWhitespace, trailingWhitespace) { }
    }

    public class RightBracketNode : CharacterLiteralNode
    {
        public RightBracketNode(
            string rawStr,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(rawStr, leadingWhitespace, trailingWhitespace) { }
    }
}

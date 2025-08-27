using System;
using System.Collections.Generic;
using System.Globalization;

namespace OpenLanguage.SpreadsheetML.Formula.Ast
{
    public class NumericLiteralNode<N> : ExpressionNode
        where N : System.Numerics.INumber<N>,
            System.Numerics.IBinaryNumber<N>,
            System.Numerics.INumberBase<N>,
            IParsable<N>,
            IFormattable,
            System.Numerics.IMinMaxValue<N>
    {
        public N Value { get; set; }
        public string FormatSpecifier { get; set; } = "D";
        public override int Precedence => Ast.Precedence.Primary;

        public NumericLiteralNode(
            N value,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Value = value;
        }

        public NumericLiteralNode(
            string rawText,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Value = N.Parse(rawText, CultureInfo.InvariantCulture);
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
            FormatSpecifier = formatSpecifier;
        }

        public NumericLiteralNode(
            string rawText,
            string formatSpecifier,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Value = N.Parse(rawText, CultureInfo.InvariantCulture);
            FormatSpecifier = formatSpecifier;
        }

        public override string ToRawString() =>
            Value.ToString(FormatSpecifier, CultureInfo.InvariantCulture);

        public override IEnumerable<O> Children<O>()
        {
            yield break;
        }

        public override Node? ReplaceChild(Int32 index, Node replacement) => null;
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

        public override Node? ReplaceChild(Int32 index, Node replacement) => null;
    }

    public class LogicalNode : ExpressionNode
    {
        public bool Value { get; set; }
        public override int Precedence => Ast.Precedence.Primary;

        public LogicalNode(
            bool value,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Value = value;
        }

        public override string ToRawString() => Value ? "TRUE" : "FALSE";

        public override IEnumerable<O> Children<O>()
        {
            yield break;
        }

        public override Node? ReplaceChild(Int32 index, Node replacement) => null;
    }

    public class ErrorNode : ExpressionNode
    {
        public string ErrorType { get; set; }
        public override int Precedence => Ast.Precedence.Primary;

        public ErrorNode(
            string errorType,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            ErrorType = errorType;
        }

        public override string ToRawString() => ErrorType;

        public override IEnumerable<O> Children<O>()
        {
            yield break;
        }

        public override Node? ReplaceChild(Int32 index, Node replacement) => null;
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

        public override Node? ReplaceChild(Int32 index, Node replacement) => null;
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

        public override Node? ReplaceChild(Int32 index, Node replacement) => null;
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

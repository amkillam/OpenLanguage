using System.Collections.Generic;

namespace OpenLanguage.WordprocessingML.Ast
{
    public class StringLiteralNode : ExpressionNode, System.IEquatable<StringLiteralNode>
    {
        public string Value { get; set; }

        public StringLiteralNode(
            string value,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Value = value;
        }

        // Leading and trailing whitespace is added in the base class's `ToString` method.
        public override string ToRawString() => Value;

        public override IEnumerable<O> Children<O>()
        {
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement) => null;

        public bool Equals(StringLiteralNode? other) =>
            !ReferenceEquals(null, other)
            && (
                ReferenceEquals(this, other)
                || string.Equals(ToString(), other.ToString(), System.StringComparison.Ordinal)
            );

        public override bool Equals(object? obj) => obj is StringLiteralNode other && Equals(other);

        public override int GetHashCode() => System.StringComparer.Ordinal.GetHashCode(ToString());

        public static bool operator ==(StringLiteralNode? left, StringLiteralNode? right) =>
            System.Collections.Generic.EqualityComparer<StringLiteralNode>.Default.Equals(
                left,
                right
            );

        public static bool operator !=(StringLiteralNode? left, StringLiteralNode? right) =>
            !System.Collections.Generic.EqualityComparer<StringLiteralNode>.Default.Equals(
                left,
                right
            );

        public static implicit operator string(StringLiteralNode node) => node.ToString();
    }
}

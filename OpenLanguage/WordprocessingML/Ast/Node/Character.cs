using System.Collections.Generic;

namespace OpenLanguage.WordprocessingML.Ast
{
    public class CharacterLiteralNode : StringLiteralNode
    {
        public CharacterLiteralNode(
            string raw,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(raw, leadingWhitespace, trailingWhitespace) { }
    }

    public class BackslashNode : CharacterLiteralNode
    {
        public BackslashNode(
            string rawStr,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(rawStr, leadingWhitespace, trailingWhitespace) { }
    }

    public class EqualLiteralNode : CharacterLiteralNode
    {
        public EqualLiteralNode(
            string rawStr,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(rawStr, leadingWhitespace, trailingWhitespace) { }
    }

    public class NotEqualLiteralNode : CharacterLiteralNode
    {
        public NotEqualLiteralNode(
            string rawStr,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(rawStr, leadingWhitespace, trailingWhitespace) { }
    }

    public class LessThanLiteralNode : CharacterLiteralNode
    {
        public LessThanLiteralNode(
            string rawStr,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(rawStr, leadingWhitespace, trailingWhitespace) { }
    }

    public class LessThanOrEqualLiteralNode : CharacterLiteralNode
    {
        public LessThanOrEqualLiteralNode(
            string rawStr,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(rawStr, leadingWhitespace, trailingWhitespace) { }
    }

    public class GreaterThanLiteralNode : CharacterLiteralNode
    {
        public GreaterThanLiteralNode(
            string rawStr,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(rawStr, leadingWhitespace, trailingWhitespace) { }
    }

    public class GreaterThanOrEqualLiteralNode : CharacterLiteralNode
    {
        public GreaterThanOrEqualLiteralNode(
            string rawStr,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(rawStr, leadingWhitespace, trailingWhitespace) { }
    }

    public class PlusLiteralNode : CharacterLiteralNode
    {
        public PlusLiteralNode(
            string rawStr,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(rawStr, leadingWhitespace, trailingWhitespace) { }
    }

    public class MinusLiteralNode : CharacterLiteralNode
    {
        public MinusLiteralNode(
            string rawStr,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(rawStr, leadingWhitespace, trailingWhitespace) { }
    }

    public class AsteriskLiteralNode : CharacterLiteralNode
    {
        public AsteriskLiteralNode(
            string rawStr,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(rawStr, leadingWhitespace, trailingWhitespace) { }
    }

    public class SlashLiteralNode : CharacterLiteralNode
    {
        public SlashLiteralNode(
            string rawStr,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(rawStr, leadingWhitespace, trailingWhitespace) { }
    }

    public class CaretLiteralNode : CharacterLiteralNode
    {
        public CaretLiteralNode(
            string rawStr,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(rawStr, leadingWhitespace, trailingWhitespace) { }
    }

    public class LeftParenNode : CharacterLiteralNode
    {
        public LeftParenNode(
            string raw,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(raw, leadingWhitespace, trailingWhitespace) { }
    }

    public class RightParenNode : CharacterLiteralNode
    {
        public RightParenNode(
            string raw,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(raw, leadingWhitespace, trailingWhitespace) { }
    }

    public class LeftBraceNode : CharacterLiteralNode
    {
        public LeftBraceNode(
            string raw,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(raw, leadingWhitespace, trailingWhitespace) { }
    }

    public class RightBraceNode : CharacterLiteralNode
    {
        public RightBraceNode(
            string raw,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(raw, leadingWhitespace, trailingWhitespace) { }
    }

    public class QuoteLiteralNode : CharacterLiteralNode
    {
        public QuoteLiteralNode(
            string value,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(value, leadingWhitespace, trailingWhitespace) { }
    }

    public class Quoted<T> : ExpressionNode
        where T : ExpressionNode
    {
        public QuoteLiteralNode LeftQuote { get; set; }
        public T Inner { get; set; }
        public QuoteLiteralNode RightQuote { get; set; }

        public Quoted(
            QuoteLiteralNode leftQuote,
            T inner,
            QuoteLiteralNode rightQuote,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Inner = inner;
            LeftQuote = leftQuote;
            RightQuote = rightQuote;
        }

        public override string ToRawString() =>
            LeftQuote.ToString() + Inner.ToString() + RightQuote.ToString();

        public override IEnumerable<O> Children<O>()
        {
            if (LeftQuote is O oLeft)
            {
                yield return oLeft;
            }
            if (Inner is O oInner)
            {
                yield return oInner;
            }
            if (RightQuote is O oRight)
            {
                yield return oRight;
            }
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;
            if (index == 0 && replacement is QuoteLiteralNode left)
            {
                current = LeftQuote;
                LeftQuote = left;
            }
            else if (index == 1 && replacement is T inner)
            {
                current = Inner;
                Inner = inner;
            }
            else if (index == 2 && replacement is QuoteLiteralNode right)
            {
                current = RightQuote;
                RightQuote = right;
            }

            return current;
        }
    }

    public class LeftGuillemetLiteralNode : CharacterLiteralNode
    {
        public LeftGuillemetLiteralNode(
            string raw,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(raw, leadingWhitespace, trailingWhitespace) { }
    }

    public class RightGuillemetLiteralNode : CharacterLiteralNode
    {
        public RightGuillemetLiteralNode(
            string raw,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(raw, leadingWhitespace, trailingWhitespace) { }
    }

    public class LeftBracketNode : CharacterLiteralNode
    {
        public LeftBracketNode(
            string raw,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(raw, leadingWhitespace, trailingWhitespace) { }
    }

    public class RightBracketNode : CharacterLiteralNode
    {
        public RightBracketNode(
            string raw,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(raw, leadingWhitespace, trailingWhitespace) { }
    }

    public class PercentLiteralNode : CharacterLiteralNode
    {
        public PercentLiteralNode(
            string raw,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(raw, leadingWhitespace, trailingWhitespace) { }
    }
}

using System.Collections.Generic;

namespace OpenLanguage.SpreadsheetML.Formula.Ast
{
    public class CharacterLiteralNode : ExpressionNode
    {
        public string Raw { get; set; }

        public CharacterLiteralNode(
            string raw,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Raw = raw;
        }

        public override string ToRawString() => Raw;

        public override IEnumerable<O> Children<O>()
        {
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement) => null;

        public override int Precedence => Ast.Precedence.Primary;
    }

    public class QuestionMarkNode : CharacterLiteralNode
    {
        public QuestionMarkNode(
            string rawStr,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(rawStr, leadingWhitespace, trailingWhitespace) { }
    }

    public class BangNode : CharacterLiteralNode
    {
        public BangNode(
            string rawStr,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(rawStr, leadingWhitespace, trailingWhitespace) { }
    }

    public class ColonNode : CharacterLiteralNode
    {
        public ColonNode(
            string rawStr,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(rawStr, leadingWhitespace, trailingWhitespace) { }
    }

    public class SemicolonNode : CharacterLiteralNode
    {
        public SemicolonNode(
            string rawStr,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(rawStr, leadingWhitespace, trailingWhitespace) { }
    }

    public class CommaNode : CharacterLiteralNode
    {
        public CommaNode(
            string rawStr,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(rawStr, leadingWhitespace, trailingWhitespace) { }
    }

    public class AtSymbolLiteralNode : CharacterLiteralNode
    {
        public AtSymbolLiteralNode(
            string rawStr,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(rawStr, leadingWhitespace, trailingWhitespace) { }
    }

    // Operator literal nodes
    public class PlusOperatorLiteralNode : CharacterLiteralNode
    {
        public PlusOperatorLiteralNode(
            string rawStr,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(rawStr, leadingWhitespace, trailingWhitespace) { }
    }

    public class MinusOperatorLiteralNode : CharacterLiteralNode
    {
        public MinusOperatorLiteralNode(
            string rawStr,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(rawStr, leadingWhitespace, trailingWhitespace) { }
    }

    public class AsteriskOperatorLiteralNode : CharacterLiteralNode
    {
        public AsteriskOperatorLiteralNode(
            string rawStr,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(rawStr, leadingWhitespace, trailingWhitespace) { }
    }

    public class SlashOperatorLiteralNode : CharacterLiteralNode
    {
        public SlashOperatorLiteralNode(
            string rawStr,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(rawStr, leadingWhitespace, trailingWhitespace) { }
    }

    public class CaretOperatorLiteralNode : CharacterLiteralNode
    {
        public CaretOperatorLiteralNode(
            string rawStr,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(rawStr, leadingWhitespace, trailingWhitespace) { }
    }

    public class AmpersandOperatorLiteralNode : CharacterLiteralNode
    {
        public AmpersandOperatorLiteralNode(
            string rawStr,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(rawStr, leadingWhitespace, trailingWhitespace) { }
    }

    public class NotEqualOperatorLiteralNode : CharacterLiteralNode
    {
        public NotEqualOperatorLiteralNode(
            string rawStr,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(rawStr, leadingWhitespace, trailingWhitespace) { }
    }

    public class LessThanOrEqualOperatorLiteralNode : CharacterLiteralNode
    {
        public LessThanOrEqualOperatorLiteralNode(
            string rawStr,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(rawStr, leadingWhitespace, trailingWhitespace) { }
    }

    public class LessThanOperatorLiteralNode : CharacterLiteralNode
    {
        public LessThanOperatorLiteralNode(
            string rawStr,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(rawStr, leadingWhitespace, trailingWhitespace) { }
    }

    public class GreaterThanOrEqualOperatorLiteralNode : CharacterLiteralNode
    {
        public GreaterThanOrEqualOperatorLiteralNode(
            string rawStr,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(rawStr, leadingWhitespace, trailingWhitespace) { }
    }

    public class GreaterThanOperatorLiteralNode : CharacterLiteralNode
    {
        public GreaterThanOperatorLiteralNode(
            string rawStr,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(rawStr, leadingWhitespace, trailingWhitespace) { }
    }

    public class EqualOperatorLiteralNode : CharacterLiteralNode
    {
        public EqualOperatorLiteralNode(
            string rawStr,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(rawStr, leadingWhitespace, trailingWhitespace) { }
    }

    public class PercentOperatorLiteralNode : CharacterLiteralNode
    {
        public PercentOperatorLiteralNode(
            string rawStr,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(rawStr, leadingWhitespace, trailingWhitespace) { }
    }

    public class HashOperatorLiteralNode : CharacterLiteralNode
    {
        public HashOperatorLiteralNode(
            string rawStr,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(rawStr, leadingWhitespace, trailingWhitespace) { }
    }

    public class IntersectionOperatorLiteralNode : CharacterLiteralNode
    {
        public IntersectionOperatorLiteralNode(
            string rawStr,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(rawStr, leadingWhitespace, trailingWhitespace) { }
    }
}

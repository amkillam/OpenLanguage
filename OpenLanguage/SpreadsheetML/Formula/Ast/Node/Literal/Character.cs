using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

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

        public override Node? ReplaceChild(Int32 index, Node replacement) => null;

        public override Int32 Precedence => Ast.Precedence.Primary;
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
}

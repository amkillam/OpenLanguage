using System.Collections.Generic;

namespace OpenLanguage.WordprocessingML.Ast
{
    public abstract class SeparatorNode : CharacterLiteralNode
    {
        protected SeparatorNode(
            string raw,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(raw, leadingWhitespace, trailingWhitespace) { }
    }

    public class CommaNode : SeparatorNode
    {
        public CommaNode(
            string rawStr,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(rawStr, leadingWhitespace, trailingWhitespace) { }
    }

    public class SemicolonNode : SeparatorNode
    {
        public SemicolonNode(
            string raw,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(raw, leadingWhitespace, trailingWhitespace) { }
    }

    public class ColonNode : SeparatorNode
    {
        public ColonNode(
            string rawStr,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(rawStr, leadingWhitespace, trailingWhitespace) { }
    }
}

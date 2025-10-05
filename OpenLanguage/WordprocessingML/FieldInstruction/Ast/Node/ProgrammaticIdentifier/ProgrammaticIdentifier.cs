using System.Collections.Generic;

namespace OpenLanguage.WordprocessingML.Ast
{
    public class ProgrammaticIdentifierNode : WordprocessingML.Ast.ExpressionNode
    {
        public ProgrammaticIdentifier.ProgrammaticIdentifier ProgId { get; set; }

        public override int Precedence => base.Precedence;

        public ProgrammaticIdentifierNode(
            ProgrammaticIdentifier.ProgrammaticIdentifier progId,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            ProgId = progId;
        }

        public override string ToRawString() => ProgId.ToString();

        public override IEnumerable<O> Children<O>()
        {
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement) => null;
    }
}

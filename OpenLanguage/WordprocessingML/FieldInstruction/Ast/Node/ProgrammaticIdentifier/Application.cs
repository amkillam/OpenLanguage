using System.Collections.Generic;

namespace OpenLanguage.WordprocessingML.Ast
{
    public class ProgrammaticIdentifierApplicationNode : WordprocessingML.Ast.ExpressionNode
    {
        public ProgrammaticIdentifier.Application Application { get; set; }

        public override int Precedence => base.Precedence;

        public ProgrammaticIdentifierApplicationNode(
            ProgrammaticIdentifier.Application application,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Application = application;
        }

        public override string ToRawString() => Application.ToString();

        public override IEnumerable<O> Children<O>()
        {
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement) => null;
    }
}

using System.Collections.Generic;

namespace OpenLanguage.WordprocessingML.Ast
{
    // Just serves as a base class for all cell reference nodes
    // to use in general abstraction of "cell reference"-like child nodes in other classes.
    public abstract class CellReferenceNode : ExpressionNode
    {
        protected CellReferenceNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace) { }
    }
}

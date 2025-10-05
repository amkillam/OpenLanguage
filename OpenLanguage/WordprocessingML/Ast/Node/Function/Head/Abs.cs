using System.Collections.Generic;

namespace OpenLanguage.WordprocessingML.Ast
{
    public class AbsFunctionNode : FunctionNode
    {
        public AbsFunctionNode(
            StringLiteralNode functionName,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(functionName, leadingWhitespace, trailingWhitespace) { }
    }
}

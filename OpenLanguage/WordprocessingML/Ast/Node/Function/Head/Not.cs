using System.Collections.Generic;

namespace OpenLanguage.WordprocessingML.Ast
{
    public class NotFunctionNode : FunctionNode
    {
        public NotFunctionNode(
            StringLiteralNode functionName,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(functionName, leadingWhitespace, trailingWhitespace) { }
    }
}

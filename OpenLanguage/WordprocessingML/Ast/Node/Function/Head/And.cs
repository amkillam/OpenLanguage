using System.Collections.Generic;

namespace OpenLanguage.WordprocessingML.Ast
{
    public class AndFunctionNode : FunctionNode
    {
        public AndFunctionNode(
            StringLiteralNode functionName,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(functionName, leadingWhitespace, trailingWhitespace) { }
    }
}

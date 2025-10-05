using System.Collections.Generic;

namespace OpenLanguage.WordprocessingML.Ast
{
    public class IntFunctionNode : FunctionNode
    {
        public IntFunctionNode(
            StringLiteralNode functionName,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(functionName, leadingWhitespace, trailingWhitespace) { }
    }
}

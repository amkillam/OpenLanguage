using System.Collections.Generic;

namespace OpenLanguage.WordprocessingML.Ast
{
    public class SignFunctionNode : FunctionNode
    {
        public SignFunctionNode(
            StringLiteralNode functionName,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(functionName, leadingWhitespace, trailingWhitespace) { }
    }
}

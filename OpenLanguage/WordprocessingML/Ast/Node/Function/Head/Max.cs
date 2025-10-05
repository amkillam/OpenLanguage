using System.Collections.Generic;

namespace OpenLanguage.WordprocessingML.Ast
{
    public class MaxFunctionNode : FunctionNode
    {
        public MaxFunctionNode(
            StringLiteralNode functionName,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(functionName, leadingWhitespace, trailingWhitespace) { }
    }
}

using System.Collections.Generic;

namespace OpenLanguage.WordprocessingML.Ast
{
    public class MinFunctionNode : FunctionNode
    {
        public MinFunctionNode(
            StringLiteralNode functionName,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(functionName, leadingWhitespace, trailingWhitespace) { }
    }
}

using System.Collections.Generic;

namespace OpenLanguage.WordprocessingML.Ast
{
    public class OrFunctionNode : FunctionNode
    {
        public OrFunctionNode(
            StringLiteralNode functionName,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(functionName, leadingWhitespace, trailingWhitespace) { }
    }
}

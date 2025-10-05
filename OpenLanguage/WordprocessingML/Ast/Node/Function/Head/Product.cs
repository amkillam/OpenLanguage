using System.Collections.Generic;

namespace OpenLanguage.WordprocessingML.Ast
{
    public class ProductFunctionNode : FunctionNode
    {
        public ProductFunctionNode(
            StringLiteralNode functionName,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(functionName, leadingWhitespace, trailingWhitespace) { }
    }
}

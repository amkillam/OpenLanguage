using System.Collections.Generic;

namespace OpenLanguage.WordprocessingML.Ast
{
    public class DefinedFunctionNode : FunctionNode
    {
        public DefinedFunctionNode(
            StringLiteralNode functionName,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(functionName, leadingWhitespace, trailingWhitespace) { }
    }
}

using System.Collections.Generic;

namespace OpenLanguage.WordprocessingML.Ast
{
    public class ModFunctionNode : FunctionNode
    {
        public ModFunctionNode(
            StringLiteralNode functionName,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(functionName, leadingWhitespace, trailingWhitespace) { }
    }
}

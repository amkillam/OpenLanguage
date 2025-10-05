using System.Collections.Generic;

namespace OpenLanguage.WordprocessingML.Ast
{
    public class FalseFunctionNode : FunctionNode
    {
        public FalseFunctionNode(
            StringLiteralNode functionName,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(functionName, leadingWhitespace, trailingWhitespace) { }
    }
}

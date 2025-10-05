using System.Collections.Generic;

namespace OpenLanguage.WordprocessingML.Ast
{
    public class TrueFunctionNode : FunctionNode
    {
        public TrueFunctionNode(
            StringLiteralNode functionName,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(functionName, leadingWhitespace, trailingWhitespace) { }
    }
}

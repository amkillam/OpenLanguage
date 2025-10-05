using System.Collections.Generic;

namespace OpenLanguage.WordprocessingML.Ast
{
    public class AverageFunctionNode : FunctionNode
    {
        public AverageFunctionNode(
            StringLiteralNode functionName,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(functionName, leadingWhitespace, trailingWhitespace) { }
    }
}

using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.WordprocessingML.Ast
{
    public abstract class FunctionNode : ExpressionNode
    {
        public StringLiteralNode FunctionName { get; set; }

        public FunctionNode(
            StringLiteralNode functionName,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            FunctionName = functionName;
        }

        public override string ToRawString() => FunctionName.ToString();

        public override IEnumerable<O> Children<O>()
        {
            if (FunctionName is O o)
            {
                yield return o;
            }
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            if (index == 0 && replacement is StringLiteralNode sln)
            {
                StringLiteralNode old = FunctionName;
                FunctionName = sln;
                return old;
            }
            return null;
        }
    }
}

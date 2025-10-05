using System.Collections.Generic;

namespace OpenLanguage.WordprocessingML.Ast
{
    public abstract class A1RowNode : RowNode<ulong>
    {
        public A1RowNode(
            ulong val,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(val, leadingWhitespace, trailingWhitespace) { }
    }

    public class A1AbsoluteRowNode : A1RowNode
    {
        public A1AbsoluteRowNode(
            ulong val,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(val, leadingWhitespace, trailingWhitespace) { }
    }
}

using System.Collections.Generic;

namespace OpenLanguage.WordprocessingML.Ast
{
    public class TableReferenceNode : ExpressionNode
    {
        public ExpressionNode Name { get; set; }

        public TableReferenceNode(
            ExpressionNode name,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Name = name;
        }

        public override string ToRawString() => Name.ToString();

        public override IEnumerable<O> Children<O>()
        {
            if (Name is O n)
            {
                yield return n;
            }
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;

            if (index == 0 && replacement is ExpressionNode n)
            {
                current = Name;
                Name = n;
            }
            return current;
        }
    }
}

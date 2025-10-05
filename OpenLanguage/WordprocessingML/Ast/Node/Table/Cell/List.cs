using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.WordprocessingML.Ast
{
    public class CellReferenceNodeList : ExpressionListNode
    {
        public new List<CellReferenceNode> Items { get; set; }
        public new List<CommaNode> Separators { get; set; }

        public CellReferenceNodeList(
            List<CellReferenceNode> items,
            List<CommaNode> separators,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Items = items;
            Separators = separators;
        }

        public override string ToRawString()
        {
            System.Text.StringBuilder sb = new();
            for (int i = 0; i < Items.Count; i++)
            {
                sb.Append(Items[i].ToString());
                if (i < Separators.Count)
                {
                    sb.Append(Separators[i].ToString());
                }
            }
            return sb.ToString();
        }

        public override IEnumerable<O> Children<O>()
        {
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i] is O item)
                {
                    yield return item;
                }
                if (i < Separators.Count && Separators[i] is O sep)
                {
                    yield return sep;
                }
            }
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;
            int currentIndex = 0;
            for (int i = 0; i < Items.Count; i++)
            {
                if (currentIndex == index)
                {
                    if (replacement is CellReferenceNode item)
                    {
                        current = Items[i];
                        Items[i] = item;
                        return current;
                    }
                }
                currentIndex++;
                if (i < Separators.Count)
                {
                    if (currentIndex == index)
                    {
                        if (replacement is CommaNode sep)
                        {
                            current = Separators[i];
                            Separators[i] = sep;
                            return current;
                        }
                    }
                    currentIndex++;
                }
            }
            return null;
        }
    }
}

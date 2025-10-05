using System.Collections.Generic;

namespace OpenLanguage.WordprocessingML.Ast
{
    public class ExpressionListNode : ExpressionNode
    {
        public List<ExpressionNode> Items { get; set; }
        public List<SeparatorNode> Separators { get; set; }

        public ExpressionListNode(
            List<ExpressionNode> items,
            List<SeparatorNode> separators,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Items = items;
            Separators = separators;
        }

        public ExpressionListNode(
            ExpressionNode item,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Items = new List<ExpressionNode> { item };
            Separators = new List<SeparatorNode>();
        }

        public ExpressionListNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Items = new List<ExpressionNode>();
            Separators = new List<SeparatorNode>();
        }

        public override string ToRawString()
        {
            System.Text.StringBuilder result = new();
            for (int i = 0; i < Items.Count; i++)
            {
                result.Append(Items[i].ToString());
                if (i < Separators.Count)
                {
                    result.Append(Separators[i].ToString());
                }
            }
            return result.ToString();
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
            int childIndex = 0;
            for (int i = 0; i < Items.Count; i++)
            {
                if (childIndex == index)
                {
                    if (replacement is ExpressionNode expr)
                    {
                        current = Items[i];
                        Items[i] = expr;
                        return current;
                    }
                }
                childIndex++;

                if (i < Separators.Count)
                {
                    if (childIndex == index)
                    {
                        if (replacement is SeparatorNode sep)
                        {
                            current = Separators[i];
                            Separators[i] = sep;
                            return current;
                        }
                    }
                    childIndex++;
                }
            }
            return current;
        }
    }
}

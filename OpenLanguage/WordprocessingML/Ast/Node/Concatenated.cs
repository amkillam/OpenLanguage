using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.WordprocessingML.Ast
{
    public class ConcatenatedNodes : ExpressionNode
    {
        public List<ExpressionNode> Nodes { get; set; }

        public ConcatenatedNodes(
            List<ExpressionNode> nodes,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Nodes = nodes;
            Nodes.TrimExcess();
        }

        public override string ToRawString() => string.Concat(Nodes.Select(n => n.ToString()));

        public override IEnumerable<O> Children<O>()
        {
            foreach (ExpressionNode node in Nodes)
            {
                if (node is O o)
                {
                    yield return o;
                }
            }
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;
            if (index >= 0 && index < Nodes.Count && replacement is ExpressionNode expr)
            {
                current = Nodes[index];
                Nodes[index] = expr;
            }
            return current;
        }

        public void Add(ExpressionNode node) => Nodes.Add(node);
    }
}

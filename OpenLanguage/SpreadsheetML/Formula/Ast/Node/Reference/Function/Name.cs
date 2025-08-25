using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.SpreadsheetML.Formula.Ast
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

        public override int Precedence => Ast.Precedence.Primary;
    }

    public class UserDefinedFunctionNode : NameNode
    {
        public UserDefinedFunctionNode(
            ExpressionNode name,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(name, leadingWhitespace, trailingWhitespace) { }
    }

    public class BuiltInFunctionNode : NameNode
    {
        public BuiltInFunctionNode(
            ExpressionNode name,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(name, leadingWhitespace, trailingWhitespace) { }

        public static BuiltInFunctionNode CreatePrefixed(
            ExpressionNode prefix,
            ExpressionNode name,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
        {
            ExpressionNode combinedName = new ConcatenatedNodes(
                new List<ExpressionNode> { prefix, name },
                leadingWhitespace,
                trailingWhitespace
            );

            return new BuiltInFunctionNode(combinedName, leadingWhitespace, trailingWhitespace);
        }
    }

    public class BuiltInStandardFunctionNode : BuiltInFunctionNode
    {
        public BuiltInStandardFunctionNode(
            ExpressionNode name,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(name, leadingWhitespace, trailingWhitespace) { }
    }

    public class BuiltInFutureFunctionNode : BuiltInFunctionNode
    {
        public BuiltInFutureFunctionNode(
            ExpressionNode name,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(name, leadingWhitespace, trailingWhitespace) { }
    }

    public class BuiltInMacroFunctionNode : BuiltInFunctionNode
    {
        public BuiltInMacroFunctionNode(
            ExpressionNode name,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(name, leadingWhitespace, trailingWhitespace) { }
    }

    public class BuiltInCommandFunctionNode : BuiltInFunctionNode
    {
        public QuestionMarkNode? QuestionMark { get; set; }

        public BuiltInCommandFunctionNode(
            ExpressionNode name,
            QuestionMarkNode? qMarkNode,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(name, leadingWhitespace, trailingWhitespace)
        {
            QuestionMark = qMarkNode;
        }

        public override string ToRawString() =>
            (base.ToRawString() + (QuestionMark?.ToString() ?? string.Empty));
    }

    public class BuiltInWorksheetFunctionNode : BuiltInFunctionNode
    {
        public BuiltInWorksheetFunctionNode(
            ExpressionNode prefix,
            ExpressionNode functionNode,
            List<Node>? leadingWs = null,
            List<Node>? trailingWs = null
        )
            : base(
                new ConcatenatedNodes(new List<ExpressionNode>() { prefix, functionNode }),
                leadingWs,
                trailingWs
            ) { }
    }
}

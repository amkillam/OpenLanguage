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

        public override int Precedence => Ast.Precedence.Primary;
    }

    public class ConcatenatedNodePair<L, R> : ExpressionNode
        where L : ExpressionNode
        where R : ExpressionNode
    {
        public L Left { get; set; }
        public R Right { get; set; }

        public ConcatenatedNodePair(
            L left,
            R right,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Left = left;
            Right = right;
        }

        public override string ToRawString() => Left.ToString() + Right.ToString();

        public override IEnumerable<O> Children<O>()
        {
            if (Left is O l)
            {
                yield return l;
            }
            if (Right is O r)
            {
                yield return r;
            }
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;
            if (index == 0 && replacement is L leftRep)
            {
                current = Left as Node;
                Left = leftRep;
            }
            else if (index == 1 && replacement is R rightRep)
            {
                current = Right as Node;
                Right = rightRep;
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
            ExpressionNode? prefix,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                prefix == null
                    ? name
                    : new ConcatenatedNodes(new List<ExpressionNode>() { prefix, name }),
                leadingWhitespace,
                trailingWhitespace
            ) { }

        public BuiltInFunctionNode(
            ExpressionNode name,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(name, leadingWhitespace, trailingWhitespace) { }
    }

    public class StandardFunctionNode : BuiltInFunctionNode
    {
        public StandardFunctionNode(
            ExpressionNode name,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(name, leadingWhitespace, trailingWhitespace) { }
    }

    public class FutureFunctionNode : BuiltInFunctionNode
    {
        public FutureFunctionNode(
            ExpressionNode name,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(name, prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class MacroFunctionNode : BuiltInFunctionNode
    {
        public MacroFunctionNode(
            ExpressionNode name,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(name, leadingWhitespace, trailingWhitespace) { }
    }

    public class CommandFunctionNode : BuiltInFunctionNode
    {
        public QuestionMarkNode? QuestionMark { get; set; }

        public CommandFunctionNode(
            ExpressionNode name,
            QuestionMarkNode? qMarkNode = null,
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

    public class WorksheetFunctionNode : BuiltInFunctionNode
    {
        public WorksheetFunctionNode(
            NameNode name,
            List<Node>? leadingWs = null,
            List<Node>? trailingWs = null
        )
            : base(name, leadingWs, trailingWs) { }

        public WorksheetFunctionNode(
            NameNode name,
            XlfnFunctionPrefixNode? xlfnPrefix = null,
            XlwsFunctionPrefixNode? xlwsPrefix = null,
            List<Node>? leadingWs = null,
            List<Node>? trailingWs = null
        )
            : base(name, leadingWs, trailingWs)
        {
            switch (xlfnPrefix, xlwsPrefix)
            {
                case (XlfnFunctionPrefixNode xlfnPrefixNode, XlwsFunctionPrefixNode xlwsPrefixNode):
                {
                    ConcatenatedNodes concatenatedPrefixes = new ConcatenatedNodes(
                        new List<ExpressionNode>() { xlfnPrefixNode, xlwsPrefixNode }
                    );
                    Name = new ConcatenatedNodes(
                        new List<ExpressionNode>() { concatenatedPrefixes, name }
                    );
                    break;
                }
                case (XlfnFunctionPrefixNode xlfnPrefixNode, null):
                    Name = new ConcatenatedNodes(
                        new List<ExpressionNode>() { xlfnPrefixNode, name }
                    );
                    break;
                case (null, XlwsFunctionPrefixNode xlwsPrefixNode):
                    Name = new ConcatenatedNodes(
                        new List<ExpressionNode>() { xlwsPrefixNode, name }
                    );
                    break;
                default:
                    break;
            }
        }
    }
}
